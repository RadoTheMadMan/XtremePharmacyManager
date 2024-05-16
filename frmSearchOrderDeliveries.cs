using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
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
        static Logger logger;
        static BulkOperationManager<OrderDelivery> manager;
        static List<ProductOrder> product_orders;
        static List<OrderDelivery> order_deliveries;
        static List<DeliveryService> delivery_services;
        static List<PaymentMethod> payment_methods;
        public frmSearchOrderDeliveries(ref Entities entity,ref Logger extlogger, ref BulkOperationManager<OrderDelivery> deliverymanager)
        {
            ent = entity;
            logger = extlogger;
            manager = deliverymanager;
            InitializeComponent();
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOrderDeliveries()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    order_deliveries = ent.GetOrderDelivery(-1,-1,-1,-1,"",new decimal(),new DateTime(), new DateTime(), new DateTime(), new DateTime(),0,"").ToList();
                    dgvOrderDeliveries.DataSource = order_deliveries;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string CargoID = txtCargoID.Text;
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
                        x.CargoID.Contains(CargoID) ^ (x.TotalPrice <= TotalPrice || x.TotalPrice >= TotalPrice)).ToList();
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
                        x.CargoID.Contains(CargoID) || (x.TotalPrice <= TotalPrice || x.TotalPrice >= TotalPrice)).ToList();
                dgvOrderDeliveries.DataSource = order_deliveries;
            }
            else if (SearchMode == 3)
            {
                RefreshProductOrders();
                RefreshDeliveryServices();
                RefreshPaymentMethods();
                order_deliveries = ent.GetOrderDelivery(DeliveryID,OrderID,DeliveryServiceID,PaymentMethodID,CargoID,new decimal(),new DateTime(),new DateTime(), new DateTime(), new DateTime(),0,"").ToList();
                dgvOrderDeliveries.DataSource = order_deliveries;
            }
            else
            {
                RefreshProductOrders();
                RefreshDeliveryServices();
                RefreshPaymentMethods();
                RefreshOrderDeliveries();
            }
            logger.RefreshLogs();
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
                            //For Deliveries we will not allow anyone to edit orders who were completed, returned or cancelled
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
                                        ent.UpdateOrderDeliveryByID(selectedDelivery.ID, selectedDelivery.OrderID,selectedDelivery.DeliveryServiceID,selectedDelivery.PaymentMethodID,selectedDelivery.CargoID,selectedDelivery.DeliveryStatus,selectedDelivery.DeliveryReason);
                                        ent.SaveChanges();
                                        //whenever you do an operation on something check if it exist in the database views and reload it in the model
                                        //if it exist in the views and/or the tables
                                        ExtendedOrderDeliveriesView od_view = ent.ExtendedOrderDeliveriesViews.Where(x => x.ID == selectedDelivery.ID).FirstOrDefault();
                                        if (od_view != null)
                                        {
                                            ent.Entry(od_view).Reload();
                                        }
                                        RefreshDeliveryServices();
                                        RefreshPaymentMethods();
                                        RefreshProductOrders();
                                        RefreshOrderDeliveries();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkOrderDeliveryOperation(BulkOperationType.UPDATE, ref ent, selectedDelivery, true));
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
                                        ent.AddOrderDelivery(selectedDelivery.OrderID,selectedDelivery.DeliveryServiceID,selectedDelivery.PaymentMethodID,selectedDelivery.CargoID,selectedDelivery.DeliveryReason);
                                        ent.SaveChanges();
                                        //whenever you do an operation on something check if it exist in the database views and reload it in the model
                                        //if it exist in the views and/or the tables
                                        ExtendedOrderDeliveriesView od_view = ent.ExtendedOrderDeliveriesViews.Where(x => x.ID == selectedDelivery.ID).FirstOrDefault();
                                        if (od_view != null)
                                        {
                                            ent.Entry(od_view).Reload();
                                        }
                                        RefreshDeliveryServices();
                                        RefreshPaymentMethods();
                                        RefreshProductOrders();
                                        RefreshOrderDeliveries();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkOrderDeliveryOperation(BulkOperationType.ADD, ref ent, selectedDelivery, true));
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
                                    ent.AddOrderDelivery(selectedDelivery.OrderID, selectedDelivery.DeliveryServiceID, selectedDelivery.PaymentMethodID, selectedDelivery.CargoID, selectedDelivery.DeliveryReason);
                                    ent.SaveChanges();
                                    //whenever you do an operation on something check if it exist in the database views and reload it in the model
                                    //if it exist in the views and/or the tables
                                    ExtendedOrderDeliveriesView od_view = ent.ExtendedOrderDeliveriesViews.Where(x => x.ID == selectedDelivery.ID).FirstOrDefault();
                                    if (od_view != null)
                                    {
                                        ent.Entry(od_view).Reload();
                                    }
                                    RefreshDeliveryServices();
                                    RefreshPaymentMethods();
                                    RefreshProductOrders();
                                    RefreshOrderDeliveries();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkOrderDeliveryOperation(BulkOperationType.ADD, ref ent, selectedDelivery, true));
                                }
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
                            ent.AddOrderDelivery(selectedDelivery.OrderID, selectedDelivery.DeliveryServiceID, selectedDelivery.PaymentMethodID, selectedDelivery.CargoID, selectedDelivery.DeliveryReason);
                            ent.SaveChanges();
                            //whenever you do an operation on something check if it exist in the database views and reload it in the model
                            //if it exist in the views and/or the tables
                            ExtendedOrderDeliveriesView od_view = ent.ExtendedOrderDeliveriesViews.Where(x => x.ID == selectedDelivery.ID).FirstOrDefault();
                            if (od_view != null)
                            {
                                ent.Entry(od_view).Reload();
                            }
                            RefreshDeliveryServices();
                            RefreshPaymentMethods();
                            RefreshProductOrders();
                            RefreshOrderDeliveries();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkOrderDeliveryOperation(BulkOperationType.ADD, ref ent, selectedDelivery, true));
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        ent.SaveChanges();
                                        //whenever you do an operation on something check if it exist in the database views and reload it in the model
                                        //if it exist in the views and/or the tables
                                        ExtendedOrderDeliveriesView od_view = ent.ExtendedOrderDeliveriesViews.Where(x=>x.ID == selectedDelivery.ID).FirstOrDefault();
                                        if(od_view != null)
                                        {
                                            ent.Entry(od_view).Reload();
                                        }
                                        RefreshDeliveryServices();
                                        RefreshPaymentMethods();
                                        RefreshProductOrders();
                                        RefreshOrderDeliveries();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkOrderDeliveryOperation(BulkOperationType.DELETE, ref ent, selectedDelivery, true));
                                    }
                                }
                            }
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrderDeliveries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int DeliveryID = -1;
            OrderDelivery target_delivery;
            ProductOrder target_order;
            DeliveryService target_service;
            PaymentMethod target_method;
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
                            target_order = product_orders.Where(x => x.ID == target_delivery.OrderID).FirstOrDefault();
                            if (target_order != null && cbSelectProductOrder.Items.Contains(target_order))
                            {
                                cbSelectProductOrder.SelectedValue = target_order.ID;
                            }
                            else
                            {
                                cbSelectProductOrder.DataSource = ent.ProductOrders.ToList();
                                cbSelectProductOrder.SelectedValue = ent.ProductOrders.FirstOrDefault().ID;
                            }
                            target_service = delivery_services.Where(x => x.ID == target_delivery.DeliveryServiceID).FirstOrDefault();
                            if (target_service != null && cbSelectDeliveryService.Items.Contains(target_service))
                            {
                                cbSelectDeliveryService.SelectedValue = target_service.ID;
                            }
                            else
                            {
                                cbSelectDeliveryService.DataSource = ent.DeliveryServices.ToList();
                                cbSelectDeliveryService.SelectedValue= ent.DeliveryServices.FirstOrDefault().ID;
                            }
                            target_method = payment_methods.Where(x => x.ID == target_delivery.PaymentMethodID).FirstOrDefault();
                            if (target_method != null && cbSelectPaymentMethod.Items.Contains(target_method))
                            {
                                cbSelectPaymentMethod.SelectedValue = target_method.ID;
                            }
                            else
                            {
                                cbSelectPaymentMethod.DataSource = ent.PaymentMethods.ToList();
                                cbSelectPaymentMethod.SelectedValue= ent.PaymentMethods.FirstOrDefault().ID;
                            }
                            dtDateAddedFrom.Value = target_delivery.DateAdded;
                            dtDateModifiedFrom.Value = target_delivery.DateModified;
                            txtCargoID.Text = target_delivery.CargoID;
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrderDeliveries_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewComboBoxCell productordercell;
            DataGridViewComboBoxColumn productordercolumn;
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
                        productordercolumn = (DataGridViewComboBoxColumn)target_view.Columns["ProductOrderIDColumn"];
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
                                if (target_product_order != null && productordercolumn.Items.Contains(target_product_order))
                                {
                                    productordercell.Value = target_product_order.ID;
                                }
                                else
                                {
                                    productordercolumn.DataSource = ent.ProductOrders.ToList();
                                    productordercell.Value = ent.ProductOrders.FirstOrDefault().ID;
                                }
                                target_delivery_service = delivery_services.Where(x => x.ID == target_order_delivery.DeliveryServiceID).FirstOrDefault();
                                if (target_delivery_service != null && deliveryservicecolumn.Items.Contains(target_delivery_service))
                                {
                                    deliveryservicecell.Value = target_delivery_service.ID;
                                }
                                else
                                {
                                    deliveryservicecolumn.DataSource = ent.DeliveryServices.ToList();
                                    deliveryservicecell.Value = ent.DeliveryServices.FirstOrDefault().ID;
                                }
                                target_payment_method = payment_methods.Where(x => x.ID == target_order_delivery.PaymentMethodID).FirstOrDefault();
                                if (target_payment_method != null && paymentmethodcolumn.Items.Contains(target_payment_method))
                                {
                                    paymentmethodcell.Value = target_payment_method.ID;
                                }
                                else
                                {
                                    paymentmethodcolumn.DataSource = ent.PaymentMethods.ToList();
                                    paymentmethodcell.Value= ent.PaymentMethods.FirstOrDefault().ID;
                                }
                                statuscell.Value = statuscolumn.Items[target_order_delivery.DeliveryStatus]; //this is not good
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchOrderDeliveries_Load(object sender, EventArgs e)
        {
            RefreshDeliveryServices();
            RefreshPaymentMethods();
            RefreshProductOrders();
            RefreshOrderDeliveries();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            OrderDelivery currentDelivery;
            string target_report_file;
            bool IsInvoice = false;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (MessageBox.Show("Do you want to generate invoice for this order delivery?", "Report Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    IsInvoice = true;
                }
                else
                {
                    IsInvoice = false;
                }
                if (dgvOrderDeliveries.SelectedRows.Count > 0)
                {
                    row = dgvOrderDeliveries.SelectedRows[0];
                    if (row != null && product_orders != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                        //Contrary to the CRUD operations, report generating will be for all records no matter
                        //if they are dummy or not
                        currentDelivery = order_deliveries.Where(x => x.ID == ID).FirstOrDefault();
                        if (currentDelivery != null)
                        {
                            if (IsInvoice)
                            {
                                target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.ORDER_DELIVERY_INVOICE_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            }                                                                                
                            else                                                                             
                            {                                                                                
                                target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.ORDER_DELIVERY_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            }
                            ExtendedOrderDeliveriesView view = ent.ExtendedOrderDeliveriesViews.Where(x => x.ID == currentDelivery.ID).FirstOrDefault();
                            if (view != null)
                            {
                                Type view_type = view.GetType();
                                DataTable dt = new DataTable();
                                Object[] values = new Object[view_type.GetProperties().Length];
                                int propindex = 0; //track the property index
                                //this is experimental and I am trying it because I added copious amounts of stats to the views but hadn't
                                //imported them yet
                                foreach (var prop in view_type.GetProperties())
                                {
                                    dt.Columns.Add(prop.Name);
                                    values[propindex] = prop.GetValue(view, null);
                                    propindex++; //indrease the property index after adding the property name
                                    //in for and foreach loops everything starts from 0 as always
                                }
                                propindex = 0; //reset the index
                                dt.Rows.Add(values); //add the values
                                foreach (ExtendedOrderDeliveriesView od_view in ent.ExtendedOrderDeliveriesViews)
                                {
                                    //as stats are added in the view there is no need for most of them to be calculated
                                    //because the database calculates them for us there is no need for all of the entries
                                    //to be imported to the report unless there is an invoice situation like here
                                    Array.Clear(values, 0, values.Length); //so clear the values first
                                    if (od_view != view)
                                    {
                                        if (IsInvoice)
                                        {
                                            if (od_view.DateAdded == view.DateAdded && od_view.ClientName == view.ClientName)
                                            {
                                                foreach (var prop in view_type.GetProperties())
                                                {
                                                    values[propindex] = prop.GetValue(od_view, null);
                                                    propindex++; //indrease the property index after adding the property name
                                                    //in for and foreach loops everything starts from 0 as always
                                                }
                                                dt.Rows.Add(values); //add the values
                                                propindex = 0; //reset the property index to be back to zero
                                            }
                                        }
                                    }
                                }
                                //reset the property index to be zero again
                                propindex = 0;
                                //then clear the values to ensure memory is not wasted
                                Array.Clear(values, 0, values.Length);
                                current_source = new ReportDataSource("OrderDeliveryReportData", dt);
                                current_params = new ReportParameterCollection();
                                current_params.Add(new ReportParameter("StatusName", cbSelectDeliveryStatus.Items[view.DeliveryStatus].ToString()));
                                current_params.Add(new ReportParameter("CompanyName", GLOBAL_RESOURCES.COMPANY_NAME));
                                new frmReports(target_report_file, ref current_source, ref current_params).Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
