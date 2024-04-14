using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static System.Net.Mime.MediaTypeNames;
using static XtremePharmacyManager.ImageBinConverter;

namespace XtremePharmacyManager
{
    public partial class frmSearchOrderDeliveries : Form
    {
        //Usually views shouldn't be used in anything instead of reports but this time it is an exception
        //for easy to use separation between users who are employees and users who are clients and minimal error
        //I hope it works for 
        static Entities ent;
        static List<ProductOrder> product_orders;
        static List<OrderDelivery> order_deliveries;
        static List<DeliveryService> delivery_services;
        static List<PaymentMethod> payment_methods;
        public frmSearchOrderDeliveries(Entities entity)
        {
            ent = entity;
            InitializeComponent();
            RefreshDeliveryServices();
            RefreshPaymentMethods();
            RefreshProductOrders();
            RefreshOrderDeliveries();
        }

        private void RefreshProductOrders()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_orders = ent.GetProductOrder(-1,-1,0, new decimal(),-1,-1,new DateTime(),new DateTime(),new DateTime(),new DateTime(),0,"").ToList();
                    cbSelectProductOrder.DataSource = product_orders;
                    ProductOrderIDColumn.DataSource = product_orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOrderDeliveries()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    order_deliveries = ent.GetOrderDelivery(-1,-1,-1,-1,new decimal(),new DateTime(), new DateTime(), new DateTime(), new DateTime(),0,"").ToList();
                    dgvOrderDeliveries.DataSource = order_deliveries;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDeliveryServices()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    delivery_services = ent.GetDeliveryService(-1,"",new decimal()).ToList();
                    cbSelectDeliveryService.DataSource = delivery_services;
                    DeliveryServiceIDColumn.DataSource = delivery_services;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshPaymentMethods()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    payment_methods = ent.GetPaymentMethod(-1,"").ToList();
                    cbSelectPaymentMethod.DataSource = payment_methods;
                    PaymentMethodIDColumn.DataSource = payment_methods;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            int DeliveryID = -1;
            int OrderID = -1;
            int DeliveryServiceID = -1;
            int PaymentMethodID = -1;
            int DeliveryStatus = 0;
            Int32.TryParse(txtID.Text, out DeliveryID);
            if (cbSelectProductOrder.SelectedValue != null)
            {
                Int32.TryParse(cbSelectProductOrder.SelectedValue.ToString(), out OrderID);
            }
            if (cbSelectDeliveryService.SelectedValue != null)
            {
                Int32.TryParse(cbSelectDeliveryService.SelectedValue.ToString(), out DeliveryServiceID);
            }
            if (cbSelectPaymentMethod.SelectedValue != null)
            {
                Int32.TryParse(cbSelectPaymentMethod.SelectedValue.ToString(), out PaymentMethodID);
            }
            DeliveryStatus = cbSelectDeliveryStatus.SelectedIndex;
            DateTime DateAddedFrom = dtDateAddedFrom.Value;
            DateTime DateAddedTo = dtDateAddedTo.Value;
            DateTime DateModifiedFrom = dtDateModifiedFrom.Value;
            DateTime DateModifiedTo = dtDateModifiedTo.Value;
            decimal TotalPrice = trbTotalPrice.Value;
            string DeliveryReason = txtDeliveryReason.Text;
            int SearchMode = cbSearchMode.SelectedIndex;
            if (SearchMode == 1)
            {
                RefreshProductOrders();
                RefreshDeliveryServices();
                RefreshPaymentMethods();
                order_deliveries = ent.OrderDeliveries.Where(
                    x => x.ID == DeliveryID ^ x.OrderID == OrderID ^ x.DeliveryServiceID == DeliveryServiceID ^ x.PaymentMethodID == PaymentMethodID ^
                        (x.DateAdded >= DateAddedFrom && x.DateAdded <= DateAddedTo) ^ x.DeliveryReason.Contains(DeliveryReason) ^
                        (x.DateModified >= DateModifiedFrom && x.DateModified <= DateModifiedTo) ^ x.DeliveryStatus == DeliveryStatus ^
                        (x.TotalPrice <= TotalPrice || x.TotalPrice >= TotalPrice)).ToList();
                dgvOrderDeliveries.DataSource = order_deliveries;
            }
            else if (SearchMode == 2)
            {
                RefreshProductOrders();
                RefreshDeliveryServices();
                RefreshPaymentMethods();
                order_deliveries = ent.OrderDeliveries.Where(
                    x => x.ID == DeliveryID || x.OrderID == OrderID || x.DeliveryServiceID == DeliveryServiceID || x.PaymentMethodID == PaymentMethodID ||
                        (x.DateAdded >= DateAddedFrom && x.DateAdded <= DateAddedTo) || x.DeliveryReason.Contains(DeliveryReason) ||
                        (x.DateModified >= DateModifiedFrom && x.DateModified <= DateModifiedTo) || x.DeliveryStatus == DeliveryStatus ||
                        (x.TotalPrice <= TotalPrice || x.TotalPrice >= TotalPrice)).ToList();
                dgvOrderDeliveries.DataSource = order_deliveries;
            }
            else if (SearchMode == 3)
            {
                RefreshProductOrders();
                RefreshDeliveryServices();
                RefreshPaymentMethods();
                order_deliveries = ent.GetOrderDelivery(DeliveryID,OrderID,DeliveryServiceID,PaymentMethodID,new decimal(),new DateTime(),new DateTime(), new DateTime(), new DateTime(),0,"").ToList();
                dgvOrderDeliveries.DataSource = order_deliveries;
            }
            else
            {
                RefreshProductOrders();
                RefreshDeliveryServices();
                RefreshPaymentMethods();
                RefreshOrderDeliveries();
            }
        }

