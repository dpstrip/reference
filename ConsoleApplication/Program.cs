using System;
using Ninject;
using UMV.Reference.ClassLibrary.Interfaces;
using UMV.Reference.ClassLibrary.Ninject;

namespace UMV.Reference.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ClassLibraryModule());

            var trainer = kernel.Get<ITrainer>("DogTrainer");
            MakePetSpeak(trainer);

            trainer = kernel.Get<ICatTrainer>();
            MakePetSpeak(trainer);

            trainer = kernel.Get<IDogTrainer>();
            MakePetSpeak(trainer);

            Console.ReadLine();
        }

        private static void MakePetSpeak(ITrainer trainer)
        {
            var animalSound = trainer.MarkPetSpeak();

            Console.WriteLine(animalSound);
        }
    }
}
