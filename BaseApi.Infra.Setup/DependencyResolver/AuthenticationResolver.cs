using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BaseApi.Infra.Setup.DependencyResolver
{
    public static class AuthenticationResolver
    {
        public static IServiceCollection AddAuth(this IServiceCollection service, byte[] jwtKey)
        {
            service.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return service;
        }
    }
}
