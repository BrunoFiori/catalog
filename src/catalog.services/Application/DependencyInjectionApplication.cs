using Commom;

namespace Catalog.Services.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMassTransitWithRabbitMq();
            services.AddScoped<IItemService, ItemService>();
            return services;
        }
    }
}
