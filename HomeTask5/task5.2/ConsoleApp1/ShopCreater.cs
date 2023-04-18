using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class ShopCreater
    {
        private Shop _shop;
        public ShopCreater()
        {
        }
        public Shop CreateShop()
        {
            _shop = new Shop();
            bool check = true;
            while (check)
            {
                Console.WriteLine("1 - add department, 2 - add subdepartment to department, 3 - Add Items To Department" +
                    "4 - show shop" +
                    "any key to save changes ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        AddSubDepartment();
                        break;
                    case "3":
                        AddItemsToDepartment();
                        break;
                    case "4":
                        Console.WriteLine(_shop);
                        break;
                    default: 
                        check= false;
                        break;

                }
            }
            return _shop;
        }
        private void AddItemsToDepartment()
        {
            Department department = null;
            Console.WriteLine(_shop);
            while (true)
            {
                Console.WriteLine("choose department");
                string name = Console.ReadLine();
                try
                {
                    if (department == null)
                        department = _shop.GetDepartment(name);
                    else
                        try
                        {
                            department = department.GetSubepartment(name);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            continue;
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return;
                }
               

                Console.WriteLine($"if you want to move upper press 1\n" +
                    $"if you want to move to {department.Level + 1} level, press 2\n" +
                    "if you want to add department press any key"
                    );
                var option = Console.ReadKey();
                if (option.KeyChar == '1')
                {
                    department = department.ParentDepartment;
                }
                if (option.KeyChar != '2' && option.KeyChar != '1')
                {
                    department.AddDepartmentBox(AddItemsToDepartmentBoxes());
                    Console.WriteLine(_shop);
                    return;
                }

            }

        }
        private DepartmentBox AddItemsToDepartmentBoxes()
        {
            List<ItemBox> ItemBoxes = new List<ItemBox>();
            while (true)
            {
                ItemBoxes.Add(AddItemsToItemBox());
                Console.WriteLine("Enter 1 to stop adding ItemBoxes, or any other key to continue:");
                var keyPressed = Console.ReadKey();
                if (keyPressed.KeyChar == '1')
                {
                    break;
                }
            }
            return new DepartmentBox(ItemBoxes);
        }
        private ItemBox AddItemsToItemBox()
        {
            List<Item> items = new List<Item>();
            string name;
            int length;
            int height;
            int width;

            while (true)
            {
                Console.WriteLine("Enter item name:");
                name = Console.ReadLine();

                Console.WriteLine("Enter item length:");
                length = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter item height:");
                height = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter item width:");
                width = Convert.ToInt32(Console.ReadLine());

                items.Add(new Item(name, height, length, width));
                Console.WriteLine();

                Console.WriteLine("Enter 1 to stop adding items, or any other key to continue:");
                var keyPressed = Console.ReadKey();
                if (keyPressed.KeyChar == '1')
                {
                    break;
                }
            }return new ItemBox(items);
        }
       
        private void AddSubDepartment()
        {
            Console.WriteLine(_shop);   
            Department department=null;
            while (true){
                Console.WriteLine("choose department");
                string name = Console.ReadLine();
                try
                {
                    if (department == null)//якщо це перший відділ то на рівні магазину до нього доступитись
                        department = _shop.GetDepartment(name);
                    else
                        try
                        {
                            department = department.GetSubepartment(name);//перейде до наступного відділу
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            continue;
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return;
                }
                Console.WriteLine("choose name of subdepartment");
                string subdepartmentname = Console.ReadLine();
                try
                {
                    department.AddSubdepartment(new Department(subdepartmentname, department));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                Console.WriteLine(_shop);
                Console.WriteLine($"if you want to one more subdepartment for {department.Level} level press 1\n" +
                    $"if you want to add  subdepartment for {department.Level+1} level, press 2\n"+
                    "if you want to quit press any key"
                    );
                string option = Console.ReadLine();
                if (option == "1")
                {
                    department =department.ParentDepartment;
                }
                if (option != "2" && option != "1")
                {
                    return;
                }

            }
         

        }
        private void AddDepartment()
        {
            Console.WriteLine("name of department");
            string name = Console.ReadLine();
            try
            {
                _shop.AddDepartment(new Department(name));
            }
            catch(Exception ex) 
            { 
               Console.WriteLine($"{ex.Message}");
                return;
            }
            Console.WriteLine("Department was created");
        }
    }
}
