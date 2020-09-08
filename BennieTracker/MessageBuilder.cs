using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BennieTracker
{

    /**
     * This class acts as a helper class for building messages to send to Discord
     */
    public class MessageBuilder
    {
        private StringBuilder builder;

        private const String NEW_LINE = "\n";

        public MessageBuilder()
        {
            builder = new StringBuilder();
        }


        /*
         * Bolds the specified value
         * Value - the specified value
         */
        public static string Bold(string value)
        {
            return "**" + value + "**";
        }

        /*
         * Italicizes the specified value
         * Value - the specified value
         */
        public static string Italic(string value)
        {
            return "*" + value + "*";
        }

        /*
         * Underlines the specified value
         * Value - the specified value
         */
        public static string Underlined(string value)
        {
            return "__" + value + "__";
        }

        /*
         * Strikes out the specified value
         * Value - the specified value
         */
        public static string StrikeOut(string value)
        {
            return "~~" + value + "~~";
        }

        /*
         * Capitalizes the specified value
         * Value - the specified value
         */
        public static string Capitalize(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1);
        }


        /**
         * Adds the specified integer value to the message.
         */
        public MessageBuilder Add(int value)
        {
            builder.Append(value);
            return this;
        }

        /**
         * Adds the specified string value to the message.
         */
        public MessageBuilder Add(string value)
        {
            builder.Append(value);
            return this;
        }


        /**
         * Adds the specified BennieScoreBoard to the message.
         */
        public MessageBuilder Add(BennieScoreBoard scoreBoard)
        {
            int nameColumnPad = 20;
            Add(BennieScoreBoard.NAME_COLUMN_TITLE);
            PadRight(nameColumnPad);
            Add(BennieScoreBoard.SCORE_COLUMN_TITLE);
            Add(NEW_LINE);
            foreach(Tuple<string, int> score in scoreBoard.scores.ToList())
            {
                Add(score.Item1);
                PadRight(nameColumnPad + (BennieScoreBoard.NAME_COLUMN_TITLE.Length - score.Item1.Length));
                Add(score.Item2);
                Add(NEW_LINE);
            }
            return this;
        }


        /**
         * Adds a block quote specifier to the message.
         */
        public MessageBuilder BlockQuote()
        {
            Add("```");
            return this;
        }

        /**
         * Adds a specified number of space characters for padding
         */
        public MessageBuilder PadRight(int size)
        {
            return PadRight(' ', size);
        }

        /**
         * Adds a specified number of a specified character for padding
         * character - the character that will be used for padding
         * size - the number of padding characters to add
         */
        public MessageBuilder PadRight(char character, int size)
        {
            return Add(string.Empty.PadRight(size, character));
        }


        /**
         * Adds a new line value to the message.
         */
        public MessageBuilder NewLine()
        {
            return Add("\n");
        }

        public string ToString()
        {
            return builder.ToString();
        }
    }
}
