using System;
using System.Collections.Generic;
using System.Linq;

namespace dataevaluationprocessor
{
    public class CsvProductionLogSortByActualPressureProcessor
    {
        public List<string[]> Process(List<string[]> csvLines)
        {
            int actualPressureColumn = csvLines[0].ToList().IndexOf("Istdruck");
            var headerLine = csvLines[0];
            csvLines.RemoveAt(0);
            csvLines.Sort((csvLine1, csvLine2) => Convert.ToDouble(csvLine1[actualPressureColumn]).CompareTo(Convert.ToDouble(csvLine2[actualPressureColumn])));
            csvLines.Insert(0, headerLine);
            return csvLines;
        }
    }
}
