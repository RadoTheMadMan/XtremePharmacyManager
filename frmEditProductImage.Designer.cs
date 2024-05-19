namespace XtremePharmacyManager
{
    partial class frmEditProductImage
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
            this.pnlData = new System.Windows.Forms.Panel();
            this.pbProductImageData = new System.Windows.Forms.PictureBox();
            this.cbSelectProduct = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectProduct = new System.Windows.Forms.Label();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.lblImageName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.productBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImageData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.pbProductImageData);
            this.pnlData.Controls.Add(this.cbSelectProduct);
            this.pnlData.Controls.Add(this.btnOK);
            this.pnlData.Controls.Add(this.btnCancel);
            this.pnlData.Controls.Add(this.lblSelectProduct);
            this.pnlData.Controls.Add(this.txtImageName);
            this.pnlData.Controls.Add(this.lblImageName);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(564, 184);
            this.pnlData.TabIndex = 0;
            // 
            // pbProductImageData
            // 
            this.pbProductImageData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbProductImageData.Location = new System.Drawing.Point(401, 14);
            this.pbProductImageData.Name = "pbProductImageData";
            this.pbProductImageData.Size = new System.Drawing.Size(151, 145);
            this.pbProductImageData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImageData.TabIndex = 37;
            this.pbProductImageData.TabStop = false;
            this.pbProductImageData.Click += new System.EventHandler(this.pbProductImageData_Click);
            // 
            // cbSelectProduct
            // 
            this.cbSelectProduct.DataSource = this.productBindingSource;
            this.cbSelectProduct.DisplayMember = "ProductName";
            this.cbSelectProduct.FormattingEnabled = true;
            this.cbSelectProduct.Location = new System.Drawing.Point(175, 70);
            this.cbSelectProduct.Name = "cbSelectProduct";
            this.cbSelectProduct.Size = new System.Drawing.Size(219, 24);
            this.cbSelectProduct.TabIndex = 36;
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
            this.btnOK.Location = new System.Drawing.Point(193, 112);
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
            this.btnCancel.Location = new System.Drawing.Point(304, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectProduct
            // 
            this.lblSelectProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectProduct.AutoSize = true;
            this.lblSelectProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectProduct.Location = new System.Drawing.Point(19, 73);
            this.lblSelectProduct.Name = "lblSelectProduct";
            this.lblSelectProduct.Size = new System.Drawing.Size(112, 16);
            this.lblSelectProduct.TabIndex = 5;
            this.lblSelectProduct.Text = "Select Product:";
            // 
            // txtImageName
            // 
            this.txtImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtImageName.Location = new System.Drawing.Point(174, 42);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(220, 22);
            this.txtImageName.TabIndex = 4;
            // 
            // lblImageName
            // 
            this.lblImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageName.AutoSize = true;
            this.lblImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageName.Location = new System.Drawing.Point(19, 45);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(99, 16);
            this.lblImageName.TabIndex = 3;
            this.lblImageName.Text = "Image Name:";
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
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // frmEditProductImage
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(564, 186);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmEditProductImage";
            this.Text = "Product Image Editor. Add or Edit Product Image";
            this.Load += new System.EventHandler(this.frmEditProductImage_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImageData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Label lblSelectProduct;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbSelectProduct;
        private System.Windows.Forms.BindingSource productBrandBindingSource;
        private System.Windows.Forms.PictureBox pbProductImageData;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}