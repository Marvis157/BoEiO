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

        //--KONSTRUKTOR--//
        public benchmarks_collection(int speedT)
        {
            speedTicks = speedT;
        }

        public void benchCPU(int input)
        {
            if (input < speedTicks)
                benchCPU(input+1);

            Console.WriteLine("Input: {0}",input);
        }

        public void benchHDD()
        {

        }
    }
}
