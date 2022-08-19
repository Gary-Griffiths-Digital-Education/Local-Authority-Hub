using WebUI.Extensions;
using WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddWebUIApplicationServices()
    .AddHashingService()
    .AddClientServices()
    .AddWebUIServices(builder.Configuration);

builder.Services.AddTransient<IViewModelToApiModelHelper, ViewModelToApiModelHelper>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }
