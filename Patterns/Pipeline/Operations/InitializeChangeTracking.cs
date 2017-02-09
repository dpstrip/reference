using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class InitializeChangeTracking<T> : IOperation<T> where T : IChangeTracker
    {
        public T Execute(T changeTracker)
        {
            changeTracker.InitializeChangeState();

            return changeTracker;
        }
    }
}