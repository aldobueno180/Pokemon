# Pokemon

Pokemon is a REST API, which giving a pokemon name, it will have as a response the description of the pokemon in shakespearean way text.


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

It is necessary to be installed

```
Visual Studio/Visual Studio Code
.Net Core 3.1
```
Get access to the APIs
* Shakespeare translator](https://funtranslations.com/api/shakespeare)
* [PokéAPI](https://pokeapi.co/)

### Openning project

Open file Pokemon.sln



### Coding Multiservices REST API

It is used multiservices folliwing the template of ASP.Net Boilerplate, folliwing also the fundamentals of DDD
Having the projects

```
Pokemon.Application ()
Pokemon.Application.Shared (project contains application service interfaces and DTO)
Pokemon.Core(project contains domain layer classes like entities and domain services).
Pokemon.Core.Shared (project contains consts, enums and helper classes used both in mobile & web projects.)
Pokemon.EntityFrameworkCore (project contains your DbContext, repository implementations, database migrations and other Entity Framework Core specific concepts.)
Pokemon.Web.Mvc (project contains the presentation/API layer (Controllers) for backend files)
```
### Build
```
dotnet run --project ./src/Pokemon.Web.Mvc/Pokemon.Web.Mvc.csproj
```

### Test
The test include unit test for the application service for getting the Pokemon description
```
dotnet test
dotnet test --filter "FullyQualifiedName=Pokemon.Tests.PokemonAppService_Test.GettingPokemonByName"
```

## Deployment
```
IIS
Docker (docker file included)
```

## Built With
* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) - API project framework used
* [RestSharp v106.11.4](https://restsharp.dev/) - Nuget Package for managing the API calls to PokeApi and Shakespeare Translator


## Versioning

Git local versioning 

## Authors

* **Aldo Bueno** 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments
* [Aspnet Boilerplate/ASP.Net Zero](https://docs.aspnetzero.com/en/aspnet-core-mvc/latest/Overview-Core#solution-structure-layers)
* [DDD Driven Domain Design](https://www.domainlanguage.com/)
