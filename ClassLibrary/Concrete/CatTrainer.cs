using UMV.Reference.ClassLibrary.Base;
using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.ClassLibrary.Concrete
{
    public class CatTrainer : Trainer, ICatTrainer
    {
        public CatTrainer(ICat pet) 
            : base(pet)
        {}
    }
}