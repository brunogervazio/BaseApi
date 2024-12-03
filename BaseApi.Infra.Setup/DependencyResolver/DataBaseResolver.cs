using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BaseApi.Infra.Data.Context;

namespace BaseApi.Infra.Setup.DependencyResolver
{
    public static class DataBaseResolver
    {
        public static IServiceCollection AddDataBaseContext(this IServiceCollection service, string conectionString)
        {
            _ = service.AddDbContext<AppDbContext>((opt) => opt.UseSqlServer(conectionString));
            return service;
        }
    }
}
