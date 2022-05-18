using Microsoft.EntityFrameworkCore;
using SportsStore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();
