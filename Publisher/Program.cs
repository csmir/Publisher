using Disqord.Bot.Hosting;
using Microsoft.Extensions.Hosting;
using Publisher;

var host = Host.CreateDefaultBuilder(args);

host.ConfigureDiscordBot<Bot>((hostContext, botContext) =>
{
    botContext.Token = hostContext.Configuration["ConnectionStrings:Discord"];
});

await host.RunConsoleAsync();