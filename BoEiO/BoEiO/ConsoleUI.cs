using System;
using System.Threading;
using System.IO;

public class ConsoleUI
{
    //--MENU UI--//
    public int Menu(string[] items, ConsoleColor fontColor, ConsoleColor backColor, bool repeatable, int posX, int posY)
    {
        bool enter = false;
        int itemPos = 0;
        int index = 0;

        hideCursor();
        //Smaže a následně přepíše konzoly po změně výběru
        Console.Clear();
        //Menu se vypisuje dokud není výběr uskutečněn
        while (!enter)
        {
            //cyklus projde všechny položky v menu
            foreach (string item in items)
            {
                Console.SetCursorPosition(posX, posY + itemPos);
                if (index == itemPos)
                {
                    //Nastavení barev fontu
                    Console.BackgroundColor = backColor;
                    Console.ForegroundColor = fontColor;
                }
                Console.WriteLine(item);
                Console.ResetColor();       //Nastavení defaultních barev v konzoli -> způsobuje chybu při výběru barvy fontu v jiných metodách
                itemPos++;
            }

            ConsoleKeyInfo klavesa = Console.ReadKey();     //Sejme zmáčknutou klávesu a uloží do proměnné
            switch (klavesa.Key)
            {
                //Při přesování v menu pomocí šipky nahoru se odečítá index
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0 && repeatable)    // ==> ošetří pád při dosažení maximální hodnoty menu
                        index = items.Length - 1;
                    if (index < 0 && !repeatable)
                        index = 0;
                    break;

                case ConsoleKey.DownArrow:
                    index++;
                    if (index == items.Length && repeatable)        // ==> ošetří pád při dosažení maximální hodnoty menu
                        index = 0;
                    if (index == items.Length && !repeatable)
                        index = index = items.Length - 1;
                    break;

                case ConsoleKey.Enter:  // ==> Potvrzení výběru
                    enter = true;
                    break;
            }

            itemPos = 0;    // ==> Vyresetuje pozici v menu
        }

        return index;       // ==> Návratová hodnota je index výběru

    }
    //--END--//

    //--Progress Bar UI--//
    public void ProgressBar(int x, int y, int width, int value)
    {
        hideCursor();
        float nmb = ((width - 2) / 100F) * value;
        //--Create template sides--//
        Console.SetCursorPosition(x, y);
        Console.Write("|");
        Console.SetCursorPosition(x + width - 1, y);
        Console.Write("|");
        //--END--//

        //--Create Progress Line--//
        for (int i = 0; i <= width - 3; i++)
        {
            Console.SetCursorPosition(x + i + 1, y);
            if (i < nmb)
                Console.BackgroundColor = ConsoleColor.Gray;
            else
                Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        Console.ResetColor();
        //--END--//
    }
    //--END--//

    //--Starting Screen UI--//
    public void StartingScreen(string appName, string author, string startingMessage, int timer)
    {
        int maxWidth = Console.BufferWidth;
        int maxHeight = Console.WindowHeight;
        int mostWidth = appName.Length;
        if (mostWidth < author.Length)
            mostWidth = author.Length;

        hideCursor();
        //--CREATE FIRST LINE--//
        for(int i = 0; i < maxWidth;i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("#");
            Console.SetCursorPosition(i, 20);
            Console.Write("#");
            Console.SetCursorPosition(i, maxHeight-1);
            Console.Write("#");
        }

        //--CREATE COLLUMNS FIRST AND LAST--//
        for(int i = 0; i < maxHeight;i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(maxWidth-1, i);
            Console.Write("#");

            if (i < 20)
            {
                Console.SetCursorPosition((maxWidth / 2) - (mostWidth / 2) - 5, i);
                Console.Write("#");
                Console.SetCursorPosition((maxWidth / 2) + (mostWidth / 2) + 5, i);
                Console.Write("#");
            }

            ResetCursor();
        }

        //--Write APP Name--//
        Console.SetCursorPosition((maxWidth/2)-(appName.Length/2),3);
        Console.Write(appName);

        //--Write Athor Name--//
        Console.SetCursorPosition((maxWidth/2)-(author.Length/2),5);
        Console.Write(author);

        //--Write Startig Message--//
        Console.SetCursorPosition((maxWidth / 2) - (startingMessage.Length / 2), 22);
        Console.Write(startingMessage);

        //--TIMER--//
        Thread.Sleep(timer*1000);
        //--END--//
    }
    //--END--//

    //--Explorer folders and files--//
    public void explorer(string path)
    {
        string[] data = Directory.GetDirectories(path);
        //string finalPath = ;

        /*foreach (var folder in data)
        {
            Console.WriteLine(folder);
        }*/

        explorer(MenuExpl(data, ConsoleColor.Black, ConsoleColor.Gray, true, 0, 0));
    }
    //--END--//

    //--Menu for Explorer--//
    public string MenuExpl(string[] items, ConsoleColor fontColor, ConsoleColor backColor, bool repeatable, int posX, int posY)
    {
        bool enter = false;
        int itemPos = 0;
        int index = 0;

        hideCursor();
        //Smaže a následně přepíše konzoly po změně výběru
        Console.Clear();
        //Menu se vypisuje dokud není výběr uskutečněn
        while (!enter)
        {
            //cyklus projde všechny položky v menu
            foreach (string item in items)
            {
                Console.SetCursorPosition(posX, posY + itemPos);
                if (index == itemPos)
                {
                    //Nastavení barev fontu
                    Console.BackgroundColor = backColor;
                    Console.ForegroundColor = fontColor;
                }
                Console.WriteLine(item);
                Console.ResetColor();       //Nastavení defaultních barev v konzoli -> způsobuje chybu při výběru barvy fontu v jiných metodách
                itemPos++;
            }
            Console.SetCursorPosition(0, index);
            ConsoleKeyInfo klavesa = Console.ReadKey();     //Sejme zmáčknutou klávesu a uloží do proměnné
            switch (klavesa.Key)
            {
                //Při přesování v menu pomocí šipky nahoru se odečítá index
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0 && repeatable)    // ==> ošetří pád při dosažení maximální hodnoty menu
                        index = items.Length - 1;
                    if (index < 0 && !repeatable)
                        index = 0;
                    break;

                case ConsoleKey.DownArrow:
                    index++;
                    if (index == items.Length && repeatable)        // ==> ošetří pád při dosažení maximální hodnoty menu
                        index = 0;
                    if (index == items.Length && !repeatable)
                        index = index = items.Length - 1;
                    break;

                case ConsoleKey.Enter:  // ==> Potvrzení výběru
                    enter = true;
                    break;
            }
            itemPos = 0;    // ==> Vyresetuje pozici v menu
        }

        return items[index];       // ==> Návratová hodnota je index výběru

    }
    //--END--//

    private void ResetCursor()
    {
        int maxWidth = Console.BufferWidth;
        Console.SetCursorPosition(maxWidth-1,0);
        Console.Write("#");
    }

    private void hideCursor()
    {
        Console.CursorVisible = false;
    }

    private void showCursor()
    {
        Console.CursorVisible = true;
    }
}
