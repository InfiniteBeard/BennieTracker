using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BennieTracker
{

    /**
     * This class is responsible for keeping track of the current bennie count for each player.
     */
    public class Players
    {
        private Dictionary<string, int> players;

        public Players(List<string> playerNames)
        {
            players = new Dictionary<string, int>();
            foreach(string name in playerNames)
            {
                Console.WriteLine("Name " + name);
                players.Add(name.ToLower(), 0);
            }
        }


        public bool TryGetCount(string name, out int count)
        {
            return players.TryGetValue(name.ToLower(), out count);
        }

        public List<KeyValuePair<string, int>> GetAll()
        {
            return players.ToList();
        }

        /**
         * Attempts to add a specified number of bennies to the specified player. It only returns a success if 
         * specified player exists.
         * Name - specified player name
         * addition - specified number of bennies
         * newCount - the new amount of bennies the specified player has
         * Return:
         *   True if the specified player exists
         */
        public bool TryAddCount(string name, int addition, out int newCount)
        {
            int currentCount;
            string formattedName = name.ToLower();
            if(players.TryGetValue(formattedName, out currentCount))
            {

                currentCount += addition;
                players[formattedName] = currentCount;
                newCount = currentCount;
                return true;  
            } else
            {
                newCount = -1;
                return false;
            }
        }



    }
}
