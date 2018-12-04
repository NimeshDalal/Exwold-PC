//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to :
//  1)  Get all Pallet Batch data and display to user
//  2)  Give the user an option to Create edit and delete pallet batches
//  3)  Give the user an option to change the status of a pallet batch
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
    public partial class PalletForm : Form
    {
        public string CreateBatchFlag;
        public string CreateBatchID;
        string UpdateType;
        string sql;
        string DoAdd;
        int BatchID;
        int ProductID;
        int NoRows;
        int status;
        DataTable dtAllProducts;

        private const string moduleName = "PalletForm:";


        private void PalletDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exwoldTrackingDataSet5.PalletBatchStatus' table. You can move, or remove it, as needed.
            this.palletBatchStatusTableAdapter.Fill(this.exwoldTrackingDataSet5.PalletBatchStatus);
            //set fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            string sql = "SELECT PalletBatchNo AS SalesOrder, * FROM data.PalletBatch WHERE status <> 4 and status <> 5 and ChangeAction <> 'Delete'";
            DataTable dt = Program.ExwoldDb.ExecuteQuery(sql);
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[2].Visible = false;


            //do this if opened from Products page ***********UPDATE**************

            switch (CreateBatchFlag)
            {
                case "Create":
                    {
                       ProductID = Convert.ToInt32(CreateBatchID);
                       button_add.PerformClick();
                        const string methodName = moduleName + "PalletDetailsForm_Load(): ";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Pallet Form Loaded from Create Pallet Batch Button");
                        break;
                    }
                case "Edit":
                    {
                        BatchID = Convert.ToInt32(CreateBatchID);
                        button_edit.PerformClick();
                        const string methodName = moduleName + "PalletDetailsForm_Load(): ";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Pallet Form Loaded from Edit Pallet Batch Button");
                        break;
                    }
            }

        }


        public PalletForm()
        {
            InitializeComponent();

        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        


        private void button_add_Click_1(object sender, EventArgs e)
        {
            //Set update type for save button, and open input panel

            switch (CreateBatchFlag)
            {

                case "Create":  //means dialogue has been opened from products page, continue

                    {
                        UpdateType = "Add";
                        this.panel1.Visible = true;
                        this.buttonEnableStatus.Visible = false;
                        this.button_save.Text = "Save";

                        sql = "SELECT * FROM Config.Products WHERE ProductUniqueNo = " + ProductID;
                        DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                        TextBoxCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                        TextBoxDetails.Text = dtCurrentProduct.Rows[0].Field<string>("CustomerDetails");
                        TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                        TextBoxProdCode.Text = dtCurrentProduct.Rows[0].Field<string>("ProductCode");
                        TextBoxProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                        TextBoxTotalCartons.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultTotalNoOfCartons"));
                        TextBoxCartsPerPallet.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultCartonsPerPallet"));
                        TextBoxInnersPerCart.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultInnerPackPerCarton"));
                        TextBoxInnerWeight.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<double>("InnerPackWeightOrVolume"));
                        comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                        TextBoxInnerPackStyle.Text = dtCurrentProduct.Rows[0].Field<string>("PH2_InnerPackStylePackStyle");
                        TextBoxGTIN.Text = dtCurrentProduct.Rows[0].Field<string>("GTIN");
                        TextBoxCompanyCode.Text = dtCurrentProduct.Rows[0].Field<string>("SsccCompanyCode");
                        TextBoxClientCode.Text = dtCurrentProduct.Rows[0].Field<string>("SsccProductionLineCustomerCode");
                        TextBoxNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");

                        comboBoxStatus.Visible = false;
                        labelStatus.Visible = false;
                        CreateBatchFlag = "Reset";
                        break;

                    }


                default:  //no product has been selected, send user to products page
                    {
                        this.Close();
                        ProductForm form10 = new ProductForm();
                        form10.ShowDialog();
                        const string methodName = moduleName + "PalletDetailsForm_Load(): ";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Open Product Form from Pallet Form Add button");
                        break;
                    }
            }
        }

        private void button_save_Click_1(object sender, EventArgs e)
        {
            //Do data validation
            DoAdd = "Yes";
            if (Program.ValidateInput(TextBoxCustomer.Text, "Customer", "", 50, 1))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxDetails.Text, "Details", "", 50 ))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxGMID.Text, "GMID", "", 20))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxProdCode.Text, "Product Code", "", 15, 1))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxTotalCartons.Text, "Total Number of Cartons", "Int",8,1, "No"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxCartsPerPallet.Text, "Cartons per Pallet", "Int", 8,1, "No"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxInnersPerCart.Text, "Default Number of Inners", "Int", 7,1, "No"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxInnerWeight.Text, "Inner Pack Weight//Volume", "Numeric",7,1, "No"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxPalletBatchNo.Text, "Sales Order", "", 15, 1))
            {
                DoAdd = "no";
            }

            if (Program.ValidateInput(comboBoxProdLine.Text, "Production Line", "ProdLine"))
            {
                DoAdd = "no";
            }


            //Run Insert or update depending on which button opened the inpuyt panel, copy data into SQL table
            switch (UpdateType)
            {
                case "Edit":

                    this.buttonEnableStatus.Visible = true;
                    if (Program.ValidateInput(TextBoxPalletBatchNo.Text, "Sales Order", "SalesOrderEdit"))
                    {
                        DoAdd = "no";
                    }
                    if (DoAdd != "no")
                    {
                        sql = "UPDATE Data.PalletBatch SET ProductionLineNo = '" + comboBoxProdLine.Text + "'," +"PalletBatchNo = '" + TextBoxPalletBatchNo.Text + "'," +
                                     "TotalNoOfCartons = '" + TextBoxTotalCartons.Text + "', CartonsPerPallet = '" + TextBoxCartsPerPallet.Text + "', InnerPacksPerCarton = '" + TextBoxInnersPerCart.Text + "', InnerPackWeightOrVolume = '" + TextBoxInnerWeight.Text + "'," +
                                     "UnitsOfMeasure = '" + comboBoxInnerUnit.Text + "', Status = '" + comboBoxStatus.SelectedValue + "', AdditionalInfo = '" + TextBoxNotes.Text + "', ChangeAction = 'Update'" +
                                     " WHERE PalletBatchUniqueNo = " + BatchID;

                        NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        sql = "SELECT PalletBatchNo AS SalesOrder, * FROM data.PalletBatch WHERE status <> 4 and status <> 5 and ChangeAction <> 'Delete'";
                        dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
                        this.dataGridView1.DataSource = dtAllProducts;
                        this.panel1.Visible = false;

                        //error checking - remove or update for logging
                        switch (NoRows)
                        {
                            case 1:
                                {
                                    MessageBox.Show("Sales Order updated.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Pallet Batch Edited " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("Edit Failed - Please check data and try again.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Pallet Batch Edit Failed " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Edit Failed - Unknown Error. Please check data and try again.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Edit Failed - Unknown Error. Pallet Batch Edit returned too many rows " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                        }


                    }
                    break;


                case "Add":
                    if (Program.ValidateInput(TextBoxPalletBatchNo.Text, "Sales Order", "SalesOrderAdd"))
                    {
                        DoAdd = "no";
                    }
                    if (DoAdd != "no")
                    {

                        string values = "'" + TextBoxPalletBatchNo.Text + "', '" + comboBoxProdLine.Text + "', '" + ProductID + "', '" + TextBoxProdCode.Text + "', '" + TextBoxProdName.Text + "', '" + TextBoxCustomer.Text + "', '" + TextBoxDetails.Text + "', '" + TextBoxGMID.Text + "', '" + TextBoxTotalCartons.Text + "', '" +
                                    TextBoxCartsPerPallet.Text + "', '" + TextBoxInnersPerCart.Text + "', '" + TextBoxInnerWeight.Text + "', '" + comboBoxInnerUnit.Text + "', '" + TextBoxGTIN.Text + "', '" + TextBoxCompanyCode.Text + "', '" +
                                    TextBoxClientCode.Text + "', '" + TextBoxNotes.Text + "', 0, 'Insert'";
                        sql = "INSERT INTO Data.PalletBatch (PalletBatchNo, ProductionLineNo, ProductUniqueNo, ProductCode, ProductName, Customer, CustomerDetails, GMID," +
                                     "TotalNoOfCartons, CartonsPerPallet, InnerPacksPerCarton, InnerPackWeightOrVolume," +
                                     "UnitsOfMeasure, GTIN, SsccCompanyCode, SsccProductionLineCustomerCode, AdditionalInfo, Status, ChangeAction) " +
                                     "VALUES (" + values + ")";

                        NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        sql = "SELECT PalletBatchNo AS SalesOrder, * FROM data.PalletBatch WHERE status <> 4 and status <> 5 and ChangeAction <> 'Delete'";
                        dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
                        this.dataGridView1.DataSource = dtAllProducts;
                        this.panel1.Visible = false;
                        CreateBatchFlag = "False";

                        switch (NoRows)
                        {
                            case 1:
                                {
                                    MessageBox.Show("New Sales Order created");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Sales Order Added " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("Failed to add Sales Order - Please check data and try again.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Sales Order Add Failed " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Failed to add Sales Order - Unknown Error, Please check data and try again.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Sales Order Add Failed - too many rows returned " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                        }
                    }
                    break;

                case "Delete":
                   
                        DialogResult dialogResult = MessageBox.Show("Are you sure?", "This will permanently delete the selected Sales Order.", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            //delete record
                            sql = "UPDATE data.PalletBatch SET ChangeAction = 'Delete', status = 5 " +
                                 " WHERE PalletBatchUniqueNo = " + BatchID;

                            NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                            // Re-Populate Datagrid                        
                            sql = "SELECT PalletBatchNo AS SalesOrder, * FROM data.PalletBatch WHERE status <> 4 and status <> 5 and ChangeAction <> 'Delete'";
                            dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
                            this.dataGridView1.DataSource = dtAllProducts;
                            this.panel1.Visible = false;

                            // logging 
                            switch (NoRows)
                            {
                                case 1:
                                    {
                                    MessageBox.Show("Sales Order deleted.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Sales Order Deleted " + TextBoxPalletBatchNo.Text);
                                    break;
                                }

                                default:
                                    {
                                    MessageBox.Show("Failed to Delete Sales Order - Please check data and try again.");
                                    const string methodName = moduleName + "button_save_Click_1(): ";
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Pallet Batch Delete Failed " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            }
                        }
                    
                    else if (dialogResult == DialogResult.No)
                    {
                        //don't delete record
                    }





                    break;
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            //enable input panel and populate from selected row in datagrid. Set update type for save button


            if (CreateBatchFlag != "Edit")
            {
                if (dataGridView1.CurrentRow != null
                     && dataGridView1.CurrentRow.Cells[1] != null)
                {
                    BatchID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                }
                else
                {
                    CreateBatchFlag = "";
                    MessageBox.Show("No Sales Order Selected");
                    const string methodName = moduleName + "button_edit_Click(): ";
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Attempt to edit blank Sales Order" + BatchID);
                    return;
                }
            }


            UpdateType = "Edit";
            this.button_save.Text = "Update";
            this.panel1.Visible = true;
            CreateBatchFlag = "";
            sql = "SELECT * FROM Data.PalletBatch WHERE PalletBatchUniqueNo = " + BatchID;
            DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
            TextBoxCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
            TextBoxProdCode.Text = dtCurrentProduct.Rows[0].Field<string>("ProductCode");
            TextBoxProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
            TextBoxTotalCartons.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("TotalNoOfCartons"));
            TextBoxCartsPerPallet.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("CartonsPerPallet"));
            TextBoxInnersPerCart.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("InnerPacksPerCarton"));
            TextBoxInnerWeight.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<double>("InnerPackWeightOrVolume"));
            comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
            TextBoxPalletBatchNo.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
            comboBoxProdLine.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
            TextBoxNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");
            comboBoxStatus.SelectedValue = Convert.ToString(dtCurrentProduct.Rows[0].Field<Int16>("Status"));

            //Warn user if batch is In-Progress
            if(Convert.ToString(comboBoxStatus.SelectedValue) == "1")
            {
                MessageBox.Show("WARNING - Pallet Batch is In-Progress" + Environment.NewLine + "" + Environment.NewLine + "You cannot edit this batch unless the status is changed.");
                const string methodName = moduleName + "button_edit_Click_1(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "In-Progress Pallet Batch opened to edit " + BatchID);
 
                comboBoxStatus.Enabled = false;

                TextBoxCustomer.Enabled = false;
                TextBoxProdCode.Enabled = false;
                TextBoxProdName.Enabled = false;
                TextBoxTotalCartons.Enabled = false;
                TextBoxCartsPerPallet.Enabled = false;
                TextBoxInnersPerCart.Enabled = false;
                TextBoxInnerWeight.Enabled = false;
                comboBoxInnerUnit.Enabled = false;
                TextBoxPalletBatchNo.Enabled = false;
                comboBoxProdLine.Enabled = false;
                TextBoxNotes.Enabled = false;


            }
            else 
            {
                    comboBoxStatus.Enabled = false;

                TextBoxCustomer.Enabled = true;
                TextBoxProdCode.Enabled = true;
                TextBoxProdName.Enabled = true;
                TextBoxTotalCartons.Enabled = true;
                TextBoxCartsPerPallet.Enabled = true;
                TextBoxInnersPerCart.Enabled = true;
                TextBoxInnerWeight.Enabled = true;
                comboBoxInnerUnit.Enabled = true;
                TextBoxPalletBatchNo.Enabled = true;
                comboBoxProdLine.Enabled = true;
                TextBoxNotes.Enabled = true;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            {
                //Set update type for save button, and open input panel
                UpdateType = "Delete";
                this.panel1.Visible = true;
                this.button_save.Text = "Delete";
                BatchID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);

                sql = "SELECT * FROM Data.PalletBatch WHERE PalletBatchUniqueNo = " + BatchID;
                DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                TextBoxCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                TextBoxProdCode.Text = dtCurrentProduct.Rows[0].Field<string>("ProductCode");
                TextBoxProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                TextBoxTotalCartons.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("TotalNoOfCartons"));
                TextBoxCartsPerPallet.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("CartonsPerPallet"));
                TextBoxInnersPerCart.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("InnerPacksPerCarton"));
                TextBoxInnerWeight.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<double>("InnerPackWeightOrVolume"));
                comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                TextBoxPalletBatchNo.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
                comboBoxProdLine.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("ProductionLineNo"));
                TextBoxNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");
                comboBoxStatus.SelectedValue = Convert.ToString(dtCurrentProduct.Rows[0].Field<Int16>("Status"));
                status = Convert.ToInt16(comboBoxStatus.SelectedValue);

                comboBoxStatus.Enabled = false;
                TextBoxCustomer.Enabled = false;
                TextBoxProdCode.Enabled = false;
                TextBoxProdName.Enabled = false;
                TextBoxTotalCartons.Enabled = false;
                TextBoxCartsPerPallet.Enabled = false;
                TextBoxInnersPerCart.Enabled = false;
                TextBoxInnerWeight.Enabled = false;
                comboBoxInnerUnit.Enabled = false;
                TextBoxPalletBatchNo.Enabled = false;
                comboBoxProdLine.Enabled = false;
                TextBoxNotes.Enabled = false;
                buttonEnableStatus.Visible = false;
            }
        }

       /// <summary>
       /// Opens Pallet details form for highlighted batch
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            BatchID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);

            BatchDetailsForm frm4 = new BatchDetailsForm();
            frm4.ViewBatchFlag = "True";
            frm4.ViewBatchID = Convert.ToString(BatchID);
            frm4.ShowDialog(); 
        }

       /// <summary>
       /// enables status field to be updated - warn user
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       private void buttonEnableStatus_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("WARNING - Pallet Batch status should normally be controlled" + Environment.NewLine + "via the Hand Held Scanner." + Environment.NewLine + "It should only be changed from this application to resolve problems." + Environment.NewLine + Environment.NewLine + "Are you sure?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //enable status change dialogue
                comboBoxStatus.Enabled = true;
                const string methodName = moduleName + "buttonEnableStatus_Click(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "User chose to update batch status " + dataGridView1.CurrentRow.Cells[1].Value);


            }

            else if (dialogResult == DialogResult.No)
            {
                //don't enable status
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            comboBoxStatus.Enabled = true;
            comboBoxStatus.Visible = true;
            labelStatus.Visible = true;
            this.buttonEnableStatus.Visible = true;
            CreateBatchFlag = "Reset";
            const string methodName = moduleName + "buttonEnableStatus_Click(): ";
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "User cancelled batch edit " + dataGridView1.CurrentRow.Cells[1].Value);

        }
    }
}

