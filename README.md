# SharpTrooper

A C# helper library for [SWAPI](https://swapi.dev) - the Star Wars API

## Basic Usage

Register `SharpTrooperCore` to your services for Dependency Injection.

https://github.com/olcay/SharpTrooper/blob/f67a48f0cac0d7bd62454ec63808dcf5fa640a9c/SharpTrooper.Example/Program.cs#L18-L31

## Methods

```csharp
var films = await sharpTrooperService.GetAllFilmsAsync();

var people = await sharpTrooperService.GetAllPeopleAsync();

var vehicles = await sharpTrooperService.GetAllVehiclesAsync();

var species = await sharpTrooperService.GetAllSpeciesAsync();

var planets = await sharpTrooperService.GetAllPlanetsAsync();
```

For more info, visit the documentation of SWAPI: [SWAPI/Documentation](https://swapi.dev/documentation)

or my personal blog post: [The Star Wars API](https://olcay.dev/2021/08/01/the-star-wars-api/)

## Contributors

<a href="https://github.com/olcay/SharpTrooper/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=olcay/SharpTrooper" />
</a>
