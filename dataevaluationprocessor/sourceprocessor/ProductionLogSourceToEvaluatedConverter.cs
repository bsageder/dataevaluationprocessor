using dataevaluationprocessor.data.models;
using dataevaluationprocessor.interfaces;
using System.Linq;

namespace dataevaluationprocessor.sourceprocessor
{
    public class ProductionLogSourceToEvaluatedConverter : IDataSourceObjectProcessor
    {
        public IEvaluatedObject Process(IDataSourceObject dataSourceObject)
        {
            ProductionLogDataSource sourceObject = dataSourceObject as ProductionLogDataSource;

            ProductionLogEvaluated evaluatedObject = new ProductionLogEvaluated
            {
                Designation = sourceObject.Designation
            };
            evaluatedObject.MomentValueObjects = sourceObject.MomentValueObjects.Select(x => CreateEvaluated(x)).ToList();

            return evaluatedObject;
        }

        private ProductionLogEvaluatedMomentValues CreateEvaluated(ProductionLogDataSourceMomentValues sourceValues)
        {
            return new ProductionLogEvaluatedMomentValues
            {
                LogTime = sourceValues.LogTime,
                ControlPressure = sourceValues.ControlPressure,
                ActualPressure = sourceValues.ActualPressure,
                ControlTemperature = sourceValues.ControlTemperature,
                ActualTemperature = sourceValues.ActualTemperature,
                Count = sourceValues.Count
            };
        }
    }
}
