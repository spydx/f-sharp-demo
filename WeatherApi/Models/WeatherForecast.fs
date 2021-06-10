namespace WeatherApi.Models

open System

type WeatherForecast =
    { Date: DateTime
      TemperatureC: int
      Summary: string
      City: string }

    member this.TemperatureF =
        32.0 + (float this.TemperatureC / 0.5556)
