using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.ClassLibrary.Base
{
    public abstract class Trainer : ITrainer
    {
        private readonly IPet _pet;

        protected Trainer(IPet pet)
        {
            _pet = pet;
        }

        public string MakePetSpeak()
        {
            return _pet.Speak();
        }
    }
}
