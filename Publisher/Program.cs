using Disqord.Bot.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Publisher;

var host = Host.CreateDefaultBuilder(args);

host.ConfigureDiscordBot<Bot>((hostContext, botContext) =>
{
    botContext.Token = hostContext.Configuration.GetConnectionString("Discord");
});

await host.RunConsoleAsync();