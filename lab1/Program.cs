using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Threading;
using TracerLib;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            var tracer = new Tracer();

            var foo = new Foo(tracer);

            var thread = new Thread(foo.MyMethod);
            thread.Start();
            thread.Join();

            thread = new Thread(foo.NotMyMethod);
            thread.Start();
            thread.Join();


            var res = tracer.GetTraceResult();


            var serialize = new Serializers();
            var consoleStream = Console.OpenStandardOutput();
            serialize.toXML(consoleStream, res);



            //string json = DataContractJsonSerializer
            //Console.WriteLine(json);

            //var serializer = new Serializers();
            //serializer.toXML(tracer.GetTraceResult());

            //foreach (TraceResult traceRes in tracer.GetTraceResult())
            //{
            //    Console.WriteLine(traceRes.time);
            //}

            Console.ReadLine();

        }
    }
}
