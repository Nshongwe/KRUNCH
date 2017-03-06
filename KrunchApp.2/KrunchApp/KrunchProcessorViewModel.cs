using System;
using BlankLibrary;
using VowelLettersLibrary;
using System.IO;

namespace KrunchApp
{
    public interface IKrunchProcessorViewModel
    {
        KrunchProcessorModel KrunchProcessorModel { get; set; }
        void Execute();
    }

    public class KrunchProcessorViewModel : IKrunchProcessorViewModel
    {
        private readonly IVowelRomoverViewModel _vowelRomoverViewModel;
        private readonly ILettersProcessorViewModel _lettersProcessorViewModel;
        private readonly IBlanksProcessorViewModel _blanksProcessorViewModel;
        private readonly IFileProcessor _fileProcessor;
        public KrunchProcessorModel KrunchProcessorModel { get; set; }

        public KrunchProcessorViewModel(IVowelRomoverViewModel vowelRomoverViewModel, ILettersProcessorViewModel lettersProcessorViewModel, IBlanksProcessorViewModel blanksProcessorViewModel, IFileProcessor fileProcessor)
        {
            _vowelRomoverViewModel = vowelRomoverViewModel;
            _lettersProcessorViewModel = lettersProcessorViewModel;
            _blanksProcessorViewModel = blanksProcessorViewModel;
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
            _blanksProcessorViewModel.BlanksProcessorModel.UnProcessedBlanks = _lettersProcessorViewModel.LettersProcessorModel.NoRepeatedLetters;
            _blanksProcessorViewModel.RemoveExtraBlanks();
            _fileProcessor.WritetoFile(_blanksProcessorViewModel.BlanksProcessorModel.ProcessedBlanks);
            KrunchProcessorModel.InputFilePath = _fileProcessor.InputFile;
            KrunchProcessorModel.OutputFilePath = _fileProcessor.DestinationFile;


        }


    }
}
