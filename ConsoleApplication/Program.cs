using System;
using System.Security.Principal;
using System.Threading;
using Ninject;
using UMV.Reference.ClassLibrary.Interfaces;
using UMV.Reference.ClassLibrary.Ninject;
using UMV.Reference.Patterns;
using UMV.Reference.Patterns.Aspects;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Ninject;
using UMV.Reference.Patterns.Operations.Interfaces;

namespace UMV.Reference.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("Travis"), new[] { "Administrator" });

            PipelineExample();

            Console.ReadLine();
        }

        private static void TestChangeTracking()
        {
            var member = new Member { FirstName = "Craig" };

            member.InitializeChangeState();

            member.FirstName = "CRAIG";

            var changes = member.GetChangeState();
        }

        private static void PipelineExample()
        {
            var kernel = new StandardKernel(new PatternsModule());

            var member = new Member { Id = 12 };

            var getMemberFromRepositoryById = kernel.Get<IOperation<Member>>("GetMemberFromRepositoryById");
            var initializeChangeTracking = kernel.Get<IOperation<Member>>("InitializeChangeTracking");
            var addAuditInformation = kernel.Get<IOperation<Member>>("AddAuditInformation");
            var updateMemberFromMessageOperation = kernel.Get<IOperation<Member>>("UpdateMemberFromMessageOperation");
            var memberChangeTracker = kernel.Get<IOperation<Member>>("MemberChangeTracker");

            // Build up your pipeline
            var pipeline = new Pipeline<Member>()
                .Register(getMemberFromRepositoryById)
                .Register(initializeChangeTracking)
                .Register(addAuditInformation)
                .Register(updateMemberFromMessageOperation)
                .Register(memberChangeTracker)
                ;

            // Add aspects around the pipline 
            var exceptionLogginAspect = new ExceptionLoggingAspect<Member>(pipeline.Execute);

            // Execute 
            member = exceptionLogginAspect.Execute(member);

            Console.WriteLine(member.FirstName);
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
