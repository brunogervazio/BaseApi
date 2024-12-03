#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BaseApi.Web/BaseApi.Web.csproj", "BaseApi.Web/"]
COPY ["BaseApi.Domain/BaseApi.Domain.csproj", "BaseApi.Domain/"]
COPY ["BaseApi.Infra.Setup/BaseApi.Infra.Setup.csproj", "BaseApi.Infra.Setup/"]
COPY ["BaseApi.Application/BaseApi.Application.csproj", "BaseApi.Application/"]
COPY ["BaseApi.Data/BaseApi.Infra.Data.csproj", "BaseApi.Data/"]
RUN dotnet restore "./BaseApi.Web/BaseApi.Web.csproj"
COPY . .
WORKDIR "/src/BaseApi.Web"
RUN dotnet build "./BaseApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BaseApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseApi.Web.dll"]