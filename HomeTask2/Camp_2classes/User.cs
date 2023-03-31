using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class User
    {
        private double _consumption;
        public double Consumption
        { get { return _consumption; }}//тільки отримати можна
        public User(double consumption)
        {
            if (Validator.IsValidUserConsumption(_consumption))
                _consumption = consumption;
            else
                throw new Exception("User consumption is invalid");
        }
        public override string ToString()
        {
            return $"user consumption is {_consumption}";
        }
        
    }
}
