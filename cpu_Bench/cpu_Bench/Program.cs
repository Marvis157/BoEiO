using System;
using System.IO;

namespace cpu_Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            //--BENCHMARK CPU--//
            long time = DateTime.Now.Ticks;
            long lastTime = time;
            float totalTime = 0f;
            int i = 0;
            int totalTicks = 0;
            float exeTicks = 10000000f;

            while (totalTicks < exeTicks)
            {
                time = DateTime.Now.Ticks;
                totalTime = time - lastTime;
                if(i%100000==0)
                {
                    Console.Clear();
                    Console.WriteLine(totalTime / 10000000);
                    i = 0;
                }          
                i++;
                totalTicks++;
            }

            logBenchmarkScore(totalTime, totalTicks, 1);
            //Console.WriteLine("Completed...");
            //Console.ReadKey();
        }

        static void logBenchmarkScore(float ttlTime, int ttlTicks, int core)
        {
            float score = ttlTicks / ttlTime;
            StreamWriter sw = new StreamWriter(core.ToString()+".txt");
            sw.WriteLine("Core: {0} | Total time: {1} | Total ticks: {2} | Score: {3}",core, ttlTime, ttlTicks, score*100);
            sw.Flush();
            sw.Close();
        }
    }
}
