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
        List<User> users;
        public frmSearchUsers(List<User> users)
        {
            this.users = users;
            InitializeComponent();
            dgvUsers.DataSource = users;
        }
    }
}
