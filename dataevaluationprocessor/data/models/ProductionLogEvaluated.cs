using dataevaluationprocessor.interfaces;
using System.Collections.Generic;

namespace dataevaluationprocessor.data.models
{
    public class ProductionLogEvaluated : IEvaluatedObject
    {
        public string Designation { get; set; }
        public List<ProductionLogEvaluatedMomentValues> MomentValueObjects { get; set; }

        public ProductionLogEvaluated()
        {
            MomentValueObjects = new List<ProductionLogEvaluatedMomentValues>();
        }
    }
}
