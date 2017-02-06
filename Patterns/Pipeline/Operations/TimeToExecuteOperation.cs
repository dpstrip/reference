using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Operations
{
    public class TimeToExecuteOperation<T> : Operation<T>
    {
        protected override T Execute(T context, Func<T, T> next)
        {
            var result = default(T);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(2000);
            result = next(context);
            stopwatch.Stop();
            Console.WriteLine($"Operation Completed in {stopwatch.ElapsedMilliseconds}ms");

            return result;
        }
    }

    public class LongRunningOperation : Operation<Member>
    {
        protected override Member Execute(Member context, Func<Member, Member> next)
        {

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            context.FirstName = "Craig";
            Thread.Sleep(2000);
            context = next(context);


            stopwatch.Stop();
            Console.WriteLine($"Operation Completed in {stopwatch.ElapsedMilliseconds}ms");

            return context;

        }
    }


}