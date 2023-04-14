using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MyCBot.cmds
{
    public class BanCommand : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [Summary("Bannit un utilisateur du serveur.")]
        public async Task BanAsync(SocketGuildUser user, [Remainder] string reason = "Aucune raison fournie.")
        {
            await Context.Guild.AddBanAsync(user, 0, reason);

            var embed = new EmbedBuilder()
                .WithTitle("Utilisateur banni")
                .WithColor(Color.Red)
                .AddField("Utilisateur", user.ToString(), true)
                .AddField("Modérateur", Context.User.ToString(), true)
                .AddField("Raison", reason)
                .Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
