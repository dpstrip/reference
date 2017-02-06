using System;
using System.Collections.Generic;
using System.Linq;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.Patterns
{

    public class PipelineBuilder<T>
    {
        private readonly List<Func<IOperation<T>>> _filters = new List<Func<IOperation<T>>>();

        public PipelineBuilder<T> Register(Func<IOperation<T>> filter)
        {
            _filters.Add(filter);
            return this;
        }

        public PipelineBuilder<T> Register(IOperation<T> operation)
        {
            _filters.Add(() => operation);
            return this;
        }

        public IOperation<T> Build()
        {
            var root = _filters.First().Invoke();

            foreach (var filter in _filters.Skip(1))
            {
                root.Register(filter.Invoke());
            }

            return root;
        }
    }
}