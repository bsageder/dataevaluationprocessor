using dataevaluationprocessor.data.models;
using dataevaluationprocessor.interfaces;
using System.Data;

namespace dataevaluationprocessor.evaluatedprocessor
{
    public class CreateDataTableProcessor : IEvaluatedObjectProcessor
    {
        public DataTable Result { get; private set; }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            ProductionLogEvaluated evaluatedLogObject = evaluatedObject as ProductionLogEvaluated;

            DataTable table = new DataTable();
            CreateColumns(table);
            CreateRows(table, evaluatedLogObject);
            Result = table;
        }

        private void CreateColumns(DataTable table)
        {
            table.Columns.Add("LogTime", typeof(string));
            table.Columns.Add("ControlPressure", typeof(double));
            table.Columns.Add("ActualPressure", typeof(double));
            table.Columns.Add("ControlTemperature", typeof(double));
            table.Columns.Add("ActualTemperature", typeof(double));
            table.Columns.Add("Count", typeof(int));
        }
        private void CreateRows(DataTable table, ProductionLogEvaluated evaluatedLogObject)
        {
            foreach (ProductionLogEvaluatedMomentValues momentValues in evaluatedLogObject.MomentValueObjects)
            {
                table.Rows.Add(
                    momentValues.LogTime,
                    momentValues.ControlPressure,
                    momentValues.ActualPressure,
                    momentValues.ControlTemperature,
                    momentValues.ActualTemperature,
                    momentValues.Count);
            }
        }
    }
}
