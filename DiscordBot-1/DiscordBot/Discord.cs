using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBot_1.DiscordBot
{
    public class Discord
    {
        private readonly string Token;

        #region Discord Dependencies

        public DiscordSocketClient Client { get; private set; }
        public CommandService CommandService { get; private set; }

        #endregion

        public Discord(string token)
        {
            Token = token;

            Client = new DiscordSocketClient();
            CommandService = new CommandService();
        }

        public async Task RunBot()
        {
            Client.Log += LogAsync;
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
        }

        #region Logging

        private async Task LogAsync(LogMessage args)
        {
            Console.WriteLine(args);
        }

        #endregion


    }
}