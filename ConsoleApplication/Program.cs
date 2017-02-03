using System;
using Ninject;
using UMV.Reference.ClassLibrary.Interfaces;
using UMV.Reference.ClassLibrary.Ninject;
using UMV.Reference.Patterns;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PipelineBuilderExample();

            Console.ReadLine();
        }

        private static void PipelineExample()
        {
            var context = new HttpContext();

            new Pipeline<HttpContext>()
            .Register(new TimingOperation())
            .Register(new LoggingOperation())
            .Register(new ResponseOperation())
            .Execute(context)
            .Wait();
        }

        private static void PipelineBuilderExample()
        {
            var context = new HttpContext();

            var pipeline = new PipelineBuilder<HttpContext>()
            .Register(new TimingOperation())
            .Register(new LoggingOperation())
            .Register(new ResponseOperation())
            .Build();

            pipeline.Execute(context).Wait();
        }

        private static void IoCExample()
        {
            var kernel = new StandardKernel(new ClassLibraryModule());

            var trainer = kernel.Get<ITrainer>("DogTrainer");
            MakePetSpeak(trainer);

            trainer = kernel.Get<ICatTrainer>();
            MakePetSpeak(trainer);

            trainer = kernel.Get<IDogTrainer>();
            MakePetSpeak(trainer);
        }

        private static void MakePetSpeak(ITrainer trainer)
        {
            var animalSound = trainer.MakePetSpeak();

            Console.WriteLine(animalSound);
        }
    }
}
