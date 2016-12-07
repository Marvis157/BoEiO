using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEiO
{
    class benchmarks_collection
    {
        //--VARIABLES--//
        int speedTicks;
        int fixTick = 0;

        //--KONSTRUKTOR--//
        public benchmarks_collection(int speedT)
        {
            speedTicks = speedT;
        }

        public void benchCPU(int input)
        {
            /*while (true)
            {
                if (input < speedTicks)
                {
                    for(int diff = 0; diff < speedTicks; diff++)
                        benchCPU(input + 1);
                }  
                //Console.WriteLine("Loop: {0}", fixTick);
                fixTick++;
            }*/

            //Start another benchmark
        }

        public void benchHDD()
        {

        }
    }
}
