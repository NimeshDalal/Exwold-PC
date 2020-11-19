/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsAzureHelper.cs
 *              Helper functions for connecting to and writing to the Azure database
 *              
 * Description: Logging helper
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              Initial Release
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS.Security.Encryption;
using System.Diagnostics;
using System.Data;
using RestSharp;

namespace ITS.Exwold.Desktop
{
    internal static class AzureHelper
    {
        /// <summary>
        /// Go to the configuration file, and extract the connection parameters
        /// decoding them if required
        /// Expecting:
        /// UseCloud (true - use the Azure settings, false - use local)
        /// LocalURI, AzureURI - base Uri strings
        /// FunctionName - function name to execute
        /// FunctionKey - the security code to execute the function
        /// </summary>
        /// <param name="pSec">Security Parameters, used to decrypt the seettings</param>
        /// <returns>The Azure connection parameters</returns>
        internal static AzureParams GetAzureParams(SecurityParams pSec)
        {
            AzureParams pAzure = new AzureParams();
            //Open the default configuration file and get the Connectivity section
            ConnectivitySection section = ConnectivitySection.Open();
            foreach (ConnectivityConfigElement ele in section.settings)
            {
                switch (ele.Name)
                {
                    case "UseCloud":
                        pAzure.UseCloud = bool.Parse(readConnectivitySetting(ele, pSec));
                        break;
                    case "LocalURI":
                        pAzure.LocalUri = readConnectivitySetting(ele, pSec);
                        break;
                    case "AzureURI":
                        pAzure.AzureUri = readConnectivitySetting(ele, pSec);
                        break;
                    case "FunctionKey":
                        pAzure.FunctionKey = readConnectivitySetting(ele, pSec);
                        break;
                    case "FunctionName":
                        pAzure.FunctionName = readConnectivitySetting(ele, pSec);
                        break;
                    default:
                        continue;
                }
            }
            return pAzure;
        }

        /// <summary>
        /// Takes a section element, and returned it's decrypted value
        /// </summary>
        /// <param name="ele">ConfigurationElement</param>
        /// <param name="password">decrypt password</param>
        /// <param name="payload">decrypt payload</param>
        /// <returns>Plain text of the element contents</returns>
        private static string readConnectivitySetting(ConnectivityConfigElement ele, SecurityParams p)
        {
            string sRtn = string.Empty;
            if (ele == null) throw new ArgumentNullException("The ConfigurationElement is null");

            //It an error occurs the decrypt error should bubble through
            try
            {
                if (ele.Encrypted)
                {
                    //Decrypt
                    sRtn = AESThenHMAC.SimpleDecryptWithPassword(ele.Value, p.Password, p.bPayload.Length);
                }
                else
                {
                    sRtn = ele.Value;
                }
            }
            catch
            { throw; }
            return sRtn;
        }

