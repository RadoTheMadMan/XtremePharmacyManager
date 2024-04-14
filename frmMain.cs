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
        static frmSearchUsers userssearchform;
        static frmSearchDeliveryServices deliveryservicessearchform;
        static frmSearchPaymentMethods paymentmethodssearchform;
        static frmSearchProductBrands productbrandssearchform;
        static frmSearchProducts productssearchform;
        static frmSearchProductOrders orderssearchform;
        static frmSearchOrderDeliveries orderdeliveriessearchform;
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
                    if (userssearchform == null)
                    {
                        userssearchform = new frmSearchUsers(entities);
                        userssearchform.MdiParent = this;
                        userssearchform.FormClosed += Usersearchform_FormClosed;
                        userssearchform.Show();
                    }
                    else
                    {
                        userssearchform.WindowState = FormWindowState.Normal;
                        userssearchform.Activate();
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
            userssearchform = null;
        }

        private void tsmenuTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void tsmenuDeliveryServices_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (deliveryservicessearchform == null)
                    {
                        deliveryservicessearchform = new frmSearchDeliveryServices(entities);
                        deliveryservicessearchform.MdiParent = this;
                        deliveryservicessearchform.FormClosed += Deliveryservicessearchform_FormClosed;
                        deliveryservicessearchform.Show();
                    }
                    else
                    {
                        deliveryservicessearchform.WindowState = FormWindowState.Normal;
                        deliveryservicessearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Deliveryservicessearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            deliveryservicessearchform = null;
        }

        private void tsmenuPaymentMethods_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (paymentmethodssearchform == null)
                    {   
                        paymentmethodssearchform = new frmSearchPaymentMethods(entities);
                        paymentmethodssearchform.MdiParent = this;
                        paymentmethodssearchform.FormClosed += Paymentmethodssearchform_FormClosed;
                        paymentmethodssearchform.Show();
                    }   
                    else
                    {  
                        paymentmethodssearchform.WindowState = FormWindowState.Normal;
                        paymentmethodssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Paymentmethodssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            paymentmethodssearchform = null;
        }

        private void tsmenuProductBrands_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (productbrandssearchform == null)
                    {   
                        productbrandssearchform = new frmSearchProductBrands(entities);
                        productbrandssearchform.MdiParent = this;
                        productbrandssearchform.FormClosed += Productbrandssearchform_FormClosed;
                        productbrandssearchform.Show();
                    }    
                    else 
                    {    
                        productbrandssearchform.WindowState = FormWindowState.Normal;
                        productbrandssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Productbrandssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            productbrandssearchform = null;
        }

        private void tsmenuProducts_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (productssearchform == null)
                    {
                        productssearchform = new frmSearchProducts(entities);
                        productssearchform.MdiParent = this;
                        productssearchform.FormClosed += Productssearchform_FormClosed;
                        productssearchform.Show();
                    }
                    else
                    {
                        productssearchform.WindowState = FormWindowState.Normal;
                        productssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Productssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            productssearchform = null;
        }

        private void tsmenuProductOrders_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (orderssearchform == null)
                    {
                        orderssearchform = new frmSearchProductOrders(entities);
                        orderssearchform.MdiParent = this;
                        orderssearchform.FormClosed += Orderssearchform_FormClosed;
                        orderssearchform.Show();
                    }
                    else
                    {
                        orderssearchform.WindowState = FormWindowState.Normal;
                        orderssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Orderssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderssearchform = null;
        }

        private void tsmenuOrderDeliveries_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (orderdeliveriessearchform == null)
                    {
                        orderdeliveriessearchform = new frmSearchOrderDeliveries(entities);
                        orderdeliveriessearchform.MdiParent = this;
                        orderdeliveriessearchform.FormClosed += Orderdeliveriessearchform_FormClosed;
                        orderdeliveriessearchform.Show();
                    }
                    else
                    {
                        orderdeliveriessearchform.WindowState = FormWindowState.Normal;
                        orderdeliveriessearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Orderdeliveriessearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderdeliveriessearchform = null;
        }

    }
}

