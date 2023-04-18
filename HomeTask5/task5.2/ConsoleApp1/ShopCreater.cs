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
                Console.WriteLine("1 - add department, 2 - add subdepartment to department");
                var option = Console.ReadLine();
                

                switch (option)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        AddSubDepartment();
                        break;
                    default: 
                        check= false;
                        break;
                }
            }
          
            return _shop;
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
