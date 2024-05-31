using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        LanguageManager languageManager;
        public frmApplicationSettings()
        {
            InitializeComponent();
            languageManager = new LanguageManager();
            
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
                this.txtSearchCulture.Text = GLOBAL_RESOURCES.CURRENT_CULTURE;
                FindAndFillCultureInfo(GLOBAL_RESOURCES.CURRENT_CULTURE);
                LanguageManager.LoadLanguages();
                FillLanguageList(languageManager.Languages);
                this.cbLanguage.DataSource = languageManager.Languages;
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

        private void FillLanguageList(List<Language> languages)
        {
            try
            {
                this.lstLanguagesInList.Items.Clear();
                //if not empty get the specific culture
                foreach (Language language in languages)
                {
                    ListViewItem language_item = new ListViewItem(language.DisplayName);
                    language_item.Text = language.DisplayName;
                    language_item.SubItems.Add(new ListViewItem.ListViewSubItem(language_item, language.LanguageCode));
                    this.lstLanguagesInList.Items.Add(language_item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAndFillCultureInfo(string target_culture)
        {
            List<CultureInfo> found_culture_infos = new List<CultureInfo>();
            try
            {
                this.lstFoundCultureInfos.Items.Clear();
                //if not empty get the specific culture
                if (!String.IsNullOrEmpty(target_culture))
                {
                    found_culture_infos = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(x => x.Name.Contains(target_culture)).ToList();
                }
                else //just get em all
                {
                    found_culture_infos = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
                }
                foreach(CultureInfo cultureInfo in found_culture_infos)
                {
                    ListViewItem culture_item = new ListViewItem(cultureInfo.DisplayName);
                    culture_item.Text = cultureInfo.DisplayName;
                    culture_item.SubItems.Add(new ListViewItem.ListViewSubItem(culture_item,cultureInfo.Name));
                    this.lstFoundCultureInfos.Items.Add(culture_item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAndFillCultureInfoByDisplayName(string target_culture_display_name)
        {
            List<CultureInfo> found_culture_infos = new List<CultureInfo>();
            try
            {
                this.lstFoundCultureInfos.Items.Clear();
                //if not empty get the specific culture
                if (!String.IsNullOrEmpty(target_culture_display_name))
                {
                    found_culture_infos = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(x => x.DisplayName.Contains(target_culture_display_name)).ToList();
                }
                else //just get em all
                {
                    found_culture_infos = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
                }
                foreach (CultureInfo cultureInfo in found_culture_infos)
                {
                    ListViewItem culture_item = new ListViewItem(cultureInfo.DisplayName);
                    culture_item.Text = cultureInfo.DisplayName;
                    culture_item.SubItems.Add(new ListViewItem.ListViewSubItem(culture_item, cultureInfo.Name));
                    this.lstFoundCultureInfos.Items.Add(culture_item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseReportDirectory_Click(object sender, EventArgs e)
        {
            //initialize with the preconfigured path
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select a folder to get the report files from...";
            folderBrowserDialog.SelectedPath = this.txtReportDirectory.Text;
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtReportDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseSavedLoginsDirectory_Click(object sender, EventArgs e)
        {
            //initialize with the preconfigured path
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select a folder to save your logins into and load them from....";
            folderBrowserDialog.SelectedPath = this.txtSavedLoginsDirectory.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSavedLoginsDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSearchCultureInfo_Click(object sender, EventArgs e)
        {
            FindAndFillCultureInfo(txtSearchCulture.Text);
        }

        private void btnAddLanguage_Click(object sender, EventArgs e)
        {
            ListViewItem selected_culture_item;
            CultureInfo selected_culture;
            try
            {
                if(lstFoundCultureInfos.SelectedItems.Count > 0)
                {
                    foreach(var item in lstFoundCultureInfos.SelectedItems)
                    {
                        selected_culture_item = (ListViewItem)item;
                        selected_culture = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList().Where(x=>x.DisplayName.Contains(selected_culture_item.Text)).FirstOrDefault();
                        if(selected_culture != null)
                        {
                            string language_name_trimmed = selected_culture.DisplayName.Substring(0, selected_culture.DisplayName.IndexOf(" "));
                            string language_code = selected_culture.Name;
                            LanguageManager.AddLanguage(language_name_trimmed,language_code);
                            cbLanguage.DataSource = null;
                            cbLanguage.DataSource = languageManager.Languages;
                            FillLanguageList(languageManager.Languages);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
