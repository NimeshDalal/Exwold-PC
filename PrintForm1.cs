//*********************************************************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Handles the Print function when recieved from the scannjer with no user input
// Provides an interface to select a printer when:
//  1)  The print function is selected from the batch details page
//  2)  The scanner sends a reprint command
//
// MODIFICATION HISTORY
// FileVersion  ProgVersion  Date        Project/CRF.    Who                     References
//     1.00      1.00.00.00  04Apr2017   702678          Stuart Eglington 
//              Initial Creation
//     1.01      1.03.00.00  30Jan2018   991068/CRF002   Martin Cox
//              Added ORDER BY startement on line 251 to the lines 351 and 495.
//              Added single quotes around GTIN in SQL as it's a string (not a number).
//              Added better debug logging.
//              In InitializePrintEngine() using value from config file for NiceLabel SDK directory
//*********************************************************************************************************************

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using NiceLabel.SDK;
using System.Data;


namespace ExwoldPcInterface
{
    /// <summary>
    /// The main Form class.
    /// </summary>
    public partial class PrintForm1 : Form
    {
        string moduleName = "PrintForm1.";

        public string PrintBatchFlag;
        public string PrintBatchID;

        int PalletBatchID;
        string sql;
        string PalletLabel;
        string PrinterName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintForm1"/> class.
        /// </summary>
        /// 
        public PrintForm1()
        {
            InitializeComponent();
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
            string methodName = moduleName + "PrintForm1.OnClosed() ";
            try
            {
                PrintEngineFactory.PrintEngine.Shutdown();

                base.OnClosed(e);
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "EXCEPTION: destroying PrintEngine: " + ex.ToString());
                MessageBox.Show(methodName + "Error destroying PrintEngine");
                Program.Log.logSave();
                Application.Exit();
            }
        }

