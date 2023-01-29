using System;
using System.Collections.Generic;
using System.Text;

namespace Camel
{
    class Player
    {
        public int Distance { get; set; }
        public int Thirst { get; set; }
        public int Flask { get; set; }
        public int Tiredness {
            get;
            set;
        }
        private Random Rng;
        private EventStuff eventStuff;

        public Player(EventStuff es)
        {
            Distance = 0;
            Thirst = 0;
            Flask = 3;
            Tiredness = 0;

            eventStuff = es;

            Rng = new Random();
            _ = new Bandits(eventStuff);
        }
        public int DrinkFromFlask()
        {
            if (Flask <= 0) return 1;
            if (Thirst <= 0) return 2;

            Flask -= 1;
            Thirst = 0;

            return 0;
        }
        public int GoForward()
        {
            int returnValue = 0;

            if (Tiredness == 8) return 1;
            if (Tiredness <= 6) returnValue = 3;

            Distance += Rng.Next(5, 13);
            Thirst += 1;
            Tiredness += 1;

            eventStuff.Move();

            if (Thirst <= 6) return 2;

            return returnValue;
        }
        public int GoForwardInAHurry()
        {
            int returnValue = 0;

            if (Tiredness == 8) return 1; 
            if (Tiredness <= 6) returnValue = 4;
            else if(Tiredness <= 4) returnValue = 3;
            if (Thirst <= 0) return 2;

            Distance += Rng.Next(10, 21);
            Thirst += 1;
            Tiredness += Rng.Next(1, 4);

            eventStuff.Move();

            return returnValue;
        }
        public int StopForTheNight()
        {
            Tiredness = 0;

            eventStuff.Move();

            return 0;
        } 
    }
}
