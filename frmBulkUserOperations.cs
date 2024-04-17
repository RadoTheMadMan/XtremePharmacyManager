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
        BulkOperationManager<User> manager;
        BulkOperation<User> selected_operation;
        User selected_target;
        public frmBulkUserOperations(ref BulkOperationManager<User> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;

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
            ofd.Title = "Select an image to upload or for add/update operation";
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

        private void frmEditUser_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            if (selected_target != null && selected_target != null)
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
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            manager.ExecuteOperations();
            lblOperationResults.Text = lblOperationResults.Text + manager.Result;
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {

        }

        private void lstBulkOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox current = (ListBox)sender;
            if (current.SelectedItems.Count > 0 || current.SelectedValue != null)
            {
                selected_operation = (BulkOperation<User>)current.SelectedValue;
                selected_target = selected_operation.TargetObject;
            }
            Bitmap currentpfp = new Bitmap(64, 64);
            if (selected_target != null && selected_target != null)
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
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {

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
        }

        private void btnApplyChangesToCurrentTarget_Click(object sender, EventArgs e)
        {
            selected_target.UserDisplayName = txtDisplayName.Text;
            selected_target.UserBirthDate = dtBirthDate.Value;
            selected_target.UserBalance = trbBalance.Value;
            selected_target.UserDiagnose = txtUsername.Text;
        }
    }
}
