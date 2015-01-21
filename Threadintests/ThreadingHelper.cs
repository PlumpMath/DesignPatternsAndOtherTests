using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threadintests
{
    public class ThreadingHelper
    {
        public ThreadingHelper()
        {
            //var taskCompletitionSource = new TaskCompletionSource<object>();
            //Task task = taskCompletitionSource.Task;
        }
        
        public Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();

            var timer = new System.Timers.Timer(5000)
            {
                AutoReset = false
            };

            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
            timer.Start();

            return tcs.Task;
        }

        
      
    }
}
