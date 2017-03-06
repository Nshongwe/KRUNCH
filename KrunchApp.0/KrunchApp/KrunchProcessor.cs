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
        private readonly IVowelRomover _vowelRomover;
        private readonly ILettersProcessor _lettersProcessor;
        private readonly IBlanksProcessor _blanksProcessor;

        public KrunchProcessor(IVowelRomover vowelRomover, ILettersProcessor lettersProcessor, IBlanksProcessor blanksProcessor)
        {
            _vowelRomover = vowelRomover;
            _lettersProcessor = lettersProcessor;
            _blanksProcessor = blanksProcessor;
            if (_vowelRomover == null)
                throw new ArgumentNullException("vowelRomover");
            if (lettersProcessor == null)
                throw new ArgumentNullException("lettersProcessor");
            if (blanksProcessor == null)
                throw new ArgumentNullException("blanksProcessor");
        }
        public void Execute()
        {
            Console.WriteLine("Please Enter an unkrunch word");
            _unkrunch = Console.ReadLine();
            if (_unkrunch == null) return;
            if (_unkrunch.Equals(string.Empty)) return;
            _vowelRomover.Unkrunch = _unkrunch.ToUpper();
            _vowelRomover.RemoveVowels();
            Console.WriteLine("Krunched");
            Console.WriteLine(_vowelRomover.Krunched);
            _lettersProcessor.RepeatedLetters = _vowelRomover.Krunched;
            _lettersProcessor.RemoveRepeats();
            Console.WriteLine("NoRepeatedLetters");
            Console.WriteLine(_lettersProcessor.NoRepeatedLetters);
            _blanksProcessor.UnProcessedBlanks = _lettersProcessor.NoRepeatedLetters;
            _blanksProcessor.RemoveExtraBlanks();
            Console.WriteLine("ProcessedBlanks");
            Console.WriteLine(_blanksProcessor.ProcessedBlanks);
            Console.ReadLine();
        }

    }
}
