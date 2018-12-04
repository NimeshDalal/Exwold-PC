//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to :
//  1)  Get selected batch data and display to user
//  2)  Give the user an option to repring the latest pallet from the pallet batch
//  3)  Give the user an option to edit the batch
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Stuart Eglington 
//          Initial Creation
//
//******************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExwoldPcInterface
{
    public partial class BatchDetailsForm : Form
    {
        public string ViewBatchFlag;
        public string ViewBatchID;

        int PalletBatchID;
        int PalletLabelID;
        string sql;
        int status;
        string statusText;

        private const string moduleName = "Batch-Details:";

        private void BatchDetailsForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            switch (ViewBatchFlag)
            {
                case "True":
                    {
                        PalletBatchID = Convert.ToInt32(ViewBatchID);

                        sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchID;
                        DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                        if (dtCurrentProduct.Rows.Count > 0)
                        {

                            textBoxPalletBatchNo.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
                            textBoxCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                            textBoxProdCode.Text = dtCurrentProduct.Rows[0].Field<string>("ProductCode");
                            textBoxProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                            textBoxTotalCartons.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("TotalNoOfCartons"));
                            textBoxCartsPerPallet.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("CartonsPerPallet"));
                            textBoxInnersPerCart.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("InnerPacksPerCarton"));
                            TextBoxInnerWeight.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<double>("InnerPackWeightOrVolume"));
                            comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                            TextBoxNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");
                            textBoxProdLine.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                            //convert Status to human readable , set colour
                            status = dtCurrentProduct.Rows[0].Field<Int16>("Status");

                            switch (status)
                            {
                                case 0:
                                    statusText = "Available";
                                    labelStatus.ForeColor = System.Drawing.Color.Black;
                                    break;
                                case 1:
                                    statusText = "In-Progress";
                                    labelStatus.ForeColor = System.Drawing.Color.Green;
                                    break;
                                case 2:
                                    statusText = "On-Hold";
                                    labelStatus.ForeColor = System.Drawing.Color.Black;
                                    break;
                                case 3:
                                    statusText = "Ready to Print";
                                    labelStatus.ForeColor = System.Drawing.Color.Green;
                                    break;
                                case 4:
                                    statusText = "Completed";
                                    labelStatus.ForeColor = System.Drawing.Color.Black;
                                    break;
                                case 5:
                                    statusText = "Stopped";
                                    labelStatus.ForeColor = System.Drawing.Color.Black;
                                    break;
                            }
                            labelStatus.Text = statusText;

                            //Get batches/carton number on Pallet

                            sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + PalletBatchID;
                            DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                            if (dtCurrentPallet.Rows.Count > 0)

                            {
                                int LastRow = dtCurrentPallet.Rows.Count - 1;

                                PalletLabelID = Convert.ToInt32(dtCurrentPallet.Rows[LastRow].Field<Int64>("PalletUniqueNo"));
                                textBoxCurrentPallet.Text = Convert.ToString(dtCurrentPallet.Rows.Count);

                                sql = "SELECT MaterialBatchNo, CartonsOnPallet FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID;

                                dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                                this.dataGridView2.DataSource = dtCurrentPallet;
                                this.dataGridView2.Columns[1].Visible = false;

                                object sumObject;
                                sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                                textBoxCartonsOnPallet.Text = sumObject.ToString();
                            }
                        }
                        else
                        {
                            const string methodName = moduleName + "viewBatchData(): ";
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Failed to get data for batch " + PalletLabelID);
                        }
                    break;
                    }

            }
        }

        public BatchDetailsForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                // set batch ID globals and open palletBatch form
                PalletForm frm2 = new PalletForm();
                frm2.CreateBatchFlag = "Edit";
                frm2.CreateBatchID = Convert.ToString(PalletBatchID);
                frm2.ShowDialog();
                const string methodName = moduleName + "buttonEdit_Click(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "User clicked Edit for batch " + PalletLabelID);
            }
        }

        private void buttonPrintLabel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This option is only to re-print pallet labels. \n\rPlease make sure the old label is destryoyed before re-printing.\n\r\n\rOld Label Destroyed?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                PrintForm1 frmPrint = new PrintForm1();
                frmPrint.PrintBatchFlag = "Reprint";
                frmPrint.PrintBatchID = Convert.ToString(PalletLabelID);
                frmPrint.ShowDialog();
                const string methodName = moduleName + "buttonPrintLabel_Click(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "User clicked Re-print for batch " + PalletLabelID);
                Program.Log.logSave();
                Application.Restart();
            }
        }
    }
}