        /// <summary>
        /// Initializes the Print engine.
        /// </summary>
        private void InitializePrintEngine()
        {
            string methodName = moduleName + "PrintForm1.InitializePrintEngine() ";
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Starting");
                if (Directory.Exists(Program.NiceLabelSDKPath))
                {
                    PrintEngineFactory.SDKFilesPath = Program.NiceLabelSDKPath;
                }
                PrintEngineFactory.PrintEngine.Initialize();

                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Finished");
            }
            catch (SDKException exception)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "SDK EXCEPTION: " + exception.ToString());
                MessageBox.Show("Initialization of the SDK failed, SDK error.");
                Program.Log.logSave();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "EXCEPTION: " + ex.ToString());
                MessageBox.Show("Initialization of the SDK failed, other error.");
                Program.Log.logSave();
                Application.Exit();
            }
        }


        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PrintFunction()
        {
            string methodName = moduleName + "PrintForm1.PrintFunction() ";
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Starting");
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
                    label.Variables["GMID"].SetValue(TextBoxGMID.Text);
                    label.Variables["Count"].SetValue(TextBoxCount.Text);
                    label.Variables["NetUnits"].SetValue(TextBoxNetUnits.Text);
                    label.Variables["NetVolume"].SetValue(TextBoxNetVolume.Text.PadLeft(6, '0'));
                    label.Variables["NetUnits_AI"].SetValue(TextBoxNetUnits_AI.Text);
                    label.Variables["BatchNumber"].SetValue(TextBoxBatchNumber.Text);
                    label.Variables["ProductionDate"].SetValue(TextBoxProductionDate.Text);
                    label.Variables["SSCC"].SetValue(TextBoxSSCC.Text);
                    label.Variables["GTIN"].SetValue(TextBoxGTIN.Text);
                    label.Variables["LabelNumber"].SetValue(TextBoxLabelNumber.Text);
                    label.Variables["TotalLabels"].SetValue(TextBoxTotalLabels.Text);
                    label.Variables["ProductName"].SetValue(TextBoxProductName.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxGMID.Text = " + TextBoxGMID.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxCount.Text = " + TextBoxCount.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxNetUnits.Text = " + TextBoxNetUnits.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxNetVolume.Text.PadLeft(6, '0') = " + TextBoxNetVolume.Text.PadLeft(6, '0'));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxNetUnits_AI.Text = " + TextBoxNetUnits_AI.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxBatchNumber.Text = " + TextBoxBatchNumber.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxProductionDate.Text = " + TextBoxProductionDate.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxSSCC.Text = " + TextBoxSSCC.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxGTIN.Text = " + TextBoxGTIN.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxLabelNumber.Text = " + TextBoxLabelNumber.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxTotalLabels.Text = " + TextBoxTotalLabels.Text);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintFunction() TextBoxProductName.Text = " + TextBoxProductName.Text);

                    int quantity = int.Parse(quantityTextBox.Text);
                    label.Print(quantity);

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, "Label printed, data is: " +
                        TextBoxGMID.Text + " : " + TextBoxCount.Text + " : " + TextBoxNetUnits.Text + " : " +
                        TextBoxNetVolume.Text.PadLeft(6, '0') + " : " + TextBoxNetUnits_AI.Text + " : " + TextBoxBatchNumber.Text + " : " +
                        TextBoxProductionDate.Text + " : " + TextBoxSSCC.Text + " : " + TextBoxGTIN.Text + " : " +
                        TextBoxLabelNumber.Text + " : " + TextBoxProductName.Text + " : " + TextBoxTotalLabels.Text);
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "EXCEPTION: Populating and printing label failed: " + ex.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, "Populating and printing label failed, Data is: " +
                        TextBoxGMID.Text + " : " + TextBoxCount.Text + " : " + TextBoxNetUnits.Text + " : " +
                        TextBoxNetVolume.Text.PadLeft(6, '0') + " : " + TextBoxNetUnits_AI.Text + " : " + TextBoxBatchNumber.Text + " : " +
                        TextBoxProductionDate.Text + " : " + TextBoxSSCC.Text + " : " + TextBoxGTIN.Text + " : " +
                        TextBoxLabelNumber.Text + " : " + TextBoxProductName.Text + " : " + TextBoxTotalLabels.Text);

                    MessageBox.Show("Populating and printing label failed \r\n Please check the printer is on-line. \r\n\r\n " +
                        TextBoxGMID.Text + " : " + TextBoxCount.Text + " : " + TextBoxNetUnits.Text + " : " +
                        TextBoxNetVolume.Text.PadLeft(6, '0') + " : " + TextBoxNetUnits_AI.Text + " : " + TextBoxBatchNumber.Text + " : " +
                        TextBoxProductionDate.Text + " : " + TextBoxSSCC.Text + " : " + TextBoxGTIN.Text + " : " +
                        TextBoxLabelNumber.Text + " : " + TextBoxProductName.Text + " : " + TextBoxTotalLabels.Text);
                }

                Program.Log.logSave();
                this.Close();
            }
            catch (SDKException exception)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "EXCEPTION: Creation of the 'label' failed, SDK exception: " + exception.ToString());
                MessageBox.Show("PrintFunction() Creation of the 'label' failed.");
                Program.Log.logSave();
                this.Close();
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "EXCEPTION: Creation of the 'label' failed: " + ex.ToString());
                MessageBox.Show("PrintFunction() Creation of the 'label' failed.");
                Program.Log.logSave();
                this.Close();
            }
        }

        private void PrintForm1_Load(object sender, EventArgs e)
        {
            string methodName = moduleName + "PrintForm1.PrintForm1_Load() ";

            //set top
            this.TopMost = true;

            if (PrintBatchFlag == "Print")
            {
                try
                {

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Print");
                    int PalletBatchID = Convert.ToInt32(PrintBatchID);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletBatchID = " + PalletBatchID.ToString());

                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    TextBoxNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                    TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                    TextBoxProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits_AI.Text = " + TextBoxNetUnits_AI.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGMID.Text = " + TextBoxGMID.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionLineNumber.Text = " + TextBoxProductionLineNumber.Text.ToString());

                    //Set printer name
                    switch (TextBoxProductionLineNumber.Text)
                    {
                        case "1":
                            PrinterName = "SATO CL6NX 305dpi 1";
                            break;
                        default:
                            PrinterName = "SATO CL6NX 305dpi 2";
                            break;
                    }

                    //Get batches/carton number on Pallet
                    sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                    int NoOfBatches = (dtCurrentPallet.Rows.Count);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "NoOfBatches = " + NoOfBatches.ToString());

                    if (NoOfBatches > 0)  // some pallet data exists, set label numbers and calculate batch data
                    {
                        int PalletLabelID = Convert.ToInt16(dtCurrentPallet.Rows[0].Field<Int64>("PalletUniqueNo"));

                        sql = "SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
                        dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);
                        NoOfBatches = (dtCurrentPallet.Rows.Count);  // Actual Number of Batches on the Pallet
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "NoOfBatches = " + NoOfBatches.ToString());

                        TextBoxTotalLabels.Text = Convert.ToString(NoOfBatches);

                        for (int i = 0; i < NoOfBatches; i++)
                        {
                            TextBoxCount.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("CartonsOnPallet"));
                            TextBoxNetUnits.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("QtyInner"));
                            TextBoxBatchNumber.Text = dtCurrentPallet.Rows[i].Field<string>("MaterialBatchNo");
                            TextBoxProductionDate.Text = dtCurrentPallet.Rows[i].Field<string>("ProdDate");
                            TextBoxSSCC.Text = dtCurrentPallet.Rows[i].Field<string>("SSCC");
                            TextBoxGTIN.Text = dtCurrentPallet.Rows[i].Field<string>("GTIN");
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxCount.Text = " + TextBoxCount.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits.Text = " + TextBoxNetUnits.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxBatchNumber.Text = " + TextBoxBatchNumber.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionDate.Text = " + TextBoxProductionDate.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxSSCC.Text = " + TextBoxSSCC.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGTIN.Text = " + TextBoxGTIN.Text.ToString());

                            // GetProduct name from GTIN
                            sql = "SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";
                            dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                            TextBoxProductName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                            TextBoxNetVolume.Text = dtCurrentPallet.Rows[i].Field<string>("NetVolOrWt");
                            TextBoxLabelNumber.Text = Convert.ToString(i + 1);
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductName.Text = " + TextBoxProductName.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + " TextBoxNetVolume.Text = " + TextBoxNetVolume.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxLabelNumber.Text = " + TextBoxLabelNumber.Text.ToString());

                            //Set label name
                            if (TextBoxNetUnits_AI.Text == "Kg")
                            {
                                PalletLabel = "ExwoldPalletLabel1K";
                            }
                            if (TextBoxNetUnits_AI.Text == "L")
                            {
                                PalletLabel = "ExwoldPalletLabel1L";
                            }
                            if (i > 0)
                            {
                                PalletLabel = PalletLabel + "_Additional";
                            }
                            PalletLabel = PalletLabel + ".nlbl";
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletLabel = " + PalletLabel);

                            PrintFunction();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "EXCEPTION: Print: Failed to get data from DB (Incorrect data?): " + ex.Message);
                    MessageBox.Show("Print: Failed to get data from DB (Incorrect data?)");
                }
            }
            if (PrintBatchFlag == "ScannerPrint")
            {
                try
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "ScannerPrint");
                    int PalletLabelID = Convert.ToInt32(PrintBatchID);
                    //Get PalletBatchID
                    sql = "SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = " + PalletLabelID;
                    DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
                    PalletBatchID = Convert.ToInt32(dtCurrentBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletBatchID = " + PalletBatchID.ToString());

                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    TextBoxNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                    TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                    TextBoxProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits_AI.Text = " + TextBoxNetUnits_AI.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGMID.Text = " + TextBoxGMID.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionLineNumber.Text = " + TextBoxProductionLineNumber.Text.ToString());

                    //Set printer name
                    switch (TextBoxProductionLineNumber.Text)
                    {
                        case "1":
                            PrinterName = "SATO CL6NX 305dpi 1";
                            break;
                        default:
                            PrinterName = "SATO CL6NX 305dpi 2";
                            break;
                    }

                    //Get batches/carton number on Pallet

                    sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);
                    int NoOfBatches = (dtCurrentPallet.Rows.Count);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "NoOfBatches = " + NoOfBatches.ToString());

                    if (NoOfBatches > 0)  // some pallet data exists, set label numbers and calculate batch data
                    {
                        sql = "SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
                        dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);
                        NoOfBatches = (dtCurrentPallet.Rows.Count);  // Actual Number of Batches on the Pallet
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + " NoOfBatches = " + NoOfBatches.ToString());

                        TextBoxTotalLabels.Text = Convert.ToString(NoOfBatches);

                        for (int i = 0; i < NoOfBatches; i++)
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "PrintForm1_Load() Loop = " + i.ToString());
                            TextBoxCount.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("CartonsOnPallet"));
                            TextBoxNetUnits.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("QtyInner"));
                            TextBoxBatchNumber.Text = dtCurrentPallet.Rows[i].Field<string>("MaterialBatchNo");
                            TextBoxProductionDate.Text = dtCurrentPallet.Rows[i].Field<string>("ProdDate");
                            TextBoxSSCC.Text = dtCurrentPallet.Rows[i].Field<string>("SSCC");
                            TextBoxGTIN.Text = dtCurrentPallet.Rows[i].Field<string>("GTIN");
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxCount.Text = " + TextBoxCount.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits.Text = " + TextBoxNetUnits.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxBatchNumber.Text = " + TextBoxBatchNumber.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionDate.Text = " + TextBoxProductionDate.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxSSCC.Text = " + TextBoxSSCC.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGTIN.Text = " + TextBoxGTIN.Text.ToString());

                            // GetProduct name from GTIN
                            sql = "SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";
                            dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                            TextBoxProductName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                            TextBoxNetVolume.Text = dtCurrentPallet.Rows[i].Field<string>("NetVolOrWt");
                            TextBoxLabelNumber.Text = Convert.ToString(i + 1);
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductName.Text = " + TextBoxProductName.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetVolume.Text = " + TextBoxNetVolume.Text.ToString());
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxLabelNumber.Text = " + TextBoxLabelNumber.Text.ToString());

                            //Set label name
                            if (TextBoxNetUnits_AI.Text == "Kg")
                            {
                                PalletLabel = "ExwoldPalletLabel1K";
                            }
                            if (TextBoxNetUnits_AI.Text == "L")
                            {
                                PalletLabel = "ExwoldPalletLabel1L";
                            }
                            if (i > 0)
                            {
                                PalletLabel = PalletLabel + "_Additional";
                            }
                            PalletLabel = PalletLabel + ".nlbl";
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletLabel = " + PalletLabel);

                            PrintFunction();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "EXCEPTION: ScannerPrint: Failed to get data from DB (Incorrect data?): " + ex.Message);
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
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "RePrint");
                    int PalletLabelID = Convert.ToInt32(PrintBatchID);
                    //Get PalletBatchID
                    sql = "SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = " + PalletLabelID;
                    DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
                    PalletBatchID = Convert.ToInt32(dtCurrentBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletBatchID = " + PalletBatchID.ToString());

                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                    DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    TextBoxNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                    TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                    TextBoxProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits_AI.Text = " + TextBoxNetUnits_AI.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGMID.Text = " + TextBoxGMID.Text.ToString());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionLineNumber.Text = " + TextBoxProductionLineNumber.Text.ToString());

                    //Set printer name
                    switch (TextBoxProductionLineNumber.Text)
                    {
                        case "1":
                            comboBoxPrinter.Text = "SATO CL6NX 305dpi 1";
                            break;
                        default:
                            comboBoxPrinter.Text = "SATO CL6NX 305dpi 2";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "EXCEPTION: RePrint: Failed to get data from DB (Incorrect data?): " + ex.Message);
                    MessageBox.Show("RePrint: Failed to get data from DB (Incorrect data?)");
                    Program.Log.logSave();
                    this.Close();
                }
            }
        }

        private void buttonReprint_Click(object sender, EventArgs e)
        {
            string methodName = moduleName + "PrintForm1.buttonReprint_Click() ";
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "starting");
                labelPrintStatus.Text = "Printing - Please Wait..........";
                int PalletLabelID = Convert.ToInt32(PrintBatchID);
                //Get PalletBatchID
                sql = "SELECT PalletBatchUniqueNo FROM data.Pallet WHERE PalletUniqueNo = " + PalletLabelID;
                DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
                PalletBatchID = Convert.ToInt32(dtCurrentBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletBatchID = " + PalletBatchID.ToString());

                sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                TextBoxNetUnits_AI.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                TextBoxProductionLineNumber.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits_AI.Text = " + TextBoxNetUnits_AI.Text.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGMID.Text = " + TextBoxGMID.Text.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionLineNumber.Text = " + TextBoxProductionLineNumber.Text.ToString());
                
                //Set printer name
                PrinterName = comboBoxPrinter.Text;

                //Get batches/carton number on Pallet
                sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                int NoOfBatches = (dtCurrentPallet.Rows.Count);
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "NoOfBatches = " + NoOfBatches.ToString());

                if (NoOfBatches > 0)  // some pallet data exists, set label numbers and calculate batch data
                {

                    sql = "SELECT * FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID + "ORDER BY PalletLabelUniqueNo Asc";
                    dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                    NoOfBatches = (dtCurrentPallet.Rows.Count);  // Actual Number of Batches on the Pallet
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "NoOfBatches = " + NoOfBatches.ToString());

                    TextBoxTotalLabels.Text = Convert.ToString(NoOfBatches);

                    for (int i = 0; i < NoOfBatches; i++)
                    {

                        TextBoxCount.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("CartonsOnPallet"));
                        TextBoxNetUnits.Text = Convert.ToString(dtCurrentPallet.Rows[i].Field<int>("QtyInner"));
                        TextBoxBatchNumber.Text = dtCurrentPallet.Rows[i].Field<string>("MaterialBatchNo");
                        TextBoxProductionDate.Text = dtCurrentPallet.Rows[i].Field<string>("ProdDate");
                        TextBoxSSCC.Text = dtCurrentPallet.Rows[i].Field<string>("SSCC");
                        TextBoxGTIN.Text = dtCurrentPallet.Rows[i].Field<string>("GTIN");
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxCount.Text = " + TextBoxCount.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetUnits.Text = " + TextBoxNetUnits.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxBatchNumber.Text = " + TextBoxBatchNumber.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductionDate.Text = " + TextBoxProductionDate.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxSSCC.Text = " + TextBoxSSCC.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxGTIN.Text = " + TextBoxGTIN.Text.ToString());
                        
                        // GetProduct name from GTIN
                        sql = "SELECT TOP 1 ProductUniqueNo, ProductName, GTIN FROM Config.Products WHERE GTIN = '" + dtCurrentPallet.Rows[i].Field<string>("GTIN") + "' ORDER BY ProductUniqueNo desc";
                        dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                        TextBoxProductName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                        TextBoxNetVolume.Text = dtCurrentPallet.Rows[i].Field<string>("NetVolOrWt");
                        TextBoxLabelNumber.Text = Convert.ToString(i + 1);
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxProductName.Text = " + TextBoxProductName.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxNetVolume.Text = " + TextBoxNetVolume.Text.ToString());
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "TextBoxLabelNumber.Text = " + TextBoxLabelNumber.Text.ToString());

                        //Set label name
                        if (TextBoxNetUnits_AI.Text == "Kg")
                        {
                            PalletLabel = "ExwoldPalletLabel1K";
                        }
                        if (TextBoxNetUnits_AI.Text == "L")
                        {
                            PalletLabel = "ExwoldPalletLabel1L";
                        }
                        if (i > 0)
                        {
                            PalletLabel = PalletLabel + "_Additional";
                        }
                        PalletLabel = PalletLabel + ".nlbl";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "PalletLabel = " + PalletLabel);

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
    }
}

