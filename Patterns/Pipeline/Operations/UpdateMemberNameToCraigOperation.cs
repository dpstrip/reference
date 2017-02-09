using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations.Interfaces;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class UpdateMemberNameToCraigOperation : IOperation<Member>
    {
        private readonly ILogRepository _logRepository;

        public UpdateMemberNameToCraigOperation(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public Member Execute(Member auditible)
        {
            _logRepository.Save("Changing First Name to \"Craig\"");

            auditible.FirstName = "Craig";

            return auditible;
        }
    }
}