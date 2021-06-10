// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Net.Http
open SwaggerProvider

let [<Literal>] Schema = "https://localhost:5001/swagger/v1/swagger.json"
type Weather = OpenApiClientProvider<Schema>

[<EntryPoint>]
let main argv =
    let handler = new HttpClientHandler(UseCookies = false)
    let baseUri = Uri("https://localhost:5001/")
    let httpClient = new HttpClient(handler, true, BaseAddress=baseUri)
    let client = Weather.Client(httpClient)
    
    printfn "WeatherData"
    printfn "Calling Endpoint /api/WeatherForcast/Bergen"
    client.GetApiWeatherForecast1("Bergen")
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> Array.map(printfn "%O")
        |> ignore
        
    printfn "" 
    printfn "Calling Endpoint /api/WeatherForcast/"
    client.GetApiWeatherForecast()
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> Array.map( printfn "%O")
        |> ignore
        
    0 // return an integer exit code