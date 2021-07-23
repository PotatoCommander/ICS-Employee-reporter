using System;
using System.Windows.Forms;
using ICS_Employee_reporter.DAL;
using Microsoft.Reporting.WinForms;

namespace ICS_Employee_reporter
{
    public partial class ReportForm : Form
    {
        private EmployeeRepository _repository;

        public ReportForm(EmployeeRepository repository)
        {
            _repository = repository;
            var a = repository.Report();
            var rds = new ReportDataSource("DataSet", repository.Report());
            InitializeComponent();
            reportViewer.LocalReport.ReportPath =
                "C:\\Users\\Lenovo\\source\\repos\\ICS-Employee-reporter\\Report.rdlc";
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.RefreshReport();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }
    }
}