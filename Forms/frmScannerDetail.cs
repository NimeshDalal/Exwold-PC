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
    internal partial class frmScannerDetail : Form
    {
        private readonly DataInterface.execFunction _db;
        private StandAloneScanner _scanner;
        private string _simulationMessage;
        private bool _enableClose = false;

        internal frmScannerDetail(DataInterface.execFunction database, StandAloneScanner Scanner)
        {
            InitializeComponent();
            _db = database;
            _scanner = Scanner;
            LoadScannerData(_scanner);
        }

        public bool EnableClose
        {
            get => _enableClose;
            set { _enableClose = value; }
        }
        #region Event Methods
        private void frmScannerDetail_Load(object sender, EventArgs e) 
        {
            if (_scanner.MX300N != null)
            {
                _scanner.MX300N.ScannerDataParsed += mx300n_DataParsed; 
            }
        }
        #endregion

        #region Form Methods
        private async void LoadScannerData(StandAloneScanner Scanner)
        {
            if (Scanner == null) { throw new ArgumentNullException(nameof(Scanner)); }

            tbScannerID.Text = Scanner.ConfigData.Id.ToString();
            tbScannerName.Text = Scanner.ConfigData.Name;
            tbScannerIPAddr.Text = Scanner.ConfigData.IpAddr.ToString();
            tbScannerPort.Text = Scanner.ConfigData.Port.ToString();
            tbScannerProdLine.Text = Scanner.ConfigData.ProductionLine.ToString();

            if (Scanner.OrderData == null)
            {
                grpOrderInfo.Enabled = false;
            }
            else
            {
                grpOrderInfo.Enabled = true;
                tbOrderProdCode.Text = Scanner.OrderData.ProductCode;
                tbOrderProdName.Text = Scanner.OrderData.ProductName;
                tbOrderGTIN.Text = Scanner.OrderData.GTIN;
                tbOrderInnerGTIN.Text = Scanner.OrderData.InnerGTIN;
                tbOrderPalletBatchUId.Text = Scanner.OrderData.PalletBatchUId.ToString();
            }

            if (Scanner.MX300N == null)
            {
                grpScannerStatus.Enabled = false;
            }
            else
            {
                grpScannerStatus.Enabled = true;
                tbStatusAvailable.Text = (await Scanner.MX300N.IsAvailable()).ToString();
                try
                {
                    tbStatusConnected.Text = (await Scanner.MX300N.IsConnected()).ToString();
                }
                catch
                {
                    tbStatusConnected.Text = "Error";
                }
                tbStatusScanning.Text = Scanner.MX300N.IsScanning().ToString();
            }
            
            btnScanningSimulateMsg.Enabled = _scanner.OrderData.PalletBatchUId > 0;
            btnScanningStart.Enabled = _scanner.OrderData.PalletBatchUId > 0;
            btnScanningStop.Enabled = _scanner.OrderData.PalletBatchUId > 0;
        }

        #endregion

        private async void btnScanningSimulateMsg_Click(object sender, EventArgs e)
        {
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchId", _scanner.OrderData.PalletBatchUId.ToString());
            DataSet dsLabelData = await _db.getDataSet("[GUI].[getLabelData]", true);
            frmScannerMsg fscannercMsg = new frmScannerMsg(dsLabelData);
         
            fscannercMsg.TopMost = true;
            fscannercMsg.ShowDialog();
            _simulationMessage = fscannercMsg.SimMsg;
            fscannercMsg.Dispose();
            if (_scanner.MX300N != null)
            {
                _scanner.MX300N.SimulateMsg = _simulationMessage;
            }
        }
        private void btnScanningStart_Click(object sender, EventArgs e)
        {
            if (_scanner.MX300N != null)
            {
//                _scanner.MX300N.StartScanningSimulation(1, _scanner.ConfigData.ScanRate);
                _scanner.MX300N.StartScanningSimulation(int.Parse(tbNumScans.Text), 1000);
            }
            btnScanningStop.Enabled = true;
        }

        private void mx300n_DataParsed(object sender, ScannerDataEventArgs args)
        {
            //Console.WriteLine($"Parsed Data:{args.ScannerId}\n{args.GTIN}\n{args.LotNo}\n{args.ProdDate}\n{args.ProdName}");
            lblLastScannedDate.Text = args.ScannedDate.ToString("dd-MMM-yyyy HH:mm:ss");
            tbLastGTIN.Text = args.GTIN;
            tbLastLotNo.Text = args.LotNo;
            tbLastProdDate.Text = args.ProdDate;
            tbLastProdName.Text = args.ProdName;
        }

        private void btnScanningStop_Click(object sender, EventArgs e)
        {
            if (_scanner.MX300N != null)
            {
                _scanner.MX300N.StopScanning();
            }
            btnScanningStop.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_enableClose)
            {
                this.Close();
                this.Dispose();
            }
        }


    }
}
