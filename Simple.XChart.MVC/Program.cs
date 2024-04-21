using Simple.XChart.MVC.Models;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionSettings = builder.Configuration.GetSection("ConnectionSettings").Get<ConnectionSettings>();
builder.Services.AddSingleton(connectionSettings);

var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
builder.Services.AddSingleton(apiSettings);

builder.Services.AddHttpClient<VerseService>(client =>
    client.BaseAddress = new Uri(apiSettings.ApiUrls.Verse)
    );

builder.Services.AddScoped(p => 
    new PexelsService(apiSettings.ApiKeys.Pexels)
    );

var database = new RolDatabase(connectionSettings.DefaultConnection);
var verseService = new VerseService(new HttpClient { BaseAddress = new Uri(apiSettings.ApiUrls.Verse) });
var pexelsService = new PexelsService(apiSettings.ApiKeys.Pexels);
builder.Services.AddScoped(x => 
    new RoLRepositoryHelper(database, pexelsService, verseService).DatabaseInitialize()
);

object value = builder.Services.AddLazyCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
