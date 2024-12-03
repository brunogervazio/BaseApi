using BaseApi.Application.Interfaces;
using BaseApi.Application.Services;
using BaseApi.Domain.Interfaces.Services;
using BaseApi.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Infra.Setup.DependencyResolver
{
    public static class ServicesResolver
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<TokenService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IPasswordEncryptService, PasswordEncryptService>();
            service.AddScoped<IContextService, ContextService>();

            return service;
        }
    }
}
