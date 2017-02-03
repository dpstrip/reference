using System;
using System.Threading.Tasks;
using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Operations
{
    public class LoggingOperation : Operation<HttpContext>
    {
        protected override async Task Execute(HttpContext context, Func<HttpContext, Task> next)
        {
            Console.WriteLine("Before Request");
            await next(context);
            Console.WriteLine("After Request");
        }
    }
}