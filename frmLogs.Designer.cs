﻿namespace XtremePharmacyManager.Properties.DataSources
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
                if (logger != null)
                {
                    logger.LogsRefreshed -= OnLogsRefreshed;
                    logger = null;
                    current_user = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogs));
            this.lstLogs = new System.Windows.Forms.ListView();
            this.LogIDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogMessageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdditionalInformationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dtLogDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblLogDateTo = new System.Windows.Forms.Label();
            this.dtLogDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblLogDateFrom = new System.Windows.Forms.Label();
            this.txtLogTitle = new System.Windows.Forms.TextBox();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.txtLogMessage = new System.Windows.Forms.TextBox();
            this.lblLogMessage = new System.Windows.Forms.Label();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.txtAdditionalInformation = new System.Windows.Forms.TextBox();
            this.lblAdditionalInformation = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ttLogs = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lstLogs
            // 
            this.lstLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LogIDColumn,
            this.LogDateColumn,
            this.LogTitleColumn,
            this.LogMessageColumn,
            this.AdditionalInformationColumn});
            this.lstLogs.FullRowSelect = true;
            this.lstLogs.HideSelection = false;
            this.lstLogs.Location = new System.Drawing.Point(13, 224);
            this.lstLogs.MultiSelect = false;
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(775, 214);
            this.lstLogs.TabIndex = 0;
            this.ttLogs.SetToolTip(this.lstLogs, GLOBAL_RESOURCES.LST_LOGS_TOOLTIP_TITLE);
            this.lstLogs.UseCompatibleStateImageBehavior = false;
            this.lstLogs.View = System.Windows.Forms.View.Details;
            this.lstLogs.SelectedIndexChanged += new System.EventHandler(this.lstLogs_SelectedIndexChanged);
            // 
            // LogIDColumn
            // 
            this.LogIDColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogID;
            // 
            // LogDateColumn
            // 
            this.LogDateColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogDate;
            this.LogDateColumn.Width = 99;
            // 
            // LogTitleColumn
            // 
            this.LogTitleColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogTitle;
            this.LogTitleColumn.Width = 97;
            // 
            // LogMessageColumn
            // 
            this.LogMessageColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.LogMessage;
            this.LogMessageColumn.Width = 120;
            // 
            // AdditionalInformationColumn
            // 
            this.AdditionalInformationColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.AdditionalLogInformation;
            this.AdditionalInformationColumn.Width = 532;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(149, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(237, 22);
            this.txtID.TabIndex = 4;
            this.ttLogs.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_SEARCH_TOOLTIP_TITLE);
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(12, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 16);
            this.lblID.TabIndex = 3;
            this.lblID.Text = GLOBAL_RESOURCES.LBL_ID_TITLE;
            // 
            // dtLogDateTo
            // 
            this.dtLogDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtLogDateTo.Location = new System.Drawing.Point(146, 78);
            this.dtLogDateTo.Name = "dtLogDateTo";
            this.dtLogDateTo.Size = new System.Drawing.Size(240, 22);
            this.dtLogDateTo.TabIndex = 16;
            this.ttLogs.SetToolTip(this.dtLogDateTo, GLOBAL_RESOURCES.LOG_DATE_TO_SEARCH_TOOLTIP_TITLE);
            // 
            // lblLogDateTo
            // 
            this.lblLogDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLogDateTo.AutoSize = true;
            this.lblLogDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogDateTo.Location = new System.Drawing.Point(11, 78);
            this.lblLogDateTo.Name = "lblLogDateTo";
            this.lblLogDateTo.Size = new System.Drawing.Size(67, 16);
            this.lblLogDateTo.TabIndex = 15;
            this.lblLogDateTo.Text = GLOBAL_RESOURCES.LBL_DATE_TO_TITLE;
            // 
            // dtLogDateFrom
            // 
            this.dtLogDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtLogDateFrom.Location = new System.Drawing.Point(149, 49);
            this.dtLogDateFrom.Name = "dtLogDateFrom";
            this.dtLogDateFrom.Size = new System.Drawing.Size(237, 22);
            this.dtLogDateFrom.TabIndex = 14;
            this.ttLogs.SetToolTip(this.dtLogDateFrom, GLOBAL_RESOURCES.LOG_DATE_FROM_SEARCH_TOOLTIP_TITLE);
            // 
            // lblLogDateFrom
            // 
            this.lblLogDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLogDateFrom.AutoSize = true;
            this.lblLogDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogDateFrom.Location = new System.Drawing.Point(10, 49);
            this.lblLogDateFrom.Name = "lblLogDateFrom";
            this.lblLogDateFrom.Size = new System.Drawing.Size(83, 16);
            this.lblLogDateFrom.TabIndex = 13;
            this.lblLogDateFrom.Text = GLOBAL_RESOURCES.LBL_DATE_FROM_TITLE;
            // 
            // txtLogTitle
            // 
            this.txtLogTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLogTitle.Location = new System.Drawing.Point(149, 109);
            this.txtLogTitle.Name = "txtLogTitle";
            this.txtLogTitle.Size = new System.Drawing.Size(237, 22);
            this.txtLogTitle.TabIndex = 18;
            this.ttLogs.SetToolTip(this.txtLogTitle, GLOBAL_RESOURCES.LOG_TITLE_SEARCH_TOOLTIP_TITLE);
            // 
            // lblLogTitle
            // 
            this.lblLogTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogTitle.Location = new System.Drawing.Point(12, 109);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(42, 16);
            this.lblLogTitle.TabIndex = 17;
            this.lblLogTitle.Text = GLOBAL_RESOURCES.LBL_TITLE_TITLE;
            // 
            // txtLogMessage
            // 
            this.txtLogMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLogMessage.Location = new System.Drawing.Point(149, 144);
            this.txtLogMessage.Name = "txtLogMessage";
            this.txtLogMessage.Size = new System.Drawing.Size(237, 22);
            this.txtLogMessage.TabIndex = 20;
            this.ttLogs.SetToolTip(this.txtLogMessage, GLOBAL_RESOURCES.LOG_MESSAGE_SEARCH_TOOLTIP_TITLE);
            // 
            // lblLogMessage
            // 
            this.lblLogMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLogMessage.AutoSize = true;
            this.lblLogMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogMessage.Location = new System.Drawing.Point(12, 144);
            this.lblLogMessage.Name = "lblLogMessage";
            this.lblLogMessage.Size = new System.Drawing.Size(75, 16);
            this.lblLogMessage.TabIndex = 19;
            this.lblLogMessage.Text = GLOBAL_RESOURCES.LBL_MESSAGE_TITLE;
            // 
            // lblSearchMode
            // 
            this.lblSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchMode.AutoSize = true;
            this.lblSearchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchMode.Location = new System.Drawing.Point(425, 137);
            this.lblSearchMode.Name = "lblSearchMode";
            this.lblSearchMode.Size = new System.Drawing.Size(103, 16);
            this.lblSearchMode.TabIndex = 36;
            this.lblSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_TITLE;
            // 
            // cbSearchMode
            // 
            this.cbSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchMode.FormattingEnabled = true;
            this.cbSearchMode.Items.AddRange(new object[] {
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_NONE,
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_SINGLE,
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_MULTIPLE,
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_ALL});
            this.cbSearchMode.Location = new System.Drawing.Point(569, 134);
            this.cbSearchMode.Name = "cbSearchMode";
            this.cbSearchMode.Size = new System.Drawing.Size(219, 24);
            this.cbSearchMode.TabIndex = 35;
            this.cbSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_MULTIPLE;
            this.ttLogs.SetToolTip(this.cbSearchMode, GLOBAL_RESOURCES.CB_SEARCH_MODE_TOOLTIP_TITLE);
            // 
            // txtAdditionalInformation
            // 
            this.txtAdditionalInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalInformation.Location = new System.Drawing.Point(569, 9);
            this.txtAdditionalInformation.Multiline = true;
            this.txtAdditionalInformation.Name = "txtAdditionalInformation";
            this.txtAdditionalInformation.Size = new System.Drawing.Size(221, 91);
            this.txtAdditionalInformation.TabIndex = 34;
            this.ttLogs.SetToolTip(this.txtAdditionalInformation, GLOBAL_RESOURCES.ADD_INFO_SEARCH_TOOLTIP_TITLE);
            // 
            // lblAdditionalInformation
            // 
            this.lblAdditionalInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdditionalInformation.AutoSize = true;
            this.lblAdditionalInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalInformation.Location = new System.Drawing.Point(392, 15);
            this.lblAdditionalInformation.Name = "lblAdditionalInformation";
            this.lblAdditionalInformation.Size = new System.Drawing.Size(161, 16);
            this.lblAdditionalInformation.TabIndex = 33;
            this.lblAdditionalInformation.Text = GLOBAL_RESOURCES.LBL_ADD_INFO_TITLE;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(15, 171);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 47);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = GLOBAL_RESOURCES.BTN_SEARCH_TITLE;
            this.ttLogs.SetToolTip(this.btnSearch, GLOBAL_RESOURCES.BTN_SEARCH_TOOLTIP_TITLE);
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ttLogs
            // 
            this.ttLogs.IsBalloon = true;
            this.ttLogs.ShowAlways = true;
            this.ttLogs.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttLogs.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearchMode);
            this.Controls.Add(this.cbSearchMode);
            this.Controls.Add(this.txtAdditionalInformation);
            this.Controls.Add(this.lblAdditionalInformation);
            this.Controls.Add(this.txtLogMessage);
            this.Controls.Add(this.lblLogMessage);
            this.Controls.Add(this.txtLogTitle);
            this.Controls.Add(this.lblLogTitle);
            this.Controls.Add(this.dtLogDateTo);
            this.Controls.Add(this.lblLogDateTo);
            this.Controls.Add(this.dtLogDateFrom);
            this.Controls.Add(this.lblLogDateFrom);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lstLogs);
            this.MaximizeBox = false;
            this.Name = "frmLogs";
            this.Text = GLOBAL_RESOURCES.LOGS_TITLE;
            this.ttLogs.SetToolTip(this, GLOBAL_RESOURCES.LOGS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmLogs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstLogs;
        private System.Windows.Forms.ColumnHeader LogIDColumn;
        private System.Windows.Forms.ColumnHeader LogDateColumn;
        private System.Windows.Forms.ColumnHeader LogTitleColumn;
        private System.Windows.Forms.ColumnHeader LogMessageColumn;
        private System.Windows.Forms.ColumnHeader AdditionalInformationColumn;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtLogDateTo;
        private System.Windows.Forms.Label lblLogDateTo;
        private System.Windows.Forms.DateTimePicker dtLogDateFrom;
        private System.Windows.Forms.Label lblLogDateFrom;
        private System.Windows.Forms.TextBox txtLogTitle;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.TextBox txtLogMessage;
        private System.Windows.Forms.Label lblLogMessage;
        private System.Windows.Forms.Label lblSearchMode;
        private System.Windows.Forms.ComboBox cbSearchMode;
        private System.Windows.Forms.TextBox txtAdditionalInformation;
        private System.Windows.Forms.Label lblAdditionalInformation;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolTip ttLogs;
    }
}