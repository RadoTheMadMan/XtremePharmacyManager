﻿namespace XtremePharmacyManager
{
    partial class frmEditDeliveryService
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
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.trbPrice = new System.Windows.Forms.TrackBar();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttEditDeliveryService = new System.Windows.Forms.ToolTip(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.Controls.Add(this.txtPrice);
            this.pnlData.Controls.Add(this.btnOK);
            this.pnlData.Controls.Add(this.btnCancel);
            this.pnlData.Controls.Add(this.trbPrice);
            this.pnlData.Controls.Add(this.lblPrice);
            this.pnlData.Controls.Add(this.txtServiceName);
            this.pnlData.Controls.Add(this.lblServiceName);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(551, 290);
            this.pnlData.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPrice.Location = new System.Drawing.Point(348, 76);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(76, 22);
            this.txtPrice.TabIndex = 34;
            this.ttEditDeliveryService.SetToolTip(this.txtPrice, GLOBAL_RESOURCES.DELIVERY_PRICE_EDIT_TOOLTIP_TITLE);
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(190, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 47);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = GLOBAL_RESOURCES.BTN_OK_TITLE;
            this.ttEditDeliveryService.SetToolTip(this.btnOK, GLOBAL_RESOURCES.BTN_OK_EDITOR_TOOLTIP_TITLE);
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(301, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text =GLOBAL_RESOURCES.BTN_CANCEL_TITLE;
            this.ttEditDeliveryService.SetToolTip(this.btnCancel,GLOBAL_RESOURCES.BTN_CANCEL_EDITOR_TOOLTIP_TITLE);
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // trbPrice
            // 
            this.trbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trbPrice.Location = new System.Drawing.Point(136, 73);
            this.trbPrice.Maximum = 5000;
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(205, 56);
            this.trbPrice.TabIndex = 21;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ttEditDeliveryService.SetToolTip(this.trbPrice, GLOBAL_RESOURCES.DELIVERY_PRICE_EDIT_TOOLTIP_TITLE);
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(20, 76);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(47, 16);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = GLOBAL_RESOURCES.LBL_PRICE_TITLE;
            // 
            // txtServiceName
            // 
            this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtServiceName.Location = new System.Drawing.Point(136, 42);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(205, 22);
            this.txtServiceName.TabIndex = 4;
            this.ttEditDeliveryService.SetToolTip(this.txtServiceName, GLOBAL_RESOURCES.SERVICE_NAME_EDIT_TOOLTIP_TITLE);
            // 
            // lblUsername
            // 
            this.lblServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.Location = new System.Drawing.Point(19, 45);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(109, 16);
            this.lblServiceName.TabIndex = 3;
            this.lblServiceName.Text = GLOBAL_RESOURCES.LBL_SERVICE_NAME_TITLE;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(136, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(205, 22);
            this.txtID.TabIndex = 2;
            this.ttEditDeliveryService.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_EDIT_TOOLTIP_TITLE);
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
            // ttEditDeliveryService
            // 
            this.ttEditDeliveryService.IsBalloon = true;
            this.ttEditDeliveryService.ShowAlways = true;
            this.ttEditDeliveryService.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttEditDeliveryService.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // frmEditDeliveryService
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(551, 291);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmEditDeliveryService";
            this.Text = GLOBAL_RESOURCES.EDIT_DELIVERY_SERVICE_TITLE;
            this.ttEditDeliveryService.SetToolTip(this, GLOBAL_RESOURCES.EDIT_DELIVERY_SERVICE_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmEditDeliveryService_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TrackBar trbPrice;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ToolTip ttEditDeliveryService;
    }
}