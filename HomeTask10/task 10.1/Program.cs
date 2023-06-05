// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
CardIdentifier cardIdentifier= new CardIdentifier();
ICard card=null;
try
{
    card = cardIdentifier.Create("4003 7891 0020 5381");
    Console.WriteLine(card.PaymentService);
}
catch(Exception e)
{
    Console.WriteLine(e);
}
