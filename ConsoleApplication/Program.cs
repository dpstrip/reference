using System;
using ClassLibrary;
using ClassLibrary.Interfaces;
using Ninject;

namespace ConsoleApplication
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
