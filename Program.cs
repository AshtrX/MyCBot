using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

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
            _client.MessageReceived += MessageReceived;

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

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Author.IsBot) return;

            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
        }
    }
}
