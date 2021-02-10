/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsDataInterface.cs
 * Description: Provides the interface for the application external data
 *              Data is usually obtained from the Azure cloud (using HTTP requests) 
 *              OR if DEBUGGING directly from a SQL database
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
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop.DataInterface
{
    public class execFunction
    {
        private AzureParams _pAzure = null;
        private Dictionary<string, string> _queryParameters = new Dictionary<string, string>();
        #region Properties

        internal Dictionary<string, string> QueryParameters
        {
            get { return _queryParameters; }
            set { _queryParameters = value; }
        }

        #endregion
        #region Constructor
        internal execFunction(AzureParams azureParams)
        {
            _pAzure = azureParams;
        }
        #endregion

        #region ExecuteSP
        /// <summary>
        /// Execute a stored procedure without parameters
        /// </summary>
        /// <param name="spName">Stored Procedure to execute</param>
        /// <returns>A datatable of the results</returns>
        public Task<DataTable> executeSP(string spName)
        {
            return executeSP(spName, null);
        }
        /// <summary>
        /// Execute a stored procedure using the local parameter dictionary
        /// </summary>
        /// <param name="spName">Stored Procedure to execute</param>
        /// <param name="hasParameters">True - User the local QueryParameters</param>
        /// <returns>A datatable of the results</returns>
        public Task<DataTable> executeSP(string spName, bool hasParameters)
        {
            if (!hasParameters) { _queryParameters.Clear(); }
            return executeSP(spName, _queryParameters);
        }
        /// <summary>
        /// Executes a stored procedure with parameters
        /// </summary>
        /// <param name="spName">Stored Procedure to execute</param>
        /// <param name="spParams">Use the parameters dictionary explicitly passed</param>
        /// <returns>A datatable of the results</returns>
        public async Task<DataTable> executeSP(string spName, Dictionary<string, string>spParams)
        {
            DataSet ds = await getDataSet(spName, spParams);
            if (ds == null) return null;

            if (ds.Tables.Count > 0)
                return ds.Tables[0];

            return null;

            //string strJSON = string.Empty;
            //string uri = string.Empty;
            //DataTable dtResult = new DataTable();


            ////Add the procedure name
            //spParams = AzureHelper.insertParameterAtStart("name", spName, spParams);

            ////Get the result
            //strJSON = await AzureHelper.executeSQL(_pAzure, spParams);
            ////If the result is empty then something went wrong!
            //if (string.IsNullOrWhiteSpace(strJSON)) return null;

            //try
            //{
            //    //Convert the result to a dataset
            //    DataSet dsResult = JsonConvert.DeserializeObject<DataSet>(strJSON);
            //    if (dsResult.Tables.Count > 0)
            //    {
            //        dtResult = dsResult.Tables[0];
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{Logging.ThisMethod()}\nError converting the result to a data table\n{strJSON}\n{ex.Message}");
            //}
            //return dtResult;
        }
        /// <summary>
        /// Execute a stored procedure using the local parameter dictionary
        /// </summary>
        /// <param name="spName">Stored Procedure to execute</param>
        /// <param name="hasParameters">True - User the local QueryParameters</param>
        /// <returns>A dataset of the results</returns>
        public Task<DataSet> getDataSet(string spName, bool hasParameters)
        {
            if (!hasParameters) { _queryParameters.Clear(); }
            return getDataSet(spName, _queryParameters);
        }
        /// <summary>
        /// Executes a stored procedure with parameters
        /// </summary>
        /// <param name="spName">Stored Procedure to execute</param>
        /// <param name="spParams">Use the parameters dictionary explicitly passed</param>
        /// <returns>A dataset of the results</returns>
        public async Task<DataSet> getDataSet(string spName, Dictionary<string, string> spParams)
        {
            string strJSON = string.Empty;
            string uri = string.Empty;
            DataSet dsResult = new DataSet();


            //Add the procedure name
            spParams = AzureHelper.insertParameterAtStart("name", spName, spParams);

            //Get the result
            strJSON = await AzureHelper.executeSQL(_pAzure, spParams);
            //If the result is empty then something went wrong!
            if (string.IsNullOrWhiteSpace(strJSON)) return null;

            try
            {
                //Convert the result to a dataset
                dsResult = JsonConvert.DeserializeObject<DataSet>(strJSON);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Logging.ThisMethod()}\nError converting the result to a data set\n{spName}\n{strJSON}\n{ex.Message}");
                //MessageBox.Show($"{Logging.ThisMethod()}\nError converting the result to a data set\n{spName}\n{strJSON}\n{ex.Message}");
            }
            return dsResult;
        }

        #endregion
    }
}
