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
            Container.Register<IVowelRomoverViewModel, VowelRomoverViewModel>();
            Container.Register<ILettersProcessorViewModel, LettersProcessorViewModel>();
            Container.Register<IBlanksProcessorViewModel, BlanksProcessorViewModel>();
            Container.Verify();

        }
    }
}
