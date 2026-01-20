using MoneyTracker.Api.Endpoints;
using MoneyTracker.Application;
using MoneyTracker.Application.Database;
using Scalar.AspNetCore;
using static MoneyTracker.Api.Exceptions.CustomExceptions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"];

if (connectionString == null)
{
    throw new MissingConfigurationException("Database connection string is missing. Please add ConnectionString to correct appsettings.json");
}

builder.Services.AddDatabase(connectionString);
builder.Services.AddOpenApi();
builder.Services.AddApplication();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("MoneyTracker");
    });
} 
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

#if DEBUG

var initDb = false;
_ = bool.TryParse(app.Configuration["InitDatabase"], out initDb);

if (initDb)
{
    // Since initializer is a scoped service, we need to create a scope to get it
    using var scope = app.Services.CreateScope();

    var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await dbInitializer.InitializeAsync();
}

#endif


app.Run();
