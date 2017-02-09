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

            Bind<IOperation<IChangeTrackable>>().To<TrackChanges>().Named("TrackChanges");
            Bind<IOperation<IAuditible>>().To<AddAuditInformation>().Named("AddAuditInformation");
            Bind<IOperation<Member>>().To<UpdateMemberNameToCraigOperation>().Named("UpdateMemberNameToCraigOperation");
            Bind<IOperation<IChangeTrackable>>().To<InitializeChangeTracking>().Named("InitializeChangeTracking");

        }
    }
}