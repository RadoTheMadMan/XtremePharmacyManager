using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void tsmenuUsers_Click(object sender, EventArgs e)
        {
            //Test to see if the users will be mapped correctly to the data columns
            List<User> users;
            frmSearchUsers usersform;
            string connstring = "";
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.ConnectTimeout = 1000;
            sb.DataSource = ".";
            sb.InitialCatalog = "XTremePharmacyDB";
            sb.UserID = "default";
            sb.Password = "123456";
            connstring = sb.ToString();
            try
            {
                using (Entities entities = new Entities())
                {
                    users = entities.GetUser(-1, "", "", "", new DateTime(), new DateTime(), "", "", "", balance, "", new DateTime(), new DateTime(), 0).ToList();
                    usersform = new frmSearchUsers(users);
                    usersform.MdiParent = this;
                    usersform.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An exception occured: {ex.Message}\nStack Trace: {ex.StackTrace}", "Critical Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
