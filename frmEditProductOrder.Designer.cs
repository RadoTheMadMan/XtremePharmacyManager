﻿namespace XtremePharmacyManager
{
    partial class frmEditProductOrder
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
                if(target != null)
                {
                    target = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProductOrder));
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtPriceOverride = new System.Windows.Forms.TextBox();
            this.txtDesiredQuantity = new System.Windows.Forms.TextBox();
            this.txtOrderReason = new System.Windows.Forms.TextBox();
            this.lblOrderReason = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.cbSelectOrderStatus = new System.Windows.Forms.ComboBox();
            this.cbSelectEmployee = new System.Windows.Forms.ComboBox();
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbSelectClient = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblClient = new System.Windows.Forms.Label();
            this.trbDesiredQuantity = new System.Windows.Forms.TrackBar();
            this.lblDesiredQuantity = new System.Windows.Forms.Label();
            this.cbSelectProduct = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.trbPriceOverride = new System.Windows.Forms.TrackBar();
            this.lblPriceOverride = new System.Windows.Forms.Label();
            this.lblSelectProduct = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttEditProductOrder = new System.Windows.Forms.ToolTip(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDesiredQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPriceOverride)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.Controls.Add(this.txtPriceOverride);
            this.pnlData.Controls.Add(this.txtDesiredQuantity);
            this.pnlData.Controls.Add(this.txtOrderReason);
            this.pnlData.Controls.Add(this.lblOrderReason);
            this.pnlData.Controls.Add(this.lblOrderStatus);
            this.pnlData.Controls.Add(this.cbSelectOrderStatus);
            this.pnlData.Controls.Add(this.cbSelectEmployee);
            this.pnlData.Controls.Add(this.lblEmployee);
            this.pnlData.Controls.Add(this.cbSelectClient);
            this.pnlData.Controls.Add(this.lblClient);
            this.pnlData.Controls.Add(this.trbDesiredQuantity);
            this.pnlData.Controls.Add(this.lblDesiredQuantity);
            this.pnlData.Controls.Add(this.cbSelectProduct);
            this.pnlData.Controls.Add(this.btnOK);
            this.pnlData.Controls.Add(this.btnCancel);
            this.pnlData.Controls.Add(this.trbPriceOverride);
            this.pnlData.Controls.Add(this.lblPriceOverride);
            this.pnlData.Controls.Add(this.lblSelectProduct);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(800, 301);
            this.pnlData.TabIndex = 0;
            // 
            // txtPriceOverride
            // 
            this.txtPriceOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriceOverride.Location = new System.Drawing.Point(738, 90);
            this.txtPriceOverride.Name = "txtPriceOverride";
            this.txtPriceOverride.Size = new System.Drawing.Size(50, 22);
            this.txtPriceOverride.TabIndex = 56;
            this.ttEditProductOrder.SetToolTip(this.txtPriceOverride, GLOBAL_RESOURCES.PRICE_OVERRIDE_EDIT_TOOLTIP_TITLE);
            this.txtPriceOverride.TextChanged += new System.EventHandler(this.txtPriceOverride_TextChanged);
            // 
            // txtDesiredQuantity
            // 
            this.txtDesiredQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesiredQuantity.Location = new System.Drawing.Point(738, 27);
            this.txtDesiredQuantity.Name = "txtDesiredQuantity";
            this.txtDesiredQuantity.Size = new System.Drawing.Size(50, 22);
            this.txtDesiredQuantity.TabIndex = 55;
            this.ttEditProductOrder.SetToolTip(this.txtDesiredQuantity, GLOBAL_RESOURCES.DESIRED_QUANTITY_EDIT_TOOLTIP_TITLE);
            this.txtDesiredQuantity.TextChanged += new System.EventHandler(this.txtDesiredQuantity_TextChanged);
            // 
            // txtOrderReason
            // 
            this.txtOrderReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderReason.Location = new System.Drawing.Point(532, 144);
            this.txtOrderReason.Multiline = true;
            this.txtOrderReason.Name = "txtOrderReason";
            this.txtOrderReason.Size = new System.Drawing.Size(230, 77);
            this.txtOrderReason.TabIndex = 54;
            this.ttEditProductOrder.SetToolTip(this.txtOrderReason,GLOBAL_RESOURCES.ORDER_REASON_EDIT_TOOLTIP_TITLE);
            // 
            // lblOrderReason
            // 
            this.lblOrderReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderReason.AutoSize = true;
            this.lblOrderReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderReason.Location = new System.Drawing.Point(401, 147);
            this.lblOrderReason.Name = "lblOrderReason";
            this.lblOrderReason.Size = new System.Drawing.Size(108, 16);
            this.lblOrderReason.TabIndex = 53;
            this.lblOrderReason.Text = GLOBAL_RESOURCES.LBL_ORDER_REASON_TITLE;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.Location = new System.Drawing.Point(20, 150);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(97, 16);
            this.lblOrderStatus.TabIndex = 52;
            this.lblOrderStatus.Text = GLOBAL_RESOURCES.LBL_ORDER_STATUS_TITLE;
            // 
            // cbSelectOrderStatus
            // 
            this.cbSelectOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSelectOrderStatus.FormattingEnabled = true;
            this.cbSelectOrderStatus.Items.AddRange(new object[] {
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
            this.cbSelectOrderStatus.Location = new System.Drawing.Point(176, 147);
            this.cbSelectOrderStatus.Name = "cbSelectOrderStatus";
            this.cbSelectOrderStatus.Size = new System.Drawing.Size(219, 24);
            this.cbSelectOrderStatus.TabIndex = 51;
            this.cbSelectOrderStatus.Text = GLOBAL_RESOURCES.LBL_ORDER_STATUS_PENDING;
            this.ttEditProductOrder.SetToolTip(this.cbSelectOrderStatus, GLOBAL_RESOURCES.ORDER_STATUS_ASSIGN_TOOLTIP_TITLE);
            // 
            // cbSelectEmployee
            // 
            this.cbSelectEmployee.DataSource = this.userBindingSource1;
            this.cbSelectEmployee.DisplayMember = "UserDisplayName";
            this.cbSelectEmployee.FormattingEnabled = true;
            this.cbSelectEmployee.Location = new System.Drawing.Point(176, 110);
            this.cbSelectEmployee.Name = "cbSelectEmployee";
            this.cbSelectEmployee.Size = new System.Drawing.Size(219, 24);
            this.cbSelectEmployee.TabIndex = 48;
            this.ttEditProductOrder.SetToolTip(this.cbSelectEmployee,GLOBAL_RESOURCES.EMPLOYEE_ASSIGN_TOOLTIP_TITLE);
            this.cbSelectEmployee.ValueMember = "ID";
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
            this.lblEmployee.Location = new System.Drawing.Point(20, 113);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(129, 16);
            this.lblEmployee.TabIndex = 47;
            this.lblEmployee.Text = GLOBAL_RESOURCES.LBL_EMPLOYEE_TITLE;
            // 
            // cbSelectClient
            // 
            this.cbSelectClient.DataSource = this.userBindingSource;
            this.cbSelectClient.DisplayMember = "UserDisplayName";
            this.cbSelectClient.FormattingEnabled = true;
            this.cbSelectClient.Location = new System.Drawing.Point(176, 73);
            this.cbSelectClient.Name = "cbSelectClient";
            this.cbSelectClient.Size = new System.Drawing.Size(219, 24);
            this.cbSelectClient.TabIndex = 46;
            this.ttEditProductOrder.SetToolTip(this.cbSelectClient,GLOBAL_RESOURCES.CLIENT_ASSIGN_TOOLTIP_TITLE);
            this.cbSelectClient.ValueMember = "ID";
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
            this.lblClient.Location = new System.Drawing.Point(20, 76);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(98, 16);
            this.lblClient.TabIndex = 45;
            this.lblClient.Text = GLOBAL_RESOURCES.LBL_CLIENT_TITLE;
            // 
            // trbDesiredQuantity
            // 
            this.trbDesiredQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbDesiredQuantity.Location = new System.Drawing.Point(527, 27);
            this.trbDesiredQuantity.Maximum = 10000;
            this.trbDesiredQuantity.Name = "trbDesiredQuantity";
            this.trbDesiredQuantity.Size = new System.Drawing.Size(205, 56);
            this.trbDesiredQuantity.TabIndex = 44;
            this.trbDesiredQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttEditProductOrder.SetToolTip(this.trbDesiredQuantity, GLOBAL_RESOURCES.DESIRED_QUANTITY_EDIT_TOOLTIP_TITLE);
            this.trbDesiredQuantity.Scroll += new System.EventHandler(this.trbDesiredQuantity_Scroll);
            // 
            // lblDesiredQuantity
            // 
            this.lblDesiredQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesiredQuantity.AutoSize = true;
            this.lblDesiredQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesiredQuantity.Location = new System.Drawing.Point(396, 26);
            this.lblDesiredQuantity.Name = "lblDesiredQuantity";
            this.lblDesiredQuantity.Size = new System.Drawing.Size(126, 16);
            this.lblDesiredQuantity.TabIndex = 42;
            this.lblDesiredQuantity.Text = GLOBAL_RESOURCES.LBL_DESIRED_QUANTITY_TITLE;
            // 
            // cbSelectProduct
            // 
            this.cbSelectProduct.DataSource = this.productBindingSource;
            this.cbSelectProduct.DisplayMember = "ProductName";
            this.cbSelectProduct.FormattingEnabled = true;
            this.cbSelectProduct.Location = new System.Drawing.Point(176, 42);
            this.cbSelectProduct.Name = "cbSelectProduct";
            this.cbSelectProduct.Size = new System.Drawing.Size(219, 24);
            this.cbSelectProduct.TabIndex = 36;
            this.ttEditProductOrder.SetToolTip(this.cbSelectProduct, GLOBAL_RESOURCES.PRODUCT_ASSIGN_TOOLTIP_TITLE);
            this.cbSelectProduct.ValueMember = "ID";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.Product);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(416, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 47);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = GLOBAL_RESOURCES.BTN_OK_TITLE;
            this.ttEditProductOrder.SetToolTip(this.btnOK, GLOBAL_RESOURCES.BTN_OK_EDITOR_TOOLTIP_TITLE);
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(527, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text =GLOBAL_RESOURCES.BTN_CANCEL_TITLE;
            this.ttEditProductOrder.SetToolTip(this.btnCancel,GLOBAL_RESOURCES.BTN_CANCEL_EDITOR_TOOLTIP_TITLE);
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // trbPriceOverride
            // 
            this.trbPriceOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbPriceOverride.Location = new System.Drawing.Point(527, 89);
            this.trbPriceOverride.Maximum = 10000;
            this.trbPriceOverride.Name = "trbPriceOverride";
            this.trbPriceOverride.Size = new System.Drawing.Size(205, 56);
            this.trbPriceOverride.TabIndex = 21;
            this.trbPriceOverride.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttEditProductOrder.SetToolTip(this.trbPriceOverride, GLOBAL_RESOURCES.PRICE_OVERRIDE_EDIT_TOOLTIP_TITLE);
            this.trbPriceOverride.Scroll += new System.EventHandler(this.trbPriceOverride_Scroll);
            // 
            // lblPriceOverride
            // 
            this.lblPriceOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceOverride.AutoSize = true;
            this.lblPriceOverride.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceOverride.Location = new System.Drawing.Point(396, 88);
            this.lblPriceOverride.Name = "lblPriceOverride";
            this.lblPriceOverride.Size = new System.Drawing.Size(111, 16);
            this.lblPriceOverride.TabIndex = 19;
            this.lblPriceOverride.Text = GLOBAL_RESOURCES.LBL_PRICE_OVERRIDE_TITLE;
            // 
            // lblSelectProduct
            // 
            this.lblSelectProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectProduct.AutoSize = true;
            this.lblSelectProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectProduct.Location = new System.Drawing.Point(20, 45);
            this.lblSelectProduct.Name = "lblSelectProduct";
            this.lblSelectProduct.Size = new System.Drawing.Size(112, 16);
            this.lblSelectProduct.TabIndex = 5;
            this.lblSelectProduct.Text = GLOBAL_RESOURCES.LBL_PRODUCT_TITLE;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(174, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(220, 22);
            this.txtID.TabIndex = 2;
            this.ttEditProductOrder.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_EDIT_TOOLTIP_TITLE);
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
            // productBrandBindingSource
            // 
            this.productBrandBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductBrand);
            // 
            // ttEditProductOrder
            // 
            this.ttEditProductOrder.IsBalloon = true;
            this.ttEditProductOrder.ShowAlways = true;
            this.ttEditProductOrder.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttEditProductOrder.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmEditProductOrder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 302);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmEditProductOrder";
            this.Text = GLOBAL_RESOURCES.EDIT_PRODUCT_ORDER_TITLE;
            this.ttEditProductOrder.SetToolTip(this, GLOBAL_RESOURCES.EDIT_PRODUCT_ORDER_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmEditProductOrder_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDesiredQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPriceOverride)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblSelectProduct;
        private System.Windows.Forms.Label lblPriceOverride;
        private System.Windows.Forms.TrackBar trbPriceOverride;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbSelectProduct;
        private System.Windows.Forms.BindingSource productBrandBindingSource;
        private System.Windows.Forms.TrackBar trbDesiredQuantity;
        private System.Windows.Forms.Label lblDesiredQuantity;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.ComboBox cbSelectClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cbSelectEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.ComboBox cbSelectOrderStatus;
        private System.Windows.Forms.TextBox txtOrderReason;
        private System.Windows.Forms.Label lblOrderReason;
        private System.Windows.Forms.TextBox txtDesiredQuantity;
        private System.Windows.Forms.TextBox txtPriceOverride;
        private System.Windows.Forms.ToolTip ttEditProductOrder;
    }
}