using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
    public class Logger
    {
       static Entities entities;
       public static Logger instance;
       public static List<Log> logs;
       public static DateTime lastUpdate;
       public LogsRefreshedEventHandler LogsRefreshed;
       public List<Log> Logs {  get { return logs; } }
        public Logger(ref Entities ent)
        {
            entities = ent;
            logs = new List<Log>();
            lastUpdate = DateTime.Now;
            this.LogsRefreshed = OnLogsRefreshed;
            if (instance == null)
            {
                instance = this;
            }
        }

        public void RefreshLogs()
        {
            try
            {
                if (entities.Database.Connection.State == System.Data.ConnectionState.Open)
                {
                    logs = entities.GetLog(-1, new DateTime(), new DateTime(), "", "", "").ToList();
                    lastUpdate = DateTime.Now;
                    this.InvokeRefreshEvent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured:{ex.Message}\nStackTrace:{ex.StackTrace}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvokeRefreshEvent()
        {
            LoggerEventArgs currentArgs = new LoggerEventArgs(logs, lastUpdate);
            this.LogsRefreshed((object)this, currentArgs);
        }

        protected virtual void OnLogsRefreshed(object sender, LoggerEventArgs e)
        {
            if(LogsRefreshed != null)
            {
                LogsRefreshed(sender, e);
            }
        }

    }
}
