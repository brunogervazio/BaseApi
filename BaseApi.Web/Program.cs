using BaseApi.Infra.Setup.Builder;

var builder = WebApplication.CreateBuilder(args);
new WebApiBuilder().Run(builder);