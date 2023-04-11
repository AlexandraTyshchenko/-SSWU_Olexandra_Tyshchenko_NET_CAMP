using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Simulator
    {
        private User _user;

        private WaterTower _waterTower;
        private Pump _pump;
        
//Хто породжує насос, користувача, вежу і т.д.,
        
        public Simulator(User user, WaterTower waterTower, Pump pump)
        {
            _user=user;
            _waterTower = waterTower;
            _pump = pump;
        }
        public bool Check()
        {
            return true;
            //у разі поломки насоса буде повертати false, причини поломки ще не придумала
        }
        public void ChangePump()
        {

        }
        public void UserConsume()
        {
            _waterTower.CurrentLevel -= _user.Consumption;
        }
        public void Execute()
        {
            if (!Check())
            {
                new Exception("temporary problems with pump");
            }
            if (Validator.CheckUserConsumption(_waterTower, _user))
                UserConsume();//added this function 4.04 update
            else
                _waterTower.TurnOnPump();
        }
       

    }
}
