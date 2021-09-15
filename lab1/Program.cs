using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            var tracer = new Tracer();

            var foo = new Foo(tracer);
            foo.MyMethod();

            

            foreach(TraceResult traceRes in tracer.GetTraceResult())
            {
                Console.WriteLine(traceRes.time);
            }

            Console.ReadLine();

        }
    }
}
