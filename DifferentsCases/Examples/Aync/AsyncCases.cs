using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode._Examples.Aync
{
    public class AsyncCases
    {
        public void Test()
        {
             WaitWithoutStart();

            //ConsoleDrawSomesing.ClockAsync();
            //ConsoleDrawSomesing.StartMoveAsync();

        }

        public void WaitWithoutStart()
        {
            var task = new Task(() =>
            {
                Console.WriteLine("a1");
                Task.Delay(2000);
                Console.WriteLine("a2");
            });
            //task.Start();
            // Бесконечное ожидание т.к. нет запуска задачи
            task.Wait();
            Console.WriteLine("a3");
        }

        public string Message {  get; set; }
        public async Task TestRun(string s)
        {
            await Task.Delay(5000);
            await Task.Run(() => { Message = s; });
        }
    }
}
