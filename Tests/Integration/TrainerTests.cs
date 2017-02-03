using NUnit.Framework;
using UMV.Reference.ClassLibrary.Concrete;

namespace UMV.Reference.Tests.Integration
{
    [TestFixture]
    public class TrainerTests
    {
        [Test]
        public void Trainer_WithDog_Barks()
        {
            // Arrange
            var dog = new Dog();
            var dogTrainer = new DogTrainer(dog);

            // Act
            var whatDoesADogSay = dogTrainer.MakePetSpeak();

            // Assert
            Assert.IsTrue(whatDoesADogSay == "WOOF, WOOF");
        }

        [Test]
        public void CatTrainer_WithCat_Meows()
        {
            // Arrange
            var cat = new Cat();
            var catTrainer = new CatTrainer(cat);

            // Act
            var whatDoesACatSay = catTrainer.MakePetSpeak();

            // Assert
            Assert.IsTrue(whatDoesACatSay == "WEOW, MEOW");
        }
    }
}
