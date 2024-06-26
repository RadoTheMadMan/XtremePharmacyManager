﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static XtremePharmacyManager.ImageBinConverter;
namespace XtremePharmacyManager
{
    public partial class frmBulkUserOperations : Form
    {
        static BulkOperationManager<User> manager;
        BulkOperation<User> selected_operation;
        User current_user;
        static User selected_target;
        static List<User> entries;
        static Entities manager_entities;
        public frmBulkUserOperations(ref BulkOperationManager<User> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            current_user = manager.CurrentUser;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<User> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.Users.ToList();
                foreach(var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Users.Where(x=>x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Users.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
            }
        }


        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<User> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.Users.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Users.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                lblOperationResults.Text = $"{GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT}";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Users.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
            }
        }




        private void frmBulkUserOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            entries = manager_entities.Users.ToList();
            foreach (var entry in entries)
            {
                manager_entities.Entry(manager_entities.Users.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbSelectRecord.DataSource = entries;
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    if (selected_target.UserProfilePic != null) { ConvertBinaryToImage(selected_target.UserProfilePic, out currentpfp); }
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtUsername.Text = (!String.IsNullOrEmpty(selected_target.UserName)) ? selected_target.UserName.ToString() : string.Empty;
                    this.txtPassword.Text = (!String.IsNullOrEmpty(selected_target.UserPassword)) ? selected_target.UserPassword.ToString() : string.Empty;
                    this.txtDisplayName.Text = (!String.IsNullOrEmpty(selected_target.UserDisplayName)) ? selected_target.UserDisplayName.ToString() : string.Empty;
                    this.dtBirthDate.Value = (selected_target.UserBirthDate != null && selected_target.UserBirthDate > DateTime.MinValue && selected_target.UserBirthDate < DateTime.MaxValue) ? selected_target.UserBirthDate : DateTime.Now;
                    this.txtPhone.Text = (!String.IsNullOrEmpty(selected_target.UserPhone)) ? selected_target.UserPhone.ToString() : string.Empty;
                    this.txtEmail.Text = (!String.IsNullOrEmpty(selected_target.UserEmail)) ? selected_target.UserEmail.ToString() : string.Empty;
                    this.txtAddress.Text = (!String.IsNullOrEmpty(selected_target.UserAddress)) ? selected_target.UserAddress.ToString() : string.Empty;
                    txtBalance.Text = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance).ToString() : string.Empty;
                    trbBalance.Value = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance) : 0;
                    txtDiagnose.Text = (!String.IsNullOrEmpty(selected_target.UserDiagnose)) ? selected_target.UserDiagnose : string.Empty;
                    cbRole.SelectedIndex = (selected_target.UserRole >= 0 && selected_target.UserRole <= 2) ? selected_target.UserRole : 1;
                    pbUserProfilePic.Image = (selected_target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                    cbSelectRecord.SelectedValue = selected_target.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.Users.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Users.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
            }
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0)
                {
                    manager.ExecuteOperations();
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_USER_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0)
                {
                    if (selected_target != null)
                    {
                        selected_target.UserDisplayName = txtDisplayName.Text;
                        selected_target.UserBirthDate = dtBirthDate.Value;
                        selected_target.UserPhone = txtPhone.Text;
                        selected_target.UserEmail = txtEmail.Text;
                        selected_target.UserAddress = txtAddress.Text;
                        selected_target.UserBalance = trbBalance.Value;
                        selected_target.UserDiagnose = txtDiagnose.Text;
                        selected_target.UserRole = cbRole.SelectedIndex;
                        if (pbUserProfilePic.Image != null)
                        {
                            Bitmap current_image = (Bitmap)pbUserProfilePic.Image;
                            byte[] image_data;
                            ConvertImageToBinary(current_image, out image_data);
                            selected_target.UserProfilePic = image_data;
                        }
                    }
                    if (selected_operation != null)
                    {
                        selected_operation.UpdateTargetObject(selected_target);
                        selected_operation.OperationType = (BulkOperationType)cbOperationType.SelectedIndex;
                        selected_operation.IsSilent = checkSilentOperation.Checked;
                        selected_operation.UpdateName();
                        manager.UpdateAllOperations(selected_operation);
                    };
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_USER_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstBulkOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox current = (ListBox)sender;
            try
            {
                if (current.SelectedItems.Count > 0 || (current.SelectedIndex >= 0 && current.SelectedIndex < current.Items.Count))
                {
                    selected_operation = current.Items[current.SelectedIndex] as BulkUserOperation;
                    selected_target = selected_operation.TargetObject;
                }
                Bitmap currentpfp = new Bitmap(64, 64);
                if (selected_operation != null && selected_target != null)
                {
                    if (selected_target.UserProfilePic != null) { ConvertBinaryToImage(selected_target.UserProfilePic, out currentpfp); }
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtUsername.Text = (!String.IsNullOrEmpty(selected_target.UserName)) ? selected_target.UserName.ToString() : string.Empty;
                    this.txtPassword.Text = (!String.IsNullOrEmpty(selected_target.UserPassword)) ? selected_target.UserPassword.ToString() : string.Empty;
                    this.txtDisplayName.Text = (!String.IsNullOrEmpty(selected_target.UserDisplayName)) ? selected_target.UserDisplayName.ToString() : string.Empty;
                    this.dtBirthDate.Value = (selected_target.UserBirthDate != null && selected_target.UserBirthDate > DateTime.MinValue && selected_target.UserBirthDate < DateTime.MaxValue) ? selected_target.UserBirthDate : DateTime.Now;
                    this.txtPhone.Text = (!String.IsNullOrEmpty(selected_target.UserPhone)) ? selected_target.UserPhone.ToString() : string.Empty;
                    this.txtEmail.Text = (!String.IsNullOrEmpty(selected_target.UserEmail)) ? selected_target.UserEmail.ToString() : string.Empty;
                    this.txtAddress.Text = (!String.IsNullOrEmpty(selected_target.UserAddress)) ? selected_target.UserAddress.ToString() : string.Empty;
                    txtBalance.Text = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance).ToString() : string.Empty;
                    trbBalance.Value = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance) : 0;
                    txtDiagnose.Text = (!String.IsNullOrEmpty(selected_target.UserDiagnose)) ? selected_target.UserDiagnose : string.Empty;
                    cbRole.SelectedIndex = (selected_target.UserRole >= 0 && selected_target.UserRole <= 2) ? selected_target.UserRole : 1;
                    pbUserProfilePic.Image = (selected_target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                    cbSelectRecord.SelectedValue = selected_target.ID;
                }
                lblOperationResults.Text = $"{GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT}";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsSilent = checkSilentOperation.Checked;
                BulkOperationType operationType = (BulkOperationType)cbOperationType.SelectedIndex;
                Bitmap current_image = (Bitmap)pbUserProfilePic.Image;
                byte[] image_bytes;
                ConvertImageToBinary(current_image, out image_bytes);
                if (current_user.UserRole == 0)
                {
                    manager.AddOperation(new BulkUserOperation(operationType, ref manager_entities, new User()
                    {
                        ID = Int32.Parse(txtID.Text),
                        UserName = txtUsername.Text,
                        UserPassword = txtPassword.Text,
                        UserDisplayName = txtDisplayName.Text,
                        UserBirthDate = dtBirthDate.Value,
                        UserPhone = txtPhone.Text,
                        UserEmail = txtEmail.Text,
                        UserAddress = txtAddress.Text,
                        UserProfilePic = image_bytes,
                        UserBalance = Convert.ToDecimal(trbBalance.Value),
                        UserDiagnose = txtDiagnose.Text,
                        UserRole = cbRole.SelectedIndex
                    }, IsSilent));
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_USER_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            //Remove it from the list of the manager and nullify it here
            try
            {
                if (selected_operation != null)
                {
                    if (current_user.UserRole == 0)
                    {
                        manager.RemoveOperation(selected_operation);
                    }
                    else
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.BULK_USER_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    selected_target = null;
                    selected_operation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToCurrentTarget_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0)
                {
                    if (selected_target != null)
                    {
                        selected_target.UserDisplayName = txtDisplayName.Text;
                        selected_target.UserBirthDate = dtBirthDate.Value;
                        selected_target.UserPhone = txtPhone.Text;
                        selected_target.UserEmail = txtEmail.Text;
                        selected_target.UserAddress = txtAddress.Text;
                        selected_target.UserBalance = trbBalance.Value;
                        selected_target.UserDiagnose = txtDiagnose.Text;
                        selected_target.UserRole = cbRole.SelectedIndex;
                        if (pbUserProfilePic.Image != null)
                        {
                            Bitmap current_image = (Bitmap)pbUserProfilePic.Image;
                            byte[] image_data;
                            ConvertImageToBinary(current_image, out image_data);
                            selected_target.UserProfilePic = image_data;
                        }
                    }
                    if (selected_operation != null)
                    {
                        int operation_index = manager.BulkOperations.IndexOf(selected_operation);
                        BulkOperationType current_type = (BulkOperationType)cbOperationType.SelectedIndex;
                        bool IsSilent = checkSilentOperation.Checked;
                        selected_operation.UpdateTargetObject(selected_target);
                        selected_operation.OperationType = current_type;
                        selected_operation.IsSilent = IsSilent;
                        selected_operation.UpdateName();
                        manager.UpdateOperation(selected_operation);
                    }
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_USER_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbUserProfilePic_Click(object sender, EventArgs e)
        {
            PictureBox current = (PictureBox)sender;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = "Select an image to upload or for bulk operation";
            if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
            {
                Bitmap selectedImage = new Bitmap(ofd.FileName);
                current.Image = new Bitmap(selectedImage);
            }
        }

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            txtBalance.Text = ((TrackBar)sender).Value.ToString();
        }

        private void cbSelectRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            User selected_record = (User)cbSelectRecord.SelectedItem;
            try
            {
               if(selected_record != null)
                {
                    if (selected_record.UserProfilePic != null) { ConvertBinaryToImage(selected_record.UserProfilePic, out currentpfp); }
                    this.txtID.Text = (selected_record.ID >= 0) ? selected_record.ID.ToString() : string.Empty;
                    this.txtUsername.Text = (!String.IsNullOrEmpty(selected_record.UserName)) ? selected_record.UserName.ToString() : string.Empty;
                    this.txtPassword.Text = (!String.IsNullOrEmpty(selected_record.UserPassword)) ? selected_record.UserPassword.ToString() : string.Empty;
                    this.txtDisplayName.Text = (!String.IsNullOrEmpty(selected_record.UserDisplayName)) ? selected_record.UserDisplayName.ToString() : string.Empty;
                    this.dtBirthDate.Value = (selected_record.UserBirthDate != null && selected_record.UserBirthDate > DateTime.MinValue && selected_record.UserBirthDate < DateTime.MaxValue) ? selected_record.UserBirthDate : DateTime.Now;
                    this.txtPhone.Text = (!String.IsNullOrEmpty(selected_record.UserPhone)) ? selected_record.UserPhone.ToString() : string.Empty;
                    this.txtEmail.Text = (!String.IsNullOrEmpty(selected_record.UserEmail)) ? selected_record.UserEmail.ToString() : string.Empty;
                    this.txtAddress.Text = (!String.IsNullOrEmpty(selected_record.UserAddress)) ? selected_record.UserAddress.ToString() : string.Empty;
                    txtBalance.Text = (selected_record.UserBalance >= 0) ? Convert.ToInt32(selected_record.UserBalance).ToString() : string.Empty;
                    trbBalance.Value = (selected_record.UserBalance >= 0) ? Convert.ToInt32(selected_record.UserBalance) : 0;
                    txtDiagnose.Text = (!String.IsNullOrEmpty(selected_record.UserDiagnose)) ? selected_record.UserDiagnose : string.Empty;
                    cbRole.SelectedIndex = (selected_record.UserRole >= 0 && selected_record.UserRole <= 2) ? selected_record.UserRole : 1;
                    pbUserProfilePic.Image = (selected_record.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                    cbSelectRecord.SelectedValue = selected_record.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblShowBalance_Click(object sender, EventArgs e)
        {

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(((TextBox)sender).Text, out value);
            if (value >= trbBalance.Maximum)
            {
                trbBalance.Maximum = value;
            }
            trbBalance.Value = value;
        }
    }
}
