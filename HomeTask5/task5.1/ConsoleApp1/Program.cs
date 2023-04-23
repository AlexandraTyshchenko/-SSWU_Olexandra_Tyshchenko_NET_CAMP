
//Розв'язано тільки дискретний випадок. Координати дерев можуть бути дійсними...
// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
List<Tree> c= new List<Tree>();
c.Add(new Tree(3, 5));
c.Add(new Tree(2, 3));
c.Add(new Tree(6, 2));
c.Add(new Tree(3, 1));
c.Add(new Tree(7, 1));
c.Add(new Tree(10, 3));
c.Add(new Tree(3, 2));
c.Add(new Tree(4, 4));
Garden garden = new Garden(c);
Console.WriteLine(garden);


c.Add(new Tree(11, 11));
Garden garden1 = new Garden(c);
Console.WriteLine(garden1);
Console.WriteLine(garden1 == garden);
Console.WriteLine(garden1 != garden);
Console.WriteLine(garden1 >= garden);
Console.WriteLine(garden1 <= garden);
