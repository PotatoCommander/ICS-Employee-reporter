using System;
using System.IO;
using System.Windows.Forms;
using ICS_Employee_reporter.DAL;
using Microsoft.Reporting.WinForms;

namespace ICS_Employee_reporter
{
    public partial class ReportForm : Form
    {
        private EmployeeRepository _repository;
        private string _reportPath;

        public ReportForm(EmployeeRepository repository)
        {
            _repository = repository;
            var reportDataSource = new ReportDataSource("DataSet", _repository.Report());
            InitializeComponent();
            var exeFolder = Application.StartupPath;
            _reportPath = Path.Combine(exeFolder, @"../../Report.rdlc");
            reportViewer.LocalReport.ReportPath = _reportPath;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }

        private void reportViewer_ReportRefresh(object sender, System.ComponentModel.CancelEventArgs e)
        {
            reportViewer.LocalReport.ReportPath = _reportPath;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet", _repository.Report()));
            reportViewer.RefreshReport();
        }
    }
}