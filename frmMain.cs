using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;

namespace XtremePharmacyManager
{
    public partial class frmMain : Form
    {
        static Entities entities;
        static string connString = "";
        static frmSearchUsers usersearchform;
        public frmMain()
        {
            InitializeComponent();
            InitializeEntities(out entities);
            TestConnection();
        }

        private void TestConnection()
        {
            try
            {
                if (entities != null)
                {
                    if (entities.Database.Connection.State != ConnectionState.Open)
                    {
                        entities.Database.Connection.Open();
                    }
                    if (entities.Database.Connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Connection successfuly open.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEntities(out Entities target)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            try
            {
                scsb.DataSource = ConfigurationSettings.AppSettings["domain"];
                scsb.InitialCatalog = ConfigurationSettings.AppSettings["dbname"];
                scsb.UserID = ConfigurationSettings.AppSettings["dbuser"];
                scsb.Password = ConfigurationSettings.AppSettings["dbpassword"];
                scsb.IntegratedSecurity = true;
                connString = scsb.ConnectionString;
                esb.Metadata = $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.csdl|"+
                               $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.ssdl|"+
                               $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.msl";
                esb.Provider = "System.Data.SqlClient";
                esb.ProviderConnectionString = connString;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}","Critical Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            target = new Entities(esb);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void tsmenuUsers_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (usersearchform == null)
                    {
                        usersearchform = new frmSearchUsers(entities);
                        usersearchform.MdiParent = this;
                        usersearchform.Show();
                    }
                    else
                    {
                        if (usersearchform.MdiParent == this)
                        {
                            usersearchform.Activate();
                            usersearchform.FormClosed += Usersearchform_FormClosed;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Usersearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            usersearchform = null;
        }

        private void tsmenuTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }
    }
}
