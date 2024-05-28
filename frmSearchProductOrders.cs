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
using System.Runtime.InteropServices;
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
        static User current_user;
        static BulkOperationManager<ProductOrder> manager;
        static List<Product> products;
        static List<ProductOrder> product_orders;
        static List<User> employees;
        static List<User> clients;
        public frmSearchProductOrders(ref Entities entity, ref User currentUser, ref Logger extlogger, ref BulkOperationManager<ProductOrder> ordermanager)
        {
            ent = entity;
            logger = extlogger;
            current_user = currentUser;
            manager = ordermanager;
            manager.BulkOperationsExecuted += ProductOrders_BulkOperationExecuted;
            InitializeComponent();
        }

        private void ProductOrders_BulkOperationExecuted(object sender, BulkOperationEventArgs<ProductOrder> e)
        {
            RefreshProducts();
            RefreshEmployees();
            RefreshClients();
            RefreshProductOrders();
            logger.RefreshLogs();
        }

        private void RefreshProducts()
        {
            try
            {
               
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    products = ent.GetProduct(-1, "", -1, -1, "", 0, new decimal(), new DateTime(), new DateTime(), "", "", "").ToList();
                    foreach(var product in products)
                    {
                        //reload every entry in the entity model associated with the retrieved entries
                        ent.Entry(ent.Products.Where(x => x.ID == product.ID).FirstOrDefault()).Reload();
                    }
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
                if (ent.Database.Connection.State == ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    product_orders = ent.GetProductOrder(-1, -1, 0, new decimal(), -1, -1, new DateTime(), new DateTime(), new DateTime(), new DateTime(), 0, "").ToList();
                    foreach (var product_order in product_orders)
                    {
                        ent.Entry(ent.ProductOrders.Where(x => x.ID == product_order.ID).FirstOrDefault()).Reload();
                    }
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
                if (ent.Database.Connection.State == ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    employees = ent.Users.Where(x => x.UserRole == 0 || x.UserRole == 1).ToList();
                    foreach (var user in employees)
                    {
                        ent.Entry(ent.Users.Where(x=>x.ID == user.ID).FirstOrDefault()).Reload();
                    }
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
                if (ent.Database.Connection.State == ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    clients = ent.Users.Where(x => x.UserRole == 2).ToList();
                    foreach (var user in employees)
                    {
                        ent.Entry(ent.Users.Where(x => x.ID == user.ID).FirstOrDefault()).Reload();
                    }
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
            if (SearchMode == 1 && (current_user.UserRole == 0 || current_user.UserRole == 1))
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
            else if (SearchMode == 2 && (current_user.UserRole == 0 || current_user.UserRole == 1))
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
            else if (SearchMode == 3 && (current_user.UserRole == 0 || current_user.UserRole == 1))
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
                if (current_user.UserRole != 0 && current_user.UserRole != 1)
                {
                    MessageBox.Show("Product Orders list access is given only to administrators and employees of this system.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                RefreshProductOrders();
            }
            logger.RefreshLogs();
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            txtPriceOverride.Text = trbPriceOverride.Value.ToString();
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            txtDesiredQuantity.Text = trbDesiredQuantity.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int OrderID = -1;
            ProductOrder selectedOrder;
            try
            {
                if (dgvProductOrders.SelectedRows.Count > 0 && (current_user.UserRole == 0 || current_user.UserRole == 1))
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
                                //Show the editor window to edit the selected product order or whatever it is now
                                //on dialog result yes update it
                                DialogResult res = new frmEditProductOrder(ref selectedOrder, ref products, ref clients, ref employees).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateProductOrderByID(selectedOrder.ID, selectedOrder.ProductID, selectedOrder.DesiredQuantity,
                                            selectedOrder.OrderPrice, selectedOrder.ClientID, selectedOrder.EmployeeID, selectedOrder.OrderStatus,
                                            selectedOrder.OrderReason);
                                        //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                                        ExtendedProductOrdersView pro_view = ent.ExtendedProductOrdersViews.Where(x => x.ID == selectedOrder.ID).FirstOrDefault();
                                        if (pro_view != null)
                                        {
                                            ent.Entry(pro_view).Reload();
                                        }
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
                                        //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                                        ExtendedProductOrdersView pro_view = ent.ExtendedProductOrdersViews.Where(x => x.ID == selectedOrder.ID).FirstOrDefault();
                                        if (pro_view != null)
                                        {
                                            ent.Entry(pro_view).Reload();
                                        }
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
                                    //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                                    ExtendedProductOrdersView pro_view = ent.ExtendedProductOrdersViews.Where(x => x.ID == selectedOrder.ID).FirstOrDefault();
                                    if (pro_view != null)
                                    {
                                        ent.Entry(pro_view).Reload();
                                    }
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
                else if (current_user.UserRole == 0 || current_user.UserRole == 1)
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
                           //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                            ExtendedProductOrdersView pro_view = ent.ExtendedProductOrdersViews.Where(x => x.ID == selectedOrder.ID).FirstOrDefault();
                            if (pro_view != null)
                            {
                                ent.Entry(pro_view).Reload();
                            }
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
                else
                {
                    MessageBox.Show($"You don't have permissions to add/edit product orders.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                RefreshProductOrders();
                logger.RefreshLogs();
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
                if (dgvProductOrders.SelectedRows.Count > 0 && (current_user.UserRole == 0 || current_user.UserRole == 1))
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
                                //Show the editor window to delete the selected product order or whatever it is
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteProductOrderByID(selectedOrder.ID);
                                        //get the view of the table where the table entry exists and if exist reload to ensure it has updated data
                                        ExtendedProductOrdersView pro_view = ent.ExtendedProductOrdersViews.Where(x=> x.ID == selectedOrder.ID).FirstOrDefault();
                                        if(pro_view != null)
                                        {
                                            ent.Entry(pro_view).Reload();
                                        }
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
                else
                {
                    MessageBox.Show($"You don't have permissions to delete product orders.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                RefreshProductOrders();
                logger.RefreshLogs();
            }
        }

        private void dgvProductOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int OrderID = -1;
            ProductOrder target_order;
            Product target_product;
            User target_employee;
            User target_client;
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
                            target_product = products.Where(x=>x.ID == target_order.ProductID).FirstOrDefault();
                            if (target_product != null && cbSelectProduct.Items.Contains(target_product))
                            {
                                cbSelectProduct.SelectedValue = target_product.ID;
                            }
                            else
                            {
                                cbSelectProduct.DataSource = ent.Products.ToList();
                                cbSelectProduct.SelectedValue = ent.Products.FirstOrDefault().ID;
                            }
                            target_employee = employees.Where(x=>x.ID == target_order.EmployeeID).FirstOrDefault();
                            if (target_employee != null && cbSelectEmployee.Items.Contains(target_employee))
                            {
                                cbSelectEmployee.SelectedValue = target_employee.ID;
                            }
                            else
                            {
                                cbSelectEmployee.DataSource = ent.Users.ToList();
                                cbSelectEmployee.SelectedValue = ent.Users.FirstOrDefault().ID;
                            }
                            target_client = clients.Where(x=>x.ID == target_order.ClientID).FirstOrDefault();
                            if (target_client != null && cbSelectClient.Items.Contains(target_client))
                            {
                                cbSelectClient.SelectedValue = target_client.ID;
                            }
                            else
                            {
                                cbSelectClient.DataSource = ent.Users.ToList();
                                cbSelectClient.SelectedValue =ent.Users.FirstOrDefault().ID;
                            }
                            dtDateAddedFrom.Value = target_order.DateAdded;
                            dtDateModifiedFrom.Value = target_order.DateModified;
                            txtOrderReason.Text = target_order.OrderReason.ToString();
                            txtDesiredQuantity.Text = target_order.DesiredQuantity.ToString();
                            trbDesiredQuantity.Value = target_order.DesiredQuantity;
                            txtPriceOverride.Text = Convert.ToInt32(target_order.OrderPrice).ToString();
                            trbPriceOverride.Value = Convert.ToInt32(target_order.OrderPrice);
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
                                if (target_product != null && productcolumn.Items.Contains(target_product))
                                {
                                    productcell.Value = target_product.ID;
                                }
                                else
                                {
                                    productcolumn.DataSource = ent.Products.ToList();
                                    productcell.Value = ent.Products.FirstOrDefault().ID;
                                }
                                target_employee = employees.Where(x => x.ID == target_product_order.EmployeeID).FirstOrDefault();
                                if (target_employee != null && employeecolumn.Items.Contains(target_employee))
                                {
                                    employeecell.Value = target_employee.ID;
                                }
                                else
                                {
                                    employeecolumn.DataSource = ent.Users.ToList();
                                    employeecell.Value = ent.Users.FirstOrDefault().ID;
                                }
                                target_client = clients.Where(x => x.ID == target_product_order.ClientID).FirstOrDefault();
                                if (target_client != null && clientcolumn.Items.Contains(target_client))
                                {
                                    clientcell.Value = target_client.ID;
                                }
                                else
                                {
                                    clientcolumn.DataSource = ent.Users.ToList();
                                    clientcell.Value = ent.Users.FirstOrDefault().ID;
                                }
                                //if there is a fixed list of string don't put data property that is not string because it hurts
                                statuscell.Value = statuscolumn.Items[target_product_order.OrderStatus]; 
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
            ProductOrder currentOrder;
            string target_report_file;
            bool IsInvoice = false;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
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
                            currentOrder = product_orders.Where(x => x.ID == ID).FirstOrDefault();
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
                                    foreach (ExtendedProductOrdersView po_view in ent.ExtendedProductOrdersViews)
                                    {
                                        //as stats are added in the view there is no need for most of them to be calculated
                                        //because the database calculates them for us there is no need for all of the entries
                                        //to be imported to the report unless there is an invoice situation like here
                                        Array.Clear(values, 0, values.Length); //so clear the values first
                                        if (po_view != view)
                                        {
                                            if (IsInvoice)
                                            {
                                                if (po_view.DateAdded == view.DateAdded && po_view.ClientName == view.ClientName)
                                                {
                                                    foreach (var prop in view_type.GetProperties())
                                                    {
                                                        values[propindex] = prop.GetValue(po_view, null);
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
                else
                {
                    MessageBox.Show($"Product order reports cannot be generated or you don't have permissions to view them", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPriceOverride_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(((TextBox)sender).Text, out value);
            if (value >= trbPriceOverride.Maximum)
            {
                trbPriceOverride.Maximum = value;
            }
            trbPriceOverride.Value = value;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(((TextBox)sender).Text, out value);
            if (value >= trbDesiredQuantity.Maximum)
            {
                trbDesiredQuantity.Maximum = value;
            }
            trbDesiredQuantity.Value = value;
        }

        private void frmSearchProductOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null)
            {
                manager.BulkOperationsExecuted -= ProductOrders_BulkOperationExecuted;
                manager = null;
            }
            if (product_orders != null)
            {
                product_orders.Clear();
                product_orders = null;
            }
            if (products != null)
            {
                products.Clear();
                products = null;
            }
            if(employees != null)
            {
                employees.Clear();
                employees = null;
            }
            if (clients != null)
            {
                clients.Clear();
                clients = null;
            }
            if (current_user != null)
            {
                current_user = null;
            }
            if (logger != null)
            {
                logger = null;
            }
            if (ent != null)
            {
                ent = null;
            }
        }
    }
}
