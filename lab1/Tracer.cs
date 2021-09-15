using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    struct TraceResult
    {
        public string methodName;
        public string className;
        public long time;
    }

    class Tracer : ITracer
    {
        private readonly List<TraceResult> traceResult = new List<TraceResult>();
        private Stopwatch stopwatch;
        //private syncRoot = new SyncRoot

        public Tracer()
        {
            stopwatch = new Stopwatch();
        }

        // вызывается в начале замеряемого метода
        public void StartTrace()
        {
            stopwatch.Start();
        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {

            stopwatch.Stop();
            TraceResult traceRes = new TraceResult();
            traceRes.time = stopwatch.ElapsedMilliseconds;


            traceResult.Add(traceRes);
        }

        // получить результаты измерений  
        public List<TraceResult> GetTraceResult()
        {
            return traceResult;
        }
    }
    
}
