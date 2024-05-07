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
    public partial class frmSearchProductBrands : Form
    {
        static Entities ent;
        static Logger logger;
        static List<ProductBrand> product_brands;
        static BulkOperationManager<ProductBrand> manager;
        public frmSearchProductBrands(ref Entities entity, ref Logger extlogger, ref BulkOperationManager<ProductBrand> bulkbrandmanager)
        {
            ent = entity;
            logger = extlogger;
            manager = bulkbrandmanager;
            InitializeComponent();
        }

        private void RefreshProductBrands()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_brands = ent.GetBrand(-1, "").ToList();
                    dgvProductBrands.DataSource = product_brands;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int BrandID = -1;
            Int32.TryParse(txtID.Text, out BrandID);
            string BrandName = txtBrandName.Text;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                product_brands = ent.ProductBrands.Where(
                    x => x.ID == BrandID ^ x.BrandName.Contains(BrandName)).ToList(); 
                dgvProductBrands.DataSource = product_brands;
            }
            else if (SearchMode == 2)
            {
                product_brands = ent.ProductBrands.Where(
                    x => x.ID == BrandID || x.BrandName.Contains(BrandName)).ToList();
                dgvProductBrands.DataSource = product_brands;
            }
            else if (SearchMode == 3)
            {
                product_brands = ent.GetBrand(BrandID,BrandName).ToList();
                dgvProductBrands.DataSource = product_brands;
            }
            else
            {
                RefreshProductBrands();
            }
            logger.RefreshLogs();
        }



        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int BrandID = -1;
            ProductBrand selectedBrand;
            try
            {
                if (dgvProductBrands.SelectedRows.Count > 0)
                {
                    row = dgvProductBrands.SelectedRows[0];
                    if (row != null && product_brands != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out BrandID);
                        if (BrandID > 0)
                        {
                            selectedBrand = product_brands.Where(x => x.ID == BrandID).FirstOrDefault();
                            if (selectedBrand != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditProductBrand(ref selectedBrand).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateBrandByID(selectedBrand.ID,selectedBrand.BrandName);
                                        ent.SaveChanges();
                                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                        ExtendedBrandsView prb_view = ent.ExtendedBrandsViews.Where(x => x.ID ==  selectedBrand.ID).FirstOrDefault();
                                        if(prb_view != null)
                                        {
                                            ent.Entry(prb_view).Reload();
                                        }
                                        RefreshProductBrands();
                                    }
                                    else // or add it as a bulk operation
                                    {
                                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            //on user prompt add a silent operation by default
                                            manager.AddOperation(new BulkProductBrandOperation(BulkOperationType.UPDATE, ref ent, selectedBrand, true));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Create a new brand
                                selectedBrand = new ProductBrand();
                                DialogResult res = new frmEditProductBrand(ref selectedBrand).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddBrand(selectedBrand.BrandName);
                                        ent.SaveChanges();
                                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                        ExtendedBrandsView prb_view = ent.ExtendedBrandsViews.Where(x => x.ID == selectedBrand.ID).FirstOrDefault();
                                        if (prb_view != null)
                                        {
                                            ent.Entry(prb_view).Reload();
                                        }
                                        RefreshProductBrands();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkProductBrandOperation(BulkOperationType.ADD, ref ent, selectedBrand, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            selectedBrand = new ProductBrand();
                            DialogResult res = new frmEditProductBrand(ref selectedBrand).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddBrand(selectedBrand.BrandName);
                                    ent.SaveChanges();
                                    //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                    ExtendedBrandsView prb_view = ent.ExtendedBrandsViews.Where(x => x.ID == selectedBrand.ID).FirstOrDefault();
                                    if (prb_view != null)
                                    {
                                        ent.Entry(prb_view).Reload();
                                    }
                                    RefreshProductBrands();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkProductBrandOperation(BulkOperationType.ADD, ref ent, selectedBrand, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedBrand = new ProductBrand();
                    DialogResult res = new frmEditProductBrand(ref selectedBrand).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddBrand(selectedBrand.BrandName);
                            ent.SaveChanges();
                            //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                            ExtendedBrandsView prb_view = ent.ExtendedBrandsViews.Where(x => x.ID == selectedBrand.ID).FirstOrDefault();
                            if (prb_view != null)
                            {
                                ent.Entry(prb_view).Reload();
                            }
                            RefreshProductBrands();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkProductBrandOperation(BulkOperationType.ADD, ref ent, selectedBrand, true));
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
            int BrandID = -1;
            ProductBrand selectedBrand;
            try
            {
                if (dgvProductBrands.SelectedRows.Count > 0)
                {
                    row = dgvProductBrands.SelectedRows[0];
                    if (row != null && product_brands != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out BrandID);
                        if (BrandID > 0)
                        {
                            selectedBrand = product_brands.Where(x => x.ID == BrandID).FirstOrDefault();
                            if (selectedBrand != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteBrandByID(selectedBrand.ID);
                                        ent.SaveChanges();
                                        //find the entry that corresponds to the entry in the original table and reload it so it is updated in the model
                                        ExtendedBrandsView prb_view = ent.ExtendedBrandsViews.Where(x => x.ID == selectedBrand.ID).FirstOrDefault();
                                        if (prb_view != null)
                                        {
                                            ent.Entry(prb_view).Reload();
                                        }
                                        RefreshProductBrands();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkProductBrandOperation(BulkOperationType.DELETE, ref ent, selectedBrand, true));
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

        private void dgvProductBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int BrandID = -1;
            ProductBrand targetBrand;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out BrandID);
                    if (BrandID >= 0 && product_brands != null)
                    {
                        targetBrand = product_brands.Where(x => x.ID == BrandID).FirstOrDefault();
                        if(targetBrand != null)
                        {
                            txtID.Text = targetBrand.ID.ToString();
                            txtBrandName.Text = targetBrand.BrandName.ToString();;
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
            RefreshProductBrands();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            ProductBrand currentBrand;
            string target_report_file;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (dgvProductBrands.SelectedRows.Count > 0)
                {
                    row = dgvProductBrands.SelectedRows[0];
                    if (row != null && product_brands != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                        //Contrary to the CRUD operations, report generating will be for all records no matter
                        //if they are dummy or not
                        currentBrand = product_brands.Where(x => x.ID == ID).FirstOrDefault();
                        if (currentBrand != null)
                        {
                            target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.PRODUCT_BRAND_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                            ExtendedBrandsView view = ent.ExtendedBrandsViews.Where(x => x.ID == currentBrand.ID).FirstOrDefault();
                            if (view != null)
                            {
                                DataTable dt = new DataTable();
                                dt.Columns.Add(nameof(view.BrandName));
                                dt.Columns.Add(nameof(view.CountProductsFromBrand));
                                dt.Rows.Add(new object[]{ view.BrandName,
                                                          view.CountProductsFromBrand});
                                foreach (ExtendedBrandsView br_view in ent.ExtendedBrandsViews)
                                {
                                    if (br_view != view)
                                    {
                                        dt.Rows.Add(new object[]{
                                                              br_view.BrandName,
                                                              br_view.CountProductsFromBrand});
                                    }
                                }
                                current_source = new ReportDataSource("ProductBrandReportData", dt);
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
