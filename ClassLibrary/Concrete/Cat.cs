using ClassLibrary.Interfaces;

namespace ClassLibrary.Concrete
{
    public class Cat : ICat
    {
        public string Speak()
        {
            return "WEOW, MEOW";
        }
    }
}