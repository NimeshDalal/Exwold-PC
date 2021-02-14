
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
using System.ComponentModel;

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
        private readonly PalletLabelMethods _palletLabelMethods = null;
        private int _palletUId = int.MinValue;
        List<PalletLabelData> plData = null;
        #endregion


        #region Properties

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="frmPrint"/> class.
        /// </summary>
        /// 
        public frmPrint(DataInterface.execFunction database, int PalletUId)
        {
            InitializeComponent();
            _db = database;
            _palletLabelMethods = new PalletLabelMethods(_db);
            _palletUId = PalletUId;
            InitialiseData();

            // Set the form parameters
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = true;
            this.Icon = Properties.Resources.ExwoldApp;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ControlBox = true;
            this.HelpButton = false;

        }

        private async void InitialiseData()
        {
            plData = await _palletLabelMethods.PalletLabelData(_palletUId);
            if (plData != null && plData.Count > 0)
            {
                // Display the data we have collected
                DisplayData(plData[0]);

                // Get the printer data
                cboPalletPrinter.DataSource = _palletLabelMethods.PalletLabelPrinters();
                cboPalletPrinter.SelectedItem = _palletLabelMethods.PalletLabelPrinterForLine(plData[0].ProductionLineNo);
            }
        }
        public static DateTime LabelDate(string LabelDateString)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
            DateTime dtConverted = default(DateTime);
            DateTime.TryParseExact(LabelDateString, "yyMMdd", provider, System.Globalization.DateTimeStyles.None, out dtConverted);
            return dtConverted;
        }
        private void DisplayData(PalletLabelData plData)
        {

            tbPalletGMID.Text = plData == null ? string.Empty : plData.GMID;
            tbPalletCount.Text = plData == null ? string.Empty : plData.Count;
            tbPalletNetUnits.Text = plData == null ? string.Empty : plData.NetUnits;
            tbPalletNetVolOrWt.Text = plData == null ? string.Empty : plData.NetVolOrWt.Insert(4, ".");
            tbPalletNetUnits_AI.Text = plData == null ? string.Empty : plData.NetUnits_AI;
            tbPalletBatchNumber.Text = plData == null ? string.Empty : plData.BatchNumber;
            
            tbPalletProductionDate.Text = plData == null ? string.Empty : LabelDate(plData.ProductionDate).ToString("dd-MMMM-yyyy");
            tbPalletSSCC.Text = plData == null ? string.Empty : plData.SSCC;
            tbPalletGTIN.Text = plData == null ? string.Empty : plData.GTIN;
            tbPalletLabelNumber.Text = plData == null ? string.Empty : plData.LabelNumber;
            tbPalletTotalLabels.Text = plData == null ? string.Empty : plData.TotalLabels;
            tbPalletProductionLineNumber.Text = plData == null ? string.Empty : plData.ProductionLineNo.ToString();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int PrintQty = int.MinValue;
                int.TryParse(tbPrintQuantity.Text, out PrintQty);
                // Set the print Qty to at least 1
                PrintQty = PrintQty < 1 ? 1 : PrintQty;

                _palletLabelMethods.SendLabelToPrinter(plData, cboPalletPrinter.Text, PrintQty);           
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "EXCEPTION: Print: ", ex);
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

