using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1
{
    interface ITracer
    {
        void StartTrace();
        void StopTrace();
        //List<TraceResult> GetTraceResult();
    }


    class MethodTrace : ITracer
    {
        private Stopwatch stopwatch;
        private MethodRes method;

        public MethodTrace()
        {
            this.stopwatch = new Stopwatch();
        }

        public void StartTrace()
        {
            stopwatch.Start();
        }

        public void StopTrace()
        {
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            method.set_time(time);
        }
        public MethodRes GetTraceRes()
        {
            return method;
        }
    }

    class ThreadTrace
    {
        private ThreadRes thread;
        private Stack<MethodTrace> StackList;

        public ThreadTrace()
        {
            
        }

        public void StartTrace()
        {
            var new_MethodTrace = new MethodTrace();
            StackList.Push(new_MethodTrace);

            new_MethodTrace.StartTrace();
        }

        public void StopTrace()
        {
            var lastTrace = StackList.Pop();
            lastTrace.StopTrace();

            var method = lastTrace.GetTraceRes();

            if (StackList.Count > 0)
            {
                //continue next method
            }
            else
            {   
                //end of method's list
                thread.addTime(method.time);
                thread.addMethod(method);
            }

        }
    }

    class Tracer : ITracer
    {

        private Dictionary<int, ThreadTrace> thread_objects;
        private TraceResult threads;
        //private TraceResult threads;


        public Tracer()
        {
            threads = new TraceResult(); 

        }

        // вызывается в начале замеряемого метода
        public void StartTrace()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;

            ThreadTrace thread;
            if (thread_objects.ContainsKey(threadID))
            {
                thread = thread_objects[threadID];
            }
            else
            {
                //create new threadTrace
            }

            thread.StartTrace();

        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;

            if(thread_objects.ContainsKey(threadID))
            {
                thread_objects[threadID].StopTrace();
            }


            //stopwatch.Stop();
            //TraceResult traceResult = new TraceResult();
            //traceResult.time = stopwatch.ElapsedMilliseconds;
            //traceResult.className = type;
            //traceResult.methodName = method;

            //traceRes.AddRes(traceResult);

            //traceRes.AddRes(traceRes);
        }

        // получить результаты измерений  
        public TraceResult GetTraceResult()
        {
            return threads;
        }
    }
    
}
