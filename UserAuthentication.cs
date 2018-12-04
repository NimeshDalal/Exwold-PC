//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
//  Provides interface for userauthentication.
//  Sets the Operator, Supervisor, and/or Administrator flags
//  if the user authenticates and is in these LOCAL groups:
//      ExwoldOperators
//      ExwoldSupervisors
//      ExwoldAdministrators
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Martin Cox 
//          Initial Creation
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.DirectoryServices.AccountManagement;

namespace ExwoldPcInterface
{
    /// <summary>
    /// User Authentication form 
    /// </summary>
    public partial class UserAuthentication : Form
    {
        public bool Operator   = false;
        public bool Supervisor = false;
        public bool Administrator = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserAuthentication()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OK Button handler, check username & password match, if they do then check local group membership
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            OkButton.Enabled = false;
            CheckingLabel.Visible = true;
            this.Refresh();

            bool validUsernamePasswordCombination = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))    //checks local machine first
            {
                // try/catch is needed for Local groups, but we don't need to handle the exception (just treat as not authenticated)
                try
                {
                    validUsernamePasswordCombination = context.ValidateCredentials(UsernameTextbox.Text, PasswordTextbox.Text);
                }
                catch { }

                if (validUsernamePasswordCombination)
                {
                    // username & password match, so check group membership
                    PrincipalContext domain = new PrincipalContext(ContextType.Machine);
                    UserPrincipal user = UserPrincipal.FindByIdentity(domain, UsernameTextbox.Text);

                    // loop through groups, and set flags if required
                    foreach (GroupPrincipal group in user.GetAuthorizationGroups())
                    {
                        switch (group.Name)
                        {
                            case "ExwoldOperators":
                                Operator = true;
                                break;
                            case "ExwoldSupervisors":
                                Supervisor = true;
                                break;
                            case "ExwoldAdministrators":
                                Administrator = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (Operator || Supervisor || Administrator)
                    {
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Username/password. Please try again.");
                }
            }

            OkButton.Enabled = true;
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
        /// On Enter: select all test so it's overwritten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsernameTextbox_Enter(object sender, EventArgs e)
        {
            UsernameTextbox.SelectionStart = 0;
            UsernameTextbox.SelectionLength = UsernameTextbox.Text.Length;

        }

        /// <summary>
        /// On Enter: select all test so it's overwritten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordTextbox_Enter(object sender, EventArgs e)
        {
            PasswordTextbox.SelectionStart = 0;
            PasswordTextbox.SelectionLength = UsernameTextbox.Text.Length;
        }

    }
}
