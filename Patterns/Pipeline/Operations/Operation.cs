using System;
using System.Threading.Tasks;

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

        Task IOperation<T>.Execute(T context)
        {
            return Execute(context, ctx => _next == null
                ? Task.CompletedTask
                : _next.Execute(ctx));
        }

        protected abstract Task Execute(T context, Func<T, Task> next);
    }
}