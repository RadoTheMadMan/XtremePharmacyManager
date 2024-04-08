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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuDebugTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuTestConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuBitmapToBinary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuFile,
            this.tsmenuAccountSettings,
            this.tsmenuWindow,
            this.tsmenuDebugTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmenuFile
            // 
            this.tsmenuFile.Name = "tsmenuFile";
            this.tsmenuFile.Size = new System.Drawing.Size(46, 24);
            this.tsmenuFile.Text = "&FIle";
            // 
            // tsmenuAccountSettings
            // 
            this.tsmenuAccountSettings.Name = "tsmenuAccountSettings";
            this.tsmenuAccountSettings.Size = new System.Drawing.Size(134, 24);
            this.tsmenuAccountSettings.Text = "&Account Settings";
            // 
            // tsmenuDebugTools
            // 
            this.tsmenuDebugTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuTestConnection,
            this.tsmenuBitmapToBinary});
            this.tsmenuDebugTools.Name = "tsmenuDebugTools";
            this.tsmenuDebugTools.Size = new System.Drawing.Size(107, 24);
            this.tsmenuDebugTools.Text = "&Debug Tools";
            // 
            // tsmenuTestConnection
            // 
            this.tsmenuTestConnection.Name = "tsmenuTestConnection";
            this.tsmenuTestConnection.Size = new System.Drawing.Size(205, 26);
            this.tsmenuTestConnection.Text = "&Test Connection";
            // 
            // tsmenuBitmapToBinary
            // 
            this.tsmenuBitmapToBinary.Name = "tsmenuBitmapToBinary";
            this.tsmenuBitmapToBinary.Size = new System.Drawing.Size(205, 26);
            this.tsmenuBitmapToBinary.Text = "&Bitmap To Binary";
            // 
            // tsmenuWindow
            // 
            this.tsmenuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuUsers});
            this.tsmenuWindow.Name = "tsmenuWindow";
            this.tsmenuWindow.Size = new System.Drawing.Size(78, 24);
            this.tsmenuWindow.Text = "Window";
            // 
            // tsmenuUsers
            // 
            this.tsmenuUsers.Name = "tsmenuUsers";
            this.tsmenuUsers.Size = new System.Drawing.Size(224, 26);
            this.tsmenuUsers.Text = "Users";
            this.tsmenuUsers.Click += new System.EventHandler(this.tsmenuUsers_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XTremePharmacyManager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmenuFile;
        private System.Windows.Forms.ToolStripMenuItem tsmenuAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmenuDebugTools;
        private System.Windows.Forms.ToolStripMenuItem tsmenuTestConnection;
        private System.Windows.Forms.ToolStripMenuItem tsmenuBitmapToBinary;
        private System.Windows.Forms.ToolStripMenuItem tsmenuWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmenuUsers;
    }
}

