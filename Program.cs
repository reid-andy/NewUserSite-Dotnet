using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using NewUserSite.Components;
using NewUserSite.Data;
using NewUserSite.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("default") ?? throw new NullReferenceException("Connection string 'default' not found.");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<NewUserService>();
builder.Services.AddSingleton<DataStateService>();
builder.Services.AddDbContextFactory<NewUserDbContext>((DbContextOptionsBuilder options) => options.UseMySQL(connectionString));
builder.Services.AddDataProtection()
    .PersistKeysToDbContext<NewUserDbContext>();
builder.Services.AddQuickGridEntityFrameworkAdapter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
