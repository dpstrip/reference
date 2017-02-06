using Ninject.Modules;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.Patterns.Ninject
{
    public class PatternsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOperation<Member>>().To<AddMemberNameOperation>();

        }
    }
}