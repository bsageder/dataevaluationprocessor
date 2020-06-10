using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dataevaluationprocessor
{
    public class CsvProductionLogFileParser
    {
        private string _csvFileName;

        public CsvProductionLogFileParser(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public List<string[]> Parse()
        {
            var csvLines = File.ReadAllLines(_csvFileName, Encoding.Default);
            var splittedLines = csvLines
                .Select(x => x.Split(';'))
                .ToList();
            return splittedLines;
        }
    }
}
