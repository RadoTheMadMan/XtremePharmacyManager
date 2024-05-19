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
    public partial class frmEditProductImage : Form
    {
        ProductImage target;
        static List<Product> products;
        public frmEditProductImage(ref ProductImage target, ref List<Product> ref_products)
        {
            InitializeComponent();
            this.target = target;
            products = ref_products;
        }

        private void pbProductImageData_Click(object sender, EventArgs e)
        {
            PictureBox current = (PictureBox)sender;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = "Select an image to upload or for add/update operation";
            if (target != null)
            {
                if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
                {
                    Bitmap selectedImage = new Bitmap(ofd.FileName);
                    current.Image = new Bitmap(selectedImage);
                }
            }
        }

        private void frmEditProductImage_Load(object sender, EventArgs e)
        {
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtImageName.Text = (!String.IsNullOrEmpty(target.ImageName)) ? target.ImageName.ToString() : string.Empty;
            this.cbSelectProduct.DataSource = products;
            this.cbSelectProduct.SelectedValue = target.ProductID;
            Bitmap extractedbitmap;
            ConvertBinaryToImage(target.ImageData, out extractedbitmap);
            pbProductImageData.Image = (extractedbitmap != null) ? extractedbitmap : new Bitmap(64, 64);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            byte[] imageBytes;
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.ImageName = txtImageName.Text;
                    target.ProductID = Int32.Parse(cbSelectProduct.SelectedValue.ToString());
                    ConvertImageToBinary((Bitmap)pbProductImageData.Image, out imageBytes);
                    target.ImageData = imageBytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
