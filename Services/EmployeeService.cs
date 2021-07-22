using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_Employee_reporter.Services
{
    class EmployeeService
    {
        private DataTable _dataTable;
        private SqlDataAdapter _adapter;
        private SqlCommandBuilder _commandBuilder;
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        private const string SELECT = "SELECT * FROM Employees";
    }
}
