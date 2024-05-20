using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;

namespace XtremePharmacyManager
{
    public partial class frmSearchProductVendors : Form
    {
        static Entities ent;
        static Logger logger;
        static List<ProductVendor> product_vendors;
        static BulkOperationManager<ProductVendor> manager;
        public frmSearchProductVendors(ref Entities entity, ref Logger extlogger, ref BulkOperationManager<ProductVendor> bulkvendormanager)
        {
            ent = entity;
            logger = extlogger;
            manager = bulkvendormanager;
            InitializeComponent();
        }

        private void RefreshProductVendors()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_vendors = ent.GetVendor(-1, "").ToList();
                    dgvProductVendors.DataSource = product_vendors;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int VendorID = -1;
            Int32.TryParse(txtID.Text, out VendorID);
            string VendorName = txtVendorName.Text;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                product_vendors = ent.ProductVendors.Where(
                    x => x.ID == VendorID ^ x.VendorName.Contains(VendorName)).ToList(); 
                dgvProductVendors.DataSource = product_vendors;
            }
            else if (SearchMode == 2)
            {
                product_vendors = ent.ProductVendors.Where(
                    x => x.ID == VendorID || x.VendorName.Contains(VendorName)).ToList();
                dgvProductVendors.DataSource = product_vendors;
            }
            else if (SearchMode == 3)
            {
                product_vendors = ent.GetVendor(VendorID,VendorName).ToList();
                dgvProductVendors.DataSource = product_vendors;
            }
            else
            {
                RefreshProductVendors();
            }
            logger.RefreshLogs();
        }



        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int VendorID = -1;
            ProductVendor selectedVendor;
            try
            {
                if (dgvProductVendors.SelectedRows.Count > 0)
                {
                    row = dgvProductVendors.SelectedRows[0];
                    if (row != null && product_vendors != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out VendorID);
                        if (VendorID > 0)
                        {
                            selectedVendor = product_vendors.Where(x => x.ID == VendorID).FirstOrDefault();
                            if (selectedVendor != null)
                            {
                                //Show the editor window to edit the selected vendor
                                //on dialog result yes update it
                                DialogResult res = new frmEditProductVendor(ref selectedVendor).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateVendorByID(selectedVendor.ID,selectedVendor.VendorName);
                                        ent.SaveChanges();
                                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                        ExtendedVendorsView prv_view = ent.ExtendedVendorsViews.Where(x => x.ID ==  selectedVendor.ID).FirstOrDefault();
                                        if(prv_view != null)
                                        {
                                            ent.Entry(prv_view).Reload();
                                        }
                                        RefreshProductVendors();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkProductVendorOperation(BulkOperationType.UPDATE, ref ent, selectedVendor, true));
                                    }
                                }
                            }
                            else
                            {
                                //Create a new vendor
                                selectedVendor = new ProductVendor();
                                DialogResult res = new frmEditProductVendor(ref selectedVendor).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddVendor(selectedVendor.VendorName);
                                        ent.SaveChanges();
                                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                        ExtendedVendorsView prv_view = ent.ExtendedVendorsViews.Where(x => x.ID == selectedVendor.ID).FirstOrDefault();
                                        if (prv_view != null)
                                        {
                                            ent.Entry(prv_view).Reload();
                                        }
                                        RefreshProductVendors();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkProductVendorOperation(BulkOperationType.ADD, ref ent, selectedVendor, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Create a new vendor
                            selectedVendor = new ProductVendor();
                            DialogResult res = new frmEditProductVendor(ref selectedVendor).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddVendor(selectedVendor.VendorName);
                                    ent.SaveChanges();
                                    //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                    ExtendedVendorsView prv_view = ent.ExtendedVendorsViews.Where(x => x.ID == selectedVendor.ID).FirstOrDefault();
                                    if (prv_view != null)
                                    {
                                        ent.Entry(prv_view).Reload();
                                    }
                                    RefreshProductVendors();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkProductVendorOperation(BulkOperationType.ADD, ref ent, selectedVendor, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Create a new vendor
                    selectedVendor = new ProductVendor();
                    DialogResult res = new frmEditProductVendor(ref selectedVendor).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddVendor(selectedVendor.VendorName);
                            ent.SaveChanges();
                            //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                            ExtendedVendorsView prv_view = ent.ExtendedVendorsViews.Where(x => x.ID == selectedVendor.ID).FirstOrDefault();
                            if (prv_view != null)
                            {
                                ent.Entry(prv_view).Reload();
                            }
                            RefreshProductVendors();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkProductVendorOperation(BulkOperationType.ADD, ref ent, selectedVendor, true));
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
            int VendorID = -1;
            ProductVendor selectedVendor;
            try
            {
                if (dgvProductVendors.SelectedRows.Count > 0)
                {
                    row = dgvProductVendors.SelectedRows[0];
                    if (row != null && product_vendors != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out VendorID);
                        if (VendorID > 0)
                        {
                            selectedVendor = product_vendors.Where(x => x.ID == VendorID).FirstOrDefault();
                            if (selectedVendor != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes delete it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteVendorByID(selectedVendor.ID);
                                        ent.SaveChanges();
                                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                        ExtendedVendorsView prv_view = ent.ExtendedVendorsViews.Where(x => x.ID == selectedVendor.ID).FirstOrDefault();
                                        if (prv_view != null)
                                        {
                                            ent.Entry(prv_view).Reload();
                                        }
                                        RefreshProductVendors();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkProductVendorOperation(BulkOperationType.DELETE, ref ent, selectedVendor, true));
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

        private void dgvProductVendors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int VendorID = -1;
            ProductVendor targetVendor;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out VendorID);
                    if (VendorID >= 0 && product_vendors != null)
                    {
                        targetVendor = product_vendors.Where(x => x.ID == VendorID).FirstOrDefault();
                        if(targetVendor != null)
                        {
                            txtID.Text = targetVendor.ID.ToString();
                            txtVendorName.Text = targetVendor.VendorName.ToString();;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchProductBrands_Load(object sender, EventArgs e)
        {
            RefreshProductVendors();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            ProductVendor currentVendor;
            string target_report_file;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (dgvProductVendors.SelectedRows.Count > 0)
                {
                    row = dgvProductVendors.SelectedRows[0];
                    if (row != null && product_vendors != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                        //Contrary to the CRUD operations, report generating will be for all records no matter
                        //if they are dummy or not
                        currentVendor = product_vendors.Where(x => x.ID == ID).FirstOrDefault();
                        if (currentVendor != null)
                        {
                            target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.PRODUCT_VENDOR_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            ExtendedVendorsView view = ent.ExtendedVendorsViews.Where(x => x.ID == currentVendor.ID).FirstOrDefault();
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
                                current_source = new ReportDataSource("ProductVendorReportData", dt);
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
