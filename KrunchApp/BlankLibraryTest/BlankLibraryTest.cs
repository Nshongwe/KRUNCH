using System;
using BlankLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BlankLibraryTest
{
    [TestFixture]
    public class BlankLibraryTest
    {
        [Test]
        public void Mapper_ShouldReturnNewInstanceOfBlanksProcessorModel()
        {
            Assert.IsInstanceOf<BlanksProcessorModel>(Mapper.BlanksProcessorModel, "BlankLibrary Mapper does not have a mapping for BlanksProcessorModel");
        }

        [Test]
        public void Constructor_SetBlanksProcessorViewModel()
        {
            var blanksProcessorViewModel = BlanksProcessorViewModel();
            Assert.IsNotNull(blanksProcessorViewModel.BlanksProcessorModel);
        }

        [TestCase("RAIL   ROAD  CROSSING 's", "RAIL ROAD CROSSING 's")]
        [TestCase("MADAM I SAY I AM ADAM  ", "MADAM I SAY I AM ADAM")]
        [TestCase(" NOW IS  THE TIME FOR   ALL GOOD MEN TO COME  TO THE AID OF THEIR COUNTRY.  ", "NOW IS THE TIME FOR ALL GOOD MEN TO COME TO THE AID OF THEIR COUNTRY.")]
        public void When_GivenStringWithLeadingAndTrailingAndDoubleSpace_ShouldRomoveThem(string input,string expected)
        {
            var blanksProcessorViewModel = BlanksProcessorViewModel();
            blanksProcessorViewModel.BlanksProcessorModel.UnProcessedBlanks = input;
            blanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks = string.Empty;
            Assert.IsEmpty(blanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks);
            blanksProcessorViewModel.RemoveExtraBlanks();
           Assert.AreEqual(expected, blanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks,"Space removering failed");

        }

        public BlanksProcessorViewModel BlanksProcessorViewModel()
        {
            return new BlanksProcessorViewModel();
        }



    }
}
