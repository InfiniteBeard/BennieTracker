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
     * A family of commands that allows for the addition of bennies to specified players. 
     */
    public class AddCommands : BaseCommandModule
    {
        /* Used to add a specified number of bennies (additionalBennies) to a specified player (playerName)
         * Discord usage:
         * !add [playerName] [additionalBennies]
         */
        [Command("add")]
        [Description("(GM ONLY) Gives bennies to the specified players")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "GM"})]
        public async Task Add(CommandContext ctx, string playerName, int additionalBennies)
        {
            if(additionalBennies < 1)
            {
                SendPosivitveValueRequiredMessage action = new SendPosivitveValueRequiredMessage(ctx);
                await action.Do();
                return;
            }

            int bennieCount = 0;
            string formattedPlayerName = MessageBuilder.Capitalize(playerName); 
            if (Bot.players.TryAddCount(playerName, additionalBennies, out bennieCount))
            {
                SendReceivedBenniesMessageAction recievedBenniesMessage = new SendReceivedBenniesMessageAction(formattedPlayerName, bennieCount, ctx);
                await recievedBenniesMessage.Do();

                SendScoreBoardMessageAction scoreBoardMessage = new SendScoreBoardMessageAction(playerName, bennieCount, ctx);
                await scoreBoardMessage.Do();

            } else
            {
                SendUnknownNameMessageAction action = new SendUnknownNameMessageAction(playerName, ctx);
                await action.Do();
            }
        }

        /* Used to add a single bennie to a specified player (playerName)
         * Discord usage:
         * !add [playerName] 
         */
        [Command("add")]
        [Description("(GM ONLY) Gives a bennie to the specified players")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "GM"})]
        public async Task Add(CommandContext ctx, string playerName) 
        {
            await Add(ctx, playerName, 1);

        }



    }
}
