using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode._Examples.BoxUnbox
{
    public class BoxingUnboxingCases
    {
        public enum EnumType { None }

        public void Test()
        {
            // Example();
            //BoxingExample();

            //object box = (int)42;
            //long unbox = (long)(int)box;

            //object box = (int)42;
            //long unbox = (long)(EnumType)box;
        }

        public void Example()
        {
            List<object> mixedList = new List<object>();

            mixedList.Add("First Group:");
            for (int j = 1; j < 5; j++)
            {
                mixedList.Add(j);
            }

            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            foreach (var item in mixedList)
            {
                Console.WriteLine(item);
            }

            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // After the list elements are unboxed, the computation does
                // not cause a compiler error.
                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            Console.WriteLine("Sum: " + sum);
        }

        public void BoxingExample()
        {
            int i = 123;
            object o = i;

            i = 456;

            Console.WriteLine("The value-type value = {0}", i);
            Console.WriteLine("The object-type value = {0}", o);
        }

    }
}
