using BlankLibrary;
using SimpleInjector;
using VowelLettersLibrary;

namespace KrunchApp
{
    class StartUp
    {
        public static Container Container;

        public static void Boot()
        {
            Container = new Container();
            Container.Register<IKrunchProcessor, KrunchProcessor>();
            Container.Register<IVowelRomover, VowelRomover>();
            Container.Register<ILettersProcessor, LettersProcessorProcessor>();
            Container.Register<IBlanksProcessor, BlanksProcessor>();
            Container.Verify();

        }
    }
}
