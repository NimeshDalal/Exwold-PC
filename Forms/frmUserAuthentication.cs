/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmUserAuthentication.cs
 * Description: Provides interface for userauthentication.
 *              Sets the Operator, Supervisor, and/or Administrator flags
 *              if the user authenticates and is in these LOCAL groups:
 *              ExwoldOperators
 *              ExwoldSupervisors
 *              ExwoldAdministrators
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         702678      04Apr2017   Martin Cox
 *              Initial Creation
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Security.Principal;
using System.DirectoryServices;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using System.DirectoryServices.AccountManagement;
using System.Collections;

namespace ITS.Exwold.Desktop
{
    /// <summary>
    /// User Authentication form 
    /// </summary>
    public partial class UserAuthentication : Form
    {
        public bool Operator   = false;
        public bool Supervisor = false;
        public bool Administrator = false;

        private string LoggedInUserName = string.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserAuthentication()
        {
            InitializeComponent();
            // Set the form parameters
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = true;
            this.Icon = Properties.Resources.ExwoldApp;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ControlBox = true;
            this.HelpButton = false;

            LoggedInUserName = WindowsIdentity.GetCurrent().Name;
            tbUsername.Text = LoggedInUserName;
        }

        private bool ValidateUserNamePasswd()
        {
            bool bRtn = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                // try/catch is needed for Local groups, but we don't need to handle the exception (just treat as not authenticated)
                try
                {
                    bRtn = context.ValidateCredentials(tbUsername.Text, tbPassword.Text);
                }
                catch { bRtn = false; }
            }
            Debug.WriteLine($"PWD check Elapsed time {sw.Elapsed.TotalSeconds}");
            return bRtn;
        }



        /// <summary>
        /// Check user group membership using Diectory Services
        /// This is MUCH faster than Group Principals
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private bool UserInGroupDS(string userName, string groupName)
        {
            bool bRtn = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (userName.StartsWith(Environment.MachineName))
            {
                userName = userName.Remove(0, Environment.MachineName.Length + 1);
            }

            using (DirectoryEntry machine = new DirectoryEntry($"WinNT://{Environment.MachineName}"))
            {
                using (DirectoryEntry group = machine.Children.Find(groupName, "Group"))
                {
                    var members = group.Invoke("Members", null);
                    foreach (var member in (IEnumerable)members)
                    {
                        string accountName = new DirectoryEntry(member).Name;
                        // Test for the usernam, but make it case insensitive
                        if (accountName.ToUpper() == userName.ToUpper())
                        {
                            bRtn = true;
                            break;
                        }
                    }
                }
            }
            return bRtn;
        }

        /// <summary>
        /// Check Group membership using Group Principals
        /// This is v. slow (but works)
        /// </summary>
        /// <returns></returns>
        private bool UserInGroupPrincipals()
        {
            bool bRtn = false;
            CheckingLabel.Text = "Password OK. Checking Permissions";
            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(context, tbUsername.Text))
                {
                    PrincipalSearchResult<Principal> results = user.GetAuthorizationGroups();
                    Debug.WriteLine($"Got Results Elapsed time {sw.Elapsed.TotalSeconds}");


                    foreach (Principal p in results)
                    {
                        Debug.WriteLine($"Name is {p.Name}");
                    }

                    // loop through groups, and set flags if required
                    foreach (GroupPrincipal group in results)
                    {
                        switch (group.Name)
                        {
                            case "ExwoldOperators":
                                Operator = true;
                                break;
                            case "ExwoldSupervisors":
                                Debug.WriteLine("I am in ExwoldSupervisors");
                                Supervisor = true;
                                break;
                            case "ExwoldAdministrators":
                                Administrator = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                Debug.WriteLine($"Grp Check Elapsed time {sw.Elapsed.TotalSeconds}");
                return bRtn;
            }
        }


        private void OkButton_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            CheckingLabel.Text = "Validating Username/Password";
            CheckingLabel.Visible = true;
            this.Refresh();


            PrincipalContext mycontext = null;
            try
            {
                //Check the un\pw combination is valie
                if (ValidateUserNamePasswd())
                {
                    CheckingLabel.Text = "Password OK. Checking Permissions";
                    Refresh();
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    //Now get the group memberships
                    Operator = UserInGroupDS(tbUsername.Text, "ExwoldOperators");
                    Supervisor = UserInGroupDS(tbUsername.Text, "ExwoldSupervisors");
                    Administrator = UserInGroupDS(tbUsername.Text, "ExwoldAdministrators");

                    chkAdmin.Checked = Administrator;
                    chkSupervisor.Checked = Supervisor;
                    chkOperator.Checked = Operator;

                    Debug.WriteLine($"Grp Check Elapsed time {sw.Elapsed.TotalSeconds}");                    
                    //Close();
                    
                }
                else
                {
                    MessageBox.Show("Incorrect Username/password. Please try again.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                if (mycontext != null) { mycontext.Dispose(); }
            }
            btnOK.Enabled = true;
            CheckingLabel.Visible = false;
            this.Refresh();
        }


        /// <summary>
        /// Close Button handler, just close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// On Enter: select all text so it's overwritten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsernameTextbox_Enter(object sender, EventArgs e)
        {
            tbUsername.SelectionStart = 0;
            tbUsername.SelectionLength = tbUsername.Text.Length;

        }

        /// <summary>
        /// On Enter: select all text so it's overwritten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordTextbox_Enter(object sender, EventArgs e)
        {
            tbPassword.SelectionStart = 0;
            tbPassword.SelectionLength = tbUsername.Text.Length;
        }


        #region Simulation
        private void EnableSimulation()
        {
#if DEBUG
            grpSimulate.Visible = true;
#else
            grpSimulate.Visible = false;
#endif
        }


        private void btnSimulate_Click(object sender, EventArgs e)
        {
            Operator = chkOperator.Checked;
            Administrator = chkAdmin.Checked;
            Supervisor = chkSupervisor.Checked;
            this.Close();
        }
        #endregion
    }
}
