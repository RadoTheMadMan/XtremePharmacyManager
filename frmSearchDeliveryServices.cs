using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;

namespace XtremePharmacyManager
{
    public partial class frmSearchDeliveryServices : Form
    {
        static Entities ent;
        static Logger logger;
        static List<DeliveryService> delivery_services;
        static BulkOperationManager<DeliveryService> manager;
        public frmSearchDeliveryServices(ref Entities entity, ref Logger extlogger, ref BulkOperationManager<DeliveryService> servicemanager)
        {
            ent = entity;
            logger = extlogger;
            manager = servicemanager;
            InitializeComponent();
        }

        private void RefreshDeliveryServices()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    delivery_services = ent.GetDeliveryService(-1, "", Convert.ToDecimal(0)).ToList();
                    dgvDeliveryServices.DataSource = delivery_services;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ServiceID = -1;
            Int32.TryParse(txtID.Text, out ServiceID);
            string ServiceName = txtServiceName.Text;
            decimal ServicePrice = trbPrice.Value;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                delivery_services = ent.DeliveryServices.Where(
                    x => x.ID == ServiceID ^ x.ServiceName.Contains(ServiceName) ^ x.ServicePrice == ServicePrice).ToList(); 
                dgvDeliveryServices.DataSource = delivery_services;
            }
            else if (SearchMode == 2)
            {
                delivery_services = ent.DeliveryServices.Where(
                    x => x.ID == ServiceID || x.ServiceName.Contains(ServiceName) || x.ServicePrice == ServicePrice).ToList();
                dgvDeliveryServices.DataSource = delivery_services;
            }
            else if (SearchMode == 3)
            {
                delivery_services = ent.GetDeliveryService(ServiceID,ServiceName,ServicePrice).ToList();
                dgvDeliveryServices.DataSource = delivery_services;
            }
            else
            {
                RefreshDeliveryServices();
            }
            logger.RefreshLogs();
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = trbPrice.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int ServiceID = -1;
            DeliveryService selectedService;
            try
            {
                if (dgvDeliveryServices.SelectedRows.Count > 0)
                {
                    row = dgvDeliveryServices.SelectedRows[0];
                    if (row != null && delivery_services != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ServiceID);
                        if (ServiceID > 0)
                        {
                            selectedService = delivery_services.Where(x => x.ID == ServiceID).FirstOrDefault();
                            if (selectedService != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditDeliveryService(ref selectedService).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateDeliveryServiceByID(selectedService.ID,selectedService.ServiceName,selectedService.ServicePrice);
                                        ent.SaveChanges();
                                        RefreshDeliveryServices();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkDeliveryServiceOperation(BulkOperationType.UPDATE, ref ent, selectedService, true));
                                    }
                                }
                            }
                            else
                            {
                                //Create a new service
                                selectedService = new DeliveryService();
                                DialogResult res = new frmEditDeliveryService(ref selectedService).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddDeliveryService(selectedService.ServiceName,selectedService.ServicePrice);
                                        ent.SaveChanges();
                                        RefreshDeliveryServices();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkDeliveryServiceOperation(BulkOperationType.ADD, ref ent, selectedService, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            selectedService = new DeliveryService();
                            DialogResult res = new frmEditDeliveryService(ref selectedService).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddDeliveryService(selectedService.ServiceName, selectedService.ServicePrice);
                                    ent.SaveChanges();
                                    RefreshDeliveryServices();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkDeliveryServiceOperation(BulkOperationType.ADD, ref ent, selectedService, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedService = new DeliveryService();
                    DialogResult res = new frmEditDeliveryService(ref selectedService).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddDeliveryService(selectedService.ServiceName, selectedService.ServicePrice);
                            ent.SaveChanges();
                            RefreshDeliveryServices();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkDeliveryServiceOperation(BulkOperationType.ADD, ref ent, selectedService, true));
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int ServiceID = -1;
            DeliveryService selectedService;
            try
            {
                if (dgvDeliveryServices.SelectedRows.Count > 0)
                {
                    row = dgvDeliveryServices.SelectedRows[0];
                    if (row != null && delivery_services != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ServiceID);
                        if (ServiceID > 0)
                        {
                            selectedService = delivery_services.Where(x => x.ID == ServiceID).FirstOrDefault();
                            if (selectedService != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteDeliveryServiceByID(selectedService.ID);
                                        ent.SaveChanges();
                                        RefreshDeliveryServices();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkDeliveryServiceOperation(BulkOperationType.DELETE, ref ent, selectedService, true));
                                    }
                                }
                            }
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDeliveryServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int ServiceID = -1;
            DeliveryService targetService;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ServiceID);
                    if (ServiceID >= 0 && delivery_services != null)
                    {
                        targetService = delivery_services.Where(x => x.ID == ServiceID).FirstOrDefault();
                        if(targetService != null)
                        {
                            txtID.Text = targetService.ID.ToString();
                            txtServiceName.Text = targetService.ServiceName.ToString();;
                            trbPrice.Value = Convert.ToInt32(targetService.ServicePrice);
                            lblPrice.Text = targetService.ServicePrice.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchDeliveryServices_Load(object sender, EventArgs e)
        {
            RefreshDeliveryServices();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            DeliveryService currentService;
            string target_report_file;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (dgvDeliveryServices.SelectedRows.Count > 0)
                {
                    row = dgvDeliveryServices.SelectedRows[0];
                    if (row != null && delivery_services != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                        //Contrary to the CRUD operations, report generating will be for all records no matter
                        //if they are dummy or not
                        currentService = delivery_services.Where(x => x.ID == ID).FirstOrDefault();
                        if (currentService != null)
                        {
                            target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.DELIVERY_SERVICE_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            ExtendedDeliveryServicesView view = ent.ExtendedDeliveryServicesViews.Where(x => x.ID == currentService.ID).FirstOrDefault();
                            if (view != null)
                            {
                                DataTable dt = new DataTable();
                                dt.Columns.Add(nameof(view.ServiceName));
                                dt.Columns.Add(nameof(view.ServicePrice));
                                dt.Columns.Add(nameof(view.TimesThisServiceWasUsed));
                                dt.Rows.Add(new object[]{ view.ServiceName,
                                                          view.ServicePrice,
                                                          view.TimesThisServiceWasUsed});
                                foreach (ExtendedDeliveryServicesView ds_view in ent.ExtendedDeliveryServicesViews)
                                {
                                    if (ds_view != view)
                                    {
                                        dt.Rows.Add(new object[]{
                                                              ds_view.ServiceName,
                                                              ds_view.ServicePrice,
                                                              ds_view.TimesThisServiceWasUsed});
                                    }
                                }
                                current_source = new ReportDataSource("DeliveryServiceReportData", dt);
                                current_params = new ReportParameterCollection();
                                current_params.Add(new ReportParameter("CompanyName", GLOBAL_RESOURCES.COMPANY_NAME));
                                new frmReports(target_report_file, ref current_source, ref current_params).Show();
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
    }
}
