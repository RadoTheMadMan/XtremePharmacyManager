using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using XtremePharmacyManager.Properties;

namespace XtremePharmacyManager
{
    ///<summary>
    ///here will be all resources and settings we need to get at startup except the
    ///Entity framework metadata path which  is always looked in the DataEntities folder
    ///as seen in obj/WhateverConfigurationYouCompileFor/edmxResourcesToEmbed
    ///it basically sets the directory the same as the project directory, in
    ///my case the DataEntities/entitymodelresourcesfile.csdl and etc
    ///</summary>
    public class GLOBAL_RESOURCES 
    {
        public static string DOMAIN_ADDRESS = "";
        public static string DB_NAME = "";
        public static string DB_USER = "";
        public static string DB_PASSWORD = "";
        public static string COMPANY_NAME = "";
        public static string CURRENT_CULTURE = "";
        public static string REPORT_DIRECTORY = "";
        public static string SAVED_LOGINS_DIRECTORY = "";
        public static string EMPLOYEE_REPORT_NAME = "";
        public static string CLIENT_REPORT_NAME = "";
        public static string PRODUCT_BRAND_REPORT_NAME = "";
        public static string PRODUCT_VENDOR_REPORT_NAME = "";
        public static string PAYMENT_METHOD_REPORT_NAME = "";
        public static string DELIVERY_SERVICE_REPORT_NAME = "";
        public static string PRODUCT_REPORT_NAME = "";
        public static string PRODUCT_ORDER_REPORT_NAME = "";
        public static string PRODUCT_ORDER_INVOICE_REPORT_NAME = "";
        public static string ORDER_DELIVERY_REPORT_NAME = "";
        public static string ORDER_DELIVERY_INVOICE_REPORT_NAME = "";
        public static string CRITICAL_ERROR_MESSAGE = "";
        public static string STACK_TRACE_MESSAGE = "";
        public static string CRITICAL_ERROR_TITLE = "";
        public static string CLOSE_PROMPT = "";
        public static string CLOSE_PROMPT_TITLE = "";
        public static string APPLICATION_INSTANCE_ERROR_MESSAGE = "";
        public static string CONNECTION_SUCCESSFUL_MESSAGE = "";
        public static string CONNECTION_SUCCESSFUL_LOGIN_MESSAGE = "";
        public static string CONNECTION_FAILED_MESSAGE = "";
        public static string CONNECTION_FAILED_AFTER_RETRY_MESSAGE = "";
        public static string CONNECTION_FAILED_LOGIN_MESSAGE = "";
        public static string AUTHORISATION_ERROR_NO_LOGIN_MESSAGE = "";
        public static string AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE = "";
        public static string AUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE = "";
        public static string AUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE = "";
        public static string AUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE = "";
        public static string AUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE = "";
        public static string AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = "";
        public static string AUTHORISATION_LOGIN_INVALID_INPUT_MESSAGE = "";
        public static string AUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE = "";
        public static string AUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE = "";
        public static string AUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE = "";
        public static string AUTHORISATION_LOGIN_EMPLOYEE_NOTICE = "";
        public static string AUTHORISATION_LOGIN_ADMIN_NOTICE = "";
        public static string USER_ACCESS_TITLE = "";
        public static string PRODUCT_MENU_ACCESS_ADMIN_NOTICE = "";
        public static string PRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE = "";
        public static string USER_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BRAND_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string VENDOR_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string PRODUCT_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string LOGS_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_USER_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_BRAND_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string BULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = "";
        public static string ACCOUNT_SETTINGS_ERROR_MESSAGE = "";
        public static string ACCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE = "";
        public static string APPLICATION_SETTINGS_CHANGES_NOTICE = "";
        public static string BULK_OPERATIONS_TITLE = "";
        public static string BULK_OPERATION_QUESTION = "";
        public static string TEST_TITLE = "";
        public static string LOGIN_TITLE = "";
        public static string CURRENT_HOST_TITLE = "";
        public static string CURRENT_OPERATOR_TITLE = "";
        public static string ACCOUNT_SETTINGS_TITLE = "";
        public static string APPLICATION_SETTINGS_TITLE = "";
        public static string ACCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE = "";
        public static GLOBAL_RESOURCES instance;
        public EventHandler<CultureInfo> CultureInfoChanged;
        
        public GLOBAL_RESOURCES()
        {
            ResourceManager manager = Resources.ResourceManager;
            if (instance == null)
            {
                instance = this;
            }
            RefreshSettings();
            Application.CurrentCulture = CultureInfo.GetCultureInfo(GLOBAL_RESOURCES.CURRENT_CULTURE);
            UpdateCurrentCultureResources();
        }

        private void InvokeCultureInfoChangedEvent(CultureInfo culture)
        {
            if(CultureInfoChanged != null)
            {
                CultureInfoChanged(this, culture);
            }
        }



