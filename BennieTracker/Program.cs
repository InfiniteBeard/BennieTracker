using DSharpPlus;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;
using System.Threading.Tasks;

/** TODO
 * 1. Add logging. Currently no logging is taking place. Having logging for when messages are received (debug), when 
 * changes occur (info), or when an illegal action was attempted (error). The bot code probably has something that you 
 * can make use of.
 * 2. Add roll parsing. Currently two bots are required to roll dice and track bennies. I'd like to shorten this to a 
 * single bot. Having some sort of pseudo State design pattern is kind of what I'm currently thinking as it should allow 
 * for you to do things like add operators/complexity fairly easily.
 */
namespace BennieTracker
{
    class Program
    {
        static DiscordClient discord;



        static int Main(string[] args)
        {
            CommandLineApplication app = new CommandLineApplication();

            //app.UnrecognizedArgumentHandling = UnrecognizedArgumentHandling.StopParsingAndCollect;
            app.HelpOption();
            CommandOption configFile = app.Option("-c|--config <PATH/TO/CONFIG/FILE>", "The json configuration file that the bot will use.", CommandOptionType.SingleValue);
            CommandOption playerFile = app.Option("-p|--players <PATH/TO/PLAYERS/FILE>", "The list of players that the bot will use.", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                string configFilePath;
                if(!ParseArgFilePath(app, configFile, out configFilePath))
                {
                    return -1;
                }
                string playerFilePath;
                if(!ParseArgFilePath(app, playerFile, out playerFilePath))
                {
                    return -1;
                }

                Bot bot = new Bot(configFilePath, playerFilePath); 
                bot.RunAsync().GetAwaiter().GetResult();

                return 0;
            });
            try
            {
                return app.Execute(args);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                app.ShowHelp();
                return -1;
            }


        }

    private static bool ParseArgFilePath(CommandLineApplication app, CommandOption fileCommandOption, out string filePath)
        {
            if (fileCommandOption.HasValue())
            {
                if (System.IO.File.Exists(fileCommandOption.Value()))
                {
                    filePath = fileCommandOption.Value();
                    return true;
                }
                else
                {
                    Console.WriteLine(string.Format("Specified file for config file '{0}' does not exist", fileCommandOption.Value()));
                    app.ShowHelp();
                    filePath = string.Empty;
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No value was given for the config file");
                app.ShowHelp();
                filePath = string.Empty;
                return false;
            }
        }

    }
}
