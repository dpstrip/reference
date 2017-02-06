using System.Collections.Generic;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.Patterns
{
    public class Pipeline<T>
    {
        private readonly List<IOperation<T>> _operations = new List<IOperation<T>>();

        public Pipeline<T> Register(IOperation<T> operation)
        {
            _operations.Add(operation);
            return this;
        }

        public T Execute(T context)
        {
            foreach (var operation in _operations)
            {
                context = operation.Execute(context);
            }
            return context;
        }
    }
}
