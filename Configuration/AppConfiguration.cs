using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Services;
using FarfetchToggleService.Settings;

namespace FarfetchToggleService.Configuration
{
    public class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
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
