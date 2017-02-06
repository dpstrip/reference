using Ninject.Modules;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations;


namespace UMV.Reference.ClassLibrary.Ninject
{
    public class ClassLibraryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOperation<Member>>().To<AddMemberNameOperation>();

        }
    }
}