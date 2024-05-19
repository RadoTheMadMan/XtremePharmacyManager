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
    public partial class frmBulkDeliveryServiceOperations : Form
    {
        static BulkOperationManager<DeliveryService> manager;
        BulkOperation<DeliveryService> selected_operation;
        DeliveryService selected_target;
        static Entities manager_entities;
        public frmBulkDeliveryServiceOperations(ref BulkOperationManager<DeliveryService> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<DeliveryService> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.DeliveryServices.ToList();
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<DeliveryService> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                cbSelectRecord.DataSource = manager_entities.DeliveryServices.ToList();
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void frmBulkDeliveryServiceOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            cbSelectRecord.DataSource = manager_entities.DeliveryServices.ToList();
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtServiceName.Text = (!String.IsNullOrEmpty(selected_target.ServiceName)) ? selected_target.ServiceName.ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.ServicePrice >= 0) ? Convert.ToInt32(selected_target.ServicePrice) : 0;
                    this.lblShowPrice.Text = (selected_target.ServicePrice >= 0) ? selected_target.ServicePrice.ToString() : string.Empty;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected_target != null)
                {
                    selected_target.ServiceName = txtServiceName.Text;
                    selected_target.ServicePrice = trbPrice.Value;
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
                    selected_operation = current.Items[current.SelectedIndex] as BulkDeliveryServiceOperation;
                    selected_target = selected_operation.TargetObject;
                }
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtServiceName.Text = (!String.IsNullOrEmpty(selected_target.ServiceName)) ? selected_target.ServiceName.ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.ServicePrice >= 0) ? Convert.ToInt32(selected_target.ServicePrice) : 0;
                    this.lblShowPrice.Text = (selected_target.ServicePrice >= 0) ? selected_target.ServicePrice.ToString() : string.Empty;
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
                manager.AddOperation(new BulkDeliveryServiceOperation(operationType, ref manager_entities, new DeliveryService()
                {
                    ID = Int32.Parse(txtID.Text),
                    ServiceName = txtServiceName.Text,
                    ServicePrice = trbPrice.Value
            }, IsSilent)) ;
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
                    manager.RemoveOperation(selected_operation);
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
                if (selected_target != null)
                {
                    selected_target.ServiceName = txtServiceName.Text;
                    selected_target.ServicePrice = trbPrice.Value;
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void cbSelectRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (selected_operation != null && selected_operation.TargetObject != null && cbSelectRecord.Items.Contains(selected_operation.TargetObject))
                {
                    selected_target = selected_operation.TargetObject;
                }
                else
                {
                    DeliveryService selected_record = (DeliveryService)cbSelectRecord.SelectedItem;
                    selected_target = manager_entities.DeliveryServices.Where(x => x.ID == selected_record.ID).FirstOrDefault();
                }
                if (selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtServiceName.Text = (!String.IsNullOrEmpty(selected_target.ServiceName)) ? selected_target.ServiceName.ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.ServicePrice >= 0) ? Convert.ToInt32(selected_target.ServicePrice) : 0;
                    this.lblShowPrice.Text = (selected_target.ServicePrice >= 0) ? selected_target.ServicePrice.ToString() : string.Empty;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = ((TrackBar)sender).Value.ToString();
        }
    }
}
