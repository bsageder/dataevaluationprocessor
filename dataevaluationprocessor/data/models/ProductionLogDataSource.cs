using dataevaluationprocessor.interfaces;
using System.Collections.Generic;

namespace dataevaluationprocessor.data.models
{
    public class ProductionLogDataSource : IDataSourceObject
    {
        public string Designation { get; set; }
        public List<ProductionLogDataSourceMomentValues> MomentValueObjects { get; set; }

        public ProductionLogDataSource()
        {
            MomentValueObjects = new List<ProductionLogDataSourceMomentValues>();
        }
    }
}
