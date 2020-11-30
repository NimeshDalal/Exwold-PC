/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmProduct.cs
 * Description: Provides an interface to :
 *              1)  Get all Customer/Product details and display to the user
 *              2)  Give the user an option to add, edit or delete Product Details
 *              3)  Give the user an option to create a Pallet Batch from the product details
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop
{
    public partial class frmProduct : Form
    {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;

        // Define Class variables
        private const string _cstbtnSalesOrderText = "Create Sales Order";
        public string CreateBatchID;
        public string CreateBatchFlag;
        string UpdateType;
        string DoAdd;
        int ProductID;
        int NoRows;
        #endregion
        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion
        public frmProduct(ExwoldConfigSettings ExwoldConfigSettings, DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
            _exwoldConfigSettings = ExwoldConfigSettings;
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
#if DEBUG
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif

            getProducts();

            //set text box data masks
            tbProdCode.MaxLength = 15;
            tbCustomer.MaxLength = 14;
            tbDetails.MaxLength = 1000;
            tbGTIN.MaxLength = 14;
            tbInnerGTIN.MaxLength = 14;
            tbNotes.MaxLength = 1000;
            tbGMID.MaxLength = 20;
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            //enable input panel and populate from selected row in datagrid. Set update type for save button
            UpdateType = "Edit";
            this.pnlProductDetails.Visible = true;
            this.btnSave.Text = "Update";

            DataTable dtCurrentProduct = null;

            int ProdId = -1;
            if (int.TryParse(dgvAllProducts.CurrentRow.Cells[0].Value.ToString(), out ProdId))
            {
                dtCurrentProduct = await getProductById(Convert.ToInt32(dgvAllProducts.CurrentRow.Cells[0].Value));
            }

            //DataTable dtCurrentProduct = await getProductById(Convert.ToInt32(dgvAllProducts.CurrentRow.Cells[0].Value));

            //Mesh Remove
            //sql = "SELECT * FROM Config.Products WHERE ProductUniqueNo = " + ProductID ;
            //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

            tbCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
            tbDetails.Text = dtCurrentProduct.Rows[0]["CustomerDetails"].ToString();
            tbGMID.Text = dtCurrentProduct.Rows[0]["GMID"].ToString();
            tbProdCode.Text = dtCurrentProduct.Rows[0]["ProductCode"].ToString();
            tbProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
            tbDefaultCartons.Text = dtCurrentProduct.Rows[0]["DefaultTotalNoOfCartons"].ToString();
            tbCartsPerPallet.Text = dtCurrentProduct.Rows[0]["DefaultCartonsPerPallet"].ToString();
            tbInnersPerCart.Text = dtCurrentProduct.Rows[0]["DefaultInnerPackPerCarton"].ToString();
            tbInnerWeight.Text = dtCurrentProduct.Rows[0]["InnerPackWeightOrVolume"].ToString();
            cboInnerUnit.Text = dtCurrentProduct.Rows[0]["UnitsOfMeasure"].ToString();
            tbInnerPackStyle.Text = dtCurrentProduct.Rows[0]["PH2_InnerPackStylePackStyle"].ToString();
            tbGTIN.Text = dtCurrentProduct.Rows[0]["GTIN"].ToString();
            tbInnerGTIN.Text = dtCurrentProduct.Rows[0]["InnerGTIN"].ToString();
            tbCompanyCode.Text = dtCurrentProduct.Rows[0]["SsccCompanyCode"].ToString();
            tbClientCode.Text = dtCurrentProduct.Rows[0]["SsccProductionLineCustomerCode"].ToString();
            tbNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Set update type for save button, and open input panel
            UpdateType = "Add";
            this.pnlProductDetails.Visible = true;
            this.btnSave.Text = "Save";

            //var ProductID = dgvAllProducts.CurrentRow.Cells[0].Value;

            // Copy the selected product
            if (dgvAllProducts.CurrentRow != null)
            {
                copyProductToTextBoxes();
            }
        }        
        private async void getProducts()
        {
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("Plant", _exwoldConfigSettings.PlantID.ToString());
            _db.QueryParameters.Add("ChangeAction", "Delete");
            DataTable dtAllProducts = await _db.executeSP("[GUI].[getProductByNOTChangeAction]", true);
            dgvAllProducts.DataSource = dtAllProducts;
            dgvAllProducts.ClearSelection();
            pnlProductDetails.Visible = false;

            try
            {
                Helper.dgvColumnsVisible(dgvAllProducts, "ProductUniqueNo", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "Plant", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "ChangeUser", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "ChangeDTUTC", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "ChangeDTLocal", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "ChangeSqlUser", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "ChangeUId", false);
                Helper.dgvColumnsVisible(dgvAllProducts, "ChangeAction", false);
            }
            catch 
            { 
                //Don't do anything here 
            }
            btnCreateSalesOrder.Text = _cstbtnSalesOrderText;
            btnCreateSalesOrder.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void copyProductToTextBoxes()
        {
            tbCustomer.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "Customer").ToString();
            tbDetails.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "CustomerDetails").ToString();
            tbGMID.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "GMID").ToString();
            tbProdCode.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductCode").ToString();
            tbProdName.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductName").ToString();
            tbDefaultCartons.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "DefaultTotalNoOfCartons").ToString();
            tbCartsPerPallet.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "DefaultCartonsPerPallet").ToString();
            tbInnersPerCart.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "DefaultInnerPackPerCarton").ToString();
            tbInnerWeight.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "InnerPackWeightOrVolume").ToString();
            cboInnerUnit.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "UnitsOfMeasure").ToString();
            tbInnerPackStyle.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "PH2_InnerPackStylePackStyle").ToString();

            tbGTIN.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "GTIN").ToString();
            tbInnerGTIN.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "InnerGTIN").ToString();
            tbCompanyCode.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "SsccCompanyCode").ToString();
            tbClientCode.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "SsccProductionLineCustomerCode").ToString();
            tbNotes.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "AdditionalInfo").ToString();
        }

        private async Task<DataTable> getProductById(int productId)
        {
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("ProductId", ProductID.ToString());
            DataTable dt = await _db.executeSP("[GUI].[getProductById]", true);

            tbCustomer.Text = dt.Rows[0].Field<string>("Customer");
            tbDetails.Text = dt.Rows[0].Field<string>("CustomerDetails");
            tbGMID.Text = dt.Rows[0].Field<string>("GMID");
            tbProdCode.Text = dt.Rows[0].Field<string>("ProductCode");
            tbProdName.Text = dt.Rows[0].Field<string>("ProductName");
            tbDefaultCartons.Text = Convert.ToString(dt.Rows[0].Field<int>("DefaultTotalNoOfCartons"));
            tbCartsPerPallet.Text = Convert.ToString(dt.Rows[0].Field<int>("DefaultCartonsPerPallet"));
            tbInnersPerCart.Text = Convert.ToString(dt.Rows[0].Field<int>("DefaultInnerPackPerCarton"));
            tbInnerWeight.Text = Convert.ToString(dt.Rows[0].Field<double>("InnerPackWeightOrVolume"));
            cboInnerUnit.Text = dt.Rows[0].Field<string>("UnitsOfMeasure");
            tbInnerPackStyle.Text = dt.Rows[0].Field<string>("PH2_InnerPackStylePackStyle");
            tbGTIN.Text = dt.Rows[0].Field<string>("GTIN");
            tbInnerGTIN.Text = dt.Rows[0].Field<string>("InnerGTIN");
            tbCompanyCode.Text = dt.Rows[0].Field<string>("SsccCompanyCode");
            tbClientCode.Text = dt.Rows[0].Field<string>("SsccProductionLineCustomerCode");
            tbNotes.Text = dt.Rows[0].Field<string>("AdditionalInfo");

            return dt;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            #region do Data Validation
            clsValidation chk = new clsValidation(_db);
            DoAdd = "Yes";
            if (await chk.ValidateInput(tbCustomer.Text, "Customer", "", 50, 1))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbDetails.Text, "Details", "", 50))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbGMID.Text, "GMID", "", 20))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbProdCode.Text, "Product Code", "", 15, 1))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbDefaultCartons.Text, "Default Number of Cartons", "Int", 8,1))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbCartsPerPallet.Text, "Cartons per Pallet", "Int"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbInnersPerCart.Text, "Default Number of Inners", "Int"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbInnerWeight.Text, "Inner Pack Weight//Volume", "Numeric"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbCompanyCode.Text, "SsccCompanyCode", "Numeric", 9, 9))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbClientCode.Text, "SsccProductionLineCustomerCode", "Numeric", 1, 1))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbGTIN.Text, "GTIN", "Int", 14, 14))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbInnerGTIN.Text, "InnerGTIN", "Int", 14, 14))
            {
                DoAdd = "no";
            }
            #endregion

            //Run Insert or update depending on which button opened the input panel, copy data into SQL table
            switch (UpdateType)
            {
                case "Edit":                   
                    if (DoAdd != "no")
                    {
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("ProductUniqueNo", ProductID.ToString());
                        _db.QueryParameters.Add("Customer", tbCustomer.Text);
                        _db.QueryParameters.Add("CustDetails", tbDetails.Text);
                        _db.QueryParameters.Add("GMID", tbGMID.Text);
                        _db.QueryParameters.Add("ProdCode", tbProdCode.Text);
                        _db.QueryParameters.Add("ProdName", tbProdName.Text);
                        _db.QueryParameters.Add("DefaultTotalCartons", tbDefaultCartons.Text);
                        _db.QueryParameters.Add("DefaultCartonPerPallet", tbCartsPerPallet.Text);
                        _db.QueryParameters.Add("DefaultInnersPerCarton", tbInnersPerCart.Text);
                        _db.QueryParameters.Add("InnerWeight", tbInnerWeight.Text);
                        _db.QueryParameters.Add("UoM", cboInnerUnit.Text);
                        _db.QueryParameters.Add("InnerPackStyle", tbInnerPackStyle.Text);
                        _db.QueryParameters.Add("GTIN", tbGTIN.Text);
                        _db.QueryParameters.Add("InnerGTIN", tbInnerGTIN.Text);
                        _db.QueryParameters.Add("SsccCompanyCode", tbCompanyCode.Text);
                        _db.QueryParameters.Add("SsccCustCode", tbClientCode.Text);
                        _db.QueryParameters.Add("ChangeAction", "Update");
                        _db.QueryParameters.Add("AddInfo", tbNotes.Text);

                        DataTable dtResult = await _db.executeSP("[GUI].[updateProducts]", true);
                        int rtnCode;
                        if (int.TryParse(dtResult.Rows[0].ItemArray[0].ToString(), out rtnCode))
                        {
                            if (rtnCode > 0)
                            {
                                //Row updated
                                NoRows = 1;
                            }
                            else
                            {
                                //An error occurred
                                NoRows = 0;
                            }
                        }
                        else
                        {
                            NoRows = int.MinValue;
                        }

                        //Mesh Remove
                        //sql = "UPDATE Config.Products SET Customer = '" + tbCustomer.Text + "', " +
                        //    "CustomerDetails = '" + tbDetails.Text + "', " +
                        //    "GMID = '" + tbGMID.Text + "', " +
                        //    "ProductCode = '" + tbProdCode.Text + "', " +
                        //    "ProductName = '" + tbProdName.Text + "'," +
                        //         "DefaultTotalNoOfCartons = '" + tbDefaultCartons.Text + "', " +
                        //         "DefaultCartonsPerPallet = '" + tbCartsPerPallet.Text + "', " +
                        //         "DefaultInnerPackPerCarton = '" + tbInnersPerCart.Text + "', " +
                        //         "InnerPackWeightOrVolume = '" + tbInnerWeight.Text + "'," +
                        //         "UnitsOfMeasure = '" + cboInnerUnit.Text + "', " +
                        //         "Ph2_InnerPackStylePackStyle = '" + tbInnerPackStyle.Text + "', " +
                        //         "GTIN = '" + tbGTIN.Text + "', " +
                        //         "SsccCompanyCode = '" + tbCompanyCode.Text + "', " +
                        //         "SsccProductionLineCustomerCode = '" + tbClientCode.Text + "', " +
                        //         "AdditionalInfo = '" + tbNotes.Text + "', " +
                        //         "ChangeAction = 'Update'" +
                        //         " WHERE ProductUniqueNo = " + ProductID;

                        //NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        getProducts();

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
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("Customer", tbCustomer.Text);
                        _db.QueryParameters.Add("CustDetails", tbDetails.Text);
                        _db.QueryParameters.Add("GMID", tbGMID.Text);
                        _db.QueryParameters.Add("ProdCode", tbProdCode.Text);
                        _db.QueryParameters.Add("ProdName", tbProdName.Text);
                        _db.QueryParameters.Add("Plant", _exwoldConfigSettings.PlantID.ToString());
                        _db.QueryParameters.Add("DefaultTotalCartons", tbDefaultCartons.Text);
                        _db.QueryParameters.Add("DefaultCartonPerPallet", tbCartsPerPallet.Text);
                        _db.QueryParameters.Add("DefaultInnersPerCarton", tbInnersPerCart.Text);
                        _db.QueryParameters.Add("InnerWeight", tbInnerWeight.Text);
                        _db.QueryParameters.Add("UoM", cboInnerUnit.Text);
                        _db.QueryParameters.Add("InnerPackStyle", tbInnerPackStyle.Text);
                        _db.QueryParameters.Add("GTIN", tbGTIN.Text);
                        _db.QueryParameters.Add("InnerGTIN", tbInnerGTIN.Text);
                        _db.QueryParameters.Add("SsccCompanyCode", tbCompanyCode.Text);
                        _db.QueryParameters.Add("SsccCustCode", tbClientCode.Text);
                        _db.QueryParameters.Add("ChangeAction", "Insert");
                        _db.QueryParameters.Add("AddInfo", tbNotes.Text);

                        DataTable dtResult = await _db.executeSP("[GUI].[createProduct]", true);
                        int NewUId;
                        if (int.TryParse(dtResult.Rows[0].ItemArray[0].ToString(), out NewUId))
                        {
                            if (NewUId > 0)
                            {
                                //The new UId is returned
                                NoRows = 1;
                            }
                            else
                            {
                                NoRows = 0;
                            }
                        }
                        else
                        {
                            NoRows = int.MinValue;
                        }

                        //Mesh Remove
                        //string values = "'" + tbCustomer.Text + "', '" + tbDetails.Text + "', '" + tbGMID.Text + "', '" + 
                        //                tbProdCode.Text + "', '" + tbProdName.Text + "', '" + tbDefaultCartons.Text + "', '" +
                        //                tbCartsPerPallet.Text + "', '" + tbInnersPerCart.Text + "', '" + tbInnerWeight.Text + "', '" + 
                        //                cboInnerUnit.Text + "', '" + tbInnerPackStyle.Text + "', '" + tbGTIN.Text + "', '" + 
                        //                tbCompanyCode.Text + "', '" + tbClientCode.Text + "', 'Insert', '" + 
                        //                tbNotes.Text + "'";
                        //sql = "INSERT INTO Config.Products (Customer, CustomerDetails, GMID, ProductCode, ProductName," +
                        //             "DefaultTotalNoOfCartons, DefaultCartonsPerPallet, DefaultInnerPackPerCarton, InnerPackWeightOrVolume," +
                        //             "UnitsOfMeasure, Ph2_InnerPackStylePackStyle, GTIN, SsccCompanyCode, SsccProductionLineCustomerCode, ChangeAction, AdditionalInfo) " +
                        //             "VALUES (" + values + ")";
                        //NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        getProducts();

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
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("ProductId", ProductID.ToString());
                        _db.QueryParameters.Add("ChangeAction", "Delete");
                        DataTable dtRtn = _db.executeSP("[GUI].[updateProductChangeAction]", true).Result;
                        NoRows = dtRtn.Rows[0].Field<int>("RowsUpdated");

                        //Mesh Remove
                        //sql = "Update Config.Products SET ChangeAction = 'Delete'" +
                        //" WHERE ProductUniqueNo = " + ProductID;
                        //NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        getProducts();

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
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            {
                //Set update type for save button, and open input panel
                UpdateType = "Delete";
                this.pnlProductDetails.Visible = true;
                this.btnSave.Text = "Delete";

                DataTable dtCurrentProduct = await getProductById(Convert.ToInt32(dgvAllProducts.CurrentRow.Cells[0].Value));

                //Mesh Remove
                //sql = "SELECT * FROM Config.Products WHERE ProductUniqueNo = " + ProductID;
                //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

                tbCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
                tbDetails.Text = dtCurrentProduct.Rows[0]["CustomerDetails"].ToString();
                tbGMID.Text = dtCurrentProduct.Rows[0]["GMID"].ToString();
                tbProdCode.Text = dtCurrentProduct.Rows[0]["ProductCode"].ToString();
                tbProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
                tbDefaultCartons.Text = dtCurrentProduct.Rows[0]["DefaultTotalNoOfCartons"].ToString();
                tbCartsPerPallet.Text = dtCurrentProduct.Rows[0]["DefaultCartonsPerPallet"].ToString();
                tbInnersPerCart.Text = dtCurrentProduct.Rows[0]["DefaultInnerPackPerCarton"].ToString();
                tbInnerWeight.Text = dtCurrentProduct.Rows[0]["InnerPackWeightOrVolume"].ToString();
                cboInnerUnit.Text = dtCurrentProduct.Rows[0]["UnitsOfMeasure"].ToString();
                tbInnerPackStyle.Text = dtCurrentProduct.Rows[0]["PH2_InnerPackStylePackStyle"].ToString();
                tbGTIN.Text = dtCurrentProduct.Rows[0]["GTIN"].ToString();
                tbInnerGTIN.Text = dtCurrentProduct.Rows[0]["InnerGTIN"].ToString();
                tbCompanyCode.Text = dtCurrentProduct.Rows[0]["SsccCompanyCode"].ToString();
                tbClientCode.Text = dtCurrentProduct.Rows[0]["SsccProductionLineCustomerCode"].ToString();
                tbNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();

                // disable text fields
                tbCustomer.Enabled = false;
                tbDetails.Enabled = false;
                tbGMID.Enabled = false;
                tbProdCode.Enabled = false;
                tbProdName.Enabled = false;
                tbDefaultCartons.Enabled = false;
                tbCartsPerPallet.Enabled = false;
                tbInnersPerCart.Enabled = false;
                tbInnerWeight.Enabled = false;
                cboInnerUnit.Enabled = false;
                tbInnerPackStyle.Enabled = false; ;
                tbGTIN.Enabled = false;
                tbInnerGTIN.Enabled = false;
                tbCompanyCode.Enabled = false;
                tbClientCode.Enabled = false;
                tbNotes.Enabled = false;
            }
        }
        private void btnCreateSalesOrder_Click(object sender, EventArgs e)
        {
            if (dgvAllProducts.CurrentRow != null)
            {
                ProductID = Convert.ToInt32(Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductUniqueNo"));
                //ProductID = Convert.ToInt32(dgvAllProducts.CurrentRow.Cells[0].Value);

                // set batch ID globals and open palletBatch form
                frmPallet fPallet = new frmPallet(_exwoldConfigSettings, _db);
                fPallet.CreateBatchFlag = "Create";
                fPallet.CreateBatchID = Convert.ToString(ProductID);
                fPallet.ShowDialog();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.pnlProductDetails.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getProducts();
        }

        private void dgvAllProducts_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedOrder();
        }
        private void ChangeSelectedOrder()
        {
            if (dgvAllProducts.CurrentRow == null)
            {
                btnCreateSalesOrder.Text = _cstbtnSalesOrderText;
                btnCreateSalesOrder.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnCreateSalesOrder.Text = $"{_cstbtnSalesOrderText} for\n{Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductCode").ToString()}";
                btnCreateSalesOrder.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

    }
}
