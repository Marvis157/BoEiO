using System;

public class ConsoleUI
{
    //--MENU UI--//
    public int Menu(string[] items, ConsoleColor fontColor, ConsoleColor backColor, bool repeatable, int posX, int posY)
    {
        bool enter = false;
        int itemPos = 0;
        int index = 0;

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
}
