using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static string REPORT_DIRECTORY = "";
        public static string EMPLOYEE_REPORT_NAME = "";
        public static string CLIENT_REPORT_NAME = "";
        public static string PRODUCT_BRAND_REPORT_NAME = "";
        public static string PAYMENT_METHOD_REPORT_NAME = "";
        public static string DELIVERY_SERVICE_REPORT_NAME = "";
        public static string PRODUCT_REPORT_NAME = "";
        public static string PRODUCT_ORDER_REPORT_NAME = "";
        public static string ORDER_DELIVERY_REPORT_NAME = "";
        public static string CRITICAL_ERROR_MESSAGE = "";
        public static string STACK_TRACE_MESSAGE = "";
        public static string CRITICAL_ERROR_TITLE = "";
        public static string CLOSE_PROMPT = "";
        public static string CLOSE_PROMPT_TITLE = "";
        public static string CONNECTION_SUCCESSFUL_MESSAGE = "";
        public static GLOBAL_RESOURCES instance;
        public EventHandler<CultureInfo> CultureInfoChanged;
        
        public GLOBAL_RESOURCES()
        {
            ResourceManager manager = Resources.ResourceManager;
            if (instance == null)
            {
                instance = this;
            }
            DOMAIN_ADDRESS = ConfigurationSettings.AppSettings["domain"];
            DB_NAME = ConfigurationSettings.AppSettings["dbname"];
            DB_USER = ConfigurationSettings.AppSettings["dbuser"];
            DB_PASSWORD = ConfigurationSettings.AppSettings["dbpassword"];
            REPORT_DIRECTORY = (ConfigurationSettings.AppSettings["report_directory"] != null && 
                Directory.Exists(Path.GetFullPath(ConfigurationSettings.AppSettings["report_directory"])))? 
                Path.GetFullPath(ConfigurationSettings.AppSettings["report_directory"]) :
                Path.GetFullPath($"{Application.StartupPath}/{ConfigurationSettings.AppSettings["report_directory"]}/");
            EMPLOYEE_REPORT_NAME = ConfigurationSettings.AppSettings["emp_report_name"];
            CLIENT_REPORT_NAME = ConfigurationSettings.AppSettings["cl_report_name"];
            PRODUCT_BRAND_REPORT_NAME = ConfigurationSettings.AppSettings["pb_report_name"];
            PAYMENT_METHOD_REPORT_NAME = ConfigurationSettings.AppSettings["pm_report_name"];
            DELIVERY_SERVICE_REPORT_NAME = ConfigurationSettings.AppSettings["ds_report_name"];
            PRODUCT_REPORT_NAME = ConfigurationSettings.AppSettings["p_report_name"];
            PRODUCT_ORDER_REPORT_NAME = ConfigurationSettings.AppSettings["po_report_name"];
            ORDER_DELIVERY_REPORT_NAME = ConfigurationSettings.AppSettings["od_report_name"];
            CRITICAL_ERROR_MESSAGE = manager.GetString("CriticalErrorMessage", CultureInfo.CurrentCulture);
            STACK_TRACE_MESSAGE = manager.GetString("StackTraceMessage", CultureInfo.CurrentCulture);
            CRITICAL_ERROR_TITLE = manager.GetString("CriticalErrorTitle", CultureInfo.CurrentCulture);
            CLOSE_PROMPT = manager.GetString("ClosePrompt", CultureInfo.CurrentCulture);
            CLOSE_PROMPT_TITLE = manager.GetString("ClosePromptTitle", CultureInfo.CurrentCulture);
            CONNECTION_SUCCESSFUL_MESSAGE = manager.GetString("ConnectionSuccessfulMessage", CultureInfo.CurrentCulture);
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
            DOMAIN_ADDRESS = ConfigurationSettings.AppSettings["domain"];
            DB_NAME = ConfigurationSettings.AppSettings["dbname"];
            DB_USER = ConfigurationSettings.AppSettings["dbuser"];
            DB_PASSWORD = ConfigurationSettings.AppSettings["dbpassword"];
            REPORT_DIRECTORY = (ConfigurationSettings.AppSettings["report_directory"] != null &&
                Directory.Exists(Path.GetFullPath(ConfigurationSettings.AppSettings["report_directory"]))) ?
                Path.GetFullPath(ConfigurationSettings.AppSettings["report_directory"]) :
                Path.GetFullPath($"{Application.StartupPath}/{ConfigurationSettings.AppSettings["report_directory"]}/");
            EMPLOYEE_REPORT_NAME = ConfigurationSettings.AppSettings["emp_report_name"];
            CLIENT_REPORT_NAME = ConfigurationSettings.AppSettings["cl_report_name"];
            PRODUCT_BRAND_REPORT_NAME = ConfigurationSettings.AppSettings["pb_report_name"];
            PAYMENT_METHOD_REPORT_NAME = ConfigurationSettings.AppSettings["pm_report_name"];
            DELIVERY_SERVICE_REPORT_NAME = ConfigurationSettings.AppSettings["ds_report_name"];
            PRODUCT_REPORT_NAME = ConfigurationSettings.AppSettings["p_report_name"];
            PRODUCT_ORDER_REPORT_NAME = ConfigurationSettings.AppSettings["po_report_name"];
            ORDER_DELIVERY_REPORT_NAME = ConfigurationSettings.AppSettings["od_report_name"];
        }

        public static void UpdateCurrentCultureResources()
        {
            ResourceManager manager = Resources.ResourceManager;
            CRITICAL_ERROR_MESSAGE = manager.GetString("CriticalErrorMessage", CultureInfo.CurrentCulture);
            STACK_TRACE_MESSAGE = manager.GetString("StackTraceMessage", CultureInfo.CurrentCulture);
            CRITICAL_ERROR_TITLE = manager.GetString("CriticalErrorTitle", CultureInfo.CurrentCulture);
            CLOSE_PROMPT = manager.GetString("ClosePrompt", CultureInfo.CurrentCulture);
            CLOSE_PROMPT_TITLE = manager.GetString("ClosePromptTitle", CultureInfo.CurrentCulture);
            CONNECTION_SUCCESSFUL_MESSAGE = manager.GetString("ConnectionSuccessfulMessage", CultureInfo.CurrentCulture);
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
            resources = new GLOBAL_RESOURCES();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
