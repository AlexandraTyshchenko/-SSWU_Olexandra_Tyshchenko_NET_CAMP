using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class StringClass
    {
        private string _str;
        public StringClass(string str="")
        {
            _str= str;
        }
        public int? FindSecondIndex(string substring)
        {
           int index= 0;
           index = _str.IndexOf(substring, _str.IndexOf(substring) + substring.Length);
            if (index == -1)
                return null;
            return index;
        }
        public int CountWordsStartingWithUpper()
        {
            string[] substrings = _str.Split(new char[] { ' ', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (var sb in substrings)
            {
                if (char.IsUpper(sb[0]))
                    count++;
            }
            return count;
        }
        //порушиться початкова структура.
        public void ReplaceWordsWithNewWord(string substring)
        {

            string[] substrings = _str.Split(new char[] { ' ', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string str;
            for (int i = 0; i < substrings.Length; i++)
            {
                str = substrings[i];
                for (int j = 1; j < str.Length; j++)
                {
                    if (char.ToLower(str[j - 1]) == char.ToLower(str[j]))
                    {
                        substrings[i] = substring;
                        break;
                    }

                }
            }
            _str = string.Join(' ', substrings);
        }
        public override string ToString()
        {
            return _str;
        }
    }
}
