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

app.MapGet("/api/animals", () => Results.Ok(_animals))
    .WithName("Animals")
    .WithOpenApi();

app.Run();