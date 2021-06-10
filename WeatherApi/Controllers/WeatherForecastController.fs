namespace WeatherApi.Controllers


open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open WeatherApi.Models


[<ApiController>]
[<Route("api/[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries =
        [|
            "Freezing"
            "Bracing"
            "Chilly"
            "Cool"
            "Mild"
            "Warm"
            "Balmy"
            "Hot"
            "Sweltering"
            "Scorching"
        |]
    let cities = [|
        "Bergen"
        "Voss"
        "Oslo"
        "Alta"
    |]

    [<HttpGet>]
    member _.Get() =
        let rng = System.Random()
        [|
            for index in 0..4 ->
                { Date = DateTime.Now.AddDays(float index)
                  TemperatureC = rng.Next(-20,55)
                  Summary = summaries.[rng.Next(summaries.Length)]
                  City = cities.[rng.Next(cities.Length)] }
        |]

    [<HttpGet("{city}")>]
    member _.GetCity(city: string) =
        let rng = System.Random()
        [|
            for index in 0..4 ->
                {
                    Date = DateTime.Now.AddDays(float index)
                    TemperatureC = rng.Next(-30, 55)
                    Summary = summaries.[rng.Next(summaries.Length)]
                    City = city
                }
        |]