# Use a imagem oficial do .NET SDK 6 para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie os arquivos .csproj e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie todos os outros arquivos e compile a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Use a imagem runtime do .NET 6 para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Estacionamento.Api.dll"]