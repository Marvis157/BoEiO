using System;

namespace BoEiO
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI cnsl = new ConsoleUI();
            benchmarks_collection bnch;

            //--VARIABLES--//
            int speedTick = 1000;

            //--Starting Screen--//
            cnsl.StartingScreen("Benchmark Of Everything In One", "Marek Kubicka", "Welcome, try some benchmark ans share your points!", 2);

            //--Main Menu--//
            mainMenu:
            switch (cnsl.Menu(new string[] {"CPU","HDD","Exit"}, ConsoleColor.Black, ConsoleColor.Gray, true, 0,0))
            {
                //--CPU--//
                case 0:
                    cpu:
                    bnch = new benchmarks_collection(speedTick);
                    switch(cnsl.Menu(new string[] {"Start","Settings","Back"}, ConsoleColor.Black, ConsoleColor.Gray, true, 0, 0))
                    {
                        //--START--//
                        case 0:
                            bnch.benchCPU();
                            Console.WriteLine("Completed...");
                            Console.ReadKey();
                            break;

                        //--SETTINGS--//
                        case 1:
                            speedTick = setSpeedTick(speedTick);
                            goto cpu;

                        //--BACK--//
                        case 2:
                            goto mainMenu;
                    }
                    break;

                //--HDD--//
                case 1:
                    hdd:
                    bnch = new benchmarks_collection(speedTick);
                    switch (cnsl.Menu(new string[] { "Start", "Settings", "Back" }, ConsoleColor.Black, ConsoleColor.Gray, true, 0, 0))
                    {
                        //--START--//
                        case 0:
                            bnch.benchHDD();
                            break;

                        //--SETTINGS--//
                        case 1:
                            speedTick = setSpeedTick(speedTick);
                            goto hdd;    

                        //--BACK--//
                        case 2:
                            goto mainMenu;
                    }
                    break;
            }
        }

        static int setSpeedTick(int defaultSpeedTick)
        {
            Console.Clear();
            Console.Write("Set speed tick, now is: {0}\nYour set: ", defaultSpeedTick);
            defaultSpeedTick = Convert.ToInt32(Console.ReadLine());

            return defaultSpeedTick;
        }
    }
}
