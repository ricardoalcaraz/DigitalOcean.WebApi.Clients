FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DigitalOcean.Client.Extensions/DigitalOcean.Client.Extensions.csproj", "DigitalOcean.Client.Extensions/"]
RUN dotnet restore "DigitalOcean.Client.Extensions/DigitalOcean.Client.Extensions.csproj"
COPY . .
WORKDIR "/src/DigitalOcean.Client.Extensions"
RUN dotnet build "DigitalOcean.Client.Extensions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalOcean.Client.Extensions.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalOcean.Client.Extensions.dll"]
