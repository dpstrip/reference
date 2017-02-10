using System.Collections.Generic;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.Patterns
{
    public class Pipeline<T> where T : IChangeTracker
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

                // If the executed operation set the Stop to true
                // Exit out of executin the rest of the operations
                if (operation.Stop)
                    return context;
            }
            return context;
        }
    }
}
