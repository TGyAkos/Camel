using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camel
{
    interface IUserInteface
    {
        void PrintOption();
        char GetResultFromPrintOption();
        void DrinkFromFlask();
        void GoForward();
        void GoForwardInAHurry();
        void StopForTheNight();
        void LookAtStats();
        void Quit();
        void Lost();
        void Won();
    }

    class UserInterface : IUserInteface
    {
        int BanditDistance = -20;

        Player player;
        EventStuff eventStuff;

        public UserInterface(Player pl, EventStuff es)
        {
            player = pl;
            eventStuff = es;
            eventStuff.GameLost += EventStuff_GameLost;
            eventStuff.GameWon += EventStuff_GameWon;
            eventStuff.BanditMovement += EventStuff_BanditMovement;
        }

        public void PrintOption()
        {
            Console.WriteLine("A. Inni a kulacsodból.");
            Console.WriteLine("B. Tovább haladsz.");
            Console.WriteLine("C. Tovább haladsz sietve.");
            Console.WriteLine("D. Megállsz éjszakára.");
            Console.WriteLine("E. Állapot megnézése.");
            Console.WriteLine("Q. Kilépés.");
        }

        public char GetResultFromPrintOption()
        {
            bool IsNullAndWrong = true;
            char[] RightChars = { 'A', 'B', 'C', 'D', 'E', 'Q' };
            char Result = 'E';

            while (IsNullAndWrong)
            {
                string RawString = Console.ReadLine().ToUpper();

                if (String.IsNullOrEmpty(RawString)) { continue; }
                if (Array.Exists(RightChars, element => element == RawString[0]))
                {
                    IsNullAndWrong = false;
                    Result = RawString[0];
                }
            }

            return Result;
        }

        public void DrinkFromFlask()
        {
            player.DrinkFromFlask();
            Console.WriteLine("Ittál a kulacsodból");
            Console.WriteLine("Jelenleg a szomjúságod: 0");
        }

        public void GoForward()
        {
            player.GoForward();
            Console.WriteLine("Utaztál {0} kilométert.\r\nA bennszülöttek {1} kilométerre vannak tőled.", player.Distance, BanditDistance);

        }

        public void GoForwardInAHurry()
        {
            player.GoForwardInAHurry();
            Console.WriteLine("Utaztál {0} kilométert.\r\nA bennszülöttek {1} kilométerre vannak tőled.", player.Distance, BanditDistance);
        }

        public void StopForTheNight()
        {
            player.StopForTheNight();
            Console.WriteLine("Aludtal");
        }

        public void LookAtStats()
        {
            Console.WriteLine("Megtett kilométer:  {0}\r\nKulacsban levő folyadék:  {1}\r\nA bennszülöttek {2} kilométerre vannak mögödted.", player.Distance, player.Flask, BanditDistance);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Lost()
        {
            Console.WriteLine("You Lost!");
        }

        private void EventStuff_GameLost(object sender, EventArgs e)
        {
            Lost();
        }

        public void Won()
        {
            Console.WriteLine("You Won!");
        }

        private void EventStuff_GameWon(object sender, EventArgs e)
        {
            Won();
        }

        private void EventStuff_BanditMovement(object sender, BanditMovementEventArgs e)
        {
            BanditDistance = e.Distance;
        }
    }
}