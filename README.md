## I tried contacting the API developer team, but I couldn't reach them. So I'll stop developing, until someone replies. It doesn't seem, that the API is in active development. 

# BattleRiteApi
C# api wrapper for the [battlerite api](http://battlerite-docs.readthedocs.io/en/master/introduction.html).

## Features
- Unittests
- Get matches
- Synchronous and asynchronous API

## Installation

Install the package from nuget:

`PM> Install-Package botiapa.BattleRiteApi`

or you can download the project and build it yourself.

## Basic Usage

Creating a new instance of the api:

```
using BattleRiteApi;

var battleRite = new BattleRite("YOUR API KEY");
```

### Matches
Getting a match collection:

`var matchCollection = battleRite.GetMatchCollection();`

Getting a single match:

`var match = battleRite.GetSingeMatch(matchCollection.matches[0].id)`

You can find more examples here: https://github.com/botiapa/BattleRiteApi/blob/master/BattleRiteApiExample/Program.cs

## Libraries Used
- Newtonsoft.Json

## License

This wrapper is under the MIT license.

