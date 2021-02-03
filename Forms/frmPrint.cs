
/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmPrint.cs
 * Description: Handles the Print function when recieved from the scannjer with no user input
 *              Provides an interface to select a printer when:
 *              1)  The print function is selected from the batch details page
 *              2)  The scanner sends a reprint command
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  04Apr2017   702678          Stuart Eglington 
 *              Initial Creation
 * 1.01         1.03.00.00  30Jan2018   991068/CRF002   Martin Cox
 *              Added ORDER BY startement on line 251 to the lines 351 and 495.
 *              Added single quotes around GTIN in SQL as it's a string (not a number).
 *              Added better debug logging.
 *              In InitializePrintEngine() using value from config file for NiceLabel SDK directory
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using NiceLabel.SDK;
using System.Data;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ITS.Exwold.Desktop
{
    /// <summary>
    /// The main Form class.
    /// </summary>
    public partial class frmPrint : Form
    {
        #region Local variables
        //Data variables
        private readonly DataInterface.execFunction _db = null;
        private PalletLabelMethods palletLabelMethods = null;
        List<PalletLabelData> plInfo;
        #endregion

        public string PrintBatchFlag { get; set; }
        public string PrintBatchID { get; set; }

        private int PalletBatchID;


        #region Properties

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="frmPrint"/> class.
        /// </summary>
        /// 
        public frmPrint(DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
            palletLabelMethods = new PalletLabelMethods(_db);
        }

        //private async void tabPrintForms_Enter(object sender, EventArgs e)
        //{
        //    GetPalletLabelData plData = new GetPalletLabelData(_db, 1);
        //    List<PalletLabelInfo> plInfo = await plData.getPalletBatchLabels(1942);

        //    if (plInfo != null && plInfo.Count > 0)
        //    {
        //        DisplayData(plInfo[0]);
        //    }


        //}
        private async void PrintForm_Load(object sender, EventArgs e)
        {
            //set top
            this.TopMost = true;
            /*
             * Populated the printer combobox
             */
            cboPalletPrinter.DataSource = palletLabelMethods.GetPalletLabelPrinters();

            if (PrintBatchFlag == "Print")
            {
                try
                {
                    plInfo = await palletLabelMethods.fetchLabelsByPalletBatch(int.Parse(PrintBatchID));
                    if (plInfo != null && plInfo.Count > 0)
                    {
                        DisplayData(plInfo[0]);
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "EXCEPTION: Print:", ex);

                }
            }
            if (PrintBatchFlag == "ScannerPrint")
            {
                try
                {
                    plInfo = await palletLabelMethods.fetchLabelsByPallet(int.Parse(PrintBatchID));
                    if (plInfo != null && plInfo.Count > 0)
                    {
                        DisplayData(plInfo[0]);
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "EXCEPTION: ScannerPrint: ", ex);
                }
            }


            /// <summary>
            /// Handles the Click event of the PrintButton control.
            /// </summary>
            if (PrintBatchFlag == "Reprint")
            {
                try
                {
                    plInfo = await palletLabelMethods.fetchLabelsByPallet(int.Parse(PrintBatchID));
                    if (plInfo != null && plInfo.Count > 0)
                    {
                        DisplayData(plInfo[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RePrint: Failed to get data from DB (Incorrect data?)");

                }
            }
        }

        private void DisplayData(PalletLabelData plData)
        {

            tbPalletGMID.Text = plData == null ? string.Empty : plData.GMID;
            tbPalletCount.Text = plData == null ? string.Empty : plData.Count;
            tbPalletNetUnits.Text = plData == null ? string.Empty : plData.NetUnits;
            tbPalletNetVolume.Text = plData == null ? string.Empty : plData.NetVolume;
            tbPalletNetUnits_AI.Text = plData == null ? string.Empty : plData.NetUnits_AI;
            tbPalletBatchNumber.Text = plData == null ? string.Empty : plData.BatchNumber;
            tbPalletProductionDate.Text = plData == null ? string.Empty : plData.ProductionDate;
            tbPalletSSCC.Text = plData == null ? string.Empty : plData.SSCC;
            tbPalletGTIN.Text = plData == null ? string.Empty : plData.GTIN;
            tbPalletLabelNumber.Text = plData == null ? string.Empty : plData.LabelNumber;
            tbPalletTotalLabels.Text = plData == null ? string.Empty : plData.TotalLabels;
            tbPalletProductionLineNumber.Text = plData == null ? string.Empty : plData.ProductionLineNo;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int PrintQty = int.MinValue;
                int.TryParse(tbPrintQuantity.Text, out PrintQty);
                // Set the print Qty to at least 1
                PrintQty = PrintQty < 1 ? 1 : PrintQty;

                palletLabelMethods.SendLabelToPrinter(plInfo, cboPalletPrinter.Text, PrintQty);           
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "EXCEPTION: RePrint: ", ex);
                Program.Log.logSave();
                this.Close();
            }
        }

        private void btnPalletClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}

