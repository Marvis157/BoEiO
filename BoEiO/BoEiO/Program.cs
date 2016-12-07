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
            mainMenu:
            switch (cnsl.Menu(new string[] {"CPU","HDD","Exit"}, ConsoleColor.Black, ConsoleColor.Gray, true, 0,0))
            {
                //--CPU--//
                case 0:
                    switch(cnsl.Menu(new string[] {"Start","Settings","Back"}, ConsoleColor.Black, ConsoleColor.Gray, true, 0, 0))
                    {
                        //--START--//
                        case 0:

                            break;

                        //--SETTINGS--//
                        case 1:

                            break;

                        //--BACK--//
                        case 2:
                            goto mainMenu;
                            break;
                    }
                    break;

                //--HDD--//
                case 1:
                    switch (cnsl.Menu(new string[] { "Start", "Settings", "Back" }, ConsoleColor.Black, ConsoleColor.Gray, true, 0, 0))
                    {
                        //--START--//
                        case 0:

                            break;

                        //--SETTINGS--//
                        case 1:

                            break;

                        //--BACK--//
                        case 2:
                            goto mainMenu;
                            break;
                    }
                    break;
            }
        }
    }
}
