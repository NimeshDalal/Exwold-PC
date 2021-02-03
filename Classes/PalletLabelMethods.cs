using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Exwold.Desktop
{
    public class PalletLabelMethods
    {
        #region Local variables
        //Data variables
        private readonly DataInterface.execFunction _db = null;
        private NiceLabel niceLabel = null;
        private int _plantNumber = 0;
        #endregion

        #region Constructor
        public PalletLabelMethods(DataInterface.execFunction database)
        {
            _db = database;
            try
            {
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["plantNumber"], out _plantNumber);
                niceLabel = new NiceLabel(System.Configuration.ConfigurationManager.AppSettings["NiceLabelSDKPath"]);
            }
            catch { }
        }
        #endregion

        /// <summary>
        /// Return a list of the configured printers (from the App.Config file)
        /// </summary>
        /// <returns></returns>
        internal List<string> GetPalletLabelPrinters()
        {
            List<string> printers = new List<string>();
            ExwoldConfigSettings settings = new ExwoldConfigSettings(_plantNumber);
            foreach (PalletLabelPrinterConfigElement printer in settings.PalletLabelPrinters)
            {
                printers.Add(printer.Name);
            }
            return printers;
        }

        /// <summary>
        /// Prints a single label to the given printer
        /// </summary>
        /// <param name="label">Data for the label</param>
        /// <param name="PrinterName">Printer to print to</param>
        /// <param name="PrintQty">Number of copied to print</param>

        internal async void SendLabelToPrinter(PalletLabelData label, string PrinterName, int PrintQty)
        {       
            try
            {
                //Update the print Qty and print
                label.PrintQty = PrintQty;
                // Set the print Qty to at least 1
                PrintQty = PrintQty < 1 ? 1 : PrintQty;
                await niceLabel.PrintPalletLabel(label, PrinterName);
            }
            catch { }
        }
        /// <summary>
        /// Prints a list of labels to the given printer
        /// </summary>
        /// <param name="PrintLabels">List of label data</param>
        /// <param name="PrinterName">Printer to print to</param>
        /// <param name="PrintQty">Number of copied to print</param>
        internal void SendLabelToPrinter(List<PalletLabelData> PrintLabels, string PrinterName, int PrintQty)
        {
            try
            {
                //Update the print Qty and print
                foreach (PalletLabelData label in PrintLabels)
                {
                    SendLabelToPrinter(label, PrinterName, PrintQty);
                }
            }
            catch { }
        }


        /// <summary>
        /// Get the Label(s) for a given PalletUId
        /// Called From the Scanner
        /// </summary>
        /// <param name="PalletLabelUId"></param>
        /// <returns></returns>
        public async Task<List<PalletLabelData>> fetchLabelsByPallet(int PalletUId)
        {
            List<PalletLabelData> labels = new List<PalletLabelData>();
            //Get the PalletBatch UId
            int PalletBatchUId = int.MinValue;
            try
            {
                DataTable dtPalletBatchByPallet = await getPalletBatchByPalletId(PalletUId);
                if (dtPalletBatchByPallet != null && dtPalletBatchByPallet.Rows.Count > 0)
                {
                    int.TryParse(dtPalletBatchByPallet.Rows[0]["PalletBatchUniqueNo"].ToString(), out PalletBatchUId);
                }
                if (PalletBatchUId > 0)
                {
                    return await fetchLabelsByPalletBatch(PalletBatchUId);
                }
                return null;
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(),
                    "EXCEPTION: ScannerPrint: Failed to get data from DB (Incorrect data?): " + ex.Message);
            }
            return labels;
        }

        /// <summary>
        /// Get the label(s) for a given PalletBatchUId
        /// </summary>
        /// <param name="PalletBatchUId"></param>
        /// <returns></returns>
        public async Task<List<PalletLabelData>> fetchLabelsByPalletBatch(int PalletBatchUId)
        {
            int NoOfBatches = int.MinValue;
            int PalletUId = int.MinValue;
            DataTable dtPalletBatch = null;
            DataTable dtBatchesOnPallet = null;
            DataTable dtPalletLabels = null;
            List<PalletLabelData> pLabels = new List<PalletLabelData>();
            PalletLabelData _labelData = new PalletLabelData();

            try
            {
                /*
                 * Get the the label(s) for a pallet
                 * Collect the data first
                 */
                dtPalletBatch = await getPalletBatch(PalletBatchUId);
                dtBatchesOnPallet = await getBatchesOnPallet(PalletBatchUId);
                if (dtBatchesOnPallet != null)
                {
                    NoOfBatches = dtBatchesOnPallet.Rows.Count;
                    if (NoOfBatches > 0) //some pallet data exists, set label numbers and calculate batch data
                    {
                        //Get the PalletUId of the first returned
                        PalletUId = int.Parse(dtBatchesOnPallet.Rows[0].Field<Int64>("PalletUniqueNo").ToString());
                    }
                }
                // Get the Labels for this Pallet
                dtPalletLabels = await getPalletLabels(PalletUId);
            }
            catch(Exception ex)
            {
                //Error getting the data
            }
            try
            {
                _labelData.NetUnits_AI = dtPalletBatch.Rows[0]["UnitsOfMeasure"].ToString().Trim();
                _labelData.GMID = dtPalletBatch.Rows[0]["GMID"].ToString();
                _labelData.ProductionLineNo = dtPalletBatch.Rows[0]["ProductionLineNo"].ToString();

                _labelData.TotalLabels = NoOfBatches.ToString();

                for (int i = 0; i < NoOfBatches; i++)
                {
                    _labelData.Count = dtPalletLabels.Rows[i]["CartonsOnPallet"].ToString();
                    _labelData.NetUnits = dtPalletLabels.Rows[i]["QtyInner"].ToString();
                    _labelData.BatchNumber = dtPalletLabels.Rows[i]["MaterialBatchNo"].ToString();
                    _labelData.ProductionDate = dtPalletLabels.Rows[i]["ProdDate"].ToString();
                    _labelData.SSCC = dtPalletLabels.Rows[i]["SSCC"].ToString();
                    _labelData.GTIN = dtPalletLabels.Rows[i]["GTIN"].ToString();
                    _labelData.NetVolume = dtPalletLabels.Rows[i]["NetVolOrWt"].ToString();
                    _labelData.LabelNumber = i + 1.ToString();  //Add 1 for the display

                    string baseLabelPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\labels\\";
                    string labelname = string.Empty;
                    //Set label Path

                    if (_labelData.NetUnits_AI.ToUpper() == "KG")
                    {
                        labelname = "ExwoldPalletLabel1K";
                    }
                    if (_labelData.NetUnits_AI.ToUpper() == "L")
                    {
                        labelname = "ExwoldPalletLabel1L";
                    }
                    if (i > 0)
                    {
                        labelname = labelname + "_Additional";
                    }
                    _labelData.LabelPath = $"{baseLabelPath}{labelname}.nlbl";
                    pLabels.Add(_labelData);
                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(),
                    "EXCEPTION: Print: Failed to get data from DB (Incorrect data?): " + ex.Message);
            }

            return pLabels;
        }


        private async Task<DataTable> getPalletBatch(int palletBatchId)
        {
            //"SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchId", palletBatchId.ToString());
            return await _db.executeSP("[GUI].[getPalletBatchById]", true);
        }
        private async Task<DataTable> getBatchesOnPallet(int palletBatchId)
        {
            //"SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;

            //Get batches\carton number on Pallet
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchId", palletBatchId.ToString());
            return await _db.executeSP("[GUI].[getPalletByPalletBatchId]", true);
        }
        private async Task<DataTable> getPalletLabels(int palletUId)
        {
            //"SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletUId", palletUId.ToString());
            return await _db.executeSP("[GUI].[getPalletLabelByPalletId]", true);
        }
        private async Task<DataTable> getProductByGTIN(string GTIN)
        {
            //"SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + 
            //dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";

            // GetProduct name from GTIN
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("GTIN", GTIN);
            return await _db.executeSP("[GUI].[getProductByGTIN]", true);
        }
        private async Task<DataTable> getPalletBatchByPalletId(int palletUId)
        {
            //SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = 
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletId", palletUId.ToString());
            return await _db.executeSP("[GUI].[getPalletBatchByPalletId]", true);

        }
        
    }

}
