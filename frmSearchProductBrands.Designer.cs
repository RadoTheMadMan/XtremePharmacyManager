﻿namespace XtremePharmacyManager
{
    partial class frmSearchProductBrands
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
                if (manager != null)
                {
                    manager.BulkOperationsExecuted -= ProductBrands_OnBulkOperationExecuted;
                    manager = null;
                }
                if (product_brands != null)
                {
                    product_brands.Clear();
                    product_brands = null;
                }
                if (logger != null)
                {
                    logger = null;
                }
                if (current_user != null)
                {
                    current_user = null;
                }
                if (ent != null)
                {
                    ent = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchProductBrands));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dgvProductBrands = new System.Windows.Forms.DataGridView();
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttSearchProductBrands = new System.Windows.Forms.ToolTip(this.components);
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductBrands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.Controls.Add(this.btnGenerateReport);
            this.pnlData.Controls.Add(this.lblSearchMode);
            this.pnlData.Controls.Add(this.cbSearchMode);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnAddOrEdit);
            this.pnlData.Controls.Add(this.btnSearch);
            this.pnlData.Controls.Add(this.txtBrandName);
            this.pnlData.Controls.Add(this.lblBrandName);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(483, 290);
            this.pnlData.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(296, 228);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(175, 47);
            this.btnGenerateReport.TabIndex = 45;
            this.btnGenerateReport.Text = GLOBAL_RESOURCES.BTN_GENERATE_REPORT_TITLE;
            this.ttSearchProductBrands.SetToolTip(this.btnGenerateReport, GLOBAL_RESOURCES.BTN_GENERATE_REPORT_TOOLTIP_TITLE);
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblSearchMode
            // 
            this.lblSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearchMode.AutoSize = true;
            this.lblSearchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchMode.Location = new System.Drawing.Point(12, 187);
            this.lblSearchMode.Name = "lblSearchMode";
            this.lblSearchMode.Size = new System.Drawing.Size(103, 16);
            this.lblSearchMode.TabIndex = 36;
            this.lblSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_TITLE;
            // 
            // cbSearchMode
            // 
            this.cbSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSearchMode.FormattingEnabled = true;
            this.cbSearchMode.Items.AddRange(new object[] {
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_NONE,
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_SINGLE,
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_MULTIPLE,
            GLOBAL_RESOURCES.LBL_SEARCH_MODE_ALL});
            this.cbSearchMode.Location = new System.Drawing.Point(131, 184);
            this.cbSearchMode.Name = "cbSearchMode";
            this.cbSearchMode.Size = new System.Drawing.Size(225, 24);
            this.cbSearchMode.TabIndex = 35;
            this.cbSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_MULTIPLE;
            this.ttSearchProductBrands.SetToolTip(this.cbSearchMode, GLOBAL_RESOURCES.CB_SEARCH_MODE_TOOLTIP_TITLE);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(200, 228);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 47);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = GLOBAL_RESOURCES.BTN_DELETE_TITLE;
            this.ttSearchProductBrands.SetToolTip(this.btnDelete, GLOBAL_RESOURCES.BTN_DELETE_TOOLTIP_TITLE);
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddOrEdit
            // 
            this.btnAddOrEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOrEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrEdit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrEdit.Location = new System.Drawing.Point(104, 228);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.Size = new System.Drawing.Size(90, 47);
            this.btnAddOrEdit.TabIndex = 33;
            this.btnAddOrEdit.Text = GLOBAL_RESOURCES.BTN_ADD_EDIT_TITLE;
            this.ttSearchProductBrands.SetToolTip(this.btnAddOrEdit, GLOBAL_RESOURCES.BTN_ADD_EDIT_TOOLTIP_TITLE +
        ".");
            this.btnAddOrEdit.UseVisualStyleBackColor = true;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(7, 228);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 47);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = GLOBAL_RESOURCES.BTN_SEARCH_TITLE;
            this.ttSearchProductBrands.SetToolTip(this.btnSearch, GLOBAL_RESOURCES.BTN_SEARCH_TOOLTIP_TITLE);
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBrandName
            // 
            this.txtBrandName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBrandName.Location = new System.Drawing.Point(131, 42);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(225, 22);
            this.txtBrandName.TabIndex = 4;
            this.ttSearchProductBrands.SetToolTip(this.txtBrandName, GLOBAL_RESOURCES.BRAND_NAME_SEARCH_TOOLTIP_TITLE);
            // 
            // lblBrandName
            // 
            this.lblBrandName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandName.Location = new System.Drawing.Point(19, 45);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(97, 16);
            this.lblBrandName.TabIndex = 3;
            this.lblBrandName.Text = GLOBAL_RESOURCES.LBL_BRAND_NAME_TITLE;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(131, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(225, 22);
            this.txtID.TabIndex = 2;
            this.ttSearchProductBrands.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_SEARCH_TOOLTIP_TITLE);
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(20, 18);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 16);
            this.lblID.TabIndex = 1;
            this.lblID.Text = GLOBAL_RESOURCES.LBL_ID_TITLE;
            // 
            // dgvProductBrands
            // 
            this.dgvProductBrands.AllowUserToAddRows = false;
            this.dgvProductBrands.AllowUserToDeleteRows = false;
            this.dgvProductBrands.AutoGenerateColumns = false;
            this.dgvProductBrands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductBrands.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductBrands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.BrandNameColumn});
            this.dgvProductBrands.DataSource = this.productBrandBindingSource;
            this.dgvProductBrands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductBrands.Location = new System.Drawing.Point(0, 290);
            this.dgvProductBrands.MultiSelect = false;
            this.dgvProductBrands.Name = "dgvProductBrands";
            this.dgvProductBrands.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductBrands.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductBrands.RowHeadersWidth = 51;
            this.dgvProductBrands.RowTemplate.Height = 24;
            this.dgvProductBrands.Size = new System.Drawing.Size(483, 113);
            this.dgvProductBrands.TabIndex = 1;
            this.ttSearchProductBrands.SetToolTip(this.dgvProductBrands, GLOBAL_RESOURCES.DGV_PRODUCT_BRANDS_TOOLTIP_TITLE);
            this.dgvProductBrands.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductBrands_CellClick);
            // 
            // ttSearchProductBrands
            // 
            this.ttSearchProductBrands.IsBalloon = true;
            this.ttSearchProductBrands.ShowAlways = true;
            this.ttSearchProductBrands.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSearchProductBrands.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // IDColumn
            // 
            this.IDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.HeaderText = GLOBAL_RESOURCES.BRAND_ID_COL_TITLE;
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            // 
            // BrandNameColumn
            // 
            this.BrandNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BrandNameColumn.DataPropertyName = "BrandName";
            this.BrandNameColumn.HeaderText = GLOBAL_RESOURCES.BRAND_NAME_COL_TITLE;
            this.BrandNameColumn.MinimumWidth = 6;
            this.BrandNameColumn.Name = "BrandNameColumn";
            this.BrandNameColumn.ReadOnly = true;
            // 
            // frmSearchProductBrands
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(483, 403);
            this.Controls.Add(this.dgvProductBrands);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchProductBrands";
            this.Text = GLOBAL_RESOURCES.PRODUCT_BRANDS_TITLE;
            this.ttSearchProductBrands.SetToolTip(this, GLOBAL_RESOURCES.PRODUCT_BRANDS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmSearchProductBrands_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductBrands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.DataGridView dgvProductBrands;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddOrEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource deliveryServiceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblSearchMode;
        private System.Windows.Forms.ComboBox cbSearchMode;
        private System.Windows.Forms.BindingSource paymentMethodBindingSource;
        private System.Windows.Forms.BindingSource productBrandBindingSource;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ToolTip ttSearchProductBrands;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandNameColumn;
    }
}