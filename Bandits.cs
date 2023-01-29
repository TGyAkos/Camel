using System;
using System.Collections.Generic;
using System.Text;

namespace Camel
{
    class Bandits
    {
        int Distance { get; set; }
        private Random rng;
        private EventStuff eventStuff;

        public Bandits(EventStuff es)
        {
            Distance = -20;
            rng = new Random();
            eventStuff = es;
            eventStuff.Movement += EventStuff_Movement;
        }
        public void GoForward()
        {
            Distance += rng.Next(7, 15);
            eventStuff.BanditMove(Distance);
        }
        private void EventStuff_Movement(object sender, EventArgs e)
        {
            GoForward();
        }
    }
}
