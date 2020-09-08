using BennieTracker.Actions;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker.Commands
{
    /**
     * A family of commands that allows for users to see what the current bennie count is for all players or for a given player.
     */
    public class ShowCommands : BaseCommandModule
    {

        /* 
         * Allows for the printing of the current bennie count for a specific player (specified by passing in the player name)
         * or for all players (specified by passing in "all").
         * Discord usage:
         * !show [playerName]
         */
        [Command("show")]
        [Description("Shows the current bennie count for the specified character (when a character name is given) or for all players (when 'all' is given)")]
        public async Task ShowSpecified(CommandContext ctx, string playerName)
        {
            int bennieCount = 0;

            if(playerName == "all")
            {
                SendScoreBoardMessageAction action = new SendScoreBoardMessageAction(Bot.players.GetAll(), ctx);
                await action.Do();
            }
            else if (Bot.players.TryGetCount(playerName, out bennieCount))
            {
               SendScoreBoardMessageAction action = new SendScoreBoardMessageAction(playerName, bennieCount, ctx);
               await action.Do();
            }
            else
            {
                SendUnknownNameMessageAction action = new SendUnknownNameMessageAction(playerName, ctx);
                await action.Do();
            }
        }

        /* 
         * Prints the current bennie count for the player who sent the command.
         * Discord usage:
         * !show 
         */
        [Command("show")]
        [Description("Shows the current bennie count for the player who invokes the command.")]
        public async Task ShowSender(CommandContext ctx)


        {
            string playerName =  ctx.Member.DisplayName;
            await ShowSpecified(ctx, playerName);
        }


    }
}
