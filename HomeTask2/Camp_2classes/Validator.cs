using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    internal class Validator
    {
        public static bool IsValidUserConsumption(double consumption)
        {
            if(consumption < 0)
            {
                return false;
            }return true;

        }
        public static bool CheckUserConsumption(WaterTower waterTower,User user)
        {
            if (user.Consumption > waterTower.CurrentLevel)
            {
                return false;
            }
            return true;
        }
       public  static bool CheckWaterTowerCurrentLevel(WaterTower waterTower)
        {
            if(waterTower.CurrentLevel>waterTower.MaxLevelOfWater || waterTower.CurrentLevel<0 ) { 
                return false;
            }  return true;
        }
        public static bool CheckPumpSpeed(double maxSpeed,double currentspeed)
        {
            if (currentspeed > maxSpeed || currentspeed < 0)
                return false;
            return true;
        }
        public static bool CheckMaxLevelOfWater(double maxLevelOfWater)
        {
            if(maxLevelOfWater < 0)
                return false;
            return true;
        }
        public static bool CheckSpeed(double speed)
        {
            if (speed < 0)
            {
                return false;
            }return true;
        }
        public static bool CheckPower(double power)
        {
            if (power<2)
            {
                return false;
            }
            return true;
        }
    }
}
