﻿using System;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    partial class frmSearchOrderDeliveries
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchOrderDeliveries));
            this.dgvOrderDeliveries = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductOrderIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TotalPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryServiceIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentMethodIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CargoIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDateAddedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryStatusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DeliveryReasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDeliveryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imgListProductImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtCargoID = new System.Windows.Forms.TextBox();
            this.lblCargoID = new System.Windows.Forms.Label();
            this.lblDeliveryStatus = new System.Windows.Forms.Label();
            this.cbSelectDeliveryStatus = new System.Windows.Forms.ComboBox();
            this.lblOrderDeliveryNotice = new System.Windows.Forms.Label();
            this.dtDateModifiedTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateModifiedTo = new System.Windows.Forms.Label();
            this.dtDateModifiedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateModifiedFrom = new System.Windows.Forms.Label();
            this.cbSelectPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblSelectPaymentMethod = new System.Windows.Forms.Label();
            this.cbSelectProductOrder = new System.Windows.Forms.ComboBox();
            this.cbSelectDeliveryService = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.trbTotalPrice = new System.Windows.Forms.TrackBar();
            this.lblShowTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtDeliveryReason = new System.Windows.Forms.TextBox();
            this.lblDeliveryReason = new System.Windows.Forms.Label();
            this.dtDateAddedTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateAddedTo = new System.Windows.Forms.Label();
            this.dtDateAddedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateAddedFrom = new System.Windows.Forms.Label();
            this.lblSelectDeliveryService = new System.Windows.Forms.Label();
            this.lblSelectProductOrder = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productImageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryServiceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAddedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryReasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryServiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDeliveries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDeliveryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderDeliveries
            // 
            this.dgvOrderDeliveries.AllowUserToAddRows = false;
            this.dgvOrderDeliveries.AllowUserToDeleteRows = false;
            this.dgvOrderDeliveries.AutoGenerateColumns = false;
            this.dgvOrderDeliveries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrderDeliveries.ColumnHeadersHeight = 29;
            this.dgvOrderDeliveries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.ProductOrderIDColumn,
            this.TotalPriceColumn,
            this.DeliveryServiceIDColumn,
            this.PaymentMethodIDColumn,
            this.CargoIDColumn,
            this.DeliveryDateAddedColumn,
            this.DeliveryDateModifiedColumn,
            this.DeliveryStatusColumn,
            this.DeliveryReasonColumn,
            this.iDDataGridViewTextBoxColumn,
            this.orderIDDataGridViewTextBoxColumn,
            this.deliveryServiceIDDataGridViewTextBoxColumn,
            this.paymentMethodIDDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn,
            this.dateAddedDataGridViewTextBoxColumn,
            this.dateModifiedDataGridViewTextBoxColumn,
            this.deliveryStatusDataGridViewTextBoxColumn,
            this.deliveryReasonDataGridViewTextBoxColumn,
            this.cargoIDDataGridViewTextBoxColumn,
            this.deliveryServiceDataGridViewTextBoxColumn,
            this.productOrderDataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn});
            this.dgvOrderDeliveries.DataSource = this.orderDeliveryBindingSource;
            this.dgvOrderDeliveries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDeliveries.Location = new System.Drawing.Point(0, 563);
            this.dgvOrderDeliveries.MultiSelect = false;
            this.dgvOrderDeliveries.Name = "dgvOrderDeliveries";
            this.dgvOrderDeliveries.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDeliveries.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderDeliveries.RowHeadersWidth = 51;
            this.dgvOrderDeliveries.RowTemplate.Height = 24;
            this.dgvOrderDeliveries.Size = new System.Drawing.Size(820, 146);
            this.dgvOrderDeliveries.TabIndex = 1;
            this.dgvOrderDeliveries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDeliveries_CellClick);
            this.dgvOrderDeliveries.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvOrderDeliveries_RowsAdded);
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
            // ProductOrderIDColumn
            // 
            this.ProductOrderIDColumn.DataPropertyName = "OrderID";
            this.ProductOrderIDColumn.DataSource = this.productOrderBindingSource;
            this.ProductOrderIDColumn.DisplayMember = "ID";
            this.ProductOrderIDColumn.HeaderText = "Product Order ID";
            this.ProductOrderIDColumn.MinimumWidth = 6;
            this.ProductOrderIDColumn.Name = "ProductOrderIDColumn";
            this.ProductOrderIDColumn.ReadOnly = true;
            this.ProductOrderIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductOrderIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductOrderIDColumn.ValueMember = "ID";
            this.ProductOrderIDColumn.Width = 125;
            // 
            // productOrderBindingSource
            // 
            this.productOrderBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductOrder);
            // 
            // TotalPriceColumn
            // 
            this.TotalPriceColumn.DataPropertyName = "TotalPrice";
            this.TotalPriceColumn.HeaderText = "Total Price";
            this.TotalPriceColumn.MinimumWidth = 6;
            this.TotalPriceColumn.Name = "TotalPriceColumn";
            this.TotalPriceColumn.ReadOnly = true;
            this.TotalPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TotalPriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalPriceColumn.Width = 125;
            // 
            // DeliveryServiceIDColumn
            // 
            this.DeliveryServiceIDColumn.DataPropertyName = "DeliveryServiceID";
            this.DeliveryServiceIDColumn.DataSource = this.deliveryServiceBindingSource;
            this.DeliveryServiceIDColumn.DisplayMember = "ServiceName";
            this.DeliveryServiceIDColumn.HeaderText = "Delivery Service";
            this.DeliveryServiceIDColumn.MinimumWidth = 6;
            this.DeliveryServiceIDColumn.Name = "DeliveryServiceIDColumn";
            this.DeliveryServiceIDColumn.ReadOnly = true;
            this.DeliveryServiceIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeliveryServiceIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeliveryServiceIDColumn.ValueMember = "ID";
            this.DeliveryServiceIDColumn.Width = 125;
            // 
            // deliveryServiceBindingSource
            // 
            this.deliveryServiceBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.DeliveryService);
            // 
            // PaymentMethodIDColumn
            // 
            this.PaymentMethodIDColumn.DataPropertyName = "ClientID";
            this.PaymentMethodIDColumn.DataSource = this.paymentMethodBindingSource;
            this.PaymentMethodIDColumn.DisplayMember = "MethodName";
            this.PaymentMethodIDColumn.HeaderText = "Payment Method";
            this.PaymentMethodIDColumn.MinimumWidth = 6;
            this.PaymentMethodIDColumn.Name = "PaymentMethodIDColumn";
            this.PaymentMethodIDColumn.ReadOnly = true;
            this.PaymentMethodIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PaymentMethodIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PaymentMethodIDColumn.ValueMember = "ID";
            this.PaymentMethodIDColumn.Width = 200;
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // CargoIDColumn
            // 
            this.CargoIDColumn.DataPropertyName = "CargoID";
            this.CargoIDColumn.HeaderText = "Cargo ID";
            this.CargoIDColumn.MinimumWidth = 6;
            this.CargoIDColumn.Name = "CargoIDColumn";
            this.CargoIDColumn.ReadOnly = true;
            this.CargoIDColumn.Width = 125;
            // 
            // DeliveryDateAddedColumn
            // 
            this.DeliveryDateAddedColumn.DataPropertyName = "DateAdded";
            this.DeliveryDateAddedColumn.HeaderText = "Date Added";
            this.DeliveryDateAddedColumn.MinimumWidth = 6;
            this.DeliveryDateAddedColumn.Name = "DeliveryDateAddedColumn";
            this.DeliveryDateAddedColumn.ReadOnly = true;
            this.DeliveryDateAddedColumn.Width = 125;
            // 
            // DeliveryDateModifiedColumn
            // 
            this.DeliveryDateModifiedColumn.DataPropertyName = "DateModified";
            this.DeliveryDateModifiedColumn.HeaderText = "Date Modified";
            this.DeliveryDateModifiedColumn.MinimumWidth = 6;
            this.DeliveryDateModifiedColumn.Name = "DeliveryDateModifiedColumn";
            this.DeliveryDateModifiedColumn.ReadOnly = true;
            this.DeliveryDateModifiedColumn.Width = 200;
            // 
            // DeliveryStatusColumn
            // 
            this.DeliveryStatusColumn.HeaderText = "Delivery Status";
            this.DeliveryStatusColumn.Items.AddRange(new object[] {
            "pending delivery",
            "prepaid",
            "directly paid",
            "paid on delivery",
            "generating invoice",
            "generating report",
            "on the move",
            "cancelled delivery",
            "returned delivery",
            "delivery completed"});
            this.DeliveryStatusColumn.MinimumWidth = 6;
            this.DeliveryStatusColumn.Name = "DeliveryStatusColumn";
            this.DeliveryStatusColumn.ReadOnly = true;
            this.DeliveryStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeliveryStatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeliveryStatusColumn.Width = 200;
            // 
            // DeliveryReasonColumn
            // 
            this.DeliveryReasonColumn.DataPropertyName = "DeliveryReason";
            this.DeliveryReasonColumn.HeaderText = "Delivery Reason";
            this.DeliveryReasonColumn.MinimumWidth = 6;
            this.DeliveryReasonColumn.Name = "DeliveryReasonColumn";
            this.DeliveryReasonColumn.ReadOnly = true;
            this.DeliveryReasonColumn.Width = 200;
            // 
            // orderDeliveryBindingSource
            // 
            this.orderDeliveryBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.OrderDelivery);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.Product);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // imgListProductImages
            // 
            this.imgListProductImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListProductImages.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListProductImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.btnGenerateReport);
            this.pnlData.Controls.Add(this.txtCargoID);
            this.pnlData.Controls.Add(this.lblCargoID);
            this.pnlData.Controls.Add(this.lblDeliveryStatus);
            this.pnlData.Controls.Add(this.cbSelectDeliveryStatus);
            this.pnlData.Controls.Add(this.lblOrderDeliveryNotice);
            this.pnlData.Controls.Add(this.dtDateModifiedTo);
            this.pnlData.Controls.Add(this.lblDateModifiedTo);
            this.pnlData.Controls.Add(this.dtDateModifiedFrom);
            this.pnlData.Controls.Add(this.lblDateModifiedFrom);
            this.pnlData.Controls.Add(this.cbSelectPaymentMethod);
            this.pnlData.Controls.Add(this.lblSelectPaymentMethod);
            this.pnlData.Controls.Add(this.cbSelectProductOrder);
            this.pnlData.Controls.Add(this.cbSelectDeliveryService);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnAddOrEdit);
            this.pnlData.Controls.Add(this.lblSearchMode);
            this.pnlData.Controls.Add(this.cbSearchMode);
            this.pnlData.Controls.Add(this.btnSearch);
            this.pnlData.Controls.Add(this.trbTotalPrice);
            this.pnlData.Controls.Add(this.lblShowTotalPrice);
            this.pnlData.Controls.Add(this.lblTotalPrice);
            this.pnlData.Controls.Add(this.txtDeliveryReason);
            this.pnlData.Controls.Add(this.lblDeliveryReason);
            this.pnlData.Controls.Add(this.dtDateAddedTo);
            this.pnlData.Controls.Add(this.lblDateAddedTo);
            this.pnlData.Controls.Add(this.dtDateAddedFrom);
            this.pnlData.Controls.Add(this.lblDateAddedFrom);
            this.pnlData.Controls.Add(this.lblSelectDeliveryService);
            this.pnlData.Controls.Add(this.lblSelectProductOrder);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(820, 563);
            this.pnlData.TabIndex = 0;
            // 
            // txtCargoID
            // 
            this.txtCargoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargoID.Location = new System.Drawing.Point(195, 183);
            this.txtCargoID.Name = "txtCargoID";
            this.txtCargoID.Size = new System.Drawing.Size(200, 22);
            this.txtCargoID.TabIndex = 52;
            // 
            // lblCargoID
            // 
            this.lblCargoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCargoID.AutoSize = true;
            this.lblCargoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoID.Location = new System.Drawing.Point(20, 189);
            this.lblCargoID.Name = "lblCargoID";
            this.lblCargoID.Size = new System.Drawing.Size(72, 16);
            this.lblCargoID.TabIndex = 51;
            this.lblCargoID.Text = "Cargo ID:";
            // 
            // lblDeliveryStatus
            // 
            this.lblDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeliveryStatus.AutoSize = true;
            this.lblDeliveryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryStatus.Location = new System.Drawing.Point(442, 75);
            this.lblDeliveryStatus.Name = "lblDeliveryStatus";
            this.lblDeliveryStatus.Size = new System.Drawing.Size(116, 16);
            this.lblDeliveryStatus.TabIndex = 50;
            this.lblDeliveryStatus.Text = "Delivery Status:";
            // 
            // cbSelectDeliveryStatus
            // 
            this.cbSelectDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSelectDeliveryStatus.FormattingEnabled = true;
            this.cbSelectDeliveryStatus.Items.AddRange(new object[] {
            "pending delivery",
            "prepaid",
            "directly paid",
            "paid on delivery",
            "generating invoice",
            "generating report",
            "on the move",
            "cancelled delivery",
            "returned delivery",
            "delivery completed"});
            this.cbSelectDeliveryStatus.Location = new System.Drawing.Point(573, 72);
            this.cbSelectDeliveryStatus.Name = "cbSelectDeliveryStatus";
            this.cbSelectDeliveryStatus.Size = new System.Drawing.Size(232, 24);
            this.cbSelectDeliveryStatus.TabIndex = 49;
            this.cbSelectDeliveryStatus.Text = "pending delivery";
            // 
            // lblOrderDeliveryNotice
            // 
            this.lblOrderDeliveryNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderDeliveryNotice.AutoSize = true;
            this.lblOrderDeliveryNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.lblOrderDeliveryNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.lblOrderDeliveryNotice.Location = new System.Drawing.Point(376, 252);
            this.lblOrderDeliveryNotice.Name = "lblOrderDeliveryNotice";
            this.lblOrderDeliveryNotice.Size = new System.Drawing.Size(441, 240);
            this.lblOrderDeliveryNotice.TabIndex = 48;
            this.lblOrderDeliveryNotice.Text = resources.GetString("lblOrderDeliveryNotice.Text");
            // 
            // dtDateModifiedTo
            // 
            this.dtDateModifiedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateModifiedTo.Location = new System.Drawing.Point(571, 44);
            this.dtDateModifiedTo.Name = "dtDateModifiedTo";
            this.dtDateModifiedTo.Size = new System.Drawing.Size(233, 22);
            this.dtDateModifiedTo.TabIndex = 47;
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
            // cbSelectPaymentMethod
            // 
            this.cbSelectPaymentMethod.DataSource = this.paymentMethodBindingSource;
            this.cbSelectPaymentMethod.DisplayMember = "MethodName";
            this.cbSelectPaymentMethod.FormattingEnabled = true;
            this.cbSelectPaymentMethod.Location = new System.Drawing.Point(195, 100);
            this.cbSelectPaymentMethod.Name = "cbSelectPaymentMethod";
            this.cbSelectPaymentMethod.Size = new System.Drawing.Size(200, 24);
            this.cbSelectPaymentMethod.TabIndex = 43;
            this.cbSelectPaymentMethod.ValueMember = "ID";
            // 
            // lblSelectPaymentMethod
            // 
            this.lblSelectPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectPaymentMethod.AutoSize = true;
            this.lblSelectPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPaymentMethod.Location = new System.Drawing.Point(19, 103);
            this.lblSelectPaymentMethod.Name = "lblSelectPaymentMethod";
            this.lblSelectPaymentMethod.Size = new System.Drawing.Size(174, 16);
            this.lblSelectPaymentMethod.TabIndex = 42;
            this.lblSelectPaymentMethod.Text = "Select Payment Method:";
            // 
            // cbSelectProductOrder
            // 
            this.cbSelectProductOrder.DataSource = this.productOrderBindingSource;
            this.cbSelectProductOrder.DisplayMember = "ID";
            this.cbSelectProductOrder.FormattingEnabled = true;
            this.cbSelectProductOrder.Location = new System.Drawing.Point(195, 40);
            this.cbSelectProductOrder.Name = "cbSelectProductOrder";
            this.cbSelectProductOrder.Size = new System.Drawing.Size(200, 24);
            this.cbSelectProductOrder.TabIndex = 41;
            this.cbSelectProductOrder.ValueMember = "ID";
            // 
            // cbSelectDeliveryService
            // 
            this.cbSelectDeliveryService.DataSource = this.deliveryServiceBindingSource;
            this.cbSelectDeliveryService.DisplayMember = "ServiceName";
            this.cbSelectDeliveryService.FormattingEnabled = true;
            this.cbSelectDeliveryService.Location = new System.Drawing.Point(195, 70);
            this.cbSelectDeliveryService.Name = "cbSelectDeliveryService";
            this.cbSelectDeliveryService.Size = new System.Drawing.Size(200, 24);
            this.cbSelectDeliveryService.TabIndex = 35;
            this.cbSelectDeliveryService.ValueMember = "ID";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(430, 510);
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
            this.btnAddOrEdit.Location = new System.Drawing.Point(334, 510);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.Size = new System.Drawing.Size(90, 47);
            this.btnAddOrEdit.TabIndex = 33;
            this.btnAddOrEdit.Text = "ADD/EDIT";
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
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(237, 510);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 47);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // trbTotalPrice
            // 
            this.trbTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trbTotalPrice.Location = new System.Drawing.Point(149, 230);
            this.trbTotalPrice.Maximum = 5000;
            this.trbTotalPrice.MaximumSize = new System.Drawing.Size(5000, 50);
            this.trbTotalPrice.Name = "trbTotalPrice";
            this.trbTotalPrice.Size = new System.Drawing.Size(219, 50);
            this.trbTotalPrice.TabIndex = 21;
            this.trbTotalPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbTotalPrice.Scroll += new System.EventHandler(this.trbTotalPrice_Scroll);
            // 
            // lblShowTotalPrice
            // 
            this.lblShowTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblShowTotalPrice.AutoSize = true;
            this.lblShowTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowTotalPrice.Location = new System.Drawing.Point(374, 233);
            this.lblShowTotalPrice.MaximumSize = new System.Drawing.Size(0, 50);
            this.lblShowTotalPrice.Name = "lblShowTotalPrice";
            this.lblShowTotalPrice.Size = new System.Drawing.Size(35, 16);
            this.lblShowTotalPrice.TabIndex = 20;
            this.lblShowTotalPrice.Text = "0.00";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(20, 233);
            this.lblTotalPrice.MaximumSize = new System.Drawing.Size(0, 50);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(87, 16);
            this.lblTotalPrice.TabIndex = 19;
            this.lblTotalPrice.Text = "Total Price:";
            // 
            // txtDeliveryReason
            // 
            this.txtDeliveryReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryReason.Location = new System.Drawing.Point(573, 103);
            this.txtDeliveryReason.Multiline = true;
            this.txtDeliveryReason.Name = "txtDeliveryReason";
            this.txtDeliveryReason.Size = new System.Drawing.Size(230, 112);
            this.txtDeliveryReason.TabIndex = 14;
            // 
            // lblDeliveryReason
            // 
            this.lblDeliveryReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeliveryReason.AutoSize = true;
            this.lblDeliveryReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryReason.Location = new System.Drawing.Point(442, 106);
            this.lblDeliveryReason.Name = "lblDeliveryReason";
            this.lblDeliveryReason.Size = new System.Drawing.Size(127, 16);
            this.lblDeliveryReason.TabIndex = 13;
            this.lblDeliveryReason.Text = "Delivery Reason:";
            // 
            // dtDateAddedTo
            // 
            this.dtDateAddedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtDateAddedTo.Location = new System.Drawing.Point(155, 158);
            this.dtDateAddedTo.Name = "dtDateAddedTo";
            this.dtDateAddedTo.Size = new System.Drawing.Size(240, 22);
            this.dtDateAddedTo.TabIndex = 12;
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
            this.dtDateAddedFrom.Location = new System.Drawing.Point(158, 129);
            this.dtDateAddedFrom.Name = "dtDateAddedFrom";
            this.dtDateAddedFrom.Size = new System.Drawing.Size(236, 22);
            this.dtDateAddedFrom.TabIndex = 10;
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
            // lblSelectDeliveryService
            // 
            this.lblSelectDeliveryService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectDeliveryService.AutoSize = true;
            this.lblSelectDeliveryService.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDeliveryService.Location = new System.Drawing.Point(19, 73);
            this.lblSelectDeliveryService.Name = "lblSelectDeliveryService";
            this.lblSelectDeliveryService.Size = new System.Drawing.Size(174, 16);
            this.lblSelectDeliveryService.TabIndex = 5;
            this.lblSelectDeliveryService.Text = "Select Delivery Service:";
            // 
            // lblSelectProductOrder
            // 
            this.lblSelectProductOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectProductOrder.AutoSize = true;
            this.lblSelectProductOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectProductOrder.Location = new System.Drawing.Point(19, 45);
            this.lblSelectProductOrder.Name = "lblSelectProductOrder";
            this.lblSelectProductOrder.Size = new System.Drawing.Size(174, 16);
            this.lblSelectProductOrder.TabIndex = 3;
            this.lblSelectProductOrder.Text = "Select Product Order ID:";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(195, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 22);
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
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // productImageBindingSource
            // 
            this.productImageBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductImage);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryServiceIDDataGridViewTextBoxColumn
            // 
            this.deliveryServiceIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryServiceID";
            this.deliveryServiceIDDataGridViewTextBoxColumn.HeaderText = "DeliveryServiceID";
            this.deliveryServiceIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deliveryServiceIDDataGridViewTextBoxColumn.Name = "deliveryServiceIDDataGridViewTextBoxColumn";
            this.deliveryServiceIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryServiceIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // paymentMethodIDDataGridViewTextBoxColumn
            // 
            this.paymentMethodIDDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethodID";
            this.paymentMethodIDDataGridViewTextBoxColumn.HeaderText = "PaymentMethodID";
            this.paymentMethodIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paymentMethodIDDataGridViewTextBoxColumn.Name = "paymentMethodIDDataGridViewTextBoxColumn";
            this.paymentMethodIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentMethodIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateAddedDataGridViewTextBoxColumn
            // 
            this.dateAddedDataGridViewTextBoxColumn.DataPropertyName = "DateAdded";
            this.dateAddedDataGridViewTextBoxColumn.HeaderText = "DateAdded";
            this.dateAddedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateAddedDataGridViewTextBoxColumn.Name = "dateAddedDataGridViewTextBoxColumn";
            this.dateAddedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateAddedDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            this.dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            this.dateModifiedDataGridViewTextBoxColumn.HeaderText = "DateModified";
            this.dateModifiedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            this.dateModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateModifiedDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryStatusDataGridViewTextBoxColumn
            // 
            this.deliveryStatusDataGridViewTextBoxColumn.DataPropertyName = "DeliveryStatus";
            this.deliveryStatusDataGridViewTextBoxColumn.HeaderText = "DeliveryStatus";
            this.deliveryStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deliveryStatusDataGridViewTextBoxColumn.Name = "deliveryStatusDataGridViewTextBoxColumn";
            this.deliveryStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryStatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryReasonDataGridViewTextBoxColumn
            // 
            this.deliveryReasonDataGridViewTextBoxColumn.DataPropertyName = "DeliveryReason";
            this.deliveryReasonDataGridViewTextBoxColumn.HeaderText = "DeliveryReason";
            this.deliveryReasonDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deliveryReasonDataGridViewTextBoxColumn.Name = "deliveryReasonDataGridViewTextBoxColumn";
            this.deliveryReasonDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryReasonDataGridViewTextBoxColumn.Width = 125;
            // 
            // cargoIDDataGridViewTextBoxColumn
            // 
            this.cargoIDDataGridViewTextBoxColumn.DataPropertyName = "CargoID";
            this.cargoIDDataGridViewTextBoxColumn.HeaderText = "CargoID";
            this.cargoIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cargoIDDataGridViewTextBoxColumn.Name = "cargoIDDataGridViewTextBoxColumn";
            this.cargoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cargoIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryServiceDataGridViewTextBoxColumn
            // 
            this.deliveryServiceDataGridViewTextBoxColumn.DataPropertyName = "DeliveryService";
            this.deliveryServiceDataGridViewTextBoxColumn.HeaderText = "DeliveryService";
            this.deliveryServiceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deliveryServiceDataGridViewTextBoxColumn.Name = "deliveryServiceDataGridViewTextBoxColumn";
            this.deliveryServiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryServiceDataGridViewTextBoxColumn.Width = 125;
            // 
            // productOrderDataGridViewTextBoxColumn
            // 
            this.productOrderDataGridViewTextBoxColumn.DataPropertyName = "ProductOrder";
            this.productOrderDataGridViewTextBoxColumn.HeaderText = "ProductOrder";
            this.productOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productOrderDataGridViewTextBoxColumn.Name = "productOrderDataGridViewTextBoxColumn";
            this.productOrderDataGridViewTextBoxColumn.ReadOnly = true;
            this.productOrderDataGridViewTextBoxColumn.Width = 125;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentMethodDataGridViewTextBoxColumn.Width = 125;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(526, 510);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(278, 47);
            this.btnGenerateReport.TabIndex = 53;
            this.btnGenerateReport.Text = "GENERATE REPORT";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // frmSearchOrderDeliveries
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(820, 709);
            this.Controls.Add(this.dgvOrderDeliveries);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchOrderDeliveries";
            this.Text = "Order Deliveries";
            this.Load += new System.EventHandler(this.frmSearchOrderDeliveries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDeliveries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDeliveryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblSelectProductOrder;
        private System.Windows.Forms.Label lblDateAddedFrom;
        private System.Windows.Forms.DateTimePicker dtDateAddedFrom;
        private System.Windows.Forms.Label lblDeliveryReason;
        private System.Windows.Forms.DateTimePicker dtDateAddedTo;
        private System.Windows.Forms.Label lblDateAddedTo;
        private System.Windows.Forms.TrackBar trbTotalPrice;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbSearchMode;
        private System.Windows.Forms.Label lblSearchMode;
        private System.Windows.Forms.Button btnAddOrEdit;
        private System.Windows.Forms.Button btnDelete;
        private Label lblSelectDeliveryService;
        private ComboBox cbSelectDeliveryService;
        private BindingSource productBrandBindingSource;
        private BindingSource productBindingSource;
        private TextBox txtDeliveryReason;
        private BindingSource productImageBindingSource;
        private ImageList imgListProductImages;
        private ComboBox cbSelectProductOrder;
        private ComboBox cbSelectPaymentMethod;
        private Label lblSelectPaymentMethod;
        private DateTimePicker dtDateModifiedTo;
        private Label lblDateModifiedTo;
        private DateTimePicker dtDateModifiedFrom;
        private Label lblDateModifiedFrom;
        private Label lblOrderDeliveryNotice;
        private Label lblDeliveryStatus;
        private ComboBox cbSelectDeliveryStatus;
        private BindingSource productOrderBindingSource;
        private DataGridView dgvOrderDeliveries;
        private BindingSource orderDeliveryBindingSource;
        private BindingSource deliveryServiceBindingSource;
        private BindingSource paymentMethodBindingSource;
        private Label lblShowTotalPrice;
        private Label lblTotalPrice;
        private TextBox txtCargoID;
        private Label lblCargoID;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewComboBoxColumn ProductOrderIDColumn;
        private DataGridViewTextBoxColumn TotalPriceColumn;
        private DataGridViewComboBoxColumn DeliveryServiceIDColumn;
        private DataGridViewComboBoxColumn PaymentMethodIDColumn;
        private DataGridViewTextBoxColumn CargoIDColumn;
        private DataGridViewTextBoxColumn DeliveryDateAddedColumn;
        private DataGridViewTextBoxColumn DeliveryDateModifiedColumn;
        private DataGridViewComboBoxColumn DeliveryStatusColumn;
        private DataGridViewTextBoxColumn DeliveryReasonColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryServiceIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn paymentMethodIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateAddedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryReasonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cargoIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryServiceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productOrderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private Button btnGenerateReport;
    }
}