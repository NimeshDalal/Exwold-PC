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
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop
{
    public partial class Product : Form
    {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db              = null;
        private ExwoldConfigSettings _exwoldConfigSettings  = null;

        // Define Class variables
        private const string _cstbtnSalesOrderText          = "Create Sales Order";
        private const string _cstDateFmt                    = "yyyy-MMM-dd HH:mm:ss";
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
        public Product(ExwoldConfigSettings ExwoldConfigSettings, DataInterface.execFunction database)
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
            tbLotNumber.MaxLength = 20;

        }
        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlProductDetails.Visible = false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getProducts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //enable input panel and populate from selected row in datagrid. Set update type for save button
            UpdateType = "Edit";
            this.pnlProductDetails.Visible = true;
            this.btnSave.Text = "Update";

            if (dgvAllProducts.CurrentRow != null)
            {
                copyDGVProductToTextBoxes();
            }
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
                copyDGVProductToTextBoxes();
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
                foreach(DataRow row in dtAllProducts.Rows)
                {
                    Console.WriteLine($"{row["DateOfmanufacture"]}");
                }
                

                Helper.dgvColumnVisible(dgvAllProducts, "ProductUniqueNo", false);
                Helper.dgvColumnVisible(dgvAllProducts, "Plant", false);
                Helper.dgvColumnVisible(dgvAllProducts, "ChangeUser", false);
                Helper.dgvColumnVisible(dgvAllProducts, "ChangeDTUTC", false);
                Helper.dgvColumnVisible(dgvAllProducts, "ChangeDTLocal", false);
                Helper.dgvColumnVisible(dgvAllProducts, "ChangeSqlUser", false);
                Helper.dgvColumnVisible(dgvAllProducts, "ChangeUId", false);
                Helper.dgvColumnVisible(dgvAllProducts, "ChangeAction", false);
                Helper.dgvColumnVisible(dgvAllProducts, "DateOfmanufacture", false);

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
        private void copyDGVProductToTextBoxes()
        {
            try
            {
                ProductID = int.Parse(Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductUniqueNo").ToString());
                tbCustomer.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "Customer").ToString();
                tbDetails.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "CustomerDetails").ToString();
                tbGMID.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "GMID").ToString();
                tbLotNumber.Text = Helper.dgvGetCurrentRowColumn(dgvAllProducts, "LotNumber").ToString();
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
                dtpDateOfManufacture.Value = DateTime.Parse(Helper.dgvGetCurrentRowColumn(dgvAllProducts, "DoMDateOnly"));
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Error, Logging.ThisMethod(), ex.Message);
            }
            try
            {
                DateTime dt = getDate(Helper.dgvGetCurrentRowColumn(dgvAllProducts, "DoMDateOnly"));
                dtpDateOfManufacture.Value = dt;
                
            }
            catch { }
        }

        private DateTime getDate(dynamic testDate)
        {
            DateTime dt;
            if (testDate is System.DBNull || string.IsNullOrEmpty(testDate.ToString()))
            {
                dt = DateTime.Now;
            }
            else
            {
                try
                {
                    DateTime.TryParse(testDate, out dt);
                }
                catch
                {
                    dt = DateTime.Now;
                }
            }
            return dt;
        }

        private void enableTextFields(bool status)
        {
            // disable text fields
            tbCustomer.Enabled = status;
            tbDetails.Enabled = status;
            tbGMID.Enabled = status;
            tbLotNumber.Enabled = status;
            tbProdCode.Enabled = status;
            tbProdName.Enabled = status;
            tbDefaultCartons.Enabled = status;
            tbCartsPerPallet.Enabled = status;
            tbInnersPerCart.Enabled = status;
            tbInnerWeight.Enabled = status;
            cboInnerUnit.Enabled = status;
            tbInnerPackStyle.Enabled = status;
            tbGTIN.Enabled = status;
            tbInnerGTIN.Enabled = status;
            dtpDateOfManufacture.Enabled = status;
            dtpDateOfManufacture.Enabled = status;
            tbCompanyCode.Enabled = status;
            tbClientCode.Enabled = status;
            tbNotes.Enabled = status;
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
            if (await chk.ValidateInput(tbLotNumber.Text, "Lot Number", "", 20))
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
                        _db.QueryParameters.Add("DateOfManufacture", dtpDateOfManufacture.Value.ToString(_cstDateFmt));

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
                        _db.QueryParameters.Add("LotNo", tbLotNumber.Text);
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
                        _db.QueryParameters.Add("DateOfManufacture", dtpDateOfManufacture.Value.ToString(_cstDateFmt));

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
                    DialogResult dialogResult = MessageBox.Show("This will permanently delete the selected product.", "Are you sure?", 
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        //delete record
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("ProductId", ProductID.ToString());
                        _db.QueryParameters.Add("ChangeAction", "Delete");
                        DataTable dtRtn = await _db.executeSP("[GUI].[updateProductChangeAction]", true);
                        int.TryParse(dtRtn.Rows[0]["RowsUpdated"].ToString(), out NoRows);

                        getProducts();

                        switch (NoRows)
                        {
                            case 1:
                                {
                                    MessageBox.Show("Product Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                //Set update type for save button, and open input panel
                UpdateType = "Delete";
                this.pnlProductDetails.Visible = true;
                this.btnSave.Text = "Delete";
                MessageBox.Show("This product has now been set for deletion\nPlease select the 'Delete' button to confirm it's removal",
                    "Deletion Flag Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                copyDGVProductToTextBoxes();
                enableTextFields(false);
            }
        }
        private void btnCreateSalesOrder_Click(object sender, EventArgs e)
        {
            if (dgvAllProducts.CurrentRow != null)
            {
                ProductID = Convert.ToInt32(Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductUniqueNo"));
                //ProductID = Convert.ToInt32(dgvAllProducts.CurrentRow.Cells[0].Value);

                // set batch ID globals and open palletBatch form
                frmSalesOrders fSalesOrder = new frmSalesOrders(_exwoldConfigSettings, _db);
                fSalesOrder.CreateBatchFlag = "Create";
                fSalesOrder.CreateBatchID = Convert.ToString(ProductID);
                fSalesOrder.ShowDialog();
                this.Close();
            }
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
                btnCreateSalesOrder.Text = $"{_cstbtnSalesOrderText} for {Helper.dgvGetCurrentRowColumn(dgvAllProducts, "ProductCode").ToString()}";
                btnCreateSalesOrder.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dgvAllProducts_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvAllProducts.Columns.Count > 2)
            {
                dgvAllProducts.Columns[1].Frozen = true;
            }
        }
    }
}
