using System.Collections.Generic;
using DataAccess;
using DataAccess.Interfaces;
using Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("mydb");
builder.Services.AddSingleton<IRepository>(new AutomovilContext(
    cs
));
var app = builder.Build();

app.MapPost("/automovil/crear", (List<Automovil> automoviles,IRepository repository) => {
    repository.InsertData(automoviles);
    return Results.Ok();
});

app.Run();
