var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // TODO: add UseMigrationsEndPoint
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// TODO: Add UseSwaggerUi3

app.UseRouting();

// TODO: 
// Add UseAuthentication
// Add Dfe Sign On Support?
// Add UseAuthorisation

app.MapRazorPages();
app.MapFallbackToFile("index.html");
app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }