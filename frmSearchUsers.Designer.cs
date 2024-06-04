using System;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    partial class frmSearchUsers
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
                if (manager != null)
                {
                    manager.BulkOperationsExecuted -= Users_OnBulkOperationExecuted;
                    manager = null;
                }
                if (logger != null)
                {
                    logger = null;
                }
                if(current_user != null)
                {
                    current_user = null;
                }
                if(users != null)
                {
                    users.Clear();
                    users = null;
                }
                if(ent != null)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchUsers));
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblBirthDateFrom = new System.Windows.Forms.Label();
            this.dtBirthDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDateTo = new System.Windows.Forms.Label();
            this.dtBirthDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.trbBalance = new System.Windows.Forms.TrackBar();
            this.lblDiagnose = new System.Windows.Forms.Label();
            this.txtDiagnose = new System.Windows.Forms.TextBox();
            this.lblRegisterDateFrom = new System.Windows.Forms.Label();
            this.dtRegisterDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblRegisterDateTo = new System.Windows.Forms.Label();
            this.dtRegisterDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbSearchMode = new System.Windows.Forms.ComboBox();
            this.lblSearchMode = new System.Windows.Forms.Label();
            this.btnAddOrEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblUserNotice = new System.Windows.Forms.Label();
            this.ttSearchUsers = new System.Windows.Forms.ToolTip(this.components);
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfilePicColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.BalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnoseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBalance)).BeginInit();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.UsernameColumn,
            this.PasswordColumn,
            this.DisplayNameColumn,
            this.BirthDateColumn,
            this.PhoneColumn,
            this.EmailColumn,
            this.AddressColumn,
            this.ProfilePicColumn,
            this.BalanceColumn,
            this.DiagnoseColumn,
            this.RegisterDateColumn,
            this.RoleColumn});
            this.dgvUsers.DataSource = this.userBindingSource;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 351);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(917, 99);
            this.dgvUsers.TabIndex = 1;
            this.ttSearchUsers.SetToolTip(this.dgvUsers, GLOBAL_RESOURCES.DGV_USERS_TOOLTIP_TITLE);
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            this.dgvUsers.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvUsers_RowsAdded);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(XtremePharmacyManager.DataEntities.User);
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
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Location = new System.Drawing.Point(136, 14);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(258, 22);
            this.txtID.TabIndex = 2;
            this.ttSearchUsers.SetToolTip(this.txtID, GLOBAL_RESOURCES.ID_SEARCH_TOOLTIP_TITLE);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(19, 45);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(82, 16);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = GLOBAL_RESOURCES.LBL_USERNAME_TITLE;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUsername.Location = new System.Drawing.Point(136, 42);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(258, 22);
            this.txtUsername.TabIndex = 4;
            this.ttSearchUsers.SetToolTip(this.txtUsername, GLOBAL_RESOURCES.USERNAME_SEARCH_TOOLTIP_TITLE);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(19, 73);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 16);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = GLOBAL_RESOURCES.LBL_PASSWORD_TITLE;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPassword.Location = new System.Drawing.Point(136, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(258, 22);
            this.txtPassword.TabIndex = 6;
            this.ttSearchUsers.SetToolTip(this.txtPassword, GLOBAL_RESOURCES.PASSWORD_SEARCH_TOOLTIP_TITLE);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(19, 101);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(109, 16);
            this.lblDisplayName.TabIndex = 7;
            this.lblDisplayName.Text = GLOBAL_RESOURCES.LBL_DISPLAY_NAME_TITLE;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDisplayName.Location = new System.Drawing.Point(136, 98);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(258, 22);
            this.txtDisplayName.TabIndex = 8;
            this.ttSearchUsers.SetToolTip(this.txtDisplayName, GLOBAL_RESOURCES.DISPLAY_NAME_SEARCH_TOOLTIP_TITLE);
            // 
            // lblBirthDateFrom
            // 
            this.lblBirthDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBirthDateFrom.AutoSize = true;
            this.lblBirthDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDateFrom.Location = new System.Drawing.Point(19, 129);
            this.lblBirthDateFrom.Name = "lblBirthDateFrom";
            this.lblBirthDateFrom.Size = new System.Drawing.Size(118, 16);
            this.lblBirthDateFrom.TabIndex = 9;
            this.lblBirthDateFrom.Text = GLOBAL_RESOURCES.LBL_USER_B_DATE_FROM_TITLE;
            // 
            // dtBirthDateFrom
            // 
            this.dtBirthDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtBirthDateFrom.Location = new System.Drawing.Point(143, 129);
            this.dtBirthDateFrom.Name = "dtBirthDateFrom";
            this.dtBirthDateFrom.Size = new System.Drawing.Size(251, 22);
            this.dtBirthDateFrom.TabIndex = 10;
            this.ttSearchUsers.SetToolTip(this.dtBirthDateFrom, GLOBAL_RESOURCES.USER_B_DATE_FROM_SEARCH_TOOLTIP);
            // 
            // lblBirthDateTo
            // 
            this.lblBirthDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBirthDateTo.AutoSize = true;
            this.lblBirthDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDateTo.Location = new System.Drawing.Point(20, 158);
            this.lblBirthDateTo.Name = "lblBirthDateTo";
            this.lblBirthDateTo.Size = new System.Drawing.Size(102, 16);
            this.lblBirthDateTo.TabIndex = 11;
            this.lblBirthDateTo.Text = GLOBAL_RESOURCES.LBL_USER_B_DATE_TO_TITLE;
            // 
            // dtBirthDateTo
            // 
            this.dtBirthDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtBirthDateTo.Location = new System.Drawing.Point(144, 158);
            this.dtBirthDateTo.Name = "dtBirthDateTo";
            this.dtBirthDateTo.Size = new System.Drawing.Size(251, 22);
            this.dtBirthDateTo.TabIndex = 12;
            this.ttSearchUsers.SetToolTip(this.dtBirthDateTo, GLOBAL_RESOURCES.USER_B_DATE_TO_SEARCH_TOOLTIP);
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(19, 189);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 16);
            this.lblPhone.TabIndex = 13;
            this.lblPhone.Text = GLOBAL_RESOURCES.LBL_PHONE_TITLE;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPhone.Location = new System.Drawing.Point(136, 186);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(258, 22);
            this.txtPhone.TabIndex = 14;
            this.ttSearchUsers.SetToolTip(this.txtPhone, GLOBAL_RESOURCES.PHONE_SEARCH_TOOLTIP_TITLE);
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(19, 217);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 16);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = GLOBAL_RESOURCES.LBL_EMAIL_TITLE;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(136, 214);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(258, 22);
            this.txtEmail.TabIndex = 16;
            this.ttSearchUsers.SetToolTip(this.txtEmail, GLOBAL_RESOURCES.EMAIL_SEARCH_TOOLTIP_TITLE);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(19, 245);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(69, 16);
            this.lblAddress.TabIndex = 17;
            this.lblAddress.Text = GLOBAL_RESOURCES.LBL_ADDRESS_TITLE;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAddress.Location = new System.Drawing.Point(136, 242);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(258, 52);
            this.txtAddress.TabIndex = 18;
            this.ttSearchUsers.SetToolTip(this.txtAddress, GLOBAL_RESOURCES.ADDRESS_SEARCH_TOOLTIP_TITLE);
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(515, 17);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(68, 16);
            this.lblBalance.TabIndex = 19;
            this.lblBalance.Text = GLOBAL_RESOURCES.LBL_BALANCE_TITLE;
            // 
            // trbBalance
            // 
            this.trbBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trbBalance.Location = new System.Drawing.Point(592, 18);
            this.trbBalance.Maximum = 5000;
            this.trbBalance.Name = "trbBalance";
            this.trbBalance.Size = new System.Drawing.Size(259, 56);
            this.trbBalance.TabIndex = 21;
            this.ttSearchUsers.SetToolTip(this.trbBalance, GLOBAL_RESOURCES.BALANCE_SEARCH_TOOLTIP_TITLE);
            this.trbBalance.Scroll += new System.EventHandler(this.trbBalance_Scroll);
            // 
            // lblDiagnose
            // 
            this.lblDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiagnose.AutoSize = true;
            this.lblDiagnose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnose.Location = new System.Drawing.Point(514, 60);
            this.lblDiagnose.Name = "lblDiagnose";
            this.lblDiagnose.Size = new System.Drawing.Size(78, 16);
            this.lblDiagnose.TabIndex = 22;
            this.lblDiagnose.Text = GLOBAL_RESOURCES.LBL_DIAGNOSE_TITLE;
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnose.Location = new System.Drawing.Point(592, 57);
            this.txtDiagnose.Multiline = true;
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.Size = new System.Drawing.Size(313, 63);
            this.txtDiagnose.TabIndex = 23;
            this.ttSearchUsers.SetToolTip(this.txtDiagnose, GLOBAL_RESOURCES.DIAGNOSE_SEARCH_TOOLTIP_TITLE);
            // 
            // lblRegisterDateFrom
            // 
            this.lblRegisterDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegisterDateFrom.AutoSize = true;
            this.lblRegisterDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterDateFrom.Location = new System.Drawing.Point(519, 123);
            this.lblRegisterDateFrom.Name = "lblRegisterDateFrom";
            this.lblRegisterDateFrom.Size = new System.Drawing.Size(150, 16);
            this.lblRegisterDateFrom.TabIndex = 24;
            this.lblRegisterDateFrom.Text = GLOBAL_RESOURCES.LBL_USER_REG_DATE_FROM_TITLE;
            // 
            // dtRegisterDateFrom
            // 
            this.dtRegisterDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegisterDateFrom.Location = new System.Drawing.Point(676, 123);
            this.dtRegisterDateFrom.Name = "dtRegisterDateFrom";
            this.dtRegisterDateFrom.Size = new System.Drawing.Size(229, 22);
            this.dtRegisterDateFrom.TabIndex = 25;
            this.ttSearchUsers.SetToolTip(this.dtRegisterDateFrom, GLOBAL_RESOURCES.USER_REG_DATE_FROM_SEARCH_TOOLTIP);
            // 
            // lblRegisterDateTo
            // 
            this.lblRegisterDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegisterDateTo.AutoSize = true;
            this.lblRegisterDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterDateTo.Location = new System.Drawing.Point(520, 152);
            this.lblRegisterDateTo.Name = "lblRegisterDateTo";
            this.lblRegisterDateTo.Size = new System.Drawing.Size(134, 16);
            this.lblRegisterDateTo.TabIndex = 26;
            this.lblRegisterDateTo.Text = GLOBAL_RESOURCES.LBL_USER_REG_DATE_TO_TITLE;
            // 
            // dtRegisterDateTo
            // 
            this.dtRegisterDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegisterDateTo.Location = new System.Drawing.Point(676, 152);
            this.dtRegisterDateTo.Name = "dtRegisterDateTo";
            this.dtRegisterDateTo.Size = new System.Drawing.Size(229, 22);
            this.dtRegisterDateTo.TabIndex = 27;
            this.ttSearchUsers.SetToolTip(this.dtRegisterDateTo, GLOBAL_RESOURCES.USER_REG_DATE_TO_SEARCH_TOOLTIP);
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(519, 178);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(44, 16);
            this.lblRole.TabIndex = 28;
            this.lblRole.Text = GLOBAL_RESOURCES.LBL_ROLE_TITLE;
            // 
            // cbRole
            // 
            this.cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            GLOBAL_RESOURCES.LBL_ROLE_ADMIN,
            GLOBAL_RESOURCES.LBL_ROLE_EMPLOYEE,
            GLOBAL_RESOURCES.LBL_ROLE_CLIENT});
            this.cbRole.Location = new System.Drawing.Point(676, 181);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(229, 24);
            this.cbRole.TabIndex = 29;
            this.cbRole.Text = GLOBAL_RESOURCES.LBL_ROLE_EMPLOYEE;
            this.ttSearchUsers.SetToolTip(this.cbRole, GLOBAL_RESOURCES.ROLE_SEARCH_TOOLTIP_TITLE);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(2, 301);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 47);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = GLOBAL_RESOURCES.BTN_SEARCH_TITLE;
            this.ttSearchUsers.SetToolTip(this.btnSearch, GLOBAL_RESOURCES.BTN_SEARCH_TOOLTIP_TITLE);
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.cbSearchMode.Location = new System.Drawing.Point(676, 211);
            this.cbSearchMode.Name = "cbSearchMode";
            this.cbSearchMode.Size = new System.Drawing.Size(229, 24);
            this.cbSearchMode.TabIndex = 31;
            this.cbSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_MULTIPLE;
            this.ttSearchUsers.SetToolTip(this.cbSearchMode, GLOBAL_RESOURCES.CB_SEARCH_MODE_TOOLTIP_TITLE);
            // 
            // lblSearchMode
            // 
            this.lblSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchMode.AutoSize = true;
            this.lblSearchMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchMode.Location = new System.Drawing.Point(520, 214);
            this.lblSearchMode.Name = "lblSearchMode";
            this.lblSearchMode.Size = new System.Drawing.Size(103, 16);
            this.lblSearchMode.TabIndex = 32;
            this.lblSearchMode.Text = GLOBAL_RESOURCES.LBL_SEARCH_MODE_TITLE;
            // 
            // btnAddOrEdit
            // 
            this.btnAddOrEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOrEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrEdit.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrEdit.Location = new System.Drawing.Point(99, 301);
            this.btnAddOrEdit.Name = "btnAddOrEdit";
            this.btnAddOrEdit.Size = new System.Drawing.Size(90, 47);
            this.btnAddOrEdit.TabIndex = 33;
            this.btnAddOrEdit.Text = GLOBAL_RESOURCES.BTN_ADD_EDIT_TITLE;
            this.ttSearchUsers.SetToolTip(this.btnAddOrEdit, GLOBAL_RESOURCES.BTN_ADD_EDIT_TOOLTIP_TITLE);
            this.btnAddOrEdit.UseVisualStyleBackColor = true;
            this.btnAddOrEdit.Click += new System.EventHandler(this.btnAddOrEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(195, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 47);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = GLOBAL_RESOURCES.BTN_DELETE_TITLE;
            this.ttSearchUsers.SetToolTip(this.btnDelete, GLOBAL_RESOURCES.BTN_DELETE_TOOLTIP_TITLE);
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.Controls.Add(this.txtBalance);
            this.pnlData.Controls.Add(this.btnGenerateReport);
            this.pnlData.Controls.Add(this.lblUserNotice);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnAddOrEdit);
            this.pnlData.Controls.Add(this.lblSearchMode);
            this.pnlData.Controls.Add(this.cbSearchMode);
            this.pnlData.Controls.Add(this.btnSearch);
            this.pnlData.Controls.Add(this.cbRole);
            this.pnlData.Controls.Add(this.lblRole);
            this.pnlData.Controls.Add(this.dtRegisterDateTo);
            this.pnlData.Controls.Add(this.lblRegisterDateTo);
            this.pnlData.Controls.Add(this.dtRegisterDateFrom);
            this.pnlData.Controls.Add(this.lblRegisterDateFrom);
            this.pnlData.Controls.Add(this.txtDiagnose);
            this.pnlData.Controls.Add(this.lblDiagnose);
            this.pnlData.Controls.Add(this.trbBalance);
            this.pnlData.Controls.Add(this.lblBalance);
            this.pnlData.Controls.Add(this.txtAddress);
            this.pnlData.Controls.Add(this.lblAddress);
            this.pnlData.Controls.Add(this.txtEmail);
            this.pnlData.Controls.Add(this.lblEmail);
            this.pnlData.Controls.Add(this.txtPhone);
            this.pnlData.Controls.Add(this.lblPhone);
            this.pnlData.Controls.Add(this.dtBirthDateTo);
            this.pnlData.Controls.Add(this.lblBirthDateTo);
            this.pnlData.Controls.Add(this.dtBirthDateFrom);
            this.pnlData.Controls.Add(this.lblBirthDateFrom);
            this.pnlData.Controls.Add(this.txtDisplayName);
            this.pnlData.Controls.Add(this.lblDisplayName);
            this.pnlData.Controls.Add(this.txtPassword);
            this.pnlData.Controls.Add(this.lblPassword);
            this.pnlData.Controls.Add(this.txtUsername);
            this.pnlData.Controls.Add(this.lblUsername);
            this.pnlData.Controls.Add(this.txtID);
            this.pnlData.Controls.Add(this.lblID);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(917, 351);
            this.pnlData.TabIndex = 0;
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.Location = new System.Drawing.Point(858, 18);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(47, 22);
            this.txtBalance.TabIndex = 45;
            this.ttSearchUsers.SetToolTip(this.txtBalance, GLOBAL_RESOURCES.BALANCE_SEARCH_TOOLTIP_TITLE);
            this.txtBalance.TextChanged += new System.EventHandler(this.txtBalance_TextChanged);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(291, 301);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(175, 47);
            this.btnGenerateReport.TabIndex = 44;
            this.btnGenerateReport.Text = GLOBAL_RESOURCES.BTN_GENERATE_REPORT_TITLE;
            this.ttSearchUsers.SetToolTip(this.btnGenerateReport, GLOBAL_RESOURCES.BTN_GENERATE_REPORT_TOOLTIP_TITLE);
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblUserNotice
            // 
            this.lblUserNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNotice.AutoSize = true;
            this.lblUserNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNotice.ForeColor = System.Drawing.Color.Firebrick;
            this.lblUserNotice.Location = new System.Drawing.Point(520, 238);
            this.lblUserNotice.Name = "lblUserNotice";
            this.lblUserNotice.Size = new System.Drawing.Size(179, 48);
            this.lblUserNotice.TabIndex = 43;
            this.lblUserNotice.Text = GLOBAL_RESOURCES.LBL_USER_NOTICE_TITLE;
            this.ttSearchUsers.SetToolTip(this.lblUserNotice, GLOBAL_RESOURCES.USER_NOTICE_TOOLTIP_TITLE);
            // 
            // ttSearchUsers
            // 
            this.ttSearchUsers.IsBalloon = true;
            this.ttSearchUsers.ShowAlways = true;
            this.ttSearchUsers.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSearchUsers.ToolTipTitle = GLOBAL_RESOURCES.HELP_TOOLTIP_TITLE;
            // 
            // IDColumn
            // 
            this.IDColumn.DataPropertyName = "ID";
            this.IDColumn.HeaderText = GLOBAL_RESOURCES.USER_ID_COL_TITLE;
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 125;
            // 
            // UsernameColumn
            // 
            this.UsernameColumn.DataPropertyName = "UserName";
            this.UsernameColumn.HeaderText = GLOBAL_RESOURCES.USER_NAME_COL_TITLE;
            this.UsernameColumn.MinimumWidth = 6;
            this.UsernameColumn.Name = "UsernameColumn";
            this.UsernameColumn.ReadOnly = true;
            this.UsernameColumn.Width = 125;
            // 
            // PasswordColumn
            // 
            this.PasswordColumn.DataPropertyName = "UserPassword";
            this.PasswordColumn.HeaderText = GLOBAL_RESOURCES.PASSWORD_COL_TITLE;
            this.PasswordColumn.MinimumWidth = 6;
            this.PasswordColumn.Name = "PasswordColumn";
            this.PasswordColumn.ReadOnly = true;
            this.PasswordColumn.Width = 125;
            // 
            // DisplayNameColumn
            // 
            this.DisplayNameColumn.DataPropertyName = "UserDisplayName";
            this.DisplayNameColumn.HeaderText = GLOBAL_RESOURCES.DISPLAY_NAME_COL_TITLE;
            this.DisplayNameColumn.MinimumWidth = 6;
            this.DisplayNameColumn.Name = "DisplayNameColumn";
            this.DisplayNameColumn.ReadOnly = true;
            this.DisplayNameColumn.Width = 125;
            // 
            // BirthDateColumn
            // 
            this.BirthDateColumn.DataPropertyName = "UserBirthDate";
            this.BirthDateColumn.HeaderText = GLOBAL_RESOURCES.BIRTH_DATE_COL_TITLE;
            this.BirthDateColumn.MinimumWidth = 6;
            this.BirthDateColumn.Name = "BirthDateColumn";
            this.BirthDateColumn.ReadOnly = true;
            this.BirthDateColumn.Width = 125;
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.DataPropertyName = "UserPhone";
            this.PhoneColumn.HeaderText = GLOBAL_RESOURCES.PHONE_COL_TITLE;
            this.PhoneColumn.MinimumWidth = 6;
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.ReadOnly = true;
            this.PhoneColumn.Width = 125;
            // 
            // EmailColumn
            // 
            this.EmailColumn.DataPropertyName = "UserEmail";
            this.EmailColumn.HeaderText = GLOBAL_RESOURCES.EMAIL_COL_TITLE;
            this.EmailColumn.MinimumWidth = 6;
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            this.EmailColumn.Width = 125;
            // 
            // AddressColumn
            // 
            this.AddressColumn.DataPropertyName = "UserAddress";
            this.AddressColumn.HeaderText = GLOBAL_RESOURCES.ADDRESS_COL_TITLE;
            this.AddressColumn.MinimumWidth = 6;
            this.AddressColumn.Name = "AddressColumn";
            this.AddressColumn.ReadOnly = true;
            this.AddressColumn.Width = 125;
            // 
            // ProfilePicColumn
            // 
            this.ProfilePicColumn.DataPropertyName = "UserProfilePic";
            this.ProfilePicColumn.HeaderText = GLOBAL_RESOURCES.PROFILE_PIC_COL_TITLE;
            this.ProfilePicColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ProfilePicColumn.MinimumWidth = 6;
            this.ProfilePicColumn.Name = "ProfilePicColumn";
            this.ProfilePicColumn.ReadOnly = true;
            this.ProfilePicColumn.Width = 125;
            // 
            // BalanceColumn
            // 
            this.BalanceColumn.DataPropertyName = "UserBalance";
            this.BalanceColumn.HeaderText = GLOBAL_RESOURCES.BALANCE_COL_TITLE;
            this.BalanceColumn.MinimumWidth = 6;
            this.BalanceColumn.Name = "BalanceColumn";
            this.BalanceColumn.ReadOnly = true;
            this.BalanceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BalanceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BalanceColumn.Width = 125;
            // 
            // DiagnoseColumn
            // 
            this.DiagnoseColumn.DataPropertyName = "UserDiagnose";
            this.DiagnoseColumn.HeaderText = GLOBAL_RESOURCES.DIAGNOSE_COL_TITLE;
            this.DiagnoseColumn.MinimumWidth = 6;
            this.DiagnoseColumn.Name = "DiagnoseColumn";
            this.DiagnoseColumn.ReadOnly = true;
            this.DiagnoseColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DiagnoseColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiagnoseColumn.Width = 125;
            // 
            // RegisterDateColumn
            // 
            this.RegisterDateColumn.DataPropertyName = "UserDateOfRegister";
            this.RegisterDateColumn.HeaderText = GLOBAL_RESOURCES.REGISTER_DATE_COL_TITLE;
            this.RegisterDateColumn.MinimumWidth = 6;
            this.RegisterDateColumn.Name = "RegisterDateColumn";
            this.RegisterDateColumn.ReadOnly = true;
            this.RegisterDateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RegisterDateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RegisterDateColumn.Width = 125;
            // 
            // RoleColumn
            // 
            this.RoleColumn.HeaderText = GLOBAL_RESOURCES.ROLE_COL_TITLE;
            this.RoleColumn.Items.AddRange(new object[] {
            GLOBAL_RESOURCES.LBL_ROLE_ADMIN,
            GLOBAL_RESOURCES.LBL_ROLE_EMPLOYEE,
            GLOBAL_RESOURCES.LBL_ROLE_CLIENT});
            this.RoleColumn.MinimumWidth = 6;
            this.RoleColumn.Name = "RoleColumn";
            this.RoleColumn.ReadOnly = true;
            this.RoleColumn.Width = 125;
            // 
            // frmSearchUsers
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlData);
            this.MaximizeBox = false;
            this.Name = "frmSearchUsers";
            this.Text = GLOBAL_RESOURCES.USERS_TITLE;
            this.ttSearchUsers.SetToolTip(this, GLOBAL_RESOURCES.USERS_TOOLTIP_TITLE);
            this.Load += new System.EventHandler(this.frmSearchUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBalance)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.BindingSource userBindingSource;
        private Label lblID;
        private TextBox txtID;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblDisplayName;
        private TextBox txtDisplayName;
        private Label lblBirthDateFrom;
        private DateTimePicker dtBirthDateFrom;
        private Label lblBirthDateTo;
        private DateTimePicker dtBirthDateTo;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblBalance;
        private TrackBar trbBalance;
        private Label lblDiagnose;
        private TextBox txtDiagnose;
        private Label lblRegisterDateFrom;
        private DateTimePicker dtRegisterDateFrom;
        private Label lblRegisterDateTo;
        private DateTimePicker dtRegisterDateTo;
        private Label lblRole;
        private ComboBox cbRole;
        private Button btnSearch;
        private ComboBox cbSearchMode;
        private Label lblSearchMode;
        private Button btnAddOrEdit;
        private Button btnDelete;
        private Panel pnlData;
        private Label lblUserNotice;
        private Button btnGenerateReport;
        private TextBox txtBalance;
        private ToolTip ttSearchUsers;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewTextBoxColumn PasswordColumn;
        private DataGridViewTextBoxColumn DisplayNameColumn;
        private DataGridViewTextBoxColumn BirthDateColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn AddressColumn;
        private DataGridViewImageColumn ProfilePicColumn;
        private DataGridViewTextBoxColumn BalanceColumn;
        private DataGridViewTextBoxColumn DiagnoseColumn;
        private DataGridViewTextBoxColumn RegisterDateColumn;
        private DataGridViewComboBoxColumn RoleColumn;
    }
}