/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsMainFormScannerMethods.cs
 * Description: Extension for the main form :
 *              1)  Contains code for the Stand Alone Scanners
 * FileVersion  Build       Date        Project/CRF.    Change By       References 
 * 2.00         2.00.00.00  Dec 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Text;
using ITS.Exwold.Desktop.DataInterface;
using System.Threading;
using System.Net;

namespace ITS.Exwold.Desktop
{
    //[GUI].[getSalesOrdersByStatus]
    public partial class MainStatusForm : Form
    {
        #region local variables
        internal List<StandAloneScanner> Scanners = new List<StandAloneScanner>();
        public event EventHandler<ScannerDataEventArgs> ScannerDataParsed;
        #endregion
        #region Events
        protected virtual void OnScannerDataParsed(ScannerDataEventArgs args)
        {
            ScannerDataParsed?.Invoke(this, args);
        }
        private void SubscribeScannerEvents(StandAloneScanner scanner, bool subscribe)
        {
            if (scanner.MX300N == null) return;

            if (subscribe)
            {
                scanner.MX300N.ScannerRead += mx300n_ScannerRead;
                scanner.MX300N.ScannerReadStarted += mx300n_ScannerReadStarted;
                scanner.MX300N.ScannerReadStopped += mx300n_ScannerReadStopped;
                scanner.MX300N.ScannerDataParsed += mx300n_ScannerDataParsed;
            }
            else
            {
                scanner.MX300N.ScannerRead -= mx300n_ScannerRead;
                scanner.MX300N.ScannerReadStarted -= mx300n_ScannerReadStarted;
                scanner.MX300N.ScannerReadStopped -= mx300n_ScannerReadStopped;
                scanner.MX300N.ScannerDataParsed -= mx300n_ScannerDataParsed;
            }
        }
        #endregion

