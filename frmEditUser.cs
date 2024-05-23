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
    public partial class frmEditUser : Form
    {
        User target;
        public frmEditUser(ref User target)
        {
            InitializeComponent();
            this.target = target;
        }

        
        
       

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            txtBalance.Text = trbBalance.Value.ToString();
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
                    current.Image = new Bitmap(selectedImage);
                }
            }
        }

        private void frmEditUser_Load(object sender, EventArgs e)
        {

            try
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
                txtBalance.Text = (target.UserBalance >= 0) ? Convert.ToInt32(target.UserBalance).ToString() : string.Empty;
                trbBalance.Value = (target.UserBalance >= 0) ? Convert.ToInt32(target.UserBalance) : 0;
                txtDiagnose.Text = (!String.IsNullOrEmpty(target.UserDiagnose)) ? target.UserDiagnose : string.Empty;
                cbRole.SelectedIndex = (target.UserRole >= 0 && target.UserRole <= 2) ? target.UserRole : 1;
                pbUserProfilePic.Image = (target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            byte[] imageBytes;
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.UserName = txtUsername.Text;
                    target.UserPassword = txtPassword.Text;
                    target.UserDisplayName = txtDisplayName.Text;
                    target.UserBirthDate = dtBirthDate.Value;
                    target.UserPhone = txtPhone.Text;
                    target.UserEmail = txtEmail.Text;
                    target.UserAddress = txtAddress.Text;
                    ConvertImageToBinary((Bitmap)pbUserProfilePic.Image, out imageBytes);
                    target.UserProfilePic = imageBytes;
                    target.UserBalance = trbBalance.Value;
                    target.UserDiagnose = txtDiagnose.Text;
                    target.UserRole = cbRole.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            byte[] imageBytes;
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.UserName = txtUsername.Text;
                    target.UserPassword = txtPassword.Text;
                    target.UserDisplayName = txtDisplayName.Text;
                    target.UserBirthDate = dtBirthDate.Value;
                    target.UserPhone = txtPhone.Text;
                    target.UserEmail = txtEmail.Text;
                    target.UserAddress = txtAddress.Text;
                    ConvertImageToBinary((Bitmap)pbUserProfilePic.Image, out imageBytes);
                    target.UserProfilePic = imageBytes;
                    target.UserBalance = trbBalance.Value;
                    target.UserDiagnose = txtDiagnose.Text;
                    target.UserRole = cbRole.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
