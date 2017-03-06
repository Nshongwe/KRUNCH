using System;
using BlankLibrary;
using VowelLettersLibrary;

namespace KrunchApp
{
    public interface IKrunchProcessor
    {
        void Execute();
    }

    public class KrunchProcessor : IKrunchProcessor
    {
        private string _unkrunch, _unvowel;
        private readonly IVowelRomoverViewModel _vowelRomoverViewModel;
        private readonly ILettersProcessorViewModel _lettersProcessorViewModel;
        private readonly IBlanksProcessorViewModel _blanksProcessorViewModel;

        public KrunchProcessor(IVowelRomoverViewModel vowelRomoverViewModel, ILettersProcessorViewModel lettersProcessorViewModel, IBlanksProcessorViewModel blanksProcessorViewModel)
        {
            _vowelRomoverViewModel = vowelRomoverViewModel;
            _lettersProcessorViewModel = lettersProcessorViewModel;
            _blanksProcessorViewModel = blanksProcessorViewModel;
            if (_vowelRomoverViewModel == null)
                throw new ArgumentNullException("vowelRomoverViewModel");
            if (lettersProcessorViewModel == null)
                throw new ArgumentNullException("lettersProcessorViewModel");
            if (blanksProcessorViewModel == null)
                throw new ArgumentNullException("blanksProcessorViewModel");
        }
        public void Execute()
        {
            Console.WriteLine("Please Enter an unkrunch word");
            _unkrunch = Console.ReadLine();
            if (_unkrunch == null) return;
            if (_unkrunch.Equals(string.Empty)) return;
            _vowelRomoverViewModel.VowelRomoverModel.Unkrunch = _unkrunch.ToUpper();
            _vowelRomoverViewModel.RemoveVowels();
            Console.WriteLine("Krunched");
            Console.WriteLine(_vowelRomoverViewModel.VowelRomoverModel.Krunched);
            _lettersProcessorViewModel.LettersProcessorModel.RepeatedLetters = _vowelRomoverViewModel.VowelRomoverModel.Krunched;
            _lettersProcessorViewModel.RemoveRepeats();
            Console.WriteLine("NoRepeatedLetters");
            Console.WriteLine(_lettersProcessorViewModel.LettersProcessorModel.NoRepeatedLetters);
            _blanksProcessorViewModel.BlanksProcessorModel.UnProcessedBlanks = _lettersProcessorViewModel.LettersProcessorModel.NoRepeatedLetters;
            _blanksProcessorViewModel.RemoveExtraBlanks();
            Console.WriteLine("ProcessedBlanks");
            Console.WriteLine(_blanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks);
            Console.ReadLine();
        }

    }
}
