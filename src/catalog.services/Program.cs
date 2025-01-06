using Catalog.Services.Application;
using Catalog.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Custom Dependency Injection
builder.Services.AddApplicationServices(); 
builder.Services.AddRepositoryServices(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(corsBuilder => corsBuilder.WithOrigins(builder.Configuration["AllowedOrigins"]).AllowAnyMethod().AllowAnyHeader());
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

