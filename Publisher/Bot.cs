using Disqord;
using Disqord.Bot;
using Disqord.Bot.Hosting;
using Disqord.Rest;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Publisher
{
    public class Bot : DiscordBot
    {
        public Bot(IOptions<DiscordBotConfiguration> options, ILogger<DiscordBot> logger, IServiceProvider services, DiscordClient client)
            : base(options, logger, services, client)
        {

        }
    }

    public class BotService : DiscordBotService
    {
        protected override async ValueTask OnMessageReceived(BotMessageReceivedEventArgs e)
        {
            var isNews = e.Channel!.Type == ChannelType.News;
            var isPostable = e.Message!.Flags.HasFlag(MessageFlags.Crossposted);

            if (isNews && !isPostable)
            {
                var guild = Guild.Get(e.GuildId);

                if (guild.Value.PubChannels.Any(x => x == e.ChannelId))
                    await Bot.CrosspostMessageAsync(e.ChannelId, e.MessageId);
            }
        }
    }
}
