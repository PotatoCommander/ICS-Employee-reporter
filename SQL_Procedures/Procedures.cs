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

        public const string AverageSalaryProcedureCreation =
            "CREATE OR ALTER PROCEDURE AverageSalary AS SELECT Position, AVG(salary) as [Average]\r\nFROM Employees\r\nGROUP BY Position;";

        public const string CreateEmployeeTable =
            "if object_id('Employees','U') is null\r\nBEGIN\r\nCREATE TABLE [Employees](\r\n\t[Id] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),\r\n\t[FirstName] [nvarchar](50) NULL,\r\n\t[LastName] [nvarchar](50) NULL,\r\n\t[Position] [nvarchar](50) NULL,\r\n\t[DateOfBirth] [date] NULL,\r\n\t[Salary] [decimal](18, 2) NULL,\r\n CONSTRAINT [PK_Employees_1] PRIMARY KEY CLUSTERED \r\n(\r\n\t[Id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nEND\r\nGO";
    }

}
