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
        private ICollection<Employee> _employees;
        private readonly EmployeeRepository _repository;

        private readonly string _con =
            "Data Source=POTATOSLENOVO\\SQLEXPRESS;Initial Catalog=Employees-DB;Integrated Security=True";

        public MainForm()
        {
            InitializeComponent();
            _repository = new EmployeeRepository(_con);
            _repository.Query(Procedures.InsertProcedureCreation);
            _repository.Query(Procedures.DeleteProcedureCreation);
            _repository.Query(Procedures.SelectAllProcedureCreation);


            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
        }

        public void UpdateData()
        {
            var list = _repository.GetAll();
            dataGrid.DataSource = list;
            comboBox.DataSource = list.Select(x => x.Position).Distinct().ToList();
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
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = _repository.GetAll().Where(x => x.Position == textBox1.Text).ToList();
            dataGrid.Update();
        }
    }
}