namespace XtremePharmacyManager
{
    partial class frmBulkOrderDeliveryOperations
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
                if(current_user != null)
                {
                    current_user = null;
                }
                if(selected_operation != null)
                {
                    selected_operation = null;
                }
                if(selected_target != null)
                {
                    selected_target = null;
                }
                if(service_entries != null)
                {
                    service_entries.Clear();
                    service_entries = null;
                }
                if(method_entries != null)
                {
                    method_entries.Clear();
                    method_entries = null;
                }
                if(order_entries != null)
                {
                    order_entries.Clear();
                    order_entries = null;
                }
                if(entries != null)
                {
                    entries.Clear();
                    entries = null;
                }
                if(manager_entities != null)
                {
                    manager_entities = null;
                }
                if(manager != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBulkOrderDeliveryOperations));
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtCargoID = new System.Windows.Forms.TextBox();
            this.lblCargoID = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cbDeliveryService = new System.Windows.Forms.ComboBox();
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDeliveryService = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cbOrder = new System.Windows.Forms.ComboBox();
            this.productOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblOrder = new System.Windows.Forms.Label();
            this.trbPrice = new System.Windows.Forms.TrackBar();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbSelectRecord = new System.Windows.Forms.ComboBox();
            this.orderDeliveryBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkProductOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkDeliveryServiceOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkPaymentMethodOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkProductBrandOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkUserOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errBulkProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttBulkOrderDeliveryOperations = new System.Windows.Forms.ToolTip(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDeliveryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOrderOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkDeliveryServiceOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkPaymentMethodOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductBrandOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkUserOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBulkProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.txtPrice);
            this.pnlData.Controls.Add(this.txtCargoID);
            this.pnlData.Controls.Add(this.lblCargoID);
            this.pnlData.Controls.Add(this.cbStatus);
            this.pnlData.Controls.Add(this.lblStatus);
            this.pnlData.Controls.Add(this.cbPaymentMethod);
            this.pnlData.Controls.Add(this.lblPaymentMethod);
            this.pnlData.Controls.Add(this.cbDeliveryService);
            this.pnlData.Controls.Add(this.lblDeliveryService);
            this.pnlData.Controls.Add(this.txtReason);
            this.pnlData.Controls.Add(this.lblReason);
            this.pnlData.Controls.Add(this.cbOrder);
            this.pnlData.Controls.Add(this.lblOrder);
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
            this.txtPrice.Location = new System.Drawing.Point(1137, 24);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(33, 22);
            this.txtPrice.TabIndex = 76;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.txtPrice, resources.GetString("txtPrice.ToolTip"));
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtCargoID
            // 
            this.txtCargoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCargoID.Location = new System.Drawing.Point(195, 165);
            this.txtCargoID.Name = "txtCargoID";
            this.txtCargoID.Size = new System.Drawing.Size(240, 22);
            this.txtCargoID.TabIndex = 75;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.txtCargoID, resources.GetString("txtCargoID.ToolTip"));
            // 
            // lblCargoID
            // 
            this.lblCargoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCargoID.AutoSize = true;
            this.lblCargoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoID.Location = new System.Drawing.Point(20, 169);
            this.lblCargoID.Name = "lblCargoID";
            this.lblCargoID.Size = new System.Drawing.Size(72, 16);
            this.lblCargoID.TabIndex = 74;
            this.lblCargoID.Text = "Cargo ID:";
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
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
            this.cbStatus.Location = new System.Drawing.Point(192, 191);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(243, 24);
            this.cbStatus.TabIndex = 73;
            this.cbStatus.Text = "pending delivery";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.cbStatus, "The delivery status. based on it the status of the product order changes and the " +
        "balances of the registered employees and clients is calculated so be REALLY care" +
        "ful with that");
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(19, 193);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(116, 16);
            this.lblStatus.TabIndex = 72;
            this.lblStatus.Text = "Delivery Status:";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPaymentMethod.DataSource = this.paymentMethodBindingSource;
            this.cbPaymentMethod.DisplayMember = "MethodName";
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(195, 138);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(240, 24);
            this.cbPaymentMethod.TabIndex = 70;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.cbPaymentMethod, "Select any existing payment method record to assign the order delivery to");
            this.cbPaymentMethod.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(19, 142);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(174, 16);
            this.lblPaymentMethod.TabIndex = 69;
            this.lblPaymentMethod.Text = "Select Payment Method:";
            // 
            // cbDeliveryService
            // 
            this.cbDeliveryService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDeliveryService.DataSource = this.deliveryServiceBindingSource;
            this.cbDeliveryService.DisplayMember = "ServiceName";
            this.cbDeliveryService.FormattingEnabled = true;
            this.cbDeliveryService.Location = new System.Drawing.Point(195, 106);
            this.cbDeliveryService.Name = "cbDeliveryService";
            this.cbDeliveryService.Size = new System.Drawing.Size(240, 24);
            this.cbDeliveryService.TabIndex = 68;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.cbDeliveryService, "Select any existing delivery service record you want the delivery assigned to");
            this.cbDeliveryService.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            // 
            // deliveryServiceBindingSource
            // 
            this.deliveryServiceBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.DeliveryService);
            // 
            // lblDeliveryService
            // 
            this.lblDeliveryService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeliveryService.AutoSize = true;
            this.lblDeliveryService.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryService.Location = new System.Drawing.Point(20, 110);
            this.lblDeliveryService.Name = "lblDeliveryService";
            this.lblDeliveryService.Size = new System.Drawing.Size(174, 16);
            this.lblDeliveryService.TabIndex = 67;
            this.lblDeliveryService.Text = "Select Delivery Service:";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReason.Location = new System.Drawing.Point(192, 220);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(241, 51);
            this.txtReason.TabIndex = 62;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.txtReason, "Type the reason you edited the delivery. Sometimes the database puts its own reas" +
        "on for change to indicate a change of status and inform you tho");
            // 
            // lblReason
            // 
            this.lblReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(20, 223);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(127, 16);
            this.lblReason.TabIndex = 61;
            this.lblReason.Text = "Delivery Reason:";
            // 
            // cbOrder
            // 
            this.cbOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOrder.DataSource = this.productOrderBindingSource;
            this.cbOrder.DisplayMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.cbOrder.FormattingEnabled = true;
            this.cbOrder.Location = new System.Drawing.Point(195, 74);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(240, 24);
            this.cbOrder.TabIndex = 55;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.cbOrder, "Select any existing order record you want to assign the order delivery to");
            this.cbOrder.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            // 
            // productOrderBindingSource
            // 
            this.productOrderBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductOrder);
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(20, 78);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(98, 16);
            this.lblOrder.TabIndex = 54;
            this.lblOrder.Text = "Select Order:";
            // 
            // trbPrice
            // 
            this.trbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbPrice.AutoSize = false;
            this.trbPrice.Location = new System.Drawing.Point(916, 24);
            this.trbPrice.Maximum = 5000;
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(214, 48);
            this.trbPrice.TabIndex = 51;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.trbPrice, resources.GetString("trbPrice.ToolTip"));
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(823, 24);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(87, 16);
            this.lblPrice.TabIndex = 49;
            this.lblPrice.Text = "Total Price:";
            // 
            // cbSelectRecord
            // 
            this.cbSelectRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSelectRecord.DataSource = this.orderDeliveryBindingSource;
            this.cbSelectRecord.DisplayMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.cbSelectRecord.FormattingEnabled = true;
            this.cbSelectRecord.Location = new System.Drawing.Point(195, 16);
            this.cbSelectRecord.Name = "cbSelectRecord";
            this.cbSelectRecord.Size = new System.Drawing.Size(240, 24);
            this.cbSelectRecord.TabIndex = 48;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.cbSelectRecord, "The record selection, you can select any existing record from here.");
            this.cbSelectRecord.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.cbSelectRecord.SelectedIndexChanged += new System.EventHandler(this.cbSelectRecord_SelectedIndexChanged);
            // 
            // orderDeliveryBindingSource
            // 
            this.orderDeliveryBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.OrderDelivery);
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
            this.txtOperationLogs.Location = new System.Drawing.Point(22, 465);
            this.txtOperationLogs.Name = "txtOperationLogs";
            this.txtOperationLogs.Size = new System.Drawing.Size(1148, 117);
            this.txtOperationLogs.TabIndex = 46;
            this.txtOperationLogs.Text = "";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.txtOperationLogs, "It shows the logs of the operations including success messages,error messages and" +
        " overall time started, time ended and execution duration.");
            // 
            // checkSilentOperation
            // 
            this.checkSilentOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSilentOperation.AutoSize = true;
            this.checkSilentOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSilentOperation.Location = new System.Drawing.Point(22, 383);
            this.checkSilentOperation.Name = "checkSilentOperation";
            this.checkSilentOperation.Size = new System.Drawing.Size(140, 20);
            this.checkSilentOperation.TabIndex = 44;
            this.checkSilentOperation.Text = "Silent Operation";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.checkSilentOperation, "Check whether the operation is silent or will show you error messages if it has f" +
        "ailed");
            this.checkSilentOperation.UseVisualStyleBackColor = true;
            // 
            // lblOperationResults
            // 
            this.lblOperationResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOperationResults.AutoSize = true;
            this.lblOperationResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationResults.Location = new System.Drawing.Point(20, 446);
            this.lblOperationResults.Name = "lblOperationResults";
            this.lblOperationResults.Size = new System.Drawing.Size(139, 16);
            this.lblOperationResults.TabIndex = 43;
            this.lblOperationResults.Text = $"{GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT}";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.lblOperationResults, "Shows the results with numbers of completed operations, failed operations and exe" +
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
            this.cbOperationType.Location = new System.Drawing.Point(937, 435);
            this.cbOperationType.Name = "cbOperationType";
            this.cbOperationType.Size = new System.Drawing.Size(229, 24);
            this.cbOperationType.TabIndex = 42;
            this.cbOperationType.Text = "ADD";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.cbOperationType, resources.GetString("cbOperationType.ToolTip"));
            // 
            // lblOperationType
            // 
            this.lblOperationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationType.Location = new System.Drawing.Point(794, 439);
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
            this.btnAddOperation.Location = new System.Drawing.Point(23, 588);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(279, 47);
            this.btnAddOperation.TabIndex = 40;
            this.btnAddOperation.Text = "ADD OPERATION";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.btnAddOperation, "Add a bulk operation to the list");
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // btnRemoveOperation
            // 
            this.btnRemoveOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRemoveOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOperation.Location = new System.Drawing.Point(308, 588);
            this.btnRemoveOperation.Name = "btnRemoveOperation";
            this.btnRemoveOperation.Size = new System.Drawing.Size(211, 47);
            this.btnRemoveOperation.TabIndex = 39;
            this.btnRemoveOperation.Text = "REMOVE OPERATION";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.btnRemoveOperation, "Remove an existing bulk operation from the list");
            this.btnRemoveOperation.UseVisualStyleBackColor = true;
            this.btnRemoveOperation.Click += new System.EventHandler(this.btnRemoveOperation_Click);
            // 
            // btnApplyChangesToCurrentTarget
            // 
            this.btnApplyChangesToCurrentTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyChangesToCurrentTarget.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToCurrentTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToCurrentTarget.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToCurrentTarget.Location = new System.Drawing.Point(742, 588);
            this.btnApplyChangesToCurrentTarget.Name = "btnApplyChangesToCurrentTarget";
            this.btnApplyChangesToCurrentTarget.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToCurrentTarget.TabIndex = 38;
            this.btnApplyChangesToCurrentTarget.Text = "APPLY CHANGES TO THIS TARGET";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.btnApplyChangesToCurrentTarget, "Apply changes to the target record of the selected operation");
            this.btnApplyChangesToCurrentTarget.UseVisualStyleBackColor = true;
            this.btnApplyChangesToCurrentTarget.Click += new System.EventHandler(this.btnApplyChangesToCurrentTarget_Click);
            // 
            // btnExecuteOperations
            // 
            this.btnExecuteOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteOperations.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExecuteOperations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteOperations.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteOperations.Location = new System.Drawing.Point(525, 588);
            this.btnExecuteOperations.Name = "btnExecuteOperations";
            this.btnExecuteOperations.Size = new System.Drawing.Size(211, 47);
            this.btnExecuteOperations.TabIndex = 37;
            this.btnExecuteOperations.Text = "EXECUTE OPERATIONS";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.btnExecuteOperations, "Execute all operations currently in the list");
            this.btnExecuteOperations.UseVisualStyleBackColor = true;
            this.btnExecuteOperations.Click += new System.EventHandler(this.btnExecuteOperations_Click);
            // 
            // btnApplyChangesToAllTargets
            // 
            this.btnApplyChangesToAllTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyChangesToAllTargets.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToAllTargets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToAllTargets.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToAllTargets.Location = new System.Drawing.Point(959, 588);
            this.btnApplyChangesToAllTargets.Name = "btnApplyChangesToAllTargets";
            this.btnApplyChangesToAllTargets.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToAllTargets.TabIndex = 36;
            this.btnApplyChangesToAllTargets.Text = "APPLY CHANGES TO ALL TARGETS";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.btnApplyChangesToAllTargets, "Applies changes to the target records of all operations");
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
            this.lstBulkOperations.Size = new System.Drawing.Size(1148, 100);
            this.lstBulkOperations.TabIndex = 35;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.lstBulkOperations, "the list of bulk operations you have added/edited/removed, it clears when the ope" +
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
            this.txtID.Location = new System.Drawing.Point(195, 44);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(240, 22);
            this.txtID.TabIndex = 2;
            this.ttBulkOrderDeliveryOperations.SetToolTip(this.txtID, "Here is the ID of the selected record. By default IDs in the database cannot be c" +
        "hanged so even if you add and ID or change it the database will still set its ow" +
        "n ID to the record");
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
            // userBindingSource1
            // 
            this.userBindingSource1.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.Product);
            // 
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // bulkProductOperationBindingSource
            // 
            this.bulkProductOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkProductOperation);
            // 
            // bulkDeliveryServiceOperationBindingSource
            // 
            this.bulkDeliveryServiceOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkDeliveryServiceOperation);
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
            // ttBulkOrderDeliveryOperations
            // 
            this.ttBulkOrderDeliveryOperations.IsBalloon = true;
            this.ttBulkOrderDeliveryOperations.ShowAlways = true;
            this.ttBulkOrderDeliveryOperations.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttBulkOrderDeliveryOperations.ToolTipTitle = GLOBAL_RESOURCES.HELP_TOOLTIP_TITLE;
            // 
            // frmBulkOrderDeliveryOperations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 721);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmBulkOrderDeliveryOperations";
            this.Text = "Bulk Order Delivery Operations";
            this.ttBulkOrderDeliveryOperations.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmBulkOrderDeliveryOperations_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDeliveryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOrderOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkDeliveryServiceOperationBindingSource)).EndInit();
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
        private System.Windows.Forms.ComboBox cbOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.BindingSource productOrderBindingSource;
        private System.Windows.Forms.ComboBox cbDeliveryService;
        private System.Windows.Forms.Label lblDeliveryService;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.BindingSource bulkProductOrderOperationBindingSource;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.BindingSource orderDeliveryBindingSource;
        private System.Windows.Forms.TextBox txtCargoID;
        private System.Windows.Forms.Label lblCargoID;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ToolTip ttBulkOrderDeliveryOperations;
    }
}