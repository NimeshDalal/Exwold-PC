using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ITS.Exwold.Desktop
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void InitSettings()
        {
            try
            {
                tbPlantNumber.Text = ConfigurationManager.AppSettings["plantNumber"];
                tbTcpListenPort.Text = ConfigurationManager.AppSettings["tcpListenPort"];
                tbNiceLabelSDKPath.Text = ConfigurationManager.AppSettings["NiceLabelSDKPath"]; ;
                tbLogLevel.Text = ConfigurationManager.AppSettings["logLevel"];
                tbLogPath.Text = ConfigurationManager.AppSettings["logPath"];
            }
            catch { }
        }
        private bool SaveSettings()
        {
            try
            {
                ConfigurationManager.AppSettings.Set("plantNumber", tbPlantNumber.Text);
                ConfigurationManager.AppSettings.Set("tcpListenPort", tbTcpListenPort.Text);
                ConfigurationManager.AppSettings.Set("NiceLabelSDKPath", tbNiceLabelSDKPath.Text);
                ConfigurationManager.AppSettings.Set("logLevel", tbLogLevel.Text);
                ConfigurationManager.AppSettings.Set("logPath", tbLogPath.Text);
                return true;
            }
            catch { return false; }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            InitSettings();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {
                MessageBox.Show("Settings Saved", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Settings failed to save", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
