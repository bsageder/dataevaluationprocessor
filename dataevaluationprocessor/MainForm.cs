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
                dataGridView.DataSource = new LogFileProcessor().RunProcess(openFileDialog.FileName);
            }
        }
    }
}
