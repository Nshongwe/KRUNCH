using System;
using NUnit.Framework;
using VowelLettersLibrary;
using Assert = NUnit.Framework.Assert;
namespace VowelLettersLibraryTest
{
    [TestFixture]
    public class LettersProcessorViewModelTest
    {
        
        [Test]
        public void Mapper_ShouldReturnNewInstanceOfLettersProcessorModel()
        {
            Assert.IsInstanceOf<LettersProcessorModel>(Mapper.LettersProcessorModel, "VowelLettersLibrary Mapper does not have a mapping for LettersProcessorModel");
            Assert.IsInstanceOf<VowelRomoverModel>(Mapper.VowelRomoverModel, "VowelLettersLibrary Mapper does not have a mapping for VowelRomoverModel");
        }

        [Test]
        public void Constructor_SetLettersProcessorViewModel()
        {
            var lettersProcessorViewModel = CreateLetterProcessorViewModel();
            Assert.IsNotNull(lettersProcessorViewModel.LettersProcessorModel);
        }
        
        [TestCase("RAILROAD CROSSING", "RAILOD CSNG")]
        [TestCase("MADAM I SAY I AM ADAM  ", "MAD I SY     ")]
        public void When_GivenInputString_ShouldRemoveRepeatingLetters(string input, string expected)
        {
            var letterProcessorViewModel = CreateLetterProcessorViewModel();
            letterProcessorViewModel.LettersProcessorModel.RepeatedLetters = input;
            letterProcessorViewModel.LettersProcessorModel.NoRepeatedLetters = string.Empty;
            letterProcessorViewModel.RemoveRepeats();
            Assert.AreEqual(expected, letterProcessorViewModel.LettersProcessorModel.NoRepeatedLetters);
        }

        private LettersProcessorViewModel CreateLetterProcessorViewModel()
        {
            return new LettersProcessorViewModel();
        }
    }
}
