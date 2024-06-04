namespace XtremePharmacyManager
{
    partial class frmSearchProductVendors
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
                    manager.BulkOperationsExecuted -= ProductVendors_OnBulkOperationExecuted;
                    manager = null;
                }
                if (logger != null)
                {
                    logger = null;
                }
                if (current_user != null)
                {
                    current_user = null;
                }
                if (product_vendors != null)
                {
                    product_vendors.Clear();
                    product_vendors = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchProductVendors));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dgvProductVendors = new System.Windows.Forms.DataGridView();
            this.productVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttSearchProductVendors = new System.Windows.Forms.ToolTip(this.components);
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productVendorBindingSource)).BeginInit();
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
            this.pnlData.Controls.Add(this.txtVendorName);
            this.pnlData.Controls.Add(this.lblVendorName);
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
            this.ttSearchProductVendors.SetToolTip(this.btnGenerateReport, "When you click the button you generate a report on  an entry based on the permiss" +
        "ions you have and whether the report definition based on localisation is present" +
        ".");
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
            this.ttSearchProductVendors.SetToolTip(this.cbSearchMode, GLOBAL_RESOURCES.CB_SEARCH_MODE_TOOLTIP_TITLE);
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
            this.ttSearchProductVendors.SetToolTip(this.btnDelete, GLOBAL_RESOURCES.BTN_DELETE_TOOLTIP_TITLE);
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
            this.ttSearchProductVendors.SetToolTip(this.btnAddOrEdit, GLOBAL_RESOURCES.BTN_ADD_EDIT_TOOLTIP_TITLE +
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
            this.ttSearchProductVendors.SetToolTip(this.btnSearch, GLOBAL_RESOURCES.BTN_SEARCH_TOOLTIP_TITLE);
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtVendorName
            // 
            this.txtVendorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVendorName.Location = new System.Drawing.Point(131, 42);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(225, 22);
            this.txtVendorName.TabIndex = 4;
            this.ttSearchProductVendors.SetToolTip(this.txtVendorName, "The vendor name with which you want to search product vendors");
            // 
            // lblVendorName
            // 
            this.lblVendorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorName.Location = new System.Drawing.Point(19, 45);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(106, 16);
            this.lblVendorName.TabIndex = 3;
            this.lblVendorName.Text = "Vendor Name:";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(131, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(225, 22);
            this.txtID.TabIndex = 2;
            this.ttSearchProductVendors.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_SEARCH_TOOLTIP_TITLE);
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
            // dgvProductVendors
            // 
            this.dgvProductVendors.AllowUserToAddRows = false;
            this.dgvProductVendors.AllowUserToDeleteRows = false;
            this.dgvProductVendors.AutoGenerateColumns = false;
            this.dgvProductVendors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductVendors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductVendors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductVendors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.VendorNameColumn});
            this.dgvProductVendors.DataSource = this.productVendorBindingSource;
            this.dgvProductVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductVendors.Location = new System.Drawing.Point(0, 290);
            this.dgvProductVendors.MultiSelect = false;
            this.dgvProductVendors.Name = "dgvProductVendors";
            this.dgvProductVendors.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductVendors.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProductVendors.RowHeadersWidth = 51;
            this.dgvProductVendors.RowTemplate.Height = 24;
            this.dgvProductVendors.Size = new System.Drawing.Size(483, 113);
            this.dgvProductVendors.TabIndex = 1;
            this.ttSearchProductVendors.SetToolTip(this.dgvProductVendors, "The list of product vendors in the database. Select any to add/edit/delete/genera" +
        "te report based on your permissions.");
            this.dgvProductVendors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductVendors_CellClick);
            // 
            // productVendorBindingSource
            // 
            this.productVendorBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductVendor);
            // 
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // ttSearchProductVendors
            // 
            this.ttSearchProductVendors.IsBalloon = true;
            this.ttSearchProductVendors.ShowAlways = true;
            this.ttSearchProductVendors.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSearchProductVendors.ToolTipTitle = GLOBAL_RESOURCES.HELP_TOOLTIP_TITLE;
            // 
            // IDColumn
            // 
            this.IDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDColumn.DataPropertyName = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.IDColumn.HeaderText = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            // 
            // VendorNameColumn
            // 
            this.VendorNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorNameColumn.DataPropertyName = "VendorName";
            this.VendorNameColumn.HeaderText = "Vendor Name";
            this.VendorNameColumn.MinimumWidth = 6;
            this.VendorNameColumn.Name = "VendorNameColumn";
            this.VendorNameColumn.ReadOnly = true;
            // 
            // frmSearchProductVendors
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(483, 403);
            this.Controls.Add(this.dgvProductVendors);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchProductVendors";
            this.Text = "Product Vendors";
            this.ttSearchProductVendors.SetToolTip(this, "The product vendors window where you can search, add, edit, delete and generate r" +
        "eports on the product vendors. Whether you can do it or not depends on your perm" +
        "issions");
            this.Load += new System.EventHandler(this.frmSearchProductVendors_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productVendorBindingSource)).EndInit();
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
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.DataGridView dgvProductVendors;
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
        private System.Windows.Forms.BindingSource productVendorBindingSource;
        private System.Windows.Forms.ToolTip ttSearchProductVendors;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorNameColumn;
    }
}