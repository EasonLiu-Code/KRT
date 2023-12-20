using Carter;
using Newtonsoft.Json;
using SimpleWebApi.Infrastructure.Entities.Test;

namespace SimpleWebApi.Endpoints;
/// <summary> </summary>
public class BaseEntityRoutes:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Test", () => Task.FromResult(Results.Ok("okay")));
    }
}