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
            if (target != null)
            {
                target.UserBalance = trbBalance.Value;
            }
        }

        private void pbUserProfilePic_Click(object sender, EventArgs e)
        {
            PictureBox current = (PictureBox)sender;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = "Select an image to upload or for add/update operation";
            if(target != null)
            {
                if(ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
                {
                    Bitmap selectedImage = new Bitmap(ofd.FileName);
                    byte[] imageBytes;
                    ConvertImageToBinary(selectedImage, out imageBytes);
                    current.Image = new Bitmap(selectedImage);
                    target.UserProfilePic = imageBytes;
                }
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.UserRole = cbRole.SelectedIndex;
            }
        }

        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {
            if (target != null)
            {
                target.UserDiagnose = txtDiagnose.Text;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(target !=null)
            {
                target.ID = Int32.Parse(txtID.Text);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if(target!=null)
            {
                target.UserName = txtUsername.Text;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(target!= null)
            {
                target.UserPassword = txtPassword.Text;
            }
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.UserDisplayName = txtDisplayName.Text;
            }
        }

        private void dtBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.UserBirthDate = dtBirthDate.Value;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.UserPhone = txtPhone.Text;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.UserEmail = txtEmail.Text; 
            }    
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.UserAddress = txtAddress.Text;
            }
        }

        private void frmEditUser_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            if (target.UserProfilePic != null) { ConvertBinaryToImage(target.UserProfilePic, out currentpfp); }
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtUsername.Text = (!String.IsNullOrEmpty(target.UserName)) ? target.UserName.ToString() : string.Empty;
            this.txtPassword.Text = (!String.IsNullOrEmpty(target.UserPassword)) ? target.UserPassword.ToString() : string.Empty;
            this.txtDisplayName.Text = (!String.IsNullOrEmpty(target.UserDisplayName)) ? target.UserDisplayName.ToString() : string.Empty;
            this.dtBirthDate.Value = (target.UserBirthDate != null && target.UserBirthDate > DateTime.MinValue && target.UserBirthDate < DateTime.MaxValue) ? target.UserBirthDate : DateTime.Now;
            this.txtPhone.Text = (!String.IsNullOrEmpty(target.UserPhone)) ? target.UserPhone.ToString() : string.Empty;
            this.txtEmail.Text = (!String.IsNullOrEmpty(target.UserEmail)) ? target.UserEmail.ToString() : string.Empty;
            this.txtAddress.Text = (!String.IsNullOrEmpty(target.UserAddress)) ? target.UserAddress.ToString() : string.Empty;
            trbBalance.Value = (target.UserBalance >= 0) ? Convert.ToInt32(target.UserBalance) : 0;
            lblShowBalance.Text = (target.UserBalance >= 0) ? target.UserBalance.ToString() : string.Empty;
            txtDiagnose.Text = (!String.IsNullOrEmpty(target.UserDiagnose)) ? target.UserDiagnose : string.Empty;
            cbRole.SelectedIndex = (target.UserRole >= 0 && target.UserRole <= 2) ? target.UserRole : 1;
            pbUserProfilePic.Image = (target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
        }
    }
}
