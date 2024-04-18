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
    public partial class frmBulkUserOperations : Form
    {
        static BulkOperationManager<User> manager;
        BulkOperation<User> selected_operation;
        User selected_target;
        static Entities manager_entities;
        public frmBulkUserOperations(ref BulkOperationManager<User> operation_manager)
        {
            InitializeComponent();
            manager = operation_manager;
            manager_entities = manager.Entities;
            manager.BulkOperationsExecuted += OnBulkOperationExecuted;
            manager.BulkOperationAdded += OnBulkOperationListChanged;
            manager.BulkOperationRemoved += OnBulkOperationListChanged;
            manager.BulkOperationUpdated += OnBulkOperationListChanged;
        }

        private void OnBulkOperationExecuted(object sender, BulkOperationEventArgs<User> e)
        {
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = e.OperationsList;
            lblOperationResults.Text = lblOperationResults.Text + e.Result;
        }

        private void OnBulkOperationListChanged(object sender, BulkOperationEventArgs<User> e)
        {
            lstBulkOperations.DataSource = null;
            lstBulkOperations.DataSource = e.OperationsList;
            lblOperationResults.Text = "Operation Results: ";
            //here let's make a test
            foreach (BulkUserOperation user_operation in e.OperationsList)
            {
                MessageBox.Show($"Current Index: {e.OperationsList.IndexOf(user_operation)}");
                MessageBox.Show(user_operation.OperationName);
                MessageBox.Show(user_operation.TargetObject.UserDisplayName);
            }
        }




        private void frmBulkUserOperations_Load(object sender, EventArgs e)
        {
            Bitmap currentpfp = new Bitmap(64, 64);
            lstBulkOperations.DataSource = manager.BulkOperations;
            if (selected_operation != null && selected_target != null)
            {
                if (selected_target.UserProfilePic != null) { ConvertBinaryToImage(selected_target.UserProfilePic, out currentpfp); }
                this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                this.txtUsername.Text = (!String.IsNullOrEmpty(selected_target.UserName)) ? selected_target.UserName.ToString() : string.Empty;
                this.txtPassword.Text = (!String.IsNullOrEmpty(selected_target.UserPassword)) ? selected_target.UserPassword.ToString() : string.Empty;
                this.txtDisplayName.Text = (!String.IsNullOrEmpty(selected_target.UserDisplayName)) ? selected_target.UserDisplayName.ToString() : string.Empty;
                this.dtBirthDate.Value = (selected_target.UserBirthDate != null && selected_target.UserBirthDate > DateTime.MinValue && selected_target.UserBirthDate < DateTime.MaxValue) ? selected_target.UserBirthDate : DateTime.Now;
                this.txtPhone.Text = (!String.IsNullOrEmpty(selected_target.UserPhone)) ? selected_target.UserPhone.ToString() : string.Empty;
                this.txtEmail.Text = (!String.IsNullOrEmpty(selected_target.UserEmail)) ? selected_target.UserEmail.ToString() : string.Empty;
                this.txtAddress.Text = (!String.IsNullOrEmpty(selected_target.UserAddress)) ? selected_target.UserAddress.ToString() : string.Empty;
                trbBalance.Value = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance) : 0;
                lblShowBalance.Text = (selected_target.UserBalance >= 0) ? selected_target.UserBalance.ToString() : string.Empty;
                txtDiagnose.Text = (!String.IsNullOrEmpty(selected_target.UserDiagnose)) ? selected_target.UserDiagnose : string.Empty;
                cbRole.SelectedIndex = (selected_target.UserRole >= 0 && selected_target.UserRole <= 2) ? selected_target.UserRole : 1;
                pbUserProfilePic.Image = (selected_target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                checkSilentOperation.Checked = selected_operation.IsSilent;
            }
        }

        private void btnExecuteOperations_Click(object sender, EventArgs e)
        {
            manager.ExecuteOperations();
        }

        private void btnApplyChangesToAllTargets_Click(object sender, EventArgs e)
        {
            selected_target.UserDisplayName = txtDisplayName.Text;
            selected_target.UserBirthDate = dtBirthDate.Value;
            selected_target.UserPhone = txtPhone.Text;
            selected_target.UserEmail = txtEmail.Text;
            selected_target.UserAddress = txtAddress.Text;
            selected_target.UserBalance = trbBalance.Value;
            selected_target.UserDiagnose = txtDiagnose.Text;
            selected_target.UserRole = cbRole.SelectedIndex;
            if (pbUserProfilePic.Image != null)
            {
                Bitmap current_image = (Bitmap)pbUserProfilePic.Image;
                byte[] image_data;
                ConvertImageToBinary(current_image, out image_data);
                selected_target.UserProfilePic = image_data;
            }
            selected_operation.TargetObject = selected_target;
            selected_operation.OperationType = (BulkOperationType)cbOperationType.SelectedIndex;
            selected_operation.IsSilent = checkSilentOperation.Checked;
            selected_operation.UpdateName();
            manager.UpdateAllOperations(selected_operation);
        }

        private void lstBulkOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox current = (ListBox)sender;
            if (current.SelectedItems.Count > 0 || ( current.SelectedIndex >= 0 && current.SelectedIndex < current.Items.Count))
            {
                selected_operation = current.Items[current.SelectedIndex] as BulkUserOperation;
                selected_target = selected_operation.TargetObject;
            }
            Bitmap currentpfp = new Bitmap(64, 64);
            if (selected_operation != null && selected_target != null)
            {
                if (selected_target.UserProfilePic != null) { ConvertBinaryToImage(selected_target.UserProfilePic, out currentpfp); }
                this.txtID.Text = (selected_target.ID >= 0) ? selected_target.ID.ToString() : string.Empty;
                this.txtUsername.Text = (!String.IsNullOrEmpty(selected_target.UserName)) ? selected_target.UserName.ToString() : string.Empty;
                this.txtPassword.Text = (!String.IsNullOrEmpty(selected_target.UserPassword)) ? selected_target.UserPassword.ToString() : string.Empty;
                this.txtDisplayName.Text = (!String.IsNullOrEmpty(selected_target.UserDisplayName)) ? selected_target.UserDisplayName.ToString() : string.Empty;
                this.dtBirthDate.Value = (selected_target.UserBirthDate != null && selected_target.UserBirthDate > DateTime.MinValue && selected_target.UserBirthDate < DateTime.MaxValue) ? selected_target.UserBirthDate : DateTime.Now;
                this.txtPhone.Text = (!String.IsNullOrEmpty(selected_target.UserPhone)) ? selected_target.UserPhone.ToString() : string.Empty;
                this.txtEmail.Text = (!String.IsNullOrEmpty(selected_target.UserEmail)) ? selected_target.UserEmail.ToString() : string.Empty;
                this.txtAddress.Text = (!String.IsNullOrEmpty(selected_target.UserAddress)) ? selected_target.UserAddress.ToString() : string.Empty;
                trbBalance.Value = (selected_target.UserBalance >= 0) ? Convert.ToInt32(selected_target.UserBalance) : 0;
                lblShowBalance.Text = (selected_target.UserBalance >= 0) ? selected_target.UserBalance.ToString() : string.Empty;
                txtDiagnose.Text = (!String.IsNullOrEmpty(selected_target.UserDiagnose)) ? selected_target.UserDiagnose : string.Empty;
                cbRole.SelectedIndex = (selected_target.UserRole >= 0 && selected_target.UserRole <= 2) ? selected_target.UserRole : 1;
                pbUserProfilePic.Image = (selected_target.UserProfilePic != null) ? currentpfp : new Bitmap(64, 64);
                cbOperationType.SelectedIndex = (int)selected_operation.OperationType;
                checkSilentOperation.Checked = selected_operation.IsSilent;
            }
            lblOperationResults.Text = "Operation Results: ";
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            bool IsSilent = checkSilentOperation.Checked;
            BulkOperationType operationType = (BulkOperationType)cbOperationType.SelectedIndex;
            manager.AddOperation(new BulkUserOperation(operationType, ref manager_entities, new User()
            {
                ID = -1,
                UserName = $"USER_{new Random().Next(manager_entities.Users.LastOrDefault().ID + 10)}",
                UserPassword = $"PWD_{new Random().NextDouble()}",
                UserDisplayName = txtDisplayName.Text,
                UserBirthDate = dtBirthDate.Value,
                UserPhone = txtPhone.Text,
                UserEmail = txtEmail.Text,
                UserAddress = txtAddress.Text,
                UserBalance = Convert.ToDecimal(trbBalance.Value),
                UserDiagnose = txtDiagnose.Text,
                UserRole = cbRole.SelectedIndex
            }, IsSilent));
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            //Remove it from the list of the manager and nullify it here
            if(selected_operation != null)
            {
                manager.RemoveOperation(selected_operation);
                selected_target = null;
                selected_operation = null;
            }
        }

        private void btnApplyChangesToCurrentTarget_Click(object sender, EventArgs e)
        {
            if (selected_target != null)
            {
                selected_target.UserDisplayName = txtDisplayName.Text;
                selected_target.UserBirthDate = dtBirthDate.Value;
                selected_target.UserPhone = txtPhone.Text;
                selected_target.UserEmail = txtEmail.Text;
                selected_target.UserAddress = txtAddress.Text;
                selected_target.UserBalance = trbBalance.Value;
                selected_target.UserDiagnose = txtDiagnose.Text;
                selected_target.UserRole = cbRole.SelectedIndex;
                if (pbUserProfilePic.Image != null)
                {
                    Bitmap current_image = (Bitmap)pbUserProfilePic.Image;
                    byte[] image_data;
                    ConvertImageToBinary(current_image, out image_data);
                    selected_target.UserProfilePic = image_data;
                }
            }
            if(selected_operation != null)
            {
                int operation_index = manager.BulkOperations.IndexOf(selected_operation);
                BulkOperationType current_type = (BulkOperationType)cbOperationType.SelectedIndex;
                bool IsSilent = checkSilentOperation.Checked;
                selected_operation.OperationType = current_type;
                selected_operation.IsSilent = IsSilent;
                selected_operation.UpdateName();
                manager.UpdateOperation(selected_operation);
            }
        }

       

       
    }
}
