using dataevaluationprocessor.data.models;
using dataevaluationprocessor.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dataevaluationprocessor.sourcegetter
{
    public class CsvProductionLogFileParser : IDataSourceObjectsGetter
    {
        private string _csvFileName;

        public CsvProductionLogFileParser(string csvFileName)
        {
            _csvFileName = csvFileName;
        }
        public IDataSourceObject[] GetSourceObjects()
        {
            ProductionLogDataSource sourceObject = new ProductionLogDataSource();
            sourceObject.Designation = Path.GetFileNameWithoutExtension(_csvFileName);

            var csvLines = File.ReadAllLines(_csvFileName, Encoding.Default);
            sourceObject.MomentValueObjects = ParseLines(csvLines);

            return new ProductionLogDataSource[] { sourceObject };
        }
        public List<ProductionLogDataSourceMomentValues> ParseLines(string[] csvLines)
        {
            return csvLines
                .Skip(1)
                .Select(x => ParseLine(x))
                .ToList();
        }
        private ProductionLogDataSourceMomentValues ParseLine(string csvLine)
        {
            int valueIndex = 0;
            string[] csvValues = csvLine.Split(';');

            ProductionLogDataSourceMomentValues dataItem = new ProductionLogDataSourceMomentValues();

            dataItem.LogTime = Convert.ToDateTime(csvValues[valueIndex++]);
            dataItem.ControlPressure = Convert.ToDouble(csvValues[valueIndex++]);
            dataItem.ActualPressure = Convert.ToDouble(csvValues[valueIndex++]);
            dataItem.ControlTemperature = Convert.ToDouble(csvValues[valueIndex++]);
            dataItem.ActualTemperature = Convert.ToDouble(csvValues[valueIndex++]);
            dataItem.Count = Convert.ToInt32(csvValues[valueIndex++]);

            return dataItem;
    }
}
}
