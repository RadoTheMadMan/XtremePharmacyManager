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
        static Logger logger;
        static User current_user;
        public frmLogs(ref Logger extlogger, ref User currentUser)
        {
            logger = extlogger;
            current_user = currentUser;
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            logger.RefreshLogs();
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
                if (current_user.UserRole == 0 || current_user.UserRole == 1)
                {
                    logger.RefreshLogs(LogID, LogDateFrom, LogDateTo, LogTitle, LogMessage, AdditionalInformation, SearchMode);
                }
                else
                {
                    if (current_user.UserRole != 0 && current_user.UserRole != 1)
                    {
                        MessageBox.Show("Database Logs access is given only to administrators and employees of this system.", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                RefreshLogsInForm(logger.Logs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logger != null)
            {
                logger.LogsRefreshed -= OnLogsRefreshed;
                logger = null;
                current_user = null;
            }
        }
    }
}
