using System.Text;

namespace ConsoleApp1
{
    enum Direction
    {
        East,
        West,
        North,
        South
    }

    internal delegate void Rule(TrafficLight trafficLight);
    internal delegate void State(TrafficLight trafficLight);
    internal class TrafficLight : ICloneable

    {
 
        public event Rule? SetRule;//івент для задання першого включення
        public event State? StateOutput;//для того щоб будь який формат виводу міг підписатсь на цей івент
        public bool IsRed { get; set; } = false;
        public bool IsYellow { get; set; } = false;
        public bool IsGreen { get; set; } = false;

        private Direction _from;
        private Direction _to;
        public TrafficLight(Direction from, Direction to)
        {
            _from = from;
            _to = to;
        }
        public Direction From
        {
            get
            { return _from; }
            set
            { _from = value; }
        }
        public Direction To
        {
            get { return _to; }
            set
            {
                CheckDirection(value); 
                _to = value;
            }
        }
        private void CheckDirection(Direction direction)
        {
            if (direction == _from)
            {
                throw new Exception("Напрямки 'з' і 'до' не мають співпадати");
            }
        }
        public void ChangeState()
        {
            if (IsRed && !IsYellow)
            {
                StateOutput.Invoke(this);//вивести стан світлофорів
                IsYellow = true;//спочатку включається червоне і жовте разом одночасно
                return;
            }
            if (IsRed && IsYellow)
            {
                StateOutput.Invoke(this);
                IsGreen = true;
                IsRed = false;
                IsYellow = false;
                return;
            }
            if (IsGreen)
            {
                StateOutput.Invoke(this);
                IsYellow = true;
                IsGreen = false;
                return;
            }
            if (!IsRed && IsYellow)
            {
                StateOutput.Invoke(this);
                IsRed = true;
                IsYellow = false;
                return;
            }
        }
        public void FirstRun()
        {
            SetRule(this);//перше включення, на цей івент підписаний метод з класу перехрестя
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (_from)
            {
                case Direction.North:
                    stringBuilder.Append("Північ -");
                    break;
                case Direction.South:
                    stringBuilder.Append("Південь-");
                    break;
                case Direction.East:
                    stringBuilder.Append("Схід- ");
                    break;
                case Direction.West:
                    stringBuilder.Append("Захід-");
                    break;
                default:
                    stringBuilder.Append("Unknown");
                    break;
            }
            switch (_to)
            {
                case Direction.North:
                    stringBuilder.Append("Північ\n");
                    break;
                case Direction.South:
                    stringBuilder.Append("Південь\n");
                    break;
                case Direction.East:
                    stringBuilder.Append("Схід\n");
                    break;
                case Direction.West:
                    stringBuilder.Append("Захід\n");
                    break;
                default:
                    stringBuilder.Append("Unknown");
                    break;
            }
            if (IsRed)
            {
                stringBuilder.Append("червоний ");
            }

            if (IsYellow)
            {
                stringBuilder.Append("жовтий");
            }

            if (IsGreen)
            {
                stringBuilder.Append("зелений");
            }
            return stringBuilder.ToString();
        }

        public object Clone()
        {
            TrafficLight clone = new TrafficLight(_from,_to);
            clone.IsRed = IsRed;
            clone.IsYellow = IsYellow;
            clone.IsGreen = IsGreen;
            return clone;
        }
    }
}
