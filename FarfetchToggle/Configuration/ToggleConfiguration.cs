using System.Reflection;
using AutoMapper;
using FarfetchToggle.Authorization;
using FarfetchToggle.Repository.Mapping;
using FarfetchToggle.Repository.Repositories;
using FarfetchToggle.Services;
using FarfetchToggle.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FarfetchToggle.Configuration
{
    public class ToggleConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMissingTypeMaps = true;
                cfg.EnableNullPropagationForQueryMapping = true;

                cfg.AddProfile(new ToggleGetMapping());
                cfg.AddProfile(new ToggleGetByIdMapping());
                cfg.AddProfiles(Assembly.GetEntryAssembly());
            });
            services.AddSingleton(Mapper.Instance);

            //Auth
            string domain = $"https://{configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = configuration["Auth0:ApiIdentifier"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
                options.AddPolicy("create:messages", policy => policy.Requirements.Add(new HasScopeRequirement("create:messages", domain)));
            });

            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info 
                {
                    Title = "Farfetch Toggle", 
                    Version = "v1" 
                });
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
            
            //AppSettings
            services.Configure<AppSettings>(configuration);

            //Services
            services.AddTransient<MessageService>();
            services.AddTransient<ToggleService>();

            //Repositories
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IToggleRepository, ToggleRepository>();
        }
    }
}
