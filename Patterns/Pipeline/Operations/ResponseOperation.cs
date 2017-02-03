using System;
using System.Threading.Tasks;
using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Operations
{
    public class ResponseOperation : Operation<HttpContext>
    {
        protected override Task Execute(HttpContext context, Func<HttpContext, Task> next)
        {
            context.Response = "<h1>Hello world</h1>";
            Console.WriteLine($"Setting Response: {context.Response}");
            return Task.Delay(3000);
        }
    }
}