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
