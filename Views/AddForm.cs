using System;
using System.Windows.Forms;
using ICS_Employee_reporter.DAL;
using ICS_Employee_reporter.Models;

namespace ICS_Employee_reporter
{
    public partial class AddForm : Form
    {
        private MainForm _parentForm;
        private EmployeeRepository _repository;

        public AddForm(MainForm parentForm, EmployeeRepository repository)
        {
            _repository = repository;
            _parentForm = parentForm;
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var employee = new Employee
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Position = PositionTextBox.Text,
                DateOfBirth = Convert.ToDateTime(DateOfBirthTextBox.Text),
                Salary = Convert.ToDecimal(SalaryTextBox.Text)
            };

            var isSuccess = _repository.AddEmployee(employee);
            if (isSuccess)
            {
                _parentForm.UpdateData();
                Close();
                return;
            }

            MessageBox.Show("Не удалось добавить запись.");
        }
    }
}