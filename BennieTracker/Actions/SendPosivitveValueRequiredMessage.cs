using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{
    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about a positive integer being required as an input.
     */
    public class SendPosivitveValueRequiredMessage : AsyncAction
    {
        private const string MESSAGE = "The value must be 1 or larger";
        private CommandContext ctx;

        public SendPosivitveValueRequiredMessage(CommandContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task Do()
        {
            await ctx.Channel.SendMessageAsync(MESSAGE);
        }
    }
}
