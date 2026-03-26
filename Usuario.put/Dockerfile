# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Usuario.put/Usuario.put.csproj", "Usuario.put/"]
COPY ["Usuario.Application/Usuario.Application.csproj", "Usuario.Application/"]
COPY ["Usuarios.Domain/Usuario.Domain.csproj", "Usuarios.Domain/"]
COPY ["Usuario.Infra/Usuario.Infra.csproj", "Usuario.Infra/"]

RUN dotnet restore "Usuario.put/Usuario.put.csproj"

COPY . .

RUN ls -R /src

WORKDIR "/src/Usuario.put"
RUN dotnet build "Usuario.put.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Usuario.put.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Usuario.put.dll"]