using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelLettersLibrary
{
   public static class Mapper
    {
       public static LettersProcessorModel LettersProcessorModel { get { return new LettersProcessorModel(); } }
       public static VowelRomoverModel VowelRomoverModel { get { return new VowelRomoverModel(); } }

    }
}
