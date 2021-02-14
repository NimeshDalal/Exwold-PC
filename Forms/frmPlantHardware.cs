/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmPlantHardware.cs
 * Description: Displays the hardware configuration from the configuration file,
 *              and pings the ipaddress and reports the status
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              <Description of the change>
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop
{
    public partial class frmPlantHardware : Form
    {
        #region private variables
        private readonly DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;
        private readonly Dictionary<string, Control> _ipadresses = new Dictionary<string, Control>();
        private List<StandAloneScanner> _scanners = null;
        private bool _discardChanges = false; 
        private bool _reInitilaiseScanners = false;

        #endregion

        internal bool ReInitialiseScanners { get { return _reInitilaiseScanners; } }
        internal bool DiscardChanges { get { return _discardChanges; } }
        internal ExwoldConfigSettings ExwoldConfigSettings
        { 
            get { return _exwoldConfigSettings; }
            set { _exwoldConfigSettings = value; }
        }
        internal frmPlantHardware(DataInterface.execFunction database, ExwoldConfigSettings ConfigSettings, List<StandAloneScanner> Scanners)
        {
            InitializeComponent();
            _db = database;
            _exwoldConfigSettings = ConfigSettings;
            _scanners = Scanners;

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


        private void frmPlantHardware_Load(object sender, EventArgs e)
        {
            BuildHarwareItems();
            PingTheIPAddresses();
        }

        /// <summary>
        /// Dynamically add the text boxes to the groups
        /// The design time texts are required for placeholder, and have VISIBLE = False
        /// </summary>
        private void BuildHarwareItems()
        {
            #region Populate the comboboxes
            //Load the ProductionLine cbo with data
            cboPLPLineX.Items.Clear();
            cboSAScnLineX.Items.Clear();
            txtHHScn_LineX.Items.Clear();
            foreach (ProductionLineConfigElement line in _exwoldConfigSettings.ProductionLines)
            {
                //Console.WriteLine("{0}, {1}, {2}", line.ToString(), line.Id.ToString(), line.Name);
                cboPLPLineX.Items.Add(line);
                cboSAScnLineX.Items.Add(line);
                txtHHScn_LineX.Items.Add(line);
            }
            cboPLPLineX.ValueMember = "Id";
            cboPLPLineX.DisplayMember = "Name";
            cboPLPLineX.SelectedIndex = 0; 
            cboSAScnLineX.ValueMember = "Id";
            cboSAScnLineX.DisplayMember = "Name";
            cboSAScnLineX.SelectedIndex = 0;
            txtHHScn_LineX.ValueMember = "Id";
            txtHHScn_LineX.DisplayMember = "Name";
            txtHHScn_LineX.SelectedIndex = 0;
            #endregion
            #region Pallet Label Printers
            for (int count = 0;count < _exwoldConfigSettings.PalletLabelPrinters.Count;count++)
            {

                addControl<TextBox>(txtPLPIdX, count, _exwoldConfigSettings.PalletLabelPrinters[count].Id.ToString(), grpPalletLabelPrinters);
                addControl<TextBox>(txtPLPNameX,count, _exwoldConfigSettings.PalletLabelPrinters[count].Name.ToString(), grpPalletLabelPrinters);
                addControl<TextBox>(txtPLPIpAddrX, count, _exwoldConfigSettings.PalletLabelPrinters[count].IpAddr.ToString(), grpPalletLabelPrinters);
                
                TextBox txtStatus = addControl<TextBox>(txtPLPStatusX, count, "---", grpPalletLabelPrinters);
                _ipadresses.Add(_exwoldConfigSettings.PalletLabelPrinters[count].IpAddr.ToString(), txtStatus);

                ComboBox cbo = addPalletLabelPrinterCbo(cboPLPLineX, count, _exwoldConfigSettings.PalletLabelPrinters[count], grpPalletLabelPrinters);
            }
            #endregion
            #region Carton Label Printers
            for (int count = 0; count < _exwoldConfigSettings.OuterPackLabelPrinters.Count; count++)
            {
                addControl<TextBox>(txtOuterPckLP_IdX, count, _exwoldConfigSettings.OuterPackLabelPrinters[count].Id.ToString(), grpOuterPackLabelPrinters);
                addControl<TextBox>(txtOuterPckLP_NameX, count, _exwoldConfigSettings.OuterPackLabelPrinters[count].Name.ToString(), grpOuterPackLabelPrinters);
                addControl<TextBox>(txtOuterPckLP_IpAddrX, count, _exwoldConfigSettings.OuterPackLabelPrinters[count].IpAddr.ToString(), grpOuterPackLabelPrinters);
                TextBox txtStatus = addControl<TextBox>(txtOuterPckLP_StatusX, count, "---", grpOuterPackLabelPrinters);
                _ipadresses.Add(_exwoldConfigSettings.OuterPackLabelPrinters[count].IpAddr.ToString(), txtStatus);
            }
            #endregion
            #region Unit Label Printers
            for (int count = 0; count < _exwoldConfigSettings.InnerPackLabelPrinters.Count; count++)
            {
                addControl<TextBox>(txtInnerPckLP_IdX, count, _exwoldConfigSettings.InnerPackLabelPrinters[count].Id.ToString(), grpInnerPackLabelPrinters);
                addControl<TextBox>(txtInnerPckLP_NameX, count, _exwoldConfigSettings.InnerPackLabelPrinters[count].Name.ToString(), grpInnerPackLabelPrinters);
                addControl<TextBox>(txtInnerPckLP_IpAddrX, count, _exwoldConfigSettings.InnerPackLabelPrinters[count].IpAddr.ToString(), grpInnerPackLabelPrinters);
                TextBox txtStatus = addControl<TextBox>(txtInnerPckLP_StatusX, count, "---", grpInnerPackLabelPrinters);
                _ipadresses.Add(_exwoldConfigSettings.InnerPackLabelPrinters[count].IpAddr.ToString(), txtStatus);
            }
            #endregion
            #region Mobile Scanners
            for (int count = 0; count < _exwoldConfigSettings.HandHeldScanners.Count; count++)
            {
                addControl<TextBox>(txtHHScn_IdX, count, _exwoldConfigSettings.HandHeldScanners[count].Id.ToString(), grpHandHeldScanner);
                addControl<TextBox>(txtHHScn_NameX, count, _exwoldConfigSettings.HandHeldScanners[count].Name.ToString(), grpHandHeldScanner);
                addControl<TextBox>(txtHHScn_IpAddrX, count, _exwoldConfigSettings.HandHeldScanners[count].IpAddr.ToString(), grpHandHeldScanner);
                addControl<TextBox>(txtHHScn_PortX, count, _exwoldConfigSettings.HandHeldScanners[count].Port.ToString(), grpHandHeldScanner);
                TextBox txtStatus = addControl<TextBox>(txtHHScn_StatusX, count, "---", grpHandHeldScanner);
                _ipadresses.Add(_exwoldConfigSettings.HandHeldScanners[count].IpAddr.ToString(), txtStatus);

                ComboBox cbo = addProdLineCbo(txtHHScn_LineX, count, _exwoldConfigSettings.HandHeldScanners[count], grpHandHeldScanner);
                cbo = addConditionCbo(cboHHScn_ConditionX, count, _exwoldConfigSettings.HandHeldScanners[count], grpHandHeldScanner);
            }
            #endregion
            #region Stand-alone Scanners
            for (int count = 0; count < _exwoldConfigSettings.StandAloneScanners.Count; count++)
            {
                addControl<TextBox>(txtSAScnIdX, count, _exwoldConfigSettings.StandAloneScanners[count].Id.ToString(), grpStandAloneScanners);
                addControl<TextBox>(txtSAScnNameX, count, _exwoldConfigSettings.StandAloneScanners[count].Name.ToString(), grpStandAloneScanners);
                addControl<TextBox>(txtSAScnIpAddrX, count, _exwoldConfigSettings.StandAloneScanners[count].IpAddr.ToString(), grpStandAloneScanners);
                addControl<TextBox>(txtSAScnPortX, count, _exwoldConfigSettings.StandAloneScanners[count].Port.ToString(), grpStandAloneScanners);
                addControl<TextBox>(txtSAScnScanRateX, count, _exwoldConfigSettings.StandAloneScanners[count].ScanRate.ToString(), grpStandAloneScanners);

                TextBox txtStatus = addControl<TextBox>(txtSAScnStatusX, count, "---", grpStandAloneScanners);
                _ipadresses.Add(_exwoldConfigSettings.StandAloneScanners[count].IpAddr.ToString(), txtStatus);
                //PingAddress(_exwoldConfigSettings.StandAloneScanners[count].IpAddr.ToString(), txtStatus);

                ComboBox cbo = addProdLineCbo(cboSAScnLineX, count, _exwoldConfigSettings.StandAloneScanners[count], grpStandAloneScanners);
                cbo = addConditionCbo(cboSAScnConditionX, count, _exwoldConfigSettings.StandAloneScanners[count], grpStandAloneScanners);
            }
            #endregion
        }

        private void PingTheIPAddresses()
        {
            foreach (string key in _ipadresses.Keys)
            {
                ((TextBox)_ipadresses[key]).Text = "Please Wait...";
                PingAddress(key, (TextBox)_ipadresses[key]);
            }
        }

        /// <summary>
        /// Ping an IP Addressm and write the results to a textbox
        /// Runs asynchronously
        /// </summary>
        /// <param name="address">Address to ping</param>
        /// <param name="tb">Textbox to display the results (text and colour)</param>
        private async void PingAddress(string address, TextBox tb)
        {
            Task<System.Net.NetworkInformation.IPStatus> task = CommsHelper.PingIPAddress(address);

            System.Net.NetworkInformation.IPStatus status = await task;
            tb.Text = status.ToString();
            tb.BackColor = status == System.Net.NetworkInformation.IPStatus.Success ? Color.Green : Color.Red;
        }
        /// <summary>
        /// Creates a new Combobox, copied from the sourceCbo
        /// </summary>
        /// <param name="sourceCbo">copy the parameter from this</param>
        /// <param name="index">Used for colouring the rows</param>
        /// <param name="prodLine">the currently select line</param>
        /// <param name="container">place to put the cbo into</param>
        /// <returns></returns>
        private ComboBox genericProdLineCbo(ComboBox sourceCbo, int index, int prodLine, GroupBox container)
        {
            //Set the veritical increment step
            int verticalOffset = sourceCbo.Height;
            //Create a new combobox
            ComboBox destCbo = new ComboBox();

            //Copy the items from source to destination
            destCbo.Items.AddRange(sourceCbo.Items.Cast<ProductionLineConfigElement>().ToArray());
            destCbo.ValueMember = "Id";
            destCbo.DisplayMember = "Name";
            destCbo.Name = sourceCbo.Name + index.ToString();
            destCbo.Size = sourceCbo.Size;
            //Set the back colour of the control - For asthetics only
            destCbo.BackColor = index % 2 == 0 ? Color.AliceBlue : Color.Aqua;
            destCbo.Location = new Point(sourceCbo.Location.X, sourceCbo.Location.Y + (index * verticalOffset));
            destCbo.Visible = true;
            container.Controls.Add(destCbo);

            //Select the Production Line for the element
            foreach (ProductionLineConfigElement line in destCbo.Items)
            {
                if (line.Id == prodLine)
                {
                    destCbo.SelectedIndex = destCbo.FindStringExact(line.Name);
                }
            }

            destCbo.KeyPress += (sender, e) => { e.Handled = true; };
            return destCbo;
        }
        private ComboBox genericConditionCbo(ComboBox sourceCbo, int index, string condition, GroupBox container)
        {
            //Set the veritical increment step
            int verticalOffset = sourceCbo.Height;
            //Create a new combobox
            ComboBox destCbo = new ComboBox();

            //Copy the items from source to destination
            destCbo.Items.AddRange(sourceCbo.Items.Cast<string>().ToArray());
            destCbo.Size = sourceCbo.Size;
            //Set the back colour of the control - For asthetics only
            destCbo.BackColor = index % 2 == 0 ? Color.AliceBlue : Color.Aqua;
            destCbo.Location = new Point(sourceCbo.Location.X, sourceCbo.Location.Y + (index * verticalOffset));
            destCbo.Visible = true;
            container.Controls.Add(destCbo);

            //Select the Condition for the element
            destCbo.SelectedIndex = destCbo.FindStringExact(condition);

            destCbo.KeyPress += (sender, e) => { e.Handled = true; };
            return destCbo;
        }

        #region Custom ComboBox Events
        /// <summary>
        /// Customer event - Write the cbo value back to the element class
        /// </summary>
        /// <param name="sender">Sending object (combobox)</param>
        /// <param name="e">standard event args</param>
        /// <param name="element">The element class to write to</param>
        private void cboPalletLabelPrinter_IndexChanged(object sender, EventArgs e, PalletLabelPrinterConfigElement element)
        {
            //Get the combobox
            ComboBox cbo = (ComboBox)sender;
            int LineId = (cbo.SelectedItem as ProductionLineConfigElement).Id;
            string PlantName = (cbo.SelectedItem as ProductionLineConfigElement).Name;

            element.ProductionLine = LineId;
        }
        private void cboMobileScanner_IndexChanged(object sender, EventArgs e, HandHeldScannerConfigElement element)
        {
            //Get the combobox
            ComboBox cbo = (ComboBox)sender;
            int LineId = (cbo.SelectedItem as ProductionLineConfigElement).Id;
            string PlantName = (cbo.SelectedItem as ProductionLineConfigElement).Name;

            element.ProductionLine = LineId;
        }
        private void cboStandAloneScanner_IndexChanged(object sender, EventArgs e, StandAloneScannerConfigElement element)
        {
            //Get the combobox
            ComboBox cbo = (ComboBox)sender;
            int LineId = (cbo.SelectedItem as ProductionLineConfigElement).Id;
            string PlantName = (cbo.SelectedItem as ProductionLineConfigElement).Name;

            element.ProductionLine = LineId;
        }
        private void cboSAScnCondition_IndexChanged(object sender, EventArgs e, StandAloneScannerConfigElement element)
        {
            //Get the combobox
            ComboBox cbo = (ComboBox)sender;
            element.Condition = cbo.SelectedItem.ToString();
        }
        private void cboHHScnCondition_IndexChanged(object sender, EventArgs e, HandHeldScannerConfigElement element)
        {
            //Get the combobox
            ComboBox cbo = (ComboBox)sender;
            element.Condition = cbo.SelectedItem.ToString();
        }
        private void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
        #region Add Combobox Methods
        /// <summary>
        /// Add a combobox of for the specific type, and creates and event, so changes can be written 
        /// back to the element (class) holding the data
        /// </summary>
        /// <param name="sourceCbo">to be passed to the genericCbo method</param>
        /// <param name="index">to be passed to the genericCbo method</param>
        /// <param name="element">Used to create the specific custom event</param>
        /// <param name="container">to be passed to the genericCbo method</param>
        /// <returns></returns>

        private ComboBox addPalletLabelPrinterCbo(ComboBox sourceCbo, int index, PalletLabelPrinterConfigElement element, GroupBox container)

        {
            //Build the generic CBO stuff
            ComboBox destCbo = genericProdLineCbo(sourceCbo, index, element.ProductionLine, container);
            #region Custom Events
            destCbo.SelectedIndexChanged += delegate (object sender, EventArgs e) { cboPalletLabelPrinter_IndexChanged(sender, e, element); };
            #endregion            
            return destCbo;
        }

        private ComboBox addProdLineCbo(ComboBox sourceCbo, int index, HandHeldScannerConfigElement element, GroupBox container)

        {
            //Build the generic CBO stuff
            ComboBox destCbo = genericProdLineCbo(sourceCbo, index, element.ProductionLine, container);
            #region Custom Events
            destCbo.SelectedIndexChanged += delegate (object sender, EventArgs e) { cboMobileScanner_IndexChanged(sender, e, element); };
            #endregion            
            return destCbo;
        }

        private ComboBox addProdLineCbo(ComboBox sourceCbo, int index, StandAloneScannerConfigElement element, GroupBox container)

        {
            //Build the generic CBO stuff
            ComboBox destCbo = genericProdLineCbo(sourceCbo, index, element.ProductionLine, container);
            #region Custom Events
            destCbo.SelectedIndexChanged += delegate (object sender, EventArgs e) { cboStandAloneScanner_IndexChanged(sender, e, element); };
            #endregion            
            return destCbo;
        }

        private ComboBox addConditionCbo(ComboBox sourceCbo, int index, StandAloneScannerConfigElement element, GroupBox container)

        {
            //Build the generic CBO stuff
            ComboBox destCbo = genericConditionCbo(sourceCbo, index, element.Condition, container);
            #region Custom Events
            destCbo.SelectedIndexChanged += delegate (object sender, EventArgs e) { cboSAScnCondition_IndexChanged(sender, e, element); };
            #endregion            
            return destCbo;
        }

        private ComboBox addConditionCbo(ComboBox sourceCbo, int index, HandHeldScannerConfigElement element, GroupBox container)

        {
            //Build the generic CBO stuff
            ComboBox destCbo = genericConditionCbo(sourceCbo, index, element.Condition, container);
            #region Custom Events
            destCbo.SelectedIndexChanged += delegate (object sender, EventArgs e) { cboHHScnCondition_IndexChanged(sender, e, element); };
            #endregion            
            return destCbo;
        }
        #endregion

        /// <summary>
        /// Added controls to a group box by copying the source control
        /// </summary>
        /// <typeparam name="T">Data type of the control to copy</typeparam>
        /// <param name="sourceCtrl">Control to copy</param>
        /// <param name="index">Used for colouring the rows</param>
        /// <param name="displayText">The .Text value to write</param>
        /// <param name="container">group box to put the control in</param>
        /// <returns></returns>
        private T addControl<T>(Control sourceCtrl, int index, string displayText, GroupBox container) where T : Control, new ()
        {
            //Set the veritical increment step
            int verticalOffset = sourceCtrl.Height + 1;
            //Create a new control of the type we are working with
            T destCtrl = new T();

            container.Controls.Add(destCtrl);
            //Copy the source poperties
            Helper.copyControl(sourceCtrl, destCtrl);
            destCtrl.Name = sourceCtrl.Name + index.ToString();
            destCtrl.Location = new Point(sourceCtrl.Location.X, sourceCtrl.Location.Y + (index * verticalOffset));
            destCtrl.Text = displayText;
            destCtrl.Visible = true;

            //Set the back colour of the control - For asthetics only
            destCtrl.BackColor = index % 2 == 0 ? Color.AliceBlue : Color.Aqua;
            

            destCtrl.Refresh();

            return destCtrl;
        }
        private void btnRetestIPAddresses_Click(object sender, EventArgs e)
        {
            PingTheIPAddresses();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            _discardChanges = true;
            this.Close();
        }

        private void btnStandAloneScanners_Click(object sender, EventArgs e)
        {
            frmStandAloneScanners fScanners = new frmStandAloneScanners(_db, _scanners);
            fScanners.ShowDialog();
        }

        private void btnInitScanners_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //Save the settings
            _exwoldConfigSettings.Save();
            _reInitilaiseScanners = true;
            this.Close();
        }
    }
}
