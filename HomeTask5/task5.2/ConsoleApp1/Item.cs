using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class Item
    {
        public int Id { get; set; }
        private string _name;
        private int _hight;
        private int _length;
        private int _width;
        public Item()
        {
            GenerateID();
        }
        public Item(string name, int hight, int length, int width)
        {
            GenerateID();
            _name = name;
            _hight = hight;
            _length = length;
            _width = width;
        }

        private  void GenerateID()
        {
            var random = new Random();
            Id =  random.Next(1, 1000);
        }
    }
}
