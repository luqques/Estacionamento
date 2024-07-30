FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Estacionamento.Api/Estacionamento.Api.csproj", "Estacionamento.Api/"]
COPY ["Estacionamento.Data/Estacionamento.Data.csproj", "Estacionamento.Data/"]
COPY ["Estacionamento.Domain/Estacionamento.Domain.csproj", "Estacionamento.Domain/"]
COPY ["Estacionamento.Service/Estacionamento.Service.csproj", "Estacionamento.Service/"]
RUN dotnet restore "./Estacionamento.Api/Estacionamento.Api.csproj"
COPY . .
WORKDIR "/src/Estacionamento.Api"
RUN dotnet build "./Estacionamento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Estacionamento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Estacionamento.Api.dll"]