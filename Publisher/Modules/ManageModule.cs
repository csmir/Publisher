﻿using Disqord.Bot.Commands.Text;
using Qmmands.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Modules
{
    public class ManageModule : DiscordTextModuleBase
    {
        [TextCommand("enable")]
        public async Task EnableAsync()
        {
            using var guild = Guild.Get(Context.ChannelId);

            if (guild.Value.PubChannels.Contains(Context.ChannelId))
                await Response(":x: **Auto-publish is already enabled in this channel.**");
            else
            {
                guild.Value.PubChannels.Add(Context.ChannelId);
                await Response(":white_check_mark: **Successfully enabled auto-publish in channel.**");
            }
        }

        [TextCommand("disable")]
        public async Task DisableAsync()
        {
            using var guild = Guild.Get(Context.ChannelId);

            if (guild.Value.PubChannels.Remove(Context.ChannelId))
                await Response(":white_check_mark: **Successfully disabled auto-publish in channel.**");
            else
                await Response(":x: **Auto-publish was never enabled in this channel.**");
        }
    }
}
