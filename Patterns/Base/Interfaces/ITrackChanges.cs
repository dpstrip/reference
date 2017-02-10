using UMV.Reference.Patterns.Base.Models;

namespace UMV.Reference.Patterns.Base.Interfaces
{
    public interface ITrackChanges : IAuditible
    {
        ChangeState GetChangeState();

        void InitializeChangeState();

    }
}