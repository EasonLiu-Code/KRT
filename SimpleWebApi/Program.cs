using System.Reflection;
using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleWebApi.Application;
using SimpleWebApi.Application.AppService;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure;
using SimpleWebApi.Infrastructure.Repositories;
using SimpleWebApi.Migrations;

SetThreadPool();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var file = Path.Combine(AppContext.BaseDirectory, "SimpleWebApi.xml");
    var path = Path.Combine(AppContext.BaseDirectory, file);
    c.IncludeXmlComments(path ,true);
});
builder.Services.AddDbContext<DataDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("mysqldb");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
//MemoryCache
builder.Services.AddMemoryCache();

#region DenpendencyInjection
builder.Services.AddScoped<ITestDbAppService, TestDbAppService>();
builder.Services.AddScoped<ITestDbRepository, TestDbRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplication();
builder.Services.AddAppServiceApplication();
#endregion


// 👇 Add the required Carter services
builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //自动迁移
    //app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// 👇 find all the Carter modules and register all the APIs
app.MapCarter();
app.Run();



static void SetThreadPool()
{
    ThreadPool.GetMinThreads(out var minWorkerThreads, out var minCompletionPortThreads);
    ThreadPool.SetMinThreads(
        minWorkerThreads < 100 ? 100 : minWorkerThreads,
        minCompletionPortThreads < 100 ? 100 : minCompletionPortThreads);
    ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);
    ThreadPool.SetMaxThreads(maxWorkerThreads, maxCompletionPortThreads <= 3000 ? 3000 : maxCompletionPortThreads);
}
