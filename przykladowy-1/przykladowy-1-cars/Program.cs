using przykladowy_1_cars.Extensions;

var builder = WebApplication.CreateBuilder(args);

// TODO: To trzeba dodać
builder.Services.AddControllers();
builder.Services.AddCarServicesServices();

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
