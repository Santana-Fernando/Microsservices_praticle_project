# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Usuario.get/Usuario.get.csproj", "Usuario.get/"]
COPY ["Usuario.Application/Usuario.Application.csproj", "Usuario.Application/"]
COPY ["Usuarios.Domain/Usuario.Domain.csproj", "Usuarios.Domain/"]
COPY ["Usuario.Infra/Usuario.Infra.csproj", "Usuario.Infra/"]

RUN dotnet restore "Usuario.get/Usuario.get.csproj"

COPY . .

RUN ls -R /src

WORKDIR "/src/Usuario.get"
RUN dotnet build "Usuario.get.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Usuario.get.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Usuario.get.dll"]