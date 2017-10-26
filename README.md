# SharpTrooper

A C# helper library for [SWAPI](https://www.swapi.co) - the Star Wars API

## Basic Usage

All resources are accessible through the top-level SharpTrooperCore() methods:

`SharpTrooperCore core = new SharpTrooperCore();`

## Methods
```
var planet = core.GetPlanet("1");

var planets = core.GetAllPlanets();

...

var resourceFromUrl = core.GetSingleByUrl<People>(planet.residents[0]);
```

For more info, visit the documentation of SWAPI: [SWAPI/Documentation](http://swapi.co/documentation)

or my personal blog post:
[Otomatik Mühendis](http://otomatikmuhendis.com/2015/07/27/the-star-wars-api/)
