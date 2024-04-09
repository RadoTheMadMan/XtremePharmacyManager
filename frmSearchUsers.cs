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
    public partial class frmSearchUsers : Form
    {
        Entities ent;
        List<User> users;
        public frmSearchUsers(Entities ent)
        {
            this.ent = ent;
            InitializeComponent();
            RefreshUsers();
        }

        private void RefreshUsers()
        {
            try
            {
                //Never try to execute any function if it is not online
                if (ent.Database.Connection.State == ConnectionState.Open)
                {
                    List<User> users = ent.GetUser(-1, "", "", "", new DateTime(), new DateTime(), "", "", "", new decimal(), "", new DateTime(), new DateTime(), 0).ToList();
                    dgvUsers.DataSource = users;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView target_view = (DataGridView)sender;
            DataGridViewRow row = target_view.Rows[e.RowIndex];
            int UserID = -1;
            User target_user;
            if (row != null && row.Index >= 0 && row.Index <= target_view.RowCount)
            {
                Int32.TryParse(row.Cells["IDColumn"].Value.ToString(), out UserID);
                if (UserID >= 0)
                {
                    target_user = users[UserID];
                    row.Cells["RoleColumn"].Value = RoleColumn.Items[target_user.UserRole];
                }
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
          if (SearchMode == 1)
            {
                users = ent.Users.Where(
                    x => x.ID == UserID ^ x.UserName.Contains(UserName) ^ x.UserPassword.Contains(Password) ^
                        x.UserDisplayName.Contains(DisplayName) ^ (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ^
                        x.UserPhone.Contains(Phone) ^ x.UserEmail.Contains(Email) ^ x.UserAddress.Contains(Address) ^ (x.UserBalance <= Balance || x.UserBalance >= Balance) ^
                        x.UserDiagnose.Contains(Diagnose) ^ (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) ^ x.UserRole == Role
                ).ToList(); 
                dgvUsers.DataSource = users;
            }
            else if (SearchMode == 2)
            {
                users = ent.Users.Where(
                    x => x.ID == UserID || x.UserName.Contains(UserName) || x.UserPassword.Contains(Password) ||
                        x.UserDisplayName.Contains(DisplayName) || (x.UserBirthDate >= BirthDateFrom && x.UserBirthDate <= BirthDateTo) ||
                        x.UserPhone.Contains(Phone) || x.UserEmail.Contains(Email) || x.UserAddress.Contains(Address) || (x.UserBalance <= Balance || x.UserBalance >= Balance) ||
                        x.UserDiagnose.Contains(Diagnose) || (x.UserDateOfRegister >= RegisterDateFrom && x.UserDateOfRegister <= RegisterDateTo) || x.UserRole == Role
                ).ToList();
                dgvUsers.DataSource = users;
            }
            else if (SearchMode == 3)
            {
                users = ent.GetUser(UserID,UserName,Password,DisplayName,BirthDateFrom,BirthDateTo,Phone,Email,Address,Balance,Diagnose,RegisterDateFrom,RegisterDateTo,Role).ToList();
                dgvUsers.DataSource = users;
            }
            else
            {
                RefreshUsers();
            }
        }

        private void trbBalance_Scroll(object sender, EventArgs e)
        {
            lblShowBalance.Text = trbBalance.Value.ToString();
        }
    }
}
