using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MyCBot.cmds;

namespace MonBotDiscord
{
    class Program
    {
        private DiscordSocketClient _client;

        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;

            var commandService = new CommandService();
            await commandService.AddModuleAsync<PingCommand>(null);

            _client.MessageReceived += async (message) =>
            {
                // Ne traitez pas les messages des bots
                if (message.Author.IsBot) return;

                // Préfixe de la commande
                char prefix = '!';

                // Vérifiez si le message commence par le préfixe de la commande
                if (message.Content.StartsWith(prefix))
                {
                    int argPos = 1;
                    var context = new SocketCommandContext(_client, message as SocketUserMessage);

                    // Exécutez la commande
                    await commandService.ExecuteAsync(context, argPos, null);
                }
            };

            // Remplacez YOUR_BOT_TOKEN par le token de votre bot
            await _client.LoginAsync(TokenType.Bot, "YOUR_BOT_TOKEN");
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
