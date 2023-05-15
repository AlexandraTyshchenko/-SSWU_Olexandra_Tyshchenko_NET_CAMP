// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

Console.WriteLine("Hello, World!");
BritishCat cat = new BritishCat();
cat.MoveReact += () => Console.WriteLine("Quiet walking on paws");
cat.Invoke();