using System;
using System.IO;
using System.Linq;
using task4._3;
// Форматування добре. Але числа після таблиці не прокоментовані для користувача.
Accounting accounting = new Accounting(1);
accounting.ReadFromFile();
Console.WriteLine(accounting);
Console.WriteLine(accounting.GetInfoAboutFlatByNumber(6));
Console.WriteLine(accounting.GetSubscriberWithHighestDebt());
Console.WriteLine(accounting.GetSubscribersWithZeroUsage());
Dictionary<int,double>dict = new Dictionary<int, double>(accounting.GetTotalCost());
foreach (var kvp in dict)
{
    Console.WriteLine(kvp.Key+" "+kvp.Value);
}
