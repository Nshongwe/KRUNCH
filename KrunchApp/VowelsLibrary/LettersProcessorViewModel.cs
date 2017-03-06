using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VowelLettersLibrary
{
    public interface ILettersProcessorViewModel
    {
        LettersProcessorModel LettersProcessorModel { get; set; }
        void RemoveRepeats();
    }

    public class LettersProcessorViewModel : ILettersProcessorViewModel
    {

        private readonly Regex _regex = new Regex("^[a-zA-Z0-9]*$");
        public LettersProcessorModel LettersProcessorModel { get; set; }

        public LettersProcessorViewModel()
        {
            LettersProcessorModel = Mapper.LettersProcessorModel;
        }

        public void RemoveRepeats()
        {
            string localNoRepeatedLetters = string.Empty;
            foreach (var letter in LettersProcessorModel.RepeatedLetters.ToCharArray())
            {
                if (!_regex.IsMatch(letter.ToString())) localNoRepeatedLetters += letter;
                else
                    if (!localNoRepeatedLetters.Contains(letter)) localNoRepeatedLetters += letter;
            }
            LettersProcessorModel.NoRepeatedLetters = localNoRepeatedLetters;
        }
    }
}
