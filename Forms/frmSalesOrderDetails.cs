/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmPallet.cs
 * Description: Provides an interface to :
 *              1)  Get all Pallet Batch data and display to user
 *              2)  Give the user an option to Create edit and delete pallet batches
 *              3)  Give the user an option to change the status of a pallet batch
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
    public partial class frmSalesOrderDetails : Form
    {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;

        public string CreateBatchFlag;
        public string CreateBatchID;
        string UpdateType;
        string DoAdd;
        int BatchID;
        int ProductID;
        int NoRows;
        int status;
        #endregion

        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion
        public frmSalesOrderDetails(ExwoldConfigSettings ExwoldConfigSettings, DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
            _exwoldConfigSettings = ExwoldConfigSettings;
        }
        private async void PalletDetailsForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
#if DEBUG
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif
            

            // Populated the combo boxes
            getProductionLines(_exwoldConfigSettings.PlantID);
            getOrderStatus();
            
            //do this if opened from Products page ***********UPDATE**************
            switch (CreateBatchFlag)
            {
                case "Create":  //Called from the products form
                    {
                        ProductID = int.Parse(CreateBatchID);
                        btnAdd.PerformClick();
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Pallet Form Loaded from Create Pallet Batch Button");
                        break;
                    }
                case "Edit":    // Called from the Batch details form
                    {
                        BatchID = int.Parse(CreateBatchID);
                        btnEdit.PerformClick();
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Pallet Form Loaded from Edit Pallet Batch Button");
                        break;
                    }
                default:
                    {
                        getIncompleteOrders();
                        break;
                    }
            }
        }
        #region Button Event handlers
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //Set update type for save button, and open input panel
            switch (CreateBatchFlag)
            {
                case "Create":  //means dialogue has been opened from products page, continue
                    {
                        UpdateType = "Add";
                        this.pnlTextBoxes.Visible = true;
                        this.buttonEnableStatus.Visible = false;
                        btnSave.Text = "Save";

                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("ProductId", ProductID.ToString());
                        //Get the data
                        DataTable dtCurrentProduct = await _db.executeSP("[GUI].[getProductById]", true);
                        dgvOrders.DataSource = dtCurrentProduct;
                        //Mesh remove
                        //sql = "SELECT * FROM Config.Products WHERE ProductUniqueNo = " + ProductID;
                        //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

                        tbCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
                        tbDetails.Text = dtCurrentProduct.Rows[0]["CustomerDetails"].ToString();
                        tbPlant.Text = dtCurrentProduct.Rows[0]["Plant"].ToString();

                        tbGMID.Text = dtCurrentProduct.Rows[0]["GMID"].ToString();
                        tbProdCode.Text = dtCurrentProduct.Rows[0]["ProductCode"].ToString();
                        tbProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
                        tbTotalCartons.Text = dtCurrentProduct.Rows[0]["DefaultTotalNoOfCartons"].ToString();
                        tbCartonsPerPallet.Text = dtCurrentProduct.Rows[0]["DefaultCartonsPerPallet"].ToString();
                        tbInnersPerCart.Text = dtCurrentProduct.Rows[0]["DefaultInnerPackPerCarton"].ToString();
                        tbInnerWeight.Text = dtCurrentProduct.Rows[0]["InnerPackWeightOrVolume"].ToString();
                        cboInnerUnit.Text = dtCurrentProduct.Rows[0]["UnitsOfMeasure"].ToString();
                        tbInnerPackStyle.Text = dtCurrentProduct.Rows[0]["PH2_InnerPackStylePackStyle"].ToString();
                        tbGTIN.Text = dtCurrentProduct.Rows[0]["GTIN"].ToString();
                        tbInnerGTIN.Text = dtCurrentProduct.Rows[0]["InnerGTIN"].ToString();
                        tbCompanyCode.Text = dtCurrentProduct.Rows[0]["SsccCompanyCode"].ToString();
                        tbClientCode.Text = dtCurrentProduct.Rows[0]["SsccProductionLineCustomerCode"].ToString();
                        tbNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();
                        tbDateOfManufacture.Text = dtCurrentProduct.Rows[0]["DateOfManufacture"].ToString();

                        cboStatus.Visible = false;
                        lblStatus.Visible = false;
                        CreateBatchFlag = "Reset";
                        break;
                    }
                default:  //no product has been selected, send user to products page
                    {
                        this.Close();
                        frmProduct fProduct = new frmProduct(_exwoldConfigSettings, _db);
                        fProduct.DB = _db;
                        fProduct.ShowDialog();
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Open Product Form from Pallet Form Add button");
                        break;
                    }
            }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            //enable input panel and populate from selected row in datagrid. Set update type for save button
            if (CreateBatchFlag != "Edit")
            {
                if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.Cells[1] != null)
                {
                    BatchID = int.Parse(Helper.dgvGetCurrentRowColumn(dgvOrders, "PalletBatchUniqueNo").ToString());
                }
                else
                {
                    CreateBatchFlag = "";
                    MessageBox.Show("No Sales Order Selected");
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Attempt to edit blank Sales Order" + BatchID);
                    return;
                }
            }
            UpdateType = "Edit";
            btnSave.Text = "Update";
            pnlTextBoxes.Visible = true;
            CreateBatchFlag = "";

            DataTable dtCurrentProduct = await GetPalletBatch(BatchID);
            //dgvOrders.DataSource = dtCurrentProduct;

            tbCustomer.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "Customer").ToString();
            tbProdCode.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "ProductCode").ToString();
            tbProdName.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "ProductName").ToString();
            tbTotalCartons.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "TotalNoOfCartons").ToString();
            tbCartonsPerPallet.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "CartonsPerPallet").ToString();
            tbInnersPerCart.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "InnerPacksPerCarton").ToString();
            tbInnerWeight.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "InnerPackWeightOrVolume").ToString();
            TextBoxPalletBatchNo.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "PalletBatchNo").ToString();
            tbNotes.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "AdditionalInfo").ToString();

            cboInnerUnit.Text = Helper.dgvGetCurrentRowColumn(dgvOrders, "UnitsOfMeasure").ToString();
            int idx;
            try
            {
                int.TryParse(Helper.dgvGetCurrentRowColumn(dgvOrders, "ProductionLineNo").ToString(), out idx);
                cboProdLine.SelectedValue = idx;
            }
            catch
            {
                cboProdLine.SelectedValue = -1;
            }
            try
            {
                int.TryParse(Helper.dgvGetCurrentRowColumn(dgvOrders, "Status").ToString(), out idx);
                cboStatus.SelectedValue = idx;
            }
            catch
            {
                cboStatus.SelectedValue = -1;
            }
            string str = Helper.dgvGetCurrentRowColumn(dgvOrders, "UnitsOfMeasure").ToString().Trim();
            cboInnerUnit.SelectedIndex = cboInnerUnit.FindString(Helper.dgvGetCurrentRowColumn(dgvOrders, "UnitsOfMeasure").ToString().Trim());



            //DataTable dtCurrentProduct = await GetPalletBatch(BatchID);

            ////Mesh Remove
            ////sql = "SELECT * FROM Data.PalletBatch WHERE PalletBatchUniqueNo = " + BatchID;
            ////DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

            //tbCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
            //tbProdCode.Text = dtCurrentProduct.Rows[0]["ProductCode"].ToString();
            //tbProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
            //tbTotalCartons.Text = dtCurrentProduct.Rows[0]["TotalNoOfCartons"].ToString();
            //tbCartonsPerPallet.Text = dtCurrentProduct.Rows[0]["CartonsPerPallet"].ToString();
            //tbInnersPerCart.Text = dtCurrentProduct.Rows[0]["InnerPacksPerCarton"].ToString();
            //tbInnerWeight.Text = dtCurrentProduct.Rows[0]["InnerPackWeightOrVolume"].ToString();
            //cboInnerUnit.Text = dtCurrentProduct.Rows[0]["UnitsOfMeasure"].ToString();
            //TextBoxPalletBatchNo.Text = dtCurrentProduct.Rows[0]["PalletBatchNo"].ToString();
            //cboProdLine.Text = dtCurrentProduct.Rows[0]["ProductionLineNo"].ToString();

            //tbNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();
            //cboStatus.SelectedValue = dtCurrentProduct.Rows[0]["Status"].ToString();

            //Warn user if batch is In-Progress
            if (Convert.ToString(cboStatus.SelectedValue) == "1")
            {
                MessageBox.Show("WARNING - Pallet Batch is In-Progress" + Environment.NewLine + "" + Environment.NewLine + "You cannot edit this batch unless the status is changed.");
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "In-Progress Pallet Batch opened to edit " + BatchID);

                cboStatus.Enabled = false;
                EnableTextBoxes(false);

                //Mesh Remove
                //cboStatus.Enabled = false;
                //tbCustomer.Enabled = false;
                //tbProdCode.Enabled = false;
                //tbProdName.Enabled = false;
                //tbTotalCartons.Enabled = false;
                //tbCartonsPerPallet.Enabled = false;
                //tbInnersPerCart.Enabled = false;
                //tbInnerWeight.Enabled = false;
                //cboInnerUnit.Enabled = false;
                //TextBoxPalletBatchNo.Enabled = false;
                //cboProdLine.Enabled = false;
                //tbNotes.Enabled = false;
            }
            else
            {
                cboStatus.Enabled = false;
                EnableTextBoxes(true);
                //Mesh Remove
                //tbCustomer.Enabled = true;
                //tbProdCode.Enabled = true;
                //tbProdName.Enabled = true;
                //tbTotalCartons.Enabled = true;
                //tbCartonsPerPallet.Enabled = true;
                //tbInnersPerCart.Enabled = true;
                //tbInnerWeight.Enabled = true;
                //cboInnerUnit.Enabled = true;
                //TextBoxPalletBatchNo.Enabled = true;
                //cboProdLine.Enabled = true;
                //tbNotes.Enabled = true;
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            {
                //Set update type for save button, and open input panel
                UpdateType = "Delete";
                this.pnlTextBoxes.Visible = true;
                this.btnSave.Text = "Delete";
                BatchID = int.Parse(Helper.dgvGetCurrentRowColumn(dgvOrders, "PalletBatchUniqueNo").ToString());
                //Convert.ToInt32(dgvOrders.CurrentRow.Cells[1].Value);

                DataTable dtCurrentProduct = await GetPalletBatch(BatchID);
                //Mesh Remove
                //sql = "SELECT * FROM Data.PalletBatch WHERE PalletBatchUniqueNo = " + BatchID;
                //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);


                tbCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
                tbProdCode.Text = dtCurrentProduct.Rows[0]["ProductCode"].ToString();
                tbProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
                tbTotalCartons.Text = dtCurrentProduct.Rows[0]["TotalNoOfCartons"].ToString();
                tbCartonsPerPallet.Text = dtCurrentProduct.Rows[0]["CartonsPerPallet"].ToString();
                tbInnersPerCart.Text = dtCurrentProduct.Rows[0]["InnerPacksPerCarton"].ToString();
                tbInnerWeight.Text = dtCurrentProduct.Rows[0]["InnerPackWeightOrVolume"].ToString();
                cboInnerUnit.Text = dtCurrentProduct.Rows[0]["UnitsOfMeasure"].ToString();
                TextBoxPalletBatchNo.Text = dtCurrentProduct.Rows[0]["PalletBatchNo"].ToString();
                cboProdLine.Text = dtCurrentProduct.Rows[0]["ProductionLineNo"].ToString();
                tbNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();
                cboStatus.SelectedValue = dtCurrentProduct.Rows[0]["Status"].ToString();

                status = Convert.ToInt16(cboStatus.SelectedValue);

                cboStatus.Enabled = false;
                EnableTextBoxes(false);

                //Mesh Remove
                //tbCustomer.Enabled = false;
                //tbProdCode.Enabled = false;
                //tbProdName.Enabled = false;
                //tbTotalCartons.Enabled = false;
                //tbCartonsPerPallet.Enabled = false;
                //tbInnersPerCart.Enabled = false;
                //tbInnerWeight.Enabled = false;
                //cboInnerUnit.Enabled = false;
                //TextBoxPalletBatchNo.Enabled = false;
                //cboProdLine.Enabled = false;
                //tbNotes.Enabled = false;
                //buttonEnableStatus.Visible = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            #region Do data validation
            clsValidation chk = new clsValidation(_db);
            DoAdd = "Yes";
            if (await chk.ValidateInput(tbCustomer.Text, "Customer", "", 50, 1))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbDetails.Text, "Details", "", 50 ))
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
            if (await chk.ValidateInput(tbTotalCartons.Text, "Total Number of Cartons", "Int",8,1, "No"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbCartonsPerPallet.Text, "Cartons per Pallet", "Int", 8,1, "No"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbInnersPerCart.Text, "Default Number of Inners", "Int", 7,1, "No"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(tbInnerWeight.Text, "Inner Pack Weight//Volume", "Numeric",7,1, "No"))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(TextBoxPalletBatchNo.Text, "Sales Order", "", 15, 1))
            {
                DoAdd = "no";
            }
            if (await chk.ValidateInput(cboProdLine.Text, "Production Line", "ProdLine"))
            {
                DoAdd = "no";
            }
            #endregion

            //Run Insert or update depending on which button opened the inpuyt panel, copy data into SQL table
            switch (UpdateType)
            {
                case "Edit":

                    this.buttonEnableStatus.Visible = true;
                    if (await chk.ValidateInput(TextBoxPalletBatchNo.Text, "Sales Order", "SalesOrderEdit"))
                    {
                        DoAdd = "no";
                    }
                    if (DoAdd != "no")
                    {
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("@BatchId", BatchID.ToString());
                        _db.QueryParameters.Add("@ProductionLineNo", cboProdLine.Text);
                        _db.QueryParameters.Add("@PalletBatchNo", TextBoxPalletBatchNo.Text);
                        _db.QueryParameters.Add("@TotalNoOfCartons", tbTotalCartons.Text);
                        _db.QueryParameters.Add("@CartonsPerPallet", tbCartonsPerPallet.Text);
                        _db.QueryParameters.Add("@InnerPacksPerCarton", tbInnersPerCart.Text);
                        _db.QueryParameters.Add("@InnerPackWeightOrVolume", tbInnerWeight.Text);
                        _db.QueryParameters.Add("@UnitsOfMeasure", cboInnerUnit.Text);
                        _db.QueryParameters.Add("@Status", cboStatus.SelectedValue.ToString());
                        _db.QueryParameters.Add("@AdditionalInfo", tbNotes.Text);
                        _db.QueryParameters.Add("@ChangeAction", "Update");

                        //Get the data
                        DataTable dtPalletBatch = await _db.executeSP("[GUI].[updatePalletBatch]", true);

                        //Returned the number of rows updated
                        int.TryParse(dtPalletBatch.Rows[0].ItemArray[0].ToString(), out NoRows);



                        //Mesh Remove
                        //sql = "UPDATE Data.PalletBatch SET ProductionLineNo = '" + cboProdLine.Text + "'," +"PalletBatchNo = '" + TextBoxPalletBatchNo.Text + "'," +
                        //             "TotalNoOfCartons = '" + tbTotalCartons.Text + "', CartonsPerPallet = '" + tbCartonsPerPallet.Text + "', InnerPacksPerCarton = '" + tbInnersPerCart.Text + "', InnerPackWeightOrVolume = '" + tbInnerWeight.Text + "'," +
                        //             "UnitsOfMeasure = '" + cboInnerUnit.Text + "', Status = '" + cboStatus.SelectedValue + "', AdditionalInfo = '" + tbNotes.Text + "', ChangeAction = 'Update'" +
                        //             " WHERE PalletBatchUniqueNo = " + BatchID;

                        //NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        getIncompleteOrders();
                        this.pnlTextBoxes.Visible = false;

                        //error checking - remove or update for logging
                        switch (NoRows)
                        {
                            case 1:
                                {
                                    MessageBox.Show("Sales Order updated.");
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Pallet Batch Edited " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("Edit Failed - Please check data and try again.");
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Pallet Batch Edit Failed " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Edit Failed - Unknown Error. Please check data and try again.");
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Edit Failed - Unknown Error. Pallet Batch Edit returned too many rows " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                        }
                    }
                    break;


                case "Add":                   
                    if (await chk.ValidateInput(TextBoxPalletBatchNo.Text, "Sales Order", "SalesOrderAdd"))
                    {
                        DoAdd = "no";
                    }
                    if (DoAdd != "no")
                    {
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("@PalletBatchNo", TextBoxPalletBatchNo.Text);
                        _db.QueryParameters.Add("@ProdLineNo", cboProdLine.Text);
                        _db.QueryParameters.Add("@ProductID", ProductID.ToString());
                        _db.QueryParameters.Add("@ProdCode", tbProdCode.Text);
                        _db.QueryParameters.Add("@ProdName", tbProdName.Text);
                        _db.QueryParameters.Add("@Customer", tbCustomer.Text);
                        _db.QueryParameters.Add("@CustDetails", tbDetails.Text);
                        _db.QueryParameters.Add("@GMID", tbGMID.Text);
                        _db.QueryParameters.Add("@TotalCartons", tbTotalCartons.Text);
                        _db.QueryParameters.Add("@CartonsPerPallet", tbCartonsPerPallet.Text);
                        _db.QueryParameters.Add("@InnersPerCarton", tbInnersPerCart.Text);
                        _db.QueryParameters.Add("@InnerWeight", tbInnerWeight.Text);
                        _db.QueryParameters.Add("@UoM", cboInnerUnit.Text);
                        _db.QueryParameters.Add("@GTIN", tbGTIN.Text);
                        _db.QueryParameters.Add("@SsccCompanyCode", tbCompanyCode.Text);
                        _db.QueryParameters.Add("@SccCustCode", tbClientCode.Text);
                        _db.QueryParameters.Add("@AddInfo", tbNotes.Text);
                        _db.QueryParameters.Add("@Status", "0");
                        _db.QueryParameters.Add("@ChangeAction", "Insert");

                        DataTable dtResult = await _db.executeSP("[GUI].[createPalletBatch]", true);
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
                        //string values = "'" + TextBoxPalletBatchNo.Text + "', '" + cboProdLine.Text + "', '" + ProductID + "', '" + 
                        //    tbProdCode.Text + "', '" + tbProdName.Text + "', '" + tbCustomer.Text + "', '" + 
                        //    tbDetails.Text + "', '" + tbGMID.Text + "', '" + tbTotalCartons.Text + "', '" +
                        //        tbCartonsPerPallet.Text + "', '" + tbInnersPerCart.Text + "', '" + tbInnerWeight.Text + "', '" + 
                        //        cboInnerUnit.Text + "', '" + tbGTIN.Text + "', '" + tbCompanyCode.Text + "', '" +
                        //            tbClientCode.Text + "', '" + tbNotes.Text + "', 0, " +
                        //            "'Insert'";
                        //sql = "INSERT INTO Data.PalletBatch (PalletBatchNo, ProductionLineNo, ProductUniqueNo, ProductCode, ProductName, Customer, CustomerDetails, GMID," +
                        //             "TotalNoOfCartons, CartonsPerPallet, InnerPacksPerCarton, InnerPackWeightOrVolume," +
                        //             "UnitsOfMeasure, GTIN, SsccCompanyCode, SsccProductionLineCustomerCode, AdditionalInfo, Status, ChangeAction) " +
                        //             "VALUES (" + values + ")";

                        //NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        getIncompleteOrders();
                        this.pnlTextBoxes.Visible = false;
                        CreateBatchFlag = "False";

                        switch (NoRows)
                        {
                            case 1:
                                {
                                    MessageBox.Show("New Sales Order created");
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Sales Order Added " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("Failed to add Sales Order - Please check data and try again.");
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Sales Order Add Failed " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Failed to add Sales Order - Unknown Error, Please check data and try again.");
                                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Sales Order Add Failed - too many rows returned " + TextBoxPalletBatchNo.Text);
                                    break;
                                }
                        }
                    }
                    break;

                case "Delete":
                   
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "This will permanently delete the selected Sales Order.", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    { 
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("@PalletBatchUId", BatchID.ToString());
                        DataTable dtResult = await _db.executeSP("deletePalletBatch", true);

                        int.TryParse(dtResult.Rows[0].ItemArray[0].ToString(), out NoRows);

                        //Mesh Remove
                        ////delete record
                        //sql = "UPDATE data.PalletBatch SET ChangeAction = 'Delete', status = 5 " +
                        //        " WHERE PalletBatchUniqueNo = " + BatchID;

                        //NoRows = Program.ExwoldDb.ExecuteNonQuery(sql);

                        // Re-Populate Datagrid                        
                        getIncompleteOrders();
                        this.pnlTextBoxes.Visible = false;

                        // logging 
                        switch (NoRows)
                        {
                            case 1:
                                {
                                MessageBox.Show("Sales Order deleted.");
                                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Sales Order Deleted " + TextBoxPalletBatchNo.Text);
                                break;
                            }

                            default:
                                {
                                MessageBox.Show("Failed to Delete Sales Order - Please check data and try again.");
                                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Pallet Batch Delete Failed " + TextBoxPalletBatchNo.Text);
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
        /// <summary>
        /// Opens Pallet details form for highlighted batch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            BatchID = int.Parse(Helper.dgvGetCurrentRowColumn(dgvOrders, "PalletBatchUniqueNo").ToString());

            frmBatchDetails fBatchDetail = new frmBatchDetails(_exwoldConfigSettings, _db);
            fBatchDetail.ViewBatch = true;
            fBatchDetail.PalletBatchId = BatchID;
            fBatchDetail.ShowDialog(); 
        }
        /// <summary>
        /// enables status field to be updated - warn user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnableStatus_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("WARNING - Pallet Batch status should normally be controlled" + Environment.NewLine + "via the Hand Held Scanner." + Environment.NewLine + "It should only be changed from this application to resolve problems." + Environment.NewLine + Environment.NewLine + "Are you sure?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //enable status change dialogue
                cboStatus.Enabled = true;
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "User chose to update batch status " + dgvOrders.CurrentRow.Cells[1].Value);
            }

            else if (dialogResult == DialogResult.No)
            {
                //don't enable status
            }
        }                
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.pnlTextBoxes.Visible = false;
            cboStatus.Enabled = true;
            cboStatus.Visible = true;
            lblStatus.Visible = true;
            this.buttonEnableStatus.Visible = true;
            CreateBatchFlag = "Reset";
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "User cancelled batch edit " + dgvOrders.CurrentRow.Cells[1].Value);
        }
        #endregion

        #region Local helpers methods
        private async void getIncompleteOrders()
        {
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("Plant", _exwoldConfigSettings.PlantID.ToString());
            //Get the data
            DataTable dt = await _db.executeSP("[GUI].[getIncompleteOrders]", true);
            dgvOrders.DataSource = dt;
            Helper.dgvColumnVisible(dgvOrders, "PalletBatchUniqueNo", false);
            Helper.dgvColumnVisible(dgvOrders, "ProductUniqueNo", false);
            Helper.dgvColumnVisible(dgvOrders, "DateOfManufacture", false);
            Helper.dgvColumnVisible(dgvOrders, "OuterLabelsRqd", false);
            Helper.dgvColumnVisible(dgvOrders, "InnerLabelsRqd", false);
            Helper.dgvColumnVisible(dgvOrders, "OuterLabelsPrinted", false);
            Helper.dgvColumnVisible(dgvOrders, "InnerLabelsPrinted", false);
            Helper.dgvColumnVisible(dgvOrders, "ChangeUser", false);
            Helper.dgvColumnVisible(dgvOrders, "ChangeAction", false);
            Helper.dgvColumnVisible(dgvOrders, "ChangeDTUTC", false);
            Helper.dgvColumnVisible(dgvOrders, "ChangeDTLocal", false);
            Helper.dgvColumnVisible(dgvOrders, "ChangeSqlUser", false);
            Helper.dgvColumnVisible(dgvOrders, "ChangeUID", false);

            //return dt;
            //Mesh Remove
            //string sql = "SELECT PalletBatchNo AS SalesOrder, * FROM data.PalletBatch WHERE status <> 4 and status <> 5 and ChangeAction <> 'Delete'";
            //DataTable dt = Program.ExwoldDb.ExecuteQuery(sql);
        }
        private async void getProductionLines(int Plant)
        {
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("Plant", _exwoldConfigSettings.PlantID.ToString());
            //Get the data
            DataTable dt = await _db.executeSP("[GUI].[getProductionLines]", true);

            cboProdLine.DisplayMember = "Name";
            cboProdLine.ValueMember = "UId";
            cboProdLine.DataSource = dt;
        }
        private async void getOrderStatus()
        {
            _db.QueryParameters.Clear();
            //Get the data
            DataTable dt = await _db.executeSP("[GUI].[getOrderStatus]");

            cboStatus.DisplayMember = "Status";
            cboStatus.ValueMember = "StatusNo";
            cboStatus.DataSource = dt;
        }
        private void EnableTextBoxes(bool enabled)
        {
            tbCustomer.Enabled = enabled;
            tbProdCode.Enabled = enabled;
            tbProdName.Enabled = enabled;
            tbTotalCartons.Enabled = enabled;
            tbCartonsPerPallet.Enabled = enabled;
            tbInnersPerCart.Enabled = enabled;
            tbInnerWeight.Enabled = enabled;
            cboInnerUnit.Enabled = enabled;
            TextBoxPalletBatchNo.Enabled = enabled;
            cboProdLine.Enabled = enabled;
            tbNotes.Enabled = enabled;
            buttonEnableStatus.Visible = enabled;
        }
        private async Task<DataTable> GetPalletBatch(int BatchId)
        {
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("@PalletBatchId", BatchId.ToString());
            //Get the data
            return await _db.executeSP("[GUI].[getPalletBatchById]", true);

            //Mesh Remove
            //sql = "SELECT * FROM Data.PalletBatch WHERE PalletBatchUniqueNo = " + BatchID;
            //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
        }
        #endregion
    }
}

