using ClassLibrary.Interfaces;
using Ninject;

namespace ClassLibrary.Base
{
    public abstract class Trainer : ITrainer
    {
        private readonly IPet _pet;

        protected Trainer(IPet pet)
        {
            _pet = pet;
        }

        public string MarkPetSpeak()
        {
            return _pet.Speak();
        }
    }
}
