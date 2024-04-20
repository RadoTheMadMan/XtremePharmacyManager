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
        Product selected_target;
        static Entities manager_entities;
        public frmBulkProductOperations(ref BulkOperationManager<Product> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
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
                cbSelectRecord.DataSource = manager_entities.Products.ToList();
                cbBrand.DataSource = manager_entities.ProductBrands.ToList();
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<Product> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.Products.ToList();
                cbBrand.DataSource = manager_entities.ProductBrands.ToList();
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void frmBulkProductOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            cbSelectRecord.DataSource = manager_entities.Products.ToList();
            cbBrand.DataSource = manager_entities.ProductBrands.ToList();
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
                    this.trbPrice.Value = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice) : 0;
                    this.trbQuantity.Value = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity : 0;
                    this.lblShowPrice.Text = (selected_target.ProductPrice >= 0) ? selected_target.ProductPrice.ToString() : string.Empty;
                    this.lblShowQuantity.Text = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbBrand.SelectedValue = selected_target.BrandID;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            try
            {
                manager.ExecuteOperations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected_target != null)
                {
                    selected_target.ProductName = txtProductName.Text;
                    selected_target.BrandID = Int32.Parse(cbBrand.SelectedValue.ToString());
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
                    selected_operation.TargetObject = selected_target;
                    selected_operation.OperationType = (BulkOperationType)cbOperationType.SelectedIndex;
                    selected_operation.IsSilent = checkSilentOperation.Checked;
                    selected_operation.UpdateName();
                    manager.UpdateAllOperations(selected_operation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.trbPrice.Value = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice) : 0;
                    this.trbQuantity.Value = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity : 0;
                    this.lblShowPrice.Text = (selected_target.ProductPrice >= 0) ? selected_target.ProductPrice.ToString() : string.Empty;
                    this.lblShowQuantity.Text = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbBrand.SelectedValue = selected_target.BrandID;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                }
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsSilent = checkSilentOperation.Checked;
                BulkOperationType operationType = (BulkOperationType)cbOperationType.SelectedIndex;
                manager.AddOperation(new BulkProductOperation(operationType, ref manager_entities, new Product()
                {
                    ID = Int32.Parse(txtID.Text),
                    ProductName = txtProductName.Text,
                    BrandID = Int32.Parse(cbBrand.SelectedValue.ToString()),
                    ProductDescription = txtProductDescription.Text,
                    ProductQuantity = trbQuantity.Value,
                    ProductPrice = trbPrice.Value,
                    ProductExpiryDate = dtExpiryDate.Value,
                    ProductRegNum = txtRegNum.Text,
                    ProductPartNum = txtPartNum.Text,
                    ProductStorageLocation = txtStorageLocation.Text,
                }, IsSilent)) ;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            //Remove it from the list of the manager and nullify it here
            try
            {
                if (selected_operation != null)
                {
                    manager.RemoveOperation(selected_operation);
                    selected_target = null;
                    selected_operation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToCurrentTarget_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected_target != null)
                {
                    selected_target.ProductName = txtProductName.Text;
                    selected_target.BrandID = Int32.Parse(cbBrand.SelectedValue.ToString());
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
                    selected_operation.TargetObject = selected_target;
                    selected_operation.OperationType = current_type;
                    selected_operation.IsSilent = IsSilent;
                    selected_operation.UpdateName();
                    manager.UpdateOperation(selected_operation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void cbSelectRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selected_target = manager_entities.Products.Where(x => x.ID == ((Product)cbSelectRecord.SelectedItem).ID).FirstOrDefault();
                if (selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtProductName.Text = (!String.IsNullOrEmpty(selected_target.ProductName)) ? selected_target.ProductName.ToString() : string.Empty;
                    this.txtProductDescription.Text = (!String.IsNullOrEmpty(selected_target.ProductDescription)) ? selected_target.ProductDescription.ToString() : string.Empty;
                    this.txtRegNum.Text = (!String.IsNullOrEmpty(selected_target.ProductRegNum)) ? selected_target.ProductRegNum.ToString() : string.Empty;
                    this.txtPartNum.Text = (!String.IsNullOrEmpty(selected_target.ProductPartNum)) ? selected_target.ProductPartNum.ToString() : string.Empty;
                    this.txtStorageLocation.Text = (!String.IsNullOrEmpty(selected_target.ProductStorageLocation)) ? selected_target.ProductStorageLocation.ToString() : string.Empty;
                    dtExpiryDate.Value = (selected_target.ProductExpiryDate >= DateTime.MinValue && selected_target.ProductExpiryDate <= DateTime.MaxValue) ? selected_target.ProductExpiryDate : DateTime.Now;
                    this.trbPrice.Value = (selected_target.ProductPrice >= 0) ? Convert.ToInt32(selected_target.ProductPrice) : 0;
                    this.trbQuantity.Value = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity : 0;
                    this.lblShowPrice.Text = (selected_target.ProductPrice >= 0) ? selected_target.ProductPrice.ToString() : string.Empty;
                    this.lblShowQuantity.Text = (selected_target.ProductQuantity >= 0) ? selected_target.ProductQuantity.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbBrand.SelectedValue = selected_target.BrandID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = ((TrackBar)sender).Value.ToString();
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            lblShowQuantity.Text = ((TrackBar)sender).Value.ToString();
        }
    }
}
