using dataevaluationprocessor.data.models;
using dataevaluationprocessor.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace dataevaluationprocessor.evaluatedprocessor
{
    public class RemoveActualPressureRangeProcessor : BaseProcessorWithFollowUp, IEvaluatedObjectProcessor
    {
        private double _minRange;
        private double _maxRange;
        private List<ProductionLogEvaluatedMomentValues> _removedObjects;

        public RemoveActualPressureRangeProcessor(double minRange, double maxRange,
            List<ProductionLogEvaluatedMomentValues> removedObjects = null,
            IEvaluatedObjectProcessor followUpProcessor = null) : base(followUpProcessor)
        {
            _minRange = minRange;
            _maxRange = maxRange;
            _removedObjects = removedObjects;
        }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            ProductionLogEvaluated evaluatedLogObject = evaluatedObject as ProductionLogEvaluated;

            _removedObjects?.AddRange(evaluatedLogObject.MomentValueObjects.Where(x => x.ActualPressure >= _minRange && x.ActualPressure <= _maxRange));
            evaluatedLogObject.MomentValueObjects.RemoveAll(x => x.ActualPressure >= _minRange && x.ActualPressure <= _maxRange);

            _followUpProcessor?.Process(evaluatedLogObject);
        }
    }
}
