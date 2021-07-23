using System;
using System.Data;

namespace ICS_Employee_reporter.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        
        public Employee()
        {
        }

        public Employee(DataRow dataRow)
        {
            Id = dataRow["Id"].ToString();
            FirstName = dataRow["FirstName"].ToString();
            LastName = dataRow["LastName"].ToString();
            Position = dataRow["Position"].ToString();
            DateOfBirth = Convert.ToDateTime(dataRow["DateOfBirth"]);
            Salary = Convert.ToDecimal(dataRow["Salary"]);
        }
    }
}