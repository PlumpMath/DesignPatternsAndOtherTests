using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcmt;

namespace ObserverAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            DummyProduct product = new DummyProduct();

            Shop shop1 = new Shop("Shop 1");
            Shop shop2 = new Shop("Shop 2");
            Shop shop3 = new Shop("Shop 3");
            Shop shop4 = new Shop("Shop 4");

            product.Attach(shop1);
            product.Attach(shop2);
            product.Attach(shop3);
            product.Attach(shop4);

            product.ChangePrice(26.0f);

            Console.ReadLine();
        }
    }
}
