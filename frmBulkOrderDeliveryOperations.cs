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
    public partial class frmBulkOrderDeliveryOperations : Form
    {
        static BulkOperationManager<OrderDelivery> manager;
        BulkOperation<OrderDelivery> selected_operation;
        static List<OrderDelivery> entries;
        static List<ProductOrder> order_entries;
        static List<PaymentMethod> method_entries;
        static List<DeliveryService> service_entries;
        OrderDelivery selected_target;
        static Entities manager_entities;
        public frmBulkOrderDeliveryOperations(ref BulkOperationManager<OrderDelivery> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<OrderDelivery> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.OrderDeliveries.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.OrderDeliveries.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                order_entries = manager_entities.ProductOrders.ToList();
                foreach (var entry in order_entries)
                {
                    manager_entities.Entry(manager_entities.ProductOrders.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbOrder.DataSource = order_entries;
                method_entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in method_entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbPaymentMethod.DataSource = method_entries;
                service_entries = manager_entities.DeliveryServices.ToList();
                foreach (var entry in service_entries)
                {
                    manager_entities.Entry(manager_entities.DeliveryServices.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbDeliveryService.DataSource = service_entries;
                lblOperationResults.Text = e.Result;
                txtOperationLogs.Text = e.OperationLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.OrderDeliveries.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.OrderDeliveries.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                order_entries = manager_entities.ProductOrders.ToList();
                foreach (var entry in order_entries)
                {
                    manager_entities.Entry(manager_entities.ProductOrders.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbOrder.DataSource = order_entries;
                method_entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in method_entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbPaymentMethod.DataSource = method_entries;
                service_entries = manager_entities.DeliveryServices.ToList();
                foreach (var entry in service_entries)
                {
                    manager_entities.Entry(manager_entities.DeliveryServices.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbDeliveryService.DataSource = service_entries;
            }
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<OrderDelivery> e)
        {
            try
            {
                lstBulkOperations.DataSource = null;
                lstBulkOperations.DataSource = e.OperationsList;
                entries = manager_entities.OrderDeliveries.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.OrderDeliveries.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                order_entries = manager_entities.ProductOrders.ToList();
                foreach (var entry in order_entries)
                {
                    manager_entities.Entry(manager_entities.ProductOrders.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbOrder.DataSource = order_entries;
                method_entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in method_entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbPaymentMethod.DataSource = method_entries;
                service_entries = manager_entities.DeliveryServices.ToList();
                foreach (var entry in service_entries)
                {
                    manager_entities.Entry(manager_entities.DeliveryServices.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbDeliveryService.DataSource = service_entries;
                lblOperationResults.Text = "Operation Results: ";
                txtOperationLogs.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.OrderDeliveries.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.OrderDeliveries.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                order_entries = manager_entities.ProductOrders.ToList();
                foreach (var entry in order_entries)
                {
                    manager_entities.Entry(manager_entities.ProductOrders.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbOrder.DataSource = order_entries;
                method_entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in method_entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbPaymentMethod.DataSource = method_entries;
                service_entries = manager_entities.DeliveryServices.ToList();
                foreach (var entry in service_entries)
                {
                    manager_entities.Entry(manager_entities.DeliveryServices.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbDeliveryService.DataSource = service_entries;
            }
        }




        private void frmBulkOrderDeliveryOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            entries = manager_entities.OrderDeliveries.ToList();
            foreach (var entry in entries)
            {
                manager_entities.Entry(manager_entities.OrderDeliveries.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbSelectRecord.DataSource = entries;
            order_entries = manager_entities.ProductOrders.ToList();
            foreach (var entry in order_entries)
            {
                manager_entities.Entry(manager_entities.ProductOrders.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbOrder.DataSource = order_entries;
            method_entries = manager_entities.PaymentMethods.ToList();
            foreach (var entry in method_entries)
            {
                manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbPaymentMethod.DataSource = method_entries;
            service_entries = manager_entities.DeliveryServices.ToList();
            foreach (var entry in service_entries)
            {
                manager_entities.Entry(manager_entities.DeliveryServices.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
            }
            cbDeliveryService.DataSource = service_entries;
            try
            {
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_target.DeliveryReason)) ? selected_target.DeliveryReason.ToString() : string.Empty;
                    this.txtCargoID.Text = (!String.IsNullOrEmpty(selected_target.CargoID)) ? selected_target.CargoID.ToString() : string.Empty;
                    this.txtPrice.Text = (selected_target.TotalPrice >= 0) ? Convert.ToInt32(selected_target.TotalPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.TotalPrice >= 0) ? Convert.ToInt32(selected_target.TotalPrice) : 0;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbOrder.SelectedValue = selected_target.OrderID;
                    cbDeliveryService.SelectedValue = selected_target.DeliveryServiceID;
                    cbPaymentMethod.SelectedValue = selected_target.PaymentMethodID;
                    cbStatus.SelectedIndex = selected_target.DeliveryStatus;
                    cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                    checkSilentOperation.Checked = selected_operation.IsSilent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                entries = manager_entities.OrderDeliveries.ToList();
                foreach (var entry in entries)
                {
                    manager_entities.Entry(manager_entities.OrderDeliveries.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbSelectRecord.DataSource = entries;
                order_entries = manager_entities.ProductOrders.ToList();
                foreach (var entry in order_entries)
                {
                    manager_entities.Entry(manager_entities.ProductOrders.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbOrder.DataSource = order_entries;
                method_entries = manager_entities.PaymentMethods.ToList();
                foreach (var entry in method_entries)
                {
                    manager_entities.Entry(manager_entities.PaymentMethods.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbPaymentMethod.DataSource = method_entries;
                service_entries = manager_entities.DeliveryServices.ToList();
                foreach (var entry in service_entries)
                {
                    manager_entities.Entry(manager_entities.DeliveryServices.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                }
                cbDeliveryService.DataSource = service_entries;
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
                    selected_target.OrderID = Int32.Parse(cbOrder.SelectedValue.ToString());
                    selected_target.DeliveryServiceID = Int32.Parse(cbDeliveryService.SelectedValue.ToString());
                    selected_target.PaymentMethodID = Int32.Parse(cbPaymentMethod.SelectedValue.ToString());
                    selected_target.CargoID = txtCargoID.Text;
                    selected_target.DeliveryStatus = cbStatus.SelectedIndex;
                    selected_target.DeliveryReason = txtReason.Text;
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
                    selected_operation = current.Items[current.SelectedIndex] as BulkOrderDeliveryOperation;
                    selected_target = selected_operation.TargetObject;
                }
                if (selected_operation != null && selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_target.DeliveryReason)) ? selected_target.DeliveryReason.ToString() : string.Empty;
                    this.txtCargoID.Text = (!String.IsNullOrEmpty(selected_target.CargoID)) ? selected_target.CargoID.ToString() : string.Empty;
                    this.txtPrice.Text = (selected_target.TotalPrice >= 0) ? Convert.ToInt32(selected_target.TotalPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.TotalPrice >= 0) ? Convert.ToInt32(selected_target.TotalPrice) : 0;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbOrder.SelectedValue = selected_target.OrderID;
                    cbDeliveryService.SelectedValue = selected_target.DeliveryServiceID;
                    cbPaymentMethod.SelectedValue = selected_target.PaymentMethodID;
                    cbStatus.SelectedIndex = selected_target.DeliveryStatus;
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
                manager.AddOperation(new BulkOrderDeliveryOperation(operationType, ref manager_entities, new OrderDelivery()
                {
                    ID = Int32.Parse(txtID.Text),
                    OrderID = Int32.Parse(cbOrder.SelectedValue.ToString()),
                    DeliveryServiceID = Int32.Parse(cbDeliveryService.SelectedValue.ToString()),
                    PaymentMethodID = Int32.Parse(cbPaymentMethod.SelectedValue.ToString()),
                    CargoID = txtCargoID.Text,
                    DeliveryStatus = cbStatus.SelectedIndex,
                    DeliveryReason = txtReason.Text
            }, IsSilent));
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
                    selected_target.OrderID = Int32.Parse(cbOrder.SelectedValue.ToString());
                    selected_target.DeliveryServiceID = Int32.Parse(cbDeliveryService.SelectedValue.ToString());
                    selected_target.PaymentMethodID = Int32.Parse(cbPaymentMethod.SelectedValue.ToString());
                    selected_target.CargoID = txtCargoID.Text;
                    selected_target.DeliveryStatus = cbStatus.SelectedIndex;
                    selected_target.DeliveryReason = txtReason.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void cbSelectRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (selected_operation != null && selected_operation.TargetObject != null && cbSelectRecord.Items.Contains(selected_operation.TargetObject) && ((OrderDelivery)cbSelectRecord.SelectedItem) == selected_operation.TargetObject)
                {
                    selected_target = selected_operation.TargetObject;
                }
                else
                {
                    OrderDelivery selected_record = (OrderDelivery)cbSelectRecord.SelectedItem;
                    if (selected_record != null && manager_entities.OrderDeliveries.Where(x => x.ID == selected_record.ID).Any())
                    {
                        selected_target = manager_entities.OrderDeliveries.Where(x => x.ID == selected_record.ID).FirstOrDefault();
                    }
                }
                if (cbSelectRecord.SelectedItem != null && selected_target == null)
                {
                    OrderDelivery selected_record = (OrderDelivery)cbSelectRecord.SelectedItem;
                    this.txtID.Text = (selected_record.ID >= 0) ? selected_record.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_record.DeliveryReason)) ? selected_record.DeliveryReason.ToString() : string.Empty;
                    this.txtCargoID.Text = (!String.IsNullOrEmpty(selected_record.CargoID)) ? selected_record.CargoID.ToString() : string.Empty;
                    this.txtPrice.Text = (selected_record.TotalPrice >= 0) ? Convert.ToInt32(selected_record.TotalPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_record.TotalPrice >= 0) ? Convert.ToInt32(selected_record.TotalPrice) : 0;
                    cbSelectRecord.SelectedValue = selected_record.ID;
                    cbOrder.SelectedValue = selected_record.OrderID;
                    cbDeliveryService.SelectedValue = selected_record.DeliveryServiceID;
                    cbPaymentMethod.SelectedValue = selected_record.PaymentMethodID;
                    cbStatus.SelectedIndex = selected_record.DeliveryStatus;
                    cbSelectRecord.SelectedValue = selected_record.ID;
                }
                else if (selected_target != null)
                {
                    this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_target.DeliveryReason)) ? selected_target.DeliveryReason.ToString() : string.Empty;
                    this.txtCargoID.Text = (!String.IsNullOrEmpty(selected_target.CargoID)) ? selected_target.CargoID.ToString() : string.Empty;
                    this.txtPrice.Text = (selected_target.TotalPrice >= 0) ? Convert.ToInt32(selected_target.TotalPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_target.TotalPrice >= 0) ? Convert.ToInt32(selected_target.TotalPrice) : 0;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                    cbOrder.SelectedValue = selected_target.OrderID;
                    cbDeliveryService.SelectedValue = selected_target.DeliveryServiceID;
                    cbPaymentMethod.SelectedValue = selected_target.PaymentMethodID;
                    cbStatus.SelectedIndex = selected_target.DeliveryStatus;
                    cbSelectRecord.SelectedValue = selected_target.ID;
                }
                else
                {
                    OrderDelivery selected_record = (OrderDelivery)cbSelectRecord.SelectedItem;
                    this.txtID.Text = (selected_record.ID >= 0) ? selected_record.ID.ToString() : string.Empty;
                    this.txtReason.Text = (!String.IsNullOrEmpty(selected_record.DeliveryReason)) ? selected_record.DeliveryReason.ToString() : string.Empty;
                    this.txtCargoID.Text = (!String.IsNullOrEmpty(selected_record.CargoID)) ? selected_record.CargoID.ToString() : string.Empty;
                    this.txtPrice.Text = (selected_record.TotalPrice >= 0) ? Convert.ToInt32(selected_record.TotalPrice).ToString() : string.Empty;
                    this.trbPrice.Value = (selected_record.TotalPrice >= 0) ? Convert.ToInt32(selected_record.TotalPrice) : 0;
                    cbSelectRecord.SelectedValue = selected_record.ID;
                    cbOrder.SelectedValue = selected_record.OrderID;
                    cbDeliveryService.SelectedValue = selected_record.DeliveryServiceID;
                    cbPaymentMethod.SelectedValue = selected_record.PaymentMethodID;
                    cbStatus.SelectedIndex = selected_record.DeliveryStatus;
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
