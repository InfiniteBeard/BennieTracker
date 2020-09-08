using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{
    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about the current bennie count.
     */
    public class SendScoreBoardMessageAction : AsyncAction
    {
        private CommandContext ctx;

        private BennieScoreBoard scoreBoard;

        public SendScoreBoardMessageAction(List<KeyValuePair<string, int>> values, CommandContext ctx)
        {
            scoreBoard = new BennieScoreBoard();
            foreach(KeyValuePair<string, int> value in values)
            {
                scoreBoard.AddEntry(MessageBuilder.Capitalize(value.Key), value.Value);
            }
            this.ctx = ctx;
        }
        public SendScoreBoardMessageAction(string name, int score, CommandContext ctx)
        {
            scoreBoard = new BennieScoreBoard();
            scoreBoard.AddEntry(MessageBuilder.Capitalize(name), score);
            this.ctx = ctx;
        }

        public async Task Do()
        {
            MessageBuilder replyBuilder = new MessageBuilder();
            string message = replyBuilder.BlockQuote().Add(scoreBoard).BlockQuote().ToString();
            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
