using KrunchApp;

namespace KRUNCH
{
    public class Program
    {
        private static IKrunchProcessor _krunchProcessor;

        static void Main(string[] args)
        {
            
            /*  The belew 2 statement can be removed and replaced with
            _krunchProcessor = new KrunchProcessor(new VowelRomoverViewModel());
             because i have used simpliInjector as my DI and is external*/
            
            StartUp.Boot();
            _krunchProcessor = StartUp.Container.GetInstance<IKrunchProcessor>();
            _krunchProcessor.Execute();

        }
    }
}
