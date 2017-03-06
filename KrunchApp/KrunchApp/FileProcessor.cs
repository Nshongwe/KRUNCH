using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KrunchApp
{
    public interface IFileProcessor
    {
        string DestinationFile { get; }
        string InputFile { get; }
        string SourceString { get; set; }
        void WritetoFile(string output);
        void ReadFile();
    }

    public class FileProcessor : IFileProcessor
    {

        public string DestinationFile { get; private set; }
        public string InputFile { get; private set; }

        private StreamWriter _logWriter;
        private StreamReader _logReader;
        public  IUtility Utility { get; set; }
        public string SourceString { get; set; }

        public FileProcessor(IUtility utility)
        {
            Utility = utility;
            if (utility == null)
                throw new ArgumentNullException("utility");
        }

        public void ReadFile()
        {
            try
            {
                InputFile = Utility.GetAppSetting("SourcePath") + "UnKruchedFile.txt"; ;
                DestinationFile = Utility.GetAppSetting("DestinationPath") + "KruchedFile.txt";
                if (InputFile.Equals(string.Empty)) return;
                _logReader = new StreamReader(InputFile);
                SourceString = _logReader.ReadToEnd();
                SourceString = SourceString.Replace("\r\n", " ");
                _logReader.Close();
            }
            catch (Exception e)
            {
                throw new IOException("Error reading file" + e.Message);
            }

        }

        public void WritetoFile(string output)
        {
            try
            {
                _logWriter = new StreamWriter(DestinationFile);
                if (_logWriter == null)
                    throw new IOException("Error writting to file ");
                _logWriter.WriteLineAsync(output);
                if ((_logWriter != null))
                {
                    _logWriter.Flush();
                    _logWriter.Close();
                }
            }
            catch (Exception e)
            {
                throw new IOException("Error writting to file " + e.Message);
            }

        }
    }
}