        public void InitScanners()
        {
            Console.WriteLine($"No of scanners (Config) : {_exwoldConfigSettings.StandAloneScanners.Count}");
            Console.WriteLine($"No of scanners (Setup) : {Scanners.Count}");
            foreach (StandAloneScannerConfigElement scannerConfig in _exwoldConfigSettings.StandAloneScanners)
            {
                bool _init = false;
                try
                {
                    /*
                    // Just reinitialise all of the scanners
                    // This should not take long to complete.
                    InitScanner(scannerConfig);
                    */
                    /*
                     * This code looks for a change in the scanner config and only updates the ones that have changed 
                     */
                    //find the scanner in the current config
                    if (Scanners.Count > 0)
                    {
                        StandAloneScanner currScanner = Scanners.Find(ele => ele.ConfigData.Id == scannerConfig.Id);
                        if (currScanner != null)
                        {
                            if (currScanner.MX300N == null & scannerConfig.Condition == "active")
                            {
                                _init = true;
                            }
                            else
                            {
                                if (!(currScanner.MX300N.ProductionLineUId == scannerConfig.ProductionLine &
                                    currScanner.MX300N.ScanRate == scannerConfig.ScanRate))
                                {
                                    _init = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        _init = true;
                    }
                    if (_init) { InitScanner(scannerConfig); }
                }
                catch { }
            }
        }
        private async void InitScanner(StandAloneScannerConfigElement scannerConfig)
        {
            ScannerOrderData orderData = null;
            StandAloneScanner scanner = new StandAloneScanner(scannerConfig, orderData);
            Console.WriteLine($"Id:{scannerConfig.Id}, Name:{scannerConfig.Name}");
            if (scannerConfig.Condition == "active")
            {
                try
                {
                    /*
                     * Get the current order on the line to which the scanner is attached
                     */
                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("Status", ((int)Helper.BatchStatus.InProgress).ToString());
                    _db.QueryParameters.Add("LineNumber", scannerConfig.ProductionLine.ToString());
                    DataTable dt = await _db.executeSP("[GUI].[getPalletBatch]", true);
                    orderData = new ScannerOrderData();
                    // There should only be one In-Progress Order per line
                    if (dt != null && dt.Rows.Count == 1)
                    {
                        orderData.PalletBatchUId = int.Parse(dt.Rows[0]["PalletBatchUniqueNo"].ToString());
                        orderData.ProductionLineUId = int.Parse(dt.Rows[0]["ProductionLineNo"].ToString());
                        orderData.GTIN = dt.Rows[0]["GTIN"].ToString();
                        orderData.InnerGTIN = dt.Rows[0]["InnerGTIN"].ToString();
                        orderData.ProductName = dt.Rows[0]["ProductName"].ToString();
                        orderData.ProductCode = dt.Rows[0]["ProductCode"].ToString();
                        orderData.ProdLineName = dt.Rows[0]["ProdLineName"].ToString();
                    }
                    scanner.OrderData = orderData;
                    Scanners.Add(scanner);
                    bool bScanning = await scanner.MX300N.TryStart();
                    try
                    {
                        SubscribeScannerEvents(scanner, true);
                    }
                    catch { }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
                }
            }
            else
            {
                try
                {
                    Scanners.Add(scanner);
                    try
                    {
                        SubscribeScannerEvents(scanner, false);
                    }
                    catch { }
                }
                catch (Exception ex)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
                }
            }
        }


        #region scanner event handlers
        private void mx300n_ScannerRead(object sender, ScannerReadEventArgs a)
        {
            Console.WriteLine($"{Logging.ThisMethod()} Scanner:{a.IPAddr}, GoodReads:{a.GoodReads}, ReadsTried:{a.ReadsTried}, Data Length: {a.RawData.Length} Raw Data:{a.RawData}");
        }
        private void mx300n_ScannerReadStarted(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine($"Scanner read start {a.IPAddr}");
        }
        private void mx300n_ScannerReadStopped(object sender, ScannerReadStatusEventArgs a)

        {
            Console.WriteLine($"Scanner read stopped {a.IPAddr}");
        }
        private async void mx300n_ScannerDataParsed(object sender, ScannerDataEventArgs args)
        {
            Console.WriteLine($"Parsed Data:{args.ScannerId}\n{args.GTIN}\n{args.LotNo}\n{args.ProdDate}\n{args.ProdName}");
            //Upload the data to the database
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchUniqueNo", args.PalletBatchUId.ToString());
            _db.QueryParameters.Add("ProductionLineNo", args.ProductionLineUId.ToString());
            _db.QueryParameters.Add("GTIN", args.GTIN);
            _db.QueryParameters.Add("ProdDate", args.ProdDate);
            _db.QueryParameters.Add("LotNo", args.LotNo);
            _db.QueryParameters.Add("Device", args.ScannerId);
            DataTable dt = await _db.executeSP("[dbo].[spAcceptInnerPackData]", true);
        }

        #endregion


    }

    internal class ScannerOrderData
    {
        internal int PalletBatchUId { get; set; }
        internal int ProductionLineUId { get; set; }
        internal string GTIN { get; set; }
        internal string InnerGTIN { get; set; }
        internal string ProductName { get; set; }
        internal string ProductCode { get; set; }
        internal string ProdLineName { get; set; }
    }
    internal class StandAloneScanner
    {
        #region Local Variables
        private StandAloneScannerConfigElement _configData = null;
        private clsMx300NDataAsync _mx300n = null;
        private ScannerOrderData _orderData = null;
        #endregion
        #region Properties
        public StandAloneScannerConfigElement ConfigData
        {
            get { return _configData; }
            set { _configData = value; }
        }

        public clsMx300NDataAsync MX300N
        {
            get { return _mx300n; }
            set { _mx300n = value; }
        }
        public ScannerOrderData OrderData
        {
            get { return _orderData; }
            set { _orderData = value; }
        }

        #endregion
        internal StandAloneScanner(StandAloneScannerConfigElement ConfigData, ScannerOrderData OrderData)
        {
            //Need to change this to to get the current PalletBatchUId for the line

            _configData = ConfigData;
            _orderData = OrderData;
            int _palletBatchUId = 0;
            if (_orderData != null) { _palletBatchUId = _orderData.PalletBatchUId; }
            if (OrderData == null)
            {

            }
            if (_configData.Condition == "active")
            {
                _mx300n = new clsMx300NDataAsync(IPAddress.Parse(_configData.IpAddr), _configData.Port)
                {
                    LogControl = null,
                    ctrlReads = null,
                    ctrlGoodReads = null,
                    PalletBatchUId = _palletBatchUId,
                    ProductionLineUId = ConfigData.ProductionLine,
                    ScannerId = _configData.Name,
                    ScanRate = _configData.ScanRate,
                };
            }
            
        }
    }

}
