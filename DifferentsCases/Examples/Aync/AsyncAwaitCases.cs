using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentsCases.Examples.Aync
{
    public class AsyncAwaitCases
    {
        public AsyncAwaitCases() { }

        public void Main()
        {
            Console.WriteLine($"Main begin work in thread {Thread.CurrentThread.ManagedThreadId}.");

            WriteCharAsync('#').DisableAsyncWarning();
            //WriteCharAsync('#').GetAwaiter().GetResult();
            WriteChar('*');

            //var task = WriteCharAsync('#');
            //WriteChar('*');
            //task.Wait();

            Console.WriteLine($"Main begin end in thread {Thread.CurrentThread.ManagedThreadId}.");
            Console.ReadLine();
        }

        private async Task WriteCharAsync(char v)
        {
            Console.WriteLine($"WriteCharAsync '{v}' begin work in thread {Thread.CurrentThread.ManagedThreadId}.");

            await Task.Run(() => WriteChar(v));

            //var asyncResult = Task.Run(() => WriteChar(v));
            //Thread.Sleep(10000);
            //await asyncResult;

            Console.WriteLine($"WriteCharAsync '{v}' end work in thread {Thread.CurrentThread.ManagedThreadId}.");
        }

        private void WriteChar(char v)
        {
            Console.WriteLine($"WriteChar '{v}' begin work in thread {Thread.CurrentThread.ManagedThreadId}.");
            Thread.Sleep(500);

            for (int i = 0; i < 100; i++)
            {
                Console.Write(v);
                Thread.Sleep(50);
            }

            Console.WriteLine($"\nWriteChar '{v}' end work in thread {Thread.CurrentThread.ManagedThreadId}.");
        }
    }

    public static class MyAsyncExtension
    {
        public static void DisableAsyncWarning(this Task _) { }
    }
}
