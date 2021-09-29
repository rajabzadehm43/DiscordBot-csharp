using System.Net.Sockets;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot_1.Commands
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        public async Task SayHello()
        {
            await ReplyAsync($"Hello {Context.User.Mention}");
        }
    }
}