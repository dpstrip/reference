using Ninject.Modules;
using UMV.Reference.ClassLibrary.Concrete;
using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.ClassLibrary.Ninject
{
    public class ClassLibraryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDog>().To<Dog>();
            Bind<ICat>().To<Cat>();

            Bind<ITrainer>().To<CatTrainer>().Named("CatTrainer");
            Bind<ITrainer>().To<DogTrainer>().Named("DogTrainer");

            Bind<ICatTrainer>().To<CatTrainer>();
            Bind<IDogTrainer>().To<DogTrainer>();

        }
    }
}