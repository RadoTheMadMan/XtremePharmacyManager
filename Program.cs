using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.Properties;

namespace XtremePharmacyManager
{
    public class GLOBAL_RESOURCES
    {
        public static string CRITICAL_ERROR_MESSAGE = "";
        public static string CRITICAL_ERROR_TITLE = "";
        public static string CLOSE_PROMPT = "";
        public static string CLOSE_PROMPT_TITLE = "";
        public GLOBAL_RESOURCES()
        {
            ResourceManager manager = Resources.ResourceManager;
            CRITICAL_ERROR_MESSAGE = manager.GetString("CriticalErrorMessage", CultureInfo.CurrentCulture);
            CRITICAL_ERROR_TITLE = manager.GetString("CriticalErrorTitle", CultureInfo.CurrentCulture);
            CLOSE_PROMPT = manager.GetString("ClosePrompt", CultureInfo.CurrentCulture);
            CLOSE_PROMPT_TITLE = manager.GetString("ClosePromptTile", CultureInfo.CurrentCulture);
        }
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static GLOBAL_RESOURCES resources = new GLOBAL_RESOURCES();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
