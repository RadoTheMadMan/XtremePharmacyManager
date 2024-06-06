using System.Reflection;

namespace XtremePharmacyManager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuApplicationSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuProductBrands = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuProductVendors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuPaymentMethods = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuDeliveryServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuProductOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuOrderDeliveries = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkUserOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkProductBrandOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkProductVendorOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkPaymentMethodOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkDeliveryServiceOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkProductOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkProductImageOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkProductOrderOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBulkOrderDeliveryOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuDebugTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuTestConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBitmapToBinary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuFile,
            this.tsmenuAccountSettings,
            this.tsmenuWindow,
            this.tsmenuDebugTools,
            this.tsmenuHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1348, 28);
            this.msMain.TabIndex = 1;
            this.msMain.Text = GLOBAL_RESOURCES.MAIN_MENU_TITLE;
            // 
            // tsmenuFile
            // 
            this.tsmenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuApplicationSettings,
            this.tsmenuExit});
            this.tsmenuFile.Name = "tsmenuFile";
            this.tsmenuFile.Size = new System.Drawing.Size(46, 26);
            this.tsmenuFile.Text = GLOBAL_RESOURCES.FILE_MENU_TITLE;
            this.tsmenuFile.ToolTipText = GLOBAL_RESOURCES.FILE_MENU_TOOLTIP_TITLE;
            // 
            // tsmenuApplicationSettings
            // 
            this.tsmenuApplicationSettings.Name = "tsmenuApplicationSettings";
            this.tsmenuApplicationSettings.Size = new System.Drawing.Size(226, 26);
            this.tsmenuApplicationSettings.Text = GLOBAL_RESOURCES.APP_SETTINGS_MENU_TITLE;
            this.tsmenuApplicationSettings.ToolTipText = GLOBAL_RESOURCES.APP_SETTINGS_MENU_TOOLTIP_TITLE;
            this.tsmenuApplicationSettings.Click += new System.EventHandler(this.tsmenuApplicationSettings_Click);
            // 
            // tsmenuExit
            // 
            this.tsmenuExit.Name = "tsmenuExit";
            this.tsmenuExit.Size = new System.Drawing.Size(226, 26);
            this.tsmenuExit.Text = GLOBAL_RESOURCES.EXIT_MENU_TITLE;
            this.tsmenuExit.ToolTipText = GLOBAL_RESOURCES.EXIT_MENU_TOOLTIP_TITLE;
            this.tsmenuExit.Click += new System.EventHandler(this.tsmenuExit_Click);
            // 
            // tsmenuAccountSettings
            // 
            this.tsmenuAccountSettings.Name = "tsmenuAccountSettings";
            this.tsmenuAccountSettings.Size = new System.Drawing.Size(134, 24);
            this.tsmenuAccountSettings.Text = GLOBAL_RESOURCES.ACC_SETTINGS_MENU_TITLE;
            this.tsmenuAccountSettings.ToolTipText = GLOBAL_RESOURCES.ACC_SETTINGS_MENU_TOOLTIP_TITLE;
            this.tsmenuAccountSettings.Click += new System.EventHandler(this.tsmenuAccountSettings_Click);
            // 
            // tsmenuWindow
            // 
            this.tsmenuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuUsers,
            this.tsmenuProductBrands,
            this.tsmenuProductVendors,
            this.tsmenuPaymentMethods,
            this.tsmenuDeliveryServices,
            this.tsmenuProducts,
            this.tsmenuProductOrders,
            this.tsmenuOrderDeliveries,
            this.tsmenuLogs,
            this.tsmenuBulkOperations});
            this.tsmenuWindow.Name = "tsmenuWindow";
            this.tsmenuWindow.Size = new System.Drawing.Size(78, 24);
            this.tsmenuWindow.Text = GLOBAL_RESOURCES.WINDOW_MENU_TITLE;
            this.tsmenuWindow.ToolTipText = GLOBAL_RESOURCES.WINDOW_MENU_TOOLTIP_TITLE;
            // 
            // tsmenuUsers
            // 
            this.tsmenuUsers.Name = "tsmenuUsers";
            this.tsmenuUsers.Size = new System.Drawing.Size(224, 26);
            this.tsmenuUsers.Text = GLOBAL_RESOURCES.USERS_TITLE;
            this.tsmenuUsers.ToolTipText = GLOBAL_RESOURCES.USERS_MENU_TOOLTIP_TITLE;
            this.tsmenuUsers.Click += new System.EventHandler(this.tsmenuUsers_Click);
            // 
            // tsmenuProductBrands
            // 
            this.tsmenuProductBrands.Name = "tsmenuProductBrands";
            this.tsmenuProductBrands.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProductBrands.Text = GLOBAL_RESOURCES.PRODUCT_BRANDS_TITLE;
            this.tsmenuProductBrands.ToolTipText = GLOBAL_RESOURCES.BRANDS_MENU_TOOLTIP_TITLE;
            this.tsmenuProductBrands.Click += new System.EventHandler(this.tsmenuProductBrands_Click);
            // 
            // tsmenuProductVendors
            // 
            this.tsmenuProductVendors.Name = "tsmenuProductVendors";
            this.tsmenuProductVendors.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProductVendors.Text = GLOBAL_RESOURCES.VENDORS_TITLE;
            this.tsmenuProductVendors.ToolTipText = GLOBAL_RESOURCES.VENDORS_MENU_TOOLTIP_TITLE;
            this.tsmenuProductVendors.Click += new System.EventHandler(this.tsmenuProductVendors_Click);
            // 
            // tsmenuPaymentMethods
            // 
            this.tsmenuPaymentMethods.Name = "tsmenuPaymentMethods";
            this.tsmenuPaymentMethods.Size = new System.Drawing.Size(224, 26);
            this.tsmenuPaymentMethods.Text = GLOBAL_RESOURCES.PAYMENT_METHODS_TITLE;
            this.tsmenuPaymentMethods.ToolTipText = GLOBAL_RESOURCES.PAYMENT_METHODS_MENU_TOOLTIP_TITLE;
            this.tsmenuPaymentMethods.Click += new System.EventHandler(this.tsmenuPaymentMethods_Click);
            // 
            // tsmenuDeliveryServices
            // 
            this.tsmenuDeliveryServices.Name = "tsmenuDeliveryServices";
            this.tsmenuDeliveryServices.Size = new System.Drawing.Size(224, 26);
            this.tsmenuDeliveryServices.Text = GLOBAL_RESOURCES.DELIVERY_SERVICES_TITLE;
            this.tsmenuDeliveryServices.ToolTipText = GLOBAL_RESOURCES.DELIVERY_SERVICES_MENU_TOOLTIP_TITLE;
            this.tsmenuDeliveryServices.Click += new System.EventHandler(this.tsmenuDeliveryServices_Click);
            // 
            // tsmenuProducts
            // 
            this.tsmenuProducts.Name = "tsmenuProducts";
            this.tsmenuProducts.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProducts.Text = GLOBAL_RESOURCES.PRODUCTS_TITLE;
            this.tsmenuProducts.ToolTipText = GLOBAL_RESOURCES.PRODUCTS_MENU_TOOLTIP_TITLE;
            this.tsmenuProducts.Click += new System.EventHandler(this.tsmenuProducts_Click);
            // 
            // tsmenuProductOrders
            // 
            this.tsmenuProductOrders.Name = "tsmenuProductOrders";
            this.tsmenuProductOrders.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProductOrders.Text = GLOBAL_RESOURCES.PRODUCT_ORDERS_TITLE;
            this.tsmenuProductOrders.ToolTipText = GLOBAL_RESOURCES.PRODUCT_ORDERS_MENU_TOOLTIP_TITLE;
            this.tsmenuProductOrders.Click += new System.EventHandler(this.tsmenuProductOrders_Click);
            // 
            // tsmenuOrderDeliveries
            // 
            this.tsmenuOrderDeliveries.Name = "tsmenuOrderDeliveries";
            this.tsmenuOrderDeliveries.Size = new System.Drawing.Size(224, 26);
            this.tsmenuOrderDeliveries.Text = GLOBAL_RESOURCES.ORDER_DELIVERIES_TITLE;
            this.tsmenuOrderDeliveries.ToolTipText = GLOBAL_RESOURCES.ORDER_DELIVERIES_MENU_TOOLTIP_TTILE;
            this.tsmenuOrderDeliveries.Click += new System.EventHandler(this.tsmenuOrderDeliveries_Click);
            // 
            // tsmenuLogs
            // 
            this.tsmenuLogs.Name = "tsmenuLogs";
            this.tsmenuLogs.Size = new System.Drawing.Size(224, 26);
            this.tsmenuLogs.Text = GLOBAL_RESOURCES.LOGS_TITLE;
            this.tsmenuLogs.ToolTipText = GLOBAL_RESOURCES. LOGS_MENU_TOOLTIP_TITLE;
            this.tsmenuLogs.Click += new System.EventHandler(this.tsmenuLogs_Click);
            // 
            // tsmenuBulkOperations
            // 
            this.tsmenuBulkOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuBulkUserOperations,
            this.tsmenuBulkProductBrandOperations,
            this.tsmenuBulkProductVendorOperations,
            this.tsmenuBulkPaymentMethodOperations,
            this.tsmenuBulkDeliveryServiceOperations,
            this.tsmenuBulkProductOperations,
            this.tsmenuBulkProductImageOperations,
            this.tsmenuBulkProductOrderOperations,
            this.tsmenuBulkOrderDeliveryOperations});
            this.tsmenuBulkOperations.Name = "tsmenuBulkOperations";
            this.tsmenuBulkOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkOperations.Text = $"{GLOBAL_RESOURCES.BULK_OPERATIONS_TITLE}";
            this.tsmenuBulkOperations.ToolTipText = GLOBAL_RESOURCES.BULK_MENU_TOOLTIP_TITLE;
            // 
            // tsmenuBulkUserOperations
            // 
            this.tsmenuBulkUserOperations.Name = "tsmenuBulkUserOperations";
            this.tsmenuBulkUserOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkUserOperations.Text = GLOBAL_RESOURCES.USERS_TITLE;
            this.tsmenuBulkUserOperations.ToolTipText = GLOBAL_RESOURCES.BULK_USER_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkUserOperations.Click += new System.EventHandler(this.tsmenuBulkUserOperations_Click);
            // 
            // tsmenuBulkProductBrandOperations
            // 
            this.tsmenuBulkProductBrandOperations.Name = "tsmenuBulkProductBrandOperations";
            this.tsmenuBulkProductBrandOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductBrandOperations.Text = GLOBAL_RESOURCES.PRODUCT_BRANDS_TITLE;
            this.tsmenuBulkProductBrandOperations.ToolTipText =GLOBAL_RESOURCES.BULK_BRAND_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkProductBrandOperations.Click += new System.EventHandler(this.tsmenuBulkProductBrandOperations_Click);
            // 
            // tsmenuBulkProductVendorOperations
            // 
            this.tsmenuBulkProductVendorOperations.Name = "tsmenuBulkProductVendorOperations";
            this.tsmenuBulkProductVendorOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductVendorOperations.Text = GLOBAL_RESOURCES.VENDORS_TITLE;
            this.tsmenuBulkProductVendorOperations.ToolTipText = GLOBAL_RESOURCES.BULK_VENDOR_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkProductVendorOperations.Click += new System.EventHandler(this.tsmenuBulkProductVendorOperations_Click);
            // 
            // tsmenuBulkPaymentMethodOperations
            // 
            this.tsmenuBulkPaymentMethodOperations.Name = "tsmenuBulkPaymentMethodOperations";
            this.tsmenuBulkPaymentMethodOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkPaymentMethodOperations.Text = GLOBAL_RESOURCES.PAYMENT_METHODS_TITLE;
            this.tsmenuBulkPaymentMethodOperations.ToolTipText = GLOBAL_RESOURCES.BULK_PAYMENT_METHOD_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkPaymentMethodOperations.Click += new System.EventHandler(this.tsmenuBulkPaymentMethodOperations_Click);
            // 
            // tsmenuBulkDeliveryServiceOperations
            // 
            this.tsmenuBulkDeliveryServiceOperations.Name = "tsmenuBulkDeliveryServiceOperations";
            this.tsmenuBulkDeliveryServiceOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkDeliveryServiceOperations.Text = GLOBAL_RESOURCES.DELIVERY_SERVICES_TITLE;
            this.tsmenuBulkDeliveryServiceOperations.ToolTipText = GLOBAL_RESOURCES.BULK_DELIVERY_SERVICE_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkDeliveryServiceOperations.Click += new System.EventHandler(this.tsmenuBulkDeliveryServiceOperations_Click);
            // 
            // tsmenuBulkProductOperations
            // 
            this.tsmenuBulkProductOperations.Name = "tsmenuBulkProductOperations";
            this.tsmenuBulkProductOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductOperations.Text = GLOBAL_RESOURCES.PRODUCTS_TITLE;
            this.tsmenuBulkProductOperations.ToolTipText = GLOBAL_RESOURCES.BULK_PRODUCT_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkProductOperations.Click += new System.EventHandler(this.tsmenuBulkProductOperations_Click);
            // 
            // tsmenuBulkProductImageOperations
            // 
            this.tsmenuBulkProductImageOperations.Name = "tsmenuBulkProductImageOperations";
            this.tsmenuBulkProductImageOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductImageOperations.Text = GLOBAL_RESOURCES. PRODUCT_IMAGES_TITLE;
            this.tsmenuBulkProductImageOperations.ToolTipText = GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkProductImageOperations.Click += new System.EventHandler(this.tsmenuBulkProductImageOperations_Click);
            // 
            // tsmenuBulkProductOrderOperations
            // 
            this.tsmenuBulkProductOrderOperations.Name = "tsmenuBulkProductOrderOperations";
            this.tsmenuBulkProductOrderOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductOrderOperations.Text = GLOBAL_RESOURCES.PRODUCT_ORDERS_TITLE;
            this.tsmenuBulkProductOrderOperations.ToolTipText = GLOBAL_RESOURCES.BULK_PRODUCT_ORDER_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkProductOrderOperations.Click += new System.EventHandler(this.tsmenuBulkProductOrderOperations_Click);
            // 
            // tsmenuBulkOrderDeliveryOperations
            // 
            this.tsmenuBulkOrderDeliveryOperations.Name = "tsmenuBulkOrderDeliveryOperations";
            this.tsmenuBulkOrderDeliveryOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkOrderDeliveryOperations.Text = GLOBAL_RESOURCES.ORDER_DELIVERIES_TITLE;
            this.tsmenuBulkOrderDeliveryOperations.ToolTipText = GLOBAL_RESOURCES.BULK_ORDER_DELIVERY_MENU_TOOLTIP_TITLE;
            this.tsmenuBulkOrderDeliveryOperations.Click += new System.EventHandler(this.tsmenuBulkOrderDeliveryOperations_Click);
            // 
            // tsmenuDebugTools
            // 
            this.tsmenuDebugTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuTestConnection,
            this.tsmenuBitmapToBinary});
            this.tsmenuDebugTools.Name = "tsmenuDebugTools";
            this.tsmenuDebugTools.Size = new System.Drawing.Size(107, 24);
            this.tsmenuDebugTools.Text = GLOBAL_RESOURCES.DEBUG_TOOLS_TITLE;
            this.tsmenuDebugTools.ToolTipText = GLOBAL_RESOURCES.DEBUG_TOOLS_MENU_TOOLTIP_TITLE;
            // 
            // tsmenuTestConnection
            // 
            this.tsmenuTestConnection.Name = "tsmenuTestConnection";
            this.tsmenuTestConnection.Size = new System.Drawing.Size(224, 26);
            this.tsmenuTestConnection.Text = GLOBAL_RESOURCES.TEST_CONNECTION_TITLE;
            this.tsmenuTestConnection.ToolTipText = GLOBAL_RESOURCES.TEST_CONNECTION_MENU_TOOLTIP_TITLE;
            this.tsmenuTestConnection.Click += new System.EventHandler(this.tsmenuTestConnection_Click);
            // 
            // tsmenuBitmapToBinary
            // 
            this.tsmenuBitmapToBinary.Name = "tsmenuBitmapToBinary";
            this.tsmenuBitmapToBinary.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBitmapToBinary.Text = GLOBAL_RESOURCES.IMG_BIN_TITLE;
            this.tsmenuBitmapToBinary.ToolTipText = GLOBAL_RESOURCES.IMG_BIN_MENU_TOOLTIP_TITLE;
            this.tsmenuBitmapToBinary.Click += new System.EventHandler(this.tsmenuBitmapToBinary_Click);
            // 
            // tsmenuHelp
            // 
            this.tsmenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuAbout});
            this.tsmenuHelp.Name = "tsmenuHelp";
            this.tsmenuHelp.Size = new System.Drawing.Size(55, 24);
            this.tsmenuHelp.Text = GLOBAL_RESOURCES.HELP_TITLE;
            this.tsmenuHelp.ToolTipText = GLOBAL_RESOURCES.HELP_MENU_TOOLTIP_TITLE;
            // 
            // tsmenuAbout
            // 
            this.tsmenuAbout.Name = "tsmenuAbout";
            this.tsmenuAbout.Size = new System.Drawing.Size(224, 26);
            this.tsmenuAbout.Text = GLOBAL_RESOURCES.ABOUT_MENU_TITLE;
            this.tsmenuAbout.ToolTipText = GLOBAL_RESOURCES.ABOUT_MENU_TOOLTIP_TITLE;
            this.tsmenuAbout.Click += new System.EventHandler(this.tsmenuAbout_Click);
            // 
            // ttMain
            // 
            this.ttMain.IsBalloon = true;
            this.ttMain.ShowAlways = true;
            this.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttMain.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = GLOBAL_RESOURCES.ASSEMBLY_PRODUCT_NAME;
            this.ttMain.SetToolTip(this, GLOBAL_RESOURCES.MAIN_FORM_TOOLTIP_TITLE);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmenuFile;
        private System.Windows.Forms.ToolStripMenuItem tsmenuAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmenuDebugTools;
        private System.Windows.Forms.ToolStripMenuItem tsmenuTestConnection;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBitmapToBinary;
        private System.Windows.Forms.ToolStripMenuItem tsmenuWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmenuUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmenuDeliveryServices;
        private System.Windows.Forms.ToolStripMenuItem tsmenuPaymentMethods;
        private System.Windows.Forms.ToolStripMenuItem tsmenuProductBrands;
        private System.Windows.Forms.ToolStripMenuItem tsmenuProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmenuProductOrders;
        private System.Windows.Forms.ToolStripMenuItem tsmenuOrderDeliveries;
        private System.Windows.Forms.ToolStripMenuItem tsmenuLogs;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkUserOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkProductBrandOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkPaymentMethodOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkDeliveryServiceOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkProductOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkProductImageOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkProductOrderOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkOrderDeliveryOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuProductVendors;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBulkProductVendorOperations;
        private System.Windows.Forms.ToolStripMenuItem tsmenuApplicationSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmenuExit;
        private System.Windows.Forms.ToolStripMenuItem tsmenuHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmenuAbout;
        private System.Windows.Forms.ToolTip ttMain;
    }
}

