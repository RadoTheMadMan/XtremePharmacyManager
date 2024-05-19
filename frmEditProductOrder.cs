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
    public partial class frmEditProductOrder : Form
    {
        ProductOrder target;
        static List<Product> products;
        static List<User> clients;
        static List<User> employees;
        public frmEditProductOrder(ref ProductOrder target, ref List<Product> ref_products, ref List<User> ref_clients, ref List<User> ref_employees)
        {
            InitializeComponent();
            this.target = target;
            products = ref_products;
            clients = ref_clients;
            employees = ref_employees;
        }

        private void trbPriceOverride_Scroll(object sender, EventArgs e)
        {
            lblShowPriceOverride.Text = trbPriceOverride.Value.ToString();
        }

        private void trbDesiredQuantity_Scroll(object sender, EventArgs e)
        {
            lblShowDesiredQuantity.Text = trbDesiredQuantity.Value.ToString();
        }


        private void frmEditProductOrder_Load(object sender, EventArgs e)
        {
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.cbSelectProduct.DataSource = products;
            this.cbSelectClient.DataSource = clients;
            this.cbSelectEmployee.DataSource = employees;
            if (products.Where(x=>x.ID == target.ProductID).FirstOrDefault() != null)
            {
                this.cbSelectProduct.SelectedValue = target.ProductID;
            }
            if (clients.Where(x => x.ID == target.ClientID).FirstOrDefault() != null)
            {
                this.cbSelectClient.SelectedValue = target.ClientID;
            }
            if (employees.Where(x => x.ID == target.EmployeeID).FirstOrDefault() != null)
            {
                this.cbSelectEmployee.SelectedValue = target.EmployeeID;
            }
            trbDesiredQuantity.Value = (target.DesiredQuantity >= 0) ? target.DesiredQuantity : 0;
            lblShowDesiredQuantity.Text = (target.DesiredQuantity >= 0) ? target.DesiredQuantity.ToString() : string.Empty;
            trbPriceOverride.Value = (target.OrderPrice >= 0) ? Convert.ToInt32(target.OrderPrice) : 0;
            lblShowPriceOverride.Text = (target.OrderPrice >= 0) ? target.OrderPrice.ToString() : string.Empty;
            cbSelectOrderStatus.SelectedValue = cbSelectOrderStatus.Items[target.OrderStatus];
            txtOrderReason.Text = target.OrderReason;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.ProductID = Int32.Parse(cbSelectProduct.SelectedValue.ToString());
                    target.DesiredQuantity = trbDesiredQuantity.Value;
                    target.OrderPrice = trbPriceOverride.Value;
                    target.ClientID = Int32.Parse(cbSelectClient.SelectedValue.ToString());
                    target.EmployeeID = Int32.Parse(cbSelectEmployee.SelectedValue.ToString());
                    target.OrderStatus = cbSelectOrderStatus.SelectedIndex;
                    target.OrderReason = txtOrderReason.Text;
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
                    target.ProductID = Int32.Parse(cbSelectProduct.SelectedValue.ToString());
                    target.DesiredQuantity = trbDesiredQuantity.Value;
                    target.OrderPrice = trbPriceOverride.Value;
                    target.ClientID = Int32.Parse(cbSelectClient.SelectedValue.ToString());
                    target.EmployeeID = Int32.Parse(cbSelectEmployee.SelectedValue.ToString());
                    target.OrderStatus = cbSelectOrderStatus.SelectedIndex;
                    target.OrderReason = txtOrderReason.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
