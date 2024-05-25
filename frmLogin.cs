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

        public User ResultingUser { get { return user_result; } }
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
                        MessageBox.Show("Successfully found your credentials by the configuration settings of your application.\nOn your confirmation by logging in/clicking ok this will be the user you will work with.\nIf you want another user select from the logins list.\nEvery login is saved into the filesystem in a binary format read only this program.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No user found with the specified credentials by your application configuration.\nPlease configure the application with database credentials from your system administrator or create an user with the stored procedures and set it as a sysadmin if you are a system administrator and try again.\nThe admin role for the database is different from the sysadmin role and this is for security reasons.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txtUsername.Text = GLOBAL_RESOURCES.DB_USER;
                txtPassword.Text = GLOBAL_RESOURCES.DB_PASSWORD;
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

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(retrieved_users != null)
            {
                retrieved_users.Clear();
                retrieved_users = null;
            }
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
                            MessageBox.Show("Successfully found the user.\nNow the connection string will be set up to work with these credentials and the application will reconnect.\nPlease be patient...\n", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //close, rebuild the connection string and try to reconnect
                            ent.Database.Connection.Close();
                            scsb.DataSource = GLOBAL_RESOURCES.DOMAIN_ADDRESS;
                            scsb.InitialCatalog = GLOBAL_RESOURCES.DB_NAME;
                            scsb.UserID = txtUsername.Text;
                            scsb.Password = txtPassword.Text;
                            scsb.IntegratedSecurity = true;
                            connString = scsb.ConnectionString;
                            esb.Metadata = $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.csdl|" +
                                           $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.ssdl|" +
                                           $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.msl";
                            esb.Provider = "System.Data.SqlClient";
                            esb.ProviderConnectionString = connString;
                            ent = new Entities(esb);
                            ent.Database.Connection.Open();
                            if(ent.Database.Connection.State == ConnectionState.Open)
                            {
                                MessageBox.Show("Successful connection with the credentials.\nNow you are logged in and can proceed.\nPress OK to continue.\n", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("With valid login credentials you were supposed to be connected but you aren't.\nPlease contact the administrator of your database to check the server.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No user found with the specified credentials by your application configuration.\nPlease configure the application with database credentials from your system administrator or create an user with the stored procedures and set it as a sysadmin if you are a system administrator and try again.\nThe admin role for the database is different from the sysadmin role and this is for security reasons.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

       
