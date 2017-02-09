using Ninject.Modules;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations;
using UMV.Reference.Patterns.Operations.Interfaces;
using UMV.Reference.Patterns.Repositories;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Ninject
{
    public class PatternsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogRepository>().To<LogRepository>();
            Bind<IAuditRepository>().To<AuditRepository>();
            Bind<IMemberRepository>().To<MemberRepository>();
            Bind<IMessageRepository>().To<MessageRepository>();

            Bind<IOperation<Member>>().To<ChangeTracker<Member>>().Named("MemberChangeTracker");
            Bind<IOperation<Member>>().To<AddAuditInformation<Member>>().Named("AddAuditInformation");
            Bind<IOperation<Member>>().To<UpdateMemberNameToCraigOperation>().Named("UpdateMemberNameToCraigOperation");
            Bind<IOperation<Member>>().To<InitializeChangeTracking<Member>>().Named("InitializeChangeTracking");

        }
    }
}