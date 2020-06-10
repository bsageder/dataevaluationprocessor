using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dataevaluationprocessor
{
    public class CreateDataTableProcessor
    {
        public DataTable Process(List<string[]> evaluatedCsvLines)
        {
            DataTable table = new DataTable();
            // Create columns
            foreach (string columnName in evaluatedCsvLines[0])
            {
                table.Columns.Add(columnName, typeof(string));
            }
            // Create rows
            foreach (var splittedCsvLine in evaluatedCsvLines.Skip(1))
            {
                table.Rows.Add(splittedCsvLine);
            }
            return table;
        }
    }
}
