// Не побачила малюнка з діаграмою. Домовлялись про файл в форматі малюнка теж...
// See https://aka.ms/new-console-template for more information
using Strings;
StringClass str = new StringClass("Hello World Hello World World");
int? index = str.FindSecondIndex("World");
// А якщо індекс null, як друкувати будемо?
Console.WriteLine(index);
int sum = str.CountWordsStartingWithUpper();
Console.WriteLine(sum);
str.ReplaceWordsWithNewWord("hi");
Console.WriteLine(str);
