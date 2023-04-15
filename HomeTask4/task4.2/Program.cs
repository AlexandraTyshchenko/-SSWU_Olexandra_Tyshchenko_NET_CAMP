// See https://aka.ms/new-console-template for more information
//char[] delimiters = new char[] { '!', '#', '$', '%', '&', '*', '+', '-', '=', '?', '^', '_', '{', '|', '}', '~', '.' };

//bool IsAllLatinOrDigitLocal(string str)
//{
//    if (ifHasQuotes(str))
//        return str.All(c => char.IsDigit(c)||(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || delimiters.Contains(c) || c == '"' || c == ' ');
//    return str.All(c => char.IsDigit(c)||(c >= 'a' && c <= 'z'||  c >= 'A' && c <= 'Z') || delimiters.Contains(c)) && CheckDot(str);
//}
//bool IsAllLatinOrDigitDomain(string str)
//{
//    return str.All(c => char.IsDigit(c)||(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || c == '-' || c == '.') && (!str.StartsWith('-') && !str.EndsWith('-')) && CheckDot(str);
//}
//bool ifHasQuotes(string str)
//{
//    if (str.StartsWith("\"") && str.EndsWith("\""))
//        return true;
//    return false;
//}

//bool CheckAt(string str)
//{
//    return !str.StartsWith('@') && !str.EndsWith('@') && str.Count(c => c == '@') == 1;
//}
//bool CheckDot(string str)
//{

//    for (int i = 1; i < str.Length; i++)
//    {
//        if (str[i] == '.' && str[i - 1] == '.')
//        {
//            return false;
//        }
//    }
//    return (str.StartsWith('.') || str.EndsWith('.')) ? false : true;
//}
//string email = "\"john..doe\"@(comment)example.com";
//string local = string.Empty;
//string domain = string.Empty;

//if (CheckAt(email))
//{
//    local = email.Substring(0, email.IndexOf('@'));
//    domain = email.Substring(email.IndexOf('@') + 1, email.Length - email.IndexOf('@') - 1);
//}

//int start = domain.IndexOf("(");
//int end = domain.IndexOf(")");
//if (start < end)
//{
//    domain = domain.Remove(start, end + 1);
//}
//if (IsAllLatinOrDigitLocal(local) && IsAllLatinOrDigitDomain(domain))
//    Console.WriteLine("урааа");
using task4._2;

EmailValidator emailvalidator=new EmailValidator("emails.txt");
emailvalidator.Read();
Console.WriteLine(emailvalidator);