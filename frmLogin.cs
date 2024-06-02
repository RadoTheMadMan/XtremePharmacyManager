using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static XtremePharmacyManager.ImageBinConverter;
namespace XtremePharmacyManager
{
    public partial class frmLogin : Form
    {
        static User current_user;
        User retrieved_user;
        static List<User> retrieved_users;
        static List<User> last_logins;
        static Entities ent;
        User user_result;
        string connection_string = "";

        public User ResultingUser { get { return user_result; } }
        public string ConnectionString { get { return connection_string; } }
        public frmLogin(ref Entities entities, ref List<User> last_login_list)
        {
            InitializeComponent();
            ent = entities;
            last_logins = last_login_list;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                lstLastLogins.DataSource = last_logins;
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    //retrieve list with in the beginning with the credentials for the database
                    retrieved_users = ent.Users.Where(x => (x.UserName.Equals(GLOBAL_RESOURCES.DB_USER) && x.UserPassword.Equals(GLOBAL_RESOURCES.DB_PASSWORD))).ToList();
                    if ((String.IsNullOrEmpty(GLOBAL_RESOURCES.DB_USER) && String.IsNullOrEmpty(GLOBAL_RESOURCES.DB_PASSWORD)) || retrieved_users.Count > 1)
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (retrieved_users.Count == 1)
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE}", $"{GLOBAL_RESOURCES.LOGIN_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txtUsername.Text = GLOBAL_RESOURCES.DB_USER;
                txtPassword.Text = GLOBAL_RESOURCES.DB_PASSWORD;
                btnLogin.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void btnSetCurrentLoginAsDefault_Click(object sender, EventArgs e)
        {
            var configfile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configfile.AppSettings.Settings["dbuser"].Value = txtUsername.Text;
            configfile.AppSettings.Settings["dbpassword"].Value = txtPassword.Text;
            configfile.Save(ConfigurationSaveMode.Modified);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            string connString = "";
            try {
                //first check if it is open
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    if (ent.Database.Connection.State == ConnectionState.Open)
                    {
                        //retrieve list with in the beginning with the credentials for the database
                        retrieved_users = ent.Users.Where(x => (x.UserName.Equals(txtUsername.Text) && x.UserPassword.Equals(txtPassword.Text))).ToList();
                        if ((String.IsNullOrEmpty(txtUsername.Text) && String.IsNullOrEmpty(txtPassword.Text)) || retrieved_users.Count > 1)
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (retrieved_users.Count == 1)
                        {
                            user_result = retrieved_users.FirstOrDefault();
                            //close, rebuild the connection string and try to reconnect
                            ent.Database.Connection.Close();
                            scsb.DataSource = GLOBAL_RESOURCES.DOMAIN_ADDRESS;
                            scsb.InitialCatalog = GLOBAL_RESOURCES.DB_NAME;
                            scsb.UserID = txtUsername.Text;
                            scsb.Password = txtPassword.Text;
                            scsb.IntegratedSecurity = false;
                            connString = scsb.ConnectionString;
                            esb.Metadata = $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.csdl|" +
                                           $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.ssdl|" +
                                           $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.msl";
                            esb.Provider = "System.Data.SqlClient";
                            esb.ProviderConnectionString = connString;
                            connection_string = esb.ConnectionString;
                        }
                        else
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_INVALID_INPUT_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstLastLogins_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selected_record = (User)lstLastLogins.SelectedItem;
            if(selected_record != null)
            {
                txtUsername.Text = selected_record.UserName;
                txtPassword.Text = selected_record.UserPassword;
            }
        }

        private void btnClearLogins_Click(object sender, EventArgs e)
        {
            if (last_logins != null)
            {
                last_logins.Clear();
                lstLastLogins.DataSource = null;
                lstLastLogins.DataSource = last_logins;
            }
        }

        private void btnAddLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (last_logins != null)
                {
                    if (ent.Database.Connection.State == ConnectionState.Open)
                    {
                        if (ent.Users.Where(x => (x.UserName.Contains(txtUsername.Text) && x.UserPassword.Contains(txtPassword.Text))).Any() &&
                            ent.Users.Where(x => (x.UserName.Contains(txtUsername.Text) && x.UserPassword.Contains(txtPassword.Text))).ToList().Count == 1)
                        {
                            User target_login = ent.Users.Where(x => (x.UserName.Contains(txtUsername.Text) && x.UserPassword.Contains(txtPassword.Text))).FirstOrDefault();
                            last_logins.Add(target_login);
                        }
                        else
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            ent.Database.Connection.Open();
                            if(ent.Database.Connection.State != ConnectionState.Open)
                            {
                                MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_FAILED_AFTER_RETRY_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    lstLastLogins.DataSource = null;
                    lstLastLogins.DataSource = last_logins;
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (last_logins != null)
                {
                   if(last_logins.Count > 0 && lstLastLogins.SelectedItem != null && last_logins.Contains((User)lstLastLogins.SelectedItem))
                    {
                        int index = last_logins.IndexOf((User)lstLastLogins.SelectedItem);
                        last_logins.RemoveAt(index);
                    }
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lstLastLogins.DataSource=null;
                lstLastLogins.DataSource = last_logins;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

       
