﻿using System;
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
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        static BulkOperationManager<ProductVendor> bulkProductVendorOperationManager;
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
        static frmSearchProductVendors productvendorssearchform;
        static frmSearchProducts productssearchform;
        static frmSearchProductOrders orderssearchform;
        static frmSearchOrderDeliveries orderdeliveriessearchform;
        static frmLogs logsform;
        static User currentUser;
        static List<User> last_Logins;
        static frmImageBinConverter imgbinform;
        static frmBulkUserOperations bulkUserOperationsform;
        static frmBulkProductBrandOperations bulkProductBrandOperationsform;
        static frmBulkProductVendorOperations bulkProductVendorOperationsform;
        static frmBulkPaymentMethodOperations bulkPaymentMethodOperationsform;
        static frmBulkDeliveryServiceOperations bulkDeliveryServiceOperationsform;
        static frmBulkProductOperations bulkProductOperationsform;
        static frmBulkProductImageOperations bulkProductImageOperationsform;
        static frmBulkProductOrderOperations bulkProductOrderOperationsform;
        static frmBulkOrderDeliveryOperations bulkOrderDeliveryOperationsform;
        public frmMain()
        {
            InitializeComponent();
            InitializeEntities(out entities);
            InitializeLogger(ref entities, out logger);
            InitializeBulkManagers();
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
                        MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_SUCCESSFUL_MESSAGE}", $"{GLOBAL_RESOURCES.TEST_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_FAILED_MESSAGE}", $"{GLOBAL_RESOURCES.TEST_TITLE}", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            entities.Database.Connection.Open();
                            if (entities.Database.Connection.State != ConnectionState.Open)
                            {
                                MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_FAILED_AFTER_RETRY_MESSAGE}", $"{GLOBAL_RESOURCES.TEST_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
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
                scsb.IntegratedSecurity = false;
                connString = scsb.ConnectionString;
                esb.Metadata = $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.csdl|" +
                               $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.ssdl|" +
                               $"{Application.StartupPath}/DataEntities/XTremePharmacyModel.msl";
                esb.Provider = "System.Data.SqlClient";
                esb.ProviderConnectionString = connString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            target = new Entities(esb);
        }

        private void InitializeEntities(string conn_string, out Entities target)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            try
            {
                esb.ConnectionString = conn_string;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            target = new Entities(esb);
        }

        private void InitializeLogger(ref Entities ent, out Logger target)
        {
            target = new Logger(ref ent, ref currentUser);
        }

        private void InitializeBulkManagers()
        {
            bulkUserOperationManager = new BulkOperationManager<User>(ref entities, ref currentUser);
            bulkProductBrandOperationManager = new BulkOperationManager<ProductBrand>(ref entities, ref currentUser);
            bulkProductVendorOperationManager = new BulkOperationManager<ProductVendor>(ref entities, ref currentUser);
            bulkPaymentMethodOperationManager = new BulkOperationManager<PaymentMethod>(ref entities, ref currentUser);
            bulkDeliveryServiceOperationManager = new BulkOperationManager<DeliveryService>(ref entities, ref currentUser);
            bulkProductOperationManager = new BulkOperationManager<Product>(ref entities, ref currentUser);
            bulkProductImageOperationManager = new BulkOperationManager<ProductImage>(ref entities, ref currentUser);
            bulkProductOrderOperationManager = new BulkOperationManager<ProductOrder>(ref entities, ref currentUser);
            bulkOrderDeliveryOperationManager = new BulkOperationManager<OrderDelivery>(ref entities, ref currentUser);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //moved these here so it constructs and loads faster
                TestConnection();
                //if the connection is successful time to load last logins
                //use binary desearialisation to check for username files in .bin format, this will be hardcoded
                if (CheckOrCreateLoginDirectory())
                {
                    if (!LoadSavedLogins(out last_Logins) && currentUser == null)
                    {
                        //as the function returns true if the logins list is not empty and if the current user is null then this fires up
                        //make a login form and instantiate it, it will be a special one instantiated and closed as a dialog and it will have reference
                        //to the current user so it will apply changes at closing
                        frmLogin loginform = new frmLogin(ref entities, ref last_Logins);
                        DialogResult res = loginform.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            currentUser = loginform.ResultingUser;
                            if (currentUser == null)
                            {
                                MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_NO_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                            else
                            {
                                if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
                                {
                                    InitializeEntities(loginform.ConnectionString, out entities);
                                    InitializeLogger(ref entities, out logger);
                                    InitializeBulkManagers();
                                    if (currentUser.UserRole == 1)
                                    {
                                        tsmenuUsers.Enabled = true;
                                        tsmenuProductBrands.Enabled = true;
                                        tsmenuProductVendors.Enabled = true;
                                        tsmenuPaymentMethods.Enabled = true;
                                        tsmenuDeliveryServices.Enabled = true;
                                        tsmenuProducts.Enabled = true;
                                        tsmenuProductOrders.Enabled = true;
                                        tsmenuOrderDeliveries.Enabled = true;
                                        tsmenuLogs.Enabled = true;
                                        tsmenuBulkUserOperations.Enabled = false;
                                        tsmenuBulkProductBrandOperations.Enabled = false;
                                        tsmenuBulkProductVendorOperations.Enabled = false;
                                        tsmenuBulkPaymentMethodOperations.Enabled = false;
                                        tsmenuBulkDeliveryServiceOperations.Enabled = false;
                                        tsmenuBulkProductOperations.Enabled = false;
                                        tsmenuBulkProductImageOperations.Enabled = true;
                                        tsmenuBulkProductOrderOperations.Enabled = true;
                                        tsmenuBulkOrderDeliveryOperations.Enabled = true;
                                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_EMPLOYEE_NOTICE}", $"{GLOBAL_RESOURCES.LOGIN_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if (currentUser.UserRole == 0)
                                    {
                                        tsmenuUsers.Enabled = true;
                                        tsmenuProductBrands.Enabled = true;
                                        tsmenuProductVendors.Enabled = true;
                                        tsmenuPaymentMethods.Enabled = true;
                                        tsmenuDeliveryServices.Enabled = true;
                                        tsmenuProducts.Enabled = true;
                                        tsmenuProductOrders.Enabled = true;
                                        tsmenuOrderDeliveries.Enabled = true;
                                        tsmenuLogs.Enabled = true;
                                        tsmenuBulkUserOperations.Enabled = true;
                                        tsmenuBulkProductBrandOperations.Enabled = true;
                                        tsmenuBulkProductVendorOperations.Enabled = true;
                                        tsmenuBulkPaymentMethodOperations.Enabled = true;
                                        tsmenuBulkDeliveryServiceOperations.Enabled = true;
                                        tsmenuBulkProductOperations.Enabled = true;
                                        tsmenuBulkProductImageOperations.Enabled = true;
                                        tsmenuBulkProductOrderOperations.Enabled = true;
                                        tsmenuBulkOrderDeliveryOperations.Enabled = true;
                                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_ADMIN_NOTICE}", $"{GLOBAL_RESOURCES.LOGIN_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Application.Exit();
                                }
                                if (last_Logins != null && !last_Logins.Contains(currentUser))
                                {
                                    last_Logins.Add(currentUser);
                                    foreach (var login in last_Logins)
                                    {
                                        entities.Entry(entities.Users.Where(x => x.ID == login.ID).FirstOrDefault()).Reload();
                                        SaveLoginToFileSystem(login);
                                    }
                                }
                                SaveLoginToFileSystem(currentUser);
                            }
                        }
                        else if (res == DialogResult.Cancel)
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (loginform != null)
                            {loginform.Dispose();
                                loginform = null;
                            }
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (loginform != null)
                            {loginform.Dispose();
                                loginform = null;
                            }
                            Application.Exit();
                        }
                    }
                    else
                    {
                        //handle login anyway
                        //as the function returns true if the logins list is not empty and if the current user is null then this fires up
                        //make a login form and instantiate it, it will be a special one instantiated and closed as a dialog and it will have reference
                        //to the current user so it will apply changes at closing
                        frmLogin loginform = new frmLogin(ref entities, ref last_Logins);
                        DialogResult res = loginform.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            currentUser = loginform.ResultingUser;
                            if (currentUser == null)
                            {
                                MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_NO_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                            else
                            {

                                if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
                                {
                                    InitializeEntities(loginform.ConnectionString, out entities);
                                    InitializeLogger(ref entities, out logger);
                                    InitializeBulkManagers();
                                    if (currentUser.UserRole == 1)
                                    {
                                        tsmenuUsers.Enabled = true;
                                        tsmenuProductBrands.Enabled = true;
                                        tsmenuProductVendors.Enabled = true;
                                        tsmenuPaymentMethods.Enabled = true;
                                        tsmenuDeliveryServices.Enabled = true;
                                        tsmenuProducts.Enabled = true;
                                        tsmenuProductOrders.Enabled = true;
                                        tsmenuOrderDeliveries.Enabled = true;
                                        tsmenuLogs.Enabled = true;
                                        tsmenuBulkUserOperations.Enabled = false;
                                        tsmenuBulkProductBrandOperations.Enabled = false;
                                        tsmenuBulkProductVendorOperations.Enabled = false;
                                        tsmenuBulkPaymentMethodOperations.Enabled = false;
                                        tsmenuBulkDeliveryServiceOperations.Enabled = false;
                                        tsmenuBulkProductOperations.Enabled = false;
                                        tsmenuBulkProductImageOperations.Enabled = true;
                                        tsmenuBulkProductOrderOperations.Enabled = true;
                                        tsmenuBulkOrderDeliveryOperations.Enabled = true;
                                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_EMPLOYEE_NOTICE}", $"{GLOBAL_RESOURCES.LOGIN_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if (currentUser.UserRole == 0)
                                    {
                                        tsmenuUsers.Enabled = true;
                                        tsmenuProductBrands.Enabled = true;
                                        tsmenuProductVendors.Enabled = true;
                                        tsmenuPaymentMethods.Enabled = true;
                                        tsmenuDeliveryServices.Enabled = true;
                                        tsmenuProducts.Enabled = true;
                                        tsmenuProductOrders.Enabled = true;
                                        tsmenuOrderDeliveries.Enabled = true;
                                        tsmenuLogs.Enabled = true;
                                        tsmenuBulkUserOperations.Enabled = true;
                                        tsmenuBulkProductBrandOperations.Enabled = true;
                                        tsmenuBulkProductVendorOperations.Enabled = true;
                                        tsmenuBulkPaymentMethodOperations.Enabled = true;
                                        tsmenuBulkDeliveryServiceOperations.Enabled = true;
                                        tsmenuBulkProductOperations.Enabled = true;
                                        tsmenuBulkProductImageOperations.Enabled = true;
                                        tsmenuBulkProductOrderOperations.Enabled = true;
                                        tsmenuBulkOrderDeliveryOperations.Enabled = true;
                                        MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_LOGIN_ADMIN_NOTICE}", $"{GLOBAL_RESOURCES.LOGIN_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Application.Exit();
                                }
                                if (last_Logins != null && !last_Logins.Contains(currentUser))
                                {
                                    last_Logins.Add(currentUser);
                                    foreach (var login in last_Logins)
                                    {
                                        entities.Entry(entities.Users.Where(x => x.ID == login.ID).FirstOrDefault()).Reload();
                                        SaveLoginToFileSystem(login);
                                    }
                                }
                                SaveLoginToFileSystem(currentUser);
                            }
                        }
                        else if (res == DialogResult.Cancel)
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (loginform != null)
                            {loginform.Dispose();
                                loginform = null;
                            }
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show($"{GLOBAL_RESOURCES.AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (loginform != null)
                            {loginform.Dispose();
                                loginform = null;
                            }
                            Application.Exit();
                        }
                    }
                }
                if (entities != null && entities.Database.Connection.State != ConnectionState.Open)
                {
                    entities.Database.Connection.Open();
                    if (entities.Database.Connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_SUCCESSFUL_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.LOGIN_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show($"{GLOBAL_RESOURCES.CONNECTION_FAILED_LOGIN_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            TestConnection();
                        }
                    }
                }
                if (currentUser != null && entities != null)
                {
                    this.Text = $"{System.Diagnostics.Process.GetCurrentProcess().ProcessName} - {GLOBAL_RESOURCES.CURRENT_HOST_TITLE}: {entities.Database.Connection.DataSource} - {GLOBAL_RESOURCES.CURRENT_OPERATOR_TITLE}: {currentUser.UserDisplayName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void tsmenuUsers_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (userssearchform == null)
                        {
                            userssearchform = new frmSearchUsers(ref entities, ref currentUser, ref logger, ref bulkUserOperationManager);
                            userssearchform.MdiParent = this;
                            userssearchform.Dock = DockStyle.Fill;
                            userssearchform.FormClosed += Usersearchform_FormClosed;
                            userssearchform.Show();
                        }
                        else
                        {
                            userssearchform.WindowState = FormWindowState.Normal;
                            userssearchform.Dock = DockStyle.Fill;
                            userssearchform.Activate();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.USER_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usersearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            userssearchform.Dispose();
            userssearchform = null;
        }

        private void tsmenuTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void tsmenuDeliveryServices_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (deliveryservicessearchform == null)
                        {
                            deliveryservicessearchform = new frmSearchDeliveryServices(ref entities, ref currentUser, ref logger, ref bulkDeliveryServiceOperationManager);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Deliveryservicessearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            deliveryservicessearchform.Dispose();
            deliveryservicessearchform = null;
        }

        private void tsmenuPaymentMethods_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (paymentmethodssearchform == null)
                        {
                            paymentmethodssearchform = new frmSearchPaymentMethods(ref entities, ref currentUser, ref logger, ref bulkPaymentMethodOperationManager);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Paymentmethodssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            paymentmethodssearchform.Dispose();
            paymentmethodssearchform = null;
        }

        private void tsmenuProductBrands_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (productbrandssearchform == null)
                        {
                            productbrandssearchform = new frmSearchProductBrands(ref entities, ref currentUser, ref logger, ref bulkProductBrandOperationManager);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BRAND_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Productbrandssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            productbrandssearchform.Dispose();
            productbrandssearchform = null;
        }

        private void tsmenuProducts_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (currentUser.UserRole == 0)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.PRODUCT_MENU_ACCESS_ADMIN_NOTICE}", $"{GLOBAL_RESOURCES.USER_ACCESS_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentUser.UserRole == 1)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.PRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE}", $"{GLOBAL_RESOURCES.USER_ACCESS_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (productssearchform == null)
                        {
                            productssearchform = new frmSearchProducts(ref entities, ref currentUser, ref logger, ref bulkProductOperationManager, ref bulkProductImageOperationManager);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.PRODUCT_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Productssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            productssearchform.Dispose();
            productssearchform = null;
        }

        private void tsmenuProductOrders_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (orderssearchform == null)
                        {
                            orderssearchform = new frmSearchProductOrders(ref entities, ref currentUser, ref logger, ref bulkProductOrderOperationManager);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Orderssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderssearchform.Dispose();
            orderssearchform = null;
        }

        private void tsmenuOrderDeliveries_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (orderdeliveriessearchform == null)
                        {
                            orderdeliveriessearchform = new frmSearchOrderDeliveries(ref entities, ref currentUser, ref logger, ref bulkOrderDeliveryOperationManager);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Orderdeliveriessearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderdeliveriessearchform.Dispose();
            orderdeliveriessearchform = null;
        }

        private void tsmenuLogs_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (logsform == null)
                        {
                            logsform = new frmLogs(ref logger, ref currentUser);
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.LOGS_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Logsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            logsform.Dispose();
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
            imgbinform.Dispose(); 
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
                        userssearchform.Close();
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
                    if (productvendorssearchform != null)
                    {
                        productvendorssearchform.Close();
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
                    userssearchform.Dispose();
                    userssearchform = null;
                }
                if (deliveryservicessearchform != null)
                {
                    deliveryservicessearchform.Dispose();
                    deliveryservicessearchform = null;
                }
                if (paymentmethodssearchform != null)
                {
                    paymentmethodssearchform.Dispose();
                    paymentmethodssearchform = null;
                }
                if (productbrandssearchform != null)
                {
                    productbrandssearchform.Dispose();
                    productbrandssearchform = null;
                }
                if (productvendorssearchform != null)
                {
                    productvendorssearchform.Dispose();
                    productvendorssearchform = null;
                }
                if (productssearchform != null)
                {
                    productssearchform.Dispose();
                    productssearchform = null;
                }
                if(orderssearchform != null)
                {
                    orderssearchform.Dispose();
                    orderssearchform = null;
                }
                if(orderdeliveriessearchform != null)
                {   
                    orderdeliveriessearchform.Dispose();
                    orderdeliveriessearchform = null;
                }
                if(logsform != null)
                {
                    logsform.Dispose();
                    logsform = null;
                }
                if (imgbinform != null)
                {
                    imgbinform.Dispose();
                    imgbinform = null;
                }
                if (bulkUserOperationsform != null)
                {
                    bulkUserOperationsform.Dispose();
                    bulkUserOperationsform = null;
                }
                if (bulkProductBrandOperationsform != null)
                {
                    bulkProductBrandOperationsform.Dispose();
                    bulkProductBrandOperationsform = null;
                }
                if (bulkProductVendorOperationsform != null)
                {
                    bulkProductVendorOperationsform.Dispose();
                    bulkProductVendorOperationsform = null;
                }
                if (bulkPaymentMethodOperationsform != null)
                {
                    bulkPaymentMethodOperationsform.Dispose();
                    bulkPaymentMethodOperationsform = null;
                }
                if (bulkDeliveryServiceOperationsform != null)
                {
                    bulkDeliveryServiceOperationsform.Dispose();
                    bulkDeliveryServiceOperationsform = null;
                }
                if (bulkProductOperationsform != null)
                {
                    bulkProductOperationsform.Dispose();
                    bulkProductOperationsform = null;
                }
                if (bulkProductImageOperationsform != null)
                {
                    bulkProductImageOperationsform.Dispose();
                    bulkProductImageOperationsform = null;
                }
                if (bulkProductOrderOperationsform != null)
                {
                    bulkProductOrderOperationsform.Dispose();
                    bulkProductOrderOperationsform = null;
                }
                if (bulkOrderDeliveryOperationsform != null)
                {
                    bulkOrderDeliveryOperationsform.Dispose();
                    bulkOrderDeliveryOperationsform = null;
                }
                if (bulkUserOperationManager != null)
                {
                    bulkUserOperationManager.Dispose();
                    bulkUserOperationManager = null;
                }
                if(bulkProductBrandOperationManager != null)
                {
                    bulkProductBrandOperationManager.Dispose();
                    bulkProductBrandOperationManager = null;
                }
                if (bulkProductVendorOperationManager != null)
                {
                    bulkProductVendorOperationManager.Dispose();
                    bulkProductVendorOperationManager = null;
                }
                if (bulkPaymentMethodOperationManager != null)
                {
                    bulkPaymentMethodOperationManager.Dispose();
                    bulkPaymentMethodOperationManager = null;
                }
                if(bulkDeliveryServiceOperationManager != null)
                {
                    bulkDeliveryServiceOperationManager.Dispose();
                    bulkDeliveryServiceOperationManager = null;
                }
                if(bulkProductOperationManager != null)
                {
                    bulkProductOperationManager.Dispose();
                    bulkProductOperationManager = null;
                }
                if(bulkProductImageOperationManager != null)
                {
                    bulkProductImageOperationManager.Dispose();
                    bulkProductImageOperationManager = null;
                }
                if(bulkProductOrderOperationManager != null)
                {
                    bulkProductOrderOperationManager.Dispose();
                    bulkProductOrderOperationManager = null;
                }
                if(bulkOrderDeliveryOperationManager != null)
                {
                    bulkOrderDeliveryOperationManager.Dispose();
                    bulkOrderDeliveryOperationManager = null;
                }
                if (logger != null)
                {
                    logger.Dispose();
                    logger = null;
                }
                if (entities != null)
                {
                    if (entities.Database.Connection.State == ConnectionState.Open)
                    {
                        entities.Database.Connection.Close();
                    }
                    entities.Dispose();
                    entities = null;
                }
                if(currentUser != null)
                {
                    currentUser = null;
                }
                if(last_Logins != null)
                {
                    last_Logins.Clear();
                    last_Logins = null;
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmenuBulkUserOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_USER_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkUserOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkUserOperationsform.Dispose();
            bulkUserOperationsform = null;
        }

        private void tsmenuBulkProductBrandOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_BRAND_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkProductBrandOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductBrandOperationsform.Dispose();
            bulkProductBrandOperationsform = null;
        }

        private void tsmenuBulkPaymentMethodOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkPaymentMethodOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkPaymentMethodOperationsform.Dispose();
            bulkPaymentMethodOperationsform = null;
        }

        private void tsmenuBulkDeliveryServiceOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkDeliveryServiceOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkDeliveryServiceOperationsform.Dispose();
            bulkDeliveryServiceOperationsform = null;
        }

        private void tsmenuBulkProductOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkProductOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductOperationsform.Dispose();
            bulkProductOperationsform = null;
        }

        private void tsmenuBulkProductImageOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkProductImageOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductImageOperationsform.Dispose();
            bulkProductImageOperationsform = null;
        }

        private void tsmenuBulkProductOrderOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkProductOrderOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductOrderOperationsform.Dispose();
            bulkProductOrderOperationsform = null;
        }

        private void tsmenuBulkOrderDeliveryOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
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
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkOrderDeliveryOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkOrderDeliveryOperationsform.Dispose();
            bulkOrderDeliveryOperationsform = null;
        }

        private void tsmenuProductVendors_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0 || currentUser.UserRole == 1)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (productvendorssearchform == null)
                        {
                            productvendorssearchform = new frmSearchProductVendors(ref entities, ref currentUser, ref logger, ref bulkProductVendorOperationManager);
                            productvendorssearchform.MdiParent = this;
                            productvendorssearchform.Dock = DockStyle.Fill;
                            productvendorssearchform.FormClosed += Productvendorssearchform_FormClosed;
                            productvendorssearchform.Show();
                        }
                        else
                        {
                            productvendorssearchform.WindowState = FormWindowState.Normal;
                            productvendorssearchform.Dock = DockStyle.Fill;
                            productvendorssearchform.Activate();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.VENDOR_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Productvendorssearchform_FormClosed(object sender, FormClosedEventArgs e)
        {
            productvendorssearchform.Dispose();
            productvendorssearchform = null;
        }

        private void tsmenuBulkProductVendorOperations_Click(object sender, EventArgs e)
        {
            if (currentUser.UserRole == 0)
            {
                if (entities.Database.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        if (bulkProductVendorOperationsform == null)
                        {
                            bulkProductVendorOperationsform = new frmBulkProductVendorOperations(ref bulkProductVendorOperationManager);
                            bulkProductVendorOperationsform.MdiParent = this;
                            bulkProductVendorOperationsform.Dock = DockStyle.Fill;
                            bulkProductVendorOperationsform.FormClosed += bulkProductVendorOperationsform_FormClosed;
                            bulkProductVendorOperationsform.Show();
                        }
                        else
                        {
                            bulkProductVendorOperationsform.WindowState = FormWindowState.Normal;
                            bulkProductVendorOperationsform.Dock = DockStyle.Fill;
                            bulkProductVendorOperationsform.Activate();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.BULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bulkProductVendorOperationsform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bulkProductVendorOperationsform.Dispose();
            bulkProductVendorOperationsform = null;
        }

        public static bool CheckOrCreateLoginDirectory()
        {
            bool result = false;
            try
            {

                if (!Directory.Exists(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY))
                {
                    //create the directory if it doesn't exist
                    DirectoryInfo created_directory = Directory.CreateDirectory(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY);
                    if(created_directory != null && created_directory.Exists)
                    {
                        //if the creation was successful
                        result = true;
                    }
                    else
                    {
                        //otherwise don't bother, just set the result and proceed to the finish line
                        result = false;
                    }
                }
                else
                {
                    //return the check if it exists
                    result = Directory.Exists(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY);
                }
            }
            catch (Exception ex)
            {
                //return false on exception
                result = false;
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static bool IsLoginInList(User login)
        {
            bool result = false;
            try
            {
                if(login  != null && last_Logins.Contains(login))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                //return false on exception
                result = false;
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static bool IsLoginInFileSystem(User login)
        {
            bool result = false;
            List<FileInfo> files;
            try
            {
                if (login != null && CheckOrCreateLoginDirectory() && IsLoginInList(login)) //if the directory exists and the user is in the login list
                {
                    files = new List<FileInfo>();
                    foreach (string filename in Directory.EnumerateFiles(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY))
                    {
                        //add the files to the file list if they exist
                        if (File.Exists(filename))
                        {
                            files.Add(new FileInfo(filename));
                        }
                    }
                    //now browse the file list and check if they are .bin(binary extension)
                    foreach (FileInfo file in files)
                    {
                        if (file.Exists && file.Name == $"{login.UserName}.bin" && file.Extension.IndexOf("bin",StringComparison.OrdinalIgnoreCase) >= 0) //if they are .bin proceed and have the username of the user as their file name return true and break
                        {
                            result = true;
                            break;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                //return false on exception
                result = false;
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static bool LoadSavedLogins(out List<User> login_list)
        {
            bool result = true;
            List<FileInfo> files;
            List<User> retrieved_users = new List<User>();
            try
            {
                //first check or create the logins directory and if it is successful browse it
                if (CheckOrCreateLoginDirectory())
                {
                    files = new List<FileInfo>();
                    foreach(string filename in Directory.EnumerateFiles(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY))
                    {
                        //add the files to the file list if they exist
                        if(File.Exists(filename))
                        {
                            files.Add(new FileInfo(filename));
                        }
                    }
                    //now browse the file list and check if they are .bin(binary extension)
                    foreach(FileInfo file in files)
                    {
                        if(file.Exists && file.Extension.IndexOf("bin", StringComparison.OrdinalIgnoreCase) >= 0) //if they are .bin proceed with user extraction
                        {
                            User retrieved_user;
                            //load the user with binary deserialization from the file stream
                            using(FileStream fs = new FileStream(file.FullName,FileMode.Open,FileAccess.Read))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                if (fs.Length > 0)
                                {
                                    retrieved_user = (User)bf.Deserialize(fs);
                                }
                                else
                                {
                                    retrieved_user = null;
                                }
                            }
                            //if the retrieved user is not null, i.e. valid then add if, otherwise don't
                            if(retrieved_user != null && !retrieved_users.Contains(retrieved_user))
                            {
                                retrieved_users.Add(retrieved_user);
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                }
                if (retrieved_users.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                //return false on exception
                result = false;
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            login_list = retrieved_users;
            return result;
        }

        public static bool SaveLoginToFileSystem(User login)
        {
            bool result = true;
            List<FileInfo> files;
            User existing_login;
            try
            {
                //first check or create the logins directory and if it is successful browse it
                if (login != null && CheckOrCreateLoginDirectory() && IsLoginInList(login) && IsLoginInFileSystem(login)) //if the user exists both in the list and the file system proceed
                {
                    files = new List<FileInfo>();
                    foreach (string filename in Directory.EnumerateFiles(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY))
                    {
                        //add the files to the file list if they exist
                        if (File.Exists(filename))
                        {
                            files.Add(new FileInfo(filename));
                        }
                    }
                    //now browse the file list and check if they are .bin(binary extension)
                    foreach (FileInfo file in files)
                    {
                        if (file.Exists && file.Name == $"{login.UserName}.bin" && file.Extension.IndexOf("bin", StringComparison.OrdinalIgnoreCase) >= 0) //if they are .bin and have the username of the login as its filename retrieve the existing data then set it with shallow copy and save it overwriting the file
                        {
                           //retrieve existing login data to confirm it exists
                           using(FileStream fs = new FileStream(file.FullName,FileMode.CreateNew | FileMode.Create, FileAccess.Read|FileAccess.Write))
                           {
                                BinaryFormatter bf = new BinaryFormatter();
                                existing_login = (User)bf.Deserialize(fs);
                                if (existing_login != null)
                                {
                                    existing_login = login;
                                    bf.Serialize(fs, existing_login);
                                }
                           }
                           result = true;
                           break;
                        }
                    }
                }
                else //if it doesn't exist, save it as new
                {
                    if (login != null)
                    {
                        string new_file_path = Path.Combine(Path.GetFullPath(GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY), $"{login.UserName}.bin");
                        using (FileStream fs = new FileStream(new_file_path, FileMode.CreateNew, FileAccess.Write))
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(fs, login);
                        }
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //return false on exception
                result = false;
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void tsmenuExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show($"{GLOBAL_RESOURCES.CLOSE_PROMPT}", $"{GLOBAL_RESOURCES.CLOSE_PROMPT_TITLE}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (userssearchform != null)
                    {
                        userssearchform.Close();
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
                    if (productvendorssearchform != null)
                    {
                        productvendorssearchform.Close();
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
                    if (bulkUserOperationsform != null)
                    {
                        bulkUserOperationsform.Close();
                    }
                    if (bulkProductBrandOperationsform != null)
                    {
                        bulkProductBrandOperationsform.Close();
                    }
                    if (bulkPaymentMethodOperationsform != null)
                    {
                        bulkPaymentMethodOperationsform.Close();
                    }
                    if (bulkDeliveryServiceOperationsform != null)
                    {
                        bulkDeliveryServiceOperationsform.Close();
                    }
                    if (bulkProductOperationsform != null)
                    {
                        bulkProductOperationsform.Close();
                    }
                    if (bulkProductImageOperationsform != null)
                    {
                        bulkProductImageOperationsform.Close();
                    }
                    if (bulkProductOrderOperationsform != null)
                    {
                        bulkProductOrderOperationsform.Close();
                    }
                    if (bulkOrderDeliveryOperationsform != null)
                    {
                        bulkOrderDeliveryOperationsform.Close();
                    }
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmenuAccountSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if(new frmAccountSettings(ref currentUser).ShowDialog() == DialogResult.OK)
                {
                    if(entities.Database.Connection.State == ConnectionState.Open)
                    {
                        //update the user
                        entities.UpdateUserByID(currentUser.ID, currentUser.UserName, currentUser.UserPassword, currentUser.UserDisplayName,
                                                currentUser.UserBirthDate, currentUser.UserPhone, currentUser.UserEmail, currentUser.UserAddress,
                                                currentUser.UserProfilePic, currentUser.UserBalance, currentUser.UserDiagnose, currentUser.UserRole);
                        //reload the user
                        entities.Entry(entities.Users.Where(x => x.ID == currentUser.ID).FirstOrDefault()).Reload();
                        //refresh logs
                        logger.RefreshLogs();
                        //save to filesystem
                        SaveLoginToFileSystem(currentUser);
                    }
                    else
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.ACCOUNT_SETTINGS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.ACCOUNT_SETTINGS_TITLE}",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmenuApplicationSettings_Click(object sender, EventArgs e)
        {
            if(new frmApplicationSettings().ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.APPLICATION_SETTINGS_CHANGES_NOTICE}", $"{GLOBAL_RESOURCES.APPLICATION_SETTINGS_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmenuAbout_Click(object sender, EventArgs e)
        {
            frmAbout aboutform = new frmAbout();
            aboutform.ShowDialog();
            aboutform.Dispose();
        }
    }
}

