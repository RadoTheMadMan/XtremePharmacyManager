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
    public partial class frmEditDeliveryService : Form
    {
        DeliveryService target;
        public frmEditDeliveryService(ref DeliveryService target)
        {
            InitializeComponent();
            this.target = target;
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtServiceName.Text = (!String.IsNullOrEmpty(target.ServiceName)) ? target.ServiceName.ToString() : string.Empty;
            trbPrice.Value = (target.ServicePrice >= 0) ? Convert.ToInt32(target.ServicePrice) : 0;
            lblShowPrice.Text = (target.ServicePrice >= 0) ? target.ServicePrice.ToString() : string.Empty;
        }

        
        
       

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = trbPrice.Value.ToString();
            if (target != null)
            {
                target.ServicePrice = trbPrice.Value;
            }
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
                target.ServiceName = txtServiceName.Text;
            }
        }
    }
}
