﻿using System;
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
            LoadImageAndBytes();
        }

        public frmImageBinConverter(ref Bitmap target_image)
        {
            InitializeComponent();
            this.target_image = target_image;
            ConvertImageToBinary(target_image, out image_bytes);
            LoadImageAndBytes();
        }

        private void LoadImageAndBytes()
        {
            if (target_image != null && image_bytes != null)
            {
                pbLoadedImage.Image = target_image;
                txtImageBytes.Text = Convert.ToBase64String(image_bytes);
            }
        }

        private void btnConvertImageToBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = "Select an image to upload or for add/update operation";
            if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
            {
                target_image = new Bitmap(ofd.FileName);
                ConvertImageToBinary(target_image, out image_bytes);
                LoadImageAndBytes();
            }
        }

        private void buttonConvertBinaryToImage_Click(object sender, EventArgs e)
        {
            image_bytes = Convert.FromBase64String(txtImageBytes.Text);
            ConvertBinaryToImage(image_bytes,out target_image);
            LoadImageAndBytes();
        }
    }
}