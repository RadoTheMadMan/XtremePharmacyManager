using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager;
using XtremePharmacyManager.DataEntities;

public delegate void LogsRefreshedEventHandler(object sender, LoggerEventArgs e);

public class LoggerEventArgs:EventArgs
{
    public List<Log> Logs;
    public DateTime LastUpdate;
    public LoggerEventArgs(List<Log> Logs, DateTime LastUpdate) : base()
    {
        this.Logs = Logs;
        this.LastUpdate = LastUpdate;
    }
}

namespace XtremePharmacyManager
{
    public class Logger :IDisposable
    {
       static Entities entities;
       static User current_user;
       public static Logger instance;
       public static List<Log> logs;
       public static DateTime lastUpdate;
       public LogsRefreshedEventHandler LogsRefreshed;
       public List<Log> Logs {  get { return logs; } }
        public Logger(ref Entities ent, ref User currentUser)
        {
            entities = ent;
            current_user = currentUser;
            logs = new List<Log>();
            lastUpdate = DateTime.Now;
            if (instance == null)
            {
                instance = this;
            }
        }



        public void RefreshLogs()
        {
            try
            {
                if (entities.Database.Connection.State == System.Data.ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    logs = entities.GetLog(-1, new DateTime(), new DateTime(), "", "", "").ToList();
                    foreach(var entry in logs)
                    {
                        entities.Entry(entities.Logs.Where(x => x.ID == entry.ID).FirstOrDefault()).Reload();
                    }
                    lastUpdate = DateTime.Now;
                    this.InvokeRefreshEvent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshLogs(int ID, DateTime LogDateFrom, DateTime LogDateTo, string Title, string Message, string AdditionalInformation, int SearchMode)
        {
            try
            {
                if (entities.Database.Connection.State == System.Data.ConnectionState.Open && (current_user.UserRole == 0 || current_user.UserRole == 1))
                {
                    if (SearchMode == 1)
                    {
                        logs = entities.Logs.Where(
                            x => x.ID == ID ^ x.LogTitle.Contains(Title) ^ (x.LogDate >= LogDateFrom && x.LogDate <= LogDateTo) ^ x.LogMessage.Contains(Message) ^ x.AdditionalLogInformation.Contains(AdditionalInformation)).ToList();
                    }
                    else if (SearchMode == 2)
                    {
                        logs = entities.Logs.Where(
                           x => x.ID == ID || x.LogTitle.Contains(Title) || (x.LogDate >= LogDateFrom && x.LogDate <= LogDateTo) ||  x.LogMessage.Contains(Message) || x.AdditionalLogInformation.Contains(AdditionalInformation)).ToList();
                    }
                    else if (SearchMode == 3)
                    {
                        logs = entities.GetLog(ID, LogDateFrom, LogDateTo, Title, Message, AdditionalInformation).ToList();
                    }
                    else
                    {
                        RefreshLogs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvokeRefreshEvent()
        {
            try
            {
                LoggerEventArgs currentArgs = new LoggerEventArgs(logs, lastUpdate);
                if (this.LogsRefreshed != null)
                {
                    this.LogsRefreshed((object)this, currentArgs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            logs.Clear();
            logs = null;
            lastUpdate = DateTime.Now;
            instance = null;
            entities = null;
        }
    }
}
