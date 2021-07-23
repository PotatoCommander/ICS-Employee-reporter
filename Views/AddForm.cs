using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ICS_Employee_reporter.DAL;
using ICS_Employee_reporter.Models;

namespace ICS_Employee_reporter
{
    public partial class AddForm : Form
    {
        private MainForm _parentForm;
        private EmployeeRepository _repository;

        private bool firstNameIsValid;
        private bool lastNameIsValid;
        private bool positionIsValid;
        private bool dateOfBirthIsValid;
        private bool salaryIsValid;

        private const string LETTERS = @"^[A-Za-z\u0400-\u04FF]*$";

        public AddForm(MainForm parentForm, EmployeeRepository repository)
        {
            firstNameIsValid = false;
            lastNameIsValid = false;
            positionIsValid = false;
            dateOfBirthIsValid = false;
            salaryIsValid = false;

            _repository = repository;
            _parentForm = parentForm;
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!firstNameIsValid || !lastNameIsValid || !positionIsValid || !dateOfBirthIsValid || !salaryIsValid)
            {
                MessageBox.Show("Правильно заполните все поля");
                return;
            }
            var employee = new Employee
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Position = PositionTextBox.Text,
                DateOfBirth = Convert.ToDateTime(DateOfBirthTextBox.Text),
                Salary = Convert.ToDecimal(SalaryTextBox.Text.Replace(".",","))
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

        private void FirstNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateText(e, FirstNameTextBox, "Имя", LETTERS, out firstNameIsValid);
        }

        private void LastNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateText(e, LastNameTextBox, "Фамилия", LETTERS, out lastNameIsValid);
        }

        private void PositionTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateText(e, PositionTextBox, "Должность", LETTERS, out positionIsValid);
        }

        private void DateOfBirthTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DateTime.TryParse(DateOfBirthTextBox.Text, out var time))
            {
                dateOfBirthIsValid = false;
                e.Cancel = true;
                DateOfBirthTextBox.Focus();
                errorProvider.SetError(DateOfBirthTextBox, $"Неверная дата рождения");
            }
            else
            {
                if (DateTime.Now.Year - time.Year > 150 || time.Year > DateTime.Now.Year)
                {
                    dateOfBirthIsValid = false;
                    e.Cancel = true;
                    DateOfBirthTextBox.Focus();
                    errorProvider.SetError(DateOfBirthTextBox, $"Неверная дата рождения");
                }
                else
                {
                    dateOfBirthIsValid = true;
                    e.Cancel = false;
                    errorProvider.SetError(DateOfBirthTextBox, "");
                }
            }
        }

        private void SalaryTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateText(e, SalaryTextBox, "Зарплата", @"\d{0,2}(\.\d{1,2})?", out salaryIsValid);
        }

        private void ValidateText(CancelEventArgs e, TextBox textBox, string fieldName, string regExPattern, out bool isValid)
        {
            if (!Regex.IsMatch(textBox.Text, regExPattern))
            {
                isValid = false;
                textBox.Focus();
                errorProvider.SetError(textBox, $"Неверные символы в поле {fieldName}");
            }
            else
            {
                isValid = true;
                errorProvider.SetError(textBox, "");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}