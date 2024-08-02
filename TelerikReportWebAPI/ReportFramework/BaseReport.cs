using System;
using System.Collections.Generic;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace TelerikReportWebAPI.ReportFramework
{
    public abstract class BaseReport : Telerik.Reporting.Report
    {
        protected SqlDataSource dataSource;
        protected DetailSection detailSection;
        protected PageHeaderSection pageHeaderSection;
        protected PageFooterSection pageFooterSection;

        public BaseReport()
        {
            InitializeComponent();
            this.Items.Clear();
            SetupDataSource();
            SetupPageHeader();
            SetupDetailSection();
            SetupPageFooter();
            ApplyStyles();
        }

        protected abstract void SetupDataSource();
        protected abstract void SetupDetailSection();

        protected abstract void InitializeComponent();

        protected virtual void SetupPageHeader()
        {
            pageHeaderSection = new PageHeaderSection();
            TextBox reportTitle = new TextBox
            {
                Name = "ReportTitleTextBox",
                Value = GetType().Name,
                Style = { Font = { Bold = true, Size = Unit.Point(14) } }
            };
            pageHeaderSection.Items.Add(reportTitle);
            this.Items.Add(pageHeaderSection);
        }

        protected virtual void SetupPageFooter()
        {
            pageFooterSection = new PageFooterSection();
            TextBox pageNumber = new TextBox
            {
                Name = "PageNumberTextBox",
                Value = "Page: {PageNumber}",
                Location = new PointU(Unit.Inch(5), Unit.Inch(0.5))
            };
            pageFooterSection.Items.Add(pageNumber);
            this.Items.Add(pageFooterSection);
        }

        protected virtual void ApplyStyles()
        {
            StyleRule styleRule = new StyleRule();
            styleRule.Selectors.AddRange(new ISelector[] {
                new TypeSelector(typeof(TextItemBase)),
                new TypeSelector(typeof(HtmlTextBox))
            });
            styleRule.Style.Padding.Left = Unit.Point(2);
            styleRule.Style.Padding.Right = Unit.Point(2);
            this.StyleSheet.AddRange(new StyleRule[] { styleRule });
        }

        protected Table CreateTable(SqlDataSource dataSource, params string[] columnNames)
        {
            Table table = new Table();
            table.DataSource = dataSource;

            foreach (var columnName in columnNames)
            {
                TableBodyColumn column = new TableBodyColumn(Unit.Inch(1));
                table.Body.Columns.Add(column);

                TextBox headerCell = new TextBox { Value = columnName };
                table.ColumnGroups[0].ReportItem = headerCell;

                TextBox bodyCell = new TextBox { Value = $"= Fields.{columnName}" };
                table.Body.SetCellContent(0, table.Body.Columns.Count - 1, bodyCell);
            }

            return table;
        }
    }
}