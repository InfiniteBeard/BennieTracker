using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker
{

    /**
     * A command that allows for the bot to be pinged
     */
    public class PingCommand  : BaseCommandModule
    {

        /*
         * Discord usage:
         * !ping
         */
        [Command("ping")]
        [Description("Returns pong. Used to see if the bot is currently operational.")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

    }
}
