namespace dataevaluationprocessor.interfaces
{
    public interface IDataSourceObjectProcessor
    {
        IEvaluatedObject Process(IDataSourceObject dataSourceObject);
    }
}
