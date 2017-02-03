using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Operations
{
    public class TimeToExecuteOperation<T> : Operation<T>
    {
        protected override async Task Execute(T context, Func<T, Task> next)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await next(context);
            stopwatch.Stop();

            Console.WriteLine($"Operation Completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public class LongRunningOperation : Operation<Member>
    {
        protected override Task Execute(Member context, Func<Member, Task> next)
        {
            context.FirstName = "Craig";
            Thread.Sleep(2000);
            return next(context);
        }

    }
}