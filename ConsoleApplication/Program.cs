using System;
using Ninject;
using UMV.Reference.ClassLibrary.Interfaces;
using UMV.Reference.ClassLibrary.Ninject;
using UMV.Reference.Patterns;
using UMV.Reference.Patterns.Aspects;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var member = new Member();

            member.FirstName = "Craig";

            member.Initialize();

            member.FirstName = "CRAIG";

            var changes = member.GetChanges();

            Console.ReadLine();
        }

        private static void PipelineExample()
        {
            var context = new Member();

            IOperation<Member> m = null;

            // Build up your pipeline
            var pipeline = new Pipeline<Member>()
                .Register(m)
                .Register(new AddMemberNameOperation());

            // Add aspects around the pipline 
            var exceptionLogginAspect = new ExceptionLoggingAspect<Member>(pipeline.Execute);

            // Execute 
            context = exceptionLogginAspect.Execute(context);

            Console.WriteLine(context.FirstName);
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
