using System;
using System.IO;
using System.Net.Mime;
using BlankLibrary;
using VowelLettersLibrary;

namespace KrunchApp
{
    public class Program
    {
        private static IKrunchProcessorViewModel _krunchProcessorViewModel;

        static void Main(string[] args)
        {
            try
            {
                _krunchProcessorViewModel = new KrunchProcessorViewModel(new VowelRomoverViewModel(), new LettersProcessorViewModel(),
                    new BlanksProcessorViewModel(), new FileProcessor());
                Console.WriteLine("Note : Krunching Source and destination file location config is found in the appConfig file");
                Console.WriteLine("Rrunching Started");
                _krunchProcessorViewModel.Execute();
                Console.WriteLine("Krunching is done and output is written to a file {0} ",
                     _krunchProcessorViewModel.KrunchProcessorModel.OutputFilePath);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}
