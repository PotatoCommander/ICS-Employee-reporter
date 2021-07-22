using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Employee_reporter.Models;

namespace ICS_Employee_reporter.DAL
{
    class EmployeeRepository
    {
        public DataTable DataTable { set; get; }
        private string _connectionString;
        private const string SELECT = "SELECT * FROM Employees";

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(SELECT, connection);
                DataTable = new DataTable();
                
                adapter.Fill(DataTable);
                DataTable.PrimaryKey = new[] {DataTable.Columns["Id"]};
            }
        }

        public DataTable DeleteById(int id)
        { 
            DataTable.Rows.Find(id).Delete();
            return DataTable;
        }

        public DataTable AddItem(Employee employee)
        {
            var row = DataTable.NewRow();
            row["Id"] = Guid.NewGuid();
            row["FirstName"] = employee.FirstName;
            row["LastName"] = employee.LastName;
            row["Position"] = employee.Position;
            row["DateOfBirth"] = employee.DateOfBirth.ToString("yyyy-MM-dd");
            row["Salary"] = employee.Salary;
            DataTable.Rows.Add(row);
            return DataTable;
        }

        public DataTable SaveChanges()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(SELECT, connection);

                var _ = new SqlCommandBuilder(adapter);
                adapter.Update(DataTable);
            }
            

            return DataTable;
        }
    }
}
