using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharpTrooper.Core;

using (var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHttpClient();
        services.AddScoped<SharpTrooperCore>();
    })
    .Build())
{
    using var scope = host.Services.CreateScope();
    var sharpTrooperService = scope.ServiceProvider.GetService<SharpTrooperCore>()
        ?? throw new NullReferenceException("service is null");

    var films = await sharpTrooperService.GetAllFilmsAsync();

    Console.WriteLine("List of films from SWAPI:");

    foreach (var item in films.results)
    {
        Console.WriteLine(item.title);
    }
}