using BaseApi.Domain.Interfaces.Repositories;
using BaseApi.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Infra.Setup.DependencyResolver
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IAccountRepository, AccountRepository>();

            return service;
        }
    }
}
