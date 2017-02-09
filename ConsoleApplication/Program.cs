using System;
using Ninject;
using UMV.Reference.ClassLibrary.Interfaces;
using UMV.Reference.ClassLibrary.Ninject;
using UMV.Reference.Patterns;
using UMV.Reference.Patterns.Aspects;
using UMV.Reference.Patterns.Base.Interfaces;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Ninject;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PipelineExample();

            Console.ReadLine();
        }

        private static void TestChangeTracking()
        {
            var member = new Member();

            member.FirstName = "Craig";

            member.InitializeChangeState();

            member.FirstName = "CRAIG";

            var changes = member.GetChangeState();
        }

        private static void PipelineExample()
        {
            var kernel = new StandardKernel(new PatternsModule());
            var context = new Member();

            var trackChanges = kernel.Get<IOperation<Member>>("MemberChangeTracker");
            var addAuditInformation = kernel.Get<IOperation<Member>>("AddAuditInformation");
            var updateMemberNameToCraigOperation = kernel.Get<IOperation<Member>>("UpdateMemberNameToCraigOperation");
            var initializeChangeTracking = kernel.Get<IOperation<Member>>("InitializeChangeTracking");

            // Build up your pipeline
            var pipeline = new Pipeline<Member>()
                .Register(initializeChangeTracking)
                .Register(addAuditInformation)
                .Register(updateMemberNameToCraigOperation)
                .Register(trackChanges)
                ;

            // Add aspects around the pipline 
            var exceptionLogginAspect = new ExceptionLoggingAspect<Member>(pipeline.Execute);

            // Execute 
            context = exceptionLogginAspect.Execute(context) ;

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
