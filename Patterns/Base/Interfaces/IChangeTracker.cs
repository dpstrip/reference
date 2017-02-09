using UMV.Reference.Patterns.Base.Models;

namespace UMV.Reference.Patterns.Base.Interfaces
{
    public interface IChangeTracker : IAuditible
    {
        ChangeState GetChangeState();

        void InitializeChangeState();

    }
}