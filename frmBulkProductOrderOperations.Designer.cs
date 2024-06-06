namespace XtremePharmacyManager
{
    partial class frmBulkProductOrderOperations
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
                if(selected_operation != null)
                {
                    selected_operation = null;
                }
                if(selected_target != null)
                {
                    selected_target = null;
                }
                if(current_user != null)
                {
                    current_user = null;
                }
                if(client_entries != null)
                {
                    client_entries.Clear();
                    client_entries = null;
                }
                if(employee_entries != null)
                {
                    employee_entries.Clear();
                    employee_entries = null;
                }
                if(product_entries != null)
                {
                    product_entries.Clear();
                    product_entries = null;
                }
                if(entries != null)
                {
                    entries.Clear();
                    entries = null;
                }
                if (manager != null)
                {
                    manager.BulkOperationUpdated -= OnBulkOperationListChanged;
                    manager.BulkOperationRemoved -= OnBulkOperationListChanged;
                    manager.BulkOperationAdded -= OnBulkOperationListChanged;
                    manager.BulkOperationsExecuted -= OnBulkOperationExecuted;
                    manager = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBulkProductOrderOperations));
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.checkOverridePriceAsTotalOnAdd = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblClient = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.trbQuantity = new System.Windows.Forms.TrackBar();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblProduct = new System.Windows.Forms.Label();
            this.trbPrice = new System.Windows.Forms.TrackBar();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbSelectRecord = new System.Windows.Forms.ComboBox();
            this.productOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblSelectRecord = new System.Windows.Forms.Label();
            this.txtOperationLogs = new System.Windows.Forms.RichTextBox();
            this.checkSilentOperation = new System.Windows.Forms.CheckBox();
            this.lblOperationResults = new System.Windows.Forms.Label();
            this.cbOperationType = new System.Windows.Forms.ComboBox();
            this.lblOperationType = new System.Windows.Forms.Label();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.btnRemoveOperation = new System.Windows.Forms.Button();
            this.btnApplyChangesToCurrentTarget = new System.Windows.Forms.Button();
            this.btnExecuteOperations = new System.Windows.Forms.Button();
            this.btnApplyChangesToAllTargets = new System.Windows.Forms.Button();
            this.lstBulkOperations = new System.Windows.Forms.ListBox();
            this.bulkProductOrderOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkProductOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkDeliveryServiceOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkPaymentMethodOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkProductBrandOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkUserOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errBulkProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttBulkProductOrderOperations = new System.Windows.Forms.ToolTip(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOrderOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkDeliveryServiceOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkPaymentMethodOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductBrandOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkUserOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBulkProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.txtPrice);
            this.pnlData.Controls.Add(this.txtQuantity);
            this.pnlData.Controls.Add(this.checkOverridePriceAsTotalOnAdd);
            this.pnlData.Controls.Add(this.lblStatus);
            this.pnlData.Controls.Add(this.cbStatus);
            this.pnlData.Controls.Add(this.cbEmployee);
            this.pnlData.Controls.Add(this.lblEmployee);
            this.pnlData.Controls.Add(this.cbClient);
            this.pnlData.Controls.Add(this.lblClient);
            this.pnlData.Controls.Add(this.txtReason);
            this.pnlData.Controls.Add(this.lblReason);
            this.pnlData.Controls.Add(this.trbQuantity);
            this.pnlData.Controls.Add(this.lblQuantity);
            this.pnlData.Controls.Add(this.cbProduct);
            this.pnlData.Controls.Add(this.lblProduct);
            this.pnlData.Controls.Add(this.trbPrice);
            this.pnlData.Controls.Add(this.lblPrice);
            this.pnlData.Controls.Add(this.cbSelectRecord);
            this.pnlData.Controls.Add(this.lblSelectRecord);
            this.pnlData.Controls.Add(this.txtOperationLogs);
            this.pnlData.Controls.Add(this.checkSilentOperation);
            this.pnlData.Controls.Add(this.lblOperationResults);
            this.pnlData.Controls.Add(this.cbOperationType);
            this.pnlData.Controls.Add(this.lblOperationType);
            this.pnlData.Controls.Add(this.btnAddOperation);
            this.pnlData.Controls.Add(this.btnRemoveOperation);
            this.pnlData.Controls.Add(this.btnApplyChangesToCurrentTarget);
            this.pnlData.Controls.Add(this.btnExecuteOperations);
            this.pnlData.Controls.Add(this.btnApplyChangesToAllTargets);
            this.pnlData.Controls.Add(this.lstBulkOperations);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1182, 718);
            this.pnlData.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(1137, 78);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(33, 22);
            this.txtPrice.TabIndex = 76;
            this.ttBulkProductOrderOperations.SetToolTip(this.txtPrice, resources.GetString("txtPrice.ToolTip"));
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Location = new System.Drawing.Point(1137, 25);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(33, 22);
            this.txtQuantity.TabIndex = 75;
            this.ttBulkProductOrderOperations.SetToolTip(this.txtQuantity, GLOBAL_RESOURCES.DESIRED_QUANTITY_EDIT_TOOLTIP_TITLE);
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // checkOverridePriceAsTotalOnAdd
            // 
            this.checkOverridePriceAsTotalOnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkOverridePriceAsTotalOnAdd.AutoSize = true;
            this.checkOverridePriceAsTotalOnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOverridePriceAsTotalOnAdd.Location = new System.Drawing.Point(920, 251);
            this.checkOverridePriceAsTotalOnAdd.Name = "checkOverridePriceAsTotalOnAdd";
            this.checkOverridePriceAsTotalOnAdd.Size = new System.Drawing.Size(250, 20);
            this.checkOverridePriceAsTotalOnAdd.TabIndex = 74;
            this.checkOverridePriceAsTotalOnAdd.Text = "Override Price As Total On Add:";
            this.ttBulkProductOrderOperations.SetToolTip(this.checkOverridePriceAsTotalOnAdd, resources.GetString("checkOverridePriceAsTotalOnAdd.ToolTip"));
            this.checkOverridePriceAsTotalOnAdd.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(19, 171);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(97, 16);
            this.lblStatus.TabIndex = 72;
            this.lblStatus.Text = GLOBAL_RESOURCES.LBL_ORDER_STATUS_TITLE;
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            GLOBAL_RESOURCES.LBL_ORDER_STATUS_PENDING,
            GLOBAL_RESOURCES.LBL_STATUS_PREPAID,
            GLOBAL_RESOURCES.LBL_STATUS_PAID_ON_DELIVERY,
            GLOBAL_RESOURCES.LBL_STATUS_DIRECTLY_PAID,
            GLOBAL_RESOURCES.LBL_STATUS_GENERATING_INVOICE,
            GLOBAL_RESOURCES.LBL_STATUS_GENERATING_REPORT,
            GLOBAL_RESOURCES.LBL_ORDER_STATUS_PROCESSING,
            GLOBAL_RESOURCES.LBL_ORDER_STATUS_CANCELLED,
            GLOBAL_RESOURCES.LBL_ORDER_STATUS_RETURNED,
           GLOBAL_RESOURCES.LBL_ORDER_STATUS_COMPLETED});
            this.cbStatus.Location = new System.Drawing.Point(169, 168);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(226, 24);
            this.cbStatus.TabIndex = 71;
            this.cbStatus.Text = GLOBAL_RESOURCES.LBL_ORDER_STATUS_PENDING;
            this.ttBulkProductOrderOperations.SetToolTip(this.cbStatus, GLOBAL_RESOURCES.ORDER_STATUS_ASSIGN_TOOLTIP_TITLE);
            // 
            // cbEmployee
            // 
            this.cbEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbEmployee.DataSource = this.userBindingSource1;
            this.cbEmployee.DisplayMember = "UserDisplayName";
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(169, 138);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(226, 24);
            this.cbEmployee.TabIndex = 70;
            this.ttBulkProductOrderOperations.SetToolTip(this.cbEmployee,GLOBAL_RESOURCES.EMPLOYEE_ASSIGN_TOOLTIP_TITLE);
            this.cbEmployee.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            // 
            // userBindingSource1
            // 
            this.userBindingSource1.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // lblEmployee
            // 
            this.lblEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(19, 142);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(129, 16);
            this.lblEmployee.TabIndex = 69;
            this.lblEmployee.Text = GLOBAL_RESOURCES.LBL_EMPLOYEE_TITLE;
            // 
            // cbClient
            // 
            this.cbClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbClient.DataSource = this.userBindingSource;
            this.cbClient.DisplayMember = "UserDisplayName";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(169, 106);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(226, 24);
            this.cbClient.TabIndex = 68;
            this.ttBulkProductOrderOperations.SetToolTip(this.cbClient,GLOBAL_RESOURCES.CLIENT_ASSIGN_TOOLTIP_TITLE);
            this.cbClient.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // lblClient
            // 
            this.lblClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(20, 110);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(98, 16);
            this.lblClient.TabIndex = 67;
            this.lblClient.Text = GLOBAL_RESOURCES.LBL_CLIENT_TITLE;
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReason.Location = new System.Drawing.Point(169, 197);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(227, 74);
            this.txtReason.TabIndex = 62;
            this.ttBulkProductOrderOperations.SetToolTip(this.txtReason,GLOBAL_RESOURCES.ORDER_REASON_EDIT_TOOLTIP_TITLE);
            // 
            // lblReason
            // 
            this.lblReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(23, 200);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(108, 16);
            this.lblReason.TabIndex = 61;
            this.lblReason.Text = GLOBAL_RESOURCES.LBL_ORDER_REASON_TITLE;
            // 
            // trbQuantity
            // 
            this.trbQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbQuantity.AutoSize = false;
            this.trbQuantity.Location = new System.Drawing.Point(916, 25);
            this.trbQuantity.Maximum = 5000;
            this.trbQuantity.Name = "trbQuantity";
            this.trbQuantity.Size = new System.Drawing.Size(214, 39);
            this.trbQuantity.TabIndex = 58;
            this.trbQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttBulkProductOrderOperations.SetToolTip(this.trbQuantity, GLOBAL_RESOURCES.DESIRED_QUANTITY_EDIT_TOOLTIP_TITLE);
            this.trbQuantity.Scroll += new System.EventHandler(this.trbQuantity_Scroll);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(783, 24);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(126, 16);
            this.lblQuantity.TabIndex = 56;
            this.lblQuantity.Text = GLOBAL_RESOURCES.LBL_DESIRED_QUANTITY_TITLE;
            // 
            // cbProduct
            // 
            this.cbProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbProduct.DataSource = this.productBindingSource;
            this.cbProduct.DisplayMember = "ProductName";
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(169, 74);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(226, 24);
            this.cbProduct.TabIndex = 55;
            this.ttBulkProductOrderOperations.SetToolTip(this.cbProduct, GLOBAL_RESOURCES.PRODUCT_ASSIGN_TOOLTIP_TITLE);
            this.cbProduct.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.Product);
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(20, 78);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(112, 16);
            this.lblProduct.TabIndex = 54;
            this.lblProduct.Text = GLOBAL_RESOURCES.LBL_PRODUCT_TITLE;
            // 
            // trbPrice
            // 
            this.trbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbPrice.AutoSize = false;
            this.trbPrice.Location = new System.Drawing.Point(916, 77);
            this.trbPrice.Maximum = 5000;
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(214, 49);
            this.trbPrice.TabIndex = 51;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttBulkProductOrderOperations.SetToolTip(this.trbPrice, resources.GetString("trbPrice.ToolTip"));
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(783, 85);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(116, 16);
            this.lblPrice.TabIndex = 49;
            this.lblPrice.Text = "Price Overrride:";
            // 
            // cbSelectRecord
            // 
            this.cbSelectRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSelectRecord.DataSource = this.productOrderBindingSource;
            this.cbSelectRecord.DisplayMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.cbSelectRecord.FormattingEnabled = true;
            this.cbSelectRecord.Location = new System.Drawing.Point(169, 16);
            this.cbSelectRecord.Name = "cbSelectRecord";
            this.cbSelectRecord.Size = new System.Drawing.Size(226, 24);
            this.cbSelectRecord.TabIndex = 48;
            this.ttBulkProductOrderOperations.SetToolTip(this.cbSelectRecord, "The record selection, you can select any existing record from here.");
            this.cbSelectRecord.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.cbSelectRecord.SelectedIndexChanged += new System.EventHandler(this.cbSelectRecord_SelectedIndexChanged);
            // 
            // productOrderBindingSource
            // 
            this.productOrderBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductOrder);
            // 
            // lblSelectRecord
            // 
            this.lblSelectRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectRecord.AutoSize = true;
            this.lblSelectRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectRecord.Location = new System.Drawing.Point(19, 20);
            this.lblSelectRecord.Name = "lblSelectRecord";
            this.lblSelectRecord.Size = new System.Drawing.Size(110, 16);
            this.lblSelectRecord.TabIndex = 47;
            this.lblSelectRecord.Text = "Select Record:";
            // 
            // txtOperationLogs
            // 
            this.txtOperationLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperationLogs.Location = new System.Drawing.Point(22, 490);
            this.txtOperationLogs.Name = "txtOperationLogs";
            this.txtOperationLogs.Size = new System.Drawing.Size(1148, 108);
            this.txtOperationLogs.TabIndex = 46;
            this.txtOperationLogs.Text = "";
            this.ttBulkProductOrderOperations.SetToolTip(this.txtOperationLogs, "It shows the logs of the operations including success messages,error messages and" +
        " overall time started, time ended and execution duration.");
            // 
            // checkSilentOperation
            // 
            this.checkSilentOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSilentOperation.AutoSize = true;
            this.checkSilentOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSilentOperation.Location = new System.Drawing.Point(22, 415);
            this.checkSilentOperation.Name = "checkSilentOperation";
            this.checkSilentOperation.Size = new System.Drawing.Size(140, 20);
            this.checkSilentOperation.TabIndex = 44;
            this.checkSilentOperation.Text = "Silent Operation";
            this.ttBulkProductOrderOperations.SetToolTip(this.checkSilentOperation, "Check whether the operation is silent or will show you error messages if it has f" +
        "ailed");
            this.checkSilentOperation.UseVisualStyleBackColor = true;
            // 
            // lblOperationResults
            // 
            this.lblOperationResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOperationResults.AutoSize = true;
            this.lblOperationResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationResults.Location = new System.Drawing.Point(20, 471);
            this.lblOperationResults.Name = "lblOperationResults";
            this.lblOperationResults.Size = new System.Drawing.Size(139, 16);
            this.lblOperationResults.TabIndex = 43;
            this.lblOperationResults.Text = $"{GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT}";
            this.ttBulkProductOrderOperations.SetToolTip(this.lblOperationResults, "Shows the results with numbers of completed operations, failed operations and exe" +
        "cution time");
            // 
            // cbOperationType
            // 
            this.cbOperationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOperationType.FormattingEnabled = true;
            this.cbOperationType.Items.AddRange(new object[] {
            "DEFAULT(Invalid Operation)",
            "ADD",
            "UPDATE",
            "DELETE",
            "CUSTOM(Only for operations with custom action overrides)"});
            this.cbOperationType.Location = new System.Drawing.Point(937, 447);
            this.cbOperationType.Name = "cbOperationType";
            this.cbOperationType.Size = new System.Drawing.Size(229, 24);
            this.cbOperationType.TabIndex = 42;
            this.cbOperationType.Text = "ADD";
            this.ttBulkProductOrderOperations.SetToolTip(this.cbOperationType, resources.GetString("cbOperationType.ToolTip"));
            // 
            // lblOperationType
            // 
            this.lblOperationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationType.Location = new System.Drawing.Point(794, 451);
            this.lblOperationType.Name = "lblOperationType";
            this.lblOperationType.Size = new System.Drawing.Size(119, 16);
            this.lblOperationType.TabIndex = 41;
            this.lblOperationType.Text = "Operation Type:";
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOperation.Location = new System.Drawing.Point(22, 604);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(280, 47);
            this.btnAddOperation.TabIndex = 40;
            this.btnAddOperation.Text = GLOBAL_RESOURCES.BTN_ADD_OPERATION_TITLE;
            this.ttBulkProductOrderOperations.SetToolTip(this.btnAddOperation, "Add a bulk operation to the list");
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // btnRemoveOperation
            // 
            this.btnRemoveOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRemoveOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOperation.Location = new System.Drawing.Point(308, 604);
            this.btnRemoveOperation.Name = "btnRemoveOperation";
            this.btnRemoveOperation.Size = new System.Drawing.Size(211, 47);
            this.btnRemoveOperation.TabIndex = 39;
            this.btnRemoveOperation.Text = GLOBAL_RESOURCES.BTN_REMOVE_OPERATION_TITLE;
            this.ttBulkProductOrderOperations.SetToolTip(this.btnRemoveOperation, "Remove an existing bulk operation from the list");
            this.btnRemoveOperation.UseVisualStyleBackColor = true;
            this.btnRemoveOperation.Click += new System.EventHandler(this.btnRemoveOperation_Click);
            // 
            // btnApplyChangesToCurrentTarget
            // 
            this.btnApplyChangesToCurrentTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyChangesToCurrentTarget.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToCurrentTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToCurrentTarget.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToCurrentTarget.Location = new System.Drawing.Point(742, 604);
            this.btnApplyChangesToCurrentTarget.Name = "btnApplyChangesToCurrentTarget";
            this.btnApplyChangesToCurrentTarget.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToCurrentTarget.TabIndex = 38;
            this.btnApplyChangesToCurrentTarget.Text = GLOBAL_RESOURCES.BTN_APPLY_CHANGES_TO_CURRENT_TARGET_TITLE;
            this.ttBulkProductOrderOperations.SetToolTip(this.btnApplyChangesToCurrentTarget, "Apply changes to the target record of the selected operation");
            this.btnApplyChangesToCurrentTarget.UseVisualStyleBackColor = true;
            this.btnApplyChangesToCurrentTarget.Click += new System.EventHandler(this.btnApplyChangesToCurrentTarget_Click);
            // 
            // btnExecuteOperations
            // 
            this.btnExecuteOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteOperations.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExecuteOperations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteOperations.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteOperations.Location = new System.Drawing.Point(525, 604);
            this.btnExecuteOperations.Name = "btnExecuteOperations";
            this.btnExecuteOperations.Size = new System.Drawing.Size(211, 47);
            this.btnExecuteOperations.TabIndex = 37;
            this.btnExecuteOperations.Text = GLOBAL_RESOURCES.BTN_EXECUTE_OPERATIONS_TITLE;
            this.ttBulkProductOrderOperations.SetToolTip(this.btnExecuteOperations, "Execute all operations currently in the list");
            this.btnExecuteOperations.UseVisualStyleBackColor = true;
            this.btnExecuteOperations.Click += new System.EventHandler(this.btnExecuteOperations_Click);
            // 
            // btnApplyChangesToAllTargets
            // 
            this.btnApplyChangesToAllTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyChangesToAllTargets.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToAllTargets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToAllTargets.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToAllTargets.Location = new System.Drawing.Point(959, 604);
            this.btnApplyChangesToAllTargets.Name = "btnApplyChangesToAllTargets";
            this.btnApplyChangesToAllTargets.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToAllTargets.TabIndex = 36;
            this.btnApplyChangesToAllTargets.Text = GLOBAL_RESOURCES.BTN_APPLY_CHANGES_TO_ALL_TARGETS_TITLE;
            this.ttBulkProductOrderOperations.SetToolTip(this.btnApplyChangesToAllTargets, "Applies changes to the target records of all operations");
            this.btnApplyChangesToAllTargets.UseVisualStyleBackColor = true;
            this.btnApplyChangesToAllTargets.Click += new System.EventHandler(this.btnApplyChangesToAllTargets_Click);
            // 
            // lstBulkOperations
            // 
            this.lstBulkOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBulkOperations.DataSource = this.bulkProductOrderOperationBindingSource;
            this.lstBulkOperations.DisplayMember = "OperationName";
            this.lstBulkOperations.FormattingEnabled = true;
            this.lstBulkOperations.ItemHeight = 16;
            this.lstBulkOperations.Location = new System.Drawing.Point(22, 277);
            this.lstBulkOperations.Name = "lstBulkOperations";
            this.lstBulkOperations.Size = new System.Drawing.Size(1148, 132);
            this.lstBulkOperations.TabIndex = 35;
            this.ttBulkProductOrderOperations.SetToolTip(this.lstBulkOperations, "the list of bulk operations you have added/edited/removed, it clears when the ope" +
        "rations are executed.You can select any operation from here");
            this.lstBulkOperations.ValueMember = "TargetObject";
            this.lstBulkOperations.SelectedIndexChanged += new System.EventHandler(this.lstBulkOperations_SelectedIndexChanged);
            // 
            // bulkProductOrderOperationBindingSource
            // 
            this.bulkProductOrderOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkProductOrderOperation);
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(169, 44);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(226, 22);
            this.txtID.TabIndex = 2;
            this.ttBulkProductOrderOperations.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_EDIT_TOOLTIP_TITLE);
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(20, 48);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 16);
            this.lblID.TabIndex = 1;
            this.lblID.Text = GLOBAL_RESOURCES.LBL_ID_TITLE;
            // 
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // bulkProductOperationBindingSource
            // 
            this.bulkProductOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkProductOperation);
            // 
            // deliveryServiceBindingSource
            // 
            this.deliveryServiceBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.DeliveryService);
            // 
            // bulkDeliveryServiceOperationBindingSource
            // 
            this.bulkDeliveryServiceOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkDeliveryServiceOperation);
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // bulkPaymentMethodOperationBindingSource
            // 
            this.bulkPaymentMethodOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkPaymentMethodOperation);
            // 
            // bulkProductBrandOperationBindingSource
            // 
            this.bulkProductBrandOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkProductBrandOperation);
            // 
            // bulkUserOperationBindingSource
            // 
            this.bulkUserOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkUserOperation);
            // 
            // errBulkProvider
            // 
            this.errBulkProvider.ContainerControl = this;
            // 
            // ttBulkProductOrderOperations
            // 
            this.ttBulkProductOrderOperations.IsBalloon = true;
            this.ttBulkProductOrderOperations.ShowAlways = true;
            this.ttBulkProductOrderOperations.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttBulkProductOrderOperations.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmBulkProductOrderOperations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 721);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmBulkProductOrderOperations";
            this.Text = "Bulk Product Order Operations";
            this.ttBulkProductOrderOperations.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmBulkProductOrderOperations_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOrderOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkDeliveryServiceOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkPaymentMethodOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductBrandOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkUserOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBulkProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.ListBox lstBulkOperations;
        private System.Windows.Forms.BindingSource bulkUserOperationBindingSource;
        private System.Windows.Forms.Button btnExecuteOperations;
        private System.Windows.Forms.Button btnApplyChangesToAllTargets;
        private System.Windows.Forms.Button btnApplyChangesToCurrentTarget;
        private System.Windows.Forms.ComboBox cbOperationType;
        private System.Windows.Forms.Label lblOperationType;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.Button btnRemoveOperation;
        private System.Windows.Forms.Label lblOperationResults;
        private System.Windows.Forms.CheckBox checkSilentOperation;
        private System.Windows.Forms.ErrorProvider errBulkProvider;
        private System.Windows.Forms.RichTextBox txtOperationLogs;
        private System.Windows.Forms.ComboBox cbSelectRecord;
        private System.Windows.Forms.Label lblSelectRecord;
        private System.Windows.Forms.BindingSource productBrandBindingSource;
        private System.Windows.Forms.BindingSource bulkProductBrandOperationBindingSource;
        private System.Windows.Forms.BindingSource paymentMethodBindingSource;
        private System.Windows.Forms.BindingSource bulkPaymentMethodOperationBindingSource;
        private System.Windows.Forms.BindingSource bulkDeliveryServiceOperationBindingSource;
        private System.Windows.Forms.BindingSource deliveryServiceBindingSource;
        private System.Windows.Forms.TrackBar trbPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.BindingSource bulkProductOperationBindingSource;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TrackBar trbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.BindingSource productOrderBindingSource;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.BindingSource bulkProductOrderOperationBindingSource;
        private System.Windows.Forms.CheckBox checkOverridePriceAsTotalOnAdd;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ToolTip ttBulkProductOrderOperations;
    }
}