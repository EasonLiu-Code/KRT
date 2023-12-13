using Carter;

namespace SimpleWebApi.Endpoints;
/// <summary>
/// fast mini api
/// it can be replace for controller
/// </summary>
public class BaseEntityRoutes:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("test", () => Task.FromResult(Results.Ok()));
    }
}