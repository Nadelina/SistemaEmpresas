FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.sln .
COPY SistemaEmpresas/*.csproj ./SistemaEmpresas/
COPY SistemaEmpresas.Data/*.csproj ./SistemaEmpresas.Data/
COPY SistemaEmpresas.Test/*.csproj ./SistemaEmpresas.Test/
RUN dotnet restore

COPY SistemaEmpresas/. ./SistemaEmpresas/
COPY SistemaEmpresas.Data/. ./SistemaEmpresas.Data/
WORKDIR /app/SistemaEmpresas.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/SistemaEmpresas.Api/out ./
ENTRYPOINT ["dotnet", "SistemaEmpresas.Api.dll"]
