using System;
using System.Diagnostics;
using System.Threading;

namespace BoEiO
{
    class benchmarks_collection
    {
        //--VARIABLES--//
        int speedTicks;

        //--KONSTRUKTOR--//
        public benchmarks_collection(int speedT)
        {
            speedTicks = speedT;
        }

        public void benchCPU()
        {
            //--CORES VARIABLE--//
            int cores = Environment.ProcessorCount;

            //Create threads up to 8 cores
            if (cores > 0) { Thread core1 = new Thread(() => startBenchCPU(1)); core1.Start(); }
            if (cores > 1) { Thread core2 = new Thread(() => startBenchCPU(2)); core2.Start(); }
            if (cores > 2) { Thread core3 = new Thread(() => startBenchCPU(3)); core3.Start(); }
            if (cores > 3) { Thread core4 = new Thread(() => startBenchCPU(4)); core4.Start(); }
            if (cores > 4) { Thread core5 = new Thread(() => startBenchCPU(5)); core5.Start(); }
            if (cores > 5) { Thread core6 = new Thread(() => startBenchCPU(6)); core6.Start(); }
            if (cores > 6) { Thread core7 = new Thread(() => startBenchCPU(7)); core7.Start(); }
            if (cores > 7) { Thread core8 = new Thread(() => startBenchCPU(8)); core8.Start(); }

        }

        public void benchHDD()
        {

        }

        private void startBenchCPU(int core)
        {
            //Start another benchmark
            Process.Start("cpu_Bench.exe", core.ToString());
        }
    }
}
