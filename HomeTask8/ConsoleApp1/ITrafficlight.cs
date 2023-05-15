using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface ITrafficlight:ICloneable
    {
        public bool IsRed { get; set; }
        public bool IsYellow { get; set; }
        public bool IsGreen { get; set; }
    }
}
