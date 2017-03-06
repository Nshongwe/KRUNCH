using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SimpleInjector;
namespace KRUNCH
{
    class StartUp
    {
        public static Container Container;

        public static void Boot()
        {
            Container = new Container();
            Container.Register<IKrunchProcessor, KrunchProcessor>();
            Container.Register<IVowelRomover, VowelRomover>();
            Container.Verify();

        }
    }
}
