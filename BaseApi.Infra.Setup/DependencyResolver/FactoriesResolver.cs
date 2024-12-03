using BaseApi.Domain.Factories;
using BaseApi.Domain.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Infra.Setup.DependencyResolver
{
    public static class FactoriesResolver
    {
        public static IServiceCollection AddFactories(this IServiceCollection service)
        {
            service.AddScoped<IUserFactory, UserFactory>();

            return service;
        }
    }
}
