using ConsoleApp1;
IVisitor visitor = new DeliveryCalculator(20);
List<IItem> items = new List<IItem>() { new Electronics(40, 40, 5), new Flowers(3, 3, 3) };
Client client= new Client();
client.CalculateDeliveryCost(items, visitor);
foreach(IItem item in items)
{
    Console.WriteLine(item.DeliveryCost);
}