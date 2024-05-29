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
                        MessageBox.Show("Seems like you are the system administrator for the database and you have either disabled or bypassed the logon trigger and that's why you were probably connected even if you didn't have credentials to connect to the database.\nThis might damage the system and enabling the trigger is critical.\nThis is an important warning because " +
                            "the system is at risk of data breach in multiple ways.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (retrieved_users.Count == 1)
                    {
                        MessageBox.Show("Successfully found your credentials by the configuration settings of your application.\nOn your confirmation by logging in this will be the user you will work with.\nIf you want another user select from the logins list.\nEvery login is saved into the filesystem in a binary format read only this program.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No user found with the specified credentials by your application configuration.\nPlease configure the application with database credentials provided by your system administrator or create an user with the stored procedures and set it as a sysadmin if you are a system administrator and try again.\nThe admin role for the database is different from the sysadmin role and this is for security reasons.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Seems like you didn't provide any login information at all.\nPlease try again.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("No user found with the specified credentials by your input.\nPlease input the credentials you registered with or provided by your system administrator.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show($"Multiple login results gotten or none at all.\nPlease check the credentials and try again", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show($"Application is not connected to the database and login information cannot be retrieved.\nPlease retry.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            ent.Database.Connection.Open();
                            if(ent.Database.Connection.State != ConnectionState.Open)
                            {
                                MessageBox.Show($"Connection failed.\nApplication will exit.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    lstLastLogins.DataSource = null;
                    lstLastLogins.DataSource = last_logins;
                }
                else
                {
                    MessageBox.Show($"Saved Logins list hasn't been retrieved properly.\nPlease restart the application.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Saved Logins list hasn't been retrieved properly .\nPlease restart the application.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       
