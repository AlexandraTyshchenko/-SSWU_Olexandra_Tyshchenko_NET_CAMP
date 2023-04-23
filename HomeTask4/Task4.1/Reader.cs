using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
    internal class Reader
    {
        private List<string> _sentences = new List<string>();
        private StreamReader _sr;
        private string _location;
        public Reader(string location)
        {
            _location= location;
            _sr = new StreamReader(location);
        }

        public void Read()
        {
            var character = 0;

            StringBuilder sb = new StringBuilder();
            var symbols = new char[] { '.', '!', '?' };
            int previous;
            int buf = 0;
            while (character != -1)
            {
                previous = character;
                character = _sr.Read();
                if (character == '\n' || character == '\r')//перевіряю на наявність переносів
                {
                    if (buf != ' ')//пробілу попереднього нема, тільки тоді добавити пробіл, оскільки пробіл можна додати тільки раз
                    {
                        sb.Append(' ');
                        buf = ' ';
                    }
                    continue;
                }
                if (previous == ' ' && character == ' ')//уникнення кількох пробілів
                    continue;
                sb.Append((char)character);
                if (symbols.Contains((char)character))//якщо поточний символ є закінченням речення
                {
                    _sentences.Add(sb.ToString());
                    sb.Clear();
                }
            }
            _sr.Close();
            if (sb.Length != 0)//є ситуації коли останнє речення без розділового знаку, теж добавляється у список. 
                _sentences.Add(sb.ToString());
        }
        public string SentencesWithBrackets()
        {
            StringBuilder stringBuilder = new StringBuilder();
            char first = '(';
            char last = ')';
            foreach (var s in _sentences)
            {
                if (s.IndexOf(first) >= 0 && s.IndexOf(last) >= 0 && s.IndexOf(first) <= s.IndexOf(last))//якщо символи існують поверне більше ніж 0, якщо не знайдені -1, і перевірка чи правильно розтавлені, а не навпаки
                    stringBuilder.Append(s);
            }

            return stringBuilder.ToString();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            //Ви не використовуєте наступні 2 стрічки.
            char first = '(';
            char last = ')';
            foreach (var s in _sentences)
            {
                   stringBuilder.Append(s);
            }

            return stringBuilder.ToString();
        }
    }
}
