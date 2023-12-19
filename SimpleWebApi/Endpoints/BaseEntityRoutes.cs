using Carter;
using Newtonsoft.Json;

namespace SimpleWebApi.Endpoints;
/// <summary>
/// fast mini api
/// it can be replace for controller
/// </summary>
public class BaseEntityRoutes:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Test", () => Task.FromResult(Results.Ok("okay")));
        app.MapGet("Test2", () => Task.FromResult(Results.Ok(JsonConvert.SerializeObject(typeof(WeatherForecast)))));
    }
}