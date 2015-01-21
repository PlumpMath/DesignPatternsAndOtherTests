using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threadintests
{
    class Enemy
    {
        public Enemy()
        {
 
        }
        
        public void StartFire()
        {
            Thread enemyThread = new Thread(Fire);
            enemyThread.Start();
        }

        private int fireDemage = 10;
        
        //enemy firing constantly
        public void Fire()
        {
            for (int i = 0; i < 100; i++)
             {
                Console.WriteLine("Just Fire"); //String.Format("Enemy fired with {0} dmg", fireDemage)
            } 
        }
    }
}
