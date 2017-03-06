using System;

namespace VowelLettersLibrary
{
    public interface IVowelRomover
    {
        void RemoveVowels();
        string Unkrunch { get; set; }
        string Krunched { get; }
    }

    public class VowelRomover : IVowelRomover
    {
        public string Unkrunch { get; set; }
        public string Krunched { get; private set; }

        public void RemoveVowels()
        {
            string localUnkrunch = Unkrunch;
            foreach (var vowel in Enum.GetNames(typeof(Vowels)))
            {
                localUnkrunch = localUnkrunch.Replace(vowel, string.Empty);
            }

            Krunched = localUnkrunch;
        }
    }
}