        private void trbTotalPrice_Scroll(object sender, EventArgs e)
        {
            lblShowTotalPrice.Text = trbTotalPrice.Value.ToString();
        }


        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int DeliveryID = -1;
            OrderDelivery selectedDelivery;
            try
            {
                if (dgvOrderDeliveries.SelectedRows.Count > 0)
                {
                    row = dgvOrderDeliveries.SelectedRows[0];
                    if (row != null && order_deliveries != null && product_orders != null && payment_methods != null && delivery_services != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out DeliveryID);
                        if (DeliveryID > 0)
                        {
                            //For Orders we will not allow anyone to edit orders who were completed, returned or cancelled
                            selectedDelivery = order_deliveries.Where(x => x.ID == DeliveryID && (x.DeliveryStatus != 7 || x.DeliveryStatus!= 8 || x.DeliveryStatus != 9)).FirstOrDefault();
                            if (selectedDelivery != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditOrderDelivery(ref selectedDelivery, ref product_orders, ref payment_methods, ref delivery_services).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateOrderDeliveryByID(selectedDelivery.ID, selectedDelivery.OrderID,selectedDelivery.DeliveryServiceID,selectedDelivery.PaymentMethodID,selectedDelivery.DeliveryStatus,selectedDelivery.DeliveryReason);
                                        RefreshDeliveryServices();
                                        RefreshPaymentMethods();
                                        RefreshProductOrders();
                                        RefreshOrderDeliveries();
                                    }
                                }
                            }
                            else
                            {
                                //Create a new one
                                selectedDelivery = new OrderDelivery();
                                DialogResult res = new frmEditOrderDelivery(ref selectedDelivery, ref product_orders, ref payment_methods, ref delivery_services).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddOrderDelivery(selectedDelivery.OrderID,selectedDelivery.DeliveryServiceID,selectedDelivery.PaymentMethodID,selectedDelivery.DeliveryReason);
                                        RefreshDeliveryServices();
                                        RefreshPaymentMethods();
                                        RefreshProductOrders();
                                        RefreshOrderDeliveries();
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Create a new one
                            selectedDelivery = new OrderDelivery();
                            DialogResult res = new frmEditOrderDelivery(ref selectedDelivery, ref product_orders, ref payment_methods, ref delivery_services).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddOrderDelivery(selectedDelivery.OrderID, selectedDelivery.DeliveryServiceID, selectedDelivery.PaymentMethodID, selectedDelivery.DeliveryReason);
                                    RefreshDeliveryServices();
                                    RefreshPaymentMethods();
                                    RefreshProductOrders();
                                    RefreshOrderDeliveries();
                                }
                            }
                        }
                    }
                }
                else
                {
                //Create a new one
                //Create a new one
                selectedDelivery = new OrderDelivery();
                DialogResult res = new frmEditOrderDelivery(ref selectedDelivery, ref product_orders, ref payment_methods, ref delivery_services).ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (ent.Database.Connection.State == ConnectionState.Open)
                    {
                        ent.AddOrderDelivery(selectedDelivery.OrderID, selectedDelivery.DeliveryServiceID, selectedDelivery.PaymentMethodID, selectedDelivery.DeliveryReason);
                        RefreshDeliveryServices();
                        RefreshPaymentMethods();
                        RefreshProductOrders();
                        RefreshOrderDeliveries();
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int DeliveryID = -1;
            OrderDelivery selectedDelivery;
            try
            {
                if (dgvOrderDeliveries.SelectedRows.Count > 0)
                {
                    row = dgvOrderDeliveries.SelectedRows[0];
                    if (row != null && product_orders != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out DeliveryID);
                        if (DeliveryID > 0)
                        {
                            selectedDelivery = order_deliveries.Where(x => x.ID == DeliveryID).FirstOrDefault();
                            if (selectedDelivery != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteOrderDeliveryByID(selectedDelivery.ID);
                                        RefreshDeliveryServices();
                                        RefreshPaymentMethods();
                                        RefreshProductOrders();
                                        RefreshOrderDeliveries();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrderDeliveries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int DeliveryID = -1;
            OrderDelivery target_delivery;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out DeliveryID);
                    if (DeliveryID >= 0 && order_deliveries != null)
                    {
                        target_delivery = order_deliveries.Where(x => x.ID == DeliveryID).FirstOrDefault();
                        if (target_delivery != null)
                        {
                            txtID.Text = target_delivery.ID.ToString();
                            if (cbSelectProductOrder.Items.Contains(product_orders.Where(x=>x.ID ==target_delivery.OrderID)))
                            {
                                cbSelectProductOrder.SelectedValue = target_delivery.OrderID;
                            }
                            if (cbSelectDeliveryService.Items.Contains(delivery_services.Where(x=>x.ID == target_delivery.DeliveryServiceID)))
                            {
                                cbSelectDeliveryService.SelectedValue = target_delivery.DeliveryServiceID;
                            }
                            if (cbSelectPaymentMethod.Items.Contains(payment_methods.Where(x=>x.ID == target_delivery.PaymentMethodID)))
                            {
                                cbSelectPaymentMethod.SelectedValue = target_delivery.PaymentMethodID;
                            }
                            dtDateAddedFrom.Value = target_delivery.DateAdded;
                            dtDateModifiedFrom.Value = target_delivery.DateModified;
                            txtDeliveryReason.Text = target_delivery.DeliveryReason.ToString();
                            trbTotalPrice.Value = Convert.ToInt32(target_delivery.TotalPrice);
                            lblShowTotalPrice.Text = target_delivery.TotalPrice.ToString();
                            cbSelectDeliveryStatus.SelectedIndex = target_delivery.DeliveryStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrderDeliveries_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewComboBoxCell productordercell;
            DataGridViewComboBoxColumn productorder;
            DataGridViewComboBoxCell deliveryservicecell;
            DataGridViewComboBoxColumn deliveryservicecolumn;
            DataGridViewComboBoxCell paymentmethodcell;
            DataGridViewComboBoxColumn paymentmethodcolumn;
            DataGridViewComboBoxCell statuscell;
            DataGridViewComboBoxColumn statuscolumn;
            int DeliveryID = -1;
            OrderDelivery target_order_delivery;
            ProductOrder target_product_order;
            DeliveryService target_delivery_service;
            PaymentMethod target_payment_method;
            try
            {
                foreach (DataGridViewRow row in target_view.Rows)
                {
                    if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                    {
                        productordercell = (DataGridViewComboBoxCell)row.Cells["ProductOrderIDColumn"];
                        productorder = (DataGridViewComboBoxColumn)target_view.Columns["ProductOrderIDColumn"];
                        deliveryservicecell = (DataGridViewComboBoxCell)row.Cells["DeliveryServiceIDColumn"];
                        deliveryservicecolumn = (DataGridViewComboBoxColumn)target_view.Columns["DeliveryServiceIDColumn"];
                        paymentmethodcell = (DataGridViewComboBoxCell)row.Cells["PaymentMethodIDColumn"];
                        paymentmethodcolumn = (DataGridViewComboBoxColumn)target_view.Columns["PaymentMethodIDColumn"];
                        statuscell = (DataGridViewComboBoxCell)row.Cells["DeliveryStatusColumn"];
                        statuscolumn = (DataGridViewComboBoxColumn)target_view.Columns["DeliveryStatusColumn"];
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out DeliveryID);
                        if (product_orders != null && delivery_services != null && payment_methods != null && order_deliveries != null)
                        {
                            target_order_delivery = order_deliveries.Where(x => x.ID == DeliveryID).FirstOrDefault();
                            if (target_order_delivery != null)
                            {
                                target_product_order = product_orders.Where(x => x.ID == target_order_delivery.OrderID).FirstOrDefault();
                                if (target_product_order != null)
                                {
                                    productordercell.Value = target_product_order.ID;
                                }
                                target_delivery_service = delivery_services.Where(x => x.ID == target_order_delivery.DeliveryServiceID).FirstOrDefault();
                                if (target_delivery_service != null)
                                {
                                    deliveryservicecell.Value = target_delivery_service.ID;
                                }
                                target_payment_method = payment_methods.Where(x => x.ID == target_order_delivery.PaymentMethodID).FirstOrDefault();
                                if (target_payment_method != null)
                                {
                                    paymentmethodcell.Value = target_payment_method.ID;
                                }
                                statuscell.Value = target_order_delivery.DeliveryStatus; //this is not good
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
