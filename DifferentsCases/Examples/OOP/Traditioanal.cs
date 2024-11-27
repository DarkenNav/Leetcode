using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentsCases.Examples.OOP
{
    public class Traditioanal
    {
        public class A 
        { 
            public virtual int Foo()
            {
                return 1;
            }
        }

        public class B : A
        {
            public new int Foo()
            {
                return 2;
            }
        }

        public class C : A
        {
            public override int Foo()
            {
                return 3;
            }
        }

        public void Cases()
        {
            var a = new A();
            var aFoo = a.Foo();

            var b = new A();
            var bFoo = b.Foo();

            A b1 = new B();
            var b1Foo = b1.Foo();

            B b2 = new B();
            var b2Foo = b2.Foo();

            var c = new A();
            var cFoo = c.Foo();

            A c1 = new C();
            var c1Foo = c1.Foo();
        }

    }
}
