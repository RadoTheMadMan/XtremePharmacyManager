﻿using System;
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
        static List<ProductImage> entries;
        static List<Product> product_entries;
        static User current_user;
        ProductImage selected_target;
        static Entities manager_entities;
        public frmBulkProductImageOperations(ref BulkOperationManager<ProductImage> operation_manager)
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

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<ProductImage> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.ProductImages.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.ProductImages.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                product_entries = manager_entities.Products.ToList();
                foreach (var entry in product_entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbProduct.DataSource = product_entries;
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.ProductImages.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.ProductImages.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                product_entries = manager_entities.Products.ToList();
                foreach (var entry in product_entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbProduct.DataSource = product_entries;
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<ProductImage> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.ProductImages.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.ProductImages.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                product_entries = manager_entities.Products.ToList();
                foreach (var entry in product_entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbProduct.DataSource = product_entries;
                lblOperationResults.Text = $"{GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT}";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.ProductImages.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.ProductImages.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                product_entries = manager_entities.Products.ToList();
                foreach (var entry in product_entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbProduct.DataSource = product_entries;
            }
        }




        private void frmBulkProductImageOperations_Load(object sender, EventArgs e)
        {
            Bitmap current_image = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            entries = manager_entities.ProductImages.ToList();
            foreach (var entry in entries)
            {
                manager_entities.Entry(manager_entities.ProductImages.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbSelectRecord.DataSource = entries;
            product_entries = manager_entities.Products.ToList();
            foreach (var entry in product_entries)
            {
                manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbProduct.DataSource = product_entries;
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.ProductImages.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.ProductImages.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                product_entries = manager_entities.Products.ToList();
                foreach (var entry in product_entries)
                {
                    manager_entities.Entry(manager_entities.Products.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbProduct.DataSource = product_entries;
            }
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
                {
                    manager.ExecuteOperations();
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            byte[] current_bytes;
            try
            {
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
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
                        selected_operation.UpdateTargetObject(selected_target);
                        selected_operation.OperationType = (BulkOperationType)cbOperationType.SelectedIndex;
                        selected_operation.IsSilent = checkSilentOperation.Checked;
                        selected_operation.UpdateName();
                        manager.UpdateAllOperations(selected_operation);
                    }
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblOperationResults.Text = $"{GLOBAL_RESOURCES.LBL_BULK_OPERATION_RESULTS_TEXT}";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            byte[] image_bytes;
            try
            {
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
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
                    }, IsSilent));
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (current_user.UserRole == 0 || current_user.UserRole == 1)
                    {
                        manager.RemoveOperation(selected_operation);
                    }
                    else
                    {
                        MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            byte[] current_bytes;
            try
            {
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
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
                        selected_operation.UpdateTargetObject(selected_target);
                        selected_operation.OperationType = current_type;
                        selected_operation.IsSilent = IsSilent;
                        selected_operation.UpdateName();
                        manager.UpdateOperation(selected_operation);
                    }
                }
                else
                {
                    MessageBox.Show($"{GLOBAL_RESOURCES.BULK_PRODUCT_IMAGE_OPERATION_NO_PERMISSION_MESSAGE}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Bitmap selected_image;
            ProductImage selected_record = (ProductImage)cbSelectRecord.SelectedItem;
            try
            {
               if(selected_record != null) 
                {
                    ConvertBinaryToImage(selected_record.ImageData, out selected_image);
                    this.txtID.Text = (selected_record.ID >= 0) ? selected_record.ID.ToString() : string.Empty;
                    cbProduct.SelectedValue = selected_record.ProductID;
                    this.txtImageName.Text = (!String.IsNullOrEmpty(selected_record.ImageName)) ? selected_record.ImageName.ToString() : string.Empty;
                    this.pbProductImageData.Image = selected_image;
                    cbSelectRecord.SelectedValue = selected_record.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
