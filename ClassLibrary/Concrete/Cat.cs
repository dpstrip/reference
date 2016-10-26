using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.ClassLibrary.Concrete
{
    public class Cat : ICat
    {
        public string Speak()
        {
            return "WEOW, MEOW";
        }
    }
}