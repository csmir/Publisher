using Disqord;
using Disqord.Bot.Commands;
using Disqord.Bot.Commands.Application;
using Qmmands;

namespace Publisher.Modules
{
    [RequireAuthorPermissions(Permissions.ManageChannels)]
    public class PublishModule : DiscordApplicationGuildModuleBase
    {
        [SlashCommand("enable")]
        [Description("Enables automated publishing of messages in this channel.")]
        public async Task<IResult> EnableAsync()
        {
            await Deferral(true);
            using var guild = Guild.Get(Context.GuildId);

            if (guild.Value.PubChannels.Contains(Context.ChannelId))
                return Response(":x: **Auto-publish is already enabled in this channel.**");

            guild.Value.PubChannels.Add(Context.ChannelId);
            return Response(":white_check_mark: **Successfully enabled auto-publish in channel.**");
        }

        [SlashCommand("disable")]
        [Description("Disables automated publishing of messages in this channel.")]
        public async Task<IResult> DisableAsync()
        {
            await Deferral(true);
            using var guild = Guild.Get(Context.GuildId);

            if (guild.Value.PubChannels.Remove(Context.ChannelId))
                return Response(":white_check_mark: **Successfully disabled auto-publish in channel.**");

            return Response(":x: **Auto-publish was never enabled in this channel.**");
        }
    }
}
