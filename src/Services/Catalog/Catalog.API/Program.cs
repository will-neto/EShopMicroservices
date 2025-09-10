using BuildingBlocks.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarterWithAssemblies(typeof(Program).Assembly);
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
});
// Add services to the container

var app = builder.Build();

app.MapCarter();
//Configure the HTTP request pipeline

app.Run();
