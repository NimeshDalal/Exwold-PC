
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
        private DataInterface.execFunction _db = null;
        #endregion

        string moduleName = "PrintForm1.";

        public string PrintBatchFlag;
        public string PrintBatchID;

        int PalletBatchID;
        string PalletLabel;
        string PrinterName;

        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="frmPrint"/> class.
        /// </summary>
        /// 
        public frmPrint(DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
        }

        /// <summary>
        /// Raises the CreateControl event.
        /// </summary>
        protected override void OnCreateControl()
        {
            this.InitializePrintEngine();

            base.OnCreateControl();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            try
            {
                PrintEngineFactory.PrintEngine.Shutdown();

                base.OnClosed(e);
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "EXCEPTION: destroying PrintEngine: " + ex.ToString());
                MessageBox.Show(Logging.ThisMethod(), "Error destroying PrintEngine");
                Program.Log.logSave();
                Application.Exit();
            }
        }

        /// <summary>
        /// Initializes the Print engine.
        /// </summary>
        private void InitializePrintEngine()
        {
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "Starting");
                if (Directory.Exists(System.Configuration.ConfigurationManager.AppSettings["NiceLabelSDKPath"]))
                {
                    PrintEngineFactory.SDKFilesPath = System.Configuration.ConfigurationManager.AppSettings["NiceLabelSDKPath"];
                }
                PrintEngineFactory.PrintEngine.Initialize();

                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "Finished");
            }
            catch (SDKException exception)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "SDK EXCEPTION: " + exception.ToString());
                MessageBox.Show("Initialization of the SDK failed, SDK error.");
                Program.Log.logSave();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "EXCEPTION: " + ex.ToString());
                MessageBox.Show("Initialization of the SDK failed, other error.");
                Program.Log.logSave();
                Application.Exit();
            }
        }


        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PrintFunction()
        {
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "Starting");
                // Open label that will be printed
                ILabel label = PrintEngineFactory.PrintEngine.OpenLabel(PalletLabel);

                try
                {
                    // By default label will be printed on printer stored on the label 
                    // (or on the default printer if saved printer is not found).
                    // Printer can be changed by changing PrinterName property in printer settings.
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() start");

                    label.PrintSettings.PrinterName = PrinterName;

                    // Setting of variables on the label
                    label.Variables["GMID"].SetValue(tbPalletGMID.Text);
                    label.Variables["Count"].SetValue(tbPalletCount.Text);
                    label.Variables["NetUnits"].SetValue(tbPalletNetUnits.Text);
                    label.Variables["NetVolume"].SetValue(tbPalletNetVolume.Text.PadLeft(6, '0'));
                    label.Variables["NetUnits_AI"].SetValue(tbPalletNetUnits_AI.Text);
                    label.Variables["BatchNumber"].SetValue(tbPalletBatchNumber.Text);
                    label.Variables["ProductionDate"].SetValue(tbPalletProductionDate.Text);
                    label.Variables["SSCC"].SetValue(tbPalletSSCC.Text);
                    label.Variables["GTIN"].SetValue(tbPalletGTIN.Text);
                    label.Variables["LabelNumber"].SetValue(tbPalletLabelNumber.Text);
                    label.Variables["TotalLabels"].SetValue(tbPalletTotalLabels.Text);
                    label.Variables["ProductName"].SetValue(tbPalletProductName.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxGMID.Text = " + tbPalletGMID.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxCount.Text = " + tbPalletCount.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxNetUnits.Text = " + tbPalletNetUnits.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxNetVolume.Text.PadLeft(6, '0') = " + tbPalletNetVolume.Text.PadLeft(6, '0'));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxNetUnits_AI.Text = " + tbPalletNetUnits_AI.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxBatchNumber.Text = " + tbPalletBatchNumber.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxProductionDate.Text = " + tbPalletProductionDate.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxSSCC.Text = " + tbPalletSSCC.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxGTIN.Text = " + tbPalletGTIN.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxLabelNumber.Text = " + tbPalletLabelNumber.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxTotalLabels.Text = " + tbPalletTotalLabels.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxProductName.Text = " + tbPalletProductName.Text);

                    int quantity = int.Parse(tbPalletQuantity.Text);
                    label.Print(quantity);

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, "Label printed, data is: " +
                        tbPalletGMID.Text + " : " + tbPalletCount.Text + " : " + tbPalletNetUnits.Text + " : " +
                        tbPalletNetVolume.Text.PadLeft(6, '0') + " : " + tbPalletNetUnits_AI.Text + " : " + tbPalletBatchNumber.Text + " : " +
                        tbPalletProductionDate.Text + " : " + tbPalletSSCC.Text + " : " + tbPalletGTIN.Text + " : " +
                        tbPalletLabelNumber.Text + " : " + tbPalletProductName.Text + " : " + tbPalletTotalLabels.Text);
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "EXCEPTION: Populating and printing label failed: " + ex.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, "Populating and printing label failed, Data is: " +
                        tbPalletGMID.Text + " : " + tbPalletCount.Text + " : " + tbPalletNetUnits.Text + " : " +
                        tbPalletNetVolume.Text.PadLeft(6, '0') + " : " + tbPalletNetUnits_AI.Text + " : " + tbPalletBatchNumber.Text + " : " +
                        tbPalletProductionDate.Text + " : " + tbPalletSSCC.Text + " : " + tbPalletGTIN.Text + " : " +
                        tbPalletLabelNumber.Text + " : " + tbPalletProductName.Text + " : " + tbPalletTotalLabels.Text);

                    MessageBox.Show("Populating and printing label failed \r\n Please check the printer is on-line. \r\n\r\n " +
                        tbPalletGMID.Text + " : " + tbPalletCount.Text + " : " + tbPalletNetUnits.Text + " : " +
                        tbPalletNetVolume.Text.PadLeft(6, '0') + " : " + tbPalletNetUnits_AI.Text + " : " + tbPalletBatchNumber.Text + " : " +
                        tbPalletProductionDate.Text + " : " + tbPalletSSCC.Text + " : " + tbPalletGTIN.Text + " : " +
                        tbPalletLabelNumber.Text + " : " + tbPalletProductName.Text + " : " + tbPalletTotalLabels.Text);
                }

                Program.Log.logSave();
                this.Close();
            }
            catch (SDKException exception)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "EXCEPTION: Creation of the 'label' failed, SDK exception: " + exception.ToString());
                MessageBox.Show("PrintFunction() Creation of the 'label' failed.");
                Program.Log.logSave();
                this.Close();
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "EXCEPTION: Creation of the 'label' failed: " + ex.ToString());
                MessageBox.Show("PrintFunction() Creation of the 'label' failed.");
                Program.Log.logSave();
                this.Close();
            }
        }

        private async void PrintForm_Load(object sender, EventArgs e)
        {
            //set top
            this.TopMost = true;

            if (PrintBatchFlag == "Print")
            {
                try
                {

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(),"Print");
                    int PalletBatchID = Convert.ToInt32(PrintBatchID);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletBatchID = " + PalletBatchID.ToString());

                    DataTable dtCurrentProduct = await getPalletBatch(PalletBatchID);
                    //Mesh Remove
                    //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    tbPalletNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                    tbPalletGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                    tbPalletProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits_AI.Text = " + tbPalletNetUnits_AI.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGMID.Text = " + tbPalletGMID.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionLineNumber.Text = " + tbPalletProductionLineNumber.Text.ToString());

                    //Set printer name
                    switch (tbPalletProductionLineNumber.Text)
                    {
                        case "1":
                            PrinterName = "SATO CL6NX 305dpi 1";
                            break;
                        default:
                            PrinterName = "SATO CL6NX 305dpi 2";
                            break;
                    }

                    //Get batches\carton number on Pallet
                    DataTable dtCurrentPallet = await getBatchesOnPallet(PalletBatchID);

                    //Mesh Remove
                    //sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    //DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                    int NoOfBatches = (dtCurrentPallet.Rows.Count);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "NoOfBatches = " + NoOfBatches.ToString());

                    if (NoOfBatches > 0)  // some pallet data exists, set label numbers and calculate batch data
                    {
                        int PalletLabelID = Convert.ToInt16(dtCurrentPallet.Rows[0].Field<Int64>("PalletUniqueNo"));

                        dtCurrentPallet = await getPalletLabels(PalletLabelID);
                        //Mesh Remove
                        //sql = "SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
                        //dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                        NoOfBatches = (dtCurrentPallet.Rows.Count);  // Actual Number of Batches on the Pallet
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "NoOfBatches = " + NoOfBatches.ToString());

                        tbPalletTotalLabels.Text = Convert.ToString(NoOfBatches);

                        for (int i = 0; i < NoOfBatches; i++)
                        {
                            tbPalletCount.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("CartonsOnPallet"));
                            tbPalletNetUnits.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("QtyInner"));
                            tbPalletBatchNumber.Text = dtCurrentPallet.Rows[i].Field<string>("MaterialBatchNo");
                            tbPalletProductionDate.Text = dtCurrentPallet.Rows[i].Field<string>("ProdDate");
                            tbPalletSSCC.Text = dtCurrentPallet.Rows[i].Field<string>("SSCC");
                            tbPalletGTIN.Text = dtCurrentPallet.Rows[i].Field<string>("GTIN");
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxCount.Text = " + tbPalletCount.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits.Text = " + tbPalletNetUnits.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxBatchNumber.Text = " + tbPalletBatchNumber.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionDate.Text = " + tbPalletProductionDate.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxSSCC.Text = " + tbPalletSSCC.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGTIN.Text = " + tbPalletGTIN.Text.ToString());

                            // GetProduct name from GTIN
                            dtCurrentPallet = await getProductByGTIN(dtCurrentPallet.Rows[i].Field<string>("GTIN"));
                            //Mesh Remove
                            //sql = "SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";
                            //dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                            tbPalletProductName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                            tbPalletNetVolume.Text = dtCurrentPallet.Rows[i].Field<string>("NetVolOrWt");
                            tbPalletLabelNumber.Text = Convert.ToString(i + 1);
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductName.Text = " + tbPalletProductName.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), " TextBoxNetVolume.Text = " + tbPalletNetVolume.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxLabelNumber.Text = " + tbPalletLabelNumber.Text.ToString());

                            //Set label name
                            if (tbPalletNetUnits_AI.Text == "Kg")
                            {
                                PalletLabel = "ExwoldPalletLabel1K";
                            }
                            if (tbPalletNetUnits_AI.Text == "L")
                            {
                                PalletLabel = "ExwoldPalletLabel1L";
                            }
                            if (i > 0)
                            {
                                PalletLabel = PalletLabel + "_Additional";
                            }
                            PalletLabel = PalletLabel + ".nlbl";
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletLabel = " + PalletLabel);

                            PrintFunction();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "EXCEPTION: Print: Failed to get data from DB (Incorrect data?): " + ex.Message);
                    MessageBox.Show("Print: Failed to get data from DB (Incorrect data?)");
                }
            }
            if (PrintBatchFlag == "ScannerPrint")
            {
                try
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "ScannerPrint");
                    int PalletLabelID = Convert.ToInt32(PrintBatchID);
                    //DataTable dtCurrentBatch =

                    //Get PalletBatchID
                    DataTable dtCurrentBatch = await getPalletBatchByLabelId(PalletLabelID);

                    //Mesh Remove
                    //sql = "SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = " + PalletLabelID;
                    //DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
                    PalletBatchID = Convert.ToInt32(dtCurrentBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletBatchID = " + PalletBatchID.ToString());

                    //Remove
                    //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    
                    DataTable dtCurrentProduct = await getPalletBatch(PalletBatchID);
                    tbPalletNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                    tbPalletGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                    tbPalletProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits_AI.Text = " + tbPalletNetUnits_AI.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGMID.Text = " + tbPalletGMID.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionLineNumber.Text = " + tbPalletProductionLineNumber.Text.ToString());

                    //Set printer name
                    switch (tbPalletProductionLineNumber.Text)
                    {
                        case "1":
                            PrinterName = "SATO CL6NX 305dpi 1";
                            break;
                        default:
                            PrinterName = "SATO CL6NX 305dpi 2";
                            break;
                    }

                    //Get batches/carton number on Pallet

                    //Mesh Remove
                    //sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    //DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                    DataTable dtCurrentPallet = await getBatchesOnPallet(PalletBatchID);
                    int NoOfBatches = (dtCurrentPallet.Rows.Count);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "NoOfBatches = " + NoOfBatches.ToString());

                    if (NoOfBatches > 0)  // some pallet data exists, set label numbers and calculate batch data
                    {
                        //Mesh Remove
                        //sql = "SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
                        //dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                        dtCurrentPallet = await getPalletLabels(PalletLabelID);
                        NoOfBatches = (dtCurrentPallet.Rows.Count);  // Actual Number of Batches on the Pallet
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), " NoOfBatches = " + NoOfBatches.ToString());

                        tbPalletTotalLabels.Text = Convert.ToString(NoOfBatches);

                        for (int i = 0; i < NoOfBatches; i++)
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintForm1_Load() Loop = " + i.ToString());
                            tbPalletCount.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("CartonsOnPallet"));
                            tbPalletNetUnits.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("QtyInner"));
                            tbPalletBatchNumber.Text = dtCurrentPallet.Rows[i].Field<string>("MaterialBatchNo");
                            tbPalletProductionDate.Text = dtCurrentPallet.Rows[i].Field<string>("ProdDate");
                            tbPalletSSCC.Text = dtCurrentPallet.Rows[i].Field<string>("SSCC");
                            tbPalletGTIN.Text = dtCurrentPallet.Rows[i].Field<string>("GTIN");
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxCount.Text = " + tbPalletCount.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits.Text = " + tbPalletNetUnits.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxBatchNumber.Text = " + tbPalletBatchNumber.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionDate.Text = " + tbPalletProductionDate.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxSSCC.Text = " + tbPalletSSCC.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGTIN.Text = " + tbPalletGTIN.Text.ToString());

                            // GetProduct name from GTIN
                            
                            //Mesh Remove
                            //sql = "SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";
                            //dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

                            dtCurrentProduct = await getProductByGTIN(dtCurrentPallet.Rows[i].Field<string>("GTIN"));
                            tbPalletProductName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                            tbPalletNetVolume.Text = dtCurrentPallet.Rows[i].Field<string>("NetVolOrWt");
                            tbPalletLabelNumber.Text = Convert.ToString(i + 1);
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductName.Text = " + tbPalletProductName.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetVolume.Text = " + tbPalletNetVolume.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxLabelNumber.Text = " + tbPalletLabelNumber.Text.ToString());

                            //Set label name
                            if (tbPalletNetUnits_AI.Text == "Kg")
                            {
                                PalletLabel = "ExwoldPalletLabel1K";
                            }
                            if (tbPalletNetUnits_AI.Text == "L")
                            {
                                PalletLabel = "ExwoldPalletLabel1L";
                            }
                            if (i > 0)
                            {
                                PalletLabel = PalletLabel + "_Additional";
                            }
                            PalletLabel = PalletLabel + ".nlbl";
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletLabel = " + PalletLabel);

                            PrintFunction();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(),"EXCEPTION: ScannerPrint: Failed to get data from DB (Incorrect data?): ", ex);
                    MessageBox.Show("ScannerPrint: Failed to get data from DB (Incorrect data?)");
                    Program.Log.logSave();
                    this.Close();
                }
            }


            /// <summary>
            /// Handles the Click event of the PrintButton control.
            /// </summary>
            if (PrintBatchFlag == "Reprint")
            {
                try
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "RePrint");
                    int PalletLabelID = Convert.ToInt32(PrintBatchID);
                    //Get PalletBatchID
                    DataTable dtCurrentBatch = await getPalletBatchByLabelId(PalletBatchID);

                    //Mesh Remove
                    //sql = "SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = " + PalletLabelID;
                    //DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);

                    PalletBatchID = Convert.ToInt32(dtCurrentBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletBatchID = " + PalletBatchID.ToString());

                    DataTable dtCurrentProduct = await getPalletBatch(PalletBatchID);

                    //Mesh Remove
                    //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

                    tbPalletNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                    tbPalletGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                    tbPalletProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits_AI.Text = " + tbPalletNetUnits_AI.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGMID.Text = " + tbPalletGMID.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionLineNumber.Text = " + tbPalletProductionLineNumber.Text.ToString());

                    //Set printer name
                    switch (tbPalletProductionLineNumber.Text)
                    {
                        case "1":
                            cboPalletPrinter.Text = "SATO CL6NX 305dpi 1";
                            break;
                        default:
                            cboPalletPrinter.Text = "SATO CL6NX 305dpi 2";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(),"EXCEPTION: RePrint: Failed to get data from DB (Incorrect data?): ",ex);
                    MessageBox.Show("RePrint: Failed to get data from DB (Incorrect data?)");
                    Program.Log.logSave();
                    this.Close();
                }
            }
        }

        private async void buttonReprint_Click(object sender, EventArgs e)
        {
            string methodName = moduleName + "PrintForm1.buttonReprint_Click() ";
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "starting");
                lblPalletPrintStatus.Text = "Printing - Please Wait..........";
                int PalletLabelID = Convert.ToInt32(PrintBatchID);
                //Get PalletBatchID

                DataTable dtCurrentBatch = await getPalletBatchByLabelId(PalletLabelID);

                //Mesh Remove
                //sql = "SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = " + PalletLabelID;
                //DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
                PalletBatchID = Convert.ToInt32(dtCurrentBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletBatchID = " + PalletBatchID.ToString());

                DataTable dtCurrentProduct = await getPalletBatch(PalletBatchID);

                //Mesh Remove
                //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                tbPalletNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                tbPalletGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                tbPalletProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits_AI.Text = " + tbPalletNetUnits_AI.Text.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGMID.Text = " + tbPalletGMID.Text.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionLineNumber.Text = " + tbPalletProductionLineNumber.Text.ToString());
                
                //Set printer name
                PrinterName = cboPalletPrinter.Text;

                //Get batches/carton number on Pallet
                DataTable dtCurrentPallet = await getBatchesOnPallet(PalletBatchID);
                
                //Mesh Remove
                //sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                //DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                int NoOfBatches = (dtCurrentPallet.Rows.Count);
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "NoOfBatches = " + NoOfBatches.ToString());

                if (NoOfBatches > 0)  // some pallet data exists, set label numbers and calculate batch data
                {
                    dtCurrentPallet = await getPalletLabels(PalletLabelID);

                    //Mesh Remove
                    //sql = "SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
                    //dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                    NoOfBatches = (dtCurrentPallet.Rows.Count);  // Actual Number of Batches on the Pallet
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "NoOfBatches = " + NoOfBatches.ToString());

                    tbPalletTotalLabels.Text = Convert.ToString(NoOfBatches);

                    for (int i = 0; i < NoOfBatches; i++)
                    {

                        tbPalletCount.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("CartonsOnPallet"));
                        tbPalletNetUnits.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("QtyInner"));
                        tbPalletBatchNumber.Text = dtCurrentPallet.Rows[i].Field<string>("MaterialBatchNo");
                        tbPalletProductionDate.Text = dtCurrentPallet.Rows[i].Field<string>("ProdDate");
                        tbPalletSSCC.Text = dtCurrentPallet.Rows[i].Field<string>("SSCC");
                        tbPalletGTIN.Text = dtCurrentPallet.Rows[i].Field<string>("GTIN");
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxCount.Text = " + tbPalletCount.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetUnits.Text = " + tbPalletNetUnits.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxBatchNumber.Text = " + tbPalletBatchNumber.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductionDate.Text = " + tbPalletProductionDate.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxSSCC.Text = " + tbPalletSSCC.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxGTIN.Text = " + tbPalletGTIN.Text.ToString());

                        // GetProduct name from GTIN
                        dtCurrentProduct = await getProductByGTIN(dtCurrentPallet.Rows[i].Field<string>("GTIN"));

                        //Mesh Remove
                        //sql = "SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";
                        //dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                        tbPalletProductName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                        tbPalletNetVolume.Text = dtCurrentPallet.Rows[i].Field<string>("NetVolOrWt");
                        tbPalletLabelNumber.Text = Convert.ToString(i + 1);
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxProductName.Text = " + tbPalletProductName.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxNetVolume.Text = " + tbPalletNetVolume.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "TextBoxLabelNumber.Text = " + tbPalletLabelNumber.Text.ToString());

                        //Set label name
                        if (tbPalletNetUnits_AI.Text == "Kg")
                        {
                            PalletLabel = "ExwoldPalletLabel1K";
                        }
                        if (tbPalletNetUnits_AI.Text == "L")
                        {
                            PalletLabel = "ExwoldPalletLabel1L";
                        }
                        if (i > 0)
                        {
                            PalletLabel = PalletLabel + "_Additional";
                        }
                        PalletLabel = PalletLabel + ".nlbl";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), "PalletLabel = " + PalletLabel);

                        PrintFunction();

                    }

                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "EXCEPTION: Form RePrint error : " + ex.Message);
                MessageBox.Show("Label failed to re-print. \n\rPlease check the Pallet data.");
                Program.Log.logSave();
                this.Close();
            }
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
        private async Task<DataTable> getPalletLabels(int palletLabelId)
        {
            //"SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletLabelId", palletLabelId.ToString());
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
        private async Task<DataTable> getPalletBatchByLabelId(int palletLabelId)
        {
            //SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = 
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletLabelId", palletLabelId.ToString());
            return await _db.executeSP("[GUI].[getPalletBatchByPalletLabelId]", true);

        }
    }
}

