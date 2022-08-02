using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.OpenApi.Models;
using WebAPI;
using WebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
                .AddInfrastructureServices(builder.Configuration)
                .AddApplicationServices();

builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

builder.Services.AddScoped<MinimalOrganisationEndPoints>();
builder.Services.AddScoped<MinimalGeneralEndPoints>();
builder.Services.AddScoped<MinimalServiceEndPoints>();
builder.Services.AddScoped<MinimalTaxonomyEndPoints>();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.OperationFilter<ReApplyOptionalRouteParameterOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync(builder.Configuration);
        await initialiser.SeedAsync();
    }
}

using (var scope = app.Services.CreateScope())
{
    var orgservice = scope.ServiceProvider.GetService<MinimalOrganisationEndPoints>();
    if (orgservice != null)
        orgservice.RegisterOrganisationEndPoints(app);

    var serservice = scope.ServiceProvider.GetService<MinimalServiceEndPoints>();
    if (serservice != null)
        serservice.RegisterServiceEndPoints(app);

    var taxonyservice = scope.ServiceProvider.GetService<MinimalTaxonomyEndPoints>();
    if (taxonyservice != null)
        taxonyservice.RegisterTaxonomyEndPoints(app);

    var genservice = scope.ServiceProvider.GetService<MinimalGeneralEndPoints>();
    if (genservice != null)
        genservice.RegisterMinimalGeneralEndPoints(app);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
