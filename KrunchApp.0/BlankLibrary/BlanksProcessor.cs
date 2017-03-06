using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankLibrary
{
    public interface IBlanksProcessor
    {
        string UnProcessedBlanks { get; set; }
        string ProcessedBlanks { get; }
        void RemoveExtraBlanks();
    }

    public class BlanksProcessor : IBlanksProcessor
    {
       public string UnProcessedBlanks { get; set; }
       public string ProcessedBlanks { get; private set; }

       public void RemoveExtraBlanks()
       {
           string localprocessedBlanks = string.Empty;
           foreach (var s in UnProcessedBlanks.Trim().Split(' '))
           {
               localprocessedBlanks+=localprocessedBlanks.Trim();
               localprocessedBlanks += ' ';
           }
           ProcessedBlanks = localprocessedBlanks;
       }
    }
}
