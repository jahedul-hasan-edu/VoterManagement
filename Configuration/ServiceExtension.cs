using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Infrastructure;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Voter.API.Common;

public static class ServiceExtension
{
    const string allowAllOrigins = "AllowAllOrigins";
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        #region Web Host
        builder.WebHost.UseKestrel();

        builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());

        builder.WebHost.UseIISIntegration();

        #endregion

        #region Serilog

        builder.Host.UseSerilog((context, conf) =>
        {
            conf
                .MinimumLevel.Error() 
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error) 
                .Enrich.FromLogContext()
                .WriteTo.Console() 
                .WriteTo.PostgreSQL(
                    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                    tableName: "\"AppLog\"",
                    needAutoCreateTable: true,
                    columnOptions: new Dictionary<string, ColumnWriterBase>
                    {
                        { "timestamp", new TimestampColumnWriter() },
                        { "level", new LevelColumnWriter() },
                        { "message", new RenderedMessageColumnWriter() },
                        { "exception", new ExceptionColumnWriter() },
                        { "properties", new PropertiesColumnWriter() }
                    }
                );
        });

        Serilog.Debugging.SelfLog.Enable(msg =>
        {
            Console.WriteLine(msg); 
            File.AppendAllText("serilog-errors.txt", msg); 
        });

        #endregion

        #region CORS Config
        builder.Services.AddHttpContextAccessor();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy(allowAllOrigins, policy =>
            {

                policy.AllowCredentials()
                    .AllowAnyOrigin()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        #endregion

        #region Endpoint Config

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(opt =>

        {
            opt.CustomSchemaIds(x => x.FullName);
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Voter Api",
                Version = "v1",
                Description = "Voter Api",
                Contact = new OpenApiContact
                {
                    Name = "Voter"
                }
            });

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer", // must be lower case
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, new string[] { }}
            });
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

        builder.Services
        .AddControllers()
        .AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        });

        #endregion

       

        #region Service Register Reflection Config 
        builder.Services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Voter.Core"));
        builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        builder.Services.Scan(scan => scan.FromAssemblies(AppDomain.CurrentDomain.Load("Voter.Core"))
        .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Validator")))
        .AsImplementedInterfaces()
        .WithTransientLifetime());

        builder.Services.Scan(scan => scan.FromAssemblies(AppDomain.CurrentDomain.Load("Voter.Core"))
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        #endregion

        #region DB Context Config
        builder.Services
            .AddDbContext<AppDbContext>(opts =>
            {
                opts
                    .UseNpgsql(
                        builder.Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging();
            });

        #endregion

        return builder;
    }
}
