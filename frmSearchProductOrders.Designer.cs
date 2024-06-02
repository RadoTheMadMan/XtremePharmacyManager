using System;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    partial class frmSearchProductOrders
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
                    manager.BulkOperationsExecuted -= ProductOrders_BulkOperationExecuted;
                    manager = null;
                }
                if (product_orders != null)
                {
                    product_orders.Clear();
                    product_orders = null;
                }
                if (products != null)
                {
                    products.Clear();
                    products = null;
                }
                if (employees != null)
                {
                    employees.Clear();
                    employees = null;
                }
                if (clients != null)
                {
                    clients.Clear();
                    clients = null;
                }
                if (current_user != null)
                {
                    current_user = null;
                }
                if (logger != null)
                {
                    logger = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchProductOrders));
            this.dgvProductOrders = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imgListProductImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtPriceOverride = new System.Windows.Forms.TextBox();
            this.txtDesiredQuantity = new System.Windows.Forms.TextBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.cbSelectOrderStatus = new System.Windows.Forms.ComboBox();
            this.lblProductOrderNotice = new System.Windows.Forms.Label();
            this.dtDateModifiedTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateModifiedTo = new System.Windows.Forms.Label();
            this.dtDateModifiedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateModifiedFrom = new System.Windows.Forms.Label();
            this.cbSelectClient = new System.Windows.Forms.ComboBox();
            this.lblSelectClient = new System.Windows.Forms.Label();
            this.cbSelectProduct = new System.Windows.Forms.ComboBox();
            this.trbDesiredQuantity = new System.Windows.Forms.TrackBar();
            this.lblDesiredQuantity = new System.Windows.Forms.Label();
            this.cbSelectEmployee = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.trbPriceOverride = new System.Windows.Forms.TrackBar();
            this.lblPriceOverride = new System.Windows.Forms.Label();
            this.txtOrderReason = new System.Windows.Forms.TextBox();
            this.lblOrderReason = new System.Windows.Forms.Label();
            this.dtDateAddedTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateAddedTo = new System.Windows.Forms.Label();
            this.dtDateAddedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateAddedFrom = new System.Windows.Forms.Label();
            this.lblSelectEmployee = new System.Windows.Forms.Label();
            this.lblSelectProduct = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productImageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttSearchProductOrders = new System.Windows.Forms.ToolTip(this.components);
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DesiredQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ClientIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderDateAddedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderReasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbDesiredQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPriceOverride)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductOrders
            // 
            this.dgvProductOrders.AllowUserToAddRows = false;
            this.dgvProductOrders.AllowUserToDeleteRows = false;
            this.dgvProductOrders.AutoGenerateColumns = false;
            this.dgvProductOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductOrders.ColumnHeadersHeight = 29;
            this.dgvProductOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.ProductIDColumn,
            this.DesiredQuantityColumn,
            this.OrderPriceColumn,
            this.EmployeeIDColumn,
            this.ClientIDColumn,
            this.OrderDateAddedColumn,
            this.OrderDateModifiedColumn,
            this.OrderStatusColumn,
            this.OrderReasonColumn});
            this.dgvProductOrders.DataSource = this.productOrderBindingSource;
            this.dgvProductOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductOrders.Location = new System.Drawing.Point(0, 596);
            this.dgvProductOrders.MultiSelect = false;
            this.dgvProductOrders.Name = "dgvProductOrders";
            this.dgvProductOrders.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductOrders.RowHeadersWidth = 51;
            this.dgvProductOrders.RowTemplate.Height = 24;
            this.dgvProductOrders.Size = new System.Drawing.Size(820, 113);
            this.dgvProductOrders.TabIndex = 1;
            this.ttSearchProductOrders.SetToolTip(this.dgvProductOrders, "The list of product orders in the database. Select any to add/edit/delete/generat" +
        "e report based on your permissions.");
            this.dgvProductOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductOrders_CellClick);
            this.dgvProductOrders.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProductOrders_RowsAdded);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.Product);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // productOrderBindingSource
            // 
            this.productOrderBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductOrder);
            // 
            // imgListProductImages
            // 
            this.imgListProductImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListProductImages.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListProductImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.txtPriceOverride);
            this.pnlData.Controls.Add(this.txtDesiredQuantity);
            this.pnlData.Controls.Add(this.btnGenerateReport);
            this.pnlData.Controls.Add(this.lblOrderStatus);
            this.pnlData.Controls.Add(this.cbSelectOrderStatus);
            this.pnlData.Controls.Add(this.lblProductOrderNotice);
            this.pnlData.Controls.Add(this.dtDateModifiedTo);
            this.pnlData.Controls.Add(this.lblDateModifiedTo);
            this.pnlData.Controls.Add(this.dtDateModifiedFrom);
            this.pnlData.Controls.Add(this.lblDateModifiedFrom);
            this.pnlData.Controls.Add(this.cbSelectClient);
            this.pnlData.Controls.Add(this.lblSelectClient);
            this.pnlData.Controls.Add(this.cbSelectProduct);
            this.pnlData.Controls.Add(this.trbDesiredQuantity);
            this.pnlData.Controls.Add(this.lblDesiredQuantity);
            this.pnlData.Controls.Add(this.cbSelectEmployee);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnAddOrEdit);
            this.pnlData.Controls.Add(this.lblSearchMode);
            this.pnlData.Controls.Add(this.cbSearchMode);
            this.pnlData.Controls.Add(this.btnSearch);
            this.pnlData.Controls.Add(this.trbPriceOverride);
            this.pnlData.Controls.Add(this.lblPriceOverride);
            this.pnlData.Controls.Add(this.txtOrderReason);
            this.pnlData.Controls.Add(this.lblOrderReason);
            this.pnlData.Controls.Add(this.dtDateAddedTo);
            this.pnlData.Controls.Add(this.lblDateAddedTo);
            this.pnlData.Controls.Add(this.dtDateAddedFrom);
            this.pnlData.Controls.Add(this.lblDateAddedFrom);
            this.pnlData.Controls.Add(this.lblSelectEmployee);
            this.pnlData.Controls.Add(this.lblSelectProduct);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(820, 596);
            this.pnlData.TabIndex = 0;
            // 
            // txtPriceOverride
            // 
            this.txtPriceOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPriceOverride.Location = new System.Drawing.Point(372, 255);
            this.txtPriceOverride.Name = "txtPriceOverride";
            this.txtPriceOverride.Size = new System.Drawing.Size(42, 22);
            this.txtPriceOverride.TabIndex = 53;
            this.ttSearchProductOrders.SetToolTip(this.txtPriceOverride, "The price overrride with which you want to search product orders");
            this.txtPriceOverride.TextChanged += new System.EventHandler(this.txtPriceOverride_TextChanged);
            // 
            // txtDesiredQuantity
            // 
            this.txtDesiredQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDesiredQuantity.Location = new System.Drawing.Point(372, 199);
            this.txtDesiredQuantity.Name = "txtDesiredQuantity";
            this.txtDesiredQuantity.Size = new System.Drawing.Size(42, 22);
            this.txtDesiredQuantity.TabIndex = 52;
            this.ttSearchProductOrders.SetToolTip(this.txtDesiredQuantity, "The desired quantity with which you want to search product orders");
            this.txtDesiredQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(296, 543);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(278, 47);
            this.btnGenerateReport.TabIndex = 51;
            this.btnGenerateReport.Text = "GENERATE REPORT";
            this.ttSearchProductOrders.SetToolTip(this.btnGenerateReport, "When you click the button you generate a report on  an entry based on the permiss" +
        "ions you have and whether the report definition based on localisation is present" +
        ".");
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.Location = new System.Drawing.Point(442, 75);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(97, 16);
            this.lblOrderStatus.TabIndex = 50;
            this.lblOrderStatus.Text = "Order Status:";
            // 
            // cbSelectOrderStatus
            // 
            this.cbSelectOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSelectOrderStatus.FormattingEnabled = true;
            this.cbSelectOrderStatus.Items.AddRange(new object[] {
            "Awaiting processing",
            "Prepaid",
            "Paid on delivery",
            "Directly paid",
            "Generating invoice",
            "Generating report",
            "Processing",
            "Cancelled order",
            "Returned order",
            "Completed"});
            this.cbSelectOrderStatus.Location = new System.Drawing.Point(573, 72);
            this.cbSelectOrderStatus.Name = "cbSelectOrderStatus";
            this.cbSelectOrderStatus.Size = new System.Drawing.Size(232, 24);
            this.cbSelectOrderStatus.TabIndex = 49;
            this.cbSelectOrderStatus.Text = "Awaiting processing";
            this.ttSearchProductOrders.SetToolTip(this.cbSelectOrderStatus, "The status with which you want to search product orders");
            // 
            // lblProductOrderNotice
            // 
            this.lblProductOrderNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductOrderNotice.AutoSize = true;
            this.lblProductOrderNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.lblProductOrderNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.lblProductOrderNotice.Location = new System.Drawing.Point(420, 255);
            this.lblProductOrderNotice.Name = "lblProductOrderNotice";
            this.lblProductOrderNotice.Size = new System.Drawing.Size(397, 285);
            this.lblProductOrderNotice.TabIndex = 48;
            this.lblProductOrderNotice.Text = resources.GetString("lblProductOrderNotice.Text");
            this.ttSearchProductOrders.SetToolTip(this.lblProductOrderNotice, "If you are a dumbfuck like my creator read this so you don\'t complain that you ca" +
        "n\'t change the product order data via any operation");
            // 
            // dtDateModifiedTo
            // 
            this.dtDateModifiedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateModifiedTo.Location = new System.Drawing.Point(571, 44);
            this.dtDateModifiedTo.Name = "dtDateModifiedTo";
            this.dtDateModifiedTo.Size = new System.Drawing.Size(233, 22);
            this.dtDateModifiedTo.TabIndex = 47;
            this.ttSearchProductOrders.SetToolTip(this.dtDateModifiedTo, "The date modified to which you want to search product orders");
            // 
            // lblDateModifiedTo
            // 
            this.lblDateModifiedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateModifiedTo.AutoSize = true;
            this.lblDateModifiedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModifiedTo.Location = new System.Drawing.Point(414, 49);
            this.lblDateModifiedTo.Name = "lblDateModifiedTo";
            this.lblDateModifiedTo.Size = new System.Drawing.Size(131, 16);
            this.lblDateModifiedTo.TabIndex = 46;
            this.lblDateModifiedTo.Text = "Date Modified To:";
            // 
            // dtDateModifiedFrom
            // 
            this.dtDateModifiedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateModifiedFrom.Location = new System.Drawing.Point(571, 15);
            this.dtDateModifiedFrom.Name = "dtDateModifiedFrom";
            this.dtDateModifiedFrom.Size = new System.Drawing.Size(232, 22);
            this.dtDateModifiedFrom.TabIndex = 45;
            this.ttSearchProductOrders.SetToolTip(this.dtDateModifiedFrom, "The date modified from which you want to search product orders");
            // 
            // lblDateModifiedFrom
            // 
            this.lblDateModifiedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateModifiedFrom.AutoSize = true;
            this.lblDateModifiedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModifiedFrom.Location = new System.Drawing.Point(413, 20);
            this.lblDateModifiedFrom.Name = "lblDateModifiedFrom";
            this.lblDateModifiedFrom.Size = new System.Drawing.Size(147, 16);
            this.lblDateModifiedFrom.TabIndex = 44;
            this.lblDateModifiedFrom.Text = "Date Modified From:";
            // 
            // cbSelectClient
            // 
            this.cbSelectClient.DataSource = this.userBindingSource;
            this.cbSelectClient.DisplayMember = "UserDisplayName";
            this.cbSelectClient.FormattingEnabled = true;
            this.cbSelectClient.Location = new System.Drawing.Point(155, 100);
            this.cbSelectClient.Name = "cbSelectClient";
            this.cbSelectClient.Size = new System.Drawing.Size(240, 24);
            this.cbSelectClient.TabIndex = 43;
            this.ttSearchProductOrders.SetToolTip(this.cbSelectClient, "The client with which you want to search product orders");
            this.cbSelectClient.ValueMember = "ID";
            // 
            // lblSelectClient
            // 
            this.lblSelectClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectClient.AutoSize = true;
            this.lblSelectClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectClient.Location = new System.Drawing.Point(19, 103);
            this.lblSelectClient.Name = "lblSelectClient";
            this.lblSelectClient.Size = new System.Drawing.Size(98, 16);
            this.lblSelectClient.TabIndex = 42;
            this.lblSelectClient.Text = "Select Client:";
            // 
            // cbSelectProduct
            // 
            this.cbSelectProduct.DataSource = this.productBindingSource;
            this.cbSelectProduct.DisplayMember = "ProductName";
            this.cbSelectProduct.FormattingEnabled = true;
            this.cbSelectProduct.Location = new System.Drawing.Point(155, 40);
            this.cbSelectProduct.Name = "cbSelectProduct";
            this.cbSelectProduct.Size = new System.Drawing.Size(240, 24);
            this.cbSelectProduct.TabIndex = 41;
            this.ttSearchProductOrders.SetToolTip(this.cbSelectProduct, "The product with which you want to search product orders");
            this.cbSelectProduct.ValueMember = "ID";
            // 
            // trbDesiredQuantity
            // 
            this.trbDesiredQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trbDesiredQuantity.Location = new System.Drawing.Point(155, 199);
            this.trbDesiredQuantity.Maximum = 5000;
            this.trbDesiredQuantity.MaximumSize = new System.Drawing.Size(5000, 50);
            this.trbDesiredQuantity.Name = "trbDesiredQuantity";
            this.trbDesiredQuantity.Size = new System.Drawing.Size(219, 50);
            this.trbDesiredQuantity.TabIndex = 38;
            this.trbDesiredQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttSearchProductOrders.SetToolTip(this.trbDesiredQuantity, "The desired quantity with which you want to search product orders");
            this.trbDesiredQuantity.Scroll += new System.EventHandler(this.trbQuantity_Scroll);
            // 
            // lblDesiredQuantity
            // 
            this.lblDesiredQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDesiredQuantity.AutoSize = true;
            this.lblDesiredQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesiredQuantity.Location = new System.Drawing.Point(26, 199);
            this.lblDesiredQuantity.MaximumSize = new System.Drawing.Size(0, 50);
            this.lblDesiredQuantity.Name = "lblDesiredQuantity";
            this.lblDesiredQuantity.Size = new System.Drawing.Size(126, 16);
            this.lblDesiredQuantity.TabIndex = 36;
            this.lblDesiredQuantity.Text = "Desired Quantity:";
            // 
            // cbSelectEmployee
            // 
            this.cbSelectEmployee.DataSource = this.userBindingSource;
            this.cbSelectEmployee.DisplayMember = "UserDisplayName";
            this.cbSelectEmployee.FormattingEnabled = true;
            this.cbSelectEmployee.Location = new System.Drawing.Point(155, 70);
            this.cbSelectEmployee.Name = "cbSelectEmployee";
            this.cbSelectEmployee.Size = new System.Drawing.Size(240, 24);
            this.cbSelectEmployee.TabIndex = 35;
            this.ttSearchProductOrders.SetToolTip(this.cbSelectEmployee, "The employee with which you want to search product orders");
            this.cbSelectEmployee.ValueMember = "ID";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(200, 543);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 47);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "DELETE";
            this.ttSearchProductOrders.SetToolTip(this.btnDelete, "When you click the button you delete an entry based on the permissions you have.");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddOrEdit
            // 
            this.btnAddOrEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOrEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrEdit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrEdit.Location = new System.Drawing.Point(104, 543);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.Size = new System.Drawing.Size(90, 47);
            this.btnAddOrEdit.TabIndex = 33;
            this.btnAddOrEdit.Text = "ADD/EDIT";
            this.ttSearchProductOrders.SetToolTip(this.btnAddOrEdit, "When you click the button you add/edit an entry based on the permissions you have" +
        ".");
            this.btnAddOrEdit.UseVisualStyleBackColor = true;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // lblSearchMode
            // 
            this.lblSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchMode.AutoSize = true;
            this.lblSearchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchMode.Location = new System.Drawing.Point(440, 228);
            this.lblSearchMode.Name = "lblSearchMode";
            this.lblSearchMode.Size = new System.Drawing.Size(103, 16);
            this.lblSearchMode.TabIndex = 32;
            this.lblSearchMode.Text = "Search Mode:";
            // 
            // cbSearchMode
            // 
            this.cbSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearchMode.FormattingEnabled = true;
            this.cbSearchMode.Items.AddRange(new object[] {
            "None",
            "Single Criteria",
            "Multiple Criterias",
            "All Criterias"});
            this.cbSearchMode.Location = new System.Drawing.Point(572, 225);
            this.cbSearchMode.Name = "cbSearchMode";
            this.cbSearchMode.Size = new System.Drawing.Size(231, 24);
            this.cbSearchMode.TabIndex = 31;
            this.cbSearchMode.Text = "Multiple Criterias";
            this.ttSearchProductOrders.SetToolTip(this.cbSearchMode, resources.GetString("cbSearchMode.ToolTip"));
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(7, 543);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 47);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "SEARCH";
            this.ttSearchProductOrders.SetToolTip(this.btnSearch, "When you click the button you search based on the criterias search mode you selec" +
        "ted.");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // trbPriceOverride
            // 
            this.trbPriceOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trbPriceOverride.Location = new System.Drawing.Point(155, 255);
            this.trbPriceOverride.Maximum = 5000;
            this.trbPriceOverride.MaximumSize = new System.Drawing.Size(5000, 50);
            this.trbPriceOverride.Name = "trbPriceOverride";
            this.trbPriceOverride.Size = new System.Drawing.Size(219, 50);
            this.trbPriceOverride.TabIndex = 21;
            this.trbPriceOverride.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttSearchProductOrders.SetToolTip(this.trbPriceOverride, "The price overrride with which you want to search product orders");
            this.trbPriceOverride.Scroll += new System.EventHandler(this.trbPrice_Scroll);
            // 
            // lblPriceOverride
            // 
            this.lblPriceOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPriceOverride.AutoSize = true;
            this.lblPriceOverride.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceOverride.Location = new System.Drawing.Point(26, 258);
            this.lblPriceOverride.MaximumSize = new System.Drawing.Size(0, 50);
            this.lblPriceOverride.Name = "lblPriceOverride";
            this.lblPriceOverride.Size = new System.Drawing.Size(111, 16);
            this.lblPriceOverride.TabIndex = 19;
            this.lblPriceOverride.Text = "Price Override:";
            // 
            // txtOrderReason
            // 
            this.txtOrderReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderReason.Location = new System.Drawing.Point(573, 103);
            this.txtOrderReason.Multiline = true;
            this.txtOrderReason.Name = "txtOrderReason";
            this.txtOrderReason.Size = new System.Drawing.Size(230, 77);
            this.txtOrderReason.TabIndex = 14;
            this.ttSearchProductOrders.SetToolTip(this.txtOrderReason, "The reason with which you want to search product orders");
            // 
            // lblOrderReason
            // 
            this.lblOrderReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderReason.AutoSize = true;
            this.lblOrderReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderReason.Location = new System.Drawing.Point(442, 106);
            this.lblOrderReason.Name = "lblOrderReason";
            this.lblOrderReason.Size = new System.Drawing.Size(108, 16);
            this.lblOrderReason.TabIndex = 13;
            this.lblOrderReason.Text = "Order Reason:";
            // 
            // dtDateAddedTo
            // 
            this.dtDateAddedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtDateAddedTo.Location = new System.Drawing.Point(155, 158);
            this.dtDateAddedTo.Name = "dtDateAddedTo";
            this.dtDateAddedTo.Size = new System.Drawing.Size(240, 22);
            this.dtDateAddedTo.TabIndex = 12;
            this.ttSearchProductOrders.SetToolTip(this.dtDateAddedTo, "The date added to which you want to search product orders");
            // 
            // lblDateAddedTo
            // 
            this.lblDateAddedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateAddedTo.AutoSize = true;
            this.lblDateAddedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAddedTo.Location = new System.Drawing.Point(20, 158);
            this.lblDateAddedTo.Name = "lblDateAddedTo";
            this.lblDateAddedTo.Size = new System.Drawing.Size(117, 16);
            this.lblDateAddedTo.TabIndex = 11;
            this.lblDateAddedTo.Text = "Date Added To:";
            // 
            // dtDateAddedFrom
            // 
            this.dtDateAddedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtDateAddedFrom.Location = new System.Drawing.Point(155, 129);
            this.dtDateAddedFrom.Name = "dtDateAddedFrom";
            this.dtDateAddedFrom.Size = new System.Drawing.Size(239, 22);
            this.dtDateAddedFrom.TabIndex = 10;
            this.ttSearchProductOrders.SetToolTip(this.dtDateAddedFrom, "The date added from which you want to search product orders");
            // 
            // lblDateAddedFrom
            // 
            this.lblDateAddedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateAddedFrom.AutoSize = true;
            this.lblDateAddedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAddedFrom.Location = new System.Drawing.Point(19, 129);
            this.lblDateAddedFrom.Name = "lblDateAddedFrom";
            this.lblDateAddedFrom.Size = new System.Drawing.Size(133, 16);
            this.lblDateAddedFrom.TabIndex = 9;
            this.lblDateAddedFrom.Text = "Date Added From:";
            // 
            // lblSelectEmployee
            // 
            this.lblSelectEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectEmployee.AutoSize = true;
            this.lblSelectEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectEmployee.Location = new System.Drawing.Point(19, 73);
            this.lblSelectEmployee.Name = "lblSelectEmployee";
            this.lblSelectEmployee.Size = new System.Drawing.Size(129, 16);
            this.lblSelectEmployee.TabIndex = 5;
            this.lblSelectEmployee.Text = "Select Employee:";
            // 
            // lblSelectProduct
            // 
            this.lblSelectProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectProduct.AutoSize = true;
            this.lblSelectProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectProduct.Location = new System.Drawing.Point(19, 45);
            this.lblSelectProduct.Name = "lblSelectProduct";
            this.lblSelectProduct.Size = new System.Drawing.Size(112, 16);
            this.lblSelectProduct.TabIndex = 3;
            this.lblSelectProduct.Text = "Select Product:";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(155, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(240, 22);
            this.txtID.TabIndex = 2;
            this.ttSearchProductOrders.SetToolTip(this.txtID, "The ID of the selected record entry to be searched is here");
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
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // productImageBindingSource
            // 
            this.productImageBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductImage);
            // 
            // ttSearchProductOrders
            // 
            this.ttSearchProductOrders.IsBalloon = true;
            this.ttSearchProductOrders.ShowAlways = true;
            this.ttSearchProductOrders.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSearchProductOrders.ToolTipTitle = "Help";
            // 
            // IDColumn
            // 
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 125;
            // 
            // ProductIDColumn
            // 
            this.ProductIDColumn.DataPropertyName = "ProductID";
            this.ProductIDColumn.DataSource = this.productBindingSource;
            this.ProductIDColumn.DisplayMember = "ProductName";
            this.ProductIDColumn.HeaderText = "Product";
            this.ProductIDColumn.MinimumWidth = 6;
            this.ProductIDColumn.Name = "ProductIDColumn";
            this.ProductIDColumn.ReadOnly = true;
            this.ProductIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductIDColumn.ValueMember = "ID";
            this.ProductIDColumn.Width = 125;
            // 
            // DesiredQuantityColumn
            // 
            this.DesiredQuantityColumn.DataPropertyName = "DesiredQuantity";
            this.DesiredQuantityColumn.HeaderText = "Desired Quantity";
            this.DesiredQuantityColumn.MinimumWidth = 6;
            this.DesiredQuantityColumn.Name = "DesiredQuantityColumn";
            this.DesiredQuantityColumn.ReadOnly = true;
            this.DesiredQuantityColumn.Width = 200;
            // 
            // OrderPriceColumn
            // 
            this.OrderPriceColumn.DataPropertyName = "OrderPrice";
            this.OrderPriceColumn.HeaderText = "Order Price";
            this.OrderPriceColumn.MinimumWidth = 6;
            this.OrderPriceColumn.Name = "OrderPriceColumn";
            this.OrderPriceColumn.ReadOnly = true;
            this.OrderPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderPriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderPriceColumn.Width = 125;
            // 
            // EmployeeIDColumn
            // 
            this.EmployeeIDColumn.DataPropertyName = "EmployeeID";
            this.EmployeeIDColumn.DataSource = this.userBindingSource;
            this.EmployeeIDColumn.DisplayMember = "UserDisplayName";
            this.EmployeeIDColumn.HeaderText = "Employee";
            this.EmployeeIDColumn.MinimumWidth = 6;
            this.EmployeeIDColumn.Name = "EmployeeIDColumn";
            this.EmployeeIDColumn.ReadOnly = true;
            this.EmployeeIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EmployeeIDColumn.ValueMember = "ID";
            this.EmployeeIDColumn.Width = 125;
            // 
            // ClientIDColumn
            // 
            this.ClientIDColumn.DataPropertyName = "ClientID";
            this.ClientIDColumn.DataSource = this.userBindingSource;
            this.ClientIDColumn.DisplayMember = "UserDisplayName";
            this.ClientIDColumn.HeaderText = "Client";
            this.ClientIDColumn.MinimumWidth = 6;
            this.ClientIDColumn.Name = "ClientIDColumn";
            this.ClientIDColumn.ReadOnly = true;
            this.ClientIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClientIDColumn.ValueMember = "ID";
            this.ClientIDColumn.Width = 200;
            // 
            // OrderDateAddedColumn
            // 
            this.OrderDateAddedColumn.DataPropertyName = "DateAdded";
            this.OrderDateAddedColumn.HeaderText = "Date Added";
            this.OrderDateAddedColumn.MinimumWidth = 6;
            this.OrderDateAddedColumn.Name = "OrderDateAddedColumn";
            this.OrderDateAddedColumn.ReadOnly = true;
            this.OrderDateAddedColumn.Width = 125;
            // 
            // OrderDateModifiedColumn
            // 
            this.OrderDateModifiedColumn.DataPropertyName = "DateModified";
            this.OrderDateModifiedColumn.HeaderText = "Date Modified";
            this.OrderDateModifiedColumn.MinimumWidth = 6;
            this.OrderDateModifiedColumn.Name = "OrderDateModifiedColumn";
            this.OrderDateModifiedColumn.ReadOnly = true;
            this.OrderDateModifiedColumn.Width = 200;
            // 
            // OrderStatusColumn
            // 
            this.OrderStatusColumn.HeaderText = "Order Status";
            this.OrderStatusColumn.Items.AddRange(new object[] {
            "Awaiting processing",
            "Prepaid",
            "Paid on delivery",
            "Directly paid",
            "Generating invoice",
            "Generating report",
            "Processing",
            "Cancelled order",
            "Returned order",
            "Completed"});
            this.OrderStatusColumn.MinimumWidth = 6;
            this.OrderStatusColumn.Name = "OrderStatusColumn";
            this.OrderStatusColumn.ReadOnly = true;
            this.OrderStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderStatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderStatusColumn.Width = 200;
            // 
            // OrderReasonColumn
            // 
            this.OrderReasonColumn.DataPropertyName = "OrderReason";
            this.OrderReasonColumn.HeaderText = "Order Reason";
            this.OrderReasonColumn.MinimumWidth = 6;
            this.OrderReasonColumn.Name = "OrderReasonColumn";
            this.OrderReasonColumn.ReadOnly = true;
            this.OrderReasonColumn.Width = 200;
            // 
            // frmSearchProductOrders
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(820, 709);
            this.Controls.Add(this.dgvProductOrders);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchProductOrders";
            this.Text = "Product Orders";
            this.ttSearchProductOrders.SetToolTip(this, "The product orders window where you can search, add, edit, delete and generate re" +
        "ports on the product orders. Whether you can do it or not depends on your permis" +
        "sions");
            this.Load += new System.EventHandler(this.frmSearchProductOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbDesiredQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPriceOverride)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblSelectProduct;
        private System.Windows.Forms.Label lblDateAddedFrom;
        private System.Windows.Forms.DateTimePicker dtDateAddedFrom;
        private System.Windows.Forms.Label lblOrderReason;
        private System.Windows.Forms.DateTimePicker dtDateAddedTo;
        private System.Windows.Forms.Label lblDateAddedTo;
        private System.Windows.Forms.Label lblPriceOverride;
        private System.Windows.Forms.TrackBar trbPriceOverride;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbSearchMode;
        private System.Windows.Forms.Label lblSearchMode;
        private System.Windows.Forms.Button btnAddOrEdit;
        private System.Windows.Forms.Button btnDelete;
        private Label lblSelectEmployee;
        private ComboBox cbSelectEmployee;
        private BindingSource productBrandBindingSource;
        private BindingSource productBindingSource;
        private TextBox txtOrderReason;
        private TrackBar trbDesiredQuantity;
        private Label lblDesiredQuantity;
        private BindingSource productImageBindingSource;
        private ImageList imgListProductImages;
        private ComboBox cbSelectProduct;
        private ComboBox cbSelectClient;
        private Label lblSelectClient;
        private DateTimePicker dtDateModifiedTo;
        private Label lblDateModifiedTo;
        private DateTimePicker dtDateModifiedFrom;
        private Label lblDateModifiedFrom;
        private Label lblProductOrderNotice;
        private Label lblOrderStatus;
        private ComboBox cbSelectOrderStatus;
        private BindingSource productOrderBindingSource;
        private DataGridView dgvProductOrders;
        private Button btnGenerateReport;
        private TextBox txtPriceOverride;
        private TextBox txtDesiredQuantity;
        private ToolTip ttSearchProductOrders;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewComboBoxColumn ProductIDColumn;
        private DataGridViewTextBoxColumn DesiredQuantityColumn;
        private DataGridViewTextBoxColumn OrderPriceColumn;
        private DataGridViewComboBoxColumn EmployeeIDColumn;
        private DataGridViewComboBoxColumn ClientIDColumn;
        private DataGridViewTextBoxColumn OrderDateAddedColumn;
        private DataGridViewTextBoxColumn OrderDateModifiedColumn;
        private DataGridViewComboBoxColumn OrderStatusColumn;
        private DataGridViewTextBoxColumn OrderReasonColumn;
    }
}