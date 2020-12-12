/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsConfigurationSettings
 * Description: Read project specific settings from a the app.Config file or another config file as required
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              <Description of the change>
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ITS.Exwold.Desktop
{
    #region Connectivity Settings
    public class ConnectivitySection : ConfigurationSection
    {
        private const string cstSectionName = "Connectivity";
        #region Fields
        private static ConnectivitySection _instance;
        private static string _spath;
        #endregion
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ConnectivityCollection settings
        {
            get
            {
                ConnectivityCollection col = (ConnectivityCollection)base[""];
                return col;
            }
            set
            {
                this[""] = value;
            }
        }
        public static ConnectivitySection Open()
        {
            /*
             * The GetEntryAssembly method can return null when a managed assembly has been loaded from an unmanaged application. 
             * For example, if an unmanaged application creates an instance of a COM component written in C#, 
             * a call to the GetEntryAssembly method from the C# component returns null, 
             * because the entry point for the process was unmanaged code rather than a managed assembly.
             */
            System.Reflection.Assembly assy = System.Reflection.Assembly.GetEntryAssembly();
            if (assy == null)
            {
                Configuration cnfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                return Open(cnfg.FilePath);
            }
            else
            {
                return Open(assy.Location);
            }
        }
        public static ConnectivitySection Open(string path)
        {
            if ((object)_instance == null)
            {
                if (path.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase))
                {
                    path = path.Remove(path.Length - 7);
                }
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);
                if (config.GetSection(cstSectionName) == null)
                {
                    _instance = new ConnectivitySection();
                    config.Sections.Add(cstSectionName, _instance);
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                    _instance = (ConnectivitySection)config.GetSection(cstSectionName);
            }
            return _instance;
        }
        public void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(_spath);
            ConnectivitySection section = (ConnectivitySection)config.GetSection(cstSectionName);
            section.settings = this.settings;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(cstSectionName);
        }
    }
    public class ConnectivityCollection : ConfigurationElementCollection
    {
        public ConnectivityCollection()
        {
            ConnectivityConfigElement details = (ConnectivityConfigElement)CreateNewElement();
            if (details.Name != string.Empty)
            {
                Add(details);
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectivityConfigElement();
        }
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectivityConfigElement)element).Name;
        }
        public ConnectivityConfigElement this[int index]
        {
            get
            {
                return (ConnectivityConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        new public ConnectivityConfigElement this[string name]
        {
            get
            {
                return (ConnectivityConfigElement)BaseGet(name);
            }
        }
        public int IndexOf(ConnectivityConfigElement details)
        {
            return BaseIndexOf(details);
        }
        public void Add(ConnectivityConfigElement details)
        {
            BaseAdd(details);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
        public void Remove(ConnectivityConfigElement details)
        {
            if (BaseIndexOf(details) >= 0)
                BaseRemove(details.Name);
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        public void Remove(string name)
        {
            BaseRemove(name);
        }
        public void Clear()
        {
            BaseClear();
        }
        protected override string ElementName
        {
            get { return "setting"; }
        }
    }
    public class ConnectivityConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, DefaultValue = "")]
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 30)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", IsKey = true, IsRequired = true, DefaultValue = "")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }

        [ConfigurationProperty("encrypted", IsRequired = true)]
        public bool Encrypted
        {
            get { return (bool)this["encrypted"]; }
            set { this["encrypted"] = value; }
        }
    }

    #endregion

    #region Exwold Plant Configuration Settings
    /// <summary>
    /// Reads the default OR custom configuration file
    /// </summary>
    public class ExwoldConfigSettings
    {
        private string _configFile = string.Empty;
        private Configuration _cnfg = null;
        private int _plantId = 0;
        private string _plantName = string.Empty;
        private PlantCollection _plants = null;
        private ProductionLineCollection _productionLines = null;
        private PalletLabelPrinterCollection _palletLabelPrinters = null;
        private InnerPackLabelPrinterCollection _innerPackLabelPrinters = null;
        private OuterPackLabelPrinterCollection _outerPacklblPrinters = null;
        private HandHeldScannerCollection _handHeldScanners = null;
        private StandAloneScannerCollection _standAloneSanners = null;

        #region Properties
        internal int PlantID
        {
            get { return _plantId; }
            set { _plantId = value; }
        }
        internal string PlantName
        {
            get { return _plantName; }
            set { _plantName = value; }
        }
        internal string ConfigFile
        {
            get { return _configFile; }
            set { _configFile = value; }
        }

        internal PlantCollection Plants
        { get { return _plants; } }
        internal ProductionLineCollection ProductionLines
        { get { return _productionLines; } }
        internal PalletLabelPrinterCollection PalletLabelPrinters
        { get { return _palletLabelPrinters; } }
        internal InnerPackLabelPrinterCollection InnerPackLabelPrinters
        { get { return _innerPackLabelPrinters; } }
        internal OuterPackLabelPrinterCollection OuterPackLabelPrinters
        { get { return _outerPacklblPrinters; } }
        internal HandHeldScannerCollection HandHeldScanners
        { get { return _handHeldScanners; } }
        internal StandAloneScannerCollection StandAloneScanners
        { get { return _standAloneSanners; } }

        #endregion
        #region Constructor
        internal ExwoldConfigSettings(int plantId)
        {
            //Set the configuraion file to the default application file
            _cnfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _plantId = plantId;
            GetExwoldPlantConfig(_cnfg, _plantId);
        }
        internal ExwoldConfigSettings(string ConfigurationFile, int plantId)
        {
            //Create a pointer to the alternative config file
            ExeConfigurationFileMap filemap = new ExeConfigurationFileMap();
            filemap.ExeConfigFilename = ConfigurationFile;
            //Open the config files
            _cnfg = ConfigurationManager.OpenMappedExeConfiguration(filemap, ConfigurationUserLevel.None);
            _plantId = plantId;
            GetExwoldPlantConfig(_cnfg, _plantId);
        }
        #endregion

        /// <summary>
        /// Returns the plant configuration for the specified plant number
        /// from the plants collection
        /// and makes the hardware collections available
        /// </summary>
        /// <param name="cnfg">The configuration file to read from</param>
        /// <param name="plantId">The plant id to locate in the configuration</param>
        /// <returns>the element containing the collections</returns>
        private bool GetExwoldPlantConfig(Configuration cnfg, int plantId)
        {
            if (cnfg == null)
                return false;
            try
            {
                if (!cnfg.HasFile)
                {
                    System.IO.FileNotFoundException cnfgEx = new System.IO.FileNotFoundException("Configuration File Missing", cnfg.FilePath);
                    throw cnfgEx;
                }
                #region Get The plant Data
                PlantConfigElement ExwoldPlant = null;
                //Access the <ExwoldPlant> section of the settings file
                ExwoldPlantSection exwoldplants = cnfg.GetSection("ExwoldPlant") as ExwoldPlantSection;
                foreach (PlantConfigElement plant in exwoldplants.plants)
                {
                    if (plant.Id == plantId)
                    {
                        //We have a plant with a matching ID
                        ExwoldPlant = plant;
                    }
                }
                if (ExwoldPlant == null)
                {
                    //No plant found
                    return false;
                }
                #endregion
                #region Plant data located
                //Set the class variables to the collections found
                _plantName = ExwoldPlant.Name;
                _productionLines = ExwoldPlant.ProductionLines;
                _palletLabelPrinters = ExwoldPlant.PalletLabelPrinters;
                _outerPacklblPrinters = ExwoldPlant.OuterPackLabelPrinters;
                _innerPackLabelPrinters = ExwoldPlant.InnerPackLabelPrinters;
                _standAloneSanners = ExwoldPlant.StandAloneScanners;
                _handHeldScanners = ExwoldPlant.HandHeldScanners;
                #endregion
            }
            catch (System.IO.FileNotFoundException ex)
            {
                StringBuilder msg = new StringBuilder(Logging.ThisMethod());
                msg.AppendLine("CONFIGURATION FILE EXCEPTION");
                msg.AppendLine(ex.Message);
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, msg.ToString());
            }
            catch (Exception ex)
            {
                StringBuilder msg = new StringBuilder(Logging.ThisMethod());
                msg.AppendLine("EXCEPTION");
                msg.AppendLine(ex.Message);
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, msg.ToString());
            }
            //All of good
            return true;
        }

        internal bool Save()
        {
            try
            {
                _cnfg.Save();
            }
            catch (Exception ex)
            {
                StringBuilder msg = new StringBuilder(Logging.ThisMethod());
                msg.AppendLine("CONFIGURATION FILE EXCEPTION");
                msg.AppendLine("Failed to save the settings");
                msg.AppendLine(ex.Message);
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, msg.ToString()); return false;
            }
            return true;
        }

    }
    #region Custom Attributes
    /// <summary>
    /// A Custom attribute to flag the properties that are included in the configuration file
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class ConfigurationData : System.Attribute
    {
        string name;

        internal ConfigurationData(string name)
        {
            this.name = name;
        }
        internal string GetName()
        {
            return name;
        }
    }
    #endregion
    #region Configuration File Section
    internal class ExwoldPlantSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        internal PlantCollection plants
        {
            get
            {
                PlantCollection plantCollection = (PlantCollection)base[""];
                return plantCollection;
            }
        }
    }
    #endregion
    #region Configuration File Element Collections
    /// <summary>
    /// The collection of <plant></plant> elements
    /// </summary>
    internal class PlantCollection : ConfigurationElementCollection
    {
        internal PlantCollection()
        {
            PlantConfigElement details = (PlantConfigElement)CreateNewElement();
            if (details.Id != 0)
            {
                Add(details);
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new PlantConfigElement();
        }
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((PlantConfigElement)element).Id;
        }
        internal PlantConfigElement this[int index]
        {
            get
            {
                return (PlantConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        new internal PlantConfigElement this[string name]
        {
            get
            {
                return (PlantConfigElement)BaseGet(name);
            }
        }
        internal int IndexOf(PlantConfigElement details)
        {
            return BaseIndexOf(details);
        }
        internal void Add(PlantConfigElement details)
        {
            BaseAdd(details);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
        internal void Remove(PlantConfigElement details)
        {
            if (BaseIndexOf(details) >= 0)
                BaseRemove(details.Id);
        }
        internal void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        internal void Remove(string name)
        {
            BaseRemove(name);
        }
        internal void Clear()
        {
            BaseClear();
        }
        protected override string ElementName
        {
            get { return "plant"; }
        }
    }
    internal class ProductionLineCollection : ConfigurationElementCollection
    {
        internal ProductionLineConfigElement this[int index]
        {
            get { return (ProductionLineConfigElement)BaseGet(index); }
        }

        internal int IndexOf(int id)
        {
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id == id)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProductionLineConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProductionLineConfigElement)element).Id;
        }
        protected override string ElementName
        {
            get { return "line"; }
        }
    }


    internal class PalletLabelPrinterCollection : ConfigurationElementCollection
    {
        internal PalletLabelPrinterConfigElement this[int index]
        {
            get { return (PalletLabelPrinterConfigElement)BaseGet(index); }
        }
        internal int IndexOf(int id)
        {
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id == id)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new PalletLabelPrinterConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PalletLabelPrinterConfigElement)element).Id;
        }
        protected override string ElementName
        {
            get { return "printer"; }
        }
    }
    internal class OuterPackLabelPrinterCollection : ConfigurationElementCollection
    {
        internal OuterPackLabelPrinterConfigElement this[int index]
        {
            get { return (OuterPackLabelPrinterConfigElement)BaseGet(index); }
        }
        internal int IndexOf(int id)
        {
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id == id)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new OuterPackLabelPrinterConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((OuterPackLabelPrinterConfigElement)element).Id;
        }
        protected override string ElementName
        {
            get { return "printer"; }
        }
    }
    internal class InnerPackLabelPrinterCollection : ConfigurationElementCollection
    {
        internal InnerPackLabelPrinterConfigElement this[int index]
        {
            get { return (InnerPackLabelPrinterConfigElement)BaseGet(index); }
        }
        internal int IndexOf(int id)
        {
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id == id)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new InnerPackLabelPrinterConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((InnerPackLabelPrinterConfigElement)element).Id;
        }
        protected override string ElementName
        {
            get { return "printer"; }
        }
    }
    internal class StandAloneScannerCollection : ConfigurationElementCollection
    {
        internal StandAloneScannerConfigElement this[int index]
        {
            get { return (StandAloneScannerConfigElement)BaseGet(index); }
        }
        internal int IndexOf(int id)
        {
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id == id)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new StandAloneScannerConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((StandAloneScannerConfigElement)element).Id;
        }
        protected override string ElementName
        {
            get { return "scanner"; }
        }
    }
    internal class HandHeldScannerCollection : ConfigurationElementCollection
    {
        internal HandHeldScannerConfigElement this[int index]
        {
            get { return (HandHeldScannerConfigElement)BaseGet(index); }
        }
        internal int IndexOf(int id)
        {
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id == id)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new HandHeldScannerConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HandHeldScannerConfigElement)element).Id;
        }
        protected override string ElementName
        {
            get { return "scanner"; }
        }
    }
    #endregion
    #region Configuration File Element Definitions
    internal class baseConfigElement : ConfigurationElement
    {
        internal baseConfigElement() { }

        internal baseConfigElement(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        [ConfigurationProperty("id", IsRequired = true, IsKey = true, DefaultValue = 1)]
        [IntegerValidator(MinValue = 1, MaxValue = 65536)]
        [ConfigurationData("id")]
        internal int Id
        {
            get { return (int)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true, DefaultValue = "")]
        [ConfigurationData("name")]
        internal string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
    }
    /// <summary>
    /// Contents of one <plant></plant> Element
    /// </summary>
    internal class PlantConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, DefaultValue = 0)]
        [IntegerValidator(MinValue = 0, MaxValue = 3)]
        internal int Id
        {
            get { return (int)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        //Mesh Plant Name with spaces
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        internal string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("ProductionLines", IsDefaultCollection = false)]
        internal ProductionLineCollection ProductionLines
        {
            get { return (ProductionLineCollection)base["ProductionLines"]; }
        }

        [ConfigurationProperty("PalletLabelPrinters", IsDefaultCollection = false)]
        internal PalletLabelPrinterCollection PalletLabelPrinters
        {
            get { return (PalletLabelPrinterCollection)base["PalletLabelPrinters"]; }
        }

        [ConfigurationProperty("OuterPackLabelPrinters", IsDefaultCollection = false)]
        internal OuterPackLabelPrinterCollection OuterPackLabelPrinters
        {
            get { return (OuterPackLabelPrinterCollection)base["OuterPackLabelPrinters"]; }
        }

        [ConfigurationProperty("InnerPackLabelPrinters", IsDefaultCollection = false)]
        internal InnerPackLabelPrinterCollection InnerPackLabelPrinters
        {
            get { return (InnerPackLabelPrinterCollection)base["InnerPackLabelPrinters"]; }
        }

        [ConfigurationProperty("StandAloneScanners", IsDefaultCollection = false)]
        internal StandAloneScannerCollection StandAloneScanners
        {
            get { return (StandAloneScannerCollection)base["StandAloneScanners"]; }
        }

        [ConfigurationProperty("HandHeldScanners", IsDefaultCollection = false)]
        internal HandHeldScannerCollection HandHeldScanners
        {
            get { return (HandHeldScannerCollection)base["HandHeldScanners"]; }
        }
    }
    internal class ProductionLineConfigElement : baseConfigElement
    {
        internal ProductionLineConfigElement() { }
        internal ProductionLineConfigElement(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        //
        // Override ToString so we can bind the class to a ComboBox\ListBox
        //
        public override string ToString() { return this.Name; }
    }
    internal class PalletLabelPrinterConfigElement : baseConfigElement
    {
        internal PalletLabelPrinterConfigElement() { }
        internal PalletLabelPrinterConfigElement(int id, string name, string ipaddr, int prodline)
        {
            this.Id = id;
            this.Name = name;
            this.IpAddr = ipaddr;
            this.ProductionLine = prodline;
        }

        [ConfigurationProperty("ipaddr", IsRequired = false)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        [ConfigurationData("")]
        internal string IpAddr
        {
            get { return (string)this["ipaddr"]; }
            set { this["ipaddr"] = value; }
        }
        [ConfigurationProperty("prodline", IsRequired = false, DefaultValue = 1)]
        [IntegerValidator(MinValue = 0, MaxValue = 4)]
        [ConfigurationData("")]
        internal int ProductionLine
        {
            get { return (int)this["prodline"]; }
            set { this["prodline"] = value; }
        }
    }
    internal class OuterPackLabelPrinterConfigElement : baseConfigElement
    {
        internal OuterPackLabelPrinterConfigElement() { }
        internal OuterPackLabelPrinterConfigElement(int id, string name, string ipaddr)
        {
            this.Id = id;
            this.Name = name;
            this.IpAddr = ipaddr;
        }

        [ConfigurationProperty("ipaddr", IsRequired = false)]
        [ConfigurationData("")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        internal string IpAddr
        {
            get { return (string)this["ipaddr"]; }
            set { this["ipaddr"] = value; }
        }
    }
    internal class InnerPackLabelPrinterConfigElement : baseConfigElement
    {
        internal InnerPackLabelPrinterConfigElement() { }
        internal InnerPackLabelPrinterConfigElement(int id, string name, string ipaddr)
        {
            this.Id = id;
            this.Name = name;
            this.IpAddr = ipaddr;
        }

        [ConfigurationProperty("ipaddr", IsRequired = false)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        [ConfigurationData("")]
        internal string IpAddr
        {
            get { return (string)this["ipaddr"]; }
            set { this["ipaddr"] = value; }
        }
    }
    internal class StandAloneScannerConfigElement : baseConfigElement
    {
        internal StandAloneScannerConfigElement() { }
        internal StandAloneScannerConfigElement(int id, string name, string ipaddr, int port, int prodline)
        {
            this.Id = id;
            this.Name = name;
            this.IpAddr = ipaddr;
            this.Port = port;
            this.ProductionLine = prodline;
        }

        [ConfigurationProperty("ipaddr", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        [ConfigurationData("")]
        internal string IpAddr
        {
            get { return (string)this["ipaddr"]; }
            set { this["ipaddr"] = value; }
        }

        [ConfigurationProperty("port", IsRequired = false)]
        //[IntegerValidator(MinValue = 1, MaxValue = 65536)]
        [ConfigurationData("")]
        internal int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }
        [ConfigurationProperty("prodline", IsRequired = false, DefaultValue = 1)]
        [IntegerValidator(MinValue = 0, MaxValue = 99)]
        [ConfigurationData("")]
        internal int ProductionLine
        {
            get { return (int)this["prodline"]; }
            set { this["prodline"] = value; }
        }

        [ConfigurationProperty("condition", IsRequired = false, DefaultValue = "active")]
        [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 5, MaxLength = 10)]
        [ConfigurationData("")]
        internal string Condition
        {
            get { return (string)this["condition"]; }
            set { this["condition"] = value; }
        }
        [ConfigurationProperty("scanrate", IsRequired = false, DefaultValue = 1000)]
        [IntegerValidator(MinValue = 50, MaxValue = 10000)]
        [ConfigurationData("")]
        internal int ScanRate
        {
            get { return (int)this["scanrate"]; }
            set { this["scanrate"] = value; }
        }



    }
    internal class HandHeldScannerConfigElement : baseConfigElement
    {
        internal HandHeldScannerConfigElement() { }
        internal HandHeldScannerConfigElement(int id, string name, string ipaddr, int port, int prodline)
        {
            this.Id = id;
            this.Name = name;
            this.IpAddr = ipaddr;
            this.Port = port;
            this.ProductionLine = prodline;
        }

        [ConfigurationProperty("ipaddr", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        [ConfigurationData("")]
        internal string IpAddr
        {
            get { return (string)this["ipaddr"]; }
            set { this["ipaddr"] = value; }
        }

        [ConfigurationProperty("port", IsRequired = false)]
        //[IntegerValidator(MinValue = 1, MaxValue = 65536)]
        [ConfigurationData("")]
        internal int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("prodline", IsRequired = false, DefaultValue = 1)]
        [IntegerValidator(MinValue = 0, MaxValue = 99)]
        [ConfigurationData("")]
        internal int ProductionLine
        {
            get { return (int)this["prodline"]; }
            set { this["prodline"] = value; }
        }

        [ConfigurationProperty("condition", IsRequired = false, DefaultValue = "active")]
        [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\",MinLength = 5, MaxLength = 6)]
        [ConfigurationData("")]
        internal string Condition
        {
            get { return (string)this["condition"]; }
            set { this["condition"] = value; }
        }
    }
    #endregion
    #endregion
}
