namespace WeatherApi

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.OpenApi.Models
open Swashbuckle.AspNetCore.Swagger

type Startup(configuration: IConfiguration) =
    member _.Configuration = configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member _.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllers() |> ignore
        services.AddSwaggerGen(
            fun c -> c.SwaggerDoc("v1", new OpenApiInfo(Title = "WeatherAPI", Version = "v1"))
            ) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        
        app.UseSwagger() |> ignore
        app.UseSwaggerUI(
            fun c -> c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherAPI in F#" )
            ) |> ignore
            
        app.UseDeveloperExceptionPage() |> ignore
        app.UseHttpsRedirection()
           .UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                endpoints.MapControllers() |> ignore
            ) |> ignore
