namespace XtremePharmacyManager
{
    partial class frmLogin
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
                if (retrieved_users != null)
                {
                    retrieved_users.Clear();
                    retrieved_users = null;
                }
                if (last_logins != null)
                {
                    last_logins = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnRemoveLogin = new System.Windows.Forms.Button();
            this.btnAddLogin = new System.Windows.Forms.Button();
            this.btnClearLogins = new System.Windows.Forms.Button();
            this.lblLastLogins = new System.Windows.Forms.Label();
            this.lblLoginCredentials = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSetCurrentLoginAsDefault = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.btnRemoveOperation = new System.Windows.Forms.Button();
            this.btnApplyChangesToCurrentTarget = new System.Windows.Forms.Button();
            this.btnExecuteOperations = new System.Windows.Forms.Button();
            this.btnApplyChangesToAllTargets = new System.Windows.Forms.Button();
            this.lstLastLogins = new System.Windows.Forms.ListBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ttLogin = new System.Windows.Forms.ToolTip(this.components);
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnRemoveLogin);
            this.pnlLogin.Controls.Add(this.btnAddLogin);
            this.pnlLogin.Controls.Add(this.btnClearLogins);
            this.pnlLogin.Controls.Add(this.lblLastLogins);
            this.pnlLogin.Controls.Add(this.lblLoginCredentials);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnSetCurrentLoginAsDefault);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.btnAddOperation);
            this.pnlLogin.Controls.Add(this.btnRemoveOperation);
            this.pnlLogin.Controls.Add(this.btnApplyChangesToCurrentTarget);
            this.pnlLogin.Controls.Add(this.btnExecuteOperations);
            this.pnlLogin.Controls.Add(this.btnApplyChangesToAllTargets);
            this.pnlLogin.Controls.Add(this.lstLastLogins);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(876, 295);
            this.pnlLogin.TabIndex = 0;
            // 
            // btnRemoveLogin
            // 
            this.btnRemoveLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLogin.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveLogin.Location = new System.Drawing.Point(286, 245);
            this.btnRemoveLogin.Name = "btnRemoveLogin";
            this.btnRemoveLogin.Size = new System.Drawing.Size(265, 47);
            this.btnRemoveLogin.TabIndex = 52;
            this.btnRemoveLogin.Text = "REMOVE LOGIN";
            this.ttLogin.SetToolTip(this.btnRemoveLogin, "With this button an item from the logins list you select will beremoved from the " +
        "memory but not from the filesystem");
            this.btnRemoveLogin.UseVisualStyleBackColor = true;
            this.btnRemoveLogin.Click += new System.EventHandler(this.btnRemoveLogin_Click);
            // 
            // btnAddLogin
            // 
            this.btnAddLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLogin.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLogin.Location = new System.Drawing.Point(286, 192);
            this.btnAddLogin.Name = "btnAddLogin";
            this.btnAddLogin.Size = new System.Drawing.Size(265, 47);
            this.btnAddLogin.TabIndex = 51;
            this.btnAddLogin.Text = "ADD LOGIN";
            this.ttLogin.SetToolTip(this.btnAddLogin, "With this button you can add new login credentials to the login list and upon log" +
        "ging in it will be saved into the filesystem");
            this.btnAddLogin.UseVisualStyleBackColor = true;
            this.btnAddLogin.Click += new System.EventHandler(this.btnAddLogin_Click);
            // 
            // btnClearLogins
            // 
            this.btnClearLogins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogins.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLogins.Location = new System.Drawing.Point(286, 139);
            this.btnClearLogins.Name = "btnClearLogins";
            this.btnClearLogins.Size = new System.Drawing.Size(265, 47);
            this.btnClearLogins.TabIndex = 50;
            this.btnClearLogins.Text = "CLEAR_LOGINS";
            this.ttLogin.SetToolTip(this.btnClearLogins, "With this button the logins list is cleared from the memory but not from the file" +
        "system");
            this.btnClearLogins.UseVisualStyleBackColor = true;
            this.btnClearLogins.Click += new System.EventHandler(this.btnClearLogins_Click);
            // 
            // lblLastLogins
            // 
            this.lblLastLogins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastLogins.AutoSize = true;
            this.lblLastLogins.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLogins.Location = new System.Drawing.Point(554, 41);
            this.lblLastLogins.Name = "lblLastLogins";
            this.lblLastLogins.Size = new System.Drawing.Size(108, 16);
            this.lblLastLogins.TabIndex = 49;
            this.lblLastLogins.Text = "LAST LOGINS:";
            this.ttLogin.SetToolTip(this.lblLastLogins, "The area where the last logins you used will be displayed. Again if you select a " +
        "client account and try to login you will be booted out.");
            // 
            // lblLoginCredentials
            // 
            this.lblLoginCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoginCredentials.AutoSize = true;
            this.lblLoginCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginCredentials.Location = new System.Drawing.Point(12, 41);
            this.lblLoginCredentials.Name = "lblLoginCredentials";
            this.lblLoginCredentials.Size = new System.Drawing.Size(268, 16);
            this.lblLoginCredentials.TabIndex = 48;
            this.lblLoginCredentials.Text = "ENTER YOUR LOGIN CREDENTIALS:";
            this.ttLogin.SetToolTip(this.lblLoginCredentials, "This is the area where you enter your login credentials or login credentials from" +
        " your application settings are displayed. They are tightly connected.");
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(15, 139);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(265, 47);
            this.btnLogin.TabIndex = 47;
            this.btnLogin.Text = $"{GLOBAL_RESOURCES.LOGIN_TITLE}";
            this.ttLogin.SetToolTip(this.btnLogin, "With this button you login to the database the software is connected to and if th" +
        "e credentials are right it will log you in otherwise not.");
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(15, 245);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(265, 47);
            this.btnExit.TabIndex = 46;
            this.btnExit.Text = "EXIT";
            this.ttLogin.SetToolTip(this.btnExit, "With this button you exit the application with probably a message that you can\'t " +
        "use this application without authorisation");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetCurrentLoginAsDefault
            // 
            this.btnSetCurrentLoginAsDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetCurrentLoginAsDefault.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetCurrentLoginAsDefault.Location = new System.Drawing.Point(15, 192);
            this.btnSetCurrentLoginAsDefault.Name = "btnSetCurrentLoginAsDefault";
            this.btnSetCurrentLoginAsDefault.Size = new System.Drawing.Size(265, 47);
            this.btnSetCurrentLoginAsDefault.TabIndex = 45;
            this.btnSetCurrentLoginAsDefault.Text = "SET CURRENT LOGIN AS DEFAULT";
            this.ttLogin.SetToolTip(this.btnSetCurrentLoginAsDefault, "With this button you can set the login credentials you put as login credentials i" +
        "n your application settings");
            this.btnSetCurrentLoginAsDefault.UseVisualStyleBackColor = true;
            this.btnSetCurrentLoginAsDefault.Click += new System.EventHandler(this.btnSetCurrentLoginAsDefault_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPassword.Location = new System.Drawing.Point(122, 111);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(429, 22);
            this.txtPassword.TabIndex = 44;
            this.ttLogin.SetToolTip(this.txtPassword, "Your password on the database with which you login.");
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(5, 114);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 16);
            this.lblPassword.TabIndex = 43;
            this.lblPassword.Text = GLOBAL_RESOURCES.LBL_PASSWORD_TITLE;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUsername.Location = new System.Drawing.Point(122, 83);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(429, 22);
            this.txtUsername.TabIndex = 42;
            this.ttLogin.SetToolTip(this.txtUsername, "Your username in the database with which you login");
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(5, 86);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(82, 16);
            this.lblUsername.TabIndex = 41;
            this.lblUsername.Text = GLOBAL_RESOURCES.LBL_USERNAME_TITLE;
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOperation.Location = new System.Drawing.Point(586, 598);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(211, 47);
            this.btnAddOperation.TabIndex = 40;
            this.btnAddOperation.Text = "ADD OPERATION";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            // 
            // btnRemoveOperation
            // 
            this.btnRemoveOperation.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRemoveOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOperation.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOperation.Location = new System.Drawing.Point(803, 598);
            this.btnRemoveOperation.Name = "btnRemoveOperation";
            this.btnRemoveOperation.Size = new System.Drawing.Size(211, 47);
            this.btnRemoveOperation.TabIndex = 39;
            this.btnRemoveOperation.Text = "REMOVE OPERATION";
            this.btnRemoveOperation.UseVisualStyleBackColor = true;
            // 
            // btnApplyChangesToCurrentTarget
            // 
            this.btnApplyChangesToCurrentTarget.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToCurrentTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToCurrentTarget.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToCurrentTarget.Location = new System.Drawing.Point(803, 651);
            this.btnApplyChangesToCurrentTarget.Name = "btnApplyChangesToCurrentTarget";
            this.btnApplyChangesToCurrentTarget.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToCurrentTarget.TabIndex = 38;
            this.btnApplyChangesToCurrentTarget.Text = "APPLY CHANGES TO THIS TARGET";
            this.btnApplyChangesToCurrentTarget.UseVisualStyleBackColor = true;
            // 
            // btnExecuteOperations
            // 
            this.btnExecuteOperations.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExecuteOperations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteOperations.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteOperations.Location = new System.Drawing.Point(1020, 596);
            this.btnExecuteOperations.Name = "btnExecuteOperations";
            this.btnExecuteOperations.Size = new System.Drawing.Size(211, 47);
            this.btnExecuteOperations.TabIndex = 37;
            this.btnExecuteOperations.Text = "EXECUTE OPERATIONS";
            this.btnExecuteOperations.UseVisualStyleBackColor = true;
            // 
            // btnApplyChangesToAllTargets
            // 
            this.btnApplyChangesToAllTargets.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyChangesToAllTargets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyChangesToAllTargets.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToAllTargets.Location = new System.Drawing.Point(1020, 651);
            this.btnApplyChangesToAllTargets.Name = "btnApplyChangesToAllTargets";
            this.btnApplyChangesToAllTargets.Size = new System.Drawing.Size(211, 47);
            this.btnApplyChangesToAllTargets.TabIndex = 36;
            this.btnApplyChangesToAllTargets.Text = "APPLY CHANGES TO ALL TARGETS";
            this.btnApplyChangesToAllTargets.UseVisualStyleBackColor = true;
            // 
            // lstLastLogins
            // 
            this.lstLastLogins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLastLogins.DataSource = this.userBindingSource;
            this.lstLastLogins.DisplayMember = "UserName";
            this.lstLastLogins.FormattingEnabled = true;
            this.lstLastLogins.ItemHeight = 16;
            this.lstLastLogins.Location = new System.Drawing.Point(557, 83);
            this.lstLastLogins.Name = "lstLastLogins";
            this.lstLastLogins.Size = new System.Drawing.Size(307, 212);
            this.lstLastLogins.TabIndex = 35;
            this.ttLogin.SetToolTip(this.lstLastLogins, "This is the list of all logins you have previously logged in from. Logins are sav" +
        "ed into and loaded automatically from the filesystem.");
            this.lstLastLogins.ValueMember = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.lstLastLogins.SelectedIndexChanged += new System.EventHandler(this.lstLastLogins_SelectedIndexChanged);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
            // 
            // ttLogin
            // 
            this.ttLogin.IsBalloon = true;
            this.ttLogin.ShowAlways = true;
            this.ttLogin.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttLogin.ToolTipTitle = GLOBAL_RESOURCES.HELP_TOOLTIP_TITLE;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(876, 295);
            this.Controls.Add(this.pnlLogin);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = $"{GLOBAL_RESOURCES.LOGIN_TITLE}";
            this.ttLogin.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.ListBox lstLastLogins;
        private System.Windows.Forms.Button btnExecuteOperations;
        private System.Windows.Forms.Button btnApplyChangesToAllTargets;
        private System.Windows.Forms.Button btnApplyChangesToCurrentTarget;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.Button btnRemoveOperation;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSetCurrentLoginAsDefault;
        private System.Windows.Forms.Label lblLoginCredentials;
        private System.Windows.Forms.Label lblLastLogins;
        private System.Windows.Forms.Button btnClearLogins;
        private System.Windows.Forms.Button btnAddLogin;
        private System.Windows.Forms.Button btnRemoveLogin;
        private System.Windows.Forms.ToolTip ttLogin;
    }
}