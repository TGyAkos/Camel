using System;
using System.Collections.Generic;
using System.Text;

namespace Camel
{
    class EventStuff
    {
        public event EventHandler Movement;
        public event EventHandler<BanditMovementEventArgs> BanditMovement;
        public event EventHandler<PlayerMovementEventArgs> PlayerMovement;
        public event EventHandler GameLost;
        public event EventHandler GameWon;

        public void Move()
        {
            OnMovement(EventArgs.Empty);
        }

        public void Lost()
        {
            OnLost(EventArgs.Empty);
        }

        public void Won()
        {
            OnWon(EventArgs.Empty);
        }

        public void BanditMove(int distance)
        {
            BanditMovementEventArgs args = new BanditMovementEventArgs();
            args.Distance = distance;
            OnBanditMovement(args);
        }

        public void PlayerMove(int distance)
        {
            PlayerMovementEventArgs args = new PlayerMovementEventArgs();
            args.Distance = distance;
            OnPlayerMovement(args);
        }

        protected virtual void OnMovement(EventArgs e)
        {
            if (Movement is not null)   
            {
                Movement(this, e);
            }
        }

        protected virtual void OnLost(EventArgs e)
        {
            if (GameLost is not null)
            {
                GameLost(this, e);
            }
        }

        protected virtual void OnWon(EventArgs e)
        {
            if (GameWon is not null)
            {
                GameWon(this, e);
            }
        }

        protected virtual void OnBanditMovement(BanditMovementEventArgs e)
        {
            EventHandler<BanditMovementEventArgs> handler = BanditMovement;
            if (handler is not null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPlayerMovement(PlayerMovementEventArgs e)
        {
            EventHandler<PlayerMovementEventArgs> handler = PlayerMovement;
            if (handler is not null)
            {
                handler(this, e);
            }
        }
    }

    public class BanditMovementEventArgs : EventArgs
    {
        public int Distance { get; set; }
    }

    public class PlayerMovementEventArgs : EventArgs
    {
        public int Distance { get; set; }
    }
}
