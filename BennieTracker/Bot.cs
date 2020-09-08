using BennieTracker.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BennieTracker
{
    /**
     * This class is responsible for creating and managing the connection to Discord. It also is responsible
     * for loading the programs configuration files.
     */
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public static Players players { get; private set; }

        private string configFilePath;
        private string playerFilePath;
        
        public Bot(string configFilePath, string playerFilePath)
        {
            this.configFilePath = configFilePath;
            this.playerFilePath = playerFilePath;

        }

        private ConfigJson LoadJson(string jsonFilePath)
        {
            string json = string.Empty;
            using (var fs = File.OpenRead(configFilePath))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = sr.ReadToEnd();

            ConfigJson configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            return configJson;
        }

        private List<string> LoadPlayers(string playerFilePath)
        {
            List<string> players = new List<string>();
            using (var fs = File.OpenRead(playerFilePath))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                while (!sr.EndOfStream)
                {
                    players.Add(sr.ReadLine());

                }
            return players;
        }

        public async Task RunAsync()
        {
            List<string> playerList = LoadPlayers(playerFilePath);
            players = new Players(playerList);
            

            ConfigJson configJson = LoadJson(configFilePath);

            DiscordConfiguration config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
                
            };

            Client = new DiscordClient(config);


            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
            };

            CreateCommands(Client, commandsConfig);

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private CommandsNextExtension CreateCommands(DiscordClient client, CommandsNextConfiguration commandsConfig)
        {
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<PingCommand>();
            Commands.RegisterCommands<AddCommands>();
            Commands.RegisterCommands<ShowCommands>();
            Commands.RegisterCommands<UseBenniesCommand>();
            return Commands;
        }
                
                

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
