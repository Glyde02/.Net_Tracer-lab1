using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    interface ITracer
    {
        void StartTrace();
        void StopTrace();
        List<TraceResult> GetTraceResult();
    }
}
