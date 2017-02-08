using System;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Repositories
{
    public class LogRepository : ILogRepository
    {
        public void Save(string log)
        {
            Console.WriteLine($"Saving log -->{log}");
        }
    }
}
