﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum DirectionType
    {
        East,
        West,
        North,
        South
    }
    internal class Direction
    {
        public DirectionType From { get; set; }
        public DirectionType To { get; set; }
        public Direction(DirectionType from, DirectionType to)
        {
            if (from == to)
            {
                throw new Exception("Не можна передавати однакові напрямки 'з' і 'до'");
            }
            From = from;
            To = to;
        }
        
    }
}
