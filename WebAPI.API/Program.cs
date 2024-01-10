using DapperORM.Infrastructure;
using DapperORM.Persistence;
using System.Globalization;
using WebAPI.API.Middlewares;
using DapperORM.Application;
using Microsoft.AspNetCore.Identity;
using DapperORM.Identity;
using DapperORM.Persistence.Repositories.Identity;
using DapperORM.Persistence.Repositories.Identity.Tables;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddApplicationDependencies();
        builder.Services.AddPersistenceDependencies();
        builder.Services.AddInfrastructureDependencies();
        builder.Services.AddIdentity<IdentityUser, ExtendedIdentityRole>(options => { options.Lockout.MaxFailedAccessAttempts = 3; })
           .AddDapperStores(options =>
           {
               options.AddRolesTable<ExtendedRolesTable, ExtendedIdentityRole>();
           }).AddDefaultUI().AddDefaultTokenProviders();
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

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
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer("Admin", options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = true, //Oluþturulacak token deðerini kimlerin/hangi originlerin/sitelerin kullanýcý belirlediðimiz deðerdir. -> www.bilmemne.com
                    ValidateIssuer = true, //Oluþturulacak token deðerini kimin daðýttýný ifade edeceðimiz alandýr. -> www.myapi.com
                    ValidateLifetime = true, //Oluþturulan token deðerinin süresini kontrol edecek olan doðrulamadýr.
                    ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden suciry key verisinin doðrulanmasýdýr.
                    ValidAudience = builder.Configuration["Token:Audience"],
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                };
            });


        var app = builder.Build();

        // Configure the HTTP request pipelineAddApplicationDependencies
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRequestLocalization();
        app.UseRequestLocalizationCookies();
        app.UseCors();
        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.Run();
    }
}