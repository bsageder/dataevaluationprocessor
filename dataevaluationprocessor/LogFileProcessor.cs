using System.Data;

namespace dataevaluationprocessor
{
    public class LogFileProcessor
    {
        public DataTable RunProcess(string fileName)
        {
            var splittedLines = new CsvProductionLogFileParser().Parse(fileName);
            var evaluatedLines = new CsvProductionLogSortByActualPressureProcessor().Process(splittedLines);
            return new CreateDataTableProcessor().Process(evaluatedLines);
        }
    }
}
