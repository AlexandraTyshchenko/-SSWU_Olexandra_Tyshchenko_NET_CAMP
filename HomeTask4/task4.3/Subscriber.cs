using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4._3
{
    struct Meter_reading
    {
        
        public DateTime Date { get; set; }
        public int Input{ get; set; }
        public int Output { get; set; }
        public Meter_reading(DateTime date, int input, int output)
        {
            Date= date;
            Input= input;
            Output= output;
        }
        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendFormat("{0,-10}|{1,-6}|{2,-6}|", Date.ToString("dd.MM.yyyy"), Input, Output);
            return sb.ToString();
        }
    }
    internal class Subscriber
    {
        private int _flat;
        private string _address;
        private string _pib;
        public int Flat{get{ return _flat; }}
        public string Address{get { return _address;}}
        public string Pib { get { return _pib;}}

        private List<Meter_reading> _meter_Reading;
        public List<Meter_reading> MeterReading { get { return _meter_Reading;}

            set
            {
                _meter_Reading = new List<Meter_reading>(value);
            }
        }
        public Subscriber(int flat,string address,string pib, List<Meter_reading> meter_Readings) {
            _flat= flat;
            _address = address;
            _pib= pib;
            _meter_Reading = new List<Meter_reading>(meter_Readings);
        }
        public override string ToString()
        {
           StringBuilder sb= new StringBuilder();
            sb.AppendFormat("|{0,-2}|{1,-26}|", _flat,  _pib);
            foreach (var m in _meter_Reading)
            {
                sb.Append(m+" ");
            }
            
            sb.AppendFormat("{0,-4}|", (DateTime.Now.Subtract(_meter_Reading.Last().Date).Days));
            return sb.ToString();
        }

    }
}
