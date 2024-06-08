using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.SharedComponents.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<StateHelper>();

var connectionSettings = builder.Configuration.GetSection("ConnectionSettings").Get<ConnectionSettings>();
builder.Services.AddSingleton(connectionSettings);

var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
builder.Services.AddSingleton(apiSettings);

builder.Services.AddScoped(p => new PexelsService(builder.Configuration.GetValue<string>("ApiKeys:pexels")));

builder.Services.AddHttpClient<VerseService>(client =>
    client.BaseAddress = new Uri(apiSettings.ApiUrls.Verse)
    );

builder.Services.AddScoped(p =>
    new PexelsService(apiSettings.ApiKeys.Pexels)
    );

//var databaseFile = Path.Combine(Directory.GetCurrentDirectory(), connectionSettings.SqliteConnection);
//var connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "RoLDB.db");

//builder.Services.AddHttpClient<VerseService>(c => c.BaseAddress = new Uri(apiSettings.ApiUrls.Verse));

var verseService = new VerseService(new HttpClient { BaseAddress = new Uri(apiSettings.ApiUrls.Verse) });
var pexelsService = new PexelsService(apiSettings.ApiKeys.Pexels);
var database = new RoLRepositoryHelper(connectionSettings.SqliteConnection, pexelsService, verseService);
await database.DatabaseInitializeAsync();
builder.Services.AddTransient<IRoLRepositoryHelper>(x => database);

builder.Services.AddMemoryCache();

builder.Services.AddScoped<Simple.XChart.SharedComponents.Helpers.JSHelper>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
