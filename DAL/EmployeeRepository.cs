using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ICS_Employee_reporter.Models;

namespace ICS_Employee_reporter.DAL
{
    public class EmployeeRepository : IRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("SelectAllEmployees", connection)
                        {CommandType = CommandType.StoredProcedure})
                    {
                        var dataAdapter = new SqlDataAdapter(cmd);
                        var dataTable = new DataTable();

                        connection.Open();
                        dataAdapter.Fill(dataTable);
                        connection.Close();

                        return dataTable.AsEnumerable().Select(x => new Employee(x)).ToList();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteEmployee", connection)
                    {CommandType = CommandType.StoredProcedure})
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    var affectedRows = cmd.ExecuteNonQuery();
                    connection.Close();
                    return affectedRows >= 1;
                }
            }
        }

        public bool AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("InsertEmployee", connection)
                    {CommandType = CommandType.StoredProcedure})
                {
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Position", employee.Position);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                    connection.Open();
                    var affectedRows = cmd.ExecuteNonQuery();
                    connection.Close();
                    return affectedRows >= 1;
                }
            }
        }

        public bool Query(string query)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                return true;
            }
            finally
            {
               
            }

            return false;
        }

        private Employee DataRowToEmployee(DataRow data)
        {
            return new Employee(data);
        }
    }
}
