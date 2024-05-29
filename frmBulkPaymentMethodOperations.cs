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
    public partial class frmBulkPaymentMethodOperations : Form
    {
        static BulkOperationManager<PaymentMethod> manager;
        BulkOperation<PaymentMethod> selected_operation;
        static List<PaymentMethod> entries;
        static User current_user;
        PaymentMethod selected_target;
        static Entities manager_entities;
        public frmBulkPaymentMethodOperations(ref BulkOperationManager<PaymentMethod> operation_manager)
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

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<PaymentMethod> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.PaymentMethods.ToList();
                foreach(var entry in entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<PaymentMethod> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
            }
        }




        private void frmBulkPaymentMethodOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            entries = manager_entities.PaymentMethods.ToList();
            foreach (var entry in entries)
            {
                manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbSelectRecord.DataSource = entries;
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtMethodName.Text = (!String.IsNullOrEmpty(selected_target.MethodName)) ? selected_target.MethodName.ToString() : string.Empty;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
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
                    MessageBox.Show("You don't have permissions to use bulk operations for payment methods.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        selected_target.MethodName = txtMethodName.Text;
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
                    MessageBox.Show("You don't have permissions to use bulk operations for payment methods.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    selected_operation = current.Items[current.SelectedIndex] as BulkPaymentMethodOperation;
                    selected_target = selected_operation.TargetObject;
                }
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtMethodName.Text = (!String.IsNullOrEmpty(selected_target.MethodName)) ? selected_target.MethodName.ToString() : string.Empty;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                    cbSelectRecord.SelectedValue = selected_target.ID;
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
                    manager.AddOperation(new BulkPaymentMethodOperation(operationType, ref manager_entities, new PaymentMethod()
                    {
                        ID = Int32.Parse(txtID.Text),
                        MethodName = txtMethodName.Text
                    }, IsSilent));
                }
                else
                {
                    MessageBox.Show("You don't have permissions to use bulk operations for payment methods.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("You don't have permissions to use bulk operations for payment methods.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        selected_target.MethodName = txtMethodName.Text;
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
                    MessageBox.Show("You don't have permissions to use bulk operations for payment methods.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            PaymentMethod selected_record = (PaymentMethod)cbSelectRecord.SelectedItem;
            try
            {
              if(selected_record != null)
                {
                    this.txtID.Text = (selected_record.ID >= 0) ? selected_record.ID.ToString() : string.Empty;
                    this.txtMethodName.Text = (!String.IsNullOrEmpty(selected_record.MethodName)) ? selected_record.MethodName.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_record.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
