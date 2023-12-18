using Carter;
using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Application.AppService;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("mysqldb");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IBaseAppService, BaseAppService>();

// 👇 Add the required Carter services
builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// 👇 find all the Carter modules and register all the APIs
app.MapCarter();
app.Run();