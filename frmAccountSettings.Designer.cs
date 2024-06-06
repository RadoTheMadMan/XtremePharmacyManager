namespace XtremePharmacyManager
{
    partial class frmAccountSettings
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
                if(login_account != null)
                {
                    login_account = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountSettings));
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblUserNotice = new System.Windows.Forms.Label();
            this.pbYourProfilePic = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtYourDiagnose = new System.Windows.Forms.TextBox();
            this.lblYourDiagnose = new System.Windows.Forms.Label();
            this.txtYourAddress = new System.Windows.Forms.TextBox();
            this.lblYourAddress = new System.Windows.Forms.Label();
            this.txtYourEmail = new System.Windows.Forms.TextBox();
            this.lblYourEmail = new System.Windows.Forms.Label();
            this.txtYourPhone = new System.Windows.Forms.TextBox();
            this.lblYourPhone = new System.Windows.Forms.Label();
            this.txtYourDisplayName = new System.Windows.Forms.TextBox();
            this.lblYourDisplayName = new System.Windows.Forms.Label();
            this.txtYourPassword = new System.Windows.Forms.TextBox();
            this.lblYourPassword = new System.Windows.Forms.Label();
            this.txtYourUsername = new System.Windows.Forms.TextBox();
            this.lblYourUsername = new System.Windows.Forms.Label();
            this.ttAccountSettings = new System.Windows.Forms.ToolTip(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbYourProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.lblUserNotice);
            this.pnlData.Controls.Add(this.pbYourProfilePic);
            this.pnlData.Controls.Add(this.btnOK);
            this.pnlData.Controls.Add(this.btnCancel);
            this.pnlData.Controls.Add(this.txtYourDiagnose);
            this.pnlData.Controls.Add(this.lblYourDiagnose);
            this.pnlData.Controls.Add(this.txtYourAddress);
            this.pnlData.Controls.Add(this.lblYourAddress);
            this.pnlData.Controls.Add(this.txtYourEmail);
            this.pnlData.Controls.Add(this.lblYourEmail);
            this.pnlData.Controls.Add(this.txtYourPhone);
            this.pnlData.Controls.Add(this.lblYourPhone);
            this.pnlData.Controls.Add(this.txtYourDisplayName);
            this.pnlData.Controls.Add(this.lblYourDisplayName);
            this.pnlData.Controls.Add(this.txtYourPassword);
            this.pnlData.Controls.Add(this.lblYourPassword);
            this.pnlData.Controls.Add(this.txtYourUsername);
            this.pnlData.Controls.Add(this.lblYourUsername);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(737, 412);
            this.pnlData.TabIndex = 0;
            // 
            // lblUserNotice
            // 
            this.lblUserNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNotice.AutoSize = true;
            this.lblUserNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.lblUserNotice.Location = new System.Drawing.Point(479, 243);
            this.lblUserNotice.Name = "lblUserNotice";
            this.lblUserNotice.Size = new System.Drawing.Size(248, 96);
            this.lblUserNotice.TabIndex = 42;
            this.lblUserNotice.Text = "IMPORTANT NOTICE:\r\nIf you change your username or \r\npassword to an existing one\r\n" +
    "it will be rejected by the system.\r\nIf this happens contact your system\r\nadminis" +
    "trator.";
            this.ttAccountSettings.SetToolTip(this.lblUserNotice, GLOBAL_RESOURCES.ACCOUNT_SETTINGS_NOTICE_TOOLTIP_TITLE);
            // 
            // pbYourProfilePic
            // 
            this.pbYourProfilePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbYourProfilePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbYourProfilePic.Location = new System.Drawing.Point(482, 20);
            this.pbYourProfilePic.Name = "pbYourProfilePic";
            this.pbYourProfilePic.Size = new System.Drawing.Size(243, 210);
            this.pbYourProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbYourProfilePic.TabIndex = 34;
            this.pbYourProfilePic.TabStop = false;
            this.ttAccountSettings.SetToolTip(this.pbYourProfilePic, "Give yourself a cool profile picture while working. Set it as you please, it is s" +
        "aved directly on the database in a binary format, no web server involved");
            this.pbYourProfilePic.Click += new System.EventHandler(this.pbYourProfilePic_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(524, 353);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 47);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "OK";
            this.ttAccountSettings.SetToolTip(this.btnOK, resources.GetString("btnOK.ToolTip"));
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(635, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "CANCEL";
            this.ttAccountSettings.SetToolTip(this.btnCancel, "Click this if you aren\'t sure about changing your account settings, they will be " +
        "reverted back to the previous ones");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtYourDiagnose
            // 
            this.txtYourDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourDiagnose.Location = new System.Drawing.Point(203, 243);
            this.txtYourDiagnose.Multiline = true;
            this.txtYourDiagnose.Name = "txtYourDiagnose";
            this.txtYourDiagnose.Size = new System.Drawing.Size(258, 96);
            this.txtYourDiagnose.TabIndex = 23;
            this.ttAccountSettings.SetToolTip(this.txtYourDiagnose, "The diagnose you have, if we know that we can recommend the exact medicine for yo" +
        "u so you can be cured from your disease");
            // 
            // lblYourDiagnose
            // 
            this.lblYourDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourDiagnose.AutoSize = true;
            this.lblYourDiagnose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourDiagnose.Location = new System.Drawing.Point(20, 243);
            this.lblYourDiagnose.Name = "lblYourDiagnose";
            this.lblYourDiagnose.Size = new System.Drawing.Size(78, 16);
            this.lblYourDiagnose.TabIndex = 22;
            this.lblYourDiagnose.Text = GLOBAL_RESOURCES.LBL_DIAGNOSE_TITLE;
            // 
            // txtYourAddress
            // 
            this.txtYourAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourAddress.Location = new System.Drawing.Point(203, 160);
            this.txtYourAddress.Multiline = true;
            this.txtYourAddress.Name = "txtYourAddress";
            this.txtYourAddress.Size = new System.Drawing.Size(258, 70);
            this.txtYourAddress.TabIndex = 18;
            this.ttAccountSettings.SetToolTip(this.txtYourAddress, "The address of your home, where we can deliver the medicine you ordered if you ca" +
        "n\'t go to order inplace");
            // 
            // lblYourAddress
            // 
            this.lblYourAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourAddress.AutoSize = true;
            this.lblYourAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourAddress.Location = new System.Drawing.Point(20, 163);
            this.lblYourAddress.Name = "lblYourAddress";
            this.lblYourAddress.Size = new System.Drawing.Size(105, 16);
            this.lblYourAddress.TabIndex = 17;
            this.lblYourAddress.Text = "Your Address:";
            // 
            // txtYourEmail
            // 
            this.txtYourEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourEmail.Location = new System.Drawing.Point(203, 132);
            this.txtYourEmail.Name = "txtYourEmail";
            this.txtYourEmail.Size = new System.Drawing.Size(258, 22);
            this.txtYourEmail.TabIndex = 16;
            this.ttAccountSettings.SetToolTip(this.txtYourEmail, "Your email, used as well for feedback and/or contacting you about ordering medici" +
        "ne");
            // 
            // lblYourEmail
            // 
            this.lblYourEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourEmail.AutoSize = true;
            this.lblYourEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourEmail.Location = new System.Drawing.Point(20, 135);
            this.lblYourEmail.Name = "lblYourEmail";
            this.lblYourEmail.Size = new System.Drawing.Size(86, 16);
            this.lblYourEmail.TabIndex = 15;
            this.lblYourEmail.Text = "Your Email:";
            // 
            // txtYourPhone
            // 
            this.txtYourPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourPhone.Location = new System.Drawing.Point(203, 104);
            this.txtYourPhone.Name = "txtYourPhone";
            this.txtYourPhone.Size = new System.Drawing.Size(258, 22);
            this.txtYourPhone.TabIndex = 14;
            this.ttAccountSettings.SetToolTip(this.txtYourPhone, "Your phone number for contacts with you and feedback from your feedback or for or" +
        "ders of various medicine");
            // 
            // lblYourPhone
            // 
            this.lblYourPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourPhone.AutoSize = true;
            this.lblYourPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourPhone.Location = new System.Drawing.Point(20, 107);
            this.lblYourPhone.Name = "lblYourPhone";
            this.lblYourPhone.Size = new System.Drawing.Size(91, 16);
            this.lblYourPhone.TabIndex = 13;
            this.lblYourPhone.Text = "Your Phone:";
            // 
            // txtYourDisplayName
            // 
            this.txtYourDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourDisplayName.Location = new System.Drawing.Point(203, 76);
            this.txtYourDisplayName.Name = "txtYourDisplayName";
            this.txtYourDisplayName.Size = new System.Drawing.Size(258, 22);
            this.txtYourDisplayName.TabIndex = 8;
            this.ttAccountSettings.SetToolTip(this.txtYourDisplayName, "The display name of your user account. You thought you will be represented by you" +
        "r username?");
            // 
            // lblYourDisplayName
            // 
            this.lblYourDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourDisplayName.AutoSize = true;
            this.lblYourDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourDisplayName.Location = new System.Drawing.Point(20, 79);
            this.lblYourDisplayName.Name = "lblYourDisplayName";
            this.lblYourDisplayName.Size = new System.Drawing.Size(145, 16);
            this.lblYourDisplayName.TabIndex = 7;
            this.lblYourDisplayName.Text = "Your Display Name:";
            // 
            // txtYourPassword
            // 
            this.txtYourPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourPassword.Location = new System.Drawing.Point(203, 48);
            this.txtYourPassword.Name = "txtYourPassword";
            this.txtYourPassword.Size = new System.Drawing.Size(258, 22);
            this.txtYourPassword.TabIndex = 6;
            this.ttAccountSettings.SetToolTip(this.txtYourPassword, "Your password on the database with which you login.");
            this.txtYourPassword.UseSystemPasswordChar = true;
            // 
            // lblYourPassword
            // 
            this.lblYourPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourPassword.AutoSize = true;
            this.lblYourPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourPassword.Location = new System.Drawing.Point(20, 51);
            this.lblYourPassword.Name = "lblYourPassword";
            this.lblYourPassword.Size = new System.Drawing.Size(115, 16);
            this.lblYourPassword.TabIndex = 5;
            this.lblYourPassword.Text = "Your Password:";
            // 
            // txtYourUsername
            // 
            this.txtYourUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYourUsername.Location = new System.Drawing.Point(203, 20);
            this.txtYourUsername.Name = "txtYourUsername";
            this.txtYourUsername.Size = new System.Drawing.Size(258, 22);
            this.txtYourUsername.TabIndex = 4;
            this.ttAccountSettings.SetToolTip(this.txtYourUsername, "Your username in the database with which you login");
            // 
            // lblYourUsername
            // 
            this.lblYourUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYourUsername.AutoSize = true;
            this.lblYourUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourUsername.Location = new System.Drawing.Point(20, 23);
            this.lblYourUsername.Name = "lblYourUsername";
            this.lblYourUsername.Size = new System.Drawing.Size(118, 16);
            this.lblYourUsername.TabIndex = 3;
            this.lblYourUsername.Text = "Your Username:";
            // 
            // ttAccountSettings
            // 
            this.ttAccountSettings.IsBalloon = true;
            this.ttAccountSettings.ShowAlways = true;
            this.ttAccountSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttAccountSettings.ToolTipTitle = GLOBAL_RESOURCES.HELP_TITLE;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // frmAccountSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(737, 417);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmAccountSettings";
            this.Text = $"{GLOBAL_RESOURCES.ACCOUNT_SETTINGS_TITLE}";
            this.ttAccountSettings.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmAccountSettings_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbYourProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.TextBox txtYourUsername;
        private System.Windows.Forms.Label lblYourUsername;
        private System.Windows.Forms.TextBox txtYourPassword;
        private System.Windows.Forms.Label lblYourPassword;
        private System.Windows.Forms.TextBox txtYourDisplayName;
        private System.Windows.Forms.Label lblYourDisplayName;
        private System.Windows.Forms.TextBox txtYourAddress;
        private System.Windows.Forms.Label lblYourAddress;
        private System.Windows.Forms.TextBox txtYourEmail;
        private System.Windows.Forms.Label lblYourEmail;
        private System.Windows.Forms.TextBox txtYourPhone;
        private System.Windows.Forms.Label lblYourPhone;
        private System.Windows.Forms.TextBox txtYourDiagnose;
        private System.Windows.Forms.Label lblYourDiagnose;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pbYourProfilePic;
        private System.Windows.Forms.Label lblUserNotice;
        private System.Windows.Forms.ToolTip ttAccountSettings;
    }
}