# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sb_Account/ACCOUNT.API.csproj", "Sb_Account/"]
COPY ["ACCOUNT.Infrastructure/ACCOUNT.Infrastructure.csproj", "ACCOUNT.Infrastructure/"]
COPY ["ACCOUNT.Domain/ACCOUNT.Domain.csproj", "ACCOUNT.Domain/"]
COPY ["Application/ACCOUNT.Application.csproj", "Application/"]
COPY ["BRANCHES.Application/BRANCHES.Application.csproj", "BRANCHES.Application/"]
COPY ["BRANCHES.Domain/BRANCHES.Domain.csproj", "BRANCHES.Domain/"]
COPY ["BRANCHES.Infrastructure/BRANCHES.Infrastructure.csproj", "BRANCHES.Infrastructure/"]
RUN dotnet restore "./Sb_Account/ACCOUNT.API.csproj"
COPY . .
WORKDIR "/src/Sb_Account"
RUN dotnet build "./ACCOUNT.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ACCOUNT.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ACCOUNT.API.dll"]