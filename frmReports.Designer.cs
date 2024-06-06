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
            this.ttReports.SetToolTip(this.rwReports, GLOBAL_RESOURCES.RW_REPORTS_TOOLTIP_TITLE);
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
            this.Text = GLOBAL_RESOURCES.REPORTS_TITLE;
            this.ttReports.SetToolTip(this, GLOBAL_RESOURCES.REPORTS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmReportcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rwReports;
        private System.Windows.Forms.ToolTip ttReports;
    }
}