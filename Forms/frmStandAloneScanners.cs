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
    internal partial class frmStandAloneScanners : Form
    {
        private readonly DataInterface.execFunction _db = null;
        List<StandAloneScanner> _scanners;
        internal frmStandAloneScanners(DataInterface.execFunction database, List<StandAloneScanner> Scanners)
        {
            InitializeComponent();
            // Set the form parameters
            StartPosition = FormStartPosition.CenterParent;
            ShowIcon = true;
            Icon = Properties.Resources.ExwoldApp;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            TopMost = true;
            ControlBox = true;
            HelpButton = false;

            _db = database;
            _scanners = Scanners;
            
        }

        private void frmStandAloneScanners_Load(object sender, EventArgs e)
        {
            // Remove the existing tabs
            tabctrlScanners.TabPages.Clear();
            foreach (StandAloneScanner scanner in _scanners.OrderBy(o => o.ConfigData.Name))
            {

                Console.WriteLine($"Scanner:{scanner.ConfigData.Name}");

                //Add a new tab
                TabPage tabPageScanner = new TabPage(scanner.ConfigData.Name);
                //tabPageScanner.BackColor = Color.Green;
                //Create a panel to put the form into
                Panel pnlScanner = new Panel();


                pnlScanner.SuspendLayout();
                tabPageScanner.SuspendLayout();
                tabctrlScanners.SuspendLayout();
                this.SuspendLayout();


                //
                // fScanner
                //
                frmScannerDetail fScannerDetail = new frmScannerDetail(_db, scanner);
                fScannerDetail.TopLevel = false;
                fScannerDetail.Name = $"frm{scanner.ConfigData.Name.Replace(" ", "")}";
                fScannerDetail.FormBorderStyle = FormBorderStyle.None;
                fScannerDetail.Show();
//Set the form height
//this.Height = fScannerDetail.Height + grpButtons.Height + 30;
                //
                // pnlScanner
                //
                pnlScanner.Dock = DockStyle.Fill;
                pnlScanner.Name = $"pnl{scanner.ConfigData.Name.Replace(" ", "")}";
                pnlScanner.Controls.Add(fScannerDetail);

                //
                // tagPageScanner
                //
                tabPageScanner.Name = $"tab{scanner.ConfigData.Name.Replace(" ", "")}";
                tabPageScanner.Padding = new System.Windows.Forms.Padding(3);
                tabPageScanner.Controls.Add(pnlScanner);

                //
                // tabctrlScanners
                //
                tabctrlScanners.Controls.Add(tabPageScanner);

                pnlScanner.ResumeLayout(false);
                tabPageScanner.ResumeLayout(false);
                tabctrlScanners.ResumeLayout(false);
                this.ResumeLayout(false);

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
