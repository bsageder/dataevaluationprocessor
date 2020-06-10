using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dataevaluationprocessor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView.DataSource = LoadFileAndCreateTable(openFileDialog.FileName);
            }
        }

        private DataTable LoadFileAndCreateTable(string fileName)
        {
            var csvLines = File.ReadAllLines(fileName, Encoding.Default);
            var splittedLines = csvLines
                .Select(x => x.Split(';'))
                .ToList();
            return CreateDataTable(splittedLines);
        }

        private DataTable CreateDataTable(List<string[]> splittedCsvLines)
        {
            DataTable table = new DataTable();
            // Create columns
            foreach (string columnName in splittedCsvLines[0])
            {
                table.Columns.Add(columnName, typeof(string));
            }
            // Create rows
            foreach (var splittedCsvLine in splittedCsvLines.Skip(1))
            {
                table.Rows.Add(splittedCsvLine);
            }
            return table;
        }
    }
}
