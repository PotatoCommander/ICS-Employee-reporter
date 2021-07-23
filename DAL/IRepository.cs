using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Employee_reporter.Models;

namespace ICS_Employee_reporter.DAL
{
    interface IRepository
    {
        List<Employee> GetAll();
        bool DeleteById(string id);
        bool AddEmployee(Employee employee);
        bool Query(string query);
    }
}