        public static void RefreshSettings()
        {
            DOMAIN_ADDRESS = ConfigurationManager.AppSettings["domain"];
            DB_NAME = ConfigurationManager.AppSettings["dbname"];
            DB_USER = ConfigurationManager.AppSettings["dbuser"];
            DB_PASSWORD = ConfigurationManager.AppSettings["dbpassword"];
            COMPANY_NAME = ConfigurationManager.AppSettings["company_name"];
            CURRENT_CULTURE = ConfigurationManager.AppSettings["current_culture"];
            SAVED_LOGINS_DIRECTORY = (ConfigurationManager.AppSettings["saved_logins_directory"] != null &&
               Directory.Exists(Path.GetFullPath(ConfigurationManager.AppSettings["saved_logins_directory"]))) ?
               Path.GetFullPath(ConfigurationManager.AppSettings["saved_logins_directory"]) :
               Path.GetFullPath($"{Application.StartupPath}/{ConfigurationManager.AppSettings["saved_logins_directory"]}/");
            REPORT_DIRECTORY = (ConfigurationManager.AppSettings["report_directory"] != null &&
                Directory.Exists(Path.GetFullPath(ConfigurationManager.AppSettings["report_directory"]))) ?
                Path.GetFullPath(ConfigurationManager.AppSettings["report_directory"]) :
                Path.GetFullPath($"{Application.StartupPath}/{ConfigurationManager.AppSettings["report_directory"]}/");
            EMPLOYEE_REPORT_NAME = ConfigurationManager.AppSettings["emp_report_name"];
            CLIENT_REPORT_NAME = ConfigurationManager.AppSettings["cl_report_name"];
            PRODUCT_BRAND_REPORT_NAME = ConfigurationManager.AppSettings["pb_report_name"];
            PRODUCT_VENDOR_REPORT_NAME = ConfigurationManager.AppSettings["pv_report_name"];
            PAYMENT_METHOD_REPORT_NAME = ConfigurationManager.AppSettings["pm_report_name"];
            DELIVERY_SERVICE_REPORT_NAME = ConfigurationManager.AppSettings["ds_report_name"];
            PRODUCT_REPORT_NAME = ConfigurationManager.AppSettings["p_report_name"];
            PRODUCT_ORDER_REPORT_NAME = ConfigurationManager.AppSettings["po_report_name"];
            PRODUCT_ORDER_INVOICE_REPORT_NAME = ConfigurationManager.AppSettings["poi_report_name"];
            ORDER_DELIVERY_REPORT_NAME = ConfigurationManager.AppSettings["od_report_name"];
            ORDER_DELIVERY_INVOICE_REPORT_NAME = ConfigurationManager.AppSettings["odi_report_name"];
        }

