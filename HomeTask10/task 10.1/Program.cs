// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
CardIdentifier cardIdentifier= new CardIdentifier();
ICard card=null;
try
{
    card = cardIdentifier.Create("3782 8224 6310005");
    Console.WriteLine(card.PaymentService);
}
catch(Exception e)
{
    Console.WriteLine(e);
}
//“378282246310005”