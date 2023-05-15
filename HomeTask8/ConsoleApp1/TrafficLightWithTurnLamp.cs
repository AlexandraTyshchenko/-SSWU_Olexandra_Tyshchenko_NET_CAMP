using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class TrafficLightWithTurnLamp : TrafficLightDecorator
    {
        public bool TurnGreenLamp { get; set; } = true;//оскыльки світлофор має властивості isgreen
                                                           //isyellow isred то лампочка на повороті теж може бути об'єктом цього типу
      
        public TrafficLightWithTurnLamp()  
        {

        }
        public override string ToString()
        {
            string lamp = TurnGreenLamp == true ? "Поворот включений " : "Поворот виключений ";
            return base.ToString()+lamp;
        }
        public override object Clone()
        {
            TrafficLightWithTurnLamp trafficLightWithTurnLamp = new TrafficLightWithTurnLamp();
            trafficLightWithTurnLamp.TurnGreenLamp = TurnGreenLamp;
            trafficLightWithTurnLamp.IsRed = IsRed;
            trafficLightWithTurnLamp.IsYellow = IsYellow;
            trafficLightWithTurnLamp.IsGreen = IsGreen;
            return trafficLightWithTurnLamp;

        }
    }
}
