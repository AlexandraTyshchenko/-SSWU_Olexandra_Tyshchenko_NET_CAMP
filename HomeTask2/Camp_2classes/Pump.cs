using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Pump
    {
        private readonly double _power;
        private bool _isOn;
        private double _speed;
        private  Random random;
        
        public  double MaxSpeed { get; set; }
        public bool IsOn
        {
            set { _isOn = value; }
            get { return _isOn; }
        }

        public Pump(double power,double speed)
        {
            if (Validator.CheckPower(power))
            {
                _power = power;
            }
            else _power = 4;
           _isOn = false;
            if(Validator.CheckSpeed(speed))
                _speed= speed; 
            MaxSpeed = 25;
            random = new Random();
        }
        public Pump()
        {
            _power = 4;
            _isOn = false;
            MaxSpeed = 20;
            random = new Random();
        }
        public void IncreaseSpeed(double speed)
        {
            if (Validator.CheckPumpSpeed(MaxSpeed,_speed+speed))
            { _speed += speed; }
        }
        public void DecreaseSpeed(double speed)
        {
            if(Validator.CheckPumpSpeed(MaxSpeed, _speed - speed))
            { _speed -= speed; }
        }
        public void TurnOn()
        {
            
                _isOn= true;
              _speed= (1.2 + MaxSpeed - 1.2) * random.NextDouble();//будь яка швидкість у вказаному діапазоні

        }
        public void TurnOff()
        {
            _isOn = false;
            _speed = 0;
        }
       
        public override string ToString()
        {
            return $"speed={_speed}"; 
        }
    }
}
