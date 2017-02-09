using UMV.Reference.Patterns.Base.Models;

namespace UMV.Reference.Patterns.Base.Interfaces
{
    public interface IChangeTrackable : IAuditible
    {
        ChangeState GetChangeState();

        void InitializeChangeState();

    }
}