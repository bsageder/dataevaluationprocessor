using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dataevaluationprocessor
{
    public class CsvProductionLogFileParser
    {
        public List<string[]> Parse(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName, Encoding.Default);
            var splittedLines = csvLines
                .Select(x => x.Split(';'))
                .ToList();
            return splittedLines;
        }
    }
}
