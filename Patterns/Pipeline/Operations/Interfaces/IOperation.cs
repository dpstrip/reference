namespace UMV.Reference.Patterns.Operations.Interfaces
{
    public interface IOperation<T>
    {
        T Execute(T context);
    }
}