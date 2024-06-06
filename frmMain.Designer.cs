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
            this.msMain.Text = "menuStrip1";
            // 
            // tsmenuFile
            // 
            this.tsmenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuApplicationSettings,
            this.tsmenuExit});
            this.tsmenuFile.Name = "tsmenuFile";
            this.tsmenuFile.Size = new System.Drawing.Size(46, 26);
            this.tsmenuFile.Text = "&File";
            this.tsmenuFile.ToolTipText = "File menu..or is it?";
            // 
            // tsmenuApplicationSettings
            // 
            this.tsmenuApplicationSettings.Name = "tsmenuApplicationSettings";
            this.tsmenuApplicationSettings.Size = new System.Drawing.Size(226, 26);
            this.tsmenuApplicationSettings.Text = "Application Settings";
            this.tsmenuApplicationSettings.ToolTipText = "The settings for the application. Use this dialog with caution and only if you kn" +
    "ow what you are doing.";
            this.tsmenuApplicationSettings.Click += new System.EventHandler(this.tsmenuApplicationSettings_Click);
            // 
            // tsmenuExit
            // 
            this.tsmenuExit.Name = "tsmenuExit";
            this.tsmenuExit.Size = new System.Drawing.Size(226, 26);
            this.tsmenuExit.Text = "Exit";
            this.tsmenuExit.ToolTipText = "The exiting of the application, similar to when you click its close button";
            this.tsmenuExit.Click += new System.EventHandler(this.tsmenuExit_Click);
            // 
            // tsmenuAccountSettings
            // 
            this.tsmenuAccountSettings.Name = "tsmenuAccountSettings";
            this.tsmenuAccountSettings.Size = new System.Drawing.Size(134, 24);
            this.tsmenuAccountSettings.Text = "&Account Settings";
            this.tsmenuAccountSettings.ToolTipText = "The dialog window where you can change your account settings.";
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
            this.tsmenuWindow.Text = "Window";
            this.tsmenuWindow.ToolTipText = "The list of the windows you can and cannot access. It adapts to your role permiss" +
    "ions";
            // 
            // tsmenuUsers
            // 
            this.tsmenuUsers.Name = "tsmenuUsers";
            this.tsmenuUsers.Size = new System.Drawing.Size(224, 26);
            this.tsmenuUsers.Text = GLOBAL_RESOURCES.USERS_TITLE;
            this.tsmenuUsers.ToolTipText = "The window for searching and/or editing users. It adapts to your permissions role" +
    ".";
            this.tsmenuUsers.Click += new System.EventHandler(this.tsmenuUsers_Click);
            // 
            // tsmenuProductBrands
            // 
            this.tsmenuProductBrands.Name = "tsmenuProductBrands";
            this.tsmenuProductBrands.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProductBrands.Text = GLOBAL_RESOURCES.PRODUCT_BRANDS_TITLE;
            this.tsmenuProductBrands.ToolTipText = "The window for searching and/or editing product brands. It adapts to your permiss" +
    "ions role.";
            this.tsmenuProductBrands.Click += new System.EventHandler(this.tsmenuProductBrands_Click);
            // 
            // tsmenuProductVendors
            // 
            this.tsmenuProductVendors.Name = "tsmenuProductVendors";
            this.tsmenuProductVendors.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProductVendors.Text = GLOBAL_RESOURCES.VENDORS_TITLE;
            this.tsmenuProductVendors.ToolTipText = "The window for searching and/or editing product vendors. It adapts to your permis" +
    "sions role.";
            this.tsmenuProductVendors.Click += new System.EventHandler(this.tsmenuProductVendors_Click);
            // 
            // tsmenuPaymentMethods
            // 
            this.tsmenuPaymentMethods.Name = "tsmenuPaymentMethods";
            this.tsmenuPaymentMethods.Size = new System.Drawing.Size(224, 26);
            this.tsmenuPaymentMethods.Text = GLOBAL_RESOURCES.PAYMENT_METHODS_TITLE;
            this.tsmenuPaymentMethods.ToolTipText = "The window for searching and/or editing payment methods. It adapts to your permis" +
    "sions role.";
            this.tsmenuPaymentMethods.Click += new System.EventHandler(this.tsmenuPaymentMethods_Click);
            // 
            // tsmenuDeliveryServices
            // 
            this.tsmenuDeliveryServices.Name = "tsmenuDeliveryServices";
            this.tsmenuDeliveryServices.Size = new System.Drawing.Size(224, 26);
            this.tsmenuDeliveryServices.Text = GLOBAL_RESOURCES.DELIVERY_SERVICES_TITLE;
            this.tsmenuDeliveryServices.ToolTipText = "The window for searching and/or editing delivery services. It adapts to your perm" +
    "issions role.";
            this.tsmenuDeliveryServices.Click += new System.EventHandler(this.tsmenuDeliveryServices_Click);
            // 
            // tsmenuProducts
            // 
            this.tsmenuProducts.Name = "tsmenuProducts";
            this.tsmenuProducts.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProducts.Text = GLOBAL_RESOURCES.PRODUCTS_TITLE;
            this.tsmenuProducts.ToolTipText = "The window for searching and/or editing products. It adapts to your permissions r" +
    "ole.";
            this.tsmenuProducts.Click += new System.EventHandler(this.tsmenuProducts_Click);
            // 
            // tsmenuProductOrders
            // 
            this.tsmenuProductOrders.Name = "tsmenuProductOrders";
            this.tsmenuProductOrders.Size = new System.Drawing.Size(224, 26);
            this.tsmenuProductOrders.Text = GLOBAL_RESOURCES.PRODUCT_ORDERS_TITLE;
            this.tsmenuProductOrders.ToolTipText = "The window for searching and/or editing product orders. It adapts to your permiss" +
    "ions role.";
            this.tsmenuProductOrders.Click += new System.EventHandler(this.tsmenuProductOrders_Click);
            // 
            // tsmenuOrderDeliveries
            // 
            this.tsmenuOrderDeliveries.Name = "tsmenuOrderDeliveries";
            this.tsmenuOrderDeliveries.Size = new System.Drawing.Size(224, 26);
            this.tsmenuOrderDeliveries.Text = GLOBAL_RESOURCES.ORDER_DELIVERIES_TITLE;
            this.tsmenuOrderDeliveries.ToolTipText = "The window for searching and/or editing order deliveries. It adapts to your permi" +
    "ssions role.";
            this.tsmenuOrderDeliveries.Click += new System.EventHandler(this.tsmenuOrderDeliveries_Click);
            // 
            // tsmenuLogs
            // 
            this.tsmenuLogs.Name = "tsmenuLogs";
            this.tsmenuLogs.Size = new System.Drawing.Size(224, 26);
            this.tsmenuLogs.Text = "Logs";
            this.tsmenuLogs.ToolTipText = "The window for seeing the database logs. It adapts to your permissions role and r" +
    "efreshes every time you execute any operation.";
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
            this.tsmenuBulkOperations.ToolTipText = "The bulk operations windows whether you can access them or not. They adapt to you" +
    "r permissions role.";
            // 
            // tsmenuBulkUserOperations
            // 
            this.tsmenuBulkUserOperations.Name = "tsmenuBulkUserOperations";
            this.tsmenuBulkUserOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkUserOperations.Text = "Users";
            this.tsmenuBulkUserOperations.ToolTipText = "The user bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkUserOperations.Click += new System.EventHandler(this.tsmenuBulkUserOperations_Click);
            // 
            // tsmenuBulkProductBrandOperations
            // 
            this.tsmenuBulkProductBrandOperations.Name = "tsmenuBulkProductBrandOperations";
            this.tsmenuBulkProductBrandOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductBrandOperations.Text = GLOBAL_RESOURCES.PRODUCT_BRANDS_TITLE;
            this.tsmenuBulkProductBrandOperations.ToolTipText = "The product brand bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkProductBrandOperations.Click += new System.EventHandler(this.tsmenuBulkProductBrandOperations_Click);
            // 
            // tsmenuBulkProductVendorOperations
            // 
            this.tsmenuBulkProductVendorOperations.Name = "tsmenuBulkProductVendorOperations";
            this.tsmenuBulkProductVendorOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductVendorOperations.Text = GLOBAL_RESOURCES.VENDORS_TITLE;
            this.tsmenuBulkProductVendorOperations.ToolTipText = "The product vendor bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkProductVendorOperations.Click += new System.EventHandler(this.tsmenuBulkProductVendorOperations_Click);
            // 
            // tsmenuBulkPaymentMethodOperations
            // 
            this.tsmenuBulkPaymentMethodOperations.Name = "tsmenuBulkPaymentMethodOperations";
            this.tsmenuBulkPaymentMethodOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkPaymentMethodOperations.Text = GLOBAL_RESOURCES.PAYMENT_METHODS_TITLE;
            this.tsmenuBulkPaymentMethodOperations.ToolTipText = "The payment method bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkPaymentMethodOperations.Click += new System.EventHandler(this.tsmenuBulkPaymentMethodOperations_Click);
            // 
            // tsmenuBulkDeliveryServiceOperations
            // 
            this.tsmenuBulkDeliveryServiceOperations.Name = "tsmenuBulkDeliveryServiceOperations";
            this.tsmenuBulkDeliveryServiceOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkDeliveryServiceOperations.Text = GLOBAL_RESOURCES.DELIVERY_SERVICES_TITLE;
            this.tsmenuBulkDeliveryServiceOperations.ToolTipText = "The delivery service bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkDeliveryServiceOperations.Click += new System.EventHandler(this.tsmenuBulkDeliveryServiceOperations_Click);
            // 
            // tsmenuBulkProductOperations
            // 
            this.tsmenuBulkProductOperations.Name = "tsmenuBulkProductOperations";
            this.tsmenuBulkProductOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductOperations.Text = GLOBAL_RESOURCES.PRODUCTS_TITLE;
            this.tsmenuBulkProductOperations.ToolTipText = "The product bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkProductOperations.Click += new System.EventHandler(this.tsmenuBulkProductOperations_Click);
            // 
            // tsmenuBulkProductImageOperations
            // 
            this.tsmenuBulkProductImageOperations.Name = "tsmenuBulkProductImageOperations";
            this.tsmenuBulkProductImageOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductImageOperations.Text = "Product Images";
            this.tsmenuBulkProductImageOperations.ToolTipText = "The product image bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkProductImageOperations.Click += new System.EventHandler(this.tsmenuBulkProductImageOperations_Click);
            // 
            // tsmenuBulkProductOrderOperations
            // 
            this.tsmenuBulkProductOrderOperations.Name = "tsmenuBulkProductOrderOperations";
            this.tsmenuBulkProductOrderOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkProductOrderOperations.Text = GLOBAL_RESOURCES.PRODUCT_ORDERS_TITLE;
            this.tsmenuBulkProductOrderOperations.ToolTipText = "The product order bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkProductOrderOperations.Click += new System.EventHandler(this.tsmenuBulkProductOrderOperations_Click);
            // 
            // tsmenuBulkOrderDeliveryOperations
            // 
            this.tsmenuBulkOrderDeliveryOperations.Name = "tsmenuBulkOrderDeliveryOperations";
            this.tsmenuBulkOrderDeliveryOperations.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBulkOrderDeliveryOperations.Text = GLOBAL_RESOURCES.ORDER_DELIVERIES_TITLE;
            this.tsmenuBulkOrderDeliveryOperations.ToolTipText = "The order delivery bulk operations window. It adapts to your permissions role.";
            this.tsmenuBulkOrderDeliveryOperations.Click += new System.EventHandler(this.tsmenuBulkOrderDeliveryOperations_Click);
            // 
            // tsmenuDebugTools
            // 
            this.tsmenuDebugTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuTestConnection,
            this.tsmenuBitmapToBinary});
            this.tsmenuDebugTools.Name = "tsmenuDebugTools";
            this.tsmenuDebugTools.Size = new System.Drawing.Size(107, 24);
            this.tsmenuDebugTools.Text = "&Debug Tools";
            this.tsmenuDebugTools.ToolTipText = "The debug tools for the application";
            // 
            // tsmenuTestConnection
            // 
            this.tsmenuTestConnection.Name = "tsmenuTestConnection";
            this.tsmenuTestConnection.Size = new System.Drawing.Size(224, 26);
            this.tsmenuTestConnection.Text = "&Test Connection";
            this.tsmenuTestConnection.ToolTipText = "The test connection. It tests if the connection is open and shows a message if it" +
    " is otherwise it silently opens it and if it fails shows you the critical error";
            this.tsmenuTestConnection.Click += new System.EventHandler(this.tsmenuTestConnection_Click);
            // 
            // tsmenuBitmapToBinary
            // 
            this.tsmenuBitmapToBinary.Name = "tsmenuBitmapToBinary";
            this.tsmenuBitmapToBinary.Size = new System.Drawing.Size(224, 26);
            this.tsmenuBitmapToBinary.Text = "&Bitmap To Binary";
            this.tsmenuBitmapToBinary.ToolTipText = "The bitmap to binary window. It is to test the capabilities of converting a bitma" +
    "p image to an array of bytes and/or base 64 string and vice versa.";
            this.tsmenuBitmapToBinary.Click += new System.EventHandler(this.tsmenuBitmapToBinary_Click);
            // 
            // tsmenuHelp
            // 
            this.tsmenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuAbout});
            this.tsmenuHelp.Name = "tsmenuHelp";
            this.tsmenuHelp.Size = new System.Drawing.Size(55, 24);
            this.tsmenuHelp.Text = GLOBAL_RESOURCES.HELP_TITLE;
            this.tsmenuHelp.ToolTipText = "The help menu for the application";
            // 
            // tsmenuAbout
            // 
            this.tsmenuAbout.Name = "tsmenuAbout";
            this.tsmenuAbout.Size = new System.Drawing.Size(224, 26);
            this.tsmenuAbout.Text = "About";
            this.tsmenuAbout.ToolTipText = "The dialog window that shows you what this application is all about.";
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
            this.Text = "XTremePharmacyManager";
            this.ttMain.SetToolTip(this, resources.GetString("$this.ToolTip"));
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

