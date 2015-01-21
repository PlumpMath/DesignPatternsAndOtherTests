using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverAgain
{
    class Shop : IObserver
    {
        private string name;
        private float price;

        public Shop(string name)
        {
            this.name = name;
        }
 
        public void Update(float price)
        {
            this.price = price;

            Console.WriteLine(@"Price at{0} is now{1}", name, price);
        }
    }
}
