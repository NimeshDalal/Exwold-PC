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

        #region Public Methods
        public async Task<bool> PrintPalletLabels(int PalletUId, int PrintQty = 1)
        {
            List<PalletLabelData> plData;
            bool bRtn = false;
            try
            {
                plData = await PalletLabelData(PalletUId);
                if (plData != null && plData.Count > 0)
                {
                    SendLabelToPrinter(plData, PalletLabelPrinterForLine(plData[0].ProductionLineNo), PrintQty);
                    bRtn = true;
                }
                
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
            }
            return bRtn;
        }
        public async void PrintBatchLabels(int PalletBatchUId, int PrintQty = 1)
        {
            int NoOfBatchesOnPallet = int.MinValue;
            int PalletUId = int.MinValue;
            //Print a set of labels for the whole batch
            DataTable dtBatchesOnPallet = null;
            PalletLabelData labelbase = new PalletLabelData();
            List<PalletLabelData> plData;
            try
            {
                dtBatchesOnPallet = await getBatchesOnPallet(PalletBatchUId);
                if (dtBatchesOnPallet != null)
                {
                    NoOfBatchesOnPallet = dtBatchesOnPallet.Rows.Count;
                    if (NoOfBatchesOnPallet > 0) //some pallet data exists, set label numbers and calculate batch data
                    {
                        labelbase = await getLabelBase(PalletBatchUId);
                        foreach(DataRow row in dtBatchesOnPallet.Rows)
                        {
                            //Get the PalletUId
                            PalletUId = int.Parse(row.Field<Int64>("PalletUniqueNo").ToString());
                            if (PalletUId > 0)
                            {
                                plData = new List<PalletLabelData>();
                                plData = await getLabelDetails(labelbase, PalletUId);
                                SendLabelToPrinter(plData, PalletLabelPrinterForLine(labelbase.ProductionLineNo), PrintQty);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// Return a list of ALL of the configured printers for this plant (from the App.Config file)
        /// </summary>
        /// <returns>List of the configured printer names</returns>
        public List<string> PalletLabelPrinters()
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
        /// For this plant, and the return the default printer for the production line
        /// If none found, then return the first printer from the App.Config file.
        /// </summary>
        /// <param name="ProductionLine">Line number to get the printer for</param>
        /// <returns>The default printer for the line</returns>
        public string PalletLabelPrinterForLine(int ProductionLine)
        {
            ExwoldConfigSettings settings = new ExwoldConfigSettings(_plantNumber);
            foreach (PalletLabelPrinterConfigElement printer in settings.PalletLabelPrinters)
            {
                if (printer.ProductionLine == ProductionLine)
                    return printer.Name;                
            }
            //If not found then return the first printer in the list
            return settings.PalletLabelPrinters[0].Name;
        }

        /// <summary>
        /// Prints a list of labels to the given printer
        /// </summary>
        /// <param name="PrintLabels">List of label data</param>
        /// <param name="PrinterName">Printer to print to</param>
        /// <param name="PrintQty">Number of copied to print</param>
        public void SendLabelToPrinter(List<PalletLabelData> PrintLabels, string PrinterName, int PrintQty)
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

        public async Task<List<PalletLabelData>> PalletLabelData(int PalletUId)
        {
            //Get the label data for a given Pallet
            int PalletBatchUId = int.MinValue;
            PalletLabelData labelbase = new PalletLabelData();
            List<PalletLabelData> plData = new List<PalletLabelData>();
            try
            {
                // Get the Pallet Batch data
                DataTable dtPalletBatchByPallet = await getPalletBatchByPalletId(PalletUId);
                if (dtPalletBatchByPallet != null && dtPalletBatchByPallet.Rows.Count > 0)
                {
                    int.TryParse(dtPalletBatchByPallet.Rows[0]["PalletBatchUniqueNo"].ToString(), out PalletBatchUId);
                }
                if (PalletBatchUId > 0)
                {
                    // Get the base data from the PalletBatch
                    labelbase = await getLabelBase(PalletBatchUId);
                    // Get the label data for the given Pallet
                    plData = await getLabelDetails(labelbase, PalletUId);
                }
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
            }
            return plData;
        }


        #region Private Methods
        /// <summary>
        /// Prints a single label to the given printer
        /// </summary>
        /// <param name="label">Data for the label</param>
        /// <param name="PrinterName">Printer to print to</param>
        /// <param name="PrintQty">Number of copied to print</param>
        private async void SendLabelToPrinter(PalletLabelData label, string PrinterName, int PrintQty)
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
        /// Get the base label data from the PalletBatch record
        /// </summary>
        /// <param name="PalletBatchUId">The PalletBatch UId </param>
        /// <returns>A partially complete PalletLabelData class</returns>
        private async Task<PalletLabelData> getLabelBase(int PalletBatchUId)
        {
            int NoOfBatchesOnPallet = int.MinValue;
            DataTable dtPalletBatch = null;
            DataTable dtBatchesOnPallet = null;
            PalletLabelData baseData = new PalletLabelData();

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
                    NoOfBatchesOnPallet = dtBatchesOnPallet.Rows.Count;
                    if (NoOfBatchesOnPallet > 0) //some pallet data exists, set label numbers and calculate batch data
                    {
                        baseData.NetUnits_AI = dtPalletBatch.Rows[0]["UnitsOfMeasure"].ToString().Trim();
                        baseData.GMID = dtPalletBatch.Rows[0]["GMID"].ToString();
                        baseData.ProductionLineNo = int.Parse(dtPalletBatch.Rows[0]["ProductionLineNo"].ToString());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(),
                    "EXCEPTION: Print: Failed to get data from DB (Incorrect data?): " + ex.Message);
            }

            return baseData;
        }
        /// <summary>
        /// Takes the base label data, and then for each label with a matching Pallet UId
        /// fetches the data to be included in the printout
        /// </summary>
        /// <param name="baseData">Data fro mthe PalletBatch record</param>
        /// <param name="PalletUId">The UId of the pallet to get the labels for</param>
        /// <returns></returns>
        private async Task<List<PalletLabelData>> getLabelDetails(PalletLabelData baseData, int PalletUId)
        {
            //The base info is passed in
            //Return a list of the completed data
            List<PalletLabelData> pLabels = new List<PalletLabelData>();
            PalletLabelData updatedData;
            int NoOfLabelsOnPallet = int.MinValue;
            DataTable dtPalletLabels = null;
            
            try
            {
                /*
                 * Get the the label(s) for this pallet
                 */
                dtPalletLabels = await getPalletLabels(PalletUId);
                if (dtPalletLabels != null)
                {
                    NoOfLabelsOnPallet = dtPalletLabels.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), ex.Message);
            }
            try
            {
                //_labelData.TotalLabels = NoOfBatchesOnPallet.ToString();

                for (int i = 0; i < NoOfLabelsOnPallet; i++)
                {
                    updatedData = new PalletLabelData();
                    // Copy the base data
                    updatedData = baseData;                    
                    updatedData.Count = dtPalletLabels.Rows[i]["CartonsOnPallet"].ToString();
                    updatedData.NetUnits = dtPalletLabels.Rows[i]["QtyInner"].ToString();
                    updatedData.BatchNumber = dtPalletLabels.Rows[i]["MaterialBatchNo"].ToString();
                    updatedData.ProductionDate = dtPalletLabels.Rows[i]["ProdDate"].ToString();
                    updatedData.SSCC = dtPalletLabels.Rows[i]["SSCC"].ToString();
                    updatedData.GTIN = dtPalletLabels.Rows[i]["GTIN"].ToString();
                    updatedData.NetVolume = dtPalletLabels.Rows[i]["NetVolOrWt"].ToString();
                    updatedData.TotalLabels = NoOfLabelsOnPallet.ToString();
                    updatedData.LabelNumber = (i + 1).ToString();  //Add 1 for the display

                    string baseLabelPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\labels\\";
                    string labelname = string.Empty;
                    //Set label Path

                    if (updatedData.NetUnits_AI.ToUpper() == "KG")
                    {
                        labelname = "ExwoldPalletLabel1K";
                    }
                    if (updatedData.NetUnits_AI.ToUpper() == "L")
                    {
                        labelname = "ExwoldPalletLabel1L";
                    }
                    if (i > 0)
                    {
                        labelname = labelname + "_Additional";
                    }
                    updatedData.LabelPath = $"{baseLabelPath}{labelname}.nlbl";
                    pLabels.Add(updatedData);
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
        public async Task<DataTable> getPalletBatchByPalletId(int palletUId)
        {
            //SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = 
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletId", palletUId.ToString());
            return await _db.executeSP("[GUI].[getPalletBatchByPalletId]", true);

        }
        #endregion
    }
}
