using System;
using System.Collections.Generic;
using System.Text;

namespace BennieTracker.Actions
{

    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about a bennie being used.
     */
    public class UseBenniesAction : Action
    {
        private string name;

        private int benniesUsed;

        public UseBenniesAction(string playerName) : this(playerName, 1)
        {

        }

        public UseBenniesAction(string name, int benniesUsed)
        {
            this.name = name;
            this.benniesUsed = benniesUsed;

        }

        public bool Do()
        {
            if(benniesUsed < 1)
            {
                return false;
            }
            else
            {
                int temp;
                return Bot.players.TryAddCount(name, benniesUsed * -1, out temp);
            }
        }
    }
}
