﻿namespace XtremePharmacyManager
{
    partial class frmBulkDeliveryServiceOperations
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
                if (selected_target != null)
                {
                    selected_target = null;
                }
                if(entries != null)
                {
                    entries.Clear();
                    entries = null;
                }
                if (manager_entities != null)
                {
                    manager_entities = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBulkDeliveryServiceOperations));
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.trbPrice = new System.Windows.Forms.TrackBar();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbSelectRecord = new System.Windows.Forms.ComboBox();
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.bulkDeliveryServiceOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkPaymentMethodOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkProductBrandOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bulkUserOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errBulkProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttBulkDeliveryServiceOperations = new System.Windows.Forms.ToolTip(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkDeliveryServiceOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkPaymentMethodOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductBrandOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkUserOperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBulkProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.txtPrice);
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
            this.pnlData.Controls.Add(this.txtServiceName);
            this.pnlData.Controls.Add(this.lblServiceName);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1182, 709);
            this.pnlData.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(1137, 21);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(34, 22);
            this.txtPrice.TabIndex = 52;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.txtPrice, GLOBAL_RESOURCES.DELIVERY_PRICE_EDIT_TOOLTIP_TITLE);
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // trbPrice
            // 
            this.trbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbPrice.AutoSize = false;
            this.trbPrice.Location = new System.Drawing.Point(872, 16);
            this.trbPrice.Maximum = 5000;
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(259, 36);
            this.trbPrice.TabIndex = 51;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.trbPrice, GLOBAL_RESOURCES.DELIVERY_PRICE_EDIT_TOOLTIP_TITLE);
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(794, 20);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(47, 16);
            this.lblPrice.TabIndex = 49;
            this.lblPrice.Text = GLOBAL_RESOURCES.LBL_PRICE_TITLE;
            // 
            // cbSelectRecord
            // 
            this.cbSelectRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSelectRecord.DataSource = this.deliveryServiceBindingSource;
            this.cbSelectRecord.DisplayMember = "ServiceName";
            this.cbSelectRecord.FormattingEnabled = true;
            this.cbSelectRecord.Location = new System.Drawing.Point(137, 16);
            this.cbSelectRecord.Name = "cbSelectRecord";
            this.cbSelectRecord.Size = new System.Drawing.Size(254, 24);
            this.cbSelectRecord.TabIndex = 48;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.cbSelectRecord, GLOBAL_RESOURCES.SELECT_RECORD_TOOLTIP_TITLE);
            this.cbSelectRecord.ValueMember = "ID";
            this.cbSelectRecord.SelectedIndexChanged += new System.EventHandler(this.cbSelectRecord_SelectedIndexChanged);
            // 
            // deliveryServiceBindingSource
            // 
            this.deliveryServiceBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.DeliveryService);
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
            this.lblSelectRecord.Text = GLOBAL_RESOURCES.LBL_SELECT_RECORD_TITLE;
            // 
            // txtOperationLogs
            // 
            this.txtOperationLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperationLogs.Location = new System.Drawing.Point(22, 300);
            this.txtOperationLogs.Name = "txtOperationLogs";
            this.txtOperationLogs.Size = new System.Drawing.Size(1148, 241);
            this.txtOperationLogs.TabIndex = 46;
            this.txtOperationLogs.Text = "";
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.txtOperationLogs, GLOBAL_RESOURCES.OPERATION_LOGS_TOOLTIP_TITLE);
            // 
            // checkSilentOperation
            // 
            this.checkSilentOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSilentOperation.AutoSize = true;
            this.checkSilentOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSilentOperation.Location = new System.Drawing.Point(23, 216);
            this.checkSilentOperation.Name = "checkSilentOperation";
            this.checkSilentOperation.Size = new System.Drawing.Size(140, 20);
            this.checkSilentOperation.TabIndex = 44;
            this.checkSilentOperation.Text = GLOBAL_RESOURCES.CHK_SILENT_OPERATION_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.checkSilentOperation, GLOBAL_RESOURCES.SILENT_OPERATION_TOOLTIP_TITLE);
            this.checkSilentOperation.UseVisualStyleBackColor = true;
            // 
            // lblOperationResults
            // 
            this.lblOperationResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOperationResults.AutoSize = true;
            this.lblOperationResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationResults.Location = new System.Drawing.Point(20, 277);
            this.lblOperationResults.Name = "lblOperationResults";
            this.lblOperationResults.Size = new System.Drawing.Size(139, 16);
            this.lblOperationResults.TabIndex = 43;
            this.lblOperationResults.Text = GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.lblOperationResults, GLOBAL_RESOURCES.OPERATION_RESULTS_TOOLTIP_TITLE);
            // 
            // cbOperationType
            // 
            this.cbOperationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOperationType.FormattingEnabled = true;
            this.cbOperationType.Items.AddRange(new object[] {
            GLOBAL_RESOURCES.LBL_OPERATION_TYPE_DEFAULT,
            GLOBAL_RESOURCES.LBL_OPERATION_TYPE_ADD,
            GLOBAL_RESOURCES.LBL_OPERATION_TYPE_UPDATE,
            GLOBAL_RESOURCES.LBL_OPERATION_TYPE_DELETE,
            GLOBAL_RESOURCES.LBL_OPERATION_TYPE_CUSTOM});
            this.cbOperationType.Location = new System.Drawing.Point(937, 270);
            this.cbOperationType.Name = "cbOperationType";
            this.cbOperationType.Size = new System.Drawing.Size(229, 24);
            this.cbOperationType.TabIndex = 42;
            this.cbOperationType.Text = GLOBAL_RESOURCES.LBL_OPERATION_TYPE_ADD;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.cbOperationType, GLOBAL_RESOURCES.OPERATION_TYPE_TOOLTIP_TITLE);
            // 
            // lblOperationType
            // 
            this.lblOperationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationType.Location = new System.Drawing.Point(794, 274);
            this.lblOperationType.Name = "lblOperationType";
            this.lblOperationType.Size = new System.Drawing.Size(119, 16);
            this.lblOperationType.TabIndex = 41;
            this.lblOperationType.Text = GLOBAL_RESOURCES.LBL_OPERATION_TYPE_TITLE;
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOperation.Location = new System.Drawing.Point(23, 547);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(280, 47);
            this.btnAddOperation.TabIndex = 40;
            this.btnAddOperation.Text = GLOBAL_RESOURCES.BTN_ADD_OPERATION_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.btnAddOperation, GLOBAL_RESOURCES.BTN_ADD_OPERATION_TOOLTIP_TITLE);
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // btnRemoveOperation
            // 
            this.btnRemoveOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRemoveOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOperation.Location = new System.Drawing.Point(309, 547);
            this.btnRemoveOperation.Name = "btnRemoveOperation";
            this.btnRemoveOperation.Size = new System.Drawing.Size(211, 47);
            this.btnRemoveOperation.TabIndex = 39;
            this.btnRemoveOperation.Text = GLOBAL_RESOURCES.BTN_REMOVE_OPERATION_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.btnRemoveOperation, GLOBAL_RESOURCES.BTN_REMOVE_OPERATION_TOOLTIP_TITLE);
            this.btnRemoveOperation.UseVisualStyleBackColor = true;
            this.btnRemoveOperation.Click += new System.EventHandler(this.btnRemoveOperation_Click);
            // 
            // btnApplyChangesToCurrentTarget
            // 
            this.btnApplyChangesToCurrentTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyChangesToCurrentTarget.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToCurrentTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToCurrentTarget.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToCurrentTarget.Location = new System.Drawing.Point(743, 547);
            this.btnApplyChangesToCurrentTarget.Name = "btnApplyChangesToCurrentTarget";
            this.btnApplyChangesToCurrentTarget.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToCurrentTarget.TabIndex = 38;
            this.btnApplyChangesToCurrentTarget.Text = GLOBAL_RESOURCES.BTN_APPLY_CHANGES_TO_CURRENT_TARGET_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.btnApplyChangesToCurrentTarget, GLOBAL_RESOURCES.BTN_APPLY_CHANGES_TO_CURRENT_TARGET_TOOLTIP_TITLE);
            this.btnApplyChangesToCurrentTarget.UseVisualStyleBackColor = true;
            this.btnApplyChangesToCurrentTarget.Click += new System.EventHandler(this.btnApplyChangesToCurrentTarget_Click);
            // 
            // btnExecuteOperations
            // 
            this.btnExecuteOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteOperations.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExecuteOperations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteOperations.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteOperations.Location = new System.Drawing.Point(526, 547);
            this.btnExecuteOperations.Name = "btnExecuteOperations";
            this.btnExecuteOperations.Size = new System.Drawing.Size(211, 47);
            this.btnExecuteOperations.TabIndex = 37;
            this.btnExecuteOperations.Text = GLOBAL_RESOURCES.BTN_EXECUTE_OPERATIONS_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.btnExecuteOperations, GLOBAL_RESOURCES.BTN_EXECUTE_OPERATIONS_TOOLTIP_TITLE);
            this.btnExecuteOperations.UseVisualStyleBackColor = true;
            this.btnExecuteOperations.Click += new System.EventHandler(this.btnExecuteOperations_Click);
            // 
            // btnApplyChangesToAllTargets
            // 
            this.btnApplyChangesToAllTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyChangesToAllTargets.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToAllTargets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToAllTargets.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToAllTargets.Location = new System.Drawing.Point(960, 547);
            this.btnApplyChangesToAllTargets.Name = "btnApplyChangesToAllTargets";
            this.btnApplyChangesToAllTargets.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToAllTargets.TabIndex = 36;
            this.btnApplyChangesToAllTargets.Text = GLOBAL_RESOURCES.BTN_APPLY_CHANGES_TO_ALL_TARGETS_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.btnApplyChangesToAllTargets, GLOBAL_RESOURCES.BTN_APPLY_CHANGES_TO_ALL_TARGETS_TOOLTIP_TITLE);
            this.btnApplyChangesToAllTargets.UseVisualStyleBackColor = true;
            this.btnApplyChangesToAllTargets.Click += new System.EventHandler(this.btnApplyChangesToAllTargets_Click);
            // 
            // lstBulkOperations
            // 
            this.lstBulkOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBulkOperations.DataSource = this.bulkDeliveryServiceOperationBindingSource;
            this.lstBulkOperations.DisplayMember = "OperationName";
            this.lstBulkOperations.FormattingEnabled = true;
            this.lstBulkOperations.ItemHeight = 16;
            this.lstBulkOperations.Location = new System.Drawing.Point(22, 110);
            this.lstBulkOperations.Name = "lstBulkOperations";
            this.lstBulkOperations.Size = new System.Drawing.Size(1148, 100);
            this.lstBulkOperations.TabIndex = 35;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.lstBulkOperations, GLOBAL_RESOURCES.LST_BULK_OPERATIONS_TOOLTIP_TITLE);
            this.lstBulkOperations.ValueMember = "TargetObject";
            this.lstBulkOperations.SelectedIndexChanged += new System.EventHandler(this.lstBulkOperations_SelectedIndexChanged);
            // 
            // bulkDeliveryServiceOperationBindingSource
            // 
            this.bulkDeliveryServiceOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkDeliveryServiceOperation);
            // 
            // txtServiceName
            // 
            this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtServiceName.Location = new System.Drawing.Point(136, 72);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(258, 22);
            this.txtServiceName.TabIndex = 4;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.txtServiceName, GLOBAL_RESOURCES.SERVICE_NAME_EDIT_TOOLTIP_TITLE);
            // 
            // lblServiceName
            // 
            this.lblServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.Location = new System.Drawing.Point(19, 75);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(109, 16);
            this.lblServiceName.TabIndex = 3;
            this.lblServiceName.Text = GLOBAL_RESOURCES.LBL_SERVICE_NAME_TITLE;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(136, 44);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(258, 22);
            this.txtID.TabIndex = 2;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_EDIT_TOOLTIP_TITLE);
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
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.PaymentMethod);
            // 
            // bulkPaymentMethodOperationBindingSource
            // 
            this.bulkPaymentMethodOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkPaymentMethodOperation);
            // 
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // bulkProductBrandOperationBindingSource
            // 
            this.bulkProductBrandOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkProductBrandOperation);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // bulkUserOperationBindingSource
            // 
            this.bulkUserOperationBindingSource.DataSource = typeof(XtremePharmacyManager.BulkUserOperation);
            // 
            // errBulkProvider
            // 
            this.errBulkProvider.ContainerControl = this;
            // 
            // ttBulkDeliveryServiceOperations
            // 
            this.ttBulkDeliveryServiceOperations.IsBalloon = true;
            this.ttBulkDeliveryServiceOperations.ShowAlways = true;
            this.ttBulkDeliveryServiceOperations.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttBulkDeliveryServiceOperations.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmBulkDeliveryServiceOperations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 721);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmBulkDeliveryServiceOperations";
            this.Text = GLOBAL_RESOURCES.BULK_DELIVERY_SERVICE_OPERATIONS_TITLE;
            this.ttBulkDeliveryServiceOperations.SetToolTip(this, GLOBAL_RESOURCES.BULK_DELIVERY_SERVICE_OPERATIONS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmBulkDeliveryServiceOperations_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkDeliveryServiceOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkPaymentMethodOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkProductBrandOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bulkUserOperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBulkProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lblServiceName;
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
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ToolTip ttBulkDeliveryServiceOperations;
    }
}