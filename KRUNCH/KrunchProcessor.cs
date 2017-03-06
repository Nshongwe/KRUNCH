using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KRUNCH
{
    public interface IKrunchProcessor
    {
        void Execute();
    }

    public class KrunchProcessor : IKrunchProcessor
    {
        private string _unkrunch, _unvowel;
        private readonly IVowelRomover _vowelRomover;

        public KrunchProcessor(IVowelRomover vowelRomover)
        {
            _vowelRomover = vowelRomover;
            if (_vowelRomover == null)
                throw new ArgumentNullException("vowelRomover");
        }
        public void Execute()
        {
            Console.WriteLine("Please Enter an unkrunch word");
            _unkrunch = Console.ReadLine();
            if (_unkrunch.Equals(string.Empty)) return;
            _unvowel = _vowelRomover.RemoveVowels(_unkrunch.ToUpper());
            Console.WriteLine(_unvowel);
            Console.ReadLine();
        }

    }
}
