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
        private StandAloneScanner _scanner;
        private string _simulationMessage;
        internal frmScannerDetail(StandAloneScanner Scanner)
        {
            InitializeComponent();
            _scanner = Scanner;
            LoadScannerData(_scanner);
        }

        #region Event Methods
        private void frmScannerDetail_Load(object sender, EventArgs e) 
        {
            if (_scanner.MX300N != null)
            {
                _scanner.MX300N.ScannerDataParsed += mx300n_DataParsed; 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
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
        }

        #endregion

        private void btnScanningSimulateMsg_Click(object sender, EventArgs e)
        {
            frmScannerMsg fscannercMsg = new frmScannerMsg()
            {
                GTIN = tbLastGTIN.Text,
                LotNo = tbLastLotNo.Text,
                ProdDate = tbLastProdDate.Text,
                ProdName = tbLastProdName.Text
            };


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
                _scanner.MX300N.StartScanningSimulation(_scanner.ConfigData.ScanRate);
            }
        }

        private void mx300n_DataParsed(object sender, ScannerDataEventArgs args)
        {
            Console.WriteLine($"Parsed Data:{args.ScannerId}\n{args.GTIN}\n{args.LotNo}\n{args.ProdDate}\n{args.ProdName}");
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
        }
    }
}
