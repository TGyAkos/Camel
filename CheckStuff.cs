using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camel
{
    class CheckStuff
    {
        EventStuff eventStuff;
        int BanditDistance;
        int PlayerDistance;

        public CheckStuff(EventStuff es) 
        {
            eventStuff = es;
            eventStuff.BanditMovement += EventStuff_BanditMovement;
            eventStuff.PlayerMovement += EventStuff_PlayerMovement;
        }

        private void CompareDistances()
        {
            if (PlayerDistance >= 200)
            {
                eventStuff.Won();
                return;
            }
            if (BanditDistance > PlayerDistance)
            {
                eventStuff.Lost();
                return;
            }
        }

        private void EventStuff_BanditMovement(object sender, BanditMovementEventArgs e)
        {
            BanditDistance = e.Distance;
            CompareDistances();
        }
        private void EventStuff_PlayerMovement(object sender, PlayerMovementEventArgs e)
        {
            PlayerDistance= e.Distance;
            CompareDistances();
        }
    }
}
