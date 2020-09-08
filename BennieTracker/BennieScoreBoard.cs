using System;
using System.Collections.Generic;
using System.Text;

namespace BennieTracker
{
    /**
     * This class holds the current bennie counts in association with the relevant player name.
     * It is primarily used to organize this information for display purposes.
     */
    public class BennieScoreBoard
    {
        public SortedSet<Tuple<string, int>> scores { get; private set; }

        public const string NAME_COLUMN_TITLE = "NAME";

        public const string SCORE_COLUMN_TITLE = "BENNIES";

        public BennieScoreBoard()
        {
            scores = new SortedSet<Tuple<string, int>>();
        }

        public bool AddEntry(string name, int score)
        {
            return scores.Add(new Tuple<string, int>(name, score));
        }
    }
}
