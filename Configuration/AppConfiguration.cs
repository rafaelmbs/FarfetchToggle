using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Services;
using FarfetchToggleService.Settings;
using AutoMapper;
using System.Reflection;
using FarfetchToggleService.Repository.Mapping;

namespace FarfetchToggleService.Configuration
{
    public class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //Automapper
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