        public static void UpdateCurrentCultureResources()
        {
            ResourceManager manager = Resources.ResourceManager;
            CRITICAL_ERROR_MESSAGE = manager.GetString("CriticalErrorMessage", CultureInfo.CurrentCulture);
            STACK_TRACE_MESSAGE = manager.GetString("StackTraceMessage", CultureInfo.CurrentCulture);
            CRITICAL_ERROR_TITLE = manager.GetString("CriticalErrorTitle", CultureInfo.CurrentCulture);
            CLOSE_PROMPT = manager.GetString("ClosePrompt", CultureInfo.CurrentCulture);
            CLOSE_PROMPT_TITLE = manager.GetString("ClosePromptTitle", CultureInfo.CurrentCulture);
            BULK_OPERATIONS_TITLE = manager.GetString("BulkOperationsTitle", CultureInfo.CurrentCulture);
            APPLICATION_INSTANCE_ERROR_MESSAGE = manager.GetString("ApplicationInstanceErrorMessage", CultureInfo.CurrentCulture);
            CONNECTION_SUCCESSFUL_MESSAGE = manager.GetString("ConnectionSuccessfulMessage", CultureInfo.CurrentCulture);
            CONNECTION_SUCCESSFUL_LOGIN_MESSAGE = manager.GetString("ConnectionSuccessfulLoginMessage", CultureInfo.CurrentCulture); 
            CONNECTION_FAILED_MESSAGE = manager.GetString("ConnectionFailedMessage", CultureInfo.CurrentCulture);
            CONNECTION_FAILED_AFTER_RETRY_MESSAGE = manager.GetString("ConnectionFailedAfterRetryMessage", CultureInfo.CurrentCulture);
            CONNECTION_FAILED_LOGIN_MESSAGE = manager.GetString("ConnectionFailedLoginMessage", CultureInfo.CurrentCulture);
            BULK_OPERATION_QUESTION = manager.GetString("BulkOperationQuestion", CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_NO_LOGIN_MESSAGE = manager.GetString("AuthorisationErrorNoLoginMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_CANCELLED_LOGIN_MESSAGE = manager.GetString("AuthorisationErrorCancelledLoginMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_CLIENT_LOGIN_MESSAGE = manager.GetString("AuthorisationErrorClientLoginMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_ERROR_SYSADMIN_BREACH_MESSAGE = manager.GetString("AuthorisationErrorSysAdminBreachMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_APPCONF_LOGIN_FOUND_MESSAGE = manager.GetString("AuthorisationAppConfLoginFoundMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_APPCONF_LOGIN_NOT_FOUND_MESSAGE = manager.GetString("AuthorisationAppConfLoginNotFoundMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = manager.GetString("AuthorisationLoginEmptyInputMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_EMPTY_INPUT_MESSAGE = manager.GetString("AuthorisationLoginInvalidInputMessage",CultureInfo.CurrentCulture);
            AUTHORISATION_ADD_LOGIN_INVALID_RESULTS_MESSAGE = manager.GetString("AuthorisationAddLoginInvalidResultsMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_NO_CONNECTION_MESSAGE = manager.GetString("AuthorisationLoginNoConnectionMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_FILESYSTEM_LOAD_ERROR_MESSAGE = manager.GetString("AuthorisationLoginFilesystemLoadErrorMessage", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_EMPLOYEE_NOTICE = manager.GetString("AuthorisationLoginEmployeeNotice", CultureInfo.CurrentCulture);
            AUTHORISATION_LOGIN_ADMIN_NOTICE = manager.GetString("AuthorisationLoginAdminNotice", CultureInfo.CurrentCulture);
            TEST_TITLE = manager.GetString("TestTitle", CultureInfo.CurrentCulture);
            LOGIN_TITLE = manager.GetString("LoginTitle", CultureInfo.CurrentCulture);
            CURRENT_HOST_TITLE = manager.GetString("CurrentHostTitle", CultureInfo.CurrentCulture);
            CURRENT_OPERATOR_TITLE = manager.GetString("CurrentOperatorTitle", CultureInfo.CurrentCulture);
            USER_ACCESS_TITLE = manager.GetString("UserAccessTitle", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_TITLE = manager.GetString("AccountSettingsTitle",CultureInfo.CurrentCulture);
            APPLICATION_SETTINGS_TITLE = manager.GetString("ApplicationSettingsTitle", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE = manager.GetString("AccountSettingsProfilePicSelectTitle", CultureInfo.CurrentCulture);
            PRODUCT_MENU_ACCESS_ADMIN_NOTICE = manager.GetString("ProductMenuAccessAdminNotice", CultureInfo.CurrentCulture);
            PRODUCT_MENU_ACCESS_EMPLOYEE_NOTICE = manager.GetString("ProductMenuAccessEmployeeNotice", CultureInfo.CurrentCulture);
            USER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("UserMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BRAND_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BrandMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            VENDOR_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("VendorMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("PaymentMethodMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("DeliveryServiceMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            PRODUCT_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("ProductMenuAccessErrorMessage", CultureInfo.CurrentCulture);
            PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("ProductOrderMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("OrderDeliveryMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            LOGS_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("LogsMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_USER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkUserMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_BRAND_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkBrandMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_VENDOR_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkVendorMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PAYMENT_METHOD_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkPaymentMethodMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_DELIVERY_SERVICE_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkDeliveryServiceMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PRODUCT_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkProductMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PRODUCT_IMAGE_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkProductImageMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_PRODUCT_ORDER_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkProductOrderMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            BULK_ORDER_DELIVERY_MENU_ACCESS_ERROR_MESSAGE = manager.GetString("BulkOrderDeliveryMenuAccessErrorMessage",CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_ERROR_MESSAGE = manager.GetString("AccountSettingsErrorMessage", CultureInfo.CurrentCulture);
            ACCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE = manager.GetString("AccountSettingsInvalidCredentialsErrorMessage", CultureInfo.CurrentCulture);
            APPLICATION_SETTINGS_CHANGES_NOTICE = manager.GetString("ApplicationSettingsChangeNotice",CultureInfo.CurrentCulture);
        instance.InvokeCultureInfoChangedEvent(CultureInfo.CurrentCulture);
        }
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static GLOBAL_RESOURCES resources;
        [STAThread]
        static void Main()
        {
            try
            {
                resources = new GLOBAL_RESOURCES();
                GLOBAL_RESOURCES.RefreshSettings();
                GLOBAL_RESOURCES.UpdateCurrentCultureResources();
                Process currentProccess = Process.GetCurrentProcess();
                bool IsAlreadyOpen = Process.GetProcessesByName(currentProccess.ProcessName).Any(p=>p.Id != currentProccess.Id);
                if(IsAlreadyOpen)
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.APPLICATION_INSTANCE_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
