using System.Threading.Tasks;
using Discord.Commands;

namespace MyCBot.cmds
{
    public class PingCommand : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Renvoie Pong! en réponse.")]
        public async Task PingAsync()
        {
            await ReplyAsync("Pong!");
        }
    }
}
