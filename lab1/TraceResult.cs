using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class MethodRes
    {
        public string methodName;
        public string className;
        public long time;

        public void set_time(long time)
        {
            this.time = time;
        }

    }

    class ThreadRes
    {
        public List<MethodRes> methods;
        public int id;
        public long time;

        public void addMethod(MethodRes method)
        {
            methods.Add(method);
        }

        public void addTime(long time)
        {
            this.time += time;
        }
    }

    class TraceResult
    {
        public Dictionary<int, ThreadRes> threads;

        public void addThread(int ID_Thread, ThreadRes thread)
        {
            threads.Add(ID_Thread, thread);
        }
        public ThreadRes getThreadInfo(int ID_Thread)
        {
            return threads[ID_Thread];
        }
        public Dictionary<int, ThreadRes> getResult()
        {
            return threads;
        }
    }
}
