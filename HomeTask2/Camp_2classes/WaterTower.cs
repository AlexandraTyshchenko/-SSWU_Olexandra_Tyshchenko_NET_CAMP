using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class WaterTower
    {
        private readonly double _maxLevelOfWater;
        private double _currentLevel;
        private  Pump _pump;
        public double CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }
        public double MaxLevelOfWater
        {
            get { return _maxLevelOfWater;}
        }
        public WaterTower(double maxLevelOfWater, Pump pump)
        {
            if (Validator.CheckMaxLevelOfWater(maxLevelOfWater))
            {
                _maxLevelOfWater = maxLevelOfWater;

            }
            else {
                _maxLevelOfWater = 1000;
            }
            _pump= pump;     
        }
        public void TurnOnPump()
        {
          
                while (_currentLevel <= MaxLevelOfWater)
                {
                    _currentLevel++;
                    _pump.TurnOn();
                }
                _pump.TurnOff();

            

        }
        
        public override string ToString()
        {
            return $"max Level Of Water = {_maxLevelOfWater}\ncurrent Level of water = {_currentLevel}";
        }
    }
        
}
