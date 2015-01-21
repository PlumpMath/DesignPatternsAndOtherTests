using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverAgain
{
    interface IObserver
    {
        void Update(float price);
    }
}
