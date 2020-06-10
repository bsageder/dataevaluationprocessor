using dataevaluationprocessor.evaluatedprocessor;
using dataevaluationprocessor.sourcegetter;
using dataevaluationprocessor.sourceprocessor;
using System;
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
                var dataTableProcessor = new CreateDataTableProcessor();

                var processor = new LogFileProcessor(
                    sourceObjectsGetter: new CsvProductionLogFileParser(openFileDialog.FileName),
                    sourceObjectProcessor: new SortProductionLogByActualPressureProcessor(),
                    evaluatedObjectProcessor: dataTableProcessor);

                processor.RunProcess();
                dataGridView.DataSource = dataTableProcessor.Result;
            }
        }
    }
}
