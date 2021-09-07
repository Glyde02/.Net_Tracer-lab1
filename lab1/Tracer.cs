using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    struct TraceResult
    {
        public string methodName;
        public string className;
        public int time;
    }

    class Tracer : ITracer
    {
        private List<TraceResult> traceResult = new List<TraceResult>();

        // вызывается в начале замеряемого метода
        public void StartTrace()
        {

        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {
        }

        // получить результаты измерений  
        public List<TraceResult> GetTraceResult()
        {
            return traceResult;
        }
    }
    
}
