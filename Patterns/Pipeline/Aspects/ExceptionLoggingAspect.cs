using System;

namespace UMV.Reference.Patterns.Aspects
{
    public class ExceptionLoggingAspect<T>
    {
        public ExceptionLoggingAspect(Func<T, T> action)
        {
            Handle = action;
        }

        public T Execute(T input)
        {
            try
            {
                return Handle(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        private Func<T, T> Handle { get; set; }

    }
}