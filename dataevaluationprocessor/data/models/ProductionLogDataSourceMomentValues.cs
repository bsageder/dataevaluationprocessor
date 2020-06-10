using System;

namespace dataevaluationprocessor.data.models
{
    public class ProductionLogDataSourceMomentValues
    {
        public DateTime LogTime { get; set; }
        public double ControlPressure { get; set; }
        public double ActualPressure { get; set; }
        public double ControlTemperature { get; set; }
        public double ActualTemperature { get; set; }
        public int Count { get; set; }
    }
}
