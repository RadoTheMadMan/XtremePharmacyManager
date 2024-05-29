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
    public partial class frmBulkProductOperations : Form
    {
        static BulkOperationManager<Product> manager;
        BulkOperation<Product> selected_operation;
        static List<Product> entries;
        static List<ProductBrand> brand_entries;
        static List<ProductVendor> vendor_entries;
        static User current_user;
        Product selected_target;
        static Entities manager_entities;
        public frmBulkProductOperations(ref BulkOperationManager<Product> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            current_user = manager.CurrentUser;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<Product> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.Products.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                brand_entries = manager_entities.ProductBrands.ToList();
                foreach (var entry in brand_entries)
                {
                    manager_entities.Entry(manager_entities.ProductBrands.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbBrand.DataSource = brand_entries;
                vendor_entries = manager_entities.ProductVendors.ToList();
                foreach (var entry in vendor_entries)
                {
                    manager_entities.Entry(manager_entities.ProductVendors.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbVendor.DataSource = vendor_entries;
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.Products.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                brand_entries = manager_entities.ProductBrands.ToList();
                foreach (var entry in brand_entries)
                {
                    manager_entities.Entry(manager_entities.ProductBrands.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbBrand.DataSource = brand_entries;
                vendor_entries = manager_entities.ProductVendors.ToList();
                foreach (var entry in vendor_entries)
                {
                    manager_entities.Entry(manager_entities.ProductVendors.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbVendor.DataSource = vendor_entries;
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<Product> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.Products.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                brand_entries = manager_entities.ProductBrands.ToList();
                foreach (var entry in brand_entries)
                {
                    manager_entities.Entry(manager_entities.ProductBrands.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbBrand.DataSource = brand_entries;
                vendor_entries = manager_entities.ProductVendors.ToList();
                foreach (var entry in vendor_entries)
                {
                    manager_entities.Entry(manager_entities.ProductVendors.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbVendor.DataSource = vendor_entries;
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.Products.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                brand_entries = manager_entities.ProductBrands.ToList();
                foreach (var entry in brand_entries)
                {
                    manager_entities.Entry(manager_entities.ProductBrands.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbBrand.DataSource = brand_entries;
                vendor_entries = manager_entities.ProductVendors.ToList();
                foreach (var entry in vendor_entries)
                {
                    manager_entities.Entry(manager_entities.ProductVendors.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbVendor.DataSource = vendor_entries;
            }
        }




        private void frmBulkProductOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            entries = manager_entities.Products.ToList();
            foreach (var entry in entries)
            {
                manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbSelectRecord.DataSource = entries;
            brand_entries = manager_entities.ProductBrands.ToList();
            foreach (var entry in brand_entries)
            {
                manager_entities.Entry(manager_entities.ProductBrands.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbBrand.DataSource = brand_entries;
            vendor_entries = manager_entities.ProductVendors.ToList();
            foreach (var entry in vendor_entries)
            {
                manager_entities.Entry(manager_entities.ProductVendors.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbVendor.DataSource = vendor_entries;
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtProductName.Text = (!String.IsNullOrEmpty(selected_target.ProductName)) ? selected_target.ProductName.ToString() : string.Empty;
                    this.txtProductDescription.Text = (!String.IsNullOrEmpty(selected_target.ProductDescription)) ? selected_target.ProductDescription.ToString() : string.Empty;
                    this.txtRegNum.Text = (!String.IsNullOrEmpty(selected_target.ProductRegNum)) ? selected_target.ProductRegNum.ToString() : string.Empty;
                    this.txtPartNum.Text = (!String.IsNullOrEmpty(selected_target.ProductPartNum)) ? selected_target.ProductPartNum.ToString() : string.Empty;
                    this.txtStorageLocation.Text = (!String.IsNullOrEmpty(selected_target.ProductStorageLocation)) ? selected_target.ProductStorageLocation.ToString() : string.Empty;
                    dtExpiryDate.Value = (selected_target.ProductExpiryDate >= DateTime.MinValue && selected_target.ProductExpiryDate <= DateTime.MaxValue) ? selected_target.ProductExpiryDate : DateTime.Now;
                    this.txtPrice.Text = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice) : 0;
                    this.txtQuantity.Text = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity.ToString() : string.Empty;
                    this.trbQuantity.Value = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity : 0;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbBrand.SelectedValue = selected_target.BrandID;
                    cbVendor.SelectedValue = selected_target.VendorID;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.Products.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                brand_entries = manager_entities.ProductBrands.ToList();
                foreach (var entry in brand_entries)
                {
                    manager_entities.Entry(manager_entities.ProductBrands.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbBrand.DataSource = brand_entries;
                vendor_entries = manager_entities.ProductVendors.ToList();
                foreach (var entry in vendor_entries)
                {
                    manager_entities.Entry(manager_entities.ProductVendors.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbVendor.DataSource = vendor_entries;
            }
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0)
                {
                    manager.ExecuteOperations();
                }
                else
                {
                    MessageBox.Show("You don't have permissions to use bulk operations for products.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0)
                {
                    if (selected_target != null)
                    {
                        selected_target.ProductName = txtProductName.Text;
                        selected_target.BrandID = Int32.Parse(cbBrand.SelectedValue.ToString());
                        selected_target.VendorID = Int32.Parse(cbVendor.SelectedValue.ToString());
                        selected_target.ProductDescription = txtProductDescription.Text;
                        selected_target.ProductQuantity = trbQuantity.Value;
                        selected_target.ProductPrice = trbPrice.Value;
                        selected_target.ProductExpiryDate = dtExpiryDate.Value;
                        selected_target.ProductRegNum = txtRegNum.Text;
                        selected_target.ProductPartNum = txtPartNum.Text;
                        selected_target.ProductStorageLocation = txtStorageLocation.Text;
                    }
                    if (selected_operation != null)
                    {
                        selected_operation.UpdateTargetObject(selected_target);
                        selected_operation.OperationType = (BulkOperationType)cbOperationType.SelectedIndex;
                        selected_operation.IsSilent = checkSilentOperation.Checked;
                        selected_operation.UpdateName();
                        manager.UpdateAllOperations(selected_operation);
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permissions to use bulk operations for products.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstBulkOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox current = (ListBox)sender;
            try
            {
                if (current.SelectedItems.Count > 0 || (current.SelectedIndex >= 0 && current.SelectedIndex < current.Items.Count))
                {
                    selected_operation = current.Items[current.SelectedIndex] as BulkProductOperation;
                    selected_target = selected_operation.TargetObject;
                }
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtProductName.Text = (!String.IsNullOrEmpty(selected_target.ProductName)) ? selected_target.ProductName.ToString() : string.Empty;
                    this.txtProductDescription.Text = (!String.IsNullOrEmpty(selected_target.ProductDescription)) ? selected_target.ProductDescription.ToString() : string.Empty;
                    this.txtRegNum.Text = (!String.IsNullOrEmpty(selected_target.ProductRegNum)) ? selected_target.ProductRegNum.ToString() : string.Empty;
                    this.txtPartNum.Text = (!String.IsNullOrEmpty(selected_target.ProductPartNum)) ? selected_target.ProductPartNum.ToString() : string.Empty;
                    this.txtStorageLocation.Text = (!String.IsNullOrEmpty(selected_target.ProductStorageLocation)) ? selected_target.ProductStorageLocation.ToString() : string.Empty;
                    dtExpiryDate.Value = (selected_target.ProductExpiryDate >= DateTime.MinValue && selected_target.ProductExpiryDate <= DateTime.MaxValue) ? selected_target.ProductExpiryDate : DateTime.Now;
                    this.txtPrice.Text = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice) : 0;
                    this.txtQuantity.Text = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity.ToString() : string.Empty;
                    this.trbQuantity.Value = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity : 0;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbBrand.SelectedValue = selected_target.BrandID;
                    cbVendor.SelectedValue = selected_target.VendorID;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                }
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsSilent = checkSilentOperation.Checked;
                BulkOperationType operationType = (BulkOperationType)cbOperationType.SelectedIndex;
                if (current_user.UserRole == 0)
                {
                    manager.AddOperation(new BulkProductOperation(operationType, ref manager_entities, new Product()
                    {
                        ID = Int32.Parse(txtID.Text),
                        ProductName = txtProductName.Text,
                        BrandID = Int32.Parse(cbBrand.SelectedValue.ToString()),
                        VendorID = Int32.Parse(cbVendor.SelectedValue.ToString()),
                        ProductDescription = txtProductDescription.Text,
                        ProductQuantity = trbQuantity.Value,
                        ProductPrice = trbPrice.Value,
                        ProductExpiryDate = dtExpiryDate.Value,
                        ProductRegNum = txtRegNum.Text,
                        ProductPartNum = txtPartNum.Text,
                        ProductStorageLocation = txtStorageLocation.Text,
                    }, IsSilent));
                }
                else
                {
                    MessageBox.Show("You don't have permissions to use bulk operations for products.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            //Remove it from the list of the manager and nullify it here
            try
            {
                if (selected_operation != null)
                {
                    if (current_user.UserRole == 0)
                    {
                        manager.RemoveOperation(selected_operation);
                    }
                    else
                    {
                        MessageBox.Show("You don't have permissions to use bulk operations for products.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    selected_target = null;
                    selected_operation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToCurrentTarget_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0)
                {
                    if (selected_target != null)
                    {
                        selected_target.ProductName = txtProductName.Text;
                        selected_target.BrandID = Int32.Parse(cbBrand.SelectedValue.ToString());
                        selected_target.VendorID = Int32.Parse(cbVendor.SelectedValue.ToString());
                        selected_target.ProductDescription = txtProductDescription.Text;
                        selected_target.ProductQuantity = trbQuantity.Value;
                        selected_target.ProductPrice = trbPrice.Value;
                        selected_target.ProductExpiryDate = dtExpiryDate.Value;
                        selected_target.ProductRegNum = txtRegNum.Text;
                        selected_target.ProductPartNum = txtPartNum.Text;
                        selected_target.ProductStorageLocation = txtStorageLocation.Text;
                    }
                    if (selected_operation != null)
                    {
                        int operation_index = manager.BulkOperations.IndexOf(selected_operation);
                        BulkOperationType current_type = (BulkOperationType)cbOperationType.SelectedIndex;
                        bool IsSilent = checkSilentOperation.Checked;
                        selected_operation.UpdateTargetObject(selected_target);
                        selected_operation.OperationType = current_type;
                        selected_operation.IsSilent = IsSilent;
                        selected_operation.UpdateName();
                        manager.UpdateOperation(selected_operation);
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permissions to use bulk operations for products.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selected_target = null;
                selected_operation = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void cbSelectRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selected_record = (Product)cbSelectRecord.SelectedItem;
            try
            {
                if(selected_record != null) 
                {
                    this.txtID.Text = (selected_record.ID >= 0) ? selected_record.ID.ToString() : string.Empty;
                    cbBrand.SelectedValue = selected_record.BrandID;
                    cbVendor.SelectedValue = selected_record.VendorID;
                    this.txtProductName.Text = (!String.IsNullOrEmpty(selected_record.ProductName)) ? selected_record.ProductName.ToString() : string.Empty;
                    this.txtProductDescription.Text = (!String.IsNullOrEmpty(selected_record.ProductDescription)) ? selected_record.ProductDescription.ToString() : string.Empty;
                    this.txtRegNum.Text = (!String.IsNullOrEmpty(selected_record.ProductRegNum)) ? selected_record.ProductRegNum.ToString() : string.Empty;
                    this.txtPartNum.Text = (!String.IsNullOrEmpty(selected_record.ProductPartNum)) ? selected_record.ProductPartNum.ToString() : string.Empty;
                    this.txtStorageLocation.Text = (!String.IsNullOrEmpty(selected_record.ProductStorageLocation)) ? selected_record.ProductStorageLocation.ToString() : string.Empty;
                    dtExpiryDate.Value = (selected_record.ProductExpiryDate >= DateTime.MinValue && selected_record.ProductExpiryDate <= DateTime.MaxValue) ? selected_record.ProductExpiryDate : DateTime.Now;
                    this.txtPrice.Text = (selected_record.ProductPrice >= 0) ? Convert.ToInt32(selected_record.ProductPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_record.ProductPrice >= 0) ? Convert.ToInt32(selected_record.ProductPrice) : 0;
                    this.txtQuantity.Text = (selected_record.ProductQuantity >= 0) ? selected_record.ProductQuantity.ToString() : string.Empty;
                    this.trbQuantity.Value = (selected_record.ProductQuantity >= 0) ? selected_record.ProductQuantity : 0;
                    cbSelectRecord.SelectedValue = selected_record.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            txtPrice.Text = ((TrackBar)sender).Value.ToString();
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            txtQuantity.Text = ((TrackBar)sender).Value.ToString();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(((TextBox)sender).Text, out value);
            if (value >= trbQuantity.Maximum)
            {
                trbQuantity.Maximum = value;
            }
            trbQuantity.Value = value;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(((TextBox)sender).Text, out value);
            if (value >= trbPrice.Maximum)
            {
                trbPrice.Maximum = value;
            }
            trbPrice.Value = value;
        }
    }
}
