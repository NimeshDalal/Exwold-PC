using System;
using System.Data;
using ITS.Exwold.Desktop;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ITS.Exwold.PackInformation
{
    public class PackInfo : IPackInfo
    {
        #region Constructor
        public PackInfo() : this(null) { }
        public PackInfo(DataSet RawData)
        {
            getDataFromDS(RawData);
        }
        #endregion        
        #region Backing Fields
        #region Table[0]
        private int _numCartons = int.MinValue;
        private int _innersInCarton = int.MinValue;
        private int _numPallets = int.MinValue;
        private int _innersOnPallet = int.MinValue;
        private int _innersUnassigned = int.MinValue;

        private int _cartonsPerPallet = int.MinValue;
        private int _innerPacksPerCarton = int.MinValue;
        private int _requiredTotalOuters = int.MinValue;
        private int _requiredTotalInners = int.MinValue;
        #endregion
        #region Table[1]
        private int _currPalletUId = int.MinValue;
        private string _currProductCode = string.Empty;
        private string _currPalletSSCC = string.Empty;
        private DateTime _currPalletStart = DateTime.MinValue;
        #endregion
        #region Table[2]
        private int _cartonsOnPallet;
        private int _currPalletLabelUId;
        #endregion
        private DataSet _rawPackInfo = null;
        private string _lastUpdateMessage = string.Empty;
        #endregion

        #region Table[0] Properties
        public int NumCartons { get => _numCartons; }
        public int InnersInCarton { get => _innersInCarton; }
        public int NumPallets { get => _numPallets; }
        public int InnersOnPallet { get => _innersOnPallet; }
        public int InnersUnassigned { get => _innersUnassigned; }

        public int CartonsPerPallet { get => _cartonsPerPallet; }
        public int InnerPacksPerCarton { get => _innerPacksPerCarton; }
        public int RequiredTotalOuters { get => _requiredTotalOuters; }
        public int RequiredTotalInners { get => _requiredTotalInners; }
        #endregion
        #region Table[1] Properties
        public int CurrPalletUId { get => _currPalletUId; }
        public string CurrProductCode { get => _currProductCode; }
        public string CurrPalletSSCC { get => _currPalletSSCC; }
        public DateTime CurrPalletStart { get => _currPalletStart; }
        #endregion
        #region Table[2] Properties
        public int CartonsOnPallet { get => _cartonsOnPallet; }
        public int CurrPalletLabelUId { get => _currPalletLabelUId; }
        #endregion

        #region Other Properties
        public DataSet RawPackInfo
        {
            get => _rawPackInfo;
            set
            {
                _rawPackInfo = value;
                getDataFromDS(_rawPackInfo);
            }
        }
        public string LastUpdateMessage
        {
            get => _lastUpdateMessage;
        }
        #endregion

        private void InitData()
        {
            #region Table[0]
            _numCartons = -1;
            _innersInCarton = 1;
            _numPallets = -1;
            _innersOnPallet = -1;
            _innersUnassigned = -1;

            _cartonsPerPallet = -1;
            _innerPacksPerCarton = -1;
            _requiredTotalOuters = -1;
            _requiredTotalInners = -1;
            #endregion
            #region Table[1]
            _currPalletUId = -1;
            _currProductCode = string.Empty;
            _currPalletSSCC = string.Empty;
            _currPalletStart = DateTime.MinValue;
            #endregion
            #region Table[2]
            _cartonsOnPallet = -1;
            _currPalletLabelUId = -1;
            #endregion
            _rawPackInfo = null;
        }
        private void getDataFromDS(DataSet rawData)
        {
            try
            {
                if (rawData == null || rawData.Tables.Count != 4)
                {
                    _lastUpdateMessage = $"{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}: Raw Data not returned";
                    InitData();
                }
                else if (rawData.Tables.Count != 4)
                {
                    _lastUpdateMessage = $"{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}: Table Count is {rawData.Tables.Count}. Need to be 4";
                    InitData();
                }
                else
                {
                    #region Table[1]
                    int.TryParse(rawData.Tables[0].Rows[0]["NumCartons"].ToString(), out _numCartons);
                    int.TryParse(rawData.Tables[0].Rows[0]["InnersInCarton"].ToString(), out _innersInCarton);
                    int.TryParse(rawData.Tables[0].Rows[0]["NumPallets"].ToString(), out _numPallets);
                    int.TryParse(rawData.Tables[0].Rows[0]["InnersOnPallet"].ToString(), out _innersOnPallet);
                    int.TryParse(rawData.Tables[0].Rows[0]["InnersUnassigned"].ToString(), out _innersUnassigned);

                    int.TryParse(rawData.Tables[0].Rows[0]["CartonsPerPallet"].ToString(), out _cartonsPerPallet);
                    int.TryParse(rawData.Tables[0].Rows[0]["InnerPacksPerCarton"].ToString(), out _innerPacksPerCarton);
                    int.TryParse(rawData.Tables[0].Rows[0]["RequiredTotalOuters"].ToString(), out _requiredTotalOuters);
                    int.TryParse(rawData.Tables[0].Rows[0]["RequiredTotalInners"].ToString(), out _requiredTotalInners);
                    #endregion

                    #region Table[1] - Open Pallets for the Sales Order
                    if (rawData.Tables[1].Rows.Count == 0)
                    {
                        _currPalletUId = 0;
                        _currProductCode = string.Empty;
                        _currPalletSSCC = string.Empty;
                        _currPalletStart = DateTime.MinValue;
                    }
                    else
                    {
                        int.TryParse(rawData.Tables[1].Rows[0]["PalletUniqueNo"].ToString(), out _currPalletUId);
                        _currProductCode = rawData.Tables[1].Rows[0]["ProductCode"].ToString();
                        _currPalletSSCC = rawData.Tables[1].Rows[0]["SSCC"].ToString();
                        _currPalletStart = DateTime.Parse(rawData.Tables[1].Rows[0]["StartDT"].ToString());
                    }
                    #endregion
                    #region Table[2]
                    if (rawData.Tables[2].Rows.Count > 0)
                    {
                        /*
                         * If se have an open pallet then use the label to give us the cartons on the pallet
                         */
                        if (rawData.Tables[1].Rows.Count > 0)
                        {
                            int.TryParse(rawData.Tables[2].Rows[0]["CartonsOnPallet"].ToString(), out _cartonsOnPallet);
                        }
                        else
                        {
                            _cartonsOnPallet = 0;
                        }
                        int.TryParse(rawData.Tables[2].Rows[0]["PalletLabelUniqueNo"].ToString(), out _currPalletLabelUId);
                    }
                    else
                    {
                        _cartonsOnPallet = 0;
                        _currPalletLabelUId = -1;
                    }
                    #endregion
                    _rawPackInfo = rawData;
                    _lastUpdateMessage = $"{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}: Data Updated ";
                }
            }
            catch { InitData(); }
        }

        #region IPackInfoExtensions methods
        /// <summary>
        /// Outers recorded in the database plus the number scanned herein
        /// </summary>
        public int OutersScanned
        {
            get
            {
                return _numCartons;
            }
        }
        /// <summary>
        /// Inners recorded in the database plus the number scanned herein
        /// </summary>
        public int InnersScanned
        {
            get
            {
                return (_innersInCarton + _innersUnassigned);
                // ToDo: Add this line if in the mobile app   
                // It adds on the inners scanned in the Handheld, but not uploaded
                //+ GlobalSetting.Instance().AcceptedInners.Inners.Count;
            }
        }
        public int OutersRemaining
        {
            get
            {
                return _requiredTotalOuters - OutersScanned;
            }
        }
        public int InnersRemaining
        {
            get
            {
                return _requiredTotalInners - InnersScanned;
            }
        }

        public int OutersToCompletePallet
        {
            get
            {
                if (_cartonsPerPallet > 0 & (OutersScanned % _cartonsPerPallet) != 0)
                {
                    return _cartonsPerPallet / (OutersScanned % _cartonsPerPallet);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int InnersToCompletePack
        {
            get
            {
                //ToDo: Add this line if in the mobile app
                // It adds on the inner scanned in the Handheld, but not uploaded
                //return (_innersUnassigned + GlobalSetting.Instance().AcceptedInners.Inners.Count) % _innerPacksPerCarton;
                return (_innersUnassigned) % _innerPacksPerCarton;
            }
        }

        #endregion
    }

    public interface IPackInfo
    {
        #region Table[0] Properties
        int NumCartons { get; }
        int InnersInCarton { get; }
        int NumPallets { get; }
        int InnersOnPallet { get; }
        int InnersUnassigned { get; }

        int CartonsPerPallet { get; }
        int InnerPacksPerCarton { get; }
        int RequiredTotalOuters { get; }
        int RequiredTotalInners { get; }
        #endregion
        #region Table[1] Properties
        int CurrPalletUId { get; }
        string CurrProductCode { get; }
        string CurrPalletSSCC { get; }
        DateTime CurrPalletStart { get; }
        #endregion
        #region Table[2] Properties
        int CartonsOnPallet { get; }
        int CurrPalletLabelUId { get; }
        #endregion
        #region Other Properties
        DataSet RawPackInfo { get; set; }
        #endregion
        #region Extensions
        int OutersScanned { get; }
        int InnersScanned { get; }
        int OutersRemaining { get; }
        int InnersRemaining { get; }
        int OutersToCompletePallet { get; }
        int InnersToCompletePack { get; }        
        #endregion

    }
}
