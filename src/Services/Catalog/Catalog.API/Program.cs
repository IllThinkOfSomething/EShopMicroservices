using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services here

// Scan carter modules in this project, since the package is registered in common abstraction library "Building Blocks"

var catalogAssembly = typeof(Program).Assembly;

builder.Services.AddCarter(configurator: config =>
{
    var modules = catalogAssembly.GetTypes()
        .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

    foreach (var module in modules)
    {
        config.WithModules(module);
    }
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions(); 

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


// Configure HTTP request pipeline.

app.MapCarter();

app.Run();