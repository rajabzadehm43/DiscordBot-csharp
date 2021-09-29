using System;
using System.Threading.Tasks;
using Discord = DiscordBot_1.DiscordBot.Discord;

namespace DiscordBot_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = "ODkxNjg3NDU5OTA0MTc2MTk5.YVB-qQ.KIdYQ0K5mFyYQ-xV9N5T1BtNemQ";
            var discord = new DiscordBot_1.DiscordBot.Discord(token);

            discord.RunBot().GetAwaiter().GetResult();

            Task.Delay(-1).GetAwaiter().GetResult();
        }
    }
}
