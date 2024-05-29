using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static XtremePharmacyManager.ImageBinConverter;

namespace XtremePharmacyManager
{
    public partial class frmSearchUsers : Form
    {
        static Entities ent;
        static List<User> users;
        static User current_user;
        static Logger logger;
        static BulkOperationManager<User> manager;
        public frmSearchUsers(ref Entities entity, ref User currentUser, ref Logger extlogger, ref BulkOperationManager<User> bulkusermanager)
        {
            ent = entity;
            current_user = currentUser;
            logger = extlogger;
            manager = bulkusermanager;
            manager.BulkOperationsExecuted += Users_OnBulkOperationExecuted;
            InitializeComponent();
        }

        private void Users_OnBulkOperationExecuted(object sender, BulkOperationEventArgs<User> e)
        {
            RefreshUsers();
            logger.RefreshLogs();
        }

        private void RefreshUsers()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    users = ent.GetUser(-1, "", "", "", DateTime.Now, DateTime.Now, "", "", "", new decimal(), "", DateTime.Now, DateTime.Now, 0).ToList();
                    foreach(var user in users)
                    {
                        //Always get updated data from the database on each refresh before setting the data source
                        ent.Entry(ent.Users.Where(x => x.ID == user.ID).FirstOrDefault()).Reload();
                    }
                    dgvUsers.DataSource = users;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            Int32.TryParse(txtID.Text, out UserID);
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;
            string DisplayName = txtDisplayName.Text;
            DateTime BirthDateFrom = dtBirthDateFrom.Value;
            DateTime BirthDateTo = dtBirthDateTo.Value;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;
            string Address = txtAddress.Text;
            decimal Balance = trbBalance.Value;
            string Diagnose = txtDiagnose.Text;
            DateTime RegisterDateFrom = dtRegisterDateFrom.Value;
            DateTime RegisterDateTo = dtRegisterDateTo.Value;
            int Role = cbRole.SelectedIndex;
            int SearchMode = cbSearchMode.SelectedIndex;
          if (SearchMode == 1 && (current_user.UserRole == 0 || current_user.UserRole == 1))
            {
                users = ent.Users.Where(
                    x => x.ID == UserID ^ x.UserName.Contains(UserName) ^ x.UserPassword.Contains(Password) ^
                        x.UserDisplayName.Contains(DisplayName) ^ (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ^
                        x.UserPhone.Contains(Phone) ^ x.UserEmail.Contains(Email) ^ x.UserAddress.Contains(Address) ^ (x.UserBalance <= Balance || x.UserBalance >= Balance) ^
                        x.UserDiagnose.Contains(Diagnose) ^ (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) ^ x.UserRole == Role
                ).ToList(); 
                dgvUsers.DataSource = users;
            }
            else if (SearchMode == 2 && (current_user.UserRole == 0 || current_user.UserRole == 1))
            {
                users = ent.Users.Where(
                    x => x.ID == UserID || x.UserName.Contains(UserName) || x.UserPassword.Contains(Password) ||
                        x.UserDisplayName.Contains(DisplayName) || (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ||
                        x.UserPhone.Contains(Phone) || x.UserEmail.Contains(Email) || x.UserAddress.Contains(Address) || (x.UserBalance <= Balance || x.UserBalance >= Balance) ||
                        x.UserDiagnose.Contains(Diagnose) || (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) || x.UserRole == Role
                ).ToList();
                dgvUsers.DataSource = users;
            }
            else if (SearchMode == 3 && (current_user.UserRole == 0 || current_user.UserRole == 1))
            {
                users = ent.GetUser(UserID,UserName,Password,DisplayName,BirthDateFrom,BirthDateTo,Phone,Email,Address,Balance,Diagnose,RegisterDateFrom,RegisterDateTo,Role).ToList();
                dgvUsers.DataSource = users;
            }
            else
            {
                if (current_user.UserRole != 0 && current_user.UserRole != 1)
                {
                    MessageBox.Show("User list access is given only to administrators and employees of this system.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshUsers();
            }
            logger.RefreshLogs();
        }

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            if(((TrackBar)sender).Value > ((TrackBar)sender).Maximum)
            {
                ((TrackBar)sender).Value = ((TrackBar)sender).Maximum;
            }
            txtBalance.Text = trbBalance.Value.ToString();
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //The Datagrid is with multiselect as false so one thing is selected at a time
            DataGridViewRow row;
            int UserID = -1;
            User selectedUser;
            try
            {
                if (dgvUsers.SelectedRows.Count > 0 && current_user.UserRole == 0)
                {
                    row = dgvUsers.SelectedRows[0];
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
                                        //Update the fucking views as well because they don't get automatically updated in the entity model on
                                        //data change while in the database itself they get updated and created and deleted easily
                                        
                                        if (selectedUser.UserRole == 0 || selectedUser.UserRole == 1)
                                        {
                                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                                            EmployeeView current_emp_view = ent.EmployeeViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                            if (current_emp_view != null)
                                            {
                                                ent.Entry(current_emp_view).Reload();
                                            }
                                        }
                                        else if (selectedUser.UserRole == 2)
                                        {
                                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                                            ClientView current_cl_view = ent.ClientViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                            if (current_cl_view != null)
                                            {
                                                ent.Entry(current_cl_view).Reload();
                                            }
                                        }
                                        RefreshUsers();
                                    }
                                }
                                else
                                {
                                    if(MessageBox.Show("Do you want to add this as a bulk operation?","Bulk Operations",MessageBoxButtons.YesNo,MessageBoxIcon.Question)  == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkUserOperation(BulkOperationType.UPDATE, ref ent, selectedUser, true));
                                    }
                                }
                            }
                            else
                            {
                                //Create a new user
                                selectedUser = new User();
                                //show the editor and after the editor confirms add it
                                DialogResult res = new frmEditUser(ref selectedUser).ShowDialog();
                                if (res == DialogResult.OK)
                                {
                                    if (ent.Database.Connection.State == ConnectionState.Open)
                                    {
                                        ent.AddUser(selectedUser.UserName, selectedUser.UserPassword, selectedUser.UserDisplayName, selectedUser.UserBirthDate,
                                            selectedUser.UserPhone, selectedUser.UserEmail, selectedUser.UserAddress, selectedUser.UserProfilePic, selectedUser.UserBalance,
                                            selectedUser.UserDiagnose, selectedUser.UserRole);
                                        if (selectedUser.UserRole == 0 || selectedUser.UserRole == 1)
                                        {
                                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                                            EmployeeView current_emp_view = ent.EmployeeViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                            if (current_emp_view != null)
                                            {
                                                ent.Entry(current_emp_view).Reload();
                                            }
                                        }
                                        else if (selectedUser.UserRole == 2)
                                        {
                                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                                            ClientView current_cl_view = ent.ClientViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                            if (current_cl_view != null)
                                            {
                                                ent.Entry(current_cl_view).Reload();
                                            }
                                        }
                                        RefreshUsers();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkUserOperation(BulkOperationType.ADD, ref ent, selectedUser, true));
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
                                    if (selectedUser.UserRole == 0 || selectedUser.UserRole == 1)
                                    {
                                        //retrieve the data and if it exists reload it from the database, if not, do nothing
                                        EmployeeView current_emp_view = ent.EmployeeViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                        if (current_emp_view != null)
                                        {
                                            ent.Entry(current_emp_view).Reload();
                                        }
                                    }
                                    else if (selectedUser.UserRole == 2)
                                    {
                                        //retrieve the data and if it exists reload it from the database, if not, do nothing
                                        ClientView current_cl_view = ent.ClientViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                        if (current_cl_view != null)
                                        {
                                            ent.Entry(current_cl_view).Reload();
                                        }
                                    }
                                    RefreshUsers();
                                }
                            }
                            else // or add it as a bulk operation
                            {
                                if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //on user prompt add a silent operation by default
                                    manager.AddOperation(new BulkUserOperation(BulkOperationType.ADD, ref ent, selectedUser, true));
                                }
                            }
                        }
                    }
                }
                else if(current_user.UserRole == 0)
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
                            if (selectedUser.UserRole == 0 || selectedUser.UserRole == 1)
                            {
                                //retrieve the data and if it exists reload it from the database, if not, do nothing
                                EmployeeView current_emp_view = ent.EmployeeViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                if (current_emp_view != null)
                                {
                                    ent.Entry(current_emp_view).Reload();
                                }
                            }
                            else if (selectedUser.UserRole == 2)
                            {
                                //retrieve the data and if it exists reload it from the database, if not, do nothing
                                ClientView current_cl_view = ent.ClientViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                if (current_cl_view != null)
                                {
                                    ent.Entry(current_cl_view).Reload();
                                }
                            }
                            RefreshUsers();
                        }
                    }
                    else // or add it as a bulk operation
                    {
                        if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //on user prompt add a silent operation by default
                            manager.AddOperation(new BulkUserOperation(BulkOperationType.ADD, ref ent, selectedUser, true));
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"You don't have permissions to add/edit users besides your own account.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                logger.RefreshLogs();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshUsers();
                logger.RefreshLogs();
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
                if (dgvUsers.SelectedRows.Count > 0 && current_user.UserRole == 0 )
                {
                    row = dgvUsers.SelectedRows[0];
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
                                        if (selectedUser.UserRole == 0 || selectedUser.UserRole == 1)
                                        {
                                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                                            EmployeeView current_emp_view = ent.EmployeeViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                            if (current_emp_view != null)
                                            {
                                                ent.Entry(current_emp_view).Reload();
                                            }
                                        }
                                        else if (selectedUser.UserRole == 2)
                                        {
                                            //retrieve the data and if it exists reload it from the database, if not, do nothing
                                            ClientView current_cl_view = ent.ClientViews.Where(x => x.ID == selectedUser.ID).FirstOrDefault();
                                            if (current_cl_view != null)
                                            {
                                                ent.Entry(current_cl_view).Reload();
                                            }
                                        }
                                        RefreshUsers();
                                    }
                                }
                                else // or add it as a bulk operation
                                {
                                    if (MessageBox.Show("Do you want to add this as a bulk operation?", "Bulk Operations", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //on user prompt add a silent operation by default
                                        manager.AddOperation(new BulkUserOperation(BulkOperationType.DELETE, ref ent, selectedUser, true));
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"You don't have permissions to delete users besides your own account.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                logger.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshUsers();
                logger.RefreshLogs();
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
                            txtUsername.Text = target_user.UserName.ToString();
                            txtPassword.Text = target_user.UserPassword.ToString();
                            txtDisplayName.Text = target_user.UserDisplayName.ToString();
                            dtBirthDateFrom.Value = target_user.UserBirthDate;
                            txtPhone.Text = target_user.UserPhone.ToString();
                            txtEmail.Text = target_user.UserEmail.ToString();
                            txtAddress.Text = target_user.UserAddress.ToString();
                            txtBalance.Text = Convert.ToInt32(target_user.UserBalance).ToString();
                            trbBalance.Value = Convert.ToInt32(target_user.UserBalance);
                            txtDiagnose.Text = target_user.UserDiagnose.ToString();
                            dtRegisterDateFrom.Value = target_user.UserDateOfRegister;
                            cbRole.SelectedIndex = target_user.UserRole;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView current = (DataGridView)sender;
            int UserID = -1;
            User currentUser;
            try
            {
                foreach (DataGridViewRow row in current.Rows)
                {
                    if (row != null && users != null)
                    {
                        Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                        if (users != null)
                        {
                            currentUser = users.Where(x => x.ID == UserID).FirstOrDefault();
                            if (currentUser != null)
                            {
                                DataGridViewComboBoxColumn rolecolumn = (DataGridViewComboBoxColumn)current.Columns["RoleColumn"];
                                rolecolumn.ValueMember = "UserRole";
                                row.Cells["RoleColumn"].Value = rolecolumn.Items[currentUser.UserRole];
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

        private void frmSearchUsers_Load(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            int ID = -1;
            User currentUser;
            string target_report_file;
            ReportDataSource current_source;
            ReportParameterCollection current_params;
            try
            {
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
                {
                    if (dgvUsers.SelectedRows.Count > 0)
                    {
                        row = dgvUsers.SelectedRows[0];
                        if (row != null && users != null)
                        {
                            Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out ID);
                            //Contrary to the CRUD operations, report generating will be for all records no matter
                            //if they are dummy or not
                            currentUser = users.Where(x => x.ID == ID).FirstOrDefault();
                            if (currentUser != null)
                            {
                                if (currentUser.UserRole == 0 || currentUser.UserRole == 1) //if the user is employee or admin(considered an employee)
                                {
                                    target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.EMPLOYEE_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                                    EmployeeView view = ent.EmployeeViews.Where(x => x.ID == currentUser.ID).FirstOrDefault();
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
                                            //for users there will be a special treatment in terms of the profile picture
                                            //it will be a base64 string containing the image data
                                            if ((prop != null && prop.GetValue(view, null) != null) && (prop.GetValue(view, null).GetType() == typeof(byte[]) || prop.GetValue(view, null).GetType() == typeof(Byte[])))
                                            {
                                                byte[] value = (byte[])prop.GetValue(view, null);
                                                string Base64ImageData = Convert.ToBase64String(value);
                                                values[propindex] = Base64ImageData;
                                            }
                                            else
                                            {
                                                values[propindex] = prop.GetValue(view, null);
                                            }
                                            propindex++; //indrease the property index after adding the property name
                                                         //in for and foreach loops everything starts from 0 as always
                                        }
                                        propindex = 0; //reset the index
                                        dt.Rows.Add(values); //add the values
                                                             //then clear the values to ensure memory is not wasted
                                        Array.Clear(values, 0, values.Length);
                                        current_source = new ReportDataSource("EmployeeReportData", dt);
                                        current_params = new ReportParameterCollection();
                                        Bitmap bmp;
                                        ConvertBinaryToImage(view.UserProfilePic, out bmp);
                                        ImageFormat bmp_format = bmp.RawFormat;
                                        ImageCodecInfo bmp_codec_info = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == bmp.RawFormat.Guid);
                                        string bmp_mime_type = bmp_codec_info.MimeType;
                                        current_params.Add(new ReportParameter("Encoding", bmp_mime_type));
                                        current_params.Add(new ReportParameter("RoleName", cbRole.Items[view.UserRole].ToString()));
                                        current_params.Add(new ReportParameter("CompanyName", GLOBAL_RESOURCES.COMPANY_NAME));
                                        new frmReports(target_report_file, ref current_source, ref current_params).Show();
                                    }
                                }
                                else if (currentUser.UserRole == 2) //if the user is a client
                                {
                                    target_report_file = $"{GLOBAL_RESOURCES.REPORT_DIRECTORY}/{GLOBAL_RESOURCES.CLIENT_REPORT_NAME}.{CultureInfo.CurrentCulture}.rdlc";
                                    ClientView view = ent.ClientViews.Where(x => x.ID == currentUser.ID).FirstOrDefault();
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
                                            //for users there will be a special treatment in terms of the profile picture
                                            //it will be a base64 string containing the image data
                                            if ((prop != null && prop.GetValue(view, null) != null) && (prop.GetValue(view, null).GetType() == typeof(byte[]) || prop.GetValue(view, null).GetType() == typeof(Byte[])))
                                            {
                                                byte[] value = (byte[])prop.GetValue(view, null);
                                                string Base64ImageData = Convert.ToBase64String(value);
                                                values[propindex] = Base64ImageData;
                                            }
                                            else
                                            {
                                                values[propindex] = prop.GetValue(view, null);
                                            }
                                            propindex++; //indrease the property index after adding the property name
                                                         //in for and foreach loops everything starts from 0 as always
                                        }
                                        propindex = 0; //reset the index
                                        dt.Rows.Add(values); //add the values
                                                             //then clear the values to ensure memory is not wasted
                                        Array.Clear(values, 0, values.Length);
                                        current_source = new ReportDataSource("ClientReportData", dt);
                                        current_params = new ReportParameterCollection();
                                        Bitmap bmp;
                                        ConvertBinaryToImage(view.UserProfilePic, out bmp);
                                        ImageFormat bmp_format = bmp.RawFormat;
                                        ImageCodecInfo bmp_codec_info = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == bmp.RawFormat.Guid);
                                        string bmp_mime_type = bmp_codec_info.MimeType;
                                        current_params.Add(new ReportParameter("Encoding", bmp_mime_type));
                                        current_params.Add(new ReportParameter("RoleName", cbRole.Items[view.UserRole].ToString()));
                                        current_params.Add(new ReportParameter("CompanyName", GLOBAL_RESOURCES.COMPANY_NAME));
                                        new frmReports(target_report_file, ref current_source, ref current_params).Show();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"User reports cannot be generated or you don't have permissions to view them", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshUsers();
                logger.RefreshLogs();
            }
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(((TextBox)sender).Text, out value);
            if(value >= trbBalance.Maximum)
            {
                trbBalance.Maximum = value;
            }
            trbBalance.Value = value;
        }

    }
}
