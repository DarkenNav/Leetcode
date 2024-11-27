using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentsCases.Examples.OOP
{
    public interface IMyInterface
    {
        public int c { get; set; }
        public int D(int a, int b)
        {
            return a + b;
        }

        public int E(int a);

    }

    public class MyClass : IMyInterface
    {
        // Impliment
        public int c { get ; set; }

        // Impliment
        public int E(int a)
        {
            throw new NotImplementedException();
        }
    }

    public class MyClass2
    {
        public void DoSomthing()
        {
            IMyInterface test = new MyClass();
            var result = test.D(1, 2);

            var result2 = ((MyClass)test).E(1);
        }
    }
}
