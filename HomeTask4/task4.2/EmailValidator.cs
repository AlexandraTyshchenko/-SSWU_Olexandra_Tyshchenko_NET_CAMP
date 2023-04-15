using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace task4._2
{
    internal class EmailValidator
    {
        private StreamReader _sr;
        private string _location;
        private Dictionary<string, bool> emails = new Dictionary<string, bool>();
        public Dictionary<string, bool> Emails { get { return emails; } }
        char[] delimiters = new char[] { '!', '#', '$', '%', '&', '*', '+', '-', '=', '?', '^', '_', '{', '|', '}', '~', '.' };
        public EmailValidator(string location)
        {
            _location = location;
            _sr = new StreamReader(location);
        }
        public void Read()
        {
            string line;
            int start;
            int end;
            string local = string.Empty;
            string domain = string.Empty;

            while ((line = _sr.ReadLine()) != null) 
            {
                if (CheckAt(line))
                {
                    local = line.Substring(0, line.IndexOf('@'));
                    domain = line.Substring(line.IndexOf('@') + 1, line.Length - line.IndexOf('@') - 1);
                    start = domain.IndexOf("(");
                    end = domain.IndexOf(")");
                    if (start < end)
                    {
                        domain = domain.Remove(start, end + 1);
                    }
                    if (IsAllLatinOrDigitLocal(local) && IsAllLatinOrDigitDomain(domain))
                        emails.Add(line, true);
                    else
                        emails.Add(line, false);
                }
                else
                {
                    emails.Add(line, false);
                }
            }
            _sr.Close();
        }
        private bool IsAllLatinOrDigitLocal(string str)
        {
            if (ifHasQuotes(str))
                return str.All(c => char.IsDigit(c) || (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || delimiters.Contains(c) || c == '"' || c == ' ');
            return str.All(c => char.IsDigit(c) || (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || delimiters.Contains(c)) && CheckDot(str);
        }
        private bool IsAllLatinOrDigitDomain(string str)
        {
            return str.All(c => char.IsDigit(c) || (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || c == '-' || c == '.') && (!str.StartsWith('-') && !str.EndsWith('-')) && CheckDot(str);
        }
        private bool ifHasQuotes(string str)
        {
            if (str.StartsWith("\"") && str.EndsWith("\""))
                return true;
            return false;
        }

        private bool CheckAt(string str)
        {
            return !str.StartsWith('@') && !str.EndsWith('@') && str.Count(c => c == '@') == 1;
        }
        private bool CheckDot(string str)
        {

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '.' && str[i - 1] == '.')
                {
                    return false;
                }
            }
            return (str.StartsWith('.') || str.EndsWith('.')) ? false : true;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach(var email in emails)
            {
                stringBuilder.Append(email.ToString()+'\n'); 
            }
            return stringBuilder.ToString();
        }

    }
}
