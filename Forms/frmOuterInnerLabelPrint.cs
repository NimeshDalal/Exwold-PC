/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmOuterInnerLabels.cs
 * Description: Handles the Print function when recieved from the scannjer with no user input
 *              Provides an interface to select a printer when:
 *              1)  The print function is selected from the batch details page
 *              2)  The scanner sends a reprint command
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              Initial Creation
 *              InitializePrintEngine() using value from config file for NiceLabel SDK directory
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using NiceLabel.SDK;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ITS.Exwold.Desktop
{
    /// <summary>
    /// The main Form class.
    /// </summary>
    internal partial class frmOuterInnerLabels : Form
    {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        private int _palletBatchUId = -1;
        private int _outerPackUId = -1;
        private int _outerTotalLabels = 0;
        private int _outerQtyPrinted = 0;
        private int _innerPackUId = -1;
        private int _innerTotalLabels = 0;
        private int _innerQtyPrinted = 0;
        private NiceLabel niceLabel = new NiceLabel(System.Configuration.ConfigurationManager.AppSettings["NiceLabelSDKPath"]);
        private ExwoldConfigSettings _exwoldConfigSettings = null;
        #endregion
        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        internal int PalletBatchUId
        {
            get { return _palletBatchUId; }
            set { _palletBatchUId = value; }
        }
        internal ExwoldConfigSettings ExwoldConfigSettings
        {
            get { return _exwoldConfigSettings; }
            set { _exwoldConfigSettings = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="frmPrint"/> class.
        /// </summary>
        /// 
        internal frmOuterInnerLabels(DataInterface.execFunction database, int PalletBatchUId, ExwoldConfigSettings exwoldConfigSettings)
        {
            InitializeComponent();
            _db = database;
            _palletBatchUId = PalletBatchUId;
            _exwoldConfigSettings = exwoldConfigSettings;
            tbOuterPrinter.Text = _exwoldConfigSettings.OuterPackLabelPrinters[0].Name;
            tbInnerPrinter.Text = _exwoldConfigSettings.InnerPackLabelPrinters[0].Name;
            SetPrinters();
        }
        private void cboOuterPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"{cboOuterPrinters.SelectedIndex}, {cboOuterPrinters.SelectedItem}");
            tbOuterPrinter.Text = cboOuterPrinters.Text;
            SetPrinters();
        }
        private void cboInnerPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {           
            tbInnerPrinter.Text = cboInnerPrinters.Text;
            SetPrinters();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            //set top
            this.TopMost = true;
            getLabelData(_palletBatchUId);            
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            niceLabel.Dispose();
        }
        private void SetPrinters()
        {
            bool bRes = false;
            #region Outer Label Printer
            cboOuterPrinters.SelectedIndexChanged -= new System.EventHandler(this.cboOuterPrinters_SelectedIndexChanged);
            cboOuterPrinters.DataSource = niceLabel.LabelPrinters;
            cboOuterPrinters.DisplayMember = "Name";
            cboOuterPrinters.SelectedIndexChanged += new System.EventHandler(this.cboOuterPrinters_SelectedIndexChanged);
            bRes = validatePrinter(tbOuterPrinter, tbOuterPrinter.Text);
            btnOuterPrint.Enabled = bRes;
            grpOuterAvailPrinters.Visible = !bRes;
            #endregion
            #region Inner Label Printer
            cboInnerPrinters.SelectedIndexChanged -= new System.EventHandler(this.cboInnerPrinters_SelectedIndexChanged);
            cboInnerPrinters.DataSource = niceLabel.LabelPrinters;
            cboInnerPrinters.DisplayMember = "Name";
            cboInnerPrinters.SelectedIndexChanged += new System.EventHandler(this.cboInnerPrinters_SelectedIndexChanged);

            bRes = validatePrinter(tbInnerPrinter, tbInnerPrinter.Text);
            btnInnerPrint.Enabled = bRes;
            grpInnerAvailPrinters.Visible = !bRes;
            #endregion
        }
        private bool validatePrinter(TextBox tb, string PrinterName)
        {
            bool bPrinterOK = false;
            tb.Text = PrinterName;
            // Do we have the printer
            foreach (IPrinter prnt in niceLabel.LabelPrinters)
            {
                if (prnt.Name == PrinterName)
                {
                    bPrinterOK = true;
                    break;
                }
            }
            if (bPrinterOK)
            {
                epQtyToPrint.SetError(tb, "");
                return true;
            }
            else
            {
                epQtyToPrint.SetError(tb, "Printer NOT available");
                return false;
            }
        }

        private async void getLabelData(int PalletBatchUId)
        {

            DataTable dtOuter = null;
            DataTable dtInner = null;
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchId", PalletBatchUId.ToString());
            DataSet ds = await _db.getDataSet("[GUI].[getLabelData]", true);
            
            if (ds.Tables.Count == 2)
            {
                dtOuter = ds.Tables[0];
                dtInner = ds.Tables[1];
                if (dtOuter.Rows.Count > 0)
                {
                    writeOuterLabelData(dtOuter);
                }
                if (dtInner.Rows.Count > 0)
                {
                    writeInnerLabelData(dtInner);
                }
            }
        }

        private void writeOuterLabelData(DataTable dt)
        {
            tbOuterCustomer.Enabled = dt.Rows.Count > 0;
            tbOuterUId.Enabled = dt.Rows.Count > 0;
            tbOuterProductName.Enabled = dt.Rows.Count > 0;
            tbOuterGTIN.Enabled = dt.Rows.Count > 0;
            tbOuterDateOfMan.Enabled = dt.Rows.Count > 0;
            tbOuterLotNumber.Enabled = dt.Rows.Count > 0;
            tbOuterTotalLabels.Enabled = dt.Rows.Count > 0;
            tbOuterQtyPrinted.Enabled = dt.Rows.Count > 0;
            tbOuterRemainingQty.Enabled = dt.Rows.Count > 0;

            btnOuterPrint.Enabled = false;

            if (dt.Rows.Count > 0)
            {
                // Get the UId for later
                int.TryParse(dt.Rows[0]["UId"].ToString(), out _outerPackUId);
                tbOuterUId.Text = dt.Rows[0]["UId"].ToString();
                tbOuterCustomer.Text = dt.Rows[0]["Customer"].ToString();

                tbOuterProductName.Text = dt.Rows[0]["ProductName"].ToString();
                tbOuterGTIN.Text = dt.Rows[0]["GTIN"].ToString();
                tbOuterDateOfMan.Text = dt.Rows[0]["ManufactureDate"].ToString();
                tbOuterLotNumber.Text = dt.Rows[0]["LotNo"].ToString();
                tbOuterTotalLabels.Text = dt.Rows[0]["LabelsRequired"].ToString();
                tbOuterQtyPrinted.Text = dt.Rows[0]["LabelsPrinted"].ToString();

                if (int.TryParse(dt.Rows[0]["LabelsRequired"].ToString(), out _outerTotalLabels) &&
                    int.TryParse(dt.Rows[0]["LabelsPrinted"].ToString(), out _outerQtyPrinted))
                {
                    tbOuterRemainingQty.Text = (_outerTotalLabels - _outerQtyPrinted).ToString();
                }
                tbOuterQtyToPrint.Text = "0";
            }
            else
            {
                tbOuterUId.Text = string.Empty;
                tbOuterCustomer.Text = string.Empty;
                tbOuterProductName.Text = string.Empty;
                tbOuterGTIN.Text = string.Empty;
                tbOuterDateOfMan.Text = string.Empty;
                tbOuterLotNumber.Text = string.Empty;
                tbOuterTotalLabels.Text = string.Empty;
                tbOuterQtyPrinted.Text = string.Empty;
                tbOuterRemainingQty.Text = string.Empty;

                tbOuterQtyToPrint.Text = string.Empty;
            }
        }
        private void writeInnerLabelData(DataTable dt)
        {
            // Get the UId for later
            int.TryParse(dt.Rows[0]["UId"].ToString(), out _innerPackUId);
            
            tbInnerUId.Enabled = dt.Rows.Count > 0;
            tbInnerCustomer.Enabled = dt.Rows.Count > 0;
            tbInnerProductName.Enabled = dt.Rows.Count > 0;
            tbInnerGTIN.Enabled = dt.Rows.Count > 0;
            tbInnerDateOfMan.Enabled = dt.Rows.Count > 0;
            tbInnerLotNumber.Enabled = dt.Rows.Count > 0;
            tbInnerTotalLabels.Enabled = dt.Rows.Count > 0;
            tbInnerQtyPrinted.Enabled = dt.Rows.Count > 0;
            tbInnerRemainingQty.Enabled = dt.Rows.Count > 0;

            btnInnerPrint.Enabled = false;

            if (dt.Rows.Count > 0)
            {
                tbInnerUId.Text = dt.Rows[0]["UId"].ToString();
                tbInnerCustomer.Text = dt.Rows[0]["Customer"].ToString();
                tbInnerGTIN.Text = dt.Rows[0]["GTIN"].ToString();
                tbInnerDateOfMan.Text = dt.Rows[0]["ManufactureDate"].ToString();
                tbInnerLotNumber.Text = dt.Rows[0]["LotNo"].ToString();
                tbInnerTotalLabels.Text = dt.Rows[0]["LabelsRequired"].ToString();
                tbInnerQtyPrinted.Text = dt.Rows[0]["LabelsPrinted"].ToString();

                if (int.TryParse(dt.Rows[0]["LabelsRequired"].ToString(), out _innerTotalLabels) &&
                    int.TryParse(dt.Rows[0]["LabelsPrinted"].ToString(), out _innerQtyPrinted))
                {
                    tbInnerRemainingQty.Text = (_innerTotalLabels - _innerQtyPrinted).ToString();
                }
                tbInnerQtyToPrint.Text = "0";
            }
            else
            {
                tbInnerUId.Text = string.Empty;
                tbInnerCustomer.Text = string.Empty;
                tbInnerGTIN.Text = string.Empty;
                tbInnerDateOfMan.Text = string.Empty;
                tbInnerLotNumber.Text = string.Empty;
                tbInnerTotalLabels.Text = string.Empty;
                tbInnerQtyPrinted.Text = string.Empty;
                tbInnerRemainingQty.Text = string.Empty;

                tbInnerQtyToPrint.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private async void btnInnerPrint_Click(object sender, EventArgs e)
        {
            InnerLabelData labelData = new InnerLabelData();
            int iPrintQty = 0;
            DateTime dtDoM = DateTime.MinValue;
            StringBuilder ErrorMsg = new StringBuilder();
            try
            {
                int.TryParse(tbInnerQtyToPrint.Text, out iPrintQty);
                DateTime.TryParse(tbInnerDateOfMan.Text, out dtDoM);
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            //Setup the print parameters
            labelData.LabelPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\labels\\InnerLabel.nlbl";
            labelData.PrintQty = iPrintQty;

            labelData.GTIN = tbOuterGTIN.Text;
            labelData.LotNo = tbOuterLotNumber.Text;
            labelData.ProductionDate = dtDoM;

            if (labelData.CanPrintLabel(out ErrorMsg))
            {
                niceLabel.PrintInnerLabel(labelData, tbInnerPrinter.Text);

                //Update the user Interface with the updated values
                _innerQtyPrinted = _innerQtyPrinted + iPrintQty;
                tbInnerQtyPrinted.Text = _innerQtyPrinted.ToString();
                tbInnerRemainingQty.Text = (_innerTotalLabels - _innerQtyPrinted).ToString();

                //Write the updates to the database
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("InnerPackUId", _innerPackUId.ToString());
                _db.QueryParameters.Add("AdditionalLabels", tbOuterQtyToPrint.Text);
                DataTable dt = await _db.executeSP("[GUI].[updateInnerLabelsPrinted]", true);

                //Done with the printing - Need to set new parameters

                tbInnerQtyToPrint.Text = "0";
                btnInnerPrint.Enabled = false;
            }
            else
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Information, Logging.ThisMethod(), ErrorMsg.ToString());
            }
        }

        private async void btnOuterPrint_Click(object sender, EventArgs e)
        {
            OuterLabelData labelData = new OuterLabelData();
            int iPrintQty = 0;
            DateTime dtDoM = DateTime.MinValue;
            StringBuilder ErrorMsg = new StringBuilder();
            try
            {
                int.TryParse(tbOuterQtyToPrint.Text, out iPrintQty);
                DateTime.TryParse(tbOuterDateOfMan.Text, out dtDoM);
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            //Setup the print parameters
            labelData.LabelPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\labels\\OuterLabel.nlbl";
            labelData.PrintQty = iPrintQty;
            
            labelData.GTIN = tbOuterGTIN.Text;
            labelData.LotNo = tbOuterLotNumber.Text;
            labelData.ProductName = tbOuterProductName.Text;
            labelData.ProductionDate = dtDoM;

            if (labelData.CanPrintLabel(out ErrorMsg))
            {
                await niceLabel.PrintOuterLabel(labelData, tbOuterPrinter.Text);

                //Update the user Interface with the updated values
                _outerQtyPrinted = _outerQtyPrinted + iPrintQty;
                tbOuterQtyPrinted.Text = _outerQtyPrinted.ToString();
                tbOuterRemainingQty.Text = (_outerTotalLabels - _outerQtyPrinted).ToString();

                //Write the updates to the database
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("OuterPackUId", _outerPackUId.ToString());
                _db.QueryParameters.Add("AdditionalLabels", tbOuterQtyToPrint.Text);
                DataTable dt = await _db.executeSP("[GUI].[updateOuterLabelsPrinted]", true);

                //Done with the printing - Need to set new parameters
                tbOuterQtyToPrint.Text = "0";
                btnOuterPrint.Enabled = false;
            }
            else
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Information, Logging.ThisMethod(), ErrorMsg.ToString());
            }
        }
        
        private bool ValidateQtyToPrint(TextBox tb, int UpperLimit, Button PrintButton)
        {
            int LowerLimit = 0;
            int iValue = 0;
            // Must be an integer
            bool bRes = int.TryParse(tb.Text, out iValue);
            if (bRes)
            {
                // Must be > 0 and less than the total
                if (iValue < LowerLimit)
                {                    
                    epQtyToPrint.SetError(tb, "Must be a +ve");
                    PrintButton.Enabled = false;
                    return false;
                }
                else if(iValue > UpperLimit)
                {
                    epQtyToPrint.SetError(tb, "Must be a less than the total");
                    PrintButton.Enabled = false;
                    return false;
                }
                PrintButton.Enabled = true;
                PrintButton.Focus();
                epQtyToPrint.SetError(tb, "");
                return true;
            }
            else
            {
                epQtyToPrint.SetError(tb, "Must be a +ve number.  (No spaces of alpha chars)");
                PrintButton.Enabled = false;
                return false;
            }
        }
        private void tbOuterQtyToPrint_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool bRes = ValidateQtyToPrint(tb, _outerTotalLabels, btnOuterPrint);
            if (e != null) e.Cancel = !bRes;
        }
        private void tbInnerQtyToPrint_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool bRes = ValidateQtyToPrint(tb, _innerTotalLabels, btnInnerPrint);
            if (e != null) e.Cancel = !bRes;
        }
        private void tbOuterQtyToPrint_Validated(object sender, EventArgs e)
        {
            btnOuterPrint.Enabled = true;
            btnOuterPrint.Focus();
        }
        private void tbInnerQtyToPrint_Validated(object sender, EventArgs e)
        {
            btnInnerPrint.Enabled = true;
            btnInnerPrint.Focus();
        }   
        private void tbOuterQtyToPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ValidateQtyToPrint(sender as TextBox, _outerTotalLabels, btnOuterPrint);
            }
        }
        private void tbInnerQtyToPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ValidateQtyToPrint(sender as TextBox, _innerTotalLabels, btnInnerPrint);
            }
        }

    }
}

