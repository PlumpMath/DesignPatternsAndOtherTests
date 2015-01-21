using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threadintests
{
    class Program
    {
        async void DisplayPrimeCouns()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(await GetPrimesCountAsync(i*100000+2, 100000));
            }
        }
        
        static Task<int> GetAnswerToLife()
        {
            var tcs = new TaskCompletionSource<int>();

            var timer = new System.Timers.Timer(5000)
            {
                AutoReset = false
            };

            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
            timer.Start();
            
            return tcs.Task;
        }
        
        static bool sharedDone;
        static readonly object locker = new Object();

        static void TestCompletitionTest()
        {
            var tcs = new TaskCompletionSource<int>();

            new Thread(() =>
             {
                 Thread.Sleep(5000);
                 tcs.SetResult(42);
             }).Start();

            Task<int> task = tcs.Task;

            Console.WriteLine(task.Result);
        }

        public static void Fire()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("Just Fire"); //String.Format("Enemy fired with {0} dmg", fireDemage)
            }
        }

        async void DisplayPrimesCount()
        {
            int result = await GetPrimesCountAsync(2, 10000);
            Console.WriteLine(result);
        }

        Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
            ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        static void Tasks()
        {
            Task<int> primeNumberTask = Task.Run(() =>

               Enumerable.Range(2, 30000).Count(
                   n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

            var awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);
            });
 
            Console.WriteLine("Task running....");
            Console.WriteLine("the answer is " + primeNumberTask.Result);
        }

         static void Main(string[] args)
        {
            new TestAwaitUI();
            
            //var threadingHelper = new ThreadingHelper();

            //threadingHelper.Delay(5000).GetAwaiter().OnCompleted(() => Console.WriteLine(42));
            //Console.WriteLine("And now something completely different");

            //var awaiter = GetAnswerToLife().GetAwaiter();
            //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));
            
            //Tasks();
            //TestCompletitionTest();


            //var signal = new ManualResetEvent(false);

            //Task task = Task.Run(() =>
            //{       
            //    Thread.Sleep(2000);    
            //    Console.WriteLine("Foo");
            //});

            //Console.WriteLine(task.IsCompleted);
            //task.Wait();
            //new Thread(() =>
            //    {
            //        Console.WriteLine("Waiting for signal...");
            //        signal.WaitOne();
            //        signal.Dispose();
            //        Console.WriteLine("Got signal");

            //    }).Start();

            //Thread.Sleep(2000);
            //signal.Set();
    
             //Thread t = new Thread(Print);
            //t.Start("Printhihs");


            //Thread exhaustiveThread = new Thread(Fire);
            //exhaustiveThread.IsBackground = false;
            //exhaustiveThread.Start();
            //Go();



            //Thread enemyThread = new Thread(Fire);
            //enemyThread.Start();

            Console.ReadLine();

        }

        private static void Print(object obj)
        {
            string message = (string)obj;
            Console.WriteLine(message);
        }

        private static void Go()
        {
            lock (locker)
            {
                if (!sharedDone)
                {
                    Console.WriteLine("Done");
                    sharedDone = true;
                }
            }
        }
    }
}
