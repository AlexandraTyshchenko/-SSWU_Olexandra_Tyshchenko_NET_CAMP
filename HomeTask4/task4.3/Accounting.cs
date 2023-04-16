using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4._3
{
    internal class Accounting
    {
        private List<Subscriber> _subscribers;
        private StreamReader _sr;
        public int Quarter { get; set; }
        public double Price{ get; set; }
        private Dictionary<int, double> _costs;
        public Accounting(List<Subscriber> subscribers, int quarter, double price)
        {
            _subscribers = new List<Subscriber>(subscribers);
            Quarter = quarter;
            _sr = new StreamReader("quarter" + Quarter + ".txt");
            Price = price;
        }
        public Accounting(int quarter)
        {
            _subscribers = new List<Subscriber>();
            Quarter= quarter;
            _sr = new StreamReader("quarter" + Quarter + ".txt");
            Price = 1.44f;
        }
        public void ReadFromFile()
        {
            string line =  _sr.ReadLine();
            string[] arr = null;
            int[] maxLengths = null;
            int indexer = 1;
            int flat=0;
            string address=string.Empty;
            string pib = string.Empty;
            List<Meter_reading> meter_Readings= new List<Meter_reading>();
            DateTime Date;
            int Input;
            int Output;
            while (line != null)
            {
                arr = line.Split(',');
              
                if(indexer % 2 != 0)
                {
                    flat = Convert.ToInt32(arr[0]);
                    address= arr[1];
                    pib = arr[2];
                }
                else
                {
                  
                    for (int i = 0; i < arr.Length; i += 3)
                    {
                        Date = DateTime.ParseExact(arr[i], "dd.MM.yyyy", null);
                        Input = Convert.ToInt32(arr[i + 1]);
                        Output = Convert.ToInt32(arr[i + 2]);
                        meter_Readings.Add(new Meter_reading(Date, Input, Output));
                    }
                    _subscribers.Add(new Subscriber(flat, address, pib, meter_Readings));
                    meter_Readings.Clear();
                }
                
                line = _sr.ReadLine();
                indexer++;
            }
            _sr.Close();
        }
        public string GetInfoAboutFlatByNumber(int number)
        {
            string result = _subscribers.FirstOrDefault(s => s.Flat == number).ToString();
            return result ;
        }
        public Subscriber GetSubscriberWithHighestDebt()
        {
            Dictionary<Subscriber,int> dict = new Dictionary<Subscriber,int>();
            
            foreach(Subscriber subscriber in _subscribers)
            {
                dict.Add(subscriber, subscriber.MeterReading.Sum(item => item.Output - item.Input));//спожита електроенергія за 1 квартал(сума різниць показників)
            }
           return dict.OrderByDescending(x => x.Value).First().Key;//відсортований словник за спаданням і перше значення буде повернуто
            
        }
        public Subscriber GetSubscribersWithZeroUsage()
        {
            Dictionary<Subscriber, int> dict = new Dictionary<Subscriber, int>();

            foreach (Subscriber subscriber in _subscribers)
            {
                dict.Add(subscriber, subscriber.MeterReading.Sum(item => item.Output - item.Input));//спожита електроенергія за 1 квартал(сума різниць показників)
            }
            return dict.FirstOrDefault(x => x.Value == 0).Key;
        }
        public Dictionary<int,double> GetTotalCost()
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();

            foreach (Subscriber subscriber in _subscribers)
            {
                dict.Add(subscriber.Flat, subscriber.MeterReading.Sum(item => (item.Output - item.Input)*Price));//спожита електроенергія за 1 квартал(сума різниць показників)
            }
            return dict;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("|{0,-2}|{1,-26}|{2,-10}|{5,-6}|{6,-6}|{3,-10}|{5,-6}|{6,-6}|{4,-10}|{5,-6}|{6,-6}|{7,-15}", "N", "pib",new DateTime(2022,Quarter,2).ToString("MMMM"), new DateTime(2022, Quarter+1, 2).ToString("MMMM"), new DateTime(2022, Quarter+2, 2).ToString("MMMM"), "input", "output","days after last meter");//new DateTime(2022,Quarter,2) - витягую назву місяця залежно від кварталу
            sb.Append("\n-------------------------------------------------------------------------------------------------------------------\n");
            foreach (var sub in _subscribers)
            {
                sb.Append(sub.ToString()+"\n");
            }
            return sb.ToString();
        }
    }

}
