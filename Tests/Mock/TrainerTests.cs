using Moq;
using NUnit.Framework;
using UMV.Reference.ClassLibrary.Concrete;
using UMV.Reference.ClassLibrary.Interfaces;

namespace UMV.Reference.Tests.Mock
{
    [TestFixture]
    public class TrainerTests
    {
        private Mock<ICat> _cat;
        private Mock<IDog> _dog;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cat = new Mock<ICat>();
            _dog = new Mock<IDog>();
        }

        [Test]
        public void Trainer_WithDog_Barks()
        {
            // Arrange
            _dog.Setup(x => x.Speak()).Returns("Hello, is it me you're looking for?");
            var dogTrainer = new DogTrainer(_dog.Object);

            // Act
            var whatDoesADogSay = dogTrainer.MarkPetSpeak();

            // Assert
            Assert.IsTrue(whatDoesADogSay == "Hello, is it me you're looking for?");
        }

        [Test]
        public void CatTrainer_WithCat_Meows()
        {
            // Arrange
            _cat.Setup(x => x.Speak()).Returns("I feel pretty, Oh, so pretty,I feel pretty and witty and bright!");
            var catTrainer = new CatTrainer(_cat.Object);

            // Act
            var whatDoesACatSay = catTrainer.MarkPetSpeak();

            // Assert
            Assert.IsTrue(whatDoesACatSay == "I feel pretty, Oh, so pretty,I feel pretty and witty and bright!");
        }
    }
}
