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
            logger.RefreshLogs();
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            RefreshLogsInForm(logger.Logs);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int LogID = -1;
                Int32.TryParse(txtID.Text, out LogID);
                DateTime LogDateFrom = dtLogDateFrom.Value;
                DateTime LogDateTo = dtLogDateTo.Value;
                string LogTitle = txtLogTitle.Text;
                string LogMessage = txtLogMessage.Text;
                string AdditionalInformation = txtAdditionalInformation.Text;
                int SearchMode = cbSearchMode.SelectedIndex;
                logger.RefreshLogs(LogID, LogDateFrom, LogDateTo, LogTitle, LogMessage, AdditionalInformation, SearchMode);
                RefreshLogsInForm(logger.Logs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //You can only select one because multiselect is disabled
                ListView current = (ListView)sender;
                ListViewItem selected;
                Log target_log;
                int LogID = -1;
                if (current.SelectedItems.Count > 0)
                {
                    selected = current.SelectedItems[0];
                    if (selected != null)
                    {
                        Int32.TryParse(selected.SubItems[0].Text, out LogID);
                        target_log = logger.Logs.Where(x => x.ID == LogID).FirstOrDefault();
                        if (target_log != null)
                        {
                            txtID.Text = target_log.ID.ToString();
                            txtLogTitle.Text = target_log.LogTitle;
                            txtLogMessage.Text = target_log.LogMessage;
                            txtAdditionalInformation.Text = target_log.AdditionalLogInformation;
                            dtLogDateFrom.Value = target_log.LogDate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.LogsRefreshed -= OnLogsRefreshed;
        }
    }
}
