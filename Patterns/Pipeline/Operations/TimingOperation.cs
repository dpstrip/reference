using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Operations
{
    public class TimingOperation : Operation<HttpContext>
    {
        protected override async Task Execute(HttpContext context, Func<HttpContext, Task> next)
        {
            var sw = new Stopwatch();
            sw.Start();
            await next(context);
            sw.Stop();

            Console.WriteLine($"Operation Completed in {sw.ElapsedMilliseconds}ms");
        }
    }
}