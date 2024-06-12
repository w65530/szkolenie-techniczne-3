using System.Net.Http.Headers;
using przykladowy_1_client.Extensions;
using przykladowy_1_client.Resolvers;
using przykladowy_1_client.Services;

var builder = WebApplication.CreateBuilder(args);

// TODO: To trzeba dodać
builder.Services.AddClientServices();
builder.Services.AddControllers();
builder.Services.AddHttpClient<CarServiceResolver>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5141/api/");
});

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

// TODO: To trzeba dodać
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
