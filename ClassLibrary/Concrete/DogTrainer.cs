using UMV.Reference.ClassLibrary.Base;
using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.ClassLibrary.Concrete
{
    public class DogTrainer : Trainer, IDogTrainer
    {
        public DogTrainer(IDog pet) 
            : base(pet)
        {}
    }
}