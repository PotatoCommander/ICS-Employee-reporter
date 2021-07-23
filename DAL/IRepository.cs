using System.Collections.Generic;
using ICS_Employee_reporter.Models;

namespace ICS_Employee_reporter.DAL
{
    internal interface IRepository
    {
        List<Employee> GetAll();
        bool DeleteById(string id);
        bool AddEmployee(Employee employee);
        bool Query(string query);
    }
}