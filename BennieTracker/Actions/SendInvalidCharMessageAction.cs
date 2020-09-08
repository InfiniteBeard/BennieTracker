using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{
    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about an illegal input character.
     */
    public class SendInvalidCharMessageAction : AsyncAction
    {
        private const string MESSAGE_SKELETON = "The chararacter '{0}' is invalid.";

        private CommandContext ctx;

        private string message;
        public SendInvalidCharMessageAction(CommandContext ctx, char c)
        {
            this.ctx = ctx;
            message = String.Format(MESSAGE_SKELETON, c);
        }

        public async Task Do()
        {
            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
