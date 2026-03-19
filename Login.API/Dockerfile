# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Usuario.API/Login.API/Login.API.csproj", "Usuario.API/Login.API/"]

RUN dotnet restore "Usuario.API/Login.API/Login.API.csproj"

COPY . .

WORKDIR "/src/Usuario.API/Login.API"
RUN dotnet build "Login.API.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Login.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Login.API.dll"]