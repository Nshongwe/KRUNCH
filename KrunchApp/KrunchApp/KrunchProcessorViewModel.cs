using System;
using BlankLibrary;
using VowelLettersLibrary;
using System.IO;

namespace KrunchApp
{
    public interface IKrunchProcessorViewModel
    {
        KrunchProcessorModel KrunchProcessorModel { get; set; }
        IBlanksProcessorViewModel BlanksProcessorViewModel { get; set; }
        void Execute();
    }

    public class KrunchProcessorViewModel : IKrunchProcessorViewModel
    {
        public IBlanksProcessorViewModel BlanksProcessorViewModel { get; set; }
        public KrunchProcessorModel KrunchProcessorModel { get; set; }

        private readonly IVowelRomoverViewModel _vowelRomoverViewModel;
        private readonly ILettersProcessorViewModel _lettersProcessorViewModel;
        private readonly IFileProcessor _fileProcessor;

        public KrunchProcessorViewModel(IVowelRomoverViewModel vowelRomoverViewModel, ILettersProcessorViewModel lettersProcessorViewModel, IBlanksProcessorViewModel blanksProcessorViewModel, IFileProcessor fileProcessor)
        {
            _vowelRomoverViewModel = vowelRomoverViewModel;
            _lettersProcessorViewModel = lettersProcessorViewModel;
            BlanksProcessorViewModel = blanksProcessorViewModel;
            KrunchProcessorModel = Mapper.KrunchProcessorModel;
            _fileProcessor = fileProcessor;
            if (_vowelRomoverViewModel == null)
                throw new ArgumentNullException("vowelRomoverViewModel");
            if (lettersProcessorViewModel == null)
                throw new ArgumentNullException("lettersProcessorViewModel");
            if (blanksProcessorViewModel == null)
                throw new ArgumentNullException("blanksProcessorViewModel");
            if (fileProcessor == null)
                throw new ArgumentNullException("fileProcessor");
        }
        public void Execute()
        {
            _fileProcessor.ReadFile();
            _vowelRomoverViewModel.VowelRomoverModel.Unkrunch = _fileProcessor.SourceString.ToUpper();
            _vowelRomoverViewModel.RemoveVowels();
            _lettersProcessorViewModel.LettersProcessorModel.RepeatedLetters = _vowelRomoverViewModel.VowelRomoverModel.Krunched;
            _lettersProcessorViewModel.RemoveRepeats();
            BlanksProcessorViewModel.BlanksProcessorModel.UnProcessedBlanks = _lettersProcessorViewModel.LettersProcessorModel.NoRepeatedLetters;
            BlanksProcessorViewModel.RemoveExtraBlanks();
            _fileProcessor.WritetoFile(BlanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks);
            KrunchProcessorModel.InputFilePath = _fileProcessor.InputFile;
            KrunchProcessorModel.OutputFilePath = _fileProcessor.DestinationFile;


        }


    }
}
