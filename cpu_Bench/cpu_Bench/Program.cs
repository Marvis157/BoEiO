using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace cpu_Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            //--BENCHMARK CPU--//
            long time = DateTime.Now.Ticks;
            long lastTime = time;
            long nowTime=0;

            while (true)
            {
                time = DateTime.Now.Ticks;
                nowTime = time - lastTime;
                Console.Write(nowTime/10000000);
                Thread.Sleep(100);
                Console.Clear();
            }
            
            Console.ReadKey();
        }
    }
}
