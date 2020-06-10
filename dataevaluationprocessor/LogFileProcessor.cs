using System.Data;

namespace dataevaluationprocessor
{
    public class LogFileProcessor
    {
        private CsvProductionLogFileParser _parser;
        private CsvProductionLogSortByActualPressureProcessor _sortProcessor;
        private CreateDataTableProcessor _createTableProcessor;

        public LogFileProcessor(CsvProductionLogFileParser parser,
            CsvProductionLogSortByActualPressureProcessor sortProcessor,
            CreateDataTableProcessor createTableProcessor)
        {
            _parser = parser;
            _sortProcessor = sortProcessor;
            _createTableProcessor = createTableProcessor;
        }
        public DataTable RunProcess()
        {
            var splittedLines = _parser.Parse();
            var evalueatedLines = _sortProcessor.Process(splittedLines);
            return _createTableProcessor.Process(evalueatedLines);
        }
    }
}
