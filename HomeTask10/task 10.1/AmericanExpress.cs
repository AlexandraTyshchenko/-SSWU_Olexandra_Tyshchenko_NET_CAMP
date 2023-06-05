using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AmericanExpress : ICard
    {
        public AmericanExpress(string number)
        {
            Number = number;
        }
        public string PaymentService { get; } = "American Express";
        public string Number { get; set; }
    }
}
