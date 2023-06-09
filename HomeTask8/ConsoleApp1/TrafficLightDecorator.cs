﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal  class TrafficLightDecorator : ITrafficlight
    {//в декораторі в цьому випадку нема необхідності створювати абстрактний клас
     //оскільки це також може бути вже готовим об'єктом класу, а якщо потрібно додати нове поле чи функціонал
     //то можна наслідуватись від цього класу

        public bool IsRed { get ; set; }=true;
        public bool IsYellow { get; set ; } = true;
        public bool IsGreen { get ; set; } = true;
        public TrafficLightDecorator()
        {

        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsRed)
            {
                stringBuilder.Append("червоний ");
            }

            if (IsYellow)
            {
                stringBuilder.Append("жовтий ");
            }

            if (IsGreen)
            {
                stringBuilder.Append("зелений ");
            }
            return stringBuilder.ToString();
        }

        public virtual object Clone()
        {
            TrafficLightDecorator trafficLightDecorator  = new TrafficLightDecorator();
            trafficLightDecorator.IsRed = IsRed;
            trafficLightDecorator.IsYellow = IsYellow;
            trafficLightDecorator.IsGreen = IsGreen;
            return trafficLightDecorator;

        }
    }
}
