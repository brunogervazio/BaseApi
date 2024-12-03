using BaseApi.Infra.Setup.DependencyResolver;
using BaseApi.Shared.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace BaseApi.Infra.Setup.Builder
{
    public class WebApiBuilder
    {
        private ConfigurationManager _configuration = null!;

        public void Run(WebApplicationBuilder builder)
        {
            _configuration = builder.Configuration;

            ConfigureServices(builder.Services);
            ConfigureBuilder(builder.Build());
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var jwtKey = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]!);
            var connectionString = _configuration.GetConnectionString("SqlServer")!;

            services.Configure<JwtSettings>(_configuration.GetSection("Jwt"));

            services
                .AddServices()
                .AddRepositories()
                .AddFactories()
                .AddSwagger()
                .AddAuth(jwtKey)
                .AddDataBaseContext(connectionString)
                .AddControllers();

            services.AddHttpContextAccessor();
        }

        private static void ConfigureBuilder(WebApplication app)
        {
            app.UseSwaggerConfiguration()
                .UseCorsConfiguration()
                .UseAuthentication()
                .UseAuthorization()
                .UseHttpsRedirection();

            app.MapControllers();
            app.Run();
        }
    }
}
