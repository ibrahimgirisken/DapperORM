using DapperORM.Application;
using DapperORM.Identity;
using DapperORM.Infrastructure;
using DapperORM.Persistence;
using System.Globalization;
using WebAPI.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddIdentityDependencies();
builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies();
builder.Services.AddInfrastructureDependencies();

//Identity

builder.Services.AddCors(option =>
option.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new("tr-TR");

    CultureInfo[] cultures = new CultureInfo[]
    {
        new("tr-TR"),
        new("en-US"),
        new("fr-FR")
    };

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();
var app = builder.Build();


// Configure the HTTP request pipelineAddApplicationDependencies
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
