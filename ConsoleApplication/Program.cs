using System;
using System.Diagnostics.Eventing.Reader;
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
            //PipelineBuilderExample();

            PipelineExample();

            Console.ReadLine();
        }



        private static void PipelineExample()
        {
            var context = new Member();

            context = new Pipeline<Member>()
            .Register(new TimeToExecuteOperation<Member>())
            .Register(new TimeToExecuteOperation<Member>())
            .Register(new TimeToExecuteOperation<Member>())
            .Execute(context);
        }

        private static void PipelineBuilderExample()
        {
            var context = new Member();

            var pipeline = new PipelineBuilder<Member>()
            .Register(new TimeToExecuteOperation<Member>())
            .Register(new TimeToExecuteOperation<Member>())
            .Register(new TimeToExecuteOperation<Member>())
            .Build();

            context = pipeline.Execute(context);
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
