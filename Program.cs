using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Antiforgery;
using StudentAssignmentTracker.Components;
using Microsoft.EntityFrameworkCore;
using StudentAssignmentTracker.Data;
using StudentAssignmentTracker.Interfaces;
using StudentAssignmentTracker.Models;
using StudentAssignmentTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options => options.FallbackPolicy = options.DefaultPolicy);
builder.Services.AddCascadingAuthenticationState();
builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/account/login");
builder.Services.AddScoped<IAuthService, AuthService>();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapPost("/account/logout", async (
    HttpContext httpContext,
    IAntiforgery antiforgery,
    IAuthService authService) =>
{
    if (!await antiforgery.IsRequestValidAsync(httpContext))
    {
        return Results.BadRequest();
    }

    await authService.LogoutAsync();
    return Results.LocalRedirect("/account/login");
})
    .RequireAuthorization();

app.MapStaticAssets().AllowAnonymous();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