        /// <summary>
        /// Encrypts and save the Connectivity data, and return the security parameters user
        /// </summary>
        /// <param name="password">Encryption password</param>
        /// <param name="payload">Encryption payload</param>
        /// <returns>secuity parameters class</returns>
        internal static bool enctryptionConnectivitySettings(SecurityParams p)
        {
            if (p == null)
            { throw new ArgumentNullException("Security Parameters missing"); }

            bool bSettingsChanged = false;
            ConnectivitySection section = null;
            try
            {
                //Open the default configuration file and get the Connectivity section
                section = ConnectivitySection.Open();
            }
            catch (Exception ex)
            {
                throw new System.IO.FileNotFoundException("Error opening the configuration file", ex);
            }

            if (section == null) return false;

            try
            {
                //Check if the encryption flag is set, if not secure the values
                foreach (ConnectivityConfigElement ele in section.settings)
                {
                    if (!ele.Encrypted)
                    {
                        bSettingsChanged = true;
                        ele.Value = AESThenHMAC.SimpleEncryptWithPassword(ele.Value, p.Password, p.bPayload);
                        ele.Encrypted = true;
                    }
                }
            }
            catch
            {
                //Rethrow the error
                throw;
            }
            try
            {
                if (bSettingsChanged)
                {
                    //Save the changes to the settings file
                    section.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving the configuration file", ex);
            }
            return true;
        }

        #region SQL Calls
        /// <summary>
        /// Runs a web URL function
        /// Add the function key to the parameter list, and then calls either
        /// a POST or GET method as requested in the AzureParams
        /// </summary>
        /// <param name="pAzure">The URL base URI, function name and function code</param>
        /// <param name="spParams">The parameters to pass the URL</param>
        /// <returns></returns>
        internal static async Task<string> executeSQL(AzureParams pAzure, Dictionary<string, string> spParams)
        {
            string uri = string.Empty;
            if (pAzure == null) { throw new ArgumentNullException("pAzure", "Azure connection parameters not provided");  }
            if (spParams == null) { throw new ArgumentNullException("spParams", "SQL parameters not provided"); }


            //Build the approriate Uri
            if (pAzure.UseCloud)
            {
                uri = $"{pAzure.AzureUri}{pAzure.FunctionName}";
            }
            else
            {
                uri = $"{pAzure.LocalUri}{pAzure.FunctionName}";
            }
            //and add the code parameter
            spParams = insertParameterAtStart("code", pAzure.FunctionKey, spParams);
            //spParams = AddCodeParameter(pAzure.FunctionKey, spParams);

            //JSon return 
            string sqlReturn = string.Empty;

            try
            {
                if (pAzure.UseGET)
                { sqlReturn = await GetAsync(uri, spParams); }
                else
                { sqlReturn = await PostAsync(uri, spParams); }
            }
            catch (System.Net.WebException webex)
            {
                Debug.WriteLine(webex.Message);
                throw new System.Net.WebException("executeSQL", webex);
            }
            catch
            {
                throw;
            }
            return sqlReturn;
        }

        /// <summary>
        /// Executes a GET call to the URI described in the Azure parameters,
        /// with a specific parameter list
        /// </summary>
        /// <param name="Uri">The Uri to call</param>
        /// <param name="spParams">The function parameters to execute</param>
        /// <returns></returns>
        internal static async Task<string> GetAsync(string Uri, Dictionary<string, string> spParams)
        {
            string strContent = string.Empty;   //Content string
            //Build the Uri with the parameters
            UriBuilder uriBuild = new UriBuilder(Uri);
            // Create the client
            RestClient client = new RestClient(uriBuild.Uri);
            // Create the request and add parameters to it
            RestRequest request = new RestRequest(Method.GET);
            foreach (string key in spParams.Keys)
            {
                request.AddParameter(key, spParams[key]);
            }
            IRestResponse response = await client.ExecuteAsync(request);

            try
            {
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    //De-serialise the response content         
                    try
                    {
                        strContent = SimpleJson.DeserializeObject<string>(response.Content);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Deserialise error: {ex.Message}");
                    }
                }
                else
                {
                    Debug.WriteLine($"Response: {response.ResponseStatus.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error: {ex.Message}");
            }

            return strContent;
        }
        /// <summary>
        /// Executes a POST call to the URI described in the Azure parameters,
        /// with a specific parameter list
        /// </summary>
        /// <param name="Uri">The Uri to call</param>
        /// <param name="spParams">The function parameters to execute</param>
        /// <returns></returns>
        internal static async Task<string> PostAsync(string Uri, Dictionary<string, string> spParams)
        {
            string strContent = string.Empty;   //Content string
            //Build the Uri with the parameters
            UriBuilder uriBuild = new UriBuilder(Uri);
            uriBuild.Query = BuildParameterString(spParams);
            // Create the client
            RestClient client = new RestClient(uriBuild.Uri);
            // Create the request and add parameters to it
            RestRequest request = new RestRequest(Method.POST);
            IRestResponse response = await client.ExecuteAsync(request);

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(spParams, Formatting.None);
            try
            {
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    //De-serialise the response content         
                    try
                    {
                        if (!response.IsSuccessful)
                        {

                            return response.StatusDescription;
                        }
                        else
                        {
                            strContent = SimpleJson.DeserializeObject<string>(response.Content);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Deserialise error: {ex.Message}");
                    }
                }
                else
                {
                    Debug.WriteLine($"Response: {response.ResponseStatus.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error: {ex.Message}");
            }
            return strContent;
        }


        #endregion


        #region SQL Helpers
        private static string BuildParameterString(Dictionary<string, string> data)
        {
            StringBuilder postData = new StringBuilder();
            foreach (string key in data.Keys)
            {
                postData.Append(key);
                //postData.Append(System.Net.WebUtility.UrlEncode(key));
                postData.Append("=");
                postData.Append(data[key]);
                //postData.Append(System.Net.WebUtility.UrlEncode(data[key]));
                postData.Append("&");
            }
            return postData.ToString();
        }
        
        internal static Dictionary<string, string> insertParameterAtStart(string pName, string pValue, Dictionary<string, string> spParamsOrig)
        {
            if (string.IsNullOrEmpty(pName)) throw new ArgumentNullException("pName");
            if (string.IsNullOrEmpty(pName)) throw new ArgumentNullException("pValue");

            Dictionary<string, string> spParams = new Dictionary<string, string>();
            //Add the code parameter to the parameter list
            spParams.Add(pName, pValue);
            if (spParamsOrig != null)
            {
                foreach (string key in spParamsOrig.Keys)
                {
                    spParams.Add(key, spParamsOrig[key]);
                }
            }
            return spParams;
        }
        //internal static Dictionary<string, string> AddCodeParameter(string authenticationCode, Dictionary<string, string> spParamsOrig)
        //{
        //    Dictionary<string, string> spParams = new Dictionary<string, string>();
        //    //Add the code parameter to the parameter list
        //    spParams.Add("code", authenticationCode);
        //    foreach (string key in spParamsOrig.Keys)
        //    {
        //        spParams.Add(key, spParamsOrig[key]);
        //    }
        //    return spParams;
        //}
        #endregion
    }

    /// <summary>
    /// Class to hold the Azure BaseURI, name of the function to call, and it's execute key
    /// and the type of call to make.  Default call type is POST
    /// </summary>
    internal class AzureParams
    {
        #region Private variables
        private bool _useCloud = false;
        private string _localuri = string.Empty;

        private string _azureuri = string.Empty;
        private string _functionname = string.Empty;
        private string _functionkey = string.Empty;
        private bool _useGET = false;
        #endregion

        #region Properties
        internal bool UseCloud { get { return _useCloud; } set { _useCloud = value; } }
        internal string LocalUri { get { return _localuri; } set { _localuri = value; } }

        internal string AzureUri { get { return _azureuri; } set { _azureuri = value; } }
        internal string FunctionName { get { return _functionname; } set { _functionname = value; } }
        internal string FunctionKey { get { return _functionkey; } set { _functionkey = value; } }
        internal bool UseGET { get { return _useGET; } set { _useGET = value; } }
        #endregion
    }

    internal class SecurityParams
    {
        #region Private variables
        private string _password = string.Empty;
        private string _payload = string.Empty;
        #endregion

        #region Properties
        internal string Password { get { return _password; } set { _password = value; } }
        internal string PayLoad { get { return _payload; } set { _payload = value; } }
        internal byte[] bPayload { get { return Encoding.UTF8.GetBytes(_payload); } }
        #endregion
    }
}
