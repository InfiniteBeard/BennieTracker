using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Actions
{
    /**
     * This class is an implementation of the AsyncAction interface. It is responsible for 
     * sending a message to Discord about not having enough bennies.
     */
    public class SendNotEnoughBenniesMessageAction : AsyncAction
    {
        private CommandContext ctx;
        private const string MESSAGE_SKELETON = "{0} tried to use {1} bennies but only has {2}";
        private string message;
        
        public SendNotEnoughBenniesMessageAction(string playerName, int currentBennies, int benniesUsed, CommandContext ctx)
        {
            message = string.Format(MESSAGE_SKELETON, playerName, benniesUsed, currentBennies);
            this.ctx = ctx;
        }
        
        public async Task Do()
        {
            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
