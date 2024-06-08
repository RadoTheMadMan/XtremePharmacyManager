namespace XtremePharmacyManager
{
    partial class frmApplicationSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if(languageManager != null)
                {
                    languageManager.Dispose();
                    languageManager = null;
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplicationSettings));
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnRemoveLanguage = new System.Windows.Forms.Button();
            this.btnAddLanguage = new System.Windows.Forms.Button();
            this.lstLanguagesInList = new System.Windows.Forms.ListView();
            this.LanguageDisplayNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LanguageCodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearchCultureInfo = new System.Windows.Forms.Button();
            this.txtSearchCulture = new System.Windows.Forms.TextBox();
            this.lstFoundCultureInfos = new System.Windows.Forms.ListView();
            this.CultureDisplayNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CultureCodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFoundCultureInfos = new System.Windows.Forms.Label();
            this.lblLanguageExtensibilitySettings = new System.Windows.Forms.Label();
            this.lblCommonSettings = new System.Windows.Forms.Label();
            this.txtOrderDeliveryInvoiceReportName = new System.Windows.Forms.TextBox();
            this.lblOrderDeliveryInvoiceReportName = new System.Windows.Forms.Label();
            this.txtOrderDeliveryReportName = new System.Windows.Forms.TextBox();
            this.lblOrderDeliveryReportName = new System.Windows.Forms.Label();
            this.txtProductOrderInvoiceReportName = new System.Windows.Forms.TextBox();
            this.lblProductOrderInvoiceReportName = new System.Windows.Forms.Label();
            this.txtProductOrderReportName = new System.Windows.Forms.TextBox();
            this.lblProductOrderReportName = new System.Windows.Forms.Label();
            this.txtProductReportName = new System.Windows.Forms.TextBox();
            this.lblProductReportName = new System.Windows.Forms.Label();
            this.txtDeliveryServiceReportName = new System.Windows.Forms.TextBox();
            this.lblDeliveryServiceReportName = new System.Windows.Forms.Label();
            this.txtPaymentMethodReportName = new System.Windows.Forms.TextBox();
            this.lblPaymentMethodReportName = new System.Windows.Forms.Label();
            this.txtProductVendorReportName = new System.Windows.Forms.TextBox();
            this.lblProductVendorReportName = new System.Windows.Forms.Label();
            this.txtProductBrandReportName = new System.Windows.Forms.TextBox();
            this.lblProductBrandReportName = new System.Windows.Forms.Label();
            this.txtClientReportName = new System.Windows.Forms.TextBox();
            this.lblClientReportName = new System.Windows.Forms.Label();
            this.txtEmployeeReportName = new System.Windows.Forms.TextBox();
            this.lblEmployeeReportName = new System.Windows.Forms.Label();
            this.txtSavedLoginsDirectory = new System.Windows.Forms.TextBox();
            this.lblSavedLoginsDirectory = new System.Windows.Forms.Label();
            this.btnBrowseSavedLoginsDirectory = new System.Windows.Forms.Button();
            this.txtReportDirectory = new System.Windows.Forms.TextBox();
            this.lblReportDirectory = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.languageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnBrowseReportDirectory = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtDatabasePassword = new System.Windows.Forms.TextBox();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.lblDBUser = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.lblDomainName = new System.Windows.Forms.Label();
            this.ttApplicationSettings = new System.Windows.Forms.ToolTip(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.btnRemoveLanguage);
            this.pnlData.Controls.Add(this.btnAddLanguage);
            this.pnlData.Controls.Add(this.lstLanguagesInList);
            this.pnlData.Controls.Add(this.btnSearchCultureInfo);
            this.pnlData.Controls.Add(this.txtSearchCulture);
            this.pnlData.Controls.Add(this.lstFoundCultureInfos);
            this.pnlData.Controls.Add(this.lblFoundCultureInfos);
            this.pnlData.Controls.Add(this.lblLanguageExtensibilitySettings);
            this.pnlData.Controls.Add(this.lblCommonSettings);
            this.pnlData.Controls.Add(this.txtOrderDeliveryInvoiceReportName);
            this.pnlData.Controls.Add(this.lblOrderDeliveryInvoiceReportName);
            this.pnlData.Controls.Add(this.txtOrderDeliveryReportName);
            this.pnlData.Controls.Add(this.lblOrderDeliveryReportName);
            this.pnlData.Controls.Add(this.txtProductOrderInvoiceReportName);
            this.pnlData.Controls.Add(this.lblProductOrderInvoiceReportName);
            this.pnlData.Controls.Add(this.txtProductOrderReportName);
            this.pnlData.Controls.Add(this.lblProductOrderReportName);
            this.pnlData.Controls.Add(this.txtProductReportName);
            this.pnlData.Controls.Add(this.lblProductReportName);
            this.pnlData.Controls.Add(this.txtDeliveryServiceReportName);
            this.pnlData.Controls.Add(this.lblDeliveryServiceReportName);
            this.pnlData.Controls.Add(this.txtPaymentMethodReportName);
            this.pnlData.Controls.Add(this.lblPaymentMethodReportName);
            this.pnlData.Controls.Add(this.txtProductVendorReportName);
            this.pnlData.Controls.Add(this.lblProductVendorReportName);
            this.pnlData.Controls.Add(this.txtProductBrandReportName);
            this.pnlData.Controls.Add(this.lblProductBrandReportName);
            this.pnlData.Controls.Add(this.txtClientReportName);
            this.pnlData.Controls.Add(this.lblClientReportName);
            this.pnlData.Controls.Add(this.txtEmployeeReportName);
            this.pnlData.Controls.Add(this.lblEmployeeReportName);
            this.pnlData.Controls.Add(this.txtSavedLoginsDirectory);
            this.pnlData.Controls.Add(this.lblSavedLoginsDirectory);
            this.pnlData.Controls.Add(this.btnBrowseSavedLoginsDirectory);
            this.pnlData.Controls.Add(this.txtReportDirectory);
            this.pnlData.Controls.Add(this.lblReportDirectory);
            this.pnlData.Controls.Add(this.cbLanguage);
            this.pnlData.Controls.Add(this.lblLanguage);
            this.pnlData.Controls.Add(this.btnBrowseReportDirectory);
            this.pnlData.Controls.Add(this.txtCompanyName);
            this.pnlData.Controls.Add(this.lblCompanyName);
            this.pnlData.Controls.Add(this.txtDatabasePassword);
            this.pnlData.Controls.Add(this.lblDBPassword);
            this.pnlData.Controls.Add(this.txtDBUser);
            this.pnlData.Controls.Add(this.lblDBUser);
            this.pnlData.Controls.Add(this.txtDatabaseName);
            this.pnlData.Controls.Add(this.lblDatabaseName);
            this.pnlData.Controls.Add(this.btnOK);
            this.pnlData.Controls.Add(this.btnCancel);
            this.pnlData.Controls.Add(this.txtDomainName);
            this.pnlData.Controls.Add(this.lblDomainName);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1152, 715);
            this.pnlData.TabIndex = 0;
            // 
            // btnRemoveLanguage
            // 
            this.btnRemoveLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLanguage.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveLanguage.Location = new System.Drawing.Point(841, 332);
            this.btnRemoveLanguage.Name = "btnRemoveLanguage";
            this.btnRemoveLanguage.Size = new System.Drawing.Size(163, 22);
            this.btnRemoveLanguage.TabIndex = 80;
            this.btnRemoveLanguage.Text = GLOBAL_RESOURCES.BTN_REMOVE_LANGUAGE_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnRemoveLanguage, GLOBAL_RESOURCES.BTN_REMOVE_LANGUAGE_TOOLTIP_TITLE);
            this.btnRemoveLanguage.UseVisualStyleBackColor = true;
            this.btnRemoveLanguage.Click += new System.EventHandler(this.btnRemoveLanguage_Click);
            // 
            // btnAddLanguage
            // 
            this.btnAddLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLanguage.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLanguage.Location = new System.Drawing.Point(672, 332);
            this.btnAddLanguage.Name = "btnAddLanguage";
            this.btnAddLanguage.Size = new System.Drawing.Size(163, 22);
            this.btnAddLanguage.TabIndex = 79;
            this.btnAddLanguage.Text = GLOBAL_RESOURCES.BTN_ADD_LANGUAGE_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnAddLanguage, GLOBAL_RESOURCES.BTN_ADD_LANGUAGE_TOOLTIP_TITLE);
            this.btnAddLanguage.UseVisualStyleBackColor = true;
            this.btnAddLanguage.Click += new System.EventHandler(this.btnAddLanguage_Click);
            // 
            // lstLanguagesInList
            // 
            this.lstLanguagesInList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLanguagesInList.CheckBoxes = true;
            this.lstLanguagesInList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LanguageDisplayNameColumn,
            this.LanguageCodeColumn});
            this.lstLanguagesInList.FullRowSelect = true;
            this.lstLanguagesInList.HideSelection = false;
            this.lstLanguagesInList.Location = new System.Drawing.Point(672, 360);
            this.lstLanguagesInList.Name = "lstLanguagesInList";
            this.lstLanguagesInList.Size = new System.Drawing.Size(442, 177);
            this.lstLanguagesInList.TabIndex = 78;
            this.ttApplicationSettings.SetToolTip(this.lstLanguagesInList, GLOBAL_RESOURCES.LST_LANGUAGES_IN_LIST_TOOLTIP_TITLE);
            this.lstLanguagesInList.UseCompatibleStateImageBehavior = false;
            this.lstLanguagesInList.View = System.Windows.Forms.View.Details;
            // 
            // LanguageDisplayNameColumn
            // 
            this.LanguageDisplayNameColumn.Text = GLOBAL_RESOURCES.LANGUAGE_DISPLAY_NAME_COL_TITLE;
            this.LanguageDisplayNameColumn.Width = 265;
            // 
            // LanguageCodeColumn
            // 
            this.LanguageCodeColumn.Text = GLOBAL_RESOURCES.LANGUAGE_CODE_COL_TITLE;
            this.LanguageCodeColumn.Width = 171;
            // 
            // btnSearchCultureInfo
            // 
            this.btnSearchCultureInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCultureInfo.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCultureInfo.Location = new System.Drawing.Point(951, 115);
            this.btnSearchCultureInfo.Name = "btnSearchCultureInfo";
            this.btnSearchCultureInfo.Size = new System.Drawing.Size(163, 22);
            this.btnSearchCultureInfo.TabIndex = 77;
            this.btnSearchCultureInfo.Text = GLOBAL_RESOURCES.BTN_SEARCH_CULTURE_INFO_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnSearchCultureInfo, GLOBAL_RESOURCES.BTN_SEARCH_CULTURE_INFO_TOOLTIP_TITLE);
            this.btnSearchCultureInfo.UseVisualStyleBackColor = true;
            this.btnSearchCultureInfo.Click += new System.EventHandler(this.btnSearchCultureInfo_Click);
            // 
            // txtSearchCulture
            // 
            this.txtSearchCulture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearchCulture.Location = new System.Drawing.Point(672, 115);
            this.txtSearchCulture.Name = "txtSearchCulture";
            this.txtSearchCulture.Size = new System.Drawing.Size(258, 22);
            this.txtSearchCulture.TabIndex = 76;
            this.ttApplicationSettings.SetToolTip(this.txtSearchCulture, GLOBAL_RESOURCES.TXT_SEARCH_CULTURE_TOOLTIP_TITLE);
            // 
            // lstFoundCultureInfos
            // 
            this.lstFoundCultureInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFoundCultureInfos.CheckBoxes = true;
            this.lstFoundCultureInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CultureDisplayNameColumn,
            this.CultureCodeColumn});
            this.lstFoundCultureInfos.FullRowSelect = true;
            this.lstFoundCultureInfos.HideSelection = false;
            this.lstFoundCultureInfos.Location = new System.Drawing.Point(672, 145);
            this.lstFoundCultureInfos.Name = "lstFoundCultureInfos";
            this.lstFoundCultureInfos.Size = new System.Drawing.Size(442, 177);
            this.lstFoundCultureInfos.TabIndex = 75;
            this.ttApplicationSettings.SetToolTip(this.lstFoundCultureInfos, GLOBAL_RESOURCES.LST_FOUND_CULTURE_INFOS_TOOLTIP_TITLE);
            this.lstFoundCultureInfos.UseCompatibleStateImageBehavior = false;
            this.lstFoundCultureInfos.View = System.Windows.Forms.View.Details;
            // 
            // CultureDisplayNameColumn
            // 
            this.CultureDisplayNameColumn.Text = GLOBAL_RESOURCES.CULTURE_DISPLAY_NAME_COL_TITLE;
            this.CultureDisplayNameColumn.Width = 265;
            // 
            // CultureCodeColumn
            // 
            this.CultureCodeColumn.Text = GLOBAL_RESOURCES.CULTURE_CODE_COL_TITLE;
            this.CultureCodeColumn.Width = 171;
            // 
            // lblFoundCultureInfos
            // 
            this.lblFoundCultureInfos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFoundCultureInfos.AutoSize = true;
            this.lblFoundCultureInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoundCultureInfos.Location = new System.Drawing.Point(669, 82);
            this.lblFoundCultureInfos.Name = "lblFoundCultureInfos";
            this.lblFoundCultureInfos.Size = new System.Drawing.Size(194, 16);
            this.lblFoundCultureInfos.TabIndex = 74;
            this.lblFoundCultureInfos.Text = GLOBAL_RESOURCES.LBL_FOUND_CULTURE_INFOS_TITLE;
            // 
            // lblLanguageExtensibilitySettings
            // 
            this.lblLanguageExtensibilitySettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLanguageExtensibilitySettings.AutoSize = true;
            this.lblLanguageExtensibilitySettings.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguageExtensibilitySettings.ForeColor = System.Drawing.Color.Firebrick;
            this.lblLanguageExtensibilitySettings.Location = new System.Drawing.Point(665, 27);
            this.lblLanguageExtensibilitySettings.Name = "lblLanguageExtensibilitySettings";
            this.lblLanguageExtensibilitySettings.Size = new System.Drawing.Size(449, 38);
            this.lblLanguageExtensibilitySettings.TabIndex = 73;
            this.lblLanguageExtensibilitySettings.Text =GLOBAL_RESOURCES.LBL_EXT_LANG_SETTINGS_TITLE;
            this.ttApplicationSettings.SetToolTip(this.lblLanguageExtensibilitySettings, GLOBAL_RESOURCES.LBL_EXT_LANG_SETTINGS_TOOLTIP_TITLE);
            // 
            // lblCommonSettings
            // 
            this.lblCommonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCommonSettings.AutoSize = true;
            this.lblCommonSettings.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommonSettings.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCommonSettings.Location = new System.Drawing.Point(28, 27);
            this.lblCommonSettings.Name = "lblCommonSettings";
            this.lblCommonSettings.Size = new System.Drawing.Size(263, 38);
            this.lblCommonSettings.TabIndex = 72;
            this.lblCommonSettings.Text = GLOBAL_RESOURCES.LBL_COMMON_SETTINGS_TITLE;
            this.ttApplicationSettings.SetToolTip(this.lblCommonSettings, GLOBAL_RESOURCES.LBL_COMMON_SETTINGS_TOOLTIP_TITLE);
            // 
            // txtOrderDeliveryInvoiceReportName
            // 
            this.txtOrderDeliveryInvoiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOrderDeliveryInvoiceReportName.Location = new System.Drawing.Point(288, 621);
            this.txtOrderDeliveryInvoiceReportName.Name = "txtOrderDeliveryInvoiceReportName";
            this.txtOrderDeliveryInvoiceReportName.Size = new System.Drawing.Size(258, 22);
            this.txtOrderDeliveryInvoiceReportName.TabIndex = 71;
            this.ttApplicationSettings.SetToolTip(this.txtOrderDeliveryInvoiceReportName, GLOBAL_RESOURCES.ODI_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblOrderDeliveryInvoiceReportName
            // 
            this.lblOrderDeliveryInvoiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderDeliveryInvoiceReportName.AutoSize = true;
            this.lblOrderDeliveryInvoiceReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDeliveryInvoiceReportName.Location = new System.Drawing.Point(25, 624);
            this.lblOrderDeliveryInvoiceReportName.Name = "lblOrderDeliveryInvoiceReportName";
            this.lblOrderDeliveryInvoiceReportName.Size = new System.Drawing.Size(262, 16);
            this.lblOrderDeliveryInvoiceReportName.TabIndex = 70;
            this.lblOrderDeliveryInvoiceReportName.Text = GLOBAL_RESOURCES.ODI_REPORT_NAME_SETTING_TITLE;
            // 
            // txtOrderDeliveryReportName
            // 
            this.txtOrderDeliveryReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOrderDeliveryReportName.Location = new System.Drawing.Point(288, 591);
            this.txtOrderDeliveryReportName.Name = "txtOrderDeliveryReportName";
            this.txtOrderDeliveryReportName.Size = new System.Drawing.Size(258, 22);
            this.txtOrderDeliveryReportName.TabIndex = 69;
            this.ttApplicationSettings.SetToolTip(this.txtOrderDeliveryReportName, GLOBAL_RESOURCES.OD_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblOrderDeliveryReportName
            // 
            this.lblOrderDeliveryReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderDeliveryReportName.AutoSize = true;
            this.lblOrderDeliveryReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDeliveryReportName.Location = new System.Drawing.Point(25, 594);
            this.lblOrderDeliveryReportName.Name = "lblOrderDeliveryReportName";
            this.lblOrderDeliveryReportName.Size = new System.Drawing.Size(208, 16);
            this.lblOrderDeliveryReportName.TabIndex = 68;
            this.lblOrderDeliveryReportName.Text = GLOBAL_RESOURCES.OD_REPORT_NAME_SETTING_TITLE;
            // 
            // txtProductOrderInvoiceReportName
            // 
            this.txtProductOrderInvoiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductOrderInvoiceReportName.Location = new System.Drawing.Point(288, 561);
            this.txtProductOrderInvoiceReportName.Name = "txtProductOrderInvoiceReportName";
            this.txtProductOrderInvoiceReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductOrderInvoiceReportName.TabIndex = 67;
            this.ttApplicationSettings.SetToolTip(this.txtProductOrderInvoiceReportName, GLOBAL_RESOURCES.POI_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblProductOrderInvoiceReportName
            // 
            this.lblProductOrderInvoiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductOrderInvoiceReportName.AutoSize = true;
            this.lblProductOrderInvoiceReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductOrderInvoiceReportName.Location = new System.Drawing.Point(25, 564);
            this.lblProductOrderInvoiceReportName.Name = "lblProductOrderInvoiceReportName";
            this.lblProductOrderInvoiceReportName.Size = new System.Drawing.Size(257, 16);
            this.lblProductOrderInvoiceReportName.TabIndex = 66;
            this.lblProductOrderInvoiceReportName.Text = GLOBAL_RESOURCES.POI_REPORT_NAME_SETTING_TITLE;
            // 
            // txtProductOrderReportName
            // 
            this.txtProductOrderReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductOrderReportName.Location = new System.Drawing.Point(288, 531);
            this.txtProductOrderReportName.Name = "txtProductOrderReportName";
            this.txtProductOrderReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductOrderReportName.TabIndex = 65;
            this.ttApplicationSettings.SetToolTip(this.txtProductOrderReportName,GLOBAL_RESOURCES.PO_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblProductOrderReportName
            // 
            this.lblProductOrderReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductOrderReportName.AutoSize = true;
            this.lblProductOrderReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductOrderReportName.Location = new System.Drawing.Point(25, 534);
            this.lblProductOrderReportName.Name = "lblProductOrderReportName";
            this.lblProductOrderReportName.Size = new System.Drawing.Size(203, 16);
            this.lblProductOrderReportName.TabIndex = 64;
            this.lblProductOrderReportName.Text = GLOBAL_RESOURCES.PO_REPORT_NAME_SETTING_TITLE;
            // 
            // txtProductReportName
            // 
            this.txtProductReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductReportName.Location = new System.Drawing.Point(288, 501);
            this.txtProductReportName.Name = "txtProductReportName";
            this.txtProductReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductReportName.TabIndex = 63;
            this.ttApplicationSettings.SetToolTip(this.txtProductReportName,GLOBAL_RESOURCES.P_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblProductReportName
            // 
            this.lblProductReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductReportName.AutoSize = true;
            this.lblProductReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductReportName.Location = new System.Drawing.Point(25, 504);
            this.lblProductReportName.Name = "lblProductReportName";
            this.lblProductReportName.Size = new System.Drawing.Size(160, 16);
            this.lblProductReportName.TabIndex = 62;
            this.lblProductReportName.Text = GLOBAL_RESOURCES.P_REPORT_NAME_SETTING_TITLE;
            // 
            // txtDeliveryServiceReportName
            // 
            this.txtDeliveryServiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDeliveryServiceReportName.Location = new System.Drawing.Point(288, 471);
            this.txtDeliveryServiceReportName.Name = "txtDeliveryServiceReportName";
            this.txtDeliveryServiceReportName.Size = new System.Drawing.Size(258, 22);
            this.txtDeliveryServiceReportName.TabIndex = 61;
            this.ttApplicationSettings.SetToolTip(this.txtDeliveryServiceReportName, GLOBAL_RESOURCES.DS_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblDeliveryServiceReportName
            // 
            this.lblDeliveryServiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeliveryServiceReportName.AutoSize = true;
            this.lblDeliveryServiceReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryServiceReportName.Location = new System.Drawing.Point(25, 474);
            this.lblDeliveryServiceReportName.Name = "lblDeliveryServiceReportName";
            this.lblDeliveryServiceReportName.Size = new System.Drawing.Size(222, 16);
            this.lblDeliveryServiceReportName.TabIndex = 60;
            this.lblDeliveryServiceReportName.Text = GLOBAL_RESOURCES.DS_REPORT_NAME_SETTING_TITLE;
            // 
            // txtPaymentMethodReportName
            // 
            this.txtPaymentMethodReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPaymentMethodReportName.Location = new System.Drawing.Point(288, 443);
            this.txtPaymentMethodReportName.Name = "txtPaymentMethodReportName";
            this.txtPaymentMethodReportName.Size = new System.Drawing.Size(258, 22);
            this.txtPaymentMethodReportName.TabIndex = 59;
            this.ttApplicationSettings.SetToolTip(this.txtPaymentMethodReportName,GLOBAL_RESOURCES.PM_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblPaymentMethodReportName
            // 
            this.lblPaymentMethodReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentMethodReportName.AutoSize = true;
            this.lblPaymentMethodReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethodReportName.Location = new System.Drawing.Point(25, 446);
            this.lblPaymentMethodReportName.Name = "lblPaymentMethodReportName";
            this.lblPaymentMethodReportName.Size = new System.Drawing.Size(222, 16);
            this.lblPaymentMethodReportName.TabIndex = 58;
            this.lblPaymentMethodReportName.Text = GLOBAL_RESOURCES.PM_REPORT_NAME_SETTING_TITLE;
            // 
            // txtProductVendorReportName
            // 
            this.txtProductVendorReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductVendorReportName.Location = new System.Drawing.Point(288, 416);
            this.txtProductVendorReportName.Name = "txtProductVendorReportName";
            this.txtProductVendorReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductVendorReportName.TabIndex = 57;
            this.ttApplicationSettings.SetToolTip(this.txtProductVendorReportName,GLOBAL_RESOURCES.PV_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblProductVendorReportName
            // 
            this.lblProductVendorReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductVendorReportName.AutoSize = true;
            this.lblProductVendorReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductVendorReportName.Location = new System.Drawing.Point(25, 419);
            this.lblProductVendorReportName.Name = "lblProductVendorReportName";
            this.lblProductVendorReportName.Size = new System.Drawing.Size(214, 16);
            this.lblProductVendorReportName.TabIndex = 56;
            this.lblProductVendorReportName.Text = GLOBAL_RESOURCES.PV_REPORT_NAME_SETTING_TITLE;
            // 
            // txtProductBrandReportName
            // 
            this.txtProductBrandReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductBrandReportName.Location = new System.Drawing.Point(288, 388);
            this.txtProductBrandReportName.Name = "txtProductBrandReportName";
            this.txtProductBrandReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductBrandReportName.TabIndex = 55;
            this.ttApplicationSettings.SetToolTip(this.txtProductBrandReportName, GLOBAL_RESOURCES.PB_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblProductBrandReportName
            // 
            this.lblProductBrandReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductBrandReportName.AutoSize = true;
            this.lblProductBrandReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductBrandReportName.Location = new System.Drawing.Point(25, 391);
            this.lblProductBrandReportName.Name = "lblProductBrandReportName";
            this.lblProductBrandReportName.Size = new System.Drawing.Size(205, 16);
            this.lblProductBrandReportName.TabIndex = 54;
            this.lblProductBrandReportName.Text = GLOBAL_RESOURCES.PB_REPORT_NAME_SETTING_TITLE;
            // 
            // txtClientReportName
            // 
            this.txtClientReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClientReportName.Location = new System.Drawing.Point(288, 360);
            this.txtClientReportName.Name = "txtClientReportName";
            this.txtClientReportName.Size = new System.Drawing.Size(258, 22);
            this.txtClientReportName.TabIndex = 53;
            this.ttApplicationSettings.SetToolTip(this.txtClientReportName, GLOBAL_RESOURCES.CL_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblClientReportName
            // 
            this.lblClientReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClientReportName.AutoSize = true;
            this.lblClientReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientReportName.Location = new System.Drawing.Point(25, 363);
            this.lblClientReportName.Name = "lblClientReportName";
            this.lblClientReportName.Size = new System.Drawing.Size(146, 16);
            this.lblClientReportName.TabIndex = 52;
            this.lblClientReportName.Text = GLOBAL_RESOURCES.CL_REPORT_NAME_SETTING_TITLE;
            // 
            // txtEmployeeReportName
            // 
            this.txtEmployeeReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmployeeReportName.Location = new System.Drawing.Point(288, 334);
            this.txtEmployeeReportName.Name = "txtEmployeeReportName";
            this.txtEmployeeReportName.Size = new System.Drawing.Size(258, 22);
            this.txtEmployeeReportName.TabIndex = 51;
            this.ttApplicationSettings.SetToolTip(this.txtEmployeeReportName,GLOBAL_RESOURCES.EMP_REPORT_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblEmployeeReportName
            // 
            this.lblEmployeeReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmployeeReportName.AutoSize = true;
            this.lblEmployeeReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeReportName.Location = new System.Drawing.Point(25, 337);
            this.lblEmployeeReportName.Name = "lblEmployeeReportName";
            this.lblEmployeeReportName.Size = new System.Drawing.Size(177, 16);
            this.lblEmployeeReportName.TabIndex = 50;
            this.lblEmployeeReportName.Text = GLOBAL_RESOURCES.EMP_REPORT_NAME_SETTING_TITLE;
            // 
            // txtSavedLoginsDirectory
            // 
            this.txtSavedLoginsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSavedLoginsDirectory.Location = new System.Drawing.Point(288, 303);
            this.txtSavedLoginsDirectory.Name = "txtSavedLoginsDirectory";
            this.txtSavedLoginsDirectory.Size = new System.Drawing.Size(258, 22);
            this.txtSavedLoginsDirectory.TabIndex = 49;
            this.ttApplicationSettings.SetToolTip(this.txtSavedLoginsDirectory, GLOBAL_RESOURCES.SAVED_LOGIN_DIR_SETTING_TOOLTIP_TITLE);
            // 
            // lblSavedLoginsDirectory
            // 
            this.lblSavedLoginsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSavedLoginsDirectory.AutoSize = true;
            this.lblSavedLoginsDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavedLoginsDirectory.Location = new System.Drawing.Point(25, 306);
            this.lblSavedLoginsDirectory.Name = "lblSavedLoginsDirectory";
            this.lblSavedLoginsDirectory.Size = new System.Drawing.Size(173, 16);
            this.lblSavedLoginsDirectory.TabIndex = 48;
            this.lblSavedLoginsDirectory.Text = GLOBAL_RESOURCES.SAVED_LOGIN_DIR_SETTING_TITLE;
            // 
            // btnBrowseSavedLoginsDirectory
            // 
            this.btnBrowseSavedLoginsDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSavedLoginsDirectory.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSavedLoginsDirectory.Location = new System.Drawing.Point(552, 303);
            this.btnBrowseSavedLoginsDirectory.Name = "btnBrowseSavedLoginsDirectory";
            this.btnBrowseSavedLoginsDirectory.Size = new System.Drawing.Size(90, 22);
            this.btnBrowseSavedLoginsDirectory.TabIndex = 47;
            this.btnBrowseSavedLoginsDirectory.Text = GLOBAL_RESOURCES.BTN_BROWSE_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnBrowseSavedLoginsDirectory, GLOBAL_RESOURCES.BTN_BROWSE_SAVED_LOGINS_DIR_TOOLTIP_TITLE);
            this.btnBrowseSavedLoginsDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseSavedLoginsDirectory.Click += new System.EventHandler(this.btnBrowseSavedLoginsDirectory_Click);
            // 
            // txtReportDirectory
            // 
            this.txtReportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReportDirectory.Location = new System.Drawing.Point(288, 273);
            this.txtReportDirectory.Name = "txtReportDirectory";
            this.txtReportDirectory.Size = new System.Drawing.Size(258, 22);
            this.txtReportDirectory.TabIndex = 46;
            this.ttApplicationSettings.SetToolTip(this.txtReportDirectory, GLOBAL_RESOURCES.REPORT_DIR_SETTING_TOOLTIP_TITLE);
            // 
            // lblReportDirectory
            // 
            this.lblReportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReportDirectory.AutoSize = true;
            this.lblReportDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDirectory.Location = new System.Drawing.Point(25, 276);
            this.lblReportDirectory.Name = "lblReportDirectory";
            this.lblReportDirectory.Size = new System.Drawing.Size(125, 16);
            this.lblReportDirectory.TabIndex = 45;
            this.lblReportDirectory.Text = GLOBAL_RESOURCES.REPORT_DIR_SETTING_TITLE;
            // 
            // cbLanguage
            // 
            this.cbLanguage.DataSource = this.languageBindingSource;
            this.cbLanguage.DisplayMember = "DisplayName";
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(288, 241);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(258, 24);
            this.cbLanguage.TabIndex = 44;
            this.ttApplicationSettings.SetToolTip(this.cbLanguage, GLOBAL_RESOURCES.LANG_SETTING_TOOLTIP_TITLE);
            this.cbLanguage.ValueMember = "LanguageCode";
            // 
            // languageBindingSource
            // 
            this.languageBindingSource.DataSource = typeof(XtremePharmacyManager.Language);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(25, 241);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(84, 16);
            this.lblLanguage.TabIndex = 43;
            this.lblLanguage.Text = GLOBAL_RESOURCES.LANG_SETTING_TITLE;
            // 
            // btnBrowseReportDirectory
            // 
            this.btnBrowseReportDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseReportDirectory.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseReportDirectory.Location = new System.Drawing.Point(552, 273);
            this.btnBrowseReportDirectory.Name = "btnBrowseReportDirectory";
            this.btnBrowseReportDirectory.Size = new System.Drawing.Size(90, 22);
            this.btnBrowseReportDirectory.TabIndex = 42;
            this.btnBrowseReportDirectory.Text = GLOBAL_RESOURCES.BTN_BROWSE_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnBrowseReportDirectory, GLOBAL_RESOURCES.BTN_BROWSE_REPORT_DIR_TOOLTIP_TITLE);
            this.btnBrowseReportDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseReportDirectory.Click += new System.EventHandler(this.btnBrowseReportDirectory_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCompanyName.Location = new System.Drawing.Point(288, 208);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(258, 22);
            this.txtCompanyName.TabIndex = 41;
            this.ttApplicationSettings.SetToolTip(this.txtCompanyName, GLOBAL_RESOURCES.COMPANY_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(25, 211);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(121, 16);
            this.lblCompanyName.TabIndex = 40;
            this.lblCompanyName.Text = GLOBAL_RESOURCES.COMPANY_NAME_SETTING_TITLE;
            // 
            // txtDatabasePassword
            // 
            this.txtDatabasePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatabasePassword.Location = new System.Drawing.Point(288, 176);
            this.txtDatabasePassword.Name = "txtDatabasePassword";
            this.txtDatabasePassword.Size = new System.Drawing.Size(258, 22);
            this.txtDatabasePassword.TabIndex = 39;
            this.ttApplicationSettings.SetToolTip(this.txtDatabasePassword, GLOBAL_RESOURCES.DB_PASSWORD_SETTING_TOOLTIP_TITLE);
            this.txtDatabasePassword.UseSystemPasswordChar = true;
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDBPassword.AutoSize = true;
            this.lblDBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBPassword.Location = new System.Drawing.Point(25, 179);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(151, 16);
            this.lblDBPassword.TabIndex = 38;
            this.lblDBPassword.Text = GLOBAL_RESOURCES.DB_PASSWORD_SETTING_TITLE;
            // 
            // txtDBUser
            // 
            this.txtDBUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDBUser.Location = new System.Drawing.Point(288, 145);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(258, 22);
            this.txtDBUser.TabIndex = 37;
            this.ttApplicationSettings.SetToolTip(this.txtDBUser, GLOBAL_RESOURCES.DB_USER_SETTING_TOOLTIP_TITLE);
            // 
            // lblDBUser
            // 
            this.lblDBUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDBUser.AutoSize = true;
            this.lblDBUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBUser.Location = new System.Drawing.Point(25, 148);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(116, 16);
            this.lblDBUser.TabIndex = 36;
            this.lblDBUser.Text = GLOBAL_RESOURCES.DB_USER_SETTING_TITLE;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatabaseName.Location = new System.Drawing.Point(288, 112);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(258, 22);
            this.txtDatabaseName.TabIndex = 35;
            this.ttApplicationSettings.SetToolTip(this.txtDatabaseName, GLOBAL_RESOURCES.DB_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.Location = new System.Drawing.Point(25, 115);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(124, 16);
            this.lblDatabaseName.TabIndex = 34;
            this.lblDatabaseName.Text = GLOBAL_RESOURCES.DB_NAME_SETTING_TITLE;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(928, 656);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 47);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = GLOBAL_RESOURCES.BTN_OK_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnOK, GLOBAL_RESOURCES.BTN_OK_APP_SETTINGS_TOOLTIP_TITLE);
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1024, 656);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text =GLOBAL_RESOURCES.BTN_CANCEL_TITLE;
            this.ttApplicationSettings.SetToolTip(this.btnCancel, GLOBAL_RESOURCES.BTN_CANCEL_APP_SETTINGS_TOOLTIP_TITLE);
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtDomainName
            // 
            this.txtDomainName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDomainName.Location = new System.Drawing.Point(288, 79);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(258, 22);
            this.txtDomainName.TabIndex = 4;
            this.ttApplicationSettings.SetToolTip(this.txtDomainName, GLOBAL_RESOURCES.DOMAIN_NAME_SETTING_TOOLTIP_TITLE);
            // 
            // lblDomainName
            // 
            this.lblDomainName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDomainName.AutoSize = true;
            this.lblDomainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomainName.Location = new System.Drawing.Point(25, 82);
            this.lblDomainName.Name = "lblDomainName";
            this.lblDomainName.Size = new System.Drawing.Size(109, 16);
            this.lblDomainName.TabIndex = 3;
            this.lblDomainName.Text = GLOBAL_RESOURCES.DOMAIN_NAME_SETTING_TITLE;
            // 
            // ttApplicationSettings
            // 
            this.ttApplicationSettings.IsBalloon = true;
            this.ttApplicationSettings.ShowAlways = true;
            this.ttApplicationSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttApplicationSettings.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmApplicationSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1152, 715);
            this.Controls.Add(this.pnlData);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmApplicationSettings";
            this.Text = GLOBAL_RESOURCES.APPLICATION_SETTINGS_TITLE;
            this.ttApplicationSettings.SetToolTip(this,GLOBAL_RESOURCES.APPLICATION_SETTINGS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmApplicationSettings_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Label lblDomainName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtDatabasePassword;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label lblDBUser;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnBrowseReportDirectory;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.TextBox txtReportDirectory;
        private System.Windows.Forms.Label lblReportDirectory;
        private System.Windows.Forms.TextBox txtSavedLoginsDirectory;
        private System.Windows.Forms.Label lblSavedLoginsDirectory;
        private System.Windows.Forms.Button btnBrowseSavedLoginsDirectory;
        private System.Windows.Forms.TextBox txtEmployeeReportName;
        private System.Windows.Forms.Label lblEmployeeReportName;
        private System.Windows.Forms.TextBox txtPaymentMethodReportName;
        private System.Windows.Forms.Label lblPaymentMethodReportName;
        private System.Windows.Forms.TextBox txtProductVendorReportName;
        private System.Windows.Forms.Label lblProductVendorReportName;
        private System.Windows.Forms.TextBox txtProductBrandReportName;
        private System.Windows.Forms.Label lblProductBrandReportName;
        private System.Windows.Forms.TextBox txtClientReportName;
        private System.Windows.Forms.Label lblClientReportName;
        private System.Windows.Forms.TextBox txtDeliveryServiceReportName;
        private System.Windows.Forms.Label lblDeliveryServiceReportName;
        private System.Windows.Forms.TextBox txtProductOrderInvoiceReportName;
        private System.Windows.Forms.Label lblProductOrderInvoiceReportName;
        private System.Windows.Forms.TextBox txtProductOrderReportName;
        private System.Windows.Forms.Label lblProductOrderReportName;
        private System.Windows.Forms.TextBox txtProductReportName;
        private System.Windows.Forms.Label lblProductReportName;
        private System.Windows.Forms.TextBox txtOrderDeliveryInvoiceReportName;
        private System.Windows.Forms.Label lblOrderDeliveryInvoiceReportName;
        private System.Windows.Forms.TextBox txtOrderDeliveryReportName;
        private System.Windows.Forms.Label lblOrderDeliveryReportName;
        private System.Windows.Forms.Label lblCommonSettings;
        private System.Windows.Forms.Label lblLanguageExtensibilitySettings;
        private System.Windows.Forms.BindingSource languageBindingSource;
        private System.Windows.Forms.Label lblFoundCultureInfos;
        private System.Windows.Forms.ListView lstFoundCultureInfos;
        private System.Windows.Forms.ColumnHeader CultureDisplayNameColumn;
        private System.Windows.Forms.ColumnHeader CultureCodeColumn;
        private System.Windows.Forms.TextBox txtSearchCulture;
        private System.Windows.Forms.Button btnSearchCultureInfo;
        private System.Windows.Forms.Button btnAddLanguage;
        private System.Windows.Forms.ListView lstLanguagesInList;
        private System.Windows.Forms.ColumnHeader LanguageDisplayNameColumn;
        private System.Windows.Forms.ColumnHeader LanguageCodeColumn;
        private System.Windows.Forms.Button btnRemoveLanguage;
        private System.Windows.Forms.ToolTip ttApplicationSettings;
    }
}