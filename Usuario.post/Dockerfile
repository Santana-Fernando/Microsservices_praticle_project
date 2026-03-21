# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Usuario.post/Usuario.post.csproj", "Usuario.post/"]

RUN dotnet restore "Usuario.post/Usuario.post.csproj"

COPY . .

WORKDIR "/src/Usuario.post"
RUN dotnet build "Usuario.post.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Usuario.post.csproj" -c Release -o /app/publish

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Usuario.post.dll"]