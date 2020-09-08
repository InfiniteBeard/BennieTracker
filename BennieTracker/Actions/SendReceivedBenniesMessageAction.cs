using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{
    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about a player receiving a bennie or bennies.
     */
    public class SendReceivedBenniesMessageAction : AsyncAction
    {
        private CommandContext ctx;
        private string message;

        public SendReceivedBenniesMessageAction(string name, int bennies, CommandContext ctx)
        {
            this.ctx = ctx;
            message = GenerateMessage(name, bennies);
        }
        public async Task Do()
        {
            await ctx.Channel.SendMessageAsync(message);
        }
        private string GenerateMessage(string playerName, int additionalBennies)
        {
            if (additionalBennies == 1) {
                return string.Format("{0} recevied a bennie!!", playerName);
            } else
            {
                return string.Format("{0} recevied some bennies!!!", playerName);
            }
        }
    }
}
