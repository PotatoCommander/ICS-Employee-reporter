using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ICS_Employee_reporter.DAL;
using ICS_Employee_reporter.Models;
using ICS_Employee_reporter.Services;

namespace ICS_Employee_reporter
{
    public partial class Main : Form
    {
        private ICollection<Employee> _employees;
        private EmployeeService _employeeService;

        public Main()
        {
            _employeeService = new EmployeeService();
            var a = new EmployeeRepository(
                "Data Source=POTATOSLENOVO\\SQLEXPRESS;Initial Catalog=Employees-DB;Integrated Security=True");
            //a.DeleteById(1);
            a.AddItem(new Employee
            {
                DateOfBirth = DateTime.Today, FirstName = "Nikita", LastName = "Bodry", Position = "Junior",
                Salary = 500
            });
            a.AddItem(new Employee
            {
                DateOfBirth = DateTime.Today,
                FirstName = "Nikita",
                LastName = "Bodry",
                Position = "Junior",
                Salary = 500
            });
            a.AddItem(new Employee
            {
                DateOfBirth = DateTime.Today,
                FirstName = "Nikita",
                LastName = "Bodry",
                Position = "Junior",
                Salary = 500
            });
            a.AddItem(new Employee
            {
                DateOfBirth = DateTime.Today,
                FirstName = "Nikita",
                LastName = "Bodry",
                Position = "Junior",
                Salary = 500
            });
            a.SaveChanges();
            InitializeComponent();
        }

        private void AddButton_click(object sender, EventArgs e)
        {
        }

        private void DeleteButton_click(object sender, EventArgs e)
        {
        }

        private void ReportButton_click(object sender, EventArgs e)
        {
        }
    }
}