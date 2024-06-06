namespace XtremePharmacyManager
{
    partial class frmReports
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
            this.rwReports = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ttReports = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // rwReports
            // 
            this.rwReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rwReports.Location = new System.Drawing.Point(0, 0);
            this.rwReports.Name = "rwReports";
            this.rwReports.ServerReport.BearerToken = null;
            this.rwReports.Size = new System.Drawing.Size(800, 450);
            this.rwReports.TabIndex = 0;
            this.ttReports.SetToolTip(this.rwReports, "The report viewer which shows every report you have generated using the applicati" +
        "ons and gives you various options to save it, export it and/or print it");
            this.rwReports.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // ttReports
            // 
            this.ttReports.IsBalloon = true;
            this.ttReports.ShowAlways = true;
            this.ttReports.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttReports.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rwReports);
            this.Name = "frmReports";
            this.Text = "Reports";
            this.ttReports.SetToolTip(this, "The reports dialog window. When you generate any report it will be shown here alo" +
        "ng with many options for saving, exporting and/or printing it");
            this.Load += new System.EventHandler(this.frmReportcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rwReports;
        private System.Windows.Forms.ToolTip ttReports;
    }
}