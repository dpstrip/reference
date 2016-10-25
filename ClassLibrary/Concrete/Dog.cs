using ClassLibrary.Interfaces;

namespace ClassLibrary.Concrete
{
    public class Dog : IDog
    {
        public string Speak()
        {
            return "WOOF, WOOF";
        }
    }
}