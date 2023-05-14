using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class TrafficLightWithTurnLamp : TrafficLightDecorator
    {
        public bool TurnGreenLamp { get; set; } = false;//оскыльки світлофор має властивості isgreen
                                                           //isyellow isred то лампочка на повороті теж може бути об'єктом цього типу
      
        public TrafficLightWithTurnLamp()
        {

        }
        public override string ToString()
        {
            string lamp = TurnGreenLamp == true ? "Поворот включений " : "Поворот виключений ";
            return base.ToString()+lamp;
        }
    }
}
