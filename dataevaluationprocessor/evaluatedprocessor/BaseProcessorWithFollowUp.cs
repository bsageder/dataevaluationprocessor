using dataevaluationprocessor.interfaces;

namespace dataevaluationprocessor.evaluatedprocessor
{
    public class BaseProcessorWithFollowUp 
    {
        protected IEvaluatedObjectProcessor _followUpProcessor;

        protected BaseProcessorWithFollowUp(IEvaluatedObjectProcessor followUpProcessor = null)
        {
            _followUpProcessor = followUpProcessor;
        }
    }
}
