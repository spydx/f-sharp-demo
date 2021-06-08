// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open SwaggerProvider

let [<Literal>] Schema = "https://localhost:5001/swagger/v1/swagger.json"
type Weather = OpenApiClientProvider<Schema>


[<EntryPoint>]
let main argv =
    let client = Weather.Client()
    client.GetApiWeatherForecast1("Bergen")
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> printf "%O"

    client.GetApiWeatherForecast()
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> printfn "%O"

    0 // return an integer exit code