using System.Threading.Tasks;

namespace UMV.Reference.Patterns.Operations
{
    public interface IOperation<T>
    {
        void Register(IOperation<T> operation);

        Task Execute(T context);
    }
}