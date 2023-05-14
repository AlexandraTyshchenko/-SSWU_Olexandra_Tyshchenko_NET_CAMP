using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LaneDecorator : ILane
    {

        public Direction LaneDirection { get; set; }
        public LaneDecorator( Direction direction)//спільне що має унаслідуватись це конструктор
        {
            LaneDirection = direction;
        }
        public LaneDecorator()
        {

        }
        public override string ToString()
        {
            return "";//щоб intersection привести у тип стрінг і не залежати чи буде доріжка з світлофором чи без
        }
    }
}
