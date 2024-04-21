﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static System.Net.Mime.MediaTypeNames;
using static XtremePharmacyManager.ImageBinConverter;

namespace XtremePharmacyManager
{
    public partial class frmSearchProducts : Form
    {
        static Entities ent;
        static Logger logger;
        static BulkOperationManager<Product> product_manager;
        static BulkOperationManager<ProductImage> image_manager;
        static List<Product> products;
        static List<ProductBrand> product_brands;
        static List<ProductImage> product_images;
        public frmSearchProducts(ref Entities entity,ref Logger extlogger, ref BulkOperationManager<Product> productmanager, ref BulkOperationManager<ProductImage> imagemanager)
        {
            ent = entity;
            logger = extlogger;
            product_manager = productmanager;
            image_manager = imagemanager;
            InitializeComponent();
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    BrandIDColumn.DataSource = product_brands;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    lstProductImages.Items.Clear();
                    imgListProductImages.Images.Clear();
                    for (int i = 0; i < product_images.Count; i++)
                    {
                        Bitmap extracted_image;
                        ConvertBinaryToImage(product_images[i].ImageData, out extracted_image);
                        imgListProductImages.Images.Add(extracted_image);
                        ListViewItem image_item = new ListViewItem(product_images[i].ID.ToString());
                        image_item.ImageIndex = i;
                        image_item.StateImageIndex = i;
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                        lstProductImages.Items.Add(image_item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        ListViewItem image_item = new ListViewItem(product_images[i].ID.ToString());
                        image_item.ImageIndex = i;
                        image_item.StateImageIndex = i;
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                        lstProductImages.Items.Add(image_item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductImages(int[] IDs,bool SearchByProductID)
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    product_images.Clear();
                    foreach(int ID in IDs)
                    {
                        if (SearchByProductID)
                        {
                            product_images.AddRange(ent.ProductImages.Where(x => x.ProductID == ID).ToList());
                        }
                        else
                        {
                            product_images.AddRange(ent.ProductImages.Where(x => x.ID == ID).ToList());
                        }
                    }
                    lstProductImages.Items.Clear();
                    imgListProductImages.Images.Clear();
                    for (int i = 0; i < product_images.Count; i++)
                    {
                        Bitmap extracted_image;
                        ConvertBinaryToImage(product_images[i].ImageData, out extracted_image);
                        imgListProductImages.Images.Add(extracted_image);
                        ListViewItem image_item = new ListViewItem(product_images[i].ID.ToString());
                        image_item.ImageIndex = i;
                        image_item.StateImageIndex = i;
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                        image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                        lstProductImages.Items.Add(image_item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DateTime ExpiryDateFrom = dtExpiryDateFrom.Value;
            DateTime ExpiryDateTo = dtExpiryDateTo.Value;
            string RegistrationNumber = txtProductRegNum.Text;
            string PartitudeNumber = txtProductPartNum.Text;
            string StorageLocation = txtProductStorageLocation.Text;
            int Quantity = trbQuantity.Value;
            decimal Price = trbPrice.Value;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1)
            {
                RefreshProductBrands();
                products = ent.Products.Where(
                    x => x.ID == ProductID ^ x.BrandID == BrandID ^ x.ProductName.Contains(ProductName) ^ x.ProductDescription.Contains(ProductDescription) ^
                        (x.ProductExpiryDate >= ExpiryDateFrom && x.ProductExpiryDate <= ExpiryDateTo) ^ x.ProductRegNum.Contains(RegistrationNumber) ^ 
                        x.ProductPartNum.Contains(PartitudeNumber) ^ x.ProductStorageLocation.Contains(StorageLocation) ^ 
                        (x.ProductQuantity <= Quantity || x.ProductQuantity >= Quantity) ^ (x.ProductPrice <= Price || x.ProductPrice >= Price)).ToList(); 
                dgvProducts.DataSource = products;
                int[] extractedids = new int[products.Count];
                for(int i = 0; i < extractedids.Count(); i++)
                {
                    extractedids[i] = products[i].ID;
                }
                RefreshProductImages(extractedids, true);
            }
            else if (SearchMode == 2)
            {
                RefreshProductBrands();
                products = ent.Products.Where(
                    x => x.ID == ProductID || x.BrandID == BrandID || x.ProductName.Contains(ProductName) || x.ProductDescription.Contains(ProductDescription) ||
                        (x.ProductExpiryDate >= ExpiryDateFrom && x.ProductExpiryDate <= ExpiryDateTo) || x.ProductRegNum.Contains(RegistrationNumber) ||
                        x.ProductPartNum.Contains(PartitudeNumber) || x.ProductStorageLocation.Contains(StorageLocation) ||
                        (x.ProductQuantity <= Quantity || x.ProductQuantity >= Quantity) || (x.ProductPrice <= Price || x.ProductPrice >= Price)).ToList();
                dgvProducts.DataSource = products;
                int[] extractedids = new int[products.Count];
                for (int i = 0; i < extractedids.Count(); i++)
                {
                    extractedids[i] = products[i].ID;
                }
                RefreshProductImages(extractedids, true);
            }
            else if (SearchMode == 3)
            {
                RefreshProductBrands();
                products = ent.GetProduct(ProductID,ProductName,BrandID,ProductDescription,Quantity,Price,ExpiryDateFrom,ExpiryDateTo,RegistrationNumber,
                    PartitudeNumber,StorageLocation).ToList();
                dgvProducts.DataSource = products;
                int[] extractedids = new int[products.Count];
                for (int i = 0; i < extractedids.Count(); i++)
                {
                    extractedids[i] = products[i].ID;
                }
                RefreshProductImages(extractedids, true);
            }
            else
            {
                RefreshProductBrands();
                RefreshProducts();
                RefreshProductImages();
            }
            logger.RefreshLogs();
        }

        private void trbPrice_Scroll(object sender, EventArgs e)
        {
            lblShowPrice.Text = trbPrice.Value.ToString();
        }

        private void trbQuantity_Scroll(object sender, EventArgs e)
        {
            lblShowQuantity.Text = trbQuantity.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int ProductID = -1;
            Product selectedProduct;
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    row = dgvProducts.SelectedRows[0];
                    if (row != null && products != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                        if (ProductID > 0)
                        {
                            selectedProduct= products.Where(x => x.ID == ProductID).FirstOrDefault();
                            if (selectedProduct != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateProductByID(selectedProduct.ID,selectedProduct.ProductName,selectedProduct.BrandID,
                                            selectedProduct.ProductDescription,selectedProduct.ProductQuantity,selectedProduct.ProductPrice,
                                            selectedProduct.ProductExpiryDate,selectedProduct.ProductRegNum,selectedProduct.ProductPartNum,
                                            selectedProduct.ProductStorageLocation);
                                        ent.SaveChanges();
                                        RefreshProductBrands();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        product_manager.AddOperation(new BulkProductOperation(BulkOperationType.UPDATE, ref ent, selectedProduct, true));
                                    }
                                }
                            }
                            else
                            {
                                //Create a new one
                                selectedProduct = new Product();
                                DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddProduct(selectedProduct.ProductName, selectedProduct.BrandID, selectedProduct.ProductDescription,
                                            selectedProduct.ProductQuantity, selectedProduct.ProductPrice, selectedProduct.ProductExpiryDate,
                                            selectedProduct.ProductRegNum, selectedProduct.ProductPartNum, selectedProduct.ProductStorageLocation);
                                        ent.SaveChanges();
                                        RefreshProductBrands();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        product_manager.AddOperation(new BulkProductOperation(BulkOperationType.ADD, ref ent, selectedProduct, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            selectedProduct = new Product();
                            DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddProduct(selectedProduct.ProductName, selectedProduct.BrandID, selectedProduct.ProductDescription,
                                        selectedProduct.ProductQuantity, selectedProduct.ProductPrice, selectedProduct.ProductExpiryDate,
                                        selectedProduct.ProductRegNum, selectedProduct.ProductPartNum, selectedProduct.ProductStorageLocation);
                                    ent.SaveChanges();
                                    RefreshProductBrands();
                                    RefreshProducts();
                                    RefreshProductImages();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    product_manager.AddOperation(new BulkProductOperation(BulkOperationType.ADD, ref ent, selectedProduct, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedProduct = new Product();
                    DialogResult res = new frmEditProduct(ref selectedProduct, ref product_brands).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddProduct(selectedProduct.ProductName, selectedProduct.BrandID, selectedProduct.ProductDescription,
                                selectedProduct.ProductQuantity, selectedProduct.ProductPrice, selectedProduct.ProductExpiryDate,
                                selectedProduct.ProductRegNum, selectedProduct.ProductPartNum, selectedProduct.ProductStorageLocation);
                            ent.SaveChanges();
                            RefreshProductBrands();
                            RefreshProducts();
                            RefreshProductImages();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            product_manager.AddOperation(new BulkProductOperation(BulkOperationType.ADD, ref ent, selectedProduct, true));
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int ProductID = -1;
            Product selectedProduct;
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    row = dgvProducts.SelectedRows[0];
                    if (row != null && products != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                        if (ProductID > 0)
                        {
                            selectedProduct = products.Where(x => x.ID == ProductID).FirstOrDefault();
                            if (selectedProduct != null)
                            {
                                //Show the editor window to edit the selected user
                                //on dialog result yes update it
                                DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (res == DialogResult.Yes)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.DeleteProductByID(selectedProduct.ID);
                                        ent.SaveChanges();
                                        RefreshProductBrands();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        product_manager.AddOperation(new BulkProductOperation(BulkOperationType.DELETE, ref ent, selectedProduct, true));
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int ProductID = -1;
            Product target_product;
            try
            {
                if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                {
                    Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                    if (ProductID >= 0 && products != null)
                    {
                        target_product = products.Where(x => x.ID == ProductID).FirstOrDefault();
                        if(target_product != null)
                        {
                            txtID.Text = target_product.ID.ToString();
                            txtReferencedID.Text = target_product.ID.ToString();
                            if (cbSelectBrand.Items.Contains(target_product.BrandID))
                            {
                                cbSelectBrand.SelectedValue = target_product.BrandID;
                            }
                            txtProductName.Text = target_product.ProductName.ToString();
                            txtProductDescription.Text = target_product.ProductDescription.ToString();
                            dtExpiryDateFrom.Value = target_product.ProductExpiryDate;
                            txtProductRegNum.Text = target_product.ProductRegNum.ToString();
                            txtProductPartNum.Text = target_product.ProductPartNum.ToString();
                            txtProductStorageLocation.Text = target_product.ProductStorageLocation.ToString();
                            trbQuantity.Value = target_product.ProductQuantity;
                            lblShowQuantity.Text = target_product.ProductQuantity.ToString();
                            trbPrice.Value = Convert.ToInt32(target_product.ProductPrice);
                            lblShowPrice.Text = target_product.ProductPrice.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewComboBoxCell brandcell;
            DataGridViewComboBoxColumn brandcolumn;
            int ProductID = -1;
            Product target_product;
            ProductBrand target_brand;
            try
            {
                foreach (DataGridViewRow row in target_view.Rows)
                {
                    if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
                    {
                        brandcell = (DataGridViewComboBoxCell)row.Cells["BrandIDColumn"];
                        brandcolumn = (DataGridViewComboBoxColumn)target_view.Columns["BrandIDColumn"];
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ProductID);
                        if (product_brands != null && products != null)
                        {
                            target_product = products.Where(x => x.ID == ProductID).FirstOrDefault();
                            if (target_product != null)
                            {
                                target_brand = product_brands.Where(x => x.ID == target_product.BrandID).FirstOrDefault();
                                if (target_brand != null)
                                {
                                    brandcell.Value = target_brand.ID;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstProductImages_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView current = (ListView)sender;
            ListViewItem currentItem = current.Items[e.ItemIndex];
            ProductImage selectedImage;
            int ImageID = -1;
            try
            {
                if (current != null && currentItem != null && product_images != null)
                {
                    Int32.TryParse(currentItem.Text, out ImageID);
                    if (ImageID >= 0)
                    {
                        selectedImage = product_images.Where(x => x.ID == ImageID).FirstOrDefault();
                        if (selectedImage != null)
                        {
                            Bitmap bmp;
                            ConvertBinaryToImage(selectedImage.ImageData, out bmp);
                            txtImageID.Text = selectedImage.ID.ToString();
                            txtReferencedID.Text = selectedImage.ProductID.ToString();
                            txtImageName.Text = selectedImage.ImageName;
                            if (bmp != null)
                            {
                                pbSelectedProductImage.Image = bmp;
                            }
                            else
                            {
                                bmp = new Bitmap(64, 64);
                                pbSelectedProductImage.Image = bmp;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchProductImage_Click(object sender, EventArgs e)
        {
            //This refreshes the product images only but not the products, search products with the none criteria
            //to refresh all brands, products and images related to products
            int ImageID = -1;
            int ProductID = -1;
            int SearchMode = cbSearchMode.SelectedIndex;
            string ImageName = txtImageName.Text;
            Int32.TryParse(txtImageID.Text, out ImageID);
            Int32.TryParse(txtReferencedID.Text, out ProductID);
            if (SearchMode == 1)
            {
                RefreshProductBrands();
                product_images = ent.ProductImages.Where(x => x.ID == ImageID ^ x.ProductID == ProductID ^ x.ImageName.Contains(ImageName)).ToList();
                lstProductImages.Items.Clear();
                imgListProductImages.Images.Clear();
                for (int i = 0; i < product_images.Count; i++)
                {
                    Bitmap extracted_image;
                    ConvertBinaryToImage(product_images[i].ImageData, out extracted_image);
                    imgListProductImages.Images.Add(extracted_image);
                    ListViewItem image_item = new ListViewItem(product_images[i].ID.ToString());
                    image_item.ImageIndex = i;
                    image_item.StateImageIndex = i;
                    image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                    image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                    lstProductImages.Items.Add(image_item);
                }
            }
            else if (SearchMode == 2)
            {
                RefreshProductBrands();
                product_images = ent.ProductImages.Where(x => x.ID == ImageID || x.ProductID == ProductID || x.ImageName.Contains(ImageName)).ToList();
                lstProductImages.Items.Clear();
                imgListProductImages.Images.Clear();
                for (int i = 0; i < product_images.Count; i++)
                {
                    Bitmap extracted_image;
                    ConvertBinaryToImage(product_images[i].ImageData, out extracted_image);
                    imgListProductImages.Images.Add(extracted_image);
                    ListViewItem image_item = new ListViewItem(product_images[i].ID.ToString());
                    image_item.ImageIndex = i;
                    image_item.StateImageIndex = i;
                    image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                    image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                    lstProductImages.Items.Add(image_item);
                }
            }
            else if (SearchMode == 3)
            {
                RefreshProductBrands();
                product_images = ent.GetProductImage(ImageID,ProductID,ImageName).ToList();
                lstProductImages.Items.Clear();
                imgListProductImages.Images.Clear();
                for (int i = 0; i < product_images.Count; i++)
                {
                    Bitmap extracted_image;
                    ConvertBinaryToImage(product_images[i].ImageData, out extracted_image);
                    imgListProductImages.Images.Add(extracted_image);
                    ListViewItem image_item = new ListViewItem(product_images[i].ID.ToString());
                    image_item.ImageIndex = i;
                    image_item.StateImageIndex = i;
                    image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ProductID.ToString()));
                    image_item.SubItems.Add(new ListViewItem.ListViewSubItem(image_item, product_images[i].ImageName.ToString()));
                    lstProductImages.Items.Add(image_item);
                }
            }
            else
            {
                RefreshProductBrands();
                RefreshProductImages();
            }
            logger.RefreshLogs();
        }

        private void btnDeleteProductImage_Click(object sender, EventArgs e)
        {
            //Multiselect is disabled on the images list as well.
            //on image create, update and delete tho everything is refreshed
            ListViewItem currentItem = lstProductImages.SelectedItems[0];
            ProductImage selectedImage;
            int ImageID = -1;
            try
            {
                if (currentItem != null && product_images != null)
                {
                    Int32.TryParse(currentItem.Text, out ImageID);
                    if (ImageID >= 0)
                    {
                        selectedImage = product_images.Where(x => x.ID == ImageID).FirstOrDefault();
                        if (selectedImage != null)
                        {
                            DialogResult res = MessageBox.Show("Are you sure you want to delete this record?\nThis operation is irreversible and can cause " +
                                  "troubles in the database relations.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (res == DialogResult.Yes)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.DeleteProductImageByID(selectedImage.ID);
                                    ent.SaveChanges();
                                    RefreshProductBrands();
                                    RefreshProducts();
                                    RefreshProductImages();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    image_manager.AddOperation(new BulkProductImageOperation(BulkOperationType.DELETE, ref ent, selectedImage, true));
                                }
                            }
                        }
                    }

                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEditProductImage_Click(object sender, EventArgs e)
        {
            ListViewItem currentItem; 
            ProductImage selectedImage;
            int ImageID = -1;
            try
            {
                if(lstProductImages.SelectedItems.Count > 0)
                { 
                    currentItem = lstProductImages.SelectedItems[0];
                    if (currentItem != null && product_images != null)
                    {
                        Int32.TryParse(currentItem.Text, out ImageID);
                        if (ImageID >= 0)
                        {
                            selectedImage = product_images.Where(x => x.ID == ImageID).FirstOrDefault();
                            if (selectedImage != null)
                            {
                                DialogResult res = new frmEditProductImage(ref selectedImage, ref products).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.UpdateProductImageByID(selectedImage.ID,selectedImage.ProductID,selectedImage.ImageName,selectedImage.ImageData);
                                        ent.SaveChanges();
                                        RefreshProductBrands();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        image_manager.AddOperation(new BulkProductImageOperation(BulkOperationType.UPDATE, ref ent, selectedImage, true));
                                    }
                                }
                            }
                            else
                            {
                                selectedImage = new ProductImage();
                                DialogResult res = new frmEditProductImage(ref selectedImage, ref products).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddProductImage(selectedImage.ProductID, selectedImage.ImageName, selectedImage.ImageData);
                                        ent.SaveChanges();
                                        RefreshProductBrands();
                                        RefreshProducts();
                                        RefreshProductImages();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        image_manager.AddOperation(new BulkProductImageOperation(BulkOperationType.ADD, ref ent, selectedImage, true));
                                    }
                                }
                            }
                        }
                        else
                        {
                            selectedImage = new ProductImage();
                            DialogResult res = new frmEditProductImage(ref selectedImage, ref products).ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                if (ent.Database.Connection.State == ConnectionState.Open)
                                {
                                    ent.AddProductImage(selectedImage.ProductID, selectedImage.ImageName, selectedImage.ImageData);
                                    ent.SaveChanges();
                                    RefreshProductBrands();
                                    RefreshProducts();
                                    RefreshProductImages();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    image_manager.AddOperation(new BulkProductImageOperation(BulkOperationType.ADD, ref ent, selectedImage, true));
                                }
                            }
                        }
                    }
                }
                else
                {
                    selectedImage = new ProductImage();
                    DialogResult res = new frmEditProductImage(ref selectedImage, ref products).ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        if (ent.Database.Connection.State == ConnectionState.Open)
                        {
                            ent.AddProductImage(selectedImage.ProductID, selectedImage.ImageName, selectedImage.ImageData);
                            ent.SaveChanges();
                            RefreshProductBrands();
                            RefreshProducts();
                            RefreshProductImages();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            image_manager.AddOperation(new BulkProductImageOperation(BulkOperationType.ADD, ref ent, selectedImage, true));
                        }
                    }
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearchProducts_Load(object sender, EventArgs e)
        {
            RefreshProductBrands();
            RefreshProducts();
            RefreshProductImages();
        }
    }
}
