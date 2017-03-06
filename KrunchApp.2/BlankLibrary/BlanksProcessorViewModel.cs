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
            BlanksProcessorModel = Mapper.BlanksProcessorModel;
        }
        public void RemoveExtraBlanks()
        {
            var list = BlanksProcessorModel.UnProcessedBlanks.Trim().Split(' ').Where(x => x != string.Empty).ToList();
            var localprocessedBlanks = string.Join(" ", list);
            BlanksProcessorModel.ProcessedBlanks = localprocessedBlanks;
        }
    }
}
