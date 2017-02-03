using System.Threading.Tasks;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.Patterns
{

    public class Pipeline<T>
    {
        private IOperation<T> _root;

        public Pipeline<T> Register(IOperation<T> operation)
        {
            if (_root == null)
            {
                _root = operation;
            }
            else
            {
                _root.Register(operation);
            }

            return this;
        }

        public Task Execute(T context)
        {
            return _root.Execute(context);
        }
    }
}
