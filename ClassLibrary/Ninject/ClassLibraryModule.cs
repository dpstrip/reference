using ClassLibrary.Base;
using ClassLibrary.Concrete;
using ClassLibrary.Interfaces;
using Ninject.Modules;

namespace ClassLibrary
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