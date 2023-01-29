using System;

namespace Camel
{
    class Program
    {
        static void Main(string[] args)
        {
            EventStuff eventStuff = new EventStuff();
            Player player = new Player(eventStuff);
            UserInterface userInterface = new UserInterface(player, eventStuff);
            _ = new CheckStuff(eventStuff); 

            while (true) 
            {
                userInterface.PrintOption();

                switch (userInterface.GetResultFromPrintOption()) 
                {
                    case 'A':
                        userInterface.DrinkFromFlask();
                        break;
                    case 'B':
                        userInterface.GoForward();
                        break;
                    case 'C':
                        userInterface.GoForwardInAHurry();
                        break;
                    case 'D':
                        userInterface.StopForTheNight();
                        break;
                    case 'E':
                        userInterface.LookAtStats();
                        break;
                    case 'Q':
                        userInterface.Quit();
                        break;
                }
            }
        }
    }
}
