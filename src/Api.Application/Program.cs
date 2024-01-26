using Api.CrossCutting.DependecyInjection;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
static void ConfigureServices(IServiceCollection services)
{
    ConfigureService.ConfigureDependenciesService(services);
    ConfigureRepository.ConfigureDependenciesRepository(services);
}

ConfigureServices(builder.Services);

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
