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
    public partial class frmAccountSettings : Form
    {
        User login_account;
        public frmAccountSettings(ref User userAccount)
        {
            InitializeComponent();
            this.login_account = userAccount;
        }

        private void pbYourProfilePic_Click(object sender, EventArgs e)
        {
            PictureBox current = (PictureBox)sender;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = $"{GLOBAL_RESOURCES.ACCOUNT_SETTINGS_PROFILE_PIC_SELECT_TITLE}";
            if (login_account != null)
            {
                if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
                {
                    Bitmap selectedImage = new Bitmap(ofd.FileName);
                    current.Image = new Bitmap(selectedImage);
                }
            }
        }

        private void frmAccountSettings_Load(object sender, EventArgs e)
        {
            Bitmap current_pfp;
            try
            {
                if (login_account != null)
                {
                    ConvertBinaryToImage(login_account.UserProfilePic, out current_pfp);
                    txtYourUsername.Text = (!String.IsNullOrEmpty(login_account.UserName) ? login_account.UserName : string.Empty);
                    txtYourPassword.Text = (!String.IsNullOrEmpty(login_account.UserPassword) ? login_account.UserPassword : string.Empty);
                    txtYourDisplayName.Text = (!String.IsNullOrEmpty(login_account.UserDisplayName) ? login_account.UserDisplayName : string.Empty);
                    txtYourEmail.Text = (!String.IsNullOrEmpty(login_account.UserEmail) ? login_account.UserEmail : string.Empty);
                    txtYourPhone.Text = (!String.IsNullOrEmpty(login_account.UserPhone) ? login_account.UserPhone : string.Empty);
                    txtYourAddress.Text = (!String.IsNullOrEmpty(login_account.UserAddress) ? login_account.UserAddress : string.Empty);
                    txtYourDiagnose.Text = (!String.IsNullOrEmpty(login_account.UserDiagnose) ? login_account.UserDiagnose : string.Empty);
                    pbYourProfilePic.Image = (current_pfp != null ? current_pfp : new Bitmap(64, 64));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            byte[] image_data;
            try
            {
                if(login_account != null && !String.IsNullOrEmpty(txtYourUsername.Text) && !String.IsNullOrEmpty(txtYourPassword.Text))
                {
                    ConvertImageToBinary((Bitmap)pbYourProfilePic.Image, out image_data);
                    login_account.UserName = txtYourUsername.Text;
                    login_account.UserPassword = txtYourPassword.Text;
                    login_account.UserDisplayName = txtYourDisplayName.Text;
                    login_account.UserEmail = txtYourEmail.Text;
                    login_account.UserPhone = txtYourPhone.Text;
                    login_account.UserAddress = txtYourAddress.Text;
                    login_account.UserDiagnose = txtYourDiagnose.Text;
                    login_account.UserProfilePic = (image_data != null ? image_data : new byte[128]);
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.ACCOUNT_SETTINGS_INVALID_CREDENTIALS_ERROR_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
