namespace UMV.Reference.Patterns.Operations
{
    public interface IOperation<T>
    {
        void Register(IOperation<T> operation);

        T Execute(T context);

    }
}