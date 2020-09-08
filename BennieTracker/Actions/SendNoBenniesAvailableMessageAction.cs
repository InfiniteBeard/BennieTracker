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
    public class SendNoBenniesAvailableMessageAction : AsyncAction
    {
        
        private string MESSAGE_SKELETON = "{0} has no bennies to use";
        private CommandContext ctx;
        private string message;

        public SendNoBenniesAvailableMessageAction(string playerName, CommandContext ctx)
        {
            this.ctx = ctx;
            message = String.Format(MESSAGE_SKELETON, playerName);
        }

        public async Task Do()
        {
            await ctx.Channel.SendMessageAsync(message);

        }
    }
}
