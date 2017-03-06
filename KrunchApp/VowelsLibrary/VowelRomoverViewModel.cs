using System;

namespace VowelLettersLibrary
{
    public interface IVowelRomoverViewModel
    {
        VowelRomoverModel VowelRomoverModel { get; set; }
        void RemoveVowels();
    }

    public class VowelRomoverViewModel : IVowelRomoverViewModel
    {
        
        public VowelRomoverModel VowelRomoverModel { get; set; }

        public VowelRomoverViewModel()
        {
            VowelRomoverModel = Mapper.VowelRomoverModel;
        }

        public void RemoveVowels()
        {
            string localUnkrunch = VowelRomoverModel.Unkrunch;
            foreach (var vowel in Enum.GetNames(typeof(Vowels)))
            {
                localUnkrunch = localUnkrunch.Replace(vowel, string.Empty);
            }

            VowelRomoverModel.Krunched = localUnkrunch;
        }
    }
}
