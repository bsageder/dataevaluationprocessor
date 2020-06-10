using dataevaluationprocessor.interfaces;
using System.Collections.Generic;

namespace dataevaluationprocessor
{
    public class LogFilesProcessor
    {
        private IDataSourceObjectsGetter _sourceObjectsGetter;
        private IDataSourceObjectProcessor _sourceObjectProcessor;
        private IEvaluatedObjectProcessor _evaluatedObjectProcessor;

        public LogFilesProcessor(IDataSourceObjectsGetter sourceObjectsGetter,
            IDataSourceObjectProcessor sourceObjectProcessor,
            IEvaluatedObjectProcessor evaluatedObjectProcessor)
        {
            _sourceObjectsGetter = sourceObjectsGetter;
            _sourceObjectProcessor = sourceObjectProcessor;
            _evaluatedObjectProcessor = evaluatedObjectProcessor;
        }
        public void RunProcess()
        {
            List<object> results = new List<object>();
            foreach (IDataSourceObject sourceObject in _sourceObjectsGetter.GetSourceObjects())
            {
                var evaluatedObject = _sourceObjectProcessor.Process(sourceObject);
                _evaluatedObjectProcessor.Process(evaluatedObject);
            }
        }
    }
}
