﻿using System;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    partial class frmSearchProducts
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
                if (image_manager != null)
                {
                    image_manager.BulkOperationsExecuted -= ProductImages_BulkOperationExecuted;
                    image_manager = null;
                }
                if (product_manager != null)
                {
                    product_manager.BulkOperationsExecuted -= Products_BulkOperationExecuted;
                    product_manager = null;
                }
                if (product_images != null)
                {
                    product_images.Clear();
                    product_images = null;
                }
                if (products != null)
                {
                    products.Clear();
                    products = null;
                }
                if (product_brands != null)
                {
                    product_brands.Clear();
                    product_brands = null;
                }
                if (product_vendors != null)
                {
                    product_vendors.Clear();
                    product_vendors = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchProducts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lstProductImages = new System.Windows.Forms.ListView();
            this.ImageIDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductIDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListProductImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cbSelectVendor = new System.Windows.Forms.ComboBox();
            this.productVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblProductNotice = new System.Windows.Forms.Label();
            this.trbQuantity = new System.Windows.Forms.TrackBar();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbSelectBrand = new System.Windows.Forms.ComboBox();
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.trbPrice = new System.Windows.Forms.TrackBar();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtProductStorageLocation = new System.Windows.Forms.TextBox();
            this.lblStorageLocation = new System.Windows.Forms.Label();
            this.txtProductPartNum = new System.Windows.Forms.TextBox();
            this.lblProductPartNum = new System.Windows.Forms.Label();
            this.txtProductRegNum = new System.Windows.Forms.TextBox();
            this.lblProductRegNum = new System.Windows.Forms.Label();
            this.dtExpiryDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDateTo = new System.Windows.Forms.Label();
            this.dtExpiryDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDateFrom = new System.Windows.Forms.Label();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblImages = new System.Windows.Forms.Label();
            this.pnlImageData = new System.Windows.Forms.Panel();
            this.btnSearchProductImage = new System.Windows.Forms.Button();
            this.btnDeleteProductImage = new System.Windows.Forms.Button();
            this.btnAddEditProductImage = new System.Windows.Forms.Button();
            this.pbSelectedProductImage = new System.Windows.Forms.PictureBox();
            this.lblProductImageNotice = new System.Windows.Forms.Label();
            this.lblImageName = new System.Windows.Forms.Label();
            this.lblImageID = new System.Windows.Forms.Label();
            this.txtImageID = new System.Windows.Forms.TextBox();
            this.lblRefetrencedID = new System.Windows.Forms.Label();
            this.txtReferencedID = new System.Windows.Forms.TextBox();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.productImageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttSearchProducts = new System.Windows.Forms.ToolTip(this.components);
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.VendorIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProductNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductExpiryDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductRegistrationNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPartitudeNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSLocationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productVendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.pnlImageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProductImages
            // 
            this.lstProductImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProductImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ImageIDColumn,
            this.ProductIDColumn,
            this.ImageNameColumn});
            this.lstProductImages.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProductImages.FullRowSelect = true;
            this.lstProductImages.HideSelection = false;
            this.lstProductImages.LargeImageList = this.imgListProductImages;
            this.lstProductImages.Location = new System.Drawing.Point(3, 376);
            this.lstProductImages.MultiSelect = false;
            this.lstProductImages.Name = "lstProductImages";
            this.lstProductImages.Size = new System.Drawing.Size(397, 276);
            this.lstProductImages.SmallImageList = this.imgListProductImages;
            this.lstProductImages.StateImageList = this.imgListProductImages;
            this.lstProductImages.TabIndex = 40;
            this.ttSearchProducts.SetToolTip(this.lstProductImages, GLOBAL_RESOURCES.LST_PRODUCT_IMAGES_TOOLTIP_TITLE);
            this.lstProductImages.UseCompatibleStateImageBehavior = false;
            this.lstProductImages.View = System.Windows.Forms.View.Details;
            this.lstProductImages.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstProductImages_ItemSelectionChanged);
            // 
            // ImageIDColumn
            // 
            this.ImageIDColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.ID;
            // 
            // ProductIDColumn
            // 
            this.ProductIDColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.ProductID;
            this.ProductIDColumn.Width = 107;
            // 
            // ImageNameColumn
            // 
            this.ImageNameColumn.Text = global::XtremePharmacyManager.Properties.Settings.Default.ImageName;
            this.ImageNameColumn.Width = 233;
            // 
            // imgListProductImages
            // 
            this.imgListProductImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListProductImages.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListProductImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.txtPrice);
            this.pnlData.Controls.Add(this.txtQuantity);
            this.pnlData.Controls.Add(this.cbSelectVendor);
            this.pnlData.Controls.Add(this.lblVendor);
            this.pnlData.Controls.Add(this.btnGenerateReport);
            this.pnlData.Controls.Add(this.lblProductNotice);
            this.pnlData.Controls.Add(this.trbQuantity);
            this.pnlData.Controls.Add(this.lblQuantity);
            this.pnlData.Controls.Add(this.cbSelectBrand);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnAddOrEdit);
            this.pnlData.Controls.Add(this.lblSearchMode);
            this.pnlData.Controls.Add(this.cbSearchMode);
            this.pnlData.Controls.Add(this.btnSearch);
            this.pnlData.Controls.Add(this.trbPrice);
            this.pnlData.Controls.Add(this.lblPrice);
            this.pnlData.Controls.Add(this.txtProductStorageLocation);
            this.pnlData.Controls.Add(this.lblStorageLocation);
            this.pnlData.Controls.Add(this.txtProductPartNum);
            this.pnlData.Controls.Add(this.lblProductPartNum);
            this.pnlData.Controls.Add(this.txtProductRegNum);
            this.pnlData.Controls.Add(this.lblProductRegNum);
            this.pnlData.Controls.Add(this.dtExpiryDateTo);
            this.pnlData.Controls.Add(this.lblExpiryDateTo);
            this.pnlData.Controls.Add(this.dtExpiryDateFrom);
            this.pnlData.Controls.Add(this.lblExpiryDateFrom);
            this.pnlData.Controls.Add(this.txtProductDescription);
            this.pnlData.Controls.Add(this.lblProductDescription);
            this.pnlData.Controls.Add(this.lblBrand);
            this.pnlData.Controls.Add(this.txtProductName);
            this.pnlData.Controls.Add(this.lblProductName);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1220, 655);
            this.pnlData.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPrice.Location = new System.Drawing.Point(383, 274);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(49, 22);
            this.txtPrice.TabIndex = 52;
            this.ttSearchProducts.SetToolTip(this.txtPrice, GLOBAL_RESOURCES.PRODUCT_PRICE_SEARCH_TOOLTIP_TITLE);
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQuantity.Location = new System.Drawing.Point(383, 218);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(49, 22);
            this.txtQuantity.TabIndex = 51;
            this.ttSearchProducts.SetToolTip(this.txtQuantity, GLOBAL_RESOURCES.QUANTITY_SEARCH_TOOLTIP_TITLE);
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // cbSelectVendor
            // 
            this.cbSelectVendor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSelectVendor.DataSource = this.productVendorBindingSource;
            this.cbSelectVendor.DisplayMember = "VendorName";
            this.cbSelectVendor.FormattingEnabled = true;
            this.cbSelectVendor.Location = new System.Drawing.Point(569, 15);
            this.cbSelectVendor.Name = "cbSelectVendor";
            this.cbSelectVendor.Size = new System.Drawing.Size(232, 24);
            this.cbSelectVendor.TabIndex = 50;
            this.ttSearchProducts.SetToolTip(this.cbSelectVendor, GLOBAL_RESOURCES.CB_SELECT_VENDOR_SEARCH_TOOLTIP_TITLE);
            this.cbSelectVendor.ValueMember = "ID";
            // 
            // productVendorBindingSource
            // 
            this.productVendorBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductVendor);
            // 
            // lblVendor
            // 
            this.lblVendor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendor.Location = new System.Drawing.Point(410, 20);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(61, 16);
            this.lblVendor.TabIndex = 49;
            this.lblVendor.Text = GLOBAL_RESOURCES.LBL_VENDOR_TITLE;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(229, 322);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(127, 48);
            this.btnGenerateReport.TabIndex = 48;
            this.btnGenerateReport.Text = GLOBAL_RESOURCES.BTN_GENERATE_REPORT_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnGenerateReport, GLOBAL_RESOURCES.BTN_GENERATE_REPORT_TOOLTIP_TITLE);
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblProductNotice
            // 
            this.lblProductNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductNotice.AutoSize = true;
            this.lblProductNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.lblProductNotice.Location = new System.Drawing.Point(410, 158);
            this.lblProductNotice.Name = "lblProductNotice";
            this.lblProductNotice.Size = new System.Drawing.Size(319, 48);
            this.lblProductNotice.TabIndex = 40;
            this.lblProductNotice.Text = GLOBAL_RESOURCES.LBL_PRODUCT_NOTICE_TITLE;
            this.ttSearchProducts.SetToolTip(this.lblProductNotice, GLOBAL_RESOURCES.PRODUCT_NOTICE_TOOLTIP_TITLE);
            // 
            // trbQuantity
            // 
            this.trbQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trbQuantity.Location = new System.Drawing.Point(106, 215);
            this.trbQuantity.Maximum = 5000;
            this.trbQuantity.MaximumSize = new System.Drawing.Size(5000, 50);
            this.trbQuantity.Name = "trbQuantity";
            this.trbQuantity.Size = new System.Drawing.Size(268, 50);
            this.trbQuantity.TabIndex = 38;
            this.trbQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttSearchProducts.SetToolTip(this.trbQuantity, GLOBAL_RESOURCES.QUANTITY_SEARCH_TOOLTIP_TITLE);
            this.trbQuantity.Scroll += new System.EventHandler(this.trbQuantity_Scroll);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(34, 218);
            this.lblQuantity.MaximumSize = new System.Drawing.Size(0, 50);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(67, 16);
            this.lblQuantity.TabIndex = 36;
            this.lblQuantity.Text = GLOBAL_RESOURCES.LBL_QUANTITY_TITLE;
            // 
            // cbSelectBrand
            // 
            this.cbSelectBrand.DataSource = this.productBrandBindingSource;
            this.cbSelectBrand.DisplayMember = "BrandName";
            this.cbSelectBrand.FormattingEnabled = true;
            this.cbSelectBrand.Location = new System.Drawing.Point(136, 70);
            this.cbSelectBrand.Name = "cbSelectBrand";
            this.cbSelectBrand.Size = new System.Drawing.Size(259, 24);
            this.cbSelectBrand.TabIndex = 35;
            this.ttSearchProducts.SetToolTip(this.cbSelectBrand, GLOBAL_RESOURCES.CB_SELECT_BRAND_SEARCH_TOOLTIP_TITLE);
            this.cbSelectBrand.ValueMember = "ID";
            // 
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(161, 322);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 48);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = GLOBAL_RESOURCES.BTN_DELETE_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnDelete, GLOBAL_RESOURCES.BTN_DELETE_TOOLTIP_TITLE);
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddOrEdit
            // 
            this.btnAddOrEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddOrEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrEdit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrEdit.Location = new System.Drawing.Point(78, 322);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.Size = new System.Drawing.Size(77, 48);
            this.btnAddOrEdit.TabIndex = 33;
            this.btnAddOrEdit.Text = GLOBAL_RESOURCES.BTN_ADD_EDIT_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnAddOrEdit, GLOBAL_RESOURCES.BTN_ADD_EDIT_TOOLTIP_TITLE +
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
            this.lblSearchMode.Location = new System.Drawing.Point(438, 216);
            this.lblSearchMode.Name = "lblSearchMode";
            this.lblSearchMode.Size = new System.Drawing.Size(103, 16);
            this.lblSearchMode.TabIndex = 32;
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
            this.cbSearchMode.Location = new System.Drawing.Point(569, 213);
            this.cbSearchMode.Name = "cbSearchMode";
            this.cbSearchMode.Size = new System.Drawing.Size(232, 24);
            this.cbSearchMode.TabIndex = 31;
            this.cbSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_MULTIPLE;
            this.ttSearchProducts.SetToolTip(this.cbSearchMode, GLOBAL_RESOURCES.CB_SEARCH_MODE_TOOLTIP_TITLE);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(6, 322);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 48);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = GLOBAL_RESOURCES.BTN_SEARCH_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnSearch, GLOBAL_RESOURCES.BTN_SEARCH_TOOLTIP_TITLE);
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // trbPrice
            // 
            this.trbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trbPrice.Location = new System.Drawing.Point(106, 271);
            this.trbPrice.Maximum = 5000;
            this.trbPrice.MaximumSize = new System.Drawing.Size(5000, 50);
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(268, 50);
            this.trbPrice.TabIndex = 21;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttSearchProducts.SetToolTip(this.trbPrice, GLOBAL_RESOURCES.PRODUCT_PRICE_SEARCH_TOOLTIP_TITLE);
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(34, 274);
            this.lblPrice.MaximumSize = new System.Drawing.Size(0, 50);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(47, 16);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = GLOBAL_RESOURCES.LBL_PRICE_TITLE;
            // 
            // txtProductStorageLocation
            // 
            this.txtProductStorageLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductStorageLocation.Location = new System.Drawing.Point(569, 106);
            this.txtProductStorageLocation.Name = "txtProductStorageLocation";
            this.txtProductStorageLocation.Size = new System.Drawing.Size(232, 22);
            this.txtProductStorageLocation.TabIndex = 18;
            this.ttSearchProducts.SetToolTip(this.txtProductStorageLocation, GLOBAL_RESOURCES.S_LOCATION_SEARCH_TOOLTIP_TITLE);
            // 
            // lblStorageLocation
            // 
            this.lblStorageLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStorageLocation.AutoSize = true;
            this.lblStorageLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorageLocation.Location = new System.Drawing.Point(410, 112);
            this.lblStorageLocation.Name = "lblStorageLocation";
            this.lblStorageLocation.Size = new System.Drawing.Size(129, 16);
            this.lblStorageLocation.TabIndex = 17;
            this.lblStorageLocation.Text = GLOBAL_RESOURCES.LBL_S_LOCATION_TITLE;
            // 
            // txtProductPartNum
            // 
            this.txtProductPartNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductPartNum.Location = new System.Drawing.Point(569, 76);
            this.txtProductPartNum.Name = "txtProductPartNum";
            this.txtProductPartNum.Size = new System.Drawing.Size(232, 22);
            this.txtProductPartNum.TabIndex = 16;
            this.ttSearchProducts.SetToolTip(this.txtProductPartNum, GLOBAL_RESOURCES.PART_NUM_SEARCH_TOOLTIP_TITLE);
            // 
            // lblProductPartNum
            // 
            this.lblProductPartNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductPartNum.AutoSize = true;
            this.lblProductPartNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPartNum.Location = new System.Drawing.Point(410, 82);
            this.lblProductPartNum.Name = "lblProductPartNum";
            this.lblProductPartNum.Size = new System.Drawing.Size(131, 16);
            this.lblProductPartNum.TabIndex = 15;
            this.lblProductPartNum.Text = GLOBAL_RESOURCES.LBL_PART_NUM_TITLE;
            // 
            // txtProductRegNum
            // 
            this.txtProductRegNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductRegNum.Location = new System.Drawing.Point(569, 49);
            this.txtProductRegNum.Name = "txtProductRegNum";
            this.txtProductRegNum.Size = new System.Drawing.Size(232, 22);
            this.txtProductRegNum.TabIndex = 14;
            this.ttSearchProducts.SetToolTip(this.txtProductRegNum, GLOBAL_RESOURCES.REG_NUM_SEARCH_TOOLTIP_TITLE);
            // 
            // lblProductRegNum
            // 
            this.lblProductRegNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductRegNum.AutoSize = true;
            this.lblProductRegNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductRegNum.Location = new System.Drawing.Point(410, 48);
            this.lblProductRegNum.Name = "lblProductRegNum";
            this.lblProductRegNum.Size = new System.Drawing.Size(153, 16);
            this.lblProductRegNum.TabIndex = 13;
            this.lblProductRegNum.Text = GLOBAL_RESOURCES.LBL_REG_NUM_TITLE;
            // 
            // dtExpiryDateTo
            // 
            this.dtExpiryDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtExpiryDateTo.Location = new System.Drawing.Point(156, 158);
            this.dtExpiryDateTo.Name = "dtExpiryDateTo";
            this.dtExpiryDateTo.Size = new System.Drawing.Size(239, 22);
            this.dtExpiryDateTo.TabIndex = 12;
            this.ttSearchProducts.SetToolTip(this.dtExpiryDateTo, GLOBAL_RESOURCES.PRODUCT_EXP_DATE_TO_SEARCH_TOOLTIP_TITLE);
            // 
            // lblExpiryDateTo
            // 
            this.lblExpiryDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExpiryDateTo.AutoSize = true;
            this.lblExpiryDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryDateTo.Location = new System.Drawing.Point(20, 158);
            this.lblExpiryDateTo.Name = "lblExpiryDateTo";
            this.lblExpiryDateTo.Size = new System.Drawing.Size(114, 16);
            this.lblExpiryDateTo.TabIndex = 11;
            this.lblExpiryDateTo.Text = GLOBAL_RESOURCES.LBL_PRODUCT_EXP_DATE_TO_TITLE;
            // 
            // dtExpiryDateFrom
            // 
            this.dtExpiryDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtExpiryDateFrom.Location = new System.Drawing.Point(155, 129);
            this.dtExpiryDateFrom.Name = "dtExpiryDateFrom";
            this.dtExpiryDateFrom.Size = new System.Drawing.Size(239, 22);
            this.dtExpiryDateFrom.TabIndex = 10;
            this.ttSearchProducts.SetToolTip(this.dtExpiryDateFrom, GLOBAL_RESOURCES.PRODUCT_EXP_DATE_FROM_SEARCH_TOOLTIP_TITLE);
            // 
            // lblExpiryDateFrom
            // 
            this.lblExpiryDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExpiryDateFrom.AutoSize = true;
            this.lblExpiryDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryDateFrom.Location = new System.Drawing.Point(19, 129);
            this.lblExpiryDateFrom.Name = "lblExpiryDateFrom";
            this.lblExpiryDateFrom.Size = new System.Drawing.Size(130, 16);
            this.lblExpiryDateFrom.TabIndex = 9;
            this.lblExpiryDateFrom.Text = GLOBAL_RESOURCES.LBL_PRODUCT_EXP_DATE_FROM_TITLE;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductDescription.Location = new System.Drawing.Point(136, 98);
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(258, 22);
            this.txtProductDescription.TabIndex = 8;
            this.ttSearchProducts.SetToolTip(this.txtProductDescription, GLOBAL_RESOURCES.PRODUCT_DESCRIPTION_SEARCH_TOOLTIP_TITLE);
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDescription.Location = new System.Drawing.Point(19, 101);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(90, 16);
            this.lblProductDescription.TabIndex = 7;
            this.lblProductDescription.Text = GLOBAL_RESOURCES.LBL_PRODUCT_DESCRIPTION_TITLE;
            // 
            // lblBrand
            // 
            this.lblBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(19, 73);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(52, 16);
            this.lblBrand.TabIndex = 5;
            this.lblBrand.Text = GLOBAL_RESOURCES.LBL_BRAND_TITLE;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtProductName.Location = new System.Drawing.Point(136, 42);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(258, 22);
            this.txtProductName.TabIndex = 4;
            this.ttSearchProducts.SetToolTip(this.txtProductName, GLOBAL_RESOURCES.PRODUCT_NAME_SEARCH_TOOLTIP_TITLE);
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(19, 45);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(109, 16);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = GLOBAL_RESOURCES.LBL_PRODUCT_NAME_TITLE;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(136, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(258, 22);
            this.txtID.TabIndex = 2;
            this.ttSearchProducts.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_SEARCH_TOOLTIP_TITLE);
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
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProducts.ColumnHeadersHeight = 29;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.BrandIDColumn,
            this.VendorIDColumn,
            this.ProductNameColumn,
            this.ProductDescriptionColumn,
            this.ProductQuantityColumn,
            this.ProductPriceColumn,
            this.ProductExpiryDateColumn,
            this.ProductRegistrationNumColumn,
            this.ProductPartitudeNumColumn,
            this.ProductSLocationColumn});
            this.dgvProducts.DataSource = this.productBindingSource;
            this.dgvProducts.Location = new System.Drawing.Point(0, 376);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(811, 279);
            this.dgvProducts.TabIndex = 1;
            this.ttSearchProducts.SetToolTip(this.dgvProducts, GLOBAL_RESOURCES.DGV_PRODUCTS_TOOLTIP_TITLE);
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProducts_RowsAdded);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.Product);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // lblImages
            // 
            this.lblImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImages.AutoSize = true;
            this.lblImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImages.Location = new System.Drawing.Point(215, 14);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(62, 16);
            this.lblImages.TabIndex = 40;
            this.lblImages.Text = GLOBAL_RESOURCES.LBL_IMAGES_TITLE;
            // 
            // pnlImageData
            // 
            this.pnlImageData.Controls.Add(this.btnSearchProductImage);
            this.pnlImageData.Controls.Add(this.btnDeleteProductImage);
            this.pnlImageData.Controls.Add(this.btnAddEditProductImage);
            this.pnlImageData.Controls.Add(this.pbSelectedProductImage);
            this.pnlImageData.Controls.Add(this.lblProductImageNotice);
            this.pnlImageData.Controls.Add(this.lblImageName);
            this.pnlImageData.Controls.Add(this.lblImageID);
            this.pnlImageData.Controls.Add(this.txtImageID);
            this.pnlImageData.Controls.Add(this.lblRefetrencedID);
            this.pnlImageData.Controls.Add(this.txtReferencedID);
            this.pnlImageData.Controls.Add(this.txtImageName);
            this.pnlImageData.Controls.Add(this.lblImages);
            this.pnlImageData.Controls.Add(this.lstProductImages);
            this.pnlImageData.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlImageData.Location = new System.Drawing.Point(817, 0);
            this.pnlImageData.Name = "pnlImageData";
            this.pnlImageData.Size = new System.Drawing.Size(403, 655);
            this.pnlImageData.TabIndex = 41;
            // 
            // btnSearchProductImage
            // 
            this.btnSearchProductImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchProductImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearchProductImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProductImage.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProductImage.Location = new System.Drawing.Point(198, 215);
            this.btnSearchProductImage.Name = "btnSearchProductImage";
            this.btnSearchProductImage.Size = new System.Drawing.Size(196, 47);
            this.btnSearchProductImage.TabIndex = 46;
            this.btnSearchProductImage.Text = GLOBAL_RESOURCES.BTN_SEARCH_PRODUCT_IMAGE_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnSearchProductImage, GLOBAL_RESOURCES.BTN_SEARCH_TOOLTIP_TITLE);
            this.btnSearchProductImage.UseVisualStyleBackColor = true;
            this.btnSearchProductImage.Click += new System.EventHandler(this.btnSearchProductImage_Click);
            // 
            // btnDeleteProductImage
            // 
            this.btnDeleteProductImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteProductImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteProductImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProductImage.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProductImage.Location = new System.Drawing.Point(198, 323);
            this.btnDeleteProductImage.Name = "btnDeleteProductImage";
            this.btnDeleteProductImage.Size = new System.Drawing.Size(196, 47);
            this.btnDeleteProductImage.TabIndex = 45;
            this.btnDeleteProductImage.Text = GLOBAL_RESOURCES.BTN_DELETE_PRODUCT_IMAGE_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnDeleteProductImage, GLOBAL_RESOURCES.BTN_DELETE_TOOLTIP_TITLE);
            this.btnDeleteProductImage.UseVisualStyleBackColor = true;
            this.btnDeleteProductImage.Click += new System.EventHandler(this.btnDeleteProductImage_Click);
            // 
            // btnAddEditProductImage
            // 
            this.btnAddEditProductImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEditProductImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddEditProductImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEditProductImage.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEditProductImage.Location = new System.Drawing.Point(198, 269);
            this.btnAddEditProductImage.Name = "btnAddEditProductImage";
            this.btnAddEditProductImage.Size = new System.Drawing.Size(196, 47);
            this.btnAddEditProductImage.TabIndex = 40;
            this.btnAddEditProductImage.Text = GLOBAL_RESOURCES.BTN_ADD_EDIT_PRODUCT_IMAGE_TITLE;
            this.ttSearchProducts.SetToolTip(this.btnAddEditProductImage, GLOBAL_RESOURCES.BTN_ADD_EDIT_TOOLTIP_TITLE);
            this.btnAddEditProductImage.UseVisualStyleBackColor = true;
            this.btnAddEditProductImage.Click += new System.EventHandler(this.btnAddEditProductImage_Click);
            // 
            // pbSelectedProductImage
            // 
            this.pbSelectedProductImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSelectedProductImage.Location = new System.Drawing.Point(14, 215);
            this.pbSelectedProductImage.Name = "pbSelectedProductImage";
            this.pbSelectedProductImage.Size = new System.Drawing.Size(178, 155);
            this.pbSelectedProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedProductImage.TabIndex = 48;
            this.pbSelectedProductImage.TabStop = false;
            this.ttSearchProducts.SetToolTip(this.pbSelectedProductImage, GLOBAL_RESOURCES.SELECTED_PRODUCT_IMAGE_TOOLTIP_TITLE);
            // 
            // lblProductImageNotice
            // 
            this.lblProductImageNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductImageNotice.AutoSize = true;
            this.lblProductImageNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblProductImageNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.15F, System.Drawing.FontStyle.Bold);
            this.lblProductImageNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.lblProductImageNotice.Location = new System.Drawing.Point(22, 144);
            this.lblProductImageNotice.Name = "lblProductImageNotice";
            this.lblProductImageNotice.Size = new System.Drawing.Size(369, 30);
            this.lblProductImageNotice.TabIndex = 47;
            this.lblProductImageNotice.Text = GLOBAL_RESOURCES.LBL_PRODUCT_IMAGE_NOTICE_TITLE;
            this.ttSearchProducts.SetToolTip(this.lblProductImageNotice, GLOBAL_RESOURCES.PRODUCT_NOTICE_TOOLTIP_TITLE);
            // 
            // lblImageName
            // 
            this.lblImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageName.AutoSize = true;
            this.lblImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageName.Location = new System.Drawing.Point(25, 112);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(99, 16);
            this.lblImageName.TabIndex = 44;
            this.lblImageName.Text = GLOBAL_RESOURCES.LBL_IMAGE_NAME_TITLE;
            // 
            // lblImageID
            // 
            this.lblImageID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageID.AutoSize = true;
            this.lblImageID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageID.Location = new System.Drawing.Point(25, 42);
            this.lblImageID.Name = "lblImageID";
            this.lblImageID.Size = new System.Drawing.Size(73, 16);
            this.lblImageID.TabIndex = 42;
            this.lblImageID.Text = GLOBAL_RESOURCES.LBL_IMAGE_ID_TITLE;
            // 
            // txtImageID
            // 
            this.txtImageID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtImageID.Location = new System.Drawing.Point(198, 39);
            this.txtImageID.Name = "txtImageID";
            this.txtImageID.Size = new System.Drawing.Size(202, 22);
            this.txtImageID.TabIndex = 43;
            this.ttSearchProducts.SetToolTip(this.txtImageID, GLOBAL_RESOURCES.ID_SEARCH_TOOLTIP_TITLE);
            // 
            // lblRefetrencedID
            // 
            this.lblRefetrencedID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefetrencedID.AutoSize = true;
            this.lblRefetrencedID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefetrencedID.Location = new System.Drawing.Point(25, 78);
            this.lblRefetrencedID.Name = "lblRefetrencedID";
            this.lblRefetrencedID.Size = new System.Drawing.Size(111, 16);
            this.lblRefetrencedID.TabIndex = 39;
            this.lblRefetrencedID.Text = GLOBAL_RESOURCES.LBL_REFERENCED_ID_TITLE;
            // 
            // txtReferencedID
            // 
            this.txtReferencedID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReferencedID.Location = new System.Drawing.Point(198, 75);
            this.txtReferencedID.Name = "txtReferencedID";
            this.txtReferencedID.Size = new System.Drawing.Size(202, 22);
            this.txtReferencedID.TabIndex = 41;
            this.ttSearchProducts.SetToolTip(this.txtReferencedID, GLOBAL_RESOURCES.REFERENCED_ID_SEARCH_TOOLTIP_TITLE);
            // 
            // txtImageName
            // 
            this.txtImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtImageName.Location = new System.Drawing.Point(198, 106);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(202, 22);
            this.txtImageName.TabIndex = 40;
            this.ttSearchProducts.SetToolTip(this.txtImageName, GLOBAL_RESOURCES.IMAGE_NAME_SEARCH_TOOLTIP_TITLE);
            // 
            // productImageBindingSource
            // 
            this.productImageBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductImage);
            // 
            // ttSearchProducts
            // 
            this.ttSearchProducts.IsBalloon = true;
            this.ttSearchProducts.ShowAlways = true;
            this.ttSearchProducts.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSearchProducts.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // IDColumn
            // 
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_ID_COL_TITLE;
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 125;
            // 
            // BrandIDColumn
            // 
            this.BrandIDColumn.DataPropertyName = "BrandID";
            this.BrandIDColumn.DataSource = this.productBrandBindingSource;
            this.BrandIDColumn.DisplayMember = "BrandName";
            this.BrandIDColumn.HeaderText = GLOBAL_RESOURCES.BRAND_COL_TITLE;
            this.BrandIDColumn.MinimumWidth = 6;
            this.BrandIDColumn.Name = "BrandIDColumn";
            this.BrandIDColumn.ReadOnly = true;
            this.BrandIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrandIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BrandIDColumn.ValueMember = "ID";
            this.BrandIDColumn.Width = 125;
            // 
            // VendorIDColumn
            // 
            this.VendorIDColumn.DataPropertyName = "VendorID";
            this.VendorIDColumn.DataSource = this.productVendorBindingSource;
            this.VendorIDColumn.DisplayMember = "VendorName";
            this.VendorIDColumn.HeaderText = GLOBAL_RESOURCES.VENDOR_COL_TITLE;
            this.VendorIDColumn.MinimumWidth = 6;
            this.VendorIDColumn.Name = "VendorIDColumn";
            this.VendorIDColumn.ReadOnly = true;
            this.VendorIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VendorIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VendorIDColumn.ValueMember = "ID";
            this.VendorIDColumn.Width = 125;
            // 
            // ProductNameColumn
            // 
            this.ProductNameColumn.DataPropertyName = "ProductName";
            this.ProductNameColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_NAME_COL_TITLE;
            this.ProductNameColumn.MinimumWidth = 6;
            this.ProductNameColumn.Name = "ProductNameColumn";
            this.ProductNameColumn.ReadOnly = true;
            this.ProductNameColumn.Width = 125;
            // 
            // ProductDescriptionColumn
            // 
            this.ProductDescriptionColumn.DataPropertyName = "ProductDescription";
            this.ProductDescriptionColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_DESCRIPTION_COL_TITLE;
            this.ProductDescriptionColumn.MinimumWidth = 6;
            this.ProductDescriptionColumn.Name = "ProductDescriptionColumn";
            this.ProductDescriptionColumn.ReadOnly = true;
            this.ProductDescriptionColumn.Width = 200;
            // 
            // ProductQuantityColumn
            // 
            this.ProductQuantityColumn.DataPropertyName = "ProductQuantity";
            this.ProductQuantityColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_QUANTITY_COL_TITLE;
            this.ProductQuantityColumn.MinimumWidth = 6;
            this.ProductQuantityColumn.Name = "ProductQuantityColumn";
            this.ProductQuantityColumn.ReadOnly = true;
            this.ProductQuantityColumn.Width = 200;
            // 
            // ProductPriceColumn
            // 
            this.ProductPriceColumn.DataPropertyName = "ProductPrice";
            this.ProductPriceColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_PRICE_COL_TITLE;
            this.ProductPriceColumn.MinimumWidth = 6;
            this.ProductPriceColumn.Name = "ProductPriceColumn";
            this.ProductPriceColumn.ReadOnly = true;
            this.ProductPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductPriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductPriceColumn.Width = 125;
            // 
            // ProductExpiryDateColumn
            // 
            this.ProductExpiryDateColumn.DataPropertyName = "ProductExpiryDate";
            this.ProductExpiryDateColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_EXP_DATE_COL_TITLE;
            this.ProductExpiryDateColumn.MinimumWidth = 6;
            this.ProductExpiryDateColumn.Name = "ProductExpiryDateColumn";
            this.ProductExpiryDateColumn.ReadOnly = true;
            this.ProductExpiryDateColumn.Width = 125;
            // 
            // ProductRegistrationNumColumn
            // 
            this.ProductRegistrationNumColumn.DataPropertyName = "ProductRegNum";
            this.ProductRegistrationNumColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_REG_NUM_COL_TITLE;
            this.ProductRegistrationNumColumn.MinimumWidth = 6;
            this.ProductRegistrationNumColumn.Name = "ProductRegistrationNumColumn";
            this.ProductRegistrationNumColumn.ReadOnly = true;
            this.ProductRegistrationNumColumn.Width = 200;
            // 
            // ProductPartitudeNumColumn
            // 
            this.ProductPartitudeNumColumn.DataPropertyName = "ProductPartNum";
            this.ProductPartitudeNumColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_PART_NUM_COL_TITLE;
            this.ProductPartitudeNumColumn.MinimumWidth = 6;
            this.ProductPartitudeNumColumn.Name = "ProductPartitudeNumColumn";
            this.ProductPartitudeNumColumn.ReadOnly = true;
            this.ProductPartitudeNumColumn.Width = 200;
            // 
            // ProductSLocationColumn
            // 
            this.ProductSLocationColumn.DataPropertyName = "ProductStorageLocation";
            this.ProductSLocationColumn.HeaderText = GLOBAL_RESOURCES.PRODUCT_S_LOCATION_COL_TITLE;
            this.ProductSLocationColumn.MinimumWidth = 6;
            this.ProductSLocationColumn.Name = "ProductSLocationColumn";
            this.ProductSLocationColumn.ReadOnly = true;
            this.ProductSLocationColumn.Width = 200;
            // 
            // frmSearchProducts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1220, 655);
            this.Controls.Add(this.pnlImageData);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchProducts";
            this.Text = GLOBAL_RESOURCES.PRODUCTS_TITLE;
            this.ttSearchProducts.SetToolTip(this,GLOBAL_RESOURCES.PRODUCTS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmSearchProducts_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productVendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.pnlImageData.ResumeLayout(false);
            this.pnlImageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblExpiryDateFrom;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.DateTimePicker dtExpiryDateFrom;
        private System.Windows.Forms.TextBox txtProductStorageLocation;
        private System.Windows.Forms.Label lblStorageLocation;
        private System.Windows.Forms.TextBox txtProductPartNum;
        private System.Windows.Forms.Label lblProductPartNum;
        private System.Windows.Forms.Label lblProductRegNum;
        private System.Windows.Forms.DateTimePicker dtExpiryDateTo;
        private System.Windows.Forms.Label lblExpiryDateTo;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TrackBar trbPrice;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbSearchMode;
        private System.Windows.Forms.Label lblSearchMode;
        private System.Windows.Forms.Button btnAddOrEdit;
        private System.Windows.Forms.Button btnDelete;
        private Label lblBrand;
        private ComboBox cbSelectBrand;
        private BindingSource productBrandBindingSource;
        private BindingSource productBindingSource;
        private TextBox txtProductRegNum;
        private TrackBar trbQuantity;
        private Label lblQuantity;
        private ColumnHeader ImageNameColumn;
        private Label lblImages;
        private Panel pnlImageData;
        private Button btnAddEditProductImage;
        private TextBox txtReferencedID;
        private TextBox txtImageName;
        private BindingSource productImageBindingSource;
        private ColumnHeader ProductIDColumn;
        private ImageList imgListProductImages;
        private ListView lstProductImages;
        private Label lblImageName;
        private Label lblImageID;
        private TextBox txtImageID;
        private Label lblRefetrencedID;
        private Label lblProductNotice;
        private Button btnDeleteProductImage;
        private Button btnSearchProductImage;
        private Label lblProductImageNotice;
        private PictureBox pbSelectedProductImage;
        private ColumnHeader ImageIDColumn;
        private Button btnGenerateReport;
        private ComboBox cbSelectVendor;
        private BindingSource productVendorBindingSource;
        private Label lblVendor;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private ToolTip ttSearchProducts;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewComboBoxColumn BrandIDColumn;
        private DataGridViewComboBoxColumn VendorIDColumn;
        private DataGridViewTextBoxColumn ProductNameColumn;
        private DataGridViewTextBoxColumn ProductDescriptionColumn;
        private DataGridViewTextBoxColumn ProductQuantityColumn;
        private DataGridViewTextBoxColumn ProductPriceColumn;
        private DataGridViewTextBoxColumn ProductExpiryDateColumn;
        private DataGridViewTextBoxColumn ProductRegistrationNumColumn;
        private DataGridViewTextBoxColumn ProductPartitudeNumColumn;
        private DataGridViewTextBoxColumn ProductSLocationColumn;
    }
}