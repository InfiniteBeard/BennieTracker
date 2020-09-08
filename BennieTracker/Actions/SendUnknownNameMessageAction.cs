using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{

    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about an unrecognized player name being given as input.
     */
    public class SendUnknownNameMessageAction : AsyncAction
    {
        private CommandContext ctx;
        private const string MESSAGE_SKELETON = "Unable to find bennie count for name '{0}'";
        private string message;

        public SendUnknownNameMessageAction(string name, CommandContext ctx)
        {
            this.ctx = ctx;
            message = String.Format(MESSAGE_SKELETON, name);
        }

        public async Task Do()
        {
            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
