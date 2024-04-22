using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    public partial class frmReports : Form
    {
        string ReportSourceFile = "";
        ReportDataSource source;
        ReportParameterCollection reportParams;
        public frmReports(string reportSourceFile, ref ReportDataSource dataSource, ref ReportParameterCollection givenparameters)
        {
            InitializeComponent();
            ReportSourceFile = reportSourceFile;
            source = dataSource;
            reportParams = givenparameters;
        }

        private void frmReportcs_Load(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            //Generate report and then refresh it
            try
            {
                this.rwReports.LocalReport.ReportPath = ReportSourceFile;
                this.rwReports.LocalReport.DataSources.Add(source);
                this.rwReports.LocalReport.SetParameters(reportParams);
                this.rwReports.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
