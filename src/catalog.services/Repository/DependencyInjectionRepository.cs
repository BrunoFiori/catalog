using Catalog.Services.Repository.Entities;
using Commom;

namespace Catalog.Services.Repository
{
    public static class DependencyInjectionRepository
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {   
            services.AddMongo()
                    .AddRepository<Item>("Items");
                    
            return services;
        }
    }
}
