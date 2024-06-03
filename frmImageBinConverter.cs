using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static XtremePharmacyManager.ImageBinConverter;

namespace XtremePharmacyManager.Properties.DataSources
{
    public partial class frmImageBinConverter : Form
    {
        Bitmap target_image;
        byte[] image_bytes;
        public frmImageBinConverter()
        {
            InitializeComponent();
            target_image = new Bitmap(256, 256);
            ConvertImageToBinary(target_image,out image_bytes);
        }

        public frmImageBinConverter(ref Bitmap target_image)
        {
            InitializeComponent();
            this.target_image = target_image;
            ConvertImageToBinary(target_image, out image_bytes);
        }

        private void LoadImageAndBytes()
        {
            try
            {
                if (target_image != null && image_bytes != null)
                {
                    pbLoadedImage.Image = target_image;
                    txtImageBytes.Text = Convert.ToBase64String(image_bytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvertImageToBinary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
                ofd.Multiselect = false;
                ofd.Title = $"{GLOBAL_RESOURCES.IMAGE_BIN_CONVERTER_CONVERT_IMAGE_TITLE}";
                if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
                {
                    target_image = new Bitmap(ofd.FileName);
                    ConvertImageToBinary(target_image, out image_bytes);
                    LoadImageAndBytes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConvertBinaryToImage_Click(object sender, EventArgs e)
        {
            try
            {
                image_bytes = Convert.FromBase64String(txtImageBytes.Text);
                ConvertBinaryToImage(image_bytes, out target_image);
                LoadImageAndBytes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmImageBinConverter_Load(object sender, EventArgs e)
        {
            LoadImageAndBytes();
        }
    }
}
