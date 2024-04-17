using System;
using System.Collections;
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
using XtremePharmacyManager.Properties.DataSources;

namespace XtremePharmacyManager
{
    public partial class frmMain : Form
    {
        static Entities entities;
        static Logger logger;
        static BulkOperationManager<User> bulkUserOperationManager;
        static BulkOperationManager<ProductBrand> bulkProductBrandOperationManager;
        static BulkOperationManager<PaymentMethod> bulkPaymentMethodOperationManager;
        static BulkOperationManager<DeliveryService> bulkDeliveryServiceOperationManager;
        static BulkOperationManager<Product> bulkProductOperationManager;
        static BulkOperationManager<ProductImage> bulkProductImageOperationManager;
        static BulkOperationManager<ProductOrder> bulkProductOrderOperationManager;
        static BulkOperationManager<OrderDelivery> bulkOrderDeliveryOperationManager;
        static string connString = "";
        static frmSearchUsers userssearchform;
        static frmSearchDeliveryServices deliveryservicessearchform;
        static frmSearchPaymentMethods paymentmethodssearchform;
        static frmSearchProductBrands productbrandssearchform;
        static frmSearchProducts productssearchform;
        static frmSearchProductOrders orderssearchform;
        static frmSearchOrderDeliveries orderdeliveriessearchform;
        static frmLogs logsform;
        static frmImageBinConverter imgbinform;
        public frmMain()
        {
            InitializeComponent();
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}",$"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            target = new Entities(esb);
        }

        private void InitializeLogger(ref Entities ent, out Logger target)
        {
            target = new Logger(ref ent);
        }

        private void InitializeBulkManagers()
        {
            bulkUserOperationManager = new BulkOperationManager<User>();
            bulkProductBrandOperationManager = new BulkOperationManager<ProductBrand>();
            bulkPaymentMethodOperationManager = new BulkOperationManager<PaymentMethod>();
            bulkDeliveryServiceOperationManager = new BulkOperationManager<DeliveryService>();
            bulkProductOperationManager = new BulkOperationManager<Product>();
            bulkProductImageOperationManager = new BulkOperationManager<ProductImage>();
            bulkProductOrderOperationManager = new BulkOperationManager<ProductOrder>();
            bulkOrderDeliveryOperationManager = new BulkOperationManager<OrderDelivery>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //moved these here so it constructs and loads faster
            InitializeEntities(out entities);
            InitializeLogger(ref entities, out logger);
            InitializeBulkManagers();
            TestConnection();
        }



        private void tsmenuUsers_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (userssearchform == null)
                    {
                        userssearchform = new frmSearchUsers(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        deliveryservicessearchform = new frmSearchDeliveryServices(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        paymentmethodssearchform = new frmSearchPaymentMethods(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        productbrandssearchform = new frmSearchProductBrands(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        productssearchform = new frmSearchProducts(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        orderssearchform = new frmSearchProductOrders(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        orderdeliveriessearchform = new frmSearchOrderDeliveries(ref entities, ref logger);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Orderdeliveriessearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderdeliveriessearchform = null;
        }

        private void tsmenuLogs_Click(object sender, EventArgs e)
        {

            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (logsform == null)
                    {
                        logsform = new frmLogs(ref logger);
                        logsform.MdiParent = this;
                        logsform.FormClosed += Logsform_FormClosed;
                        logsform.Show();
                    }
                    else
                    {
                        logsform.WindowState = FormWindowState.Normal;
                        logsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Logsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            logsform = null;
        }

        private void tsmenuBitmapToBinary_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (imgbinform == null)
                    {
                        imgbinform = new frmImageBinConverter();
                        imgbinform.MdiParent = this;
                        imgbinform.FormClosed += Imgbinform_FormClosed;
                        imgbinform.Show();
                    }
                    else
                    {
                        imgbinform.WindowState = FormWindowState.Normal;
                        imgbinform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Imgbinform_FormClosed(object sender, FormClosedEventArgs e)
        {
            imgbinform = null;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult res = MessageBox.Show($"{GLOBAL_RESOURCES.CLOSE_PROMPT}", $"{GLOBAL_RESOURCES.CLOSE_PROMPT_TITLE}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (userssearchform != null)
                    {
                        userssearchform = null;
                    }
                    if (deliveryservicessearchform != null)
                    {
                        deliveryservicessearchform.Close();
                    }
                    if (paymentmethodssearchform != null)
                    {
                        paymentmethodssearchform.Close();
                    }
                    if (productbrandssearchform != null)
                    {
                        productbrandssearchform.Close();
                    }
                    if (productssearchform != null)
                    {
                        productssearchform.Close();
                    }
                    if (orderssearchform != null)
                    {
                        orderssearchform.Close();
                    }
                    if (orderdeliveriessearchform != null)
                    {
                        orderdeliveriessearchform.Close();
                    }
                    if (logsform != null)
                    {
                        logsform.Close();
                    }
                    if (imgbinform != null)
                    {
                        imgbinform.Close();
                    }
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (logger != null)
                {
                    logger = null;
                }
                if (entities != null)
                {
                    if (entities.Database.Connection.State == ConnectionState.Open)
                    {
                        entities.Database.Connection.Close();
                    }
                    entities = null;
                }
                if (userssearchform != null)
                {
                    userssearchform = null;
                }
                if (deliveryservicessearchform != null)
                {
                    deliveryservicessearchform = null;
                }
                if (paymentmethodssearchform != null)
                {
                    paymentmethodssearchform = null;
                }
                if (productbrandssearchform != null)
                {
                    productbrandssearchform = null;
                }
                if(productssearchform!= null);
                {
                    productssearchform = null;
                }
                if(orderssearchform != null)
                {
                    orderssearchform = null;
                }
                if(orderdeliveriessearchform != null)
                {
                    orderdeliveriessearchform = null;
                }
                if(logsform != null)
                {
                    logsform = null;
                }
                if (imgbinform != null)
                {
                    imgbinform = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

