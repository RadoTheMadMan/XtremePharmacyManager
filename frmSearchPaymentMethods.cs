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
    public partial class frmSearchPaymentMethods : Form
    {
        static Entities ent;
        static Logger logger;
        static List<PaymentMethod> payment_methods;
        static BulkOperationManager<PaymentMethod> manager;
        public frmSearchPaymentMethods(ref Entities entity, ref Logger extlogger, ref BulkOperationManager<PaymentMethod> methodmanager)
        {
            ent = entity;
            logger = extlogger;
            manager = methodmanager;
            InitializeComponent();
        }

        private void RefreshPaymentMethods()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    payment_methods = ent.GetPaymentMethod(-1, "").ToList();
                    dgvPaymentMethods.DataSource = payment_methods;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int MethodID = -1;
            Int32.TryParse(txtID.Text, out MethodID);
            string MethodName = txtMethodName.Text;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                payment_methods = ent.PaymentMethods.Where(
                    x => x.ID == MethodID ^ x.MethodName.Contains(MethodName)).ToList(); 
                dgvPaymentMethods.DataSource = payment_methods;
            }
            else if (SearchMode == 2)
            {
                payment_methods = ent.PaymentMethods.Where(
                    x => x.ID == MethodID || x.MethodName.Contains(MethodName)).ToList();
                dgvPaymentMethods.DataSource = payment_methods;
            }
            else if (SearchMode == 3)
            {
                payment_methods = ent.GetPaymentMethod(MethodID,MethodName).ToList();
                dgvPaymentMethods.DataSource = payment_methods;
            }
            else
            {
                RefreshPaymentMethods();
            }
            logger.RefreshLogs();
        }



        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int MethodID = -1;
            PaymentMethod selectedMethod;
            try
            {
                if (dgvPaymentMethods.SelectedRows.Count > 0)
                {
                    row = dgvPaymentMethods.SelectedRows[0];
                    if (row != null && payment_methods != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out MethodID);
                        if (MethodID > 0)
                        {
                            selectedMethod = payment_methods.Where(x => x.ID == MethodID).FirstOrDefault();
                            if (selectedMethod != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditPaymentMethod(ref selectedMethod).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdatePaymentMethodByID(selectedMethod.ID,selectedMethod.MethodName);
                                        ent.SaveChanges();
                                        //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                                        ExtendedPaymentMethodsView pm_view = ent.ExtendedPaymentMethodsViews.Where(x => x.ID == selectedMethod.ID).FirstOrDefault();
                                        if(pm_view != null)
                                        {
                                            ent.Entry(pm_view).Reload();
                                        }
                                        RefreshPaymentMethods();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkPaymentMethodOperation(BulkOperationType.UPDATE, ref ent, selectedMethod, true));
                                    }
                                }
                            }
                            else
                            {
                                //Create a new method
                                selectedMethod = new PaymentMethod();
                                DialogResult res = new frmEditPaymentMethod(ref selectedMethod).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddPaymentMethod(selectedMethod.MethodName);
                                        ent.SaveChanges();
                                        //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                                        ExtendedPaymentMethodsView pm_view = ent.ExtendedPaymentMethodsViews.Where(x => x.ID == selectedMethod.ID).FirstOrDefault();
                                        if (pm_view != null)
                                        {
                                            ent.Entry(pm_view).Reload();
                                        }
                                        RefreshPaymentMethods();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkPaymentMethodOperation(BulkOperationType.ADD, ref ent, selectedMethod, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            selectedMethod = new PaymentMethod();
                            DialogResult res = new frmEditPaymentMethod(ref selectedMethod).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddPaymentMethod(selectedMethod.MethodName);
                                    ent.SaveChanges();
                                    //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                                    ExtendedPaymentMethodsView pm_view = ent.ExtendedPaymentMethodsViews.Where(x => x.ID == selectedMethod.ID).FirstOrDefault();
                                    if (pm_view != null)
                                    {
                                        ent.Entry(pm_view).Reload();
                                    }
                                    RefreshPaymentMethods();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkPaymentMethodOperation(BulkOperationType.ADD, ref ent, selectedMethod, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedMethod = new PaymentMethod();
                    DialogResult res = new frmEditPaymentMethod(ref selectedMethod).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddPaymentMethod(selectedMethod.MethodName);
                            ent.SaveChanges();
                            //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                            ExtendedPaymentMethodsView pm_view = ent.ExtendedPaymentMethodsViews.Where(x => x.ID == selectedMethod.ID).FirstOrDefault();
                            if (pm_view != null)
                            {
                                ent.Entry(pm_view).Reload();
                            }
                            RefreshPaymentMethods();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkPaymentMethodOperation(BulkOperationType.ADD, ref ent, selectedMethod, true));
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
            int MethodID = -1;
            PaymentMethod selectedMethod;
            try
            {
                if (dgvPaymentMethods.SelectedRows.Count > 0)
                {
                    row = dgvPaymentMethods.SelectedRows[0];
                    if (row != null && payment_methods != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out MethodID);
                        if (MethodID > 0)
                        {
                            selectedMethod = payment_methods.Where(x => x.ID == MethodID).FirstOrDefault();
                            if (selectedMethod != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeletePaymentMethodByID(selectedMethod.ID);
                                        ent.SaveChanges();
                                        //if you find a data from the table entry the operation was performed on in the views reload the view in the model
                                        ExtendedPaymentMethodsView pm_view = ent.ExtendedPaymentMethodsViews.Where(x => x.ID == selectedMethod.ID).FirstOrDefault();
                                        if (pm_view != null)
                                        {
                                            ent.Entry(pm_view).Reload();
                                        }
                                        RefreshPaymentMethods();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkPaymentMethodOperation(BulkOperationType.DELETE, ref ent, selectedMethod, true));
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

        private void dgvPaymentMethods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int MethodID = -1;
            PaymentMethod targetMethod;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out MethodID);
                    if (MethodID >= 0 && payment_methods != null)
                    {
                        targetMethod = payment_methods.Where(x => x.ID == MethodID).FirstOrDefault();
                        if(targetMethod != null)
                        {
                            txtID.Text = targetMethod.ID.ToString();
                            txtMethodName.Text = targetMethod.MethodName.ToString();;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchPaymentMethods_Load(object sender, EventArgs e)
        {
            RefreshPaymentMethods();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            PaymentMethod currentMethod;
            string target_report_file;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (dgvPaymentMethods.SelectedRows.Count > 0)
                {
                    row = dgvPaymentMethods.SelectedRows[0];
                    if (row != null && payment_methods != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                        //Contrary to the CRUD operations, report generating will be for all records no matter
                        //if they are dummy or not
                        currentMethod = payment_methods.Where(x => x.ID == ID).FirstOrDefault();
                        if (currentMethod != null)
                        {
                            target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.PAYMENT_METHOD_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            ExtendedPaymentMethodsView view = ent.ExtendedPaymentMethodsViews.Where(x => x.ID == currentMethod.ID).FirstOrDefault();
                            if (view != null)
                            {
                                Type view_type = view.GetType();
                                DataTable dt = new DataTable();
                                Object[] values = new Object[view_type.GetProperties().Length];
                                int propindex = 0; //track the property index
                                //this is experimental and I am trying it because I added copious amounts of stats to the views but hadn't
                                //imported them yet
                                foreach (var prop in view_type.GetProperties())
                                {
                                    dt.Columns.Add(prop.Name);
                                    values[propindex] = prop.GetValue(view, null);
                                    propindex++; //indrease the property index after adding the property name
                                    //in for and foreach loops everything starts from 0 as always
                                }
                                propindex = 0; //reset the index
                                dt.Rows.Add(values); //add the values
                                //then clear the values to ensure memory is not wasted
                                Array.Clear(values, 0, values.Length);
                                current_source = new ReportDataSource("PaymentMethodReportData", dt);
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
