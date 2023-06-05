using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MasterCard : ICard
    {
        public MasterCard(string number)
        {
            Number = number;
        }
        public string PaymentService { get; } = "MasterCard";
        public string Number { get; set; }
    }
}
