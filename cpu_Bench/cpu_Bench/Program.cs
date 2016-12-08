using System;
using System.IO;

namespace cpu_Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            //--BENCHMARK CPU--//
            //--VARIABLES--//
            long time = DateTime.Now.Ticks;
            long lastTime = time;
            float totalTime = 0f;
            int i = 0;
            int totalTicks = 0;
            float exeTicks = 10000000f;

            //Loop for exeTicks
            while (totalTicks < exeTicks)
            {
                time = DateTime.Now.Ticks;          //Get time now
                totalTime = time - lastTime;        //Get total time

                //Write total time after 1M ticks
                if (i%1000000==0)
                {
                    Console.Clear();
                    Console.WriteLine("Time: {0}",totalTime / 10000000);
                    i = 0;
                }    
                      
                i++;
                totalTicks++;
            }

            logBenchmarkScore(totalTime, totalTicks, Convert.ToInt32(args[0]));
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
