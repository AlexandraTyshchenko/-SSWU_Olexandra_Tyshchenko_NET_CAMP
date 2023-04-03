// See https://aka.ms/new-console-template for more information
using Strings;
StringClass str = new StringClass("Hello World Hello World World");
int? index = str.FindSecondIndex("World");
Console.WriteLine(index);
int sum = str.CountWordsStartingWithUpper();
Console.WriteLine(sum);
str.ReplaceWordsWithNewWord("hi");
Console.WriteLine(str);