using ClassLibrary.Base;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Concrete
{
    public class DogTrainer : Trainer, IDogTrainer
    {
        public DogTrainer(IDog pet) 
            : base(pet)
        {}
    }
}