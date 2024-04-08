using Microsoft.AspNetCore.Http.HttpResults;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var _animals = new List<Animal>()
{
    new Animal{id =1,name = "",category ="dog",weight = 15.4, colour = "black"},
    new Animal{id = 2, name = "",category = "cat", weight = 5.9,colour = "white"},
    new Animal{id = 3, name = "", category = "dog", weight = 10.2, colour = "brown"}
};

var _visits = new List<Visit>()
{
    new Visit{id =1, animal = _animals[0],date = new DateTime(2024,4,8),description = "operation", price = 100},
    new Visit{id = 2, animal = _animals[1],date = new DateTime(2024,4,10), description = "short visit", price = 50},
    new Visit{id = 3, animal = _animals[1],date = new DateTime(2024,4,15), description = "operation", price = 100}
    };

//Animals
app.MapGet("/api/animals", () => Results.Ok(_animals))
    .WithName("GetAnimals")
    .WithOpenApi();

app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animalToFind = _animals.FirstOrDefault(a => a.id == id);
        return animalToFind == null ? Results.NotFound("Animal with id " + id + " was not found") : Results.Ok(animalToFind);
    })
    .WithName("GetAnimal")
    .WithOpenApi();

app.MapPost("/api/animals", (Animal animal) =>
    {
    _animals.Add(animal);
    return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("CreateAnimal");

app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
    {
    var animalToUpdate = _animals.FirstOrDefault(a => a.id == id);
    if (animalToUpdate == null)
    {
        return Results.NotFound("Student with id " + id + " was not found");
    }
    _animals.Remove(animalToUpdate);
    _animals.Add(animal);

    return Results.NoContent();
    })
    .WithName("UpdateAnimal")
    .WithOpenApi();

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        var animalToDelete = _animals.FirstOrDefault(a => a.id == id);
        if (animalToDelete == null)
        {
            return Results.NotFound("Student with id " + id + " was not found");
        }
        _animals.Remove(animalToDelete);
        return Results.NoContent();
    })
    .WithName("DeleteAnimal")
    .WithOpenApi();

//Visits
app.MapGet("/api/visits/{id:int}", (int id) =>
    {
        foreach (var visit in _visits)
        {
            
        }
        return;
    })
    .WithName("Get visits")
    .WithOpenApi();


app.Run();