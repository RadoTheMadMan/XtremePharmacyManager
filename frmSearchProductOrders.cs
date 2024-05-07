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
    public partial class frmSearchProductOrders : Form
    {
        //Usually views shouldn't be used in anything instead of reports but this time it is an exception
        //for easy to use separation between users who are employees and users who are clients and minimal error
        //I hope it works for 
        static Entities ent;
        static Logger logger;
        static BulkOperationManager<ProductOrder> manager;
        static List<Product> products;
        static List<ProductOrder> product_orders;
        static List<User> employees;
        static List<User> clients;
        public frmSearchProductOrders(ref Entities entity, ref Logger extlogger, ref BulkOperationManager<ProductOrder> ordermanager)
        {
            ent = entity;
            logger = extlogger;
            manager = ordermanager;
            InitializeComponent();
        }

        private void RefreshProducts()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    products = ent.GetProduct(-1, "", -1, "", 0, new decimal(), new DateTime(), new DateTime(), "", "", "").ToList();
                    cbSelectProduct.DataSource = products;
                    ProductIDColumn.DataSource = products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductOrders()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_orders = ent.GetProductOrder(-1, -1, 0, new decimal(), -1, -1, new DateTime(), new DateTime(), new DateTime(), new DateTime(), 0, "").ToList();
                    dgvProductOrders.DataSource = product_orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshEmployees()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    employees = ent.Users.Where(x => x.UserRole == 0 || x.UserRole == 1).ToList();
                    cbSelectEmployee.DataSource = employees;
                    EmployeeIDColumn.DataSource = employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshClients()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    clients = ent.Users.Where(x => x.UserRole == 2).ToList();
                    cbSelectClient.DataSource = clients;
                    ClientIDColumn.DataSource = clients;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            int OrderID = -1;
            int ProductID = -1;
            int EmployeeID = -1;
            int ClientID = -1;
            int OrderStatus = 0;
            Int32.TryParse(txtID.Text, out OrderID);
            if (cbSelectProduct.SelectedValue != null)
            {
                Int32.TryParse(cbSelectProduct.SelectedValue.ToString(), out ProductID);
            }
            if (cbSelectEmployee.SelectedValue != null)
            {
                Int32.TryParse(cbSelectEmployee.SelectedValue.ToString(), out EmployeeID);
            }
            if (cbSelectClient.SelectedValue != null)
            {
                Int32.TryParse(cbSelectClient.SelectedValue.ToString(), out ClientID);
            }
            OrderStatus = cbSelectOrderStatus.SelectedIndex;
            DateTime DateAddedFrom = dtDateAddedFrom.Value;
            DateTime DateAddedTo = dtDateAddedTo.Value;
            DateTime DateModifiedFrom = dtDateModifiedFrom.Value;
            DateTime DateModifiedTo = dtDateModifiedTo.Value;
            int DesiredQuantity = trbDesiredQuantity.Value;
            decimal PriceOverride = trbPriceOverride.Value;
            string OrderReason = txtOrderReason.Text;
            int SearchMode = cbSearchMode.SelectedIndex;
            if (SearchMode == 1)
            {
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                product_orders = ent.ProductOrders.Where(
                    x => x.ID == OrderID ^ x.ProductID == ProductID ^ x.EmployeeID == EmployeeID ^ x.ClientID == ClientID ^
                        (x.DateAdded >= DateAddedFrom && x.DateAdded <= DateAddedTo) ^ x.OrderReason.Contains(OrderReason) ^
                        (x.DateModified >= DateModifiedFrom && x.DateModified <= DateModifiedTo) ^ x.OrderStatus == OrderStatus ^
                        (x.DesiredQuantity <= DesiredQuantity || x.DesiredQuantity >= DesiredQuantity) ^
                        (x.OrderPrice <= PriceOverride || x.OrderPrice >= PriceOverride)).ToList();
                dgvProductOrders.DataSource = product_orders;
            }
            else if (SearchMode == 2)
            {
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                product_orders = ent.ProductOrders.Where(
                    x => x.ID == OrderID || x.ProductID == ProductID || x.EmployeeID == EmployeeID || x.ClientID == ClientID ||
                        (x.DateAdded >= DateAddedFrom && x.DateAdded <= DateAddedTo) || x.OrderReason.Contains(OrderReason) ||
                        (x.DateModified >= DateModifiedFrom && x.DateModified <= DateModifiedTo) || x.OrderStatus == OrderStatus ||
                        (x.DesiredQuantity <= DesiredQuantity || x.DesiredQuantity >= DesiredQuantity) ||
                        (x.OrderPrice <= PriceOverride || x.OrderPrice >= PriceOverride)).ToList();
                dgvProductOrders.DataSource = product_orders;
            }
            else if (SearchMode == 3)
            {
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                product_orders = ent.GetProductOrder(OrderID, ProductID, DesiredQuantity, PriceOverride, ClientID, EmployeeID,
                    DateAddedFrom, DateAddedTo, DateModifiedFrom, DateModifiedTo, OrderStatus, OrderReason).ToList();
                dgvProductOrders.DataSource = product_orders;
            }
            else
            {
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                RefreshProductOrders();
            }
            logger.RefreshLogs();
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPriceOverride.Text = trbPriceOverride.Value.ToString();
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            lblShowDesiredQuantity.Text = trbDesiredQuantity.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int OrderID = -1;
            ProductOrder selectedOrder;
            try
            {
                if (dgvProductOrders.SelectedRows.Count > 0)
                {
                    row = dgvProductOrders.SelectedRows[0];
                    if (row != null && product_orders != null && products != null && clients != null && employees != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out OrderID);
                        if (OrderID > 0)
                        {
                            //For Orders we will not allow anyone to edit orders who were completed, returned or cancelled
                            selectedOrder = product_orders.Where(x => x.ID == OrderID && (x.OrderStatus != 7 || x.OrderStatus != 8 || x.OrderStatus != 9)).FirstOrDefault();
                            if (selectedOrder != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditProductOrder(ref selectedOrder, ref products, ref clients, ref employees).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateProductOrderByID(selectedOrder.ID, selectedOrder.ProductID, selectedOrder.DesiredQuantity,
                                            selectedOrder.OrderPrice, selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderStatus,
                                            selectedOrder.OrderReason);
                                        ent.SaveChanges();
                                        RefreshEmployees();
                                        RefreshClients();
                                        RefreshProducts();
                                        RefreshProductOrders();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    bool OverridePriceAsTotal = false;
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        if (MessageBox.Show("Do you want the bulk order operation to add order with total price override on create?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            OverridePriceAsTotal = true;
                                            manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.UPDATE, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                        }
                                        else
                                        {
                                            OverridePriceAsTotal = false;
                                            manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.UPDATE, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Create a new one
                                selectedOrder = new ProductOrder();
                                DialogResult res = new frmEditProductOrder(ref selectedOrder, ref products, ref clients, ref employees).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        bool OverridePriceAsTotal = false;
                                        res = MessageBox.Show("Do you want to override the price of that order as total?", "New Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (res == DialogResult.Yes)
                                        {
                                            OverridePriceAsTotal = true;
                                            ent.AddProductOrder(selectedOrder.ProductID, selectedOrder.DesiredQuantity, selectedOrder.OrderPrice,
                                            selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderReason, OverridePriceAsTotal);
                                        }
                                        else
                                        {
                                            OverridePriceAsTotal = false;
                                            ent.AddProductOrder(selectedOrder.ProductID, selectedOrder.DesiredQuantity, selectedOrder.OrderPrice,
                                            selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderReason, OverridePriceAsTotal);
                                        }
                                        ent.SaveChanges();
                                        RefreshEmployees();
                                        RefreshClients();
                                        RefreshProducts();
                                        RefreshProductOrders();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    bool OverridePriceAsTotal = false;
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        if (MessageBox.Show("Do you want the bulk order operation to add order with total price override on create?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            OverridePriceAsTotal = true;
                                            manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.ADD, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                        }
                                        else
                                        {
                                            OverridePriceAsTotal = false;
                                            manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.ADD, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Create a new one
                            selectedOrder = new ProductOrder();
                            DialogResult res = new frmEditProductOrder(ref selectedOrder, ref products, ref clients, ref employees).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    bool OverridePriceAsTotal = false;
                                    res = MessageBox.Show("Do you want to override the price of that order as total?", "New Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (res == DialogResult.Yes)
                                    {
                                        OverridePriceAsTotal = true;
                                        ent.AddProductOrder(selectedOrder.ProductID, selectedOrder.DesiredQuantity, selectedOrder.OrderPrice,
                                        selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderReason, OverridePriceAsTotal);
                                    }
                                    else
                                    {
                                        OverridePriceAsTotal = false;
                                        ent.AddProductOrder(selectedOrder.ProductID, selectedOrder.DesiredQuantity, selectedOrder.OrderPrice,
                                        selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderReason, OverridePriceAsTotal);
                                    }
                                    ent.SaveChanges();
                                    RefreshEmployees();
                                    RefreshClients();
                                    RefreshProducts();
                                    RefreshProductOrders();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                bool OverridePriceAsTotal = false;
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    if (MessageBox.Show("Do you want the bulk order operation to add order with total price override on create?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        OverridePriceAsTotal = true;
                                        manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.ADD, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                    }
                                    else
                                    {
                                        OverridePriceAsTotal = false;
                                        manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.ADD, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Create a new one
                    selectedOrder = new ProductOrder();
                    DialogResult res = new frmEditProductOrder(ref selectedOrder, ref products, ref clients, ref employees).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            bool OverridePriceAsTotal = false;
                            res = MessageBox.Show("Do you want to override the price of that order as total?", "New Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                OverridePriceAsTotal = true;
                                ent.AddProductOrder(selectedOrder.ProductID, selectedOrder.DesiredQuantity, selectedOrder.OrderPrice,
                                selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderReason, OverridePriceAsTotal);
                            }
                            else
                            {
                                OverridePriceAsTotal = false;
                                ent.AddProductOrder(selectedOrder.ProductID, selectedOrder.DesiredQuantity, selectedOrder.OrderPrice,
                                selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderReason, OverridePriceAsTotal);
                            }
                            ent.SaveChanges();
                            RefreshEmployees();
                            RefreshClients();
                            RefreshProducts();
                            RefreshProductOrders();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        bool OverridePriceAsTotal = false;
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            if (MessageBox.Show("Do you want the bulk order operation to add order with total price override on create?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                OverridePriceAsTotal = true;
                                manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.ADD, ref ent, selectedOrder, OverridePriceAsTotal, true));
                            }
                            else
                            {
                                OverridePriceAsTotal = false;
                                manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.ADD, ref ent, selectedOrder, OverridePriceAsTotal, true));
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int OrderID = -1;
            ProductOrder selectedOrder;
            try
            {
                if (dgvProductOrders.SelectedRows.Count > 0)
                {
                    row = dgvProductOrders.SelectedRows[0];
                    if (row != null && products != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out OrderID);
                        if (OrderID > 0)
                        {
                            selectedOrder = product_orders.Where(x => x.ID == OrderID).FirstOrDefault();
                            if (selectedOrder != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteProductOrderByID(selectedOrder.ID);
                                        ent.SaveChanges();
                                        RefreshEmployees();
                                        RefreshClients();
                                        RefreshProducts();
                                        RefreshProductOrders();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    bool OverridePriceAsTotal = false;
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        if (MessageBox.Show("Do you want the bulk order operation to add order with total price override on create?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            OverridePriceAsTotal = true;
                                            manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.DELETE, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                        }
                                        else
                                        {
                                            OverridePriceAsTotal = false;
                                            manager.AddOperation(new BulkProductOrderOperation(BulkOperationType.DELETE, ref ent, selectedOrder, OverridePriceAsTotal, true));
                                        }
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

        private void dgvProductOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int OrderID = -1;
            ProductOrder target_order;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out OrderID);
                    if (OrderID >= 0 && products != null)
                    {
                        target_order = product_orders.Where(x => x.ID == OrderID).FirstOrDefault();
                        if (target_order != null)
                        {
                            txtID.Text = target_order.ID.ToString();
                            if (cbSelectProduct.Items.Contains(products.Where(x => x.ID == target_order.ProductID)))
                            {
                                cbSelectProduct.SelectedValue = target_order.ProductID;
                            }
                            if (cbSelectEmployee.Items.Contains(employees.Where(x => x.ID == target_order.EmployeeID)))
                            {
                                cbSelectEmployee.SelectedValue = target_order.EmployeeID;
                            }
                            if (cbSelectClient.Items.Contains(clients.Where(x => x.ID == target_order.ClientID)))
                            {
                                cbSelectClient.SelectedValue = target_order.ClientID;
                            }
                            dtDateAddedFrom.Value = target_order.DateAdded;
                            dtDateModifiedFrom.Value = target_order.DateModified;
                            txtOrderReason.Text = target_order.OrderReason.ToString();
                            trbDesiredQuantity.Value = target_order.DesiredQuantity;
                            lblShowDesiredQuantity.Text = target_order.DesiredQuantity.ToString();
                            trbPriceOverride.Value = Convert.ToInt32(target_order.OrderPrice);
                            lblShowPriceOverride.Text = target_order.OrderPrice.ToString();
                            cbSelectOrderStatus.SelectedIndex = target_order.OrderStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductOrders_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewComboBoxCell productcell;
            DataGridViewComboBoxColumn productcolumn;
            DataGridViewComboBoxCell employeecell;
            DataGridViewComboBoxColumn employeecolumn;
            DataGridViewComboBoxCell clientcell;
            DataGridViewComboBoxColumn clientcolumn;
            DataGridViewComboBoxCell statuscell;
            DataGridViewComboBoxColumn statuscolumn;
            int OrderD = -1;
            ProductOrder target_product_order;
            Product target_product;
            User target_employee;
            User target_client;
            try
            {
                foreach (DataGridViewRow row in target_view.Rows)
                {
                    if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                    {
                        productcell = (DataGridViewComboBoxCell)row.Cells["ProductIDColumn"];
                        productcolumn = (DataGridViewComboBoxColumn)target_view.Columns["ProductIDColumn"];
                        employeecell = (DataGridViewComboBoxCell)row.Cells["EmployeeIDColumn"];
                        employeecolumn = (DataGridViewComboBoxColumn)target_view.Columns["EmployeeIDColumn"];
                        clientcell = (DataGridViewComboBoxCell)row.Cells["ClientIDColumn"];
                        clientcolumn = (DataGridViewComboBoxColumn)target_view.Columns["ClientIDColumn"];
                        statuscell = (DataGridViewComboBoxCell)row.Cells["OrderStatusColumn"];
                        statuscolumn = (DataGridViewComboBoxColumn)target_view.Columns["OrderStatusColumn"];
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out OrderD);
                        if (products != null && employees != null && clients != null && product_orders != null)
                        {
                            target_product_order = product_orders.Where(x => x.ID == OrderD).FirstOrDefault();
                            if (target_product_order != null)
                            {
                                target_product = products.Where(x => x.ID == target_product_order.ProductID).FirstOrDefault();
                                if (target_product != null)
                                {
                                    productcell.Value = target_product.ID;
                                }
                                target_employee = employees.Where(x => x.ID == target_product_order.EmployeeID).FirstOrDefault();
                                if (target_employee != null)
                                {
                                    employeecell.Value = target_employee.ID;
                                }
                                target_client = clients.Where(x => x.ID == target_product_order.ClientID).FirstOrDefault();
                                if (target_client != null)
                                {
                                    clientcell.Value = target_client.ID;
                                }
                                statuscell.Value = statuscolumn.Items[target_product_order.OrderStatus]; //this is not good
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

        private void frmSearchProductOrders_Load(object sender, EventArgs e)
        {
            RefreshEmployees();
            RefreshClients();
            RefreshProducts();
            RefreshProductOrders();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            Product currentOrder;
            string target_report_file;
            bool IsInvoice = false;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (MessageBox.Show("Do you want to generate invoice for this product order?", "Report Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    IsInvoice = true;
                }
                else
                {
                    IsInvoice = false;
                }
                if (dgvProductOrders.SelectedRows.Count > 0)
                {
                    row = dgvProductOrders.SelectedRows[0];
                    if (row != null && products != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                        //Contrary to the CRUD operations, report generating will be for all records no matter
                        //if they are dummy or not
                        currentOrder = products.Where(x => x.ID == ID).FirstOrDefault();
                        if (currentOrder != null)
                        {
                            if (IsInvoice)
                            {
                                target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.PRODUCT_ORDER_INVOICE_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            }
                            else
                            {
                                target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.PRODUCT_ORDER_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            }
                            ExtendedProductOrdersView view = ent.ExtendedProductOrdersViews.Where(x => x.ID == currentOrder.ID).FirstOrDefault();
                            if (view != null)
                            {
                                DataTable dt = new DataTable();
                                dt.Columns.Add(nameof(view.ID));
                                dt.Columns.Add(nameof(view.ProductName));
                                dt.Columns.Add(nameof(view.BrandName));
                                dt.Columns.Add(nameof(view.ProductDescription));
                                dt.Columns.Add(nameof(view.DesiredQuantity));
                                dt.Columns.Add(nameof(view.OrderPrice));
                                dt.Columns.Add(nameof(view.ProductExpiryDate));
                                dt.Columns.Add(nameof(view.ClientName));
                                dt.Columns.Add(nameof(view.ClientPhone));
                                dt.Columns.Add(nameof(view.ClientEmail));
                                dt.Columns.Add(nameof(view.ClientAddress));
                                dt.Columns.Add(nameof(view.EmployeeName));
                                dt.Columns.Add(nameof(view.DateAdded));
                                dt.Columns.Add(nameof(view.DateModified));
                                dt.Columns.Add(nameof(view.OrderStatus));
                                dt.Columns.Add(nameof(view.OrderReason));
                                dt.Rows.Add(new object[]{
                                                          view.ID,
                                                          view.ProductName,
                                                          view.BrandName,
                                                          view.ProductDescription,
                                                          view.DesiredQuantity,
                                                          view.OrderPrice,
                                                          view.ProductExpiryDate,
                                                          view.ClientName,
                                                          view.ClientPhone,
                                                          view.ClientEmail,
                                                          view.ClientAddress,
                                                          view.EmployeeName,
                                                          view.DateAdded,
                                                          view.DateModified,
                                                          view.OrderStatus,
                                                          view.OrderReason
                                });
                                foreach (ExtendedProductOrdersView po_view in ent.ExtendedProductOrdersViews)
                                {
                                    if (po_view != view)
                                    {
                                        if (!IsInvoice)
                                        {
                                            //If there is a regular order add every other order as well so the target
                                            //order can be compared to the rest
                                            dt.Rows.Add(new object[]{
                                                             view.ID,
                                                             view.ProductName,
                                                             view.BrandName,
                                                             view.ProductDescription,
                                                             view.DesiredQuantity,
                                                             view.OrderPrice,
                                                             view.ProductExpiryDate,
                                                             view.ClientName,
                                                             view.ClientPhone,
                                                             view.ClientEmail,
                                                             view.ClientAddress,
                                                             view.EmployeeName,
                                                             view.DateAdded,
                                                             view.DateModified,
                                                             view.OrderStatus,
                                                             view.OrderReason
                                            });
                                        }
                                        else
                                        {
                                            //Here only orders who are related by client name and date added to the
                                            //target order shall be added because if a client made an order for more
                                            //than one product there will be multiple orders with the same client ID
                                            //and same date of adding to the database thus grouping them as one
                                            if (po_view.DateAdded == view.DateAdded && po_view.ClientName == view.ClientName)
                                            {
                                                dt.Rows.Add(new object[]{
                                                             view.ID,
                                                             view.ProductName,
                                                             view.BrandName,
                                                             view.ProductDescription,
                                                             view.DesiredQuantity,
                                                             view.OrderPrice,
                                                             view.ProductExpiryDate,
                                                             view.ClientName,
                                                             view.ClientPhone,
                                                             view.ClientEmail,
                                                             view.ClientAddress,
                                                             view.EmployeeName,
                                                             view.DateAdded,
                                                             view.DateModified,
                                                             view.OrderStatus,
                                                             view.OrderReason
                                            });
                                            }
                                        }
                                    }
                                }
                                current_source = new ReportDataSource("ProductOrderReportData", dt);
                                current_params = new ReportParameterCollection();
                                current_params.Add(new ReportParameter("StatusName", cbSelectOrderStatus.Items[view.OrderStatus].ToString()));
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
