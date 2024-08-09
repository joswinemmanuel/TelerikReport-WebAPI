using System.Collections.Generic;
using System.Data;
using System;
using TelerikReportWebAPI.Reports;

namespace TelerikReportWebAPI.Reports
{
    public partial class test : BaseReport, IBaseReport
    {
        public test()
        {
            InitializeComponent();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=carestackdb;Integrated Security=True";
            string query = "SELECT FirstName, LastName, Age, Country, Gender, Address, PhoneNumber, Email, DateOfBirth, MedicalHistory FROM Patients;";
            InitializeReport(connectionString, query);
        }

        public override void AddAdditionalColumns(System.Data.DataTable dataTable)
        {
            var random = new Random();
            var columnsToAdd = new List<(string Name, Type Type, Func<DataRow, int, object> ValueGenerator)>
            {
                ("Password", typeof(string), (DataRow row, int index) => GenerateRandomString(8, random)),
                ("Gratitude", typeof(string), (DataRow row, int index) => $"Thank God {index + 1}"),
                ("Number", typeof(int), (DataRow row, int index) => random.Next(1, 101)),
                ("Person", typeof(string), (DataRow row, int index) => $"Person {index + 1}"),
                ("Dummy", typeof(int), (DataRow row, int index) => random.Next(1, 1001)+12),
            };

            AddColumnsToDataTable(dataTable, columnsToAdd);
        }

    }
}