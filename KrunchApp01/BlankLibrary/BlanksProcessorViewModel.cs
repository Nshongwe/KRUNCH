using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankLibrary
{
    public interface IBlanksProcessorViewModel
    {

        void RemoveExtraBlanks();
        BlanksProcessorModel BlanksProcessorModel { get; set; }
    }

    public class BlanksProcessorViewModel : IBlanksProcessorViewModel
    {
        public BlanksProcessorModel BlanksProcessorModel { get; set; }

        public BlanksProcessorViewModel()
        {
            BlanksProcessorModel=new BlanksProcessorModel();
        }
        public void RemoveExtraBlanks()
        {
            string localprocessedBlanks = string.Empty;
            foreach (var s in BlanksProcessorModel.UnProcessedBlanks.Trim().Split(' '))
            {
                localprocessedBlanks += localprocessedBlanks.Trim();
                localprocessedBlanks += ' ';
            }
            BlanksProcessorModel.ProcessedBlanks = localprocessedBlanks;
        }
    }
}
