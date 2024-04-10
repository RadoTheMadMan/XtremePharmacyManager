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

namespace XtremePharmacyManager
{
    public partial class frmSearchProductBrands : Form
    {
        static Entities ent;
        static List<ProductBrand> product_brands;
        public frmSearchProductBrands(Entities entity)
        {
            ent = entity;
            InitializeComponent();
            RefreshProductBrands();
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
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        RefreshProductBrands();
                                    }
                                }
                            }
                            else
                            {
                                //Create a new user
                                selectedBrand = new ProductBrand();
                                DialogResult res = new frmEditProductBrand(ref selectedBrand).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddBrand(selectedBrand.BrandName);
                                        RefreshProductBrands();
                                    }
                                }
                                //show the editor and after the editor confirms add it
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
                                    RefreshProductBrands();
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
                            RefreshProductBrands();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        RefreshProductBrands();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
