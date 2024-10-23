using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharpTrooper.Core;

using (var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
    })
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

    Console.WriteLine("SWAPI:");

    Console.WriteLine("...");

    var films = await sharpTrooperService.GetAllFilmsAsync();

    foreach (var item in films.results)
    {
        Console.WriteLine(item.title);
    }

    Console.WriteLine("...");

    var people = await sharpTrooperService.GetAllPeopleAsync();

    foreach (var item in people.results)
    {
        Console.WriteLine(item.name);
    }

    Console.WriteLine("...");

    var vehicles = await sharpTrooperService.GetAllVehiclesAsync();

    foreach (var item in vehicles.results)
    {
        Console.WriteLine(item.name);
    }

    Console.WriteLine("...");

    var species = await sharpTrooperService.GetAllSpeciesAsync();

    foreach (var item in species.results)
    {
        Console.WriteLine(item.name);
    }

    Console.WriteLine("...");

    var planets = await sharpTrooperService.GetAllPlanetsAsync();

    foreach (var item in planets.results)
    {
        Console.WriteLine(item.name);
    }

    Console.WriteLine("...");
}