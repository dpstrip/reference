using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class InitializeChangeTracking : IOperation<IChangeTrackable>
    {
        public IChangeTrackable Execute(IChangeTrackable changeTrackable)
        {
            changeTrackable.InitializeChangeState();

            return changeTrackable;
        }
    }
}