using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.ClassLibrary.Concrete
{
    public class Dog : IDog
    {
        public string Speak()
        {
            return "WOOF, WOOF";
        }
    }
}