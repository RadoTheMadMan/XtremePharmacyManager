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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuDebugTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuTestConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBitmapToBinary = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsmenuDebugTools});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1006, 30);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmenuFile
            // 
            this.tsmenuFile.Name = "tsmenuFile";
            this.tsmenuFile.Size = new System.Drawing.Size(46, 26);
            this.tsmenuFile.Text = "&FIle";
            // 
            // tsmenuAccountSettings
            // 
            this.tsmenuAccountSettings.Name = "tsmenuAccountSettings";
            this.tsmenuAccountSettings.Size = new System.Drawing.Size(134, 26);
            this.tsmenuAccountSettings.Text = "&Account Settings";
            // 
            // tsmenuWindow
            // 
            this.tsmenuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuUsers});
            this.tsmenuWindow.Name = "tsmenuWindow";
            this.tsmenuWindow.Size = new System.Drawing.Size(78, 26);
            this.tsmenuWindow.Text = "Window";
            // 
            // tsmenuUsers
            // 
            this.tsmenuUsers.Name = "tsmenuUsers";
            this.tsmenuUsers.Size = new System.Drawing.Size(127, 26);
            this.tsmenuUsers.Text = "Users";
            this.tsmenuUsers.Click += new System.EventHandler(this.tsmenuUsers_Click);
            // 
            // tsmenuDebugTools
            // 
            this.tsmenuDebugTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuTestConnection,
            this.tsmenuBitmapToBinary});
            this.tsmenuDebugTools.Name = "tsmenuDebugTools";
            this.tsmenuDebugTools.Size = new System.Drawing.Size(107, 26);
            this.tsmenuDebugTools.Text = "&Debug Tools";
            // 
            // tsmenuTestConnection
            // 
            this.tsmenuTestConnection.Name = "tsmenuTestConnection";
            this.tsmenuTestConnection.Size = new System.Drawing.Size(205, 26);
            this.tsmenuTestConnection.Text = "&Test Connection";
            this.tsmenuTestConnection.Click += new System.EventHandler(this.tsmenuTestConnection_Click);
            // 
            // tsmenuBitmapToBinary
            // 
            this.tsmenuBitmapToBinary.Name = "tsmenuBitmapToBinary";
            this.tsmenuBitmapToBinary.Size = new System.Drawing.Size(205, 26);
            this.tsmenuBitmapToBinary.Text = "&Bitmap To Binary";
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XTremePharmacyManager";
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
    }
}

