using Cozzi_Inmobiliaria.Server.Data;
using Cozzi_Inmobiliaria.Server.Interfaces;
using Cozzi_Inmobiliaria.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.AddJsonFile($"appsettings.{environment}.json", true)
.AddEnvironmentVariables()
.Build();

var connectionString = configuration.GetConnectionString("AppDbContext");

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(option => option.UseSqlServer(connectionString));
builder.Services.AddRazorPages();
builder.Services.AddTransient<IInmuebleService, InmuebleService>();
builder.Services.AddTransient<IInquilinoService, InquilinoService>();
builder.Services.AddTransient<IAlquilerService, AlquilerService>();
builder.Services.AddTransient<IClienteService, ClienteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
