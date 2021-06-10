# F-Sharp Demo

Mini demo for show-and-tell at work

Contains

- WeatherAPI
- apiclient using Swagger (work in progress)

Mini project showing SwaggerGen and TypeProviders in harmony.

Sources: [https://fsprojects.github.io/SwaggerProvider/#/OpenApiClientProvider](https://fsprojects.github.io/SwaggerProvider/#/OpenApiClientProvider)

## WeatherAPI

```sh
> dotnet new webapi -lang F# 
> dotnet add package Swashbuckle.AspNetCore
> dotnet add package Swashbuckle.AspNetCore.Swagger
> dotnet add package Swashbuckle.AspNetCore.SaggerGen
```

## apiclient - ConsoleAPP 

```sh
> dotnet new console -lang F#
> dotnet add pacakage SwaggerProvider
```