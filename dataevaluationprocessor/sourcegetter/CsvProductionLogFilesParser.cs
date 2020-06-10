using dataevaluationprocessor.data.models;
using dataevaluationprocessor.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dataevaluationprocessor.sourcegetter
{
    public class CsvProductionLogFilesParser : IDataSourceObjectsGetter
    {
        private string[] _csvFileNames;

        public CsvProductionLogFilesParser(string[] csvFileNames)
        {
            _csvFileNames = csvFileNames;
        }
        public IDataSourceObject[] GetSourceObjects()
        {
            List<ProductionLogDataSource> sourceObjects = new List<ProductionLogDataSource>();
            foreach (string csvFileName in _csvFileNames)
            {
                sourceObjects.Add(CreateSourceObject(csvFileName));
            }
            return sourceObjects.ToArray();
        }

        public ProductionLogDataSource CreateSourceObject(string csvFileName)
        {
            ProductionLogDataSource sourceObject = new ProductionLogDataSource();
            sourceObject.Designation = Path.GetFileNameWithoutExtension(csvFileName);

            var csvLines = File.ReadAllLines(csvFileName, Encoding.Default);
            sourceObject.MomentValueObjects = ParseLines(csvLines);

            return sourceObject;
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
