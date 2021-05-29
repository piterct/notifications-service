using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.Service.Domain.Handlers;
using Notifications.Service.Domain.Services.SendGrid;
using Notifications.Service.Infra.Services;

namespace Notifications.Service.CrossCutting.DependencyInjectionConfig
{
    public static class DependencyRegister
    {
        public static void AddScoped(this IServiceCollection services, IConfiguration configuration)
        {
            #region Handlers
            services.AddTransient<NotificationHandler, NotificationHandler>();
            #endregion

            #region Services
            services.AddTransient<ISendGridService, SendGridService>();
            #endregion
        }
    }
}
