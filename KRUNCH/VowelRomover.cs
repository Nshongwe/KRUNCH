using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KRUNCH
{
    public interface IVowelRomover
    {
        string RemoveVowels(string unkrunch);
    }

    public class VowelRomover : IVowelRomover
    {
        public string RemoveVowels(string unkrunch)
        {
            foreach (var vowel in Enum.GetNames(typeof(Vowels)))
            {
                unkrunch = unkrunch.Replace(vowel, string.Empty);
            }

            return unkrunch;
        }
    }
}
