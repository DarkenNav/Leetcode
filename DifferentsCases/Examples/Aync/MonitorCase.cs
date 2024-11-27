using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentsCases.Examples.Aync
{
    public static class MonitorCase
    {
        public static void Main()
        {
            object sync = new object();
            var thread1 = Create(sync, 2000);
            var thread2 = Create(sync, 500);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("sync start lock");
            lock (sync)
            {
                Monitor.Wait(sync);
                Console.WriteLine("sync end lock");
            }

            Console.WriteLine("end");
        }

        private static void Work(int sleep)
        {
            Console.WriteLine($"Work() start. Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(sleep);
            Console.WriteLine($"Work() end. Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static Thread Create(object sync, int sleep)
        {
            return new Thread(() =>
            {
                try
                {
                    Work(sleep);
                }
                finally
                {
                    lock (sync)
                    {
                        Monitor.PulseAll(sync);
                    }
                }
            });
        }
    }
}
