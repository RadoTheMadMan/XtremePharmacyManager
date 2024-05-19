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
    public partial class frmEditOrderDelivery : Form
    {
        OrderDelivery target;
        static List<ProductOrder> product_orders;
        static List<PaymentMethod> payment_methods;
        static List<DeliveryService> delivery_services;
        public frmEditOrderDelivery(ref OrderDelivery target, ref List<ProductOrder> ref_product_orders, ref List<PaymentMethod> ref_payment_methods, ref List<DeliveryService> ref_delivery_services)
        {
            InitializeComponent();
            this.target = target;
            product_orders = ref_product_orders;
            payment_methods = ref_payment_methods;
            delivery_services = ref_delivery_services;
        }




        private void frmEditOrderDelivery_Load(object sender, EventArgs e)
        {
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.cbSelectProductOrders.DataSource = product_orders;
            this.cbSelectDeliveryService.DataSource = delivery_services;
            this.cbSelectPaymentMethod.DataSource = payment_methods;
            if (product_orders.Where(x => x.ID == target.OrderID).FirstOrDefault() != null)
            {
                this.cbSelectProductOrders.SelectedValue = target.OrderID;
            }
            if (delivery_services.Where(x => x.ID == target.DeliveryServiceID).FirstOrDefault() != null)
            {
                this.cbSelectDeliveryService.SelectedValue = target.DeliveryServiceID;
            }
            if (delivery_services.Where(x => x.ID == target.PaymentMethodID).FirstOrDefault() != null)
            {
                this.cbSelectPaymentMethod.SelectedValue = target.PaymentMethodID;
            }
            cbSelectDeliveryStatus.SelectedValue = cbSelectDeliveryStatus.Items[target.DeliveryStatus];
            txtDeliveryReason.Text = target.DeliveryReason;
            txtCargoID.Text = target.CargoID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.OrderID = Int32.Parse(cbSelectProductOrders.SelectedValue.ToString());
                    target.DeliveryServiceID = Int32.Parse(cbSelectDeliveryService.SelectedValue.ToString());
                    target.PaymentMethodID = Int32.Parse(cbSelectPaymentMethod.SelectedValue.ToString());
                    target.CargoID = txtCargoID.Text;
                    target.DeliveryStatus = cbSelectDeliveryStatus.SelectedIndex;
                    target.DeliveryReason = txtDeliveryReason.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
