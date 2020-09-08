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
     * A family of commands that can be used to spend bennies
     */
    public class UseBenniesCommand : BaseCommandModule
    {
        /**
         * A command that is used to have a specified player (playerName) use a specified number of bennies (benniesUsed)
         * Discord usage:
         * !use [playerName] [benniesUsed]
         */
        [Command("bennie")]
        [Description("(GM ONLY) Deducts the specified number of bennies from the specified player")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "GM"})]
        public async Task UseBennies(CommandContext ctx, string playerName, int benniesUsed)
        {
            int currentBennieCount = 0;
            if(Bot.players.TryGetCount(playerName, out currentBennieCount))
            {
                if(currentBennieCount > 0)
                {

                    if(currentBennieCount > benniesUsed)
                    {
                        UseBenniesAction useBennies = new UseBenniesAction(playerName, benniesUsed);
                        useBennies.Do();
                        Bot.players.TryGetCount(playerName, out currentBennieCount);
                        SendScoreBoardMessageAction scordBoard = new SendScoreBoardMessageAction(playerName, currentBennieCount, ctx);
                        await scordBoard.Do();
                    } else
                    {
                        SendNotEnoughBenniesMessageAction action = new SendNotEnoughBenniesMessageAction(playerName, currentBennieCount, benniesUsed, ctx);
                        await action.Do();
                    }
                } else
                {
                    SendNoBenniesAvailableMessageAction action = new SendNoBenniesAvailableMessageAction(playerName, ctx);
                    await action.Do();
                }
            }
            else
            {
                SendUnknownNameMessageAction action = new SendUnknownNameMessageAction(playerName, ctx);
                await action.Do();
            }
        }

        /**
         * A command that is used to have the invoking player use a specified number of bennies (benniesUsed)
         * Discord usage:
         * !use [benniesUsed]
         */
        [Command("bennie")]
        [Description("(GM ONLY) Deducts a bennie from the specified player")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "GM"})]
        public async Task UseBennies(CommandContext ctx, string benniesUsed)
        {
            int benniesUsedParsed;
            string playerName;
            if(int.TryParse(benniesUsed, out benniesUsedParsed))
            {
                playerName = ctx.Member.DisplayName;
            }
            else
            {
                playerName = benniesUsed;
                benniesUsedParsed = 1;
            }
            await UseBennies(ctx, playerName, benniesUsedParsed);
        }

        /**
         * A command that is used to have the invoking player use a single bennie 
         * Discord usage:
         * !use
         */
        [Command("bennie")]
        [Description("Deducts a bennie from the player who invokes the command.")]
        public async Task UseBennies(CommandContext ctx)
        {
            string playerName = ctx.Member.DisplayName;
            await UseBennies(ctx, playerName, 1);
        }

        /**
         * A command that is used to have the invoking player use a specified number of bennies (benniesUsed)
         * Discord usage:
         * !use [benniesUsed]
         */
        [Command("bennie")] 
        [Description("Deducts the specified number of bennies from the player who invokes the command.")]
        public async Task UseBennies(CommandContext ctx, int benniesUsed)
        {
            //Blank, used solely for generating help for Discord
        }
    }
}
