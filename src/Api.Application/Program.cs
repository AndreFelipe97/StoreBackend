using Api.CrossCutting.DependecyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDependenciesService();
builder.Services.ConfigureDependenciesRepository();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
