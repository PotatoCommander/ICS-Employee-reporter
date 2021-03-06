using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ICS_Employee_reporter.DAL;
using ICS_Employee_reporter.Models;
using ICS_Employee_reporter.SQL_Procedures;

namespace ICS_Employee_reporter
{
    public partial class MainForm : Form
    {
        private readonly EmployeeRepository _repository;
        private ICollection<Employee> _employees;

        public MainForm()
        {
            InitializeComponent();
            _repository = new EmployeeRepository(System.Configuration.ConfigurationManager.
                ConnectionStrings["defaultConnection"].ConnectionString);
            UpdateData();
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
        }

        private void InitDB()
        {
            _repository.Query(Procedures.InsertProcedureCreation);
            _repository.Query(Procedures.DeleteProcedureCreation);
            _repository.Query(Procedures.SelectAllProcedureCreation);
            _repository.Query(Procedures.AverageSalaryProcedureCreation);
            _repository.Query(Procedures.CreateEmployeeTable);
        }

        public void UpdateData()
        {
            var list = _repository.GetAll();
            dataGrid.DataSource = list;
            var comboBoxList = list.Select(x => x.Position).Distinct().ToList();
            comboBoxList.Insert(0, "-----");
            comboBox.DataSource = comboBoxList;
        }

        private void AddButton_click(object sender, EventArgs e)
        {
            var addForm = new AddForm(this, _repository);
            addForm.Show();
        }

        private void DeleteButton_click(object sender, EventArgs e)
        {
            if (dataGrid.CurrentRow != null)
            {
                var id = dataGrid.CurrentRow.Cells[0].Value.ToString();
                var isSuccess = _repository.DeleteById(id);
                if (isSuccess)
                {
                    UpdateData();
                    return;
                }

                MessageBox.Show("Ошибка удаления.");
                return;
            }

            MessageBox.Show("Столбец не выделен");
        }

        private void ReportButton_click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm(_repository);
            reportForm.Show();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem.ToString().Equals("-----"))
            {
                dataGrid.DataSource = _repository.GetAll();
            }
            else
            {
                dataGrid.DataSource = _repository.GetAll()
                    .Where(x => x.Position == comboBox.SelectedItem.ToString())
                    .ToList();
            }
            
            dataGrid.Update();
        }
    }
}