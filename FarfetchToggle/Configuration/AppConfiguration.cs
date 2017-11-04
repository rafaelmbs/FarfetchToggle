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

namespace FarfetchToggle.Configuration
{
    public class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMissingTypeMaps = true;
                cfg.EnableNullPropagationForQueryMapping = true;

                cfg.AddProfile(new ToggleGetMap());
                cfg.AddProfile(new ToggleGetByIdMap());
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
