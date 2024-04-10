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
    public partial class frmEditPaymentMethod : Form
    {
        PaymentMethod target;
        public frmEditPaymentMethod(ref PaymentMethod target)
        {
            InitializeComponent();
            this.target = target;
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtMethodName.Text = (!String.IsNullOrEmpty(target.MethodName)) ? target.MethodName.ToString() : string.Empty;
        }

        
        
       


        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(target !=null)
            {
                target.ID = Int32.Parse(txtID.Text);
            }
        }

        private void txtServiceName_TextChanged(object sender, EventArgs e)
        {
            if(target!=null)
            {
                target.MethodName = txtMethodName.Text;
            }
        }
    }
}
