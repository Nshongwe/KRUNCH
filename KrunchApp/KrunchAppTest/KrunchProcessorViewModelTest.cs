using System;
using BlankLibrary;
using KrunchApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using VowelLettersLibrary;
using Assert = NUnit.Framework.Assert;
using StringAssert = NUnit.Framework.StringAssert;

namespace KrunchAppTest
{
    [TestFixture]
    public class KrunchProcessorViewModelTest
    {
        [Test]
        public void Constructor_ShouldThrowExceptionIfVowelRomoverViewModelNotSupplied()
        {
            try
            {
                var krunchProcessorViewModel = new KrunchProcessorViewModel(null, new LettersProcessorViewModel(),
                    new BlanksProcessorViewModel(), new FileProcessor(new Utility()));
                Assert.Fail("Expected to throw an ArgumentNullException");
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains("vowelRomoverViewModel", e.ParamName);
            }
        }

        [Test]
        public void Constructor_ShouldThrowExceptionIflettersProcessorViewModelNotSupplied()
        {
            try
            {
                var krunchProcessorViewModel = new KrunchProcessorViewModel(new VowelRomoverViewModel(), null,
                    new BlanksProcessorViewModel(), new FileProcessor(new Utility()));
                Assert.Fail("Expected to throw an ArgumentNullException");
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains("lettersProcessorViewModel", e.ParamName);
            }
        }

        [Test]
        public void Constructor_ShouldThrowExceptionIfblanksProcessorViewModelNotSupplied()
        {
            try
            {
                var krunchProcessorViewModel = new KrunchProcessorViewModel(new VowelRomoverViewModel(), new LettersProcessorViewModel(),
                   null, new FileProcessor(new Utility()));
                Assert.Fail("Expected to throw an ArgumentNullException");
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains("blanksProcessorViewModel", e.ParamName);
            }
        }

        [Test]
        public void Constructor_ShouldThrowExceptionIffileProcessorNotSupplied()
        {
            try
            {
                var krunchProcessorViewModel = new KrunchProcessorViewModel(new VowelRomoverViewModel(), new LettersProcessorViewModel(),
                   new BlanksProcessorViewModel(), null);
                Assert.Fail("Expected to throw an ArgumentNullException");
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains("fileProcessor", e.ParamName);
            }
        }

       [Test]
        public void InputString_ShouldBeKrushed()
        {
            var krunchProcessorViewModel = CreateKrunchProcessorViewModel();
            krunchProcessorViewModel.BlanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks = string.Empty;
            krunchProcessorViewModel.Execute();
            Assert.AreEqual("NW S TH M FR L GD C Y.", krunchProcessorViewModel.BlanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks);
        }
        private KrunchProcessorViewModel CreateKrunchProcessorViewModel()
        {
            return new KrunchProcessorViewModel(new VowelRomoverViewModel(), new LettersProcessorViewModel(), new BlanksProcessorViewModel(), new FileProcessor(new UtilityTest()));
        }
    }
}
