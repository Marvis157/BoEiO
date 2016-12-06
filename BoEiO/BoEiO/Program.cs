using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoEiO
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI cnsl = new ConsoleUI();

            //--Starting Screen--//
            cnsl.StartingScreen("Benchmark Of Everything In One", "Marek Kubicka", "Welcome, try some benchmark ans share your points!", 2);

            //--Main Menu--//
            switch (cnsl.Menu(new string[] {"CPU","HDD","Exit"}, ConsoleColor.Black, ConsoleColor.Gray, true, 0,0))
            {
                //--CPU--//
                case 0:
                    break;

                //--HDD--//
                case 1:
                    break;
            }
        }
    }
}
