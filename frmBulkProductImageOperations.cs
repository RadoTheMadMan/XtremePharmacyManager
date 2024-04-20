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
    public partial class frmBulkProductImageOperations : Form
    {
        static BulkOperationManager<ProductImage> manager;
        BulkOperation<ProductImage> selected_operation;
        ProductImage selected_target;
        static Entities manager_entities;
        public frmBulkProductImageOperations(ref BulkOperationManager<ProductImage> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<ProductImage> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.ProductImages.ToList();
                cbProduct.DataSource = manager_entities.Products.ToList();
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<ProductImage> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.ProductImages.ToList();
                cbProduct.DataSource = manager_entities.Products.ToList();
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void frmBulkProductImageOperations_Load(object sender, EventArgs e)
        {
            Bitmap current_image = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            cbSelectRecord.DataSource = manager_entities.ProductImages.ToList();
            cbProduct.DataSource = manager_entities.Products.ToList();
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    ConvertBinaryToImage(selected_target.ImageData, out current_image);
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtImageName.Text = (!String.IsNullOrEmpty(selected_target.ImageName)) ? selected_target.ImageName.ToString() : string.Empty;
                    this.pbProductImageData.Image = current_image;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbProduct.SelectedValue = selected_target.ProductID;
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
            byte[] current_bytes;
            try
            {
                ConvertImageToBinary((Bitmap)pbProductImageData.Image, out current_bytes);
                if (selected_target != null)
                {
                    selected_target.ImageName = txtImageName.Text;
                    selected_target.ProductID = Int32.Parse(cbProduct.SelectedValue.ToString());
                    selected_target.ImageData = current_bytes;
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
            Bitmap selected_image;
            try
            {
                if (current.SelectedItems.Count > 0 || (current.SelectedIndex >= 0 && current.SelectedIndex < current.Items.Count))
                {
                    selected_operation = current.Items[current.SelectedIndex] as BulkProductImageOperation;
                    selected_target = selected_operation.TargetObject;
                }
                if (selected_operation != null && selected_target != null)
                {
                    ConvertBinaryToImage(selected_target.ImageData, out selected_image);
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtImageName.Text = (!String.IsNullOrEmpty(selected_target.ImageName)) ? selected_target.ImageName.ToString() : string.Empty;
                    this.pbProductImageData.Image = selected_image;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbProduct.SelectedValue = selected_target.ProductID;
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
            byte[] image_bytes;
            try
            {
                ConvertImageToBinary((Bitmap)pbProductImageData.Image, out image_bytes);
                bool IsSilent = checkSilentOperation.Checked;
                BulkOperationType operationType = (BulkOperationType)cbOperationType.SelectedIndex;
                manager.AddOperation(new BulkProductImageOperation(operationType, ref manager_entities, new ProductImage()
                {
                    ID = Int32.Parse(txtID.Text),
                    ProductID = Int32.Parse(cbProduct.SelectedValue.ToString()),
                    ImageName = txtImageName.Text,
                    ImageData = image_bytes
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
            byte[] current_bytes;
            try
            {
                ConvertImageToBinary((Bitmap)pbProductImageData.Image, out current_bytes);
                if (selected_target != null)
                {
                    selected_target.ImageName = txtImageName.Text;
                    selected_target.ProductID = Int32.Parse(cbProduct.SelectedValue.ToString());
                    selected_target.ImageData = current_bytes;
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
            Bitmap selected_image;
            try
            {
                selected_target = manager_entities.ProductImages.Where(x => x.ID == ((ProductImage)cbSelectRecord.SelectedItem).ID).FirstOrDefault();
                if (selected_target != null)
                {
                    ConvertBinaryToImage(selected_target.ImageData, out selected_image);
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtImageName.Text = (!String.IsNullOrEmpty(selected_target.ImageName)) ? selected_target.ImageName.ToString() : string.Empty;
                    this.pbProductImageData.Image = selected_image;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbProduct.SelectedValue = selected_target.ProductID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbProductImageData_Click(object sender, EventArgs e)
        {
            PictureBox current = (PictureBox)sender;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png*;*.bmp*;*.jpg*;*.jpeg*;*.jfif*";
            ofd.Multiselect = false;
            ofd.Title = "Select an image to upload or for bulk operation";
            if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(ofd.FileName))
            {
                Bitmap selectedImage = new Bitmap(ofd.FileName);
                current.Image = new Bitmap(selectedImage);
            }
        }
    }
}
