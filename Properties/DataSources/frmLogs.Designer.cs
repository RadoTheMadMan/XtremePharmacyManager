namespace XtremePharmacyManager.Properties.DataSources
{
    partial class frmLogs
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
            this.lstLogs = new System.Windows.Forms.ListView();
            this.LogIDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogMessageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdditionalInformationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstLogs
            // 
            this.lstLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LogIDColumn,
            this.LogDateColumn,
            this.LogTitleColumn,
            this.LogMessageColumn,
            this.AdditionalInformationColumn});
            this.lstLogs.HideSelection = false;
            this.lstLogs.Location = new System.Drawing.Point(13, 224);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(775, 214);
            this.lstLogs.TabIndex = 0;
            this.lstLogs.UseCompatibleStateImageBehavior = false;
            this.lstLogs.View = System.Windows.Forms.View.Details;
            // 
            // LogIDColumn
            // 
            this.LogIDColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogID;
            // 
            // LogDateColumn
            // 
            this.LogDateColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogDate;
            // 
            // LogTitleColumn
            // 
            this.LogTitleColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogTitle;
            // 
            // LogMessageColumn
            // 
            this.LogMessageColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogMessage;
            // 
            // AdditionalInformationColumn
            // 
            this.AdditionalInformationColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.AdditionalLogInformation;
            this.AdditionalInformationColumn.Width = 532;
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstLogs);
            this.MaximizeBox = false;
            this.Name = "frmLogs";
            this.Text = "frmLogs";
            this.Load += new System.EventHandler(this.frmLogs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstLogs;
        private System.Windows.Forms.ColumnHeader LogIDColumn;
        private System.Windows.Forms.ColumnHeader LogDateColumn;
        private System.Windows.Forms.ColumnHeader LogTitleColumn;
        private System.Windows.Forms.ColumnHeader LogMessageColumn;
        private System.Windows.Forms.ColumnHeader AdditionalInformationColumn;
    }
}