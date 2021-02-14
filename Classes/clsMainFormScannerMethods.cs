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
using System.Linq;
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
        protected virtual void OnScannerGoodData(ScannerDataEventArgs args)
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
            Console.WriteLine($"{Logging.ThisMethod()} No of scanners (Config) : {_exwoldConfigSettings.StandAloneScanners.Count}");
            Console.WriteLine($"{Logging.ThisMethod()} No of scanners (Setup) : {Scanners.Count}");
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
            StandAloneScanner scanner = null; // = new StandAloneScanner(scannerConfig, orderData);
            Console.WriteLine($"{Logging.ThisMethod()} Id:{scannerConfig.Id}, Name:{scannerConfig.Name}");
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
                    scanner = new StandAloneScanner(scannerConfig, orderData);
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
            Console.WriteLine($"{Logging.ThisMethod()} Scanner read start {a.IPAddr}");
        }
        private void mx300n_ScannerReadStopped(object sender, ScannerReadStatusEventArgs a)

        {
            Console.WriteLine($"{Logging.ThisMethod()} Scanner read stopped {a.IPAddr}");
        }
        private async void mx300n_ScannerDataParsed(object sender, ScannerDataEventArgs args)
        {
            string batchChangeUser = args.ScannerId;
            //Console.WriteLine($"Parsed Data:{args.ScannerId}, {args.GTIN}, {args.LotNo}, {args.ProdDate}, {args.ProdName}");
            try
            {
                batchChangeUser = await Helper.ChangeUser(_db, args.PalletBatchUId.ToString());
                batchChangeUser = string.IsNullOrEmpty(batchChangeUser) ? args.ScannerId : batchChangeUser;

                if (string.IsNullOrEmpty(args.ProdName))
                {
                    //This is an Inner scan
                    await ProcessInnerPackScan(args, batchChangeUser);
                }
                else
                {
                    await ProcessOuterPackScan(args, batchChangeUser);
                }
            }
            catch { }
        }

        /// <summary>
        /// Upload a scanned carton to the database and update the UI
        /// </summary>
        /// <param name="scannedData">Data extracted from the scanner</param>
        private async Task ProcessInnerPackScan(ScannerDataEventArgs scannedData, string ChangeUser)
        {
            try
            {
                //Upload the data to the database
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("PalletBatchUniqueNo", scannedData.PalletBatchUId.ToString());
                _db.QueryParameters.Add("LotNo", scannedData.LotNo);
                _db.QueryParameters.Add("ProductionLineNo", scannedData.ProductionLineUId.ToString());
                _db.QueryParameters.Add("InnerGTIN", scannedData.GTIN);
                _db.QueryParameters.Add("ProdDate", scannedData.ProdDate);
                _db.QueryParameters.Add("Device", scannedData.ScannerId);
                DataTable dt = await _db.executeSP("[dbo].[spInnerPackAccept]", true);

                if (dt != null)
                {
                    // If we have a valid UId returned and the data is valid, refresh the page
                    try
                    {
                        frmLineInfo lInfo = lineInfoPage(scannedData.ProductionLineUId);
                        if (lInfo != null)
                        {
                            if (int.Parse(dt.Rows[0]["Valid"].ToString()) == 1)
                            {
                                await lInfo.UpdateScannedCounts();
                            }
                            lInfo.UpdateScannerUI(int.Parse(dt.Rows[0]["Valid"].ToString()) == 1, dt.Rows[0]["Message"].ToString(), true, string.Empty);
                        }
                    }
                    catch { } //Line not found so do nothing!
                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
            }
        }

        private async Task ProcessOuterPackScan(ScannerDataEventArgs scannedData, string ChangeUser)
        {
            
            DataTable dtAcceptCartonData = null;
            int CurrentPalletUId = await Helper.CurrentPallet(_db, scannedData.PalletBatchUId);
            try
            {
                if (checkScanData(scannedData))
                {
                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("PalletBatchUniqueNo", scannedData.PalletBatchUId.ToString());
                    _db.QueryParameters.Add("GTIN", scannedData.GTIN);
                    _db.QueryParameters.Add("ProdDate", scannedData.ProdDate);
                    _db.QueryParameters.Add("MaterialBatch", scannedData.LotNo);
                    _db.QueryParameters.Add("PalletUniqueNo", CurrentPalletUId.ToString());
                    _db.QueryParameters.Add("Device", string.IsNullOrEmpty(ChangeUser) ? scannedData.ScannerId : ChangeUser);
                    dtAcceptCartonData = await _db.executeSP("[dbo].[spAcceptCartonData]", true);
                }
                if (dtAcceptCartonData != null)
                {
                    if (int.Parse(dtAcceptCartonData.Rows[0]["PalletUniqueNo"].ToString()) > 0)
                    {
                        Console.WriteLine($"dtAcceptCartonData Rtn: {dtAcceptCartonData.Rows[0]["PalletUniqueNo"]}");
                        // If we have a valid UId returned and the data is valid, refresh the 
                        try
                        {
                            await lineInfoPage(scannedData.ProductionLineUId).UpdateScannedCounts();
                            lineInfoPage(scannedData.ProductionLineUId).UpdateScannerUI(true, string.Empty, true, string.Empty);
                        }
                        catch { } //Line not found so do nothing!
                    }
                    else
                    {
                        try
                        {
                            lineInfoPage(scannedData.ProductionLineUId).UpdateScannerUI(true, string.Empty, false, dtAcceptCartonData.Rows[0]["Message"].ToString());
                        }
                        catch { } //Line not found so do nothing!
                    }
                }
                else
                {
                    try
                    {
                        lineInfoPage(scannedData.ProductionLineUId).UpdateScannerUI(true, string.Empty, false, "Bad data scanned");
                    }
                    catch { } //Line not found so do nothing!
                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
            }
            #endregion
        }
        private bool checkScanData(ScannerDataEventArgs scannedData)
        {
            bool bGTIN = scannedData.GTIN.Length == 14;
            bool bProdDate = scannedData.ProdDate.Length == 6;
            bool bLotNo = scannedData.LotNo.Length >= 3 && scannedData.LotNo.Length <= 20;
            bool bProdName = scannedData.ProdName.Length <= 50;

            return bGTIN && bProdDate && bLotNo && bProdDate;
        }
        private frmLineInfo lineInfoPage(int LineUId)
        {
            try
            {
                if (fLineInfo1 != null && fLineInfo1.LineId == LineUId)
                {
                    return fLineInfo1;
                }
                if (fLineInfo2 != null && fLineInfo2.LineId == LineUId)
                {
                    return fLineInfo2;
                }
                if (fLineInfo3 != null && fLineInfo3.LineId == LineUId)
                {
                    return fLineInfo3;
                }
            }
            catch { }
            return null;
        }
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
