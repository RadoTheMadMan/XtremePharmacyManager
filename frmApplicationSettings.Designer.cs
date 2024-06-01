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
            this.btnRemoveLanguage.Text = "REMOVE LANGUAGE";
            this.ttApplicationSettings.SetToolTip(this.btnRemoveLanguage, "Select a language from the list to remove it if you don\'t want to use it for loca" +
        "lisation.");
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
            this.btnAddLanguage.Text = "ADD LANGUAGE";
            this.ttApplicationSettings.SetToolTip(this.btnAddLanguage, resources.GetString("btnAddLanguage.ToolTip"));
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
            this.ttApplicationSettings.SetToolTip(this.lstLanguagesInList, "The application languages list. If you want to add new language it be sure to loc" +
        "alise the reports and the resource file of the application. It is up to you");
            this.lstLanguagesInList.UseCompatibleStateImageBehavior = false;
            this.lstLanguagesInList.View = System.Windows.Forms.View.Details;
            // 
            // LanguageDisplayNameColumn
            // 
            this.LanguageDisplayNameColumn.Text = "Language Display Name";
            this.LanguageDisplayNameColumn.Width = 265;
            // 
            // LanguageCodeColumn
            // 
            this.LanguageCodeColumn.Text = "Language Code";
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
            this.btnSearchCultureInfo.Text = "SEARCH CULTURE INFO";
            this.ttApplicationSettings.SetToolTip(this.btnSearchCultureInfo, "Click to search culture info");
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
            this.ttApplicationSettings.SetToolTip(this.txtSearchCulture, "Here you can search culture info based on the version of .Net Framework you are o" +
        "n. 4.7.2 and above is required, you know?");
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
            this.ttApplicationSettings.SetToolTip(this.lstFoundCultureInfos, "Select any culture you want to localise your application with. It is up to you");
            this.lstFoundCultureInfos.UseCompatibleStateImageBehavior = false;
            this.lstFoundCultureInfos.View = System.Windows.Forms.View.Details;
            // 
            // CultureDisplayNameColumn
            // 
            this.CultureDisplayNameColumn.Text = "Culture Display Name";
            this.CultureDisplayNameColumn.Width = 265;
            // 
            // CultureCodeColumn
            // 
            this.CultureCodeColumn.Text = "Culture Code";
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
            this.lblFoundCultureInfos.Text = "Found Culture Informations:";
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
            this.lblLanguageExtensibilitySettings.Text = "Language Extensibility Settings";
            this.ttApplicationSettings.SetToolTip(this.lblLanguageExtensibilitySettings, "The settings for adding and removing language and then manually extending the app" +
        "lication to reflect on them. It is up to you to extend it");
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
            this.lblCommonSettings.Text = "Common Settings";
            this.ttApplicationSettings.SetToolTip(this.lblCommonSettings, "Common settings for this application");
            // 
            // txtOrderDeliveryInvoiceReportName
            // 
            this.txtOrderDeliveryInvoiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOrderDeliveryInvoiceReportName.Location = new System.Drawing.Point(288, 621);
            this.txtOrderDeliveryInvoiceReportName.Name = "txtOrderDeliveryInvoiceReportName";
            this.txtOrderDeliveryInvoiceReportName.Size = new System.Drawing.Size(258, 22);
            this.txtOrderDeliveryInvoiceReportName.TabIndex = 71;
            this.ttApplicationSettings.SetToolTip(this.txtOrderDeliveryInvoiceReportName, resources.GetString("txtOrderDeliveryInvoiceReportName.ToolTip"));
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
            this.lblOrderDeliveryInvoiceReportName.Text = "Order Delivery Invoice Report Name:";
            // 
            // txtOrderDeliveryReportName
            // 
            this.txtOrderDeliveryReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOrderDeliveryReportName.Location = new System.Drawing.Point(288, 591);
            this.txtOrderDeliveryReportName.Name = "txtOrderDeliveryReportName";
            this.txtOrderDeliveryReportName.Size = new System.Drawing.Size(258, 22);
            this.txtOrderDeliveryReportName.TabIndex = 69;
            this.ttApplicationSettings.SetToolTip(this.txtOrderDeliveryReportName, "The name of the report file that the program looks for order delivery reports. It" +
        " needs to include the language code localisation, for example OrderDeliveryRepor" +
        "t.en-US.rdlc for English and etc");
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
            this.lblOrderDeliveryReportName.Text = "Order Delivery Report Name:";
            // 
            // txtProductOrderInvoiceReportName
            // 
            this.txtProductOrderInvoiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductOrderInvoiceReportName.Location = new System.Drawing.Point(288, 561);
            this.txtProductOrderInvoiceReportName.Name = "txtProductOrderInvoiceReportName";
            this.txtProductOrderInvoiceReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductOrderInvoiceReportName.TabIndex = 67;
            this.ttApplicationSettings.SetToolTip(this.txtProductOrderInvoiceReportName, "The name of the report file that the program looks for product order invoices. It" +
        " needs to include the language code localisation, for example ProductOrderInvoic" +
        "eReport.en-US.rdlc for English and etc");
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
            this.lblProductOrderInvoiceReportName.Text = "Product Order Invoice Report Name:";
            // 
            // txtProductOrderReportName
            // 
            this.txtProductOrderReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductOrderReportName.Location = new System.Drawing.Point(288, 531);
            this.txtProductOrderReportName.Name = "txtProductOrderReportName";
            this.txtProductOrderReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductOrderReportName.TabIndex = 65;
            this.ttApplicationSettings.SetToolTip(this.txtProductOrderReportName, "The name of the report file that the program looks for product order reports. It " +
        "needs to include the language code localisation, for example ProductOrderReport." +
        "en-US.rdlc for English and etc");
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
            this.lblProductOrderReportName.Text = "Product Order Report Name:";
            // 
            // txtProductReportName
            // 
            this.txtProductReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductReportName.Location = new System.Drawing.Point(288, 501);
            this.txtProductReportName.Name = "txtProductReportName";
            this.txtProductReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductReportName.TabIndex = 63;
            this.ttApplicationSettings.SetToolTip(this.txtProductReportName, "The name of the report file that the program looks for product reports. It needs " +
        "to include the language code localisation, for example ProductReport.en-US.rdlc " +
        "for English and etc");
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
            this.lblProductReportName.Text = "Product Report Name:";
            // 
            // txtDeliveryServiceReportName
            // 
            this.txtDeliveryServiceReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDeliveryServiceReportName.Location = new System.Drawing.Point(288, 471);
            this.txtDeliveryServiceReportName.Name = "txtDeliveryServiceReportName";
            this.txtDeliveryServiceReportName.Size = new System.Drawing.Size(258, 22);
            this.txtDeliveryServiceReportName.TabIndex = 61;
            this.ttApplicationSettings.SetToolTip(this.txtDeliveryServiceReportName, "The name of the report file that the program looks for delivery service reports. " +
        "It needs to include the language code localisation, for example DeliveryServiceR" +
        "eport.en-US.rdlc for English and etc");
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
            this.lblDeliveryServiceReportName.Text = "Delivery Service Report Name:";
            // 
            // txtPaymentMethodReportName
            // 
            this.txtPaymentMethodReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPaymentMethodReportName.Location = new System.Drawing.Point(288, 443);
            this.txtPaymentMethodReportName.Name = "txtPaymentMethodReportName";
            this.txtPaymentMethodReportName.Size = new System.Drawing.Size(258, 22);
            this.txtPaymentMethodReportName.TabIndex = 59;
            this.ttApplicationSettings.SetToolTip(this.txtPaymentMethodReportName, "The name of the report file that the program looks for payment method reports. It" +
        " needs to include the language code localisation, for example PaymentMethodRepor" +
        "t.en-US.rdlc for English and etc");
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
            this.lblPaymentMethodReportName.Text = "Payment Method Report Name:";
            // 
            // txtProductVendorReportName
            // 
            this.txtProductVendorReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductVendorReportName.Location = new System.Drawing.Point(288, 416);
            this.txtProductVendorReportName.Name = "txtProductVendorReportName";
            this.txtProductVendorReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductVendorReportName.TabIndex = 57;
            this.ttApplicationSettings.SetToolTip(this.txtProductVendorReportName, "The name of the report file that the program looks for product vendor reports. It" +
        " needs to include the language code localisation, for example ProductVendorRepor" +
        "t.en-US.rdlc for English and etc");
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
            this.lblProductVendorReportName.Text = "Product Vendor Report Name:";
            // 
            // txtProductBrandReportName
            // 
            this.txtProductBrandReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductBrandReportName.Location = new System.Drawing.Point(288, 388);
            this.txtProductBrandReportName.Name = "txtProductBrandReportName";
            this.txtProductBrandReportName.Size = new System.Drawing.Size(258, 22);
            this.txtProductBrandReportName.TabIndex = 55;
            this.ttApplicationSettings.SetToolTip(this.txtProductBrandReportName, "The name of the report file that the program looks for product brand reports. It " +
        "needs to include the language code localisation, for example ProductBrandReport." +
        "en-US.rdlc for English and etc");
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
            this.lblProductBrandReportName.Text = "Product Brand Report Name:";
            // 
            // txtClientReportName
            // 
            this.txtClientReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClientReportName.Location = new System.Drawing.Point(288, 360);
            this.txtClientReportName.Name = "txtClientReportName";
            this.txtClientReportName.Size = new System.Drawing.Size(258, 22);
            this.txtClientReportName.TabIndex = 53;
            this.ttApplicationSettings.SetToolTip(this.txtClientReportName, "The name of the report file that the program looks for client reports. It needs t" +
        "o include the language code localisation, for example ClientReport.en-US.rdlc fo" +
        "r English and etc");
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
            this.lblClientReportName.Text = "Client Report Name:";
            // 
            // txtEmployeeReportName
            // 
            this.txtEmployeeReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmployeeReportName.Location = new System.Drawing.Point(288, 334);
            this.txtEmployeeReportName.Name = "txtEmployeeReportName";
            this.txtEmployeeReportName.Size = new System.Drawing.Size(258, 22);
            this.txtEmployeeReportName.TabIndex = 51;
            this.ttApplicationSettings.SetToolTip(this.txtEmployeeReportName, "The name of the report file that the program looks for employee reports. It needs" +
        " to include the language code localisation, for example EmployeeReport.en-US.rdl" +
        "c for English and etc");
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
            this.lblEmployeeReportName.Text = "Employee Report Name:";
            // 
            // txtSavedLoginsDirectory
            // 
            this.txtSavedLoginsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSavedLoginsDirectory.Location = new System.Drawing.Point(288, 303);
            this.txtSavedLoginsDirectory.Name = "txtSavedLoginsDirectory";
            this.txtSavedLoginsDirectory.Size = new System.Drawing.Size(258, 22);
            this.txtSavedLoginsDirectory.TabIndex = 49;
            this.ttApplicationSettings.SetToolTip(this.txtSavedLoginsDirectory, resources.GetString("txtSavedLoginsDirectory.ToolTip"));
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
            this.lblSavedLoginsDirectory.Text = "Saved Logins Directory:";
            // 
            // btnBrowseSavedLoginsDirectory
            // 
            this.btnBrowseSavedLoginsDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSavedLoginsDirectory.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSavedLoginsDirectory.Location = new System.Drawing.Point(552, 303);
            this.btnBrowseSavedLoginsDirectory.Name = "btnBrowseSavedLoginsDirectory";
            this.btnBrowseSavedLoginsDirectory.Size = new System.Drawing.Size(90, 22);
            this.btnBrowseSavedLoginsDirectory.TabIndex = 47;
            this.btnBrowseSavedLoginsDirectory.Text = "BROWSE";
            this.ttApplicationSettings.SetToolTip(this.btnBrowseSavedLoginsDirectory, "Browse the directory you wish to use to save and load logins here with ease");
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
            this.ttApplicationSettings.SetToolTip(this.txtReportDirectory, resources.GetString("txtReportDirectory.ToolTip"));
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
            this.lblReportDirectory.Text = "Report Directory:";
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
            this.ttApplicationSettings.SetToolTip(this.cbLanguage, resources.GetString("cbLanguage.ToolTip"));
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
            this.lblLanguage.Text = "Lamguage:";
            // 
            // btnBrowseReportDirectory
            // 
            this.btnBrowseReportDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseReportDirectory.Font = new System.Drawing.Font("Franklin Gothic Medium", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseReportDirectory.Location = new System.Drawing.Point(552, 273);
            this.btnBrowseReportDirectory.Name = "btnBrowseReportDirectory";
            this.btnBrowseReportDirectory.Size = new System.Drawing.Size(90, 22);
            this.btnBrowseReportDirectory.TabIndex = 42;
            this.btnBrowseReportDirectory.Text = "BROWSE";
            this.ttApplicationSettings.SetToolTip(this.btnBrowseReportDirectory, "You can easily browse the directory from which the application gets the report fi" +
        "les");
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
            this.ttApplicationSettings.SetToolTip(this.txtCompanyName, "The name of your company or the company you work on. It is represented in the rep" +
        "orts");
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
            this.lblCompanyName.Text = "Company Name:";
            // 
            // txtDatabasePassword
            // 
            this.txtDatabasePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatabasePassword.Location = new System.Drawing.Point(288, 176);
            this.txtDatabasePassword.Name = "txtDatabasePassword";
            this.txtDatabasePassword.Size = new System.Drawing.Size(258, 22);
            this.txtDatabasePassword.TabIndex = 39;
            this.ttApplicationSettings.SetToolTip(this.txtDatabasePassword, "The password according to the user you log yourself in to the database.");
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
            this.lblDBPassword.Text = "Database Password:";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDBUser.Location = new System.Drawing.Point(288, 145);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(258, 22);
            this.txtDBUser.TabIndex = 37;
            this.ttApplicationSettings.SetToolTip(this.txtDBUser, "The database user with which you need to login on the database, it is tightly con" +
        "nected to the registration in the database and to the role you represent in your" +
        " company");
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
            this.lblDBUser.Text = "Database User:";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatabaseName.Location = new System.Drawing.Point(288, 112);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(258, 22);
            this.txtDatabaseName.TabIndex = 35;
            this.ttApplicationSettings.SetToolTip(this.txtDatabaseName, "The database name of this application. If you have changed the database name in t" +
        "he provided query that sets it up which is not recommended you need to change it" +
        " here as well");
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
            this.lblDatabaseName.Text = "Database Name:";
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
            this.btnOK.Text = "OK";
            this.ttApplicationSettings.SetToolTip(this.btnOK, "Accept the changes, by clicking it they are saved otherwise nothing gets changed." +
        "The settings reflect on the application once it is restarted");
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
            this.btnCancel.Text = "CANCEL";
            this.ttApplicationSettings.SetToolTip(this.btnCancel, "Cancel the changes. Even if you changed anything it won\'t be saved and will be re" +
        "verted back to the previous settings");
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
            this.ttApplicationSettings.SetToolTip(this.txtDomainName, "The domain name of your company\'s server to which this application connects. Be c" +
        "areful when changing it or let a system administrator set it up for you");
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
            this.lblDomainName.Text = "Domain Name:";
            // 
            // ttApplicationSettings
            // 
            this.ttApplicationSettings.IsBalloon = true;
            this.ttApplicationSettings.ShowAlways = true;
            this.ttApplicationSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttApplicationSettings.ToolTipTitle = "Help";
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
            this.Text = "Application Settings";
            this.ttApplicationSettings.SetToolTip(this, resources.GetString("$this.ToolTip"));
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