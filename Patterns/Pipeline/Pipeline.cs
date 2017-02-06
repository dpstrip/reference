using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UMV.Reference.Patterns
{
    public class Pipeline<T>
    {
        private readonly List<Func<T,T>> _operations = new List<Func<T,T>>();

        public Pipeline<T> Register(Func<T,T> operation)
        {
            _operations.Add(operation);
            return this;
        }

        public T Execute(T context)
        {
            foreach (var operation in _operations)
            {
                context = operation.Invoke(context);
            }
            return context;
        }
    }
}
