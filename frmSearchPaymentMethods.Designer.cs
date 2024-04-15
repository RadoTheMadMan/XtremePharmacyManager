namespace XtremePharmacyManager
{
    partial class frmSearchPaymentMethods
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMethodName = new System.Windows.Forms.TextBox();
            this.lblMethodName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dgvPaymentMethods = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MethodNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDeliveriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.Controls.Add(this.lblSearchMode);
            this.pnlData.Controls.Add(this.cbSearchMode);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnAddOrEdit);
            this.pnlData.Controls.Add(this.btnSearch);
            this.pnlData.Controls.Add(this.txtMethodName);
            this.pnlData.Controls.Add(this.lblMethodName);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(415, 290);
            this.pnlData.TabIndex = 0;
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
            this.lblSearchMode.Text = "Search Mode:";
            // 
            // cbSearchMode
            // 
            this.cbSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSearchMode.FormattingEnabled = true;
            this.cbSearchMode.Items.AddRange(new object[] {
            "None",
            "Single Criteria",
            "Multiple Criterias",
            "All Criterias"});
            this.cbSearchMode.Location = new System.Drawing.Point(131, 184);
            this.cbSearchMode.Name = "cbSearchMode";
            this.cbSearchMode.Size = new System.Drawing.Size(225, 24);
            this.cbSearchMode.TabIndex = 35;
            this.cbSearchMode.Text = "Multiple Criterias";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(297, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 47);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddOrEdit
            // 
            this.btnAddOrEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrEdit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrEdit.Location = new System.Drawing.Point(201, 225);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.Size = new System.Drawing.Size(90, 47);
            this.btnAddOrEdit.TabIndex = 33;
            this.btnAddOrEdit.Text = "ADD/EDIT";
            this.btnAddOrEdit.UseVisualStyleBackColor = true;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(104, 225);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 47);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMethodName
            // 
            this.txtMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMethodName.Location = new System.Drawing.Point(131, 42);
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.Size = new System.Drawing.Size(225, 22);
            this.txtMethodName.TabIndex = 4;
            // 
            // lblMethodName
            // 
            this.lblMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMethodName.AutoSize = true;
            this.lblMethodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethodName.Location = new System.Drawing.Point(19, 45);
            this.lblMethodName.Name = "lblMethodName";
            this.lblMethodName.Size = new System.Drawing.Size(107, 16);
            this.lblMethodName.TabIndex = 3;
            this.lblMethodName.Text = "Method Name:";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(131, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(225, 22);
            this.txtID.TabIndex = 2;
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
            this.lblID.Text = "ID:";
            // 
            // dgvPaymentMethods
            // 
            this.dgvPaymentMethods.AllowUserToAddRows = false;
            this.dgvPaymentMethods.AllowUserToDeleteRows = false;
            this.dgvPaymentMethods.AutoGenerateColumns = false;
            this.dgvPaymentMethods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentMethods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPaymentMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentMethods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.MethodNameColumn,
            this.iDDataGridViewTextBoxColumn,
            this.methodNameDataGridViewTextBoxColumn,
            this.orderDeliveriesDataGridViewTextBoxColumn});
            this.dgvPaymentMethods.DataSource = this.paymentMethodBindingSource;
            this.dgvPaymentMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaymentMethods.Location = new System.Drawing.Point(0, 290);
            this.dgvPaymentMethods.MultiSelect = false;
            this.dgvPaymentMethods.Name = "dgvPaymentMethods";
            this.dgvPaymentMethods.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentMethods.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaymentMethods.RowHeadersWidth = 51;
            this.dgvPaymentMethods.RowTemplate.Height = 24;
            this.dgvPaymentMethods.Size = new System.Drawing.Size(415, 113);
            this.dgvPaymentMethods.TabIndex = 1;
            this.dgvPaymentMethods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymentMethods_CellClick);
            // 
            // IDColumn
            // 
            this.IDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            // 
            // MethodNameColumn
            // 
            this.MethodNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MethodNameColumn.DataPropertyName = "MethodName";
            this.MethodNameColumn.HeaderText = "Method Name";
            this.MethodNameColumn.MinimumWidth = 6;
            this.MethodNameColumn.Name = "MethodNameColumn";
            this.MethodNameColumn.ReadOnly = true;
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // methodNameDataGridViewTextBoxColumn
            // 
            this.methodNameDataGridViewTextBoxColumn.DataPropertyName = "MethodName";
            this.methodNameDataGridViewTextBoxColumn.HeaderText = "MethodName";
            this.methodNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.methodNameDataGridViewTextBoxColumn.Name = "methodNameDataGridViewTextBoxColumn";
            this.methodNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderDeliveriesDataGridViewTextBoxColumn
            // 
            this.orderDeliveriesDataGridViewTextBoxColumn.DataPropertyName = "OrderDeliveries";
            this.orderDeliveriesDataGridViewTextBoxColumn.HeaderText = "OrderDeliveries";
            this.orderDeliveriesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderDeliveriesDataGridViewTextBoxColumn.Name = "orderDeliveriesDataGridViewTextBoxColumn";
            this.orderDeliveriesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmSearchPaymentMethods
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(415, 403);
            this.Controls.Add(this.dgvPaymentMethods);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchPaymentMethods";
            this.Text = "Payment Methods";
            this.Load += new System.EventHandler(this.frmSearchPaymentMethods_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMethodName;
        private System.Windows.Forms.Label lblMethodName;
        private System.Windows.Forms.DataGridView dgvPaymentMethods;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MethodNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDeliveriesDataGridViewTextBoxColumn;
    }
}