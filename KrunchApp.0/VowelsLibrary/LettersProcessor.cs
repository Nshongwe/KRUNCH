using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VowelLettersLibrary
{
    public interface ILettersProcessor
    {
        string RepeatedLetters { get; set; }
        string NoRepeatedLetters { get; }
        void RemoveRepeats();
    }

    public class LettersProcessorProcessor : ILettersProcessor
    {
       public string RepeatedLetters { get; set; }
       public string NoRepeatedLetters { get; private set; }
       private readonly Regex _regex = new Regex("^[a-zA-Z0-9]*$");

       public void RemoveRepeats()
       {
           string localNoRepeatedLetters = string.Empty;
           foreach (var letter in RepeatedLetters.ToCharArray())
           {
               if (!_regex.IsMatch(letter.ToString())) localNoRepeatedLetters += letter;
               else
              if (!localNoRepeatedLetters.Contains(letter)) localNoRepeatedLetters += letter;
           }
           NoRepeatedLetters = localNoRepeatedLetters;
       }
    }
}
