using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Report:IReciever
    {
        private List<Person> people=new List<Person>();

        public void Recieve(object ob)
        {
            if(ob is Person) { 
                people.Add((Person)ob);
            }
        }
    }
}
