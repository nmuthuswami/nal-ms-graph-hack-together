using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphSample.Models;
using GraphSample.Services;
using MsIntuneGraphSample;

var myAppHost = Host.CreateDefaultBuilder()
.ConfigureServices((context, services) =>
{
    //add config settings to DI
    var config = new Settings();
    context.Configuration.GetSection(nameof(Settings))
    .Bind(config);

    //configure services
    services.AddSingleton<Settings>(config);
    services.AddScoped<IGraphUserService, GraphUserService>();
    services.AddHostedService<GraphSampleHostService>();
})
.Build();

await myAppHost.RunAsync();