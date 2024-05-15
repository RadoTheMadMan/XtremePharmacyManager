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
        static frmBulkUserOperations bulkUserOperationsform;
        static frmBulkProductBrandOperations bulkProductBrandOperationsform;
        static frmBulkPaymentMethodOperations bulkPaymentMethodOperationsform;
        static frmBulkDeliveryServiceOperations bulkDeliveryServiceOperationsform;
        static frmBulkProductOperations bulkProductOperationsform;
        static frmBulkProductImageOperations bulkProductImageOperationsform;
        static frmBulkProductOrderOperations bulkProductOrderOperationsform;
        static frmBulkOrderDeliveryOperations bulkOrderDeliveryOperationsform;
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_SUCCESSFUL_MESSAGE}", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEntities(out Entities target)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            try
            {
                scsb.DataSource = GLOBAL_RESOURCES.DOMAIN_ADDRESS;
                scsb.InitialCatalog = GLOBAL_RESOURCES.DB_NAME; ;
                scsb.UserID = GLOBAL_RESOURCES.DB_USER;
                scsb.Password = GLOBAL_RESOURCES.DB_PASSWORD;
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}",$"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            target = new Entities(esb);
        }

        private void InitializeLogger(ref Entities ent, out Logger target)
        {
            target = new Logger(ref ent);
        }

        private void InitializeBulkManagers()
        {
            bulkUserOperationManager = new BulkOperationManager<User>(ref entities);
            bulkProductBrandOperationManager = new BulkOperationManager<ProductBrand>(ref entities);
            bulkPaymentMethodOperationManager = new BulkOperationManager<PaymentMethod>(ref entities);
            bulkDeliveryServiceOperationManager = new BulkOperationManager<DeliveryService>(ref entities);
            bulkProductOperationManager = new BulkOperationManager<Product>(ref entities);
            bulkProductImageOperationManager = new BulkOperationManager<ProductImage>(ref entities);
            bulkProductOrderOperationManager = new BulkOperationManager<ProductOrder>(ref entities);
            bulkOrderDeliveryOperationManager = new BulkOperationManager<OrderDelivery>(ref entities);
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
                        userssearchform = new frmSearchUsers(ref entities, ref logger, ref bulkUserOperationManager);
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
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        deliveryservicessearchform = new frmSearchDeliveryServices(ref entities, ref logger, ref bulkDeliveryServiceOperationManager);
                        deliveryservicessearchform.MdiParent = this;
                        deliveryservicessearchform.Dock = DockStyle.Fill;
                        deliveryservicessearchform.FormClosed += Deliveryservicessearchform_FormClosed;
                        deliveryservicessearchform.Show();
                    }
                    else
                    {
                        deliveryservicessearchform.WindowState = FormWindowState.Normal;
                        deliveryservicessearchform.Dock = DockStyle.Fill;
                        deliveryservicessearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        paymentmethodssearchform = new frmSearchPaymentMethods(ref entities, ref logger, ref bulkPaymentMethodOperationManager);
                        paymentmethodssearchform.MdiParent = this;
                        paymentmethodssearchform.Dock = DockStyle.Fill;
                        paymentmethodssearchform.FormClosed += Paymentmethodssearchform_FormClosed;
                        paymentmethodssearchform.Show();
                    }   
                    else
                    {  
                        paymentmethodssearchform.WindowState = FormWindowState.Normal;
                        paymentmethodssearchform.Dock = DockStyle.Fill;
                        paymentmethodssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        productbrandssearchform = new frmSearchProductBrands(ref entities, ref logger, ref bulkProductBrandOperationManager);
                        productbrandssearchform.MdiParent = this;
                        productbrandssearchform.Dock = DockStyle.Fill;
                        productbrandssearchform.FormClosed += Productbrandssearchform_FormClosed;
                        productbrandssearchform.Show();
                    }    
                    else 
                    {    
                        productbrandssearchform.WindowState = FormWindowState.Normal;
                        productbrandssearchform.Dock = DockStyle.Fill;
                        productbrandssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        productssearchform = new frmSearchProducts(ref entities, ref logger, ref bulkProductOperationManager, ref bulkProductImageOperationManager);
                        productssearchform.MdiParent = this;
                        productssearchform.Dock = DockStyle.Fill;
                        productssearchform.FormClosed += Productssearchform_FormClosed;
                        productssearchform.Show();
                    }
                    else
                    {
                        productssearchform.WindowState = FormWindowState.Normal;
                        productssearchform.Dock = DockStyle.Fill;
                        productssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        orderssearchform = new frmSearchProductOrders(ref entities, ref logger, ref bulkProductOrderOperationManager);
                        orderssearchform.MdiParent = this;
                        orderssearchform.Dock = DockStyle.Fill;
                        orderssearchform.FormClosed += Orderssearchform_FormClosed;
                        orderssearchform.Show();
                    }
                    else
                    {
                        orderssearchform.WindowState = FormWindowState.Normal;
                        orderssearchform.Dock = DockStyle.Fill;
                        orderssearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        orderdeliveriessearchform = new frmSearchOrderDeliveries(ref entities, ref logger, ref bulkOrderDeliveryOperationManager);
                        orderdeliveriessearchform.MdiParent = this;
                        orderdeliveriessearchform.Dock = DockStyle.Fill;
                        orderdeliveriessearchform.FormClosed += Orderdeliveriessearchform_FormClosed;
                        orderdeliveriessearchform.Show();
                    }
                    else
                    {
                        orderdeliveriessearchform.WindowState = FormWindowState.Normal;
                        orderdeliveriessearchform.Dock = DockStyle.Fill;
                        orderdeliveriessearchform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        logsform.Dock = DockStyle.Fill;
                        logsform.FormClosed += Logsform_FormClosed;
                        logsform.Show();
                    }
                    else
                    {
                        logsform.WindowState = FormWindowState.Normal;
                        logsform.Dock = DockStyle.Fill;
                        logsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        imgbinform.Dock = DockStyle.Fill;
                        imgbinform.FormClosed += Imgbinform_FormClosed;
                        imgbinform.Show();
                    }
                    else
                    {
                        imgbinform.WindowState = FormWindowState.Normal;
                        imgbinform.Dock = DockStyle.Fill;
                        imgbinform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if(bulkUserOperationsform != null)
                    {
                        bulkUserOperationsform.Close();
                    }
                    if(bulkProductBrandOperationsform != null)
                    {
                        bulkProductBrandOperationsform.Close();
                    }
                    if(bulkPaymentMethodOperationsform != null)
                    {
                        bulkPaymentMethodOperationsform.Close();
                    }
                    if(bulkDeliveryServiceOperationsform != null)
                    {
                        bulkDeliveryServiceOperationsform.Close();
                    }
                    if(bulkProductOperationsform != null)
                    {
                        bulkProductOperationsform.Close();
                    }
                    if(bulkProductImageOperationsform != null)
                    {
                        bulkProductImageOperationsform.Close();
                    }
                    if(bulkProductOrderOperationsform!= null)
                    {
                        bulkProductOrderOperationsform.Close();
                    }
                    if(bulkOrderDeliveryOperationsform != null)
                    {
                        bulkOrderDeliveryOperationsform.Close();
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
                if(bulkUserOperationManager != null)
                {
                    bulkUserOperationManager = null;
                }
                if(bulkUserOperationsform != null)
                {
                    bulkUserOperationsform = null;
                }
                if(bulkProductBrandOperationManager != null)
                {
                    bulkProductBrandOperationManager = null;
                }
                if(bulkPaymentMethodOperationManager != null)
                {
                    bulkPaymentMethodOperationManager = null;
                }
                if(bulkDeliveryServiceOperationManager != null)
                {
                    bulkDeliveryServiceOperationManager = null;
                }
                if(bulkProductOperationManager != null)
                {
                    bulkProductOperationManager = null;
                }
                if(bulkProductImageOperationManager != null)
                {
                    bulkProductImageOperationManager = null;
                }
                if(bulkProductOrderOperationManager != null)
                {
                    bulkProductOrderOperationManager = null;
                }
                if(bulkOrderDeliveryOperationManager != null)
                {
                    bulkOrderDeliveryOperationManager = null;
                }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmenuBulkUserOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkUserOperationsform == null)
                    {
                        bulkUserOperationsform = new frmBulkUserOperations(ref bulkUserOperationManager);
                        bulkUserOperationsform.MdiParent = this;
                        bulkUserOperationsform.Dock = DockStyle.Fill;
                        bulkUserOperationsform.FormClosed += bulkUserOperationsform_FormClosed;
                        bulkUserOperationsform.Show();
                    }
                    else
                    {
                        bulkUserOperationsform.WindowState = FormWindowState.Normal;
                        bulkUserOperationsform.Dock = DockStyle.Fill;
                        bulkUserOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkUserOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkUserOperationsform = null;
        }

        private void tsmenuBulkProductBrandOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkProductBrandOperationsform == null)
                    {
                        bulkProductBrandOperationsform = new frmBulkProductBrandOperations(ref bulkProductBrandOperationManager);
                        bulkProductBrandOperationsform.MdiParent = this;
                        bulkProductBrandOperationsform.Dock = DockStyle.Fill;
                        bulkProductBrandOperationsform.FormClosed += bulkProductBrandOperationsform_FormClosed;
                        bulkProductBrandOperationsform.Show();
                    }
                    else
                    {
                        bulkProductBrandOperationsform.WindowState = FormWindowState.Normal;
                        bulkProductBrandOperationsform.Dock = DockStyle.Fill;
                        bulkProductBrandOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkProductBrandOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductBrandOperationsform = null;
        }

        private void tsmenuBulkPaymentMethodOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkPaymentMethodOperationsform == null)
                    {
                        bulkPaymentMethodOperationsform = new frmBulkPaymentMethodOperations(ref bulkPaymentMethodOperationManager);
                        bulkPaymentMethodOperationsform.MdiParent = this;
                        bulkPaymentMethodOperationsform.Dock = DockStyle.Fill;
                        bulkPaymentMethodOperationsform.FormClosed += bulkPaymentMethodOperationsform_FormClosed;
                        bulkPaymentMethodOperationsform.Show();
                    }
                    else
                    {
                        bulkPaymentMethodOperationsform.WindowState = FormWindowState.Normal;
                        bulkPaymentMethodOperationsform.Dock = DockStyle.Fill;
                        bulkPaymentMethodOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkPaymentMethodOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkPaymentMethodOperationsform = null;
        }

        private void tsmenuBulkDeliveryServiceOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkDeliveryServiceOperationsform == null)
                    {
                        bulkDeliveryServiceOperationsform = new frmBulkDeliveryServiceOperations(ref bulkDeliveryServiceOperationManager);
                        bulkDeliveryServiceOperationsform.MdiParent = this;
                        bulkDeliveryServiceOperationsform.Dock = DockStyle.Fill;
                        bulkDeliveryServiceOperationsform.FormClosed += bulkDeliveryServiceOperationsform_FormClosed;
                        bulkDeliveryServiceOperationsform.Show();
                    }
                    else
                    {
                        bulkDeliveryServiceOperationsform.WindowState = FormWindowState.Normal;
                        bulkDeliveryServiceOperationsform.Dock = DockStyle.Fill;
                        bulkDeliveryServiceOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkDeliveryServiceOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkDeliveryServiceOperationsform = null;
        }

        private void tsmenuBulkProductOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkProductOperationsform == null)
                    {
                        bulkProductOperationsform = new frmBulkProductOperations(ref bulkProductOperationManager);
                        bulkProductOperationsform.MdiParent = this;
                        bulkProductOperationsform.Dock = DockStyle.Fill;
                        bulkProductOperationsform.FormClosed += bulkProductOperationsform_FormClosed;
                        bulkProductOperationsform.Show();
                    }
                    else
                    {
                        bulkProductOperationsform.WindowState = FormWindowState.Normal;
                        bulkProductOperationsform.Dock = DockStyle.Fill;
                        bulkProductOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkProductOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductOperationsform = null;
        }

        private void tsmenuBulkProductImageOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkProductImageOperationsform == null)
                    {
                        bulkProductImageOperationsform = new frmBulkProductImageOperations(ref bulkProductImageOperationManager);
                        bulkProductImageOperationsform.MdiParent = this;
                        bulkProductImageOperationsform.Dock = DockStyle.Fill;
                        bulkProductImageOperationsform.FormClosed += bulkProductImageOperationsform_FormClosed;
                        bulkProductImageOperationsform.Show();
                    }
                    else
                    {
                        bulkProductImageOperationsform.WindowState = FormWindowState.Normal;
                        bulkProductImageOperationsform.Dock = DockStyle.Fill;
                        bulkProductImageOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkProductImageOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductImageOperationsform = null;
        }

        private void tsmenuBulkProductOrderOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkProductOrderOperationsform == null)
                    {
                        bulkProductOrderOperationsform = new frmBulkProductOrderOperations(ref bulkProductOrderOperationManager);
                        bulkProductOrderOperationsform.MdiParent = this;
                        bulkProductOrderOperationsform.Dock = DockStyle.Fill;
                        bulkProductOrderOperationsform.FormClosed += bulkProductOrderOperationsform_FormClosed;
                        bulkProductOrderOperationsform.Show();
                    }
                    else
                    {
                        bulkProductOrderOperationsform.WindowState = FormWindowState.Normal;
                        bulkProductOrderOperationsform.Dock = DockStyle.Fill;
                        bulkProductOrderOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkProductOrderOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductOrderOperationsform = null;
        }

        private void tsmenuBulkOrderDeliveryOperations_Click(object sender, EventArgs e)
        {
            if (entities.Database.Connection.State == ConnectionState.Open)
            {
                try
                {
                    if (bulkOrderDeliveryOperationsform == null)
                    {
                        bulkOrderDeliveryOperationsform = new frmBulkOrderDeliveryOperations(ref bulkOrderDeliveryOperationManager);
                        bulkOrderDeliveryOperationsform.MdiParent = this;
                        bulkOrderDeliveryOperationsform.Dock = DockStyle.Fill;
                        bulkOrderDeliveryOperationsform.FormClosed += bulkOrderDeliveryOperationsform_FormClosed;
                        bulkOrderDeliveryOperationsform.Show();
                    }
                    else
                    {
                        bulkOrderDeliveryOperationsform.WindowState = FormWindowState.Normal;
                        bulkOrderDeliveryOperationsform.Dock = DockStyle.Fill;
                        bulkOrderDeliveryOperationsform.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bulkOrderDeliveryOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkOrderDeliveryOperationsform = null;
        }
    }
}

