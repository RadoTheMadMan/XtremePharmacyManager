using System;
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
        static BulkOperation<User> selected_operation;
        static User selected_target;
        static Entities manager_entities;
        public frmBulkUserOperations(ref BulkOperationManager<User> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs e)
        {
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = e.OperationsList;
            lblOperationResults.Text = lblOperationResults.Text + e.Result;
        }

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            lblShowBalance.Text = trbBalance.Value.ToString();
            if (selected_target != null)
            {
                selected_target.UserBalance = trbBalance.Value;
            }
        }

        private void pbUserProfilePic_Click(object sender, EventArgs e)
        {
            PictureBox current = (PictureBox)sender;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = "Select an image to upload or for bulk operation";
            if(selected_target != null)
            {
                if(ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
                {
                    Bitmap selectedImage = new Bitmap(ofd.FileName);
                    byte[] imageBytes;
                    ConvertImageToBinary(selectedImage, out imageBytes);
                    current.Image = new Bitmap(selectedImage);
                    selected_target.UserProfilePic = imageBytes;
                }
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserRole = cbRole.SelectedIndex;
            }
        }

        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {
            if (selected_target != null)
            {
                selected_target.UserDiagnose = txtDiagnose.Text;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(selected_target !=null)
            {
                selected_target.ID = Int32.Parse(txtID.Text);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if(selected_target !=null)
            {
                selected_target.UserName = txtUsername.Text;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserPassword = txtPassword.Text;
            }
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserDisplayName = txtDisplayName.Text;
            }
        }

        private void dtBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserBirthDate = dtBirthDate.Value;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserPhone = txtPhone.Text;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserEmail = txtEmail.Text; 
            }    
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if(selected_target != null)
            {
                selected_target.UserAddress = txtAddress.Text;
            }
        }

        private void frmBulkUserOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
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
                trbBalance.Value = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance) : 0;
                lblShowBalance.Text = (selected_target.UserBalance >= 0) ? selected_target.UserBalance.ToString() : string.Empty;
                txtDiagnose.Text = (!String.IsNullOrEmpty(selected_target.UserDiagnose)) ? selected_target.UserDiagnose : string.Empty;
                cbRole.SelectedIndex = (selected_target.UserRole >= 0 && selected_target.UserRole <= 2) ? selected_target.UserRole : 1;
                pbUserProfilePic.Image = (selected_target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
            }
            foreach(BulkUserOperation user_operation in manager.BulkOperations)
            {
                MessageBox.Show(user_operation.OperationName);
                MessageBox.Show(user_operation.TargetObject.UserDisplayName);
            }
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            manager.ExecuteOperations();
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {
            int current_operation_index = 0;
            BulkOperationType current_operation_type;
            User current_operation_target;
            bool current_operation_silent_value;
            foreach(BulkUserOperation operation in manager.BulkOperations)
            {
                current_operation_index = manager.BulkOperations.IndexOf(operation);
                current_operation_type = operation.OperationType;
                current_operation_silent_value = operation.IsSilent;
                current_operation_target = operation.TargetObject as User;
                current_operation_target.UserDisplayName = txtDisplayName.Text;
                current_operation_target.UserBirthDate = dtBirthDate.Value;
                current_operation_target.UserPhone = txtPhone.Text;
                current_operation_target.UserEmail = txtEmail.Text;
                current_operation_target.UserAddress = txtAddress.Text;
                current_operation_target.UserBalance = trbBalance.Value;
                current_operation_target.UserDiagnose = txtDiagnose.Text;
                current_operation_target.UserRole = cbRole.SelectedIndex;
                if (pbUserProfilePic.Image != null)
                {
                    Bitmap current_image = (Bitmap)pbUserProfilePic.Image;
                    byte[] image_data;
                    ConvertImageToBinary(current_image, out image_data);
                    current_operation_target.UserProfilePic = image_data;
                }
                selected_operation = new BulkUserOperation(current_operation_type, ref manager_entities, current_operation_target, current_operation_silent_value);
                manager.BulkOperations[current_operation_index] = selected_operation;
            }
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = manager.BulkOperations;
            lblOperationResults.Text = "Operation Results: ";
        }

        private void lstBulkOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox current = (ListBox)sender;
            if (current.SelectedItems.Count > 0 || ( current.SelectedIndex >= 0 && current.SelectedIndex < current.Items.Count))
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
                trbBalance.Value = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance) : 0;
                lblShowBalance.Text = (selected_target.UserBalance >= 0) ? selected_target.UserBalance.ToString() : string.Empty;
                txtDiagnose.Text = (!String.IsNullOrEmpty(selected_target.UserDiagnose)) ? selected_target.UserDiagnose : string.Empty;
                cbRole.SelectedIndex = (selected_target.UserRole >= 0 && selected_target.UserRole <= 2) ? selected_target.UserRole : 1;
                pbUserProfilePic.Image = (selected_target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
            }
            lblOperationResults.Text = "Operation Results: ";
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            
            BulkUserOperation new_operation;
            User new_user = new User();
            DialogResult res = new frmEditUser(ref new_user).ShowDialog();
            BulkOperationType operationType = (BulkOperationType)cbOperationType.SelectedIndex;
            bool IsSilent = checkSilentOperation.Checked;
            if(res == DialogResult.OK)
            {
                new_operation = new BulkUserOperation(operationType, ref manager_entities, new_user, IsSilent);
                manager.BulkOperations.Add(new_operation);
            }
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = manager.BulkOperations;
            lblOperationResults.Text = "Operation Results: ";
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            //Remove it from the list of the manager and nullify it here
            if(selected_operation != null)
            {
                manager.BulkOperations.Remove(selected_operation);
                selected_target = null;
                selected_operation = null;
            }
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource= manager.BulkOperations;
            lblOperationResults.Text = "Operation Results: ";
        }

        private void btnApplyChangesToCurrentTarget_Click(object sender, EventArgs e)
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
            if(selected_operation != null)
            {
                int operation_index = manager.BulkOperations.IndexOf(selected_operation);
                BulkOperationType current_type = (BulkOperationType)cbOperationType.SelectedIndex;
                bool IsSilent = checkSilentOperation.Checked;
                selected_operation = new BulkUserOperation(current_type,ref manager_entities, selected_target, IsSilent);
                manager.BulkOperations[operation_index] = selected_operation;
            }
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = manager.BulkOperations;
            lblOperationResults.Text = "Operation Results: ";
        }

        private void checkSilentOperation_CheckedChanged(object sender, EventArgs e)
        {
            if(selected_operation != null)
            {
                BulkOperationType current_type = selected_operation.OperationType;
                bool IsSilent = checkSilentOperation.Checked;
                selected_operation = new BulkUserOperation(current_type, ref manager_entities, selected_target, IsSilent);
                manager.BulkOperations.Remove(selected_operation);
                manager.BulkOperations.Add(selected_operation);
            }
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = manager.BulkOperations;
        }

        private void cbOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected_operation != null)
            {
                int operation_index = manager.BulkOperations.IndexOf(selected_operation);
                BulkOperationType current_type = (BulkOperationType)cbOperationType.SelectedIndex;
                bool IsSilent = selected_operation.IsSilent;
                selected_operation = new BulkUserOperation(current_type, ref manager_entities, selected_target, IsSilent);
                manager.BulkOperations.Remove(selected_operation);
                manager.BulkOperations.Add(selected_operation);
            }
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = manager.BulkOperations;
        }

       
    }
}
