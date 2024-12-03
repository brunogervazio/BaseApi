using Microsoft.AspNetCore.Builder;

namespace BaseApi.Infra.Setup.DependencyResolver
{
    public static class CorsResolver
    {
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors(
                opt => opt
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true)
                    .AllowCredentials()
            );

            return app;
        }
    }
}
