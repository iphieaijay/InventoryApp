using InventoryApp.Core.Entities;
using InventoryApp.Plugin.Data;
using InventoryApp.Plugin.Repositories;
using InventoryApp.UseCases.Interfaces;
using InventoryApp.UseCases.Inventories;
using InventoryApp.UseCases.Inventories.Interfaces;
using InventoryApp.Web.Components;
using InventoryApp.Web.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
//builder.Host.UseSerilog((context, services, configuration) => configuration
//      .ReadFrom.Configuration(context.Configuration)
//      .Enrich.FromLogContext());

builder.Services.AddSingleton<IInventoryRepository, InventoyRepository>();
builder.Services.AddTransient<IViewInventoryByNameUsecase, ViewInventoryByNameUsecase>();
builder.Services.AddDbContext<InventoryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryDbConfig"));
});
builder.Services.AddApplicationServices(builder.Configuration);

// Bind JwtSettings section to JwtSettings class and register in DI
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
