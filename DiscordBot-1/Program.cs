using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot_1
{
    class Program
    {


        static void Main(string[] args)
        {

            var program = new Program();

            program.StartBot().GetAwaiter().GetResult();
            Task.Delay(-1).GetAwaiter().GetResult();
        }

        #region Bot Global Variables

        private const string Token = "ODkxNjg3NDU5OTA0MTc2MTk5.YVB-qQ.kmtcXwenD56_hRGQkxzHuVTEHQE";
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;

        #endregion

        #region Service Manager

        private readonly IServiceProvider _serviceProvider;

        #endregion

        public Program()
        {
            var serviceCollection = new ServiceCollection();

            _client = new DiscordSocketClient();
            _commandService = new CommandService();

            serviceCollection.AddSingleton(_client);
            serviceCollection.AddSingleton(_commandService);

            _client.Log += LogAsync;

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        #region Base Configuration

        public async Task StartBot()
        {
            await _client.LoginAsync(TokenType.Bot, Token);
            await _client.StartAsync();

            await RegisterCommands();
        }

        private async Task LogAsync(LogMessage message)
        {
            Console.WriteLine(message);
        }

        #endregion

        #region Command Handlers

        private async Task RegisterCommands()
        {
            _client.MessageReceived += HandleMessage;
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
        }

        private async Task HandleMessage(SocketMessage arg)
        {
            var message = (SocketUserMessage) arg;
            var context = new SocketCommandContext(_client, message);

            int argPos = 0;
            if (!message.HasCharPrefix('/', ref argPos))
                return;

            var result = await _commandService.ExecuteAsync(context, argPos, _serviceProvider);

            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorReason);
        }

        #endregion

    }
}
