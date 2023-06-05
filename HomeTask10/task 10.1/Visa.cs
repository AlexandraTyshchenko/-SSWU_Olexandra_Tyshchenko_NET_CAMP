using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Visa : ICard
    {
        public Visa(string number)
        {
            Number= number;
        }
        public string PaymentService { get; } = "Visa";
        public string Number { get; set; }
    }
}
