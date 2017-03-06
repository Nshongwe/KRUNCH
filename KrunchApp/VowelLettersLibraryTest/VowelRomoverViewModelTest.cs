using System;
using NUnit.Framework;
using VowelLettersLibrary;
using Assert = NUnit.Framework.Assert;
namespace VowelLettersLibraryTest
{
    [TestFixture]
    public class VowelRomoverViewModelTest
    {
       
        [Test]
        public void Constructor_SetVowelRomoverModel()
        {
            var vowelRomoverModel = CreateVowelRomoverModelViewModel();
            Assert.IsNotNull(vowelRomoverModel.VowelRomoverModel);
        }

        [TestCase("RAILROAD CROSSING", "RLRD CRSSNG")]
        [TestCase("MADAM I SAY I AM ADAM  ", "MDM  SY  M DM  ")]
        public void When_GivenInputString_ShouldRemoveVowels(string input, string expected)
        {
            var vowelRomoverModel = CreateVowelRomoverModelViewModel();
            vowelRomoverModel.VowelRomoverModel.Unkrunch = input;
            vowelRomoverModel.VowelRomoverModel.Krunched = string.Empty;
            vowelRomoverModel.RemoveVowels();
            Assert.AreEqual(expected, vowelRomoverModel.VowelRomoverModel.Krunched);
        }

        private VowelRomoverViewModel CreateVowelRomoverModelViewModel()
        {
            return new VowelRomoverViewModel();
        }
    }
}
