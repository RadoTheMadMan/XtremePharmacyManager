namespace XtremePharmacyManager
{
    partial class frmEditOrderDelivery
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
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblCargoID = new System.Windows.Forms.Label();
            this.txtCargoID = new System.Windows.Forms.TextBox();
            this.txtDeliveryReason = new System.Windows.Forms.TextBox();
            this.lblDeliveryReason = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.cbSelectDeliveryStatus = new System.Windows.Forms.ComboBox();
            this.cbSelectPaymentMethod = new System.Windows.Forms.ComboBox();
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cbSelectDeliveryService = new System.Windows.Forms.ComboBox();
            this.deliveryServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDeliveryService = new System.Windows.Forms.Label();
            this.cbSelectProductOrders = new System.Windows.Forms.ComboBox();
            this.productOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectProductOrder = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.lblCargoID);
            this.pnlData.Controls.Add(this.txtCargoID);
            this.pnlData.Controls.Add(this.txtDeliveryReason);
            this.pnlData.Controls.Add(this.lblDeliveryReason);
            this.pnlData.Controls.Add(this.lblOrderStatus);
            this.pnlData.Controls.Add(this.cbSelectDeliveryStatus);
            this.pnlData.Controls.Add(this.cbSelectPaymentMethod);
            this.pnlData.Controls.Add(this.lblPaymentMethod);
            this.pnlData.Controls.Add(this.cbSelectDeliveryService);
            this.pnlData.Controls.Add(this.lblDeliveryService);
            this.pnlData.Controls.Add(this.cbSelectProductOrders);
            this.pnlData.Controls.Add(this.btnOK);
            this.pnlData.Controls.Add(this.btnCancel);
            this.pnlData.Controls.Add(this.lblSelectProductOrder);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(800, 209);
            this.pnlData.TabIndex = 0;
            // 
            // lblCargoID
            // 
            this.lblCargoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCargoID.AutoSize = true;
            this.lblCargoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoID.Location = new System.Drawing.Point(20, 138);
            this.lblCargoID.Name = "lblCargoID";
            this.lblCargoID.Size = new System.Drawing.Size(72, 16);
            this.lblCargoID.TabIndex = 56;
            this.lblCargoID.Text = "Cargo ID:";
            // 
            // txtCargoID
            // 
            this.txtCargoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargoID.Location = new System.Drawing.Point(194, 135);
            this.txtCargoID.Name = "txtCargoID";
            this.txtCargoID.Size = new System.Drawing.Size(201, 22);
            this.txtCargoID.TabIndex = 55;
            // 
            // txtDeliveryReason
            // 
            this.txtDeliveryReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryReason.Location = new System.Drawing.Point(544, 11);
            this.txtDeliveryReason.Multiline = true;
            this.txtDeliveryReason.Name = "txtDeliveryReason";
            this.txtDeliveryReason.Size = new System.Drawing.Size(230, 86);
            this.txtDeliveryReason.TabIndex = 54;
            // 
            // lblDeliveryReason
            // 
            this.lblDeliveryReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeliveryReason.AutoSize = true;
            this.lblDeliveryReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryReason.Location = new System.Drawing.Point(413, 14);
            this.lblDeliveryReason.Name = "lblDeliveryReason";
            this.lblDeliveryReason.Size = new System.Drawing.Size(127, 16);
            this.lblDeliveryReason.TabIndex = 53;
            this.lblDeliveryReason.Text = "Delivery Reason:";
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.Location = new System.Drawing.Point(20, 169);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(97, 16);
            this.lblOrderStatus.TabIndex = 52;
            this.lblOrderStatus.Text = "Order Status:";
            // 
            // cbSelectDeliveryStatus
            // 
            this.cbSelectDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.cbSelectDeliveryStatus.Location = new System.Drawing.Point(194, 166);
            this.cbSelectDeliveryStatus.Name = "cbSelectDeliveryStatus";
            this.cbSelectDeliveryStatus.Size = new System.Drawing.Size(201, 24);
            this.cbSelectDeliveryStatus.TabIndex = 51;
            this.cbSelectDeliveryStatus.Text = "pending delivery";
            // 
            // cbSelectPaymentMethod
            // 
            this.cbSelectPaymentMethod.DataSource = this.paymentMethodBindingSource;
            this.cbSelectPaymentMethod.DisplayMember = "MethodName";
            this.cbSelectPaymentMethod.FormattingEnabled = true;
            this.cbSelectPaymentMethod.Location = new System.Drawing.Point(194, 105);
            this.cbSelectPaymentMethod.Name = "cbSelectPaymentMethod";
            this.cbSelectPaymentMethod.Size = new System.Drawing.Size(201, 24);
            this.cbSelectPaymentMethod.TabIndex = 48;
            this.cbSelectPaymentMethod.ValueMember = "ID";
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
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 108);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(174, 16);
            this.lblPaymentMethod.TabIndex = 47;
            this.lblPaymentMethod.Text = "Select Payment Method:";
            // 
            // cbSelectDeliveryService
            // 
            this.cbSelectDeliveryService.DataSource = this.deliveryServiceBindingSource;
            this.cbSelectDeliveryService.DisplayMember = "ServiceName";
            this.cbSelectDeliveryService.FormattingEnabled = true;
            this.cbSelectDeliveryService.Location = new System.Drawing.Point(194, 73);
            this.cbSelectDeliveryService.Name = "cbSelectDeliveryService";
            this.cbSelectDeliveryService.Size = new System.Drawing.Size(201, 24);
            this.cbSelectDeliveryService.TabIndex = 46;
            this.cbSelectDeliveryService.ValueMember = "ID";
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
            this.lblDeliveryService.Location = new System.Drawing.Point(20, 76);
            this.lblDeliveryService.Name = "lblDeliveryService";
            this.lblDeliveryService.Size = new System.Drawing.Size(174, 16);
            this.lblDeliveryService.TabIndex = 45;
            this.lblDeliveryService.Text = "Select Delivery Service:";
            // 
            // cbSelectProductOrders
            // 
            this.cbSelectProductOrders.DataSource = this.productOrderBindingSource;
            this.cbSelectProductOrders.DisplayMember = "ID";
            this.cbSelectProductOrders.FormattingEnabled = true;
            this.cbSelectProductOrders.Location = new System.Drawing.Point(194, 42);
            this.cbSelectProductOrders.Name = "cbSelectProductOrders";
            this.cbSelectProductOrders.Size = new System.Drawing.Size(201, 24);
            this.cbSelectProductOrders.TabIndex = 36;
            this.cbSelectProductOrders.ValueMember = "ID";
            // 
            // productOrderBindingSource
            // 
            this.productOrderBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.ProductOrder);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(555, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 47);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(666, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectProductOrder
            // 
            this.lblSelectProductOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectProductOrder.AutoSize = true;
            this.lblSelectProductOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectProductOrder.Location = new System.Drawing.Point(20, 45);
            this.lblSelectProductOrder.Name = "lblSelectProductOrder";
            this.lblSelectProductOrder.Size = new System.Drawing.Size(117, 16);
            this.lblSelectProductOrder.TabIndex = 5;
            this.lblSelectProductOrder.Text = "Select Order ID:";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(194, 14);
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
            // frmEditOrderDelivery
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 209);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmEditOrderDelivery";
            this.Text = "Order Delivery Editor. Add or Edit Order Deliveries";
            this.Load += new System.EventHandler(this.frmEditOrderDelivery_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblSelectProductOrder;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbSelectProductOrders;
        private System.Windows.Forms.BindingSource productBrandBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.ComboBox cbSelectDeliveryService;
        private System.Windows.Forms.Label lblDeliveryService;
        private System.Windows.Forms.ComboBox cbSelectPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.ComboBox cbSelectDeliveryStatus;
        private System.Windows.Forms.TextBox txtDeliveryReason;
        private System.Windows.Forms.Label lblDeliveryReason;
        private System.Windows.Forms.BindingSource productOrderBindingSource;
        private System.Windows.Forms.BindingSource deliveryServiceBindingSource;
        private System.Windows.Forms.TextBox txtCargoID;
        private System.Windows.Forms.Label lblCargoID;
        private System.Windows.Forms.BindingSource paymentMethodBindingSource;
    }
}