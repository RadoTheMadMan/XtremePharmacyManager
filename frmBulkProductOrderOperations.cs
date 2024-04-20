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
    public partial class frmBulkProductOrderOperations : Form
    {
        static BulkOperationManager<ProductOrder> manager;
        BulkOperation<ProductOrder> selected_operation;
        ProductOrder selected_target;
        static Entities manager_entities;
        public frmBulkProductOrderOperations(ref BulkOperationManager<ProductOrder> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<ProductOrder> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.ProductOrders.ToList();
                cbProduct.DataSource = manager_entities.Products.ToList();
                cbEmployee.DataSource = manager_entities.Users.Where(x=>x.UserRole == 0 || x.UserRole == 1).ToList();
                cbClient.DataSource = manager_entities.Users.Where(x=>x.UserRole == 2).ToList();
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<ProductOrder> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.ProductOrders.ToList();
                cbProduct.DataSource = manager_entities.Products.ToList();
                cbEmployee.DataSource = manager_entities.Users.Where(x => x.UserRole == 0 || x.UserRole == 1).ToList();
                cbClient.DataSource = manager_entities.Users.Where(x => x.UserRole == 2).ToList();
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void frmBulkProductOrderOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            cbSelectRecord.DataSource = manager_entities.ProductOrders.ToList();
            cbProduct.DataSource = manager_entities.Products.ToList();
            cbEmployee.DataSource = manager_entities.Users.Where(x => x.UserRole == 0 || x.UserRole == 1).ToList();
            cbClient.DataSource = manager_entities.Users.Where(x => x.UserRole == 2).ToList();
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_target.OrderReason)) ? selected_target.OrderReason.ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.OrderPrice >= 0) ? Convert.ToInt32(selected_target.OrderPrice) : 0;
                    this.trbQuantity.Value = (selected_target.DesiredQuantity >= 0) ? selected_target.DesiredQuantity : 0;
                    this.lblShowPrice.Text = (selected_target.OrderPrice >= 0) ? selected_target.OrderPrice.ToString() : string.Empty;
                    this.lblShowQuantity.Text = (selected_target.DesiredQuantity >= 0) ? selected_target.DesiredQuantity.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbProduct.SelectedValue = selected_target.ProductID;
                    cbClient.SelectedValue = selected_target.ClientID;
                    cbEmployee.SelectedValue = selected_target.EmployeeID;
                    cbStatus.SelectedIndex = selected_target.OrderStatus;
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
                    selected_target.ProductID = Int32.Parse(cbProduct.SelectedValue.ToString());
                    selected_target.ClientID = Int32.Parse(cbClient.SelectedValue.ToString());
                    selected_target.EmployeeID = Int32.Parse(cbEmployee.SelectedValue.ToString());
                    selected_target.DesiredQuantity = trbQuantity.Value;
                    selected_target.OrderPrice = trbPrice.Value;
                    selected_target.OrderStatus = cbStatus.SelectedIndex;
                    selected_target.OrderReason = txtReason.Text;
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
                    selected_operation = current.Items[current.SelectedIndex] as BulkProductOrderOperation;
                    selected_target = selected_operation.TargetObject;
                }
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_target.OrderReason)) ? selected_target.OrderReason.ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.OrderPrice >= 0) ? Convert.ToInt32(selected_target.OrderPrice) : 0;
                    this.trbQuantity.Value = (selected_target.DesiredQuantity >= 0) ? selected_target.DesiredQuantity : 0;
                    this.lblShowPrice.Text = (selected_target.OrderPrice >= 0) ? selected_target.OrderPrice.ToString() : string.Empty;
                    this.lblShowQuantity.Text = (selected_target.DesiredQuantity >= 0) ? selected_target.DesiredQuantity.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbProduct.SelectedValue = selected_target.ProductID;
                    cbClient.SelectedValue = selected_target.ClientID;
                    cbEmployee.SelectedValue = selected_target.EmployeeID;
                    cbStatus.SelectedIndex = selected_target.OrderStatus;
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
                    BrandID = Int32.Parse(cbProduct.SelectedValue.ToString()),
                    ProductDescription = txtProductDescription.Text,
                    ProductQuantity = trbQuantity.Value,
                    ProductPrice = trbPrice.Value,
                    ProductExpiryDate = dtExpiryDate.Value,
                    ProductRegNum = txtReason.Text,
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
                    selected_target.BrandID = Int32.Parse(cbProduct.SelectedValue.ToString());
                    selected_target.ProductDescription = txtProductDescription.Text;
                    selected_target.ProductQuantity = trbQuantity.Value;
                    selected_target.OrderPrice = trbPrice.Value;
                    selected_target.ProductExpiryDate = dtExpiryDate.Value;
                    selected_target.ProductRegNum = txtReason.Text;
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
                selected_target = manager_entities.ProductOrders.Where(x => x.ID == ((ProductOrder)cbSelectRecord.SelectedItem).ID).FirstOrDefault();
                if (selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_target.OrderReason)) ? selected_target.OrderReason.ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.OrderPrice >= 0) ? Convert.ToInt32(selected_target.OrderPrice) : 0;
                    this.trbQuantity.Value = (selected_target.DesiredQuantity >= 0) ? selected_target.DesiredQuantity : 0;
                    this.lblShowPrice.Text = (selected_target.OrderPrice >= 0) ? selected_target.OrderPrice.ToString() : string.Empty;
                    this.lblShowQuantity.Text = (selected_target.DesiredQuantity >= 0) ? selected_target.DesiredQuantity.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbProduct.SelectedValue = selected_target.ProductID;
                    cbClient.SelectedValue = selected_target.ClientID;
                    cbEmployee.SelectedValue = selected_target.EmployeeID;
                    cbStatus.SelectedIndex = selected_target.OrderStatus;
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
