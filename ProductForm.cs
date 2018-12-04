//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to :
//  1)  Get all Customer/Product details and display to the user
//  2)  Give the user an option to add, edit or delete Product Details
//  3)  Give the user an option to create a Pallet Batch from the product details
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
using System.Data.SqlClient;

namespace ExwoldPcInterface
{
    public partial class ProductForm : Form
    {
        // Define Class variables
        public string CreateBatchID;
        public string CreateBatchFlag;
        string UpdateType;
        string sql;
        string DoAdd;
        int ProductID;
        int NoRows;
        DataTable dtAllProducts;



          private void ProductForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // Populate Datagrid on form load                        
            sql = "SELECT * FROM Config.Products  WHERE ChangeAction <> 'Delete'";
            DataTable dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
            this.dataGridView1.DataSource = dtAllProducts;
            this.panel1.Visible = false;

            //set text box data masks
            TextBoxProdCode.MaxLength = 15;
            TextBoxCustomer.MaxLength = 14;
            TextBoxDetails.MaxLength = 1000;
            TextBoxGTIN.MaxLength = 14;
            TextBoxNotes.MaxLength = 1000;
            TextBoxGMID.MaxLength = 20;

        }

        public ProductForm()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            //enable input panel and populate from selected row in datagrid. Set update type for save button
            UpdateType = "Edit";
            this.panel1.Visible = true;
            this.button_save.Text = "Update";

            ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            sql = "SELECT * FROM Config.Products WHERE ProductUniqueNo = " + ProductID ;
            DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
            TextBoxCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
            TextBoxDetails.Text = dtCurrentProduct.Rows[0].Field<string>("CustomerDetails");
            TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
            TextBoxProdCode.Text = dtCurrentProduct.Rows[0].Field<string>("ProductCode");
            TextBoxProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
            TextBoxDefaultCartons.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultTotalNoOfCartons"));
            TextBoxCartsPerPallet.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultCartonsPerPallet"));
            TextBoxInnersPerCart.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultInnerPackPerCarton"));
            TextBoxInnerWeight.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<double>("InnerPackWeightOrVolume"));
            comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
            TextBoxInnerPackStyle.Text = dtCurrentProduct.Rows[0].Field<string>("PH2_InnerPackStylePackStyle");
            TextBoxGTIN.Text = dtCurrentProduct.Rows[0].Field<string>("GTIN");
            TextBoxCompanyCode.Text = dtCurrentProduct.Rows[0].Field<string>("SsccCompanyCode");
            TextBoxClientCode.Text = dtCurrentProduct.Rows[0].Field<string>("SsccProductionLineCustomerCode");
            TextBoxNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //Set update type for save button, and open input panel
            UpdateType = "Add";
            this.panel1.Visible = true;
            this.button_save.Text = "Save";

            var ProductID = dataGridView1.CurrentRow.Cells[0].Value;
        }

   


        private void button_save_Click(object sender, EventArgs e)
        {
            // do Data Validation
            DoAdd = "Yes";
            if (Program.ValidateInput(TextBoxCustomer.Text, "Customer", "", 50, 1))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxDetails.Text, "Details", "", 50))
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
            if (Program.ValidateInput(TextBoxDefaultCartons.Text, "Default Number of Cartons", "Int", 8,1))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxCartsPerPallet.Text, "Cartons per Pallet", "Int"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxInnersPerCart.Text, "Default Number of Inners", "Int"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxInnerWeight.Text, "Inner Pack Weight//Volume", "Numeric"))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxCompanyCode.Text, "SsccCompanyCode", "Numeric", 9, 9))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxClientCode.Text, "SsccProductionLineCustomerCode", "Numeric", 1, 1))
            {
                DoAdd = "no";
            }
            if (Program.ValidateInput(TextBoxGTIN.Text, "GTIN", "Int", 14, 14))
            {
                DoAdd = "no";
            }

            //Run Insert or update depending on which button opened the input panel, copy data into SQL table
            switch (UpdateType)
            {
                case "Edit":
                    if (DoAdd != "no")
                    {
                        sql = "UPDATE Config.Products SET Customer = '" + TextBoxCustomer.Text + "', CustomerDetails = '" + TextBoxDetails.Text + "', GMID = '" + TextBoxGMID.Text + "', ProductCode = '" + TextBoxProdCode.Text + "', ProductName = '" + TextBoxProdName.Text + "'," +
                                 "DefaultTotalNoOfCartons = '" + TextBoxDefaultCartons.Text + "', DefaultCartonsPerPallet = '" + TextBoxCartsPerPallet.Text + "', DefaultInnerPackPerCarton = '" + TextBoxInnersPerCart.Text + "', InnerPackWeightOrVolume = '" + TextBoxInnerWeight.Text + "'," +
                                 "UnitsOfMeasure = '" + comboBoxInnerUnit.Text + "', Ph2_InnerPackStylePackStyle = '" + TextBoxInnerPackStyle.Text + "', GTIN = '" + TextBoxGTIN.Text + "', SsccCompanyCode = '" + TextBoxCompanyCode.Text + "', SsccProductionLineCustomerCode = '" + TextBoxClientCode.Text + "', AdditionalInfo = '" + TextBoxNotes.Text + "', ChangeAction = 'Update'" +
                                 " WHERE ProductUniqueNo = " + ProductID;

                        NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        sql = "SELECT * FROM Config.Products WHERE ChangeAction <> 'Delete'";
                        DataTable dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
                        this.dataGridView1.DataSource = dtAllProducts;
                        this.panel1.Visible = false;


                        switch (NoRows)
                        {
                            case 1:
                                {
                                          MessageBox.Show("Product Updated");

                                    break;
                                }
                            case 0:
                                {
                                          MessageBox.Show("0 Rows Edited - Check Data Integrity");

                                    break;
                                }
                            default:
                                {
                                          MessageBox.Show("Error - Rows not 0 or 1");

                                    break;
                                }
                        }


                    }
                    break;


                case "Add":
                    //Validate input values and add data to Config.Products table



                    if (DoAdd != "no")
                    {
                        string values = "'" + TextBoxCustomer.Text + "', '" + TextBoxDetails.Text + "', '" + TextBoxGMID.Text + "', '" + TextBoxProdCode.Text + "', '" + TextBoxProdName.Text + "', '" + TextBoxDefaultCartons.Text + "', '" +
                                        TextBoxCartsPerPallet.Text + "', '" + TextBoxInnersPerCart.Text + "', '" + TextBoxInnerWeight.Text + "', '" + comboBoxInnerUnit.Text + "', '" + TextBoxInnerPackStyle.Text + "', '" + TextBoxGTIN.Text + "', '" + TextBoxCompanyCode.Text + "', '" +
                                        TextBoxClientCode.Text + "', 'Insert', '" + TextBoxNotes.Text + "'";
                        sql = "INSERT INTO Config.Products (Customer, CustomerDetails, GMID, ProductCode, ProductName," +
                                     "DefaultTotalNoOfCartons, DefaultCartonsPerPallet, DefaultInnerPackPerCarton, InnerPackWeightOrVolume," +
                                     "UnitsOfMeasure, Ph2_InnerPackStylePackStyle, GTIN, SsccCompanyCode, SsccProductionLineCustomerCode, ChangeAction, AdditionalInfo) " +
                                     "VALUES (" + values + ")";

                        NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        sql = "SELECT * FROM Config.Products WHERE ChangeAction <> 'Delete'";
                        dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
                        this.dataGridView1.DataSource = dtAllProducts;
                        this.panel1.Visible = false;

                        switch (NoRows)
                        {
                            case 1:
                                {
                                    MessageBox.Show("New Product succesfully added.");

                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("Failed - Check Data Integrity");

                                    break;
                                }
                            default:
                                {
                                      MessageBox.Show("Error - Rows not 0 or 1");

                                    break;
                                }
                        }
                    }

                    break;

                case "Delete":
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "This will permanently delete the selected product.", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        //delete record
                                        sql = "Update Config.Products SET ChangeAction = 'Delete'" +
                          " WHERE ProductUniqueNo = " + ProductID;

                        NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                    // Re-Populate Datagrid                        
                    sql = "SELECT * FROM Config.Products WHERE ChangeAction <> 'Delete'";
                    dtAllProducts = Program.ExwoldDb.ExecuteQuery(sql);
                    this.dataGridView1.DataSource = dtAllProducts;
                    this.panel1.Visible = false;

                    switch (NoRows)
                    {
                        case 1:
                            {
                                MessageBox.Show("Product Deleted");

                                break;
                            }

                        default:
                            {
                             //   MessageBox.Show("Error - Rows not 1");

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

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            {
                //Set update type for save button, and open input panel
                UpdateType = "Delete";
                this.panel1.Visible = true;
                this.button_save.Text = "Delete";
                ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                sql = "SELECT * FROM Config.Products WHERE ProductUniqueNo = " + ProductID;
                DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                TextBoxCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                TextBoxDetails.Text = dtCurrentProduct.Rows[0].Field<string>("CustomerDetails");
                TextBoxGMID.Text = dtCurrentProduct.Rows[0].Field<string>("GMID");
                TextBoxProdCode.Text = dtCurrentProduct.Rows[0].Field<string>("ProductCode");
                TextBoxProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                TextBoxDefaultCartons.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultTotalNoOfCartons"));
                TextBoxCartsPerPallet.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultCartonsPerPallet"));
                TextBoxInnersPerCart.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("DefaultInnerPackPerCarton"));
                TextBoxInnerWeight.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<double>("InnerPackWeightOrVolume"));
                comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0].Field<string>("UnitsOfMeasure");
                TextBoxInnerPackStyle.Text = dtCurrentProduct.Rows[0].Field<string>("PH2_InnerPackStylePackStyle");
                TextBoxGTIN.Text = dtCurrentProduct.Rows[0].Field<string>("GTIN");
                TextBoxCompanyCode.Text = dtCurrentProduct.Rows[0].Field<string>("SsccCompanyCode");
                TextBoxClientCode.Text = dtCurrentProduct.Rows[0].Field<string>("SsccProductionLineCustomerCode");
                TextBoxNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");

                // disable text fields

                TextBoxCustomer.Enabled = false;
                TextBoxDetails.Enabled = false;
                TextBoxGMID.Enabled = false;
                TextBoxProdCode.Enabled = false;
                TextBoxProdName.Enabled = false;
                TextBoxDefaultCartons.Enabled = false;
                TextBoxCartsPerPallet.Enabled = false;
                TextBoxInnersPerCart.Enabled = false;
                TextBoxInnerWeight.Enabled = false;
                comboBoxInnerUnit.Enabled = false;
                TextBoxInnerPackStyle.Enabled = false; ;
                TextBoxGTIN.Enabled = false;
                TextBoxCompanyCode.Enabled = false;
                TextBoxClientCode.Enabled = false;
                TextBoxNotes.Enabled = false;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            
            // set batch ID globals and open palletBatch form
            PalletForm frm2 = new PalletForm();
            frm2.CreateBatchFlag = "Create";
            frm2.CreateBatchID = Convert.ToString(ProductID);
            frm2.ShowDialog();
            this.Close();

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        
    }
}
