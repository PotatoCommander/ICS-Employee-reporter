using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_Employee_reporter.SQL_Procedures
{
    public static class Procedures
    {
        public const string InsertProcedureCreation =
            "CREATE OR ALTER PROCEDURE InsertEmployee\r\n    @FirstName nvarchar(50),\r\n   @LastName nvarchar(50),    @Position nvarchar(50),\r\n    @DateOfBirth date,\r\n   @Salary decimal(18,2)\r\nAS\r\nINSERT\r\nINTO\r\n    Employees\r\n(FirstName, LastName, Position, DateOfBirth, Salary)\r\nVALUES\r\n(@FirstName, @LastName, @Position, @DateOfBirth, @Salary)";

        public const string DeleteProcedureCreation =
            "CREATE OR ALTER PROCEDURE DeleteEmployee\r\n    @Id uniqueidentifier\r\nAS\r\nDELETE\r\nFROM\r\n    Employees\r\nWHERE\r\n        Id = @Id\r\n";

        public const string SelectAllProcedureCreation =
            "CREATE OR ALTER PROCEDURE SelectAllEmployees \r\nAS\r\nSELECT * FROM Employees\r\n";
    }

}
