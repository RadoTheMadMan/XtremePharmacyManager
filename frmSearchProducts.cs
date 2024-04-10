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
    public partial class frmSearchProducts : Form
    {
        static Entities ent;
        static List<Product> products;
        static List<ProductBrand> product_brands;
        static List<ProductImage> product_images;
        public frmSearchProducts(Entities entity)
        {
            ent = entity;
            InitializeComponent();
            RefreshProductBrands();
            RefreshProducts();
            RefreshProductImages();
        }

        private void RefreshProducts()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    products = ent.GetProduct(-1,"",-1,"",0,new decimal(),new DateTime(),new DateTime(),"","","").ToList();
                    dgvProducts.DataSource = products;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductBrands()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_brands = ent.GetBrand(-1, "").ToList();
                    cbSelectBrand.DataSource = product_brands;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductImages()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_images = ent.GetProductImage(-1,-1,"").ToList();
                    lstProductImages.Items.Clear();
                    foreach(ProductImage image in product_images)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductImages(int ImageID,int ProductID, string ImageName)
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_images = ent.GetProductImage(ImageID, ProductID, ImageName).ToList();
                    lstProductImages.Items.Clear();
                    imgListProductImages.Images.Clear();
                    for(int i = 0;i < product_images.Count;i++)
                    {
                        Bitmap extracted_image;
                        ConvertBinaryToImage(product_images[i].ImageData, out extracted_image);
                        imgListProductImages.Images.Add(extracted_image);
                        ListViewItem image_item = new ListViewItem();
                        image_item.ImageIndex = i;
                        image_item.StateImageIndex = i;
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ID.ToString()));
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                        lstProductImages.Items.Add(image_item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ProductID = -1;
            int BrandID = -1;
            Int32.TryParse(txtID.Text, out ProductID);
            Int32.TryParse(cbSelectBrand.SelectedValue.ToString(), out BrandID);
            string ProductName = txtProductName.Text;
            string ProductDescription = txtProductDescription.Text;
            DateTime BirthDateFrom = dtExpiryDateFrom.Value;
            DateTime BirthDateTo = dtExpiryDateTo.Value;
            string Phone = txtProductRegNum.Text;
            string Email = txtProductPartNum.Text;
            string Address = txtProductStorageLocation.Text;
            decimal Balance = trbPrice.Value;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                products = ent.Products.Where(
                    x => x.ID == ProductID ^ x.UserName.Contains(ProductName) ^ x.UserPassword.Contains(ProductDescription) ^
                        x.UserDisplayName.Contains(ProductDescription) ^ (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ^
                        x.UserPhone.Contains(Phone) ^ x.UserEmail.Contains(Email) ^ x.UserAddress.Contains(Address) ^ (x.UserBalance <= Balance || x.UserBalance >= Balance) ^
                        x.UserDiagnose.Contains(Diagnose) ^ (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) ^ x.UserRole == Role
                ).ToList(); 
                dgvProducts.DataSource = users;

            }
            else if (SearchMode == 2)
            {
                products = ent.Products.Where(
                    x => x.ID == ProductID || x.UserName.Contains(ProductName) || x.UserPassword.Contains(ProductDescription) ||
                        x.UserDisplayName.Contains(ProductDescription) || (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ||
                        x.UserPhone.Contains(Phone) || x.UserEmail.Contains(Email) || x.UserAddress.Contains(Address) || (x.UserBalance <= Balance || x.UserBalance >= Balance) ||
                        x.UserDiagnose.Contains(Diagnose) || (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) || x.UserRole == Role
                ).ToList();
                dgvProducts.DataSource = users;
            }
            else if (SearchMode == 3)
            {
                products = ent.GetUser(ProductID,ProductName,ProductDescription,ProductDescription,BirthDateFrom,BirthDateTo,Phone,Email,Address,Balance,Diagnose,RegisterDateFrom,RegisterDateTo,Role).ToList();
                dgvProducts.DataSource = users;
            }
            else
            {
                RefreshProducts();
                RefreshProductBrands();
                RefreshProductImages();
            }
        }

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = trbPrice.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int UserID = -1;
            User selectedUser;
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    row = dgvProducts.SelectedRows[0];
                    if (row != null && users != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                        if (UserID > 0)
                        {
                            selectedUser = users.Where(x => x.ID == UserID).FirstOrDefault();
                            if (selectedUser != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateUserByID(selectedUser.ID, selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName,
                                            selectedUser.UserBirthDate, selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic,
                                            selectedUser.UserBalance, selectedUser.UserDiagnose, selectedUser.UserRole);
                                        RefreshProducts();
                                    }
                                }
                            }
                            else
                            {
                                //Create a new user
                                selectedUser = new User();
                                DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                            selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                            selectedUser.UserDiagnose, selectedUser.UserRole);
                                        RefreshProducts();
                                    }
                                }
                                //show the editor and after the editor confirms add it
                            }
                        }
                        else
                        {
                            selectedUser = new User();
                            DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                        selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                        selectedUser.UserDiagnose, selectedUser.UserRole);
                                    RefreshProducts();
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedUser = new User();
                    DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                selectedUser.UserDiagnose, selectedUser.UserRole);
                            RefreshProducts();
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
            int UserID = -1;
            User selectedUser;
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    row = dgvProducts.SelectedRows[0];
                    if (row != null && users != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                        if (UserID > 0)
                        {
                            selectedUser = users.Where(x => x.ID == UserID).FirstOrDefault();
                            if (selectedUser != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteUserByID(selectedUser.ID);
                                        RefreshProducts();
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

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int UserID = -1;
            User target_user;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                    if (UserID >= 0 && users != null)
                    {
                        target_user = users.Where(x => x.ID == UserID).FirstOrDefault();
                        if(target_user != null)
                        {
                            txtID.Text = target_user.ID.ToString();
                            txtProductName.Text = target_user.UserName.ToString();
                            txtPassword.Text = target_user.UserPassword.ToString();
                            txtProductDescription.Text = target_user.UserDisplayName.ToString();
                            dtExpiryDateFrom.Value = target_user.UserBirthDate;
                            txtProductRegNum.Text = target_user.UserPhone.ToString();
                            txtProductPartNum.Text = target_user.UserEmail.ToString();
                            txtProductStorageLocation.Text = target_user.UserAddress.ToString();
                            trbPrice.Value = Convert.ToInt32(target_user.UserBalance);
                            txtDiagnose.Text = target_user.UserDiagnose.ToString();
                            dtRegisterDateFrom.Value = target_user.UserDateOfRegister;
                            cbRole.SelectedIndex = target_user.UserRole;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            DataGridViewComboBoxCell rolecell = (DataGridViewComboBoxCell)row.Cells["RoleColumn"];
            int UserID = -1;
            User target_user;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                    if (UserID >= 0 && users != null)
                    {
                        target_user = users.Where(x => x.ID == UserID).FirstOrDefault();
                        if (target_user != null)
                        {
                            rolecell.Value = target_user.UserRole;
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
