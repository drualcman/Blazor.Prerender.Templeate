var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<HttpClient>(sp =>
{
    var server = sp.GetRequiredService<Microsoft.AspNetCore.Hosting.Server.IServer>();
    var addressFeatures = server.Features.Get<Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>();
    string baseAddress = addressFeatures.Addresses.First();
    return new HttpClient() { BaseAddress = new Uri(baseAddress) };
});
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapRazorPages();

app.MapFallbackToPage("/_Host");

await app.RunAsync();
