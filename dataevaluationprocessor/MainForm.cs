using dataevaluationprocessor.evaluatedprocessor;
using dataevaluationprocessor.sourcegetter;
using dataevaluationprocessor.sourceprocessor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace dataevaluationprocessor
{
    public partial class MainForm : Form
    {
        private List<DataTable> _tables;

        public MainForm()
        {
            InitializeComponent();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _tables = new List<DataTable>();

                var processor = new LogFilesProcessor(
                    sourceObjectsGetter: new CsvProductionLogFilesParser(openFileDialog.FileNames),
                    sourceObjectProcessor: new SortProductionLogByActualPressureProcessor(),
                    evaluatedObjectProcessor: new CreateDataTableProcessor(resultList: _tables));

                processor.RunProcess();

                tabControl.TabPages.Clear();
                foreach (DataTable table in _tables)
                {
                    tabControl.TabPages.Add(table.TableName);
                }
                tabControl.Visible = (_tables.Count > 0);
                SelectTableInView(0);
            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex > -1)
            {
                SelectTableInView(tabControl.SelectedIndex);
            }
        }

        private void SelectTableInView(int index)
        {
            if (_tables.Count > index)
            {
                dataGridView.DataSource = _tables[index];
            }
        }
    }
}
