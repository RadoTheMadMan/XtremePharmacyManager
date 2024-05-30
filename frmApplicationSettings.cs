using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static XtremePharmacyManager.ImageBinConverter;
namespace XtremePharmacyManager
{
    public partial class frmApplicationSettings : Form
    {
        public frmApplicationSettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["domain"].Value = txtDomainName.Text;
                config.AppSettings.Settings["dbname"].Value = txtDatabaseName.Text;
                config.AppSettings.Settings["dbuser"].Value = txtDBUser.Text;
                config.AppSettings.Settings["dbpassword"].Value = txtDatabasePassword.Text;
                config.AppSettings.Settings["company_name"].Value = txtCompanyName.Text;
                MessageBox.Show(cbLanguage.SelectedValue.ToString());
                config.AppSettings.Settings["current_culture"].Value = cbLanguage.SelectedValue.ToString();
                config.AppSettings.Settings["report_directory"].Value = txtReportDirectory.Text;
                config.AppSettings.Settings["saved_logins_directory"].Value = txtSavedLoginsDirectory.Text;
                config.AppSettings.Settings["emp_report_name"].Value = txtEmployeeReportName.Text;
                config.AppSettings.Settings["cl_report_name"].Value = txtClientReportName.Text;
                config.AppSettings.Settings["pb_report_name"].Value = txtProductBrandReportName.Text;
                config.AppSettings.Settings["pv_report_name"].Value = txtProductVendorReportName.Text;
                config.AppSettings.Settings["pm_report_name"].Value = txtPaymentMethodReportName.Text;
                config.AppSettings.Settings["ds_report_name"].Value = txtDeliveryServiceReportName.Text;
                config.AppSettings.Settings["p_report_name"].Value = txtProductReportName.Text;
                config.AppSettings.Settings["po_report_name"].Value = txtProductOrderReportName.Text;
                config.AppSettings.Settings["poi_report_name"].Value = txtProductOrderInvoiceReportName.Text;
                config.AppSettings.Settings["od_report_name"].Value = txtOrderDeliveryReportName.Text;
                config.AppSettings.Settings["odi_report_name"].Value = txtOrderDeliveryInvoiceReportName.Text;
                config.Save(ConfigurationSaveMode.Full);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmApplicationSettings_Load(object sender, EventArgs e)
        {
            try
            {
                //TODO: make a language manager to work with the XML file and this form as an instance available only at this form
                //fill the data with global resources
                this.txtDomainName.Text = GLOBAL_RESOURCES.DOMAIN_ADDRESS;
                this.txtDatabaseName.Text = GLOBAL_RESOURCES.DB_NAME;
                this.txtDBUser.Text = GLOBAL_RESOURCES.DB_USER;
                this.txtDatabasePassword.Text = GLOBAL_RESOURCES.DB_PASSWORD;
                this.txtCompanyName.Text = GLOBAL_RESOURCES.COMPANY_NAME;
                this.cbLanguage.SelectedValue = GLOBAL_RESOURCES.CURRENT_CULTURE;
                this.txtReportDirectory.Text = GLOBAL_RESOURCES.REPORT_DIRECTORY;
                this.txtSavedLoginsDirectory.Text = GLOBAL_RESOURCES.SAVED_LOGINS_DIRECTORY;
                this.txtEmployeeReportName.Text = GLOBAL_RESOURCES.EMPLOYEE_REPORT_NAME;
                this.txtClientReportName.Text = GLOBAL_RESOURCES.CLIENT_REPORT_NAME;
                this.txtProductBrandReportName.Text = GLOBAL_RESOURCES.PRODUCT_BRAND_REPORT_NAME;
                this.txtProductVendorReportName.Text = GLOBAL_RESOURCES.PRODUCT_VENDOR_REPORT_NAME;
                this.txtPaymentMethodReportName.Text = GLOBAL_RESOURCES.PAYMENT_METHOD_REPORT_NAME;
                this.txtDeliveryServiceReportName.Text = GLOBAL_RESOURCES.DELIVERY_SERVICE_REPORT_NAME;
                this.txtProductReportName.Text = GLOBAL_RESOURCES.PRODUCT_REPORT_NAME;
                this.txtProductOrderReportName.Text = GLOBAL_RESOURCES.PRODUCT_ORDER_REPORT_NAME;
                this.txtProductOrderInvoiceReportName.Text = GLOBAL_RESOURCES.PRODUCT_ORDER_INVOICE_REPORT_NAME;
                this.txtOrderDeliveryReportName.Text = GLOBAL_RESOURCES.ORDER_DELIVERY_REPORT_NAME;
                this.txtOrderDeliveryInvoiceReportName.Text = GLOBAL_RESOURCES.ORDER_DELIVERY_INVOICE_REPORT_NAME;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
