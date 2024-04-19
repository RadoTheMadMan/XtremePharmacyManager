﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;

namespace XtremePharmacyManager
{
    public partial class frmSearchUsers : Form
    {
        static Entities ent;
        static List<User> users;
        static Logger logger;
        static BulkOperationManager<User> manager;
        public frmSearchUsers(ref Entities entity, ref Logger extlogger, ref BulkOperationManager<User> bulkusermanager)
        {
            ent = entity;
            logger = extlogger;
            manager = bulkusermanager;
            InitializeComponent();
        }

        private void RefreshUsers()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    users = ent.GetUser(-1, "", "", "", DateTime.Now, DateTime.Now, "", "", "", new decimal(), "", DateTime.Now, DateTime.Now, 0).ToList();
                    dgvUsers.DataSource = users;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            Int32.TryParse(txtID.Text, out UserID);
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;
            string DisplayName = txtDisplayName.Text;
            DateTime BirthDateFrom = dtBirthDateFrom.Value;
            DateTime BirthDateTo = dtBirthDateTo.Value;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;
            string Address = txtAddress.Text;
            decimal Balance = trbBalance.Value;
            string Diagnose = txtDiagnose.Text;
            DateTime RegisterDateFrom = dtRegisterDateFrom.Value;
            DateTime RegisterDateTo = dtRegisterDateTo.Value;
            int Role = cbRole.SelectedIndex;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                users = ent.Users.Where(
                    x => x.ID == UserID ^ x.UserName.Contains(UserName) ^ x.UserPassword.Contains(Password) ^
                        x.UserDisplayName.Contains(DisplayName) ^ (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ^
                        x.UserPhone.Contains(Phone) ^ x.UserEmail.Contains(Email) ^ x.UserAddress.Contains(Address) ^ (x.UserBalance <= Balance || x.UserBalance >= Balance) ^
                        x.UserDiagnose.Contains(Diagnose) ^ (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) ^ x.UserRole == Role
                ).ToList(); 
                dgvUsers.DataSource = users;
            }
            else if (SearchMode == 2)
            {
                users = ent.Users.Where(
                    x => x.ID == UserID || x.UserName.Contains(UserName) || x.UserPassword.Contains(Password) ||
                        x.UserDisplayName.Contains(DisplayName) || (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ||
                        x.UserPhone.Contains(Phone) || x.UserEmail.Contains(Email) || x.UserAddress.Contains(Address) || (x.UserBalance <= Balance || x.UserBalance >= Balance) ||
                        x.UserDiagnose.Contains(Diagnose) || (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) || x.UserRole == Role
                ).ToList();
                dgvUsers.DataSource = users;
            }
            else if (SearchMode == 3)
            {
                users = ent.GetUser(UserID,UserName,Password,DisplayName,BirthDateFrom,BirthDateTo,Phone,Email,Address,Balance,Diagnose,RegisterDateFrom,RegisterDateTo,Role).ToList();
                dgvUsers.DataSource = users;
            }
            else
            {
                RefreshUsers();
            }
            logger.RefreshLogs();
        }

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            lblShowBalance.Text = trbBalance.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int UserID = -1;
            User selectedUser;
            try
            {
                if (dgvUsers.SelectedRows.Count > 0)
                {
                    row = dgvUsers.SelectedRows[0];
                    if (row != null && users != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                        if (UserID > 0)
                        {
                            selectedUser = users.Where(x => x.ID == UserID).FirstOrDefault();
                            if (selectedUser != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateUserByID(selectedUser.ID, selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName,
                                            selectedUser.UserBirthDate, selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic,
                                            selectedUser.UserBalance, selectedUser.UserDiagnose, selectedUser.UserRole);
                                        ent.SaveChanges();
                                        RefreshUsers();
                                    }
                                }
                                else
                                {
                                    if(MessageBox.Show("Do you want to add this as a bulk operation?","Bulk Operations",MessageBoxButtons.YesNo,MessageBoxIcon.Question)  == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkUserOperation(BulkOperationType.UPDATE, ref ent, selectedUser, true));
                                    }
                                }
                            }
                            else
                            {
                                //Create a new user
                                selectedUser = new User();
                                //show the editor and after the editor confirms add it
                                DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                            selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                            selectedUser.UserDiagnose, selectedUser.UserRole);
                                        ent.SaveChanges();
                                        RefreshUsers();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkUserOperation(BulkOperationType.ADD, ref ent, selectedUser, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            selectedUser = new User();
                            DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                        selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                        selectedUser.UserDiagnose, selectedUser.UserRole);
                                    ent.SaveChanges();
                                    RefreshUsers();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkUserOperation(BulkOperationType.ADD, ref ent, selectedUser, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedUser = new User();
                    DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                selectedUser.UserDiagnose, selectedUser.UserRole);
                            ent.SaveChanges();
                            RefreshUsers();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkUserOperation(BulkOperationType.ADD, ref ent, selectedUser, true));
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int UserID = -1;
            User selectedUser;
            try
            {
                if (dgvUsers.SelectedRows.Count > 0)
                {
                    row = dgvUsers.SelectedRows[0];
                    if (row != null && users != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                        if (UserID > 0)
                        {
                            selectedUser = users.Where(x => x.ID == UserID).FirstOrDefault();
                            if (selectedUser != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteUserByID(selectedUser.ID);
                                        ent.SaveChanges();
                                        RefreshUsers();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkUserOperation(BulkOperationType.DELETE, ref ent, selectedUser, true));
                                    }
                                }
                            }
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int UserID = -1;
            User target_user;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                    if (UserID >= 0 && users != null)
                    {
                        target_user = users.Where(x => x.ID == UserID).FirstOrDefault();
                        if(target_user != null)
                        {
                            txtID.Text = target_user.ID.ToString();
                            txtUsername.Text = target_user.UserName.ToString();
                            txtPassword.Text = target_user.UserPassword.ToString();
                            txtDisplayName.Text = target_user.UserDisplayName.ToString();
                            dtBirthDateFrom.Value = target_user.UserBirthDate;
                            txtPhone.Text = target_user.UserPhone.ToString();
                            txtEmail.Text = target_user.UserEmail.ToString();
                            txtAddress.Text = target_user.UserAddress.ToString();
                            trbBalance.Value = Convert.ToInt32(target_user.UserBalance);
                            lblShowBalance.Text = target_user.UserBalance.ToString();
                            txtDiagnose.Text = target_user.UserDiagnose.ToString();
                            dtRegisterDateFrom.Value = target_user.UserDateOfRegister;
                            cbRole.SelectedIndex = target_user.UserRole;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView current = (DataGridView)sender;
            int UserID = -1;
            User currentUser;
            try
            {
                foreach (DataGridViewRow row in current.Rows)
                {
                    if (row != null && users != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                        if (users != null)
                        {
                            currentUser = users.Where(x => x.ID == UserID).FirstOrDefault();
                            if (currentUser != null)
                            {
                                DataGridViewComboBoxColumn rolecolumn = (DataGridViewComboBoxColumn)current.Columns["RoleColumn"];
                                rolecolumn.ValueMember = "UserRole";
                                row.Cells["RoleColumn"].Value = rolecolumn.Items[currentUser.UserRole];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchUsers_Load(object sender, EventArgs e)
        {
            RefreshUsers();
        }
    }
}
