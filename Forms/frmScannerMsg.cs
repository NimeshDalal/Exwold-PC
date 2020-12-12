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
    public partial class frmScannerMsg : Form
    {
        private string _simMsg = string.Empty;
        public string SimMsg
        {  get { return _simMsg; } }
        public string GTIN { get; set; }
        public string LotNo { get; set; }
        public string ProdDate { get; set; }
        public string ProdName { get; set; }
        public frmScannerMsg()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSetMsg_Click(object sender, EventArgs e)
        {
            try
            {
                _simMsg = PrepareMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Logging.ThisMethod(), ex.Message);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private string PrepareMessage()
        {
            StringBuilder msg = new StringBuilder();
            string str;
            //Add the stx
            msg.Append((char)MDC_ASCII.Ascii.STX);
            //Add the GTIN
            msg.Append("01");
            if (tbGTIN.Text.Length != 14)
            {
                throw new ArgumentOutOfRangeException("GTIN needs to be 14 chars");
            }
            msg.Append(tbGTIN.Text);
            //Add the Prod Date
            msg.Append("11");
            DateTime prodDate = DateTime.Parse(tbProdDate.Text);
            msg.Append($"{prodDate.ToString("yy")}{prodDate.ToString("MM")}{prodDate.ToString("dd")}");

            //Add the Lot No
            str = tbLotNo.Text.Trim();
            if (string.IsNullOrEmpty(str) || str.Length > 20)
            {
                throw new ArgumentOutOfRangeException("Lot Number is 1 - 20 chars");
            }
            msg.Append("10");
            msg.Append(str);

            //Add the product name
            str = tbProdName.Text.Trim();
            if (!string.IsNullOrEmpty(str))
            {
                //Add the separator char
                msg.Append((char)MDC_ASCII.Ascii.GS);
                // We have a prodname
                if (str.Length > 30)
                {
                    //Need 2x prod name strings
                    msg.Append("240");
                    msg.Append(str.Substring(0, 30));
                    msg.Append((char)MDC_ASCII.Ascii.GS);
                    msg.Append("240");
                    msg.Append(str.Substring(30, str.Length - 30));
                }
                else
                {
                    //Only have one prodname string
                    msg.Append("240");
                    msg.Append(str);
                }
            }
            //Add the ETX
            msg.Append((char)MDC_ASCII.Ascii.ETX);

            return msg.ToString();
        }

        private void frmScannerMsg_Load(object sender, EventArgs e)
        {
            DateTime dt;
            try
            {
                DateTime.TryParseExact(ProdDate, "yyMMdd", null, 
                    System.Globalization.DateTimeStyles.None, out dt);
                tbProdDate.Text = dt.ToString("dd-MMM-yyyy");
            }
            catch
            {
                tbProdDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            tbGTIN.Text = GTIN;
            tbLotNo.Text = LotNo;
            tbProdName.Text = ProdName;
        }
    }
}

