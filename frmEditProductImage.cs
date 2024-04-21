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

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(target !=null)
            {
                target.ID = Int32.Parse(txtID.Text);
            }
        }

        private void cbSelectProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (target != null)
            {
                target.ProductID = Int32.Parse(cbSelectProduct.SelectedValue.ToString());
            }
        }

        private void txtImageName_TextChanged(object sender, EventArgs e)
        {
            if(target!=null)
            {
                target.ImageName = txtImageName.Text;
            }
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
                    byte[] imageBytes;
                    ConvertImageToBinary(selectedImage, out imageBytes);
                    current.Image = new Bitmap(selectedImage);
                    target.ImageData = imageBytes;
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
    }
}
