using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace BoEiO
{
    class benchmarks_collection
    {
        public void benchCPU()
        {
            //--CORES VARIABLE--//
            int cores = Environment.ProcessorCount;

            //--Create threads up to 8 cores--//
            Thread core1 = new Thread(() => startBenchCPU(1));
            Thread core2 = new Thread(() => startBenchCPU(2));
            Thread core3 = new Thread(() => startBenchCPU(3));
            Thread core4 = new Thread(() => startBenchCPU(4));
            Thread core5 = new Thread(() => startBenchCPU(5));
            Thread core6 = new Thread(() => startBenchCPU(6));
            Thread core7 = new Thread(() => startBenchCPU(7));
            Thread core8 = new Thread(() => startBenchCPU(8));

            if (cores > 0) {core1.Start();}
            if (cores > 1) {core2.Start();}
            if (cores > 2) {core3.Start();}
            if (cores > 3) {core4.Start();}
            if (cores > 4) {core5.Start();}
            if (cores > 5) {core6.Start();}
            if (cores > 6) {core7.Start();}
            if (cores > 7) {core8.Start();}

            if (cores > 0) { core1.Join(); }
            if (cores > 1) { core2.Join(); }
            if (cores > 2) { core3.Join(); }
            if (cores > 3) { core4.Join(); }
            if (cores > 4) { core5.Join(); }
            if (cores > 5) { core6.Join(); }
            if (cores > 6) { core7.Join(); }
            if (cores > 7) { core8.Join(); }
            //--END--//

            loadCPUScore(cores);
        }

        public void benchHDD()
        {

        }

        private void startBenchCPU(int core)
        {
            //Start another benchmark
            Process prc = Process.Start("cpu_Bench.exe", core.ToString());
            prc.WaitForExit();
        }

        private void loadCPUScore(int ttlCores)
        {
            string[] rawData = new string[ttlCores];
            string[] tempData = new string[4];
            float ttlScore = 0;
            if (File.Exists("log.txt"))
                File.Delete("log.txt");
            StreamWriter sw = new StreamWriter("log.txt",true);
            Console.Clear();

            Console.WriteLine("------Score------"); // => Write to Console
            sw.WriteLine("------Score------");      // => Write to log.txt

            for (int i = 1; i-1 < ttlCores;i++)
            {
                rawData[i-1] = loadData(i);
            }

            for(int i = 0; i < rawData.Length;i++)
            {
                //Core;Total time;Total ticks;Score
                tempData = rawData[i].Split(';');

                //Writes to console
                Console.WriteLine("----Core {0}----", tempData[0]);
                Console.WriteLine("--Time: {0}--", tempData[1]);
                Console.WriteLine("--Ticks: {0}--", tempData[2]);
                Console.WriteLine("--Score: {0}--\n\n", tempData[3]);

                //Writes to Log.txt
                sw.WriteLine("----Core {0}----", tempData[0]);
                sw.WriteLine("--Time: {0}--", tempData[1]);
                sw.WriteLine("--Ticks: {0}--", tempData[2]);
                sw.WriteLine("--Score: {0}--\n\n", tempData[3]);

                ttlScore += float.Parse(tempData[3]);
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("Total score: {0}", ttlScore);

            sw.WriteLine("--------------------");
            sw.WriteLine("Total score: {0}", ttlScore);
            sw.Flush();
            sw.Close();
        }

        private string loadData(int coreLog)
        {
            StreamReader sr = new StreamReader(coreLog.ToString()+".txt");
            return sr.ReadLine();
        }
    }
}
