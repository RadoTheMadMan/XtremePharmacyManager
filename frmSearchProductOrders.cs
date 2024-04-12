using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
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
        static List<Product> products;
        static List<ProductOrder> product_orders;
        static List<User> employees;
        static List<User> clients;
        public frmSearchProductOrders(Entities entity)
        {
            ent = entity;
            InitializeComponent();
            RefreshEmployees();
            RefreshClients();
            RefreshProductOrders();
            RefreshProducts();
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
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Int32.TryParse(cbSelectProduct.SelectedValue.ToString(), out ProductID);
            Int32.TryParse(cbSelectEmployee.SelectedValue.ToString(), out EmployeeID);
            Int32.TryParse(cbSelectClient.SelectedValue.ToString(), out ClientID);
            Int32.TryParse(cbSelectOrderStatus.SelectedValue.ToString(), out OrderStatus);
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
                RefreshClients();
                RefreshEmployees();
                product_orders = ent.ProductOrders.Where(
                    x => x.ID == OrderID ^ x.ProductID == ProductID ^ x.EmployeeID == EmployeeID ^ x.ClientID == ClientID ^
                        (x.DateAdded >= DateAddedFrom && x.DateAdded <= DateAddedTo) ^ x.OrderReason.Contains(OrderReason) ^
                        (x.DateModified >= DateModifiedFrom && x.DateModified <= DateModifiedTo) ^ x.OrderStatus == OrderStatus ^
                        (x.DesiredQuantity <= DesiredQuantity || x.DesiredQuantity >= DesiredQuantity) ^ 
                        (x.OrderPrice <= PriceOverride || x.OrderPrice >= PriceOverride)).ToList();
                dgvProductOrders.DataSource = products;
                int[] extractedids = new int[products.Count];
                for (int i = 0; i < extractedids.Count(); i++)
                {
                    extractedids[i] = products[i].ID;
                }
            }
            else if (SearchMode == 2)
            {
                RefreshEmployees();
                products = ent.Products.Where(
                    x => x.ID == OrderID || x.BrandID == EmployeeID || x.ProductName.Contains(ProductName) || x.ProductDescription.Contains(ProductDescription) ||
                        (x.ProductExpiryDate >= DateAddedFrom && x.ProductExpiryDate <= DateAddedTo) || x.ProductRegNum.Contains(OrderReason) ||
                        x.ProductPartNum.Contains(PartitudeNumber) || x.ProductStorageLocation.Contains(StorageLocation) ||
                        (x.ProductQuantity <= DesiredQuantity || x.ProductQuantity >= DesiredQuantity) || (x.ProductPrice <= PriceOverride || x.ProductPrice >= PriceOverride)).ToList();
                dgvProductOrders.DataSource = products;
                int[] extractedids = new int[products.Count];
                for (int i = 0; i < extractedids.Count(); i++)
                {
                    extractedids[i] = products[i].ID;
                }
                RefreshProductImages(extractedids, true);
            }
            else if (SearchMode == 3)
            {
                RefreshEmployees();
                products = ent.GetProduct(OrderID, ProductName, EmployeeID, ProductDescription, DesiredQuantity, PriceOverride, DateAddedFrom, DateAddedTo, OrderReason,
                    PartitudeNumber, StorageLocation).ToList();
                dgvProductOrders.DataSource = products;
                int[] extractedids = new int[products.Count];
                for (int i = 0; i < extractedids.Count(); i++)
                {
                    extractedids[i] = products[i].ID;
                }
                RefreshProductImages(extractedids, true);
            }
            else
            {
                RefreshProducts();
                RefreshEmployees();
                RefreshClients();
                RefreshProductOrders();
            }
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
            int ProductID = -1;
            Product selectedProduct;
            try
            {
                if (dgvProductOrders.SelectedRows.Count > 0)
                {
                    row = dgvProductOrders.SelectedRows[0];
                    if (row != null && products != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                        if (ProductID > 0)
                        {
                            selectedProduct = products.Where(x => x.ID == ProductID).FirstOrDefault();
                            if (selectedProduct != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateProductByID(selectedProduct.ID, selectedProduct.ProductName, selectedProduct.BrandID,
                                            selectedProduct.ProductDescription, selectedProduct.ProductQuantity, selectedProduct.ProductPrice,
                                            selectedProduct.ProductExpiryDate, selectedProduct.ProductRegNum, selectedProduct.ProductPartNum,
                                            selectedProduct.ProductStorageLocation);
                                        RefreshEmployees();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                            }
                            else
                            {
                                //Create a new one
                                selectedProduct = new Product();
                                DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddProduct(selectedProduct.ProductName, selectedProduct.BrandID, selectedProduct.ProductDescription,
                                            selectedProduct.ProductQuantity, selectedProduct.ProductPrice, selectedProduct.ProductExpiryDate,
                                            selectedProduct.ProductRegNum, selectedProduct.ProductPartNum, selectedProduct.ProductStorageLocation);
                                        RefreshEmployees();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                                //show the editor and after the editor confirms add it
                            }
                        }
                        else
                        {
                            selectedProduct = new Product();
                            DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddProduct(selectedProduct.ProductName, selectedProduct.BrandID, selectedProduct.ProductDescription,
                                        selectedProduct.ProductQuantity, selectedProduct.ProductPrice, selectedProduct.ProductExpiryDate,
                                        selectedProduct.ProductRegNum, selectedProduct.ProductPartNum, selectedProduct.ProductStorageLocation);
                                    RefreshEmployees();
                                    RefreshProducts();
                                    RefreshProductImages();
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedProduct = new Product();
                    DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddProduct(selectedProduct.ProductName, selectedProduct.BrandID, selectedProduct.ProductDescription,
                                selectedProduct.ProductQuantity, selectedProduct.ProductPrice, selectedProduct.ProductExpiryDate,
                                selectedProduct.ProductRegNum, selectedProduct.ProductPartNum, selectedProduct.ProductStorageLocation);
                            RefreshEmployees();
                            RefreshProducts();
                            RefreshProductImages();
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
            int ProductID = -1;
            Product selectedProduct;
            try
            {
                if (dgvProductOrders.SelectedRows.Count > 0)
                {
                    row = dgvProductOrders.SelectedRows[0];
                    if (row != null && products != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                        if (ProductID > 0)
                        {
                            selectedProduct = products.Where(x => x.ID == ProductID).FirstOrDefault();
                            if (selectedProduct != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteProductByID(selectedProduct.ID);
                                        RefreshProducts();
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

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int ProductID = -1;
            Product target_product;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                    if (ProductID >= 0 && products != null)
                    {
                        target_product = products.Where(x => x.ID == ProductID).FirstOrDefault();
                        if (target_product != null)
                        {
                            txtID.Text = target_product.ID.ToString();
                            cbSelectEmployee.SelectedValue = target_product.BrandID;
                            txtProductName.Text = target_product.ProductName.ToString();
                            txtProductDescription.Text = target_product.ProductDescription.ToString();
                            dtDateAddedFrom.Value = target_product.ProductExpiryDate;
                            txtOrderReason.Text = target_product.ProductRegNum.ToString();
                            txtProductPartNum.Text = target_product.ProductPartNum.ToString();
                            txtProductStorageLocation.Text = target_product.ProductStorageLocation.ToString();
                            trbDesiredQuantity.Value = target_product.ProductQuantity;
                            lblShowDesiredQuantity.Text = target_product.ProductQuantity.ToString();
                            trbPriceOverride.Value = Convert.ToInt32(target_product.ProductPrice);
                            lblShowPriceOverride.Text = target_product.ProductPrice.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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
                        statuscell = (DataGridViewComboBoxCell)row.Cells["OrderStatusCell"];
                        statuscolumn = (DataGridViewComboBoxColumn)target_view.Columns["OrderStatusCell"];
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out OrderD);
                        if (products != null && employees != null && clients != null && product_orders != null)
                        {
                            target_product_order = product_orders.Where(x => x.ID == OrderD).FirstOrDefault();
                            if (target_product_order != null)
                            {
                                target_product = products.Where(x => x.ID == target_product_order.ProductID).FirstOrDefault();
                                productcell.Value = target_product.ID;
                                target_employee = employees.Where(x => x.ID == target_product_order.EmployeeID).FirstOrDefault();
                                employeecell.Value = target_employee.ID;
                                target_client = clients.Where(x => x.ID == target_product_order.ClientID).FirstOrDefault();
                                clientcell.Value = target_client.ID;
                                statuscell.Value = statuscolumn.Items[target_product_order.OrderStatus];
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
