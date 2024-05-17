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
    public partial class frmEditProductVendor : Form
    {
        ProductVendor target;
        public frmEditProductVendor(ref ProductVendor target)
        {
            InitializeComponent();
            this.target = target;
        }

        
        
       


        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(target !=null)
            {
                target.ID = Int32.Parse(txtID.Text);
            }
        }

        private void txtVendorName_TextChanged(object sender, EventArgs e)
        {
            if(target!=null)
            {
                target.VendorName = txtVendorName.Text;
            }
        }

        private void frmEditProductVendor_Load(object sender, EventArgs e)
        {
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtVendorName.Text = (!String.IsNullOrEmpty(target.VendorName)) ? target.VendorName.ToString() : string.Empty;
        }
    }
}
