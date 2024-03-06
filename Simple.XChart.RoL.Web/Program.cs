using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.RoL.Web.Data;
using Simple.XChart.RoL.Web.Helpers;
using Simple.XChart.RoL.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<RoLDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Simple.XChart.RoL.Web")));

builder.Services.AddHttpClient<VerseService>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrls:VerseUrl"))
    );

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
builder.Services.AddSingleton(connectionStrings);

builder.Services.AddScoped<PexelsService>(p => new PexelsService(builder.Configuration.GetValue<string>("ApiKeys:pexels")));

builder.Services.AddScoped<RoLDatabaseHelper>();

builder.Services.AddScoped<JSHelper>();

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
