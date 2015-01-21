using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverAgain
{
    class ASubject
    {
        public delegate void StatusUpdate(float price);
        public event StatusUpdate OnStatusUpdate = null;

        public void Attach(Shop product)
        {
            OnStatusUpdate += new StatusUpdate(product.Update);
        }

        public void Detach(Shop product)
        {
            OnStatusUpdate -= new StatusUpdate(product.Update);
        }

        public void Notify(float price)
        { 
            if(OnStatusUpdate != null)
            {
                OnStatusUpdate(price);
            }
        }
    }
}
