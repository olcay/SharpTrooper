# SharpTrooper

A C# helper library for [SWAPI](www.swapi.co) - the Star Wars API

## Basic Usage

All resources are accessible through the top-level SharpTrooperCore() methods:

`SharpTrooperCore core = new SharpTrooperCore();`

## Methods
```
var planet = core.GetPlanet("1");

var planets = core.GetAllPlanet();

...

var resourceFromUrl = core.GetSingleByUrl<People>(planet.residents[0]);
```

For more info, visit the documentation of SWAPI: [SWAPI/Documentation](http://swapi.co/documentation)