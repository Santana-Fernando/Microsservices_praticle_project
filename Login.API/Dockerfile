# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Login.API/Login.API.csproj", "Login.API/"]
COPY ["Usuario.Application/Usuario.Application.csproj", "Usuario.Application/"]
COPY ["Usuarios.Domain/Usuario.Domain.csproj", "Usuarios.Domain/"]
COPY ["Usuario.Infra/Usuario.Infra.csproj", "Usuario.Infra/"]

RUN dotnet restore "Login.API/Login.API.csproj"

COPY . .

RUN ls -R /src

WORKDIR "/src/Login.API"
RUN dotnet build "Login.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Login.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Login.API.dll"]