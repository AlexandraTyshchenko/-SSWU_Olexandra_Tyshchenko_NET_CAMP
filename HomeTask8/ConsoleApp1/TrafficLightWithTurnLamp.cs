using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class TrafficLightWithTurnLamp : TrafficLightDecorator
    {
        public TrafficLightDecorator TurnLamp { get; set; }//оскыльки світлофор має властивості isgreen
                                                           //isyellow isred то лампочка на повороті теж може бути об'єктом цього типу
        public TrafficLightWithTurnLamp(bool isRed, bool isYellow, bool isGreen, TrafficLightDecorator TurnLamp):
            base(isRed, isYellow, isGreen)
        {
            this.TurnLamp = TurnLamp;
        }
        public TrafficLightWithTurnLamp()
        {

        }
    }
}
