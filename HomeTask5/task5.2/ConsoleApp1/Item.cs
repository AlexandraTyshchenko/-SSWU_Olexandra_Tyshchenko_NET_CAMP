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
        public int Height { get; }
        public int Width { get; }
        public int Length { get; }
        public Item()
        {
            GenerateID();
        }
        public Item(string name, int height, int length, int width)
        {
            GenerateID();
            _name = name;
            Height = height;
            Width = length;
            Length = width;
        }

        private void GenerateID()
        {
            var random = new Random();
            Id = random.Next(1, 1000);
        }

        public override string ToString()
        {
            return $"Item ID: {Id}, Name: {_name}, Height: {Height}, Length: {Length}, Width: {Width}\n";
        }
    }
}