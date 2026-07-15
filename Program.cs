using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using NewUserSite.Components;
using NewUserSite.Data;
using NewUserSite.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("default") ?? throw new NullReferenceException("Connection string 'default' not found.");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<NewUserService>();
builder.Services.AddScoped<DataStateService>();
builder.Services.AddDbContextFactory<NewUserDbContext>((DbContextOptionsBuilder options) => options.UseMySQL(connectionString));
builder.Services.AddDataProtection()
    .PersistKeysToDbContext<NewUserDbContext>();
builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<IClaimsTransformation, AdClaimsTransformer>();

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

app.UseAuthentication();
app.UseAuthorization();

app.Run();
