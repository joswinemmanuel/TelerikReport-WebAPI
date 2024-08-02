using TelerikReportWebAPI.ReportFramework;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
//using Telerik.Reporting.Processing;

namespace TelerikReportWebAPI.Reports
{
    public class CountryReport : BaseReport
    {
        public CountryReport()
        {
            InitializeComponent();
        }
        protected override void SetupDataSource()
        {
            dataSource = new SqlDataSource();
            dataSource.ConnectionString = "Data Source=LAP-1743\\SQLEXPRESS01;Initial Catalog=countrydb;Integrated Security=T" +
    "rue";
            dataSource.SelectCommand = "dbo.GetAllCountry"; // Adjust as needed
            dataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            // Add parameters as needed
        }

        protected override void SetupDetailSection()
        {
            detailSection = new DetailSection();
            Table countryTable = CreateTable(dataSource,
                "CountryId", "CountryName", "Population", "Area");
            detailSection.Items.Add(countryTable);
            this.Items.Add(detailSection);
        }

        protected override void InitializeComponent()
        {
            // Initialize report components and layout
            var sqlDataSource = new SqlDataSource
            {
                ConnectionString = "YourConnectionString",
                SelectCommand = "SELECT CountryId, CountryName, Population, Area FROM Countries"
            };

            var table = new Table
            {
                DataSource = sqlDataSource
            };

            // Add columns and rows configuration
            table.Body.Columns.Add(new TableBodyColumn(Unit.Cm(3)));
            table.Body.Rows.Add(new TableBodyRow(Unit.Cm(1)));
            table.Body.SetCellContent(0, 0, new TextBox { Value = "= Fields.CountryId" });
            table.Body.SetCellContent(0, 1, new TextBox { Value = "= Fields.CountryName" });
            table.Body.SetCellContent(0, 2, new TextBox { Value = "= Fields.Population" });
            table.Body.SetCellContent(0, 3, new TextBox { Value = "= Fields.Area" });

            this.Items.Add(table);
        }
    }
}