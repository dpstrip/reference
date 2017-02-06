using System;

namespace UMV.Reference.Patterns.Operations
{
    public abstract class Operation<T> : IOperation<T>
    {
        private IOperation<T> _next;

        public void Register(IOperation<T> operation)
        {
            if (_next == null)
            {
                _next = operation;
            }
            else
            {
                _next.Register(operation);
            }
        }

        T IOperation<T>.Execute(T context)
        {
            return Execute(context, ctx => _next == null ? default(T) : _next.Execute(ctx));
        }

        protected abstract T Execute(T context, Func<T, T> next);
    }
}