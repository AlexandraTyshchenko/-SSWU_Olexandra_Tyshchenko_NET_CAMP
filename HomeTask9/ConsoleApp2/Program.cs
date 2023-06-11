// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
List<OrderItem> Items = new List<OrderItem>();
Items.Add(new OrderItem("pizza", TypeOfOrder.Pizza));
Items.Add(new OrderItem("cola", TypeOfOrder.Drink));
Report report = new Report();
Waiter waiter = new Waiter();
IMediator mediator = new ConcreteMediator(waiter, report);
DessertChef dessertChef = new DessertChef(mediator);
Pizzaiolo pizzaiolo = new Pizzaiolo(mediator);
Bartender bartender = new Bartender(mediator);
Person person = new Person("Dmitruk",pizzaiolo,mediator);
Person person1 = new Person("Ivanenko", dessertChef, mediator);
person.SetNext(person1);
Person person2 = new Person("Kucherenko", bartender, mediator);
person1.SetNext(person2);
person.HandleRequest(Items);
Console.ReadLine();