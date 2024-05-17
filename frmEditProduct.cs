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
    public partial class frmEditProduct : Form
    {
        Product target;
        static List<ProductBrand> brands;
        static List<ProductVendor> vendors;
        public frmEditProduct(ref Product target, ref List<ProductBrand> ref_brands, ref List<ProductVendor> ref_vendors)
        {
            InitializeComponent();
            this.target = target;
            brands = ref_brands;
            vendors = ref_vendors;
        }

        
        
       

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = trbPrice.Value.ToString();
            if (target != null)
            {
                target.ProductPrice = trbPrice.Value;
            }
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            lblShowQuantity.Text = trbQuantity.Value.ToString();
            if (target != null)
            {
                target.ProductQuantity = trbQuantity.Value;
            }
        }




        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(target !=null)
            {
                target.ID = Int32.Parse(txtID.Text);
            }
        }

        private void cbSelectBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (target != null)
            {
                target.BrandID = Int32.Parse(cbSelectBrand.SelectedValue.ToString());
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if(target!=null)
            {
                target.ProductName = txtProductName.Text;
            }
        }


        private void txtProductDescription_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.ProductDescription = txtProductDescription.Text;
            }
        }

        private void dtExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.ProductExpiryDate = dtExpiryDate.Value;
            }
        }

        private void txtRegistrationNumber_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.ProductRegNum = txtRegistrationNumber.Text;
            }
        }

        private void txtPartitudeNumber_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.ProductPartNum = txtPartitudeNumber.Text; 
            }    
        }

        private void txtStorageLocation_TextChanged(object sender, EventArgs e)
        {
            if(target != null)
            {
                target.ProductStorageLocation = txtStorageLocation.Text;
            }
        }

        private void frmEditProduct_Load(object sender, EventArgs e)
        {
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtProductName.Text = (!String.IsNullOrEmpty(target.ProductName)) ? target.ProductName.ToString() : string.Empty;
            this.cbSelectBrand.DataSource = brands;
            if (brands.Where(x => x.ID == target.BrandID).FirstOrDefault() != null)
            {
                this.cbSelectBrand.SelectedValue = target.BrandID;
            }
            this.txtProductDescription.Text = (!String.IsNullOrEmpty(target.ProductDescription)) ? target.ProductDescription.ToString() : string.Empty;
            this.dtExpiryDate.Value = (target.ProductExpiryDate != null && target.ProductExpiryDate > DateTime.MinValue && target.ProductExpiryDate < DateTime.MaxValue) ? target.ProductExpiryDate : DateTime.Now;
            this.txtRegistrationNumber.Text = (!String.IsNullOrEmpty(target.ProductRegNum)) ? target.ProductRegNum.ToString() : string.Empty;
            this.txtPartitudeNumber.Text = (!String.IsNullOrEmpty(target.ProductPartNum)) ? target.ProductPartNum.ToString() : string.Empty;
            this.txtStorageLocation.Text = (!String.IsNullOrEmpty(target.ProductStorageLocation)) ? target.ProductStorageLocation.ToString() : string.Empty;
            trbQuantity.Value = (target.ProductQuantity >= 0) ? target.ProductQuantity : 0;
            lblShowQuantity.Text = (target.ProductQuantity >= 0) ? target.ProductQuantity.ToString() : string.Empty;
            trbPrice.Value = (target.ProductPrice >= 0) ? Convert.ToInt32(target.ProductPrice) : 0;
            lblShowPrice.Text = (target.ProductPrice >= 0) ? target.ProductPrice.ToString() : string.Empty;
        }

        private void cbSelectVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (target != null)
            {
                target.VendorID = Int32.Parse(cbSelectVendor.SelectedValue.ToString());
            }
        }
    }
}
