using dataevaluationprocessor.interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace dataevaluationprocessor.evaluatedprocessor
{
    public class FilePerformanceRecorder : BaseProcessorWithFollowUp, IEvaluatedObjectProcessor
    {
        private string _fileName;

        public FilePerformanceRecorder(string fileName, IEvaluatedObjectProcessor followUpProcessor) : base(followUpProcessor)
        {
            _fileName = fileName;
        }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            Stopwatch sw = Stopwatch.StartNew();

            _followUpProcessor.Process(evaluatedObject);

            var elapsed = sw.Elapsed;
            File.AppendAllText(_fileName, $"{DateTime.Now} {elapsed.TotalMilliseconds} ms{Environment.NewLine}");
        }
    }
}
