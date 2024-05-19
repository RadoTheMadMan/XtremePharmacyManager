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
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            lblShowQuantity.Text = trbQuantity.Value.ToString();
        }




        private void frmEditProduct_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
                this.txtProductName.Text = (!String.IsNullOrEmpty(target.ProductName)) ? target.ProductName.ToString() : string.Empty;
                this.cbSelectBrand.DataSource = brands;
                this.cbSelectVendor.DataSource = vendors;
                if (brands.Where(x => x.ID == target.BrandID).FirstOrDefault() != null)
                {
                    this.cbSelectBrand.SelectedValue = target.BrandID;
                }
                if (vendors.Where(x => x.ID == target.VendorID).FirstOrDefault() != null)
                {
                    this.cbSelectVendor.SelectedValue = target.VendorID;
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
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.BrandID = Int32.Parse(cbSelectBrand.SelectedValue.ToString());
                    target.VendorID = Int32.Parse(cbSelectVendor.SelectedValue.ToString());
                    target.ProductName = txtProductName.Text;
                    target.ProductDescription = txtProductDescription.Text;
                    target.ProductQuantity = trbQuantity.Value;
                    target.ProductPrice = trbPrice.Value;
                    target.ProductExpiryDate = dtExpiryDate.Value;
                    target.ProductRegNum = txtRegistrationNumber.Text;
                    target.ProductPartNum = txtPartitudeNumber.Text;
                    target.ProductStorageLocation = txtStorageLocation.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.BrandID = Int32.Parse(cbSelectBrand.SelectedValue.ToString());
                    target.VendorID = Int32.Parse(cbSelectVendor.SelectedValue.ToString());
                    target.ProductName = txtProductName.Text;
                    target.ProductDescription = txtProductDescription.Text;
                    target.ProductQuantity = trbQuantity.Value;
                    target.ProductPrice = trbPrice.Value;
                    target.ProductExpiryDate = dtExpiryDate.Value;
                    target.ProductRegNum = txtRegistrationNumber.Text;
                    target.ProductPartNum = txtPartitudeNumber.Text;
                    target.ProductStorageLocation = txtStorageLocation.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
