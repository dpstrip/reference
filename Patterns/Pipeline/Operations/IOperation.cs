namespace UMV.Reference.Patterns.Operations
{
    public interface IOperation<T>
    {
        T Execute(T context);
    }
}