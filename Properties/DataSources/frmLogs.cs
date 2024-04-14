using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;

namespace XtremePharmacyManager.Properties.DataSources
{
    public partial class frmLogs : Form
    {
        Logger logger;
        public frmLogs(ref Logger logger)
        {
            this.logger = logger;
            InitializeComponent();
            logger.LogsRefreshed += OnLogsRefreshed;
        }

        private void OnLogsRefreshed(object sender, LoggerEventArgs e)
        {
            RefreshLogsInForm(e.Logs);
        }

        private void RefreshLogsInForm(List<Log> logs)
        {
            try
            {
                lstLogs.Items.Clear();
                if (logs != null && logs.Count > 0)
                {
                    foreach (Log log in logs)
                    {
                        ListViewItem item = new ListViewItem(log.ID.ToString());
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, log.LogDate.ToString()));
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, log.LogTitle.ToString()));
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, log.LogMessage.ToString()));
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, log.AdditionalLogInformation.ToString()));
                        lstLogs.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            RefreshLogsInForm(logger.Logs);
        }
    }
}
