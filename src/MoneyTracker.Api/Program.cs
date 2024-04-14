using System.Reflection;
using MoneyTracker.Application;
using MoneyTracker.Application.Database;
using static MoneyTracker.Api.Exceptions.CustomExceptions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"];

if (connectionString == null)
{
    throw new MissingConfigurationException("Database connection string is missing. Please add ConnectionString to correct appsettings.json");
}

builder.Services.AddDatabase(connectionString);

builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "0.1.0",
        Title = "Money Tracker API",
        Description = "This is an API for Money Tracker."
    });

    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#if DEBUG

// Since initializer is a scoped service, we need to create a scope to get it
using var scope = app.Services.CreateScope();

var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

#endif


app.Run();
