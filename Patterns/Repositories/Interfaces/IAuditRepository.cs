using UMV.Reference.Patterns.Base.Models;

namespace UMV.Reference.Patterns.Repositories.Interfaces
{
    public interface IAuditRepository
    {
        void Save(ChangeState changeState);
    }
}