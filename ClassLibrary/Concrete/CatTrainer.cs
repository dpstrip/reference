using ClassLibrary.Base;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Concrete
{
    public class CatTrainer : Trainer, ICatTrainer
    {
        public CatTrainer(ICat pet) 
            : base(pet)
        {}
    }
}