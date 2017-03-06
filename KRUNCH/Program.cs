using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace KRUNCH
{
    public class Program
    {
        private  static IKrunchProcessor _krunchProcessor;

       static void Main(string[] args)
       {
           StartUp.Boot();
           _krunchProcessor = StartUp.Container.GetInstance<IKrunchProcessor>();
           _krunchProcessor.Execute();
            
        }
    }
}
