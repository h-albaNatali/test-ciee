FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ZooManager.API/ZooManager.API.csproj", "ZooManager.API/"]
COPY ["ZooManager.Application/ZooManager.Application.csproj", "ZooManager.Application/"]
COPY ["ZooManager.Infrastructure/ZooManager.Infrastructure.csproj", "ZooManager.Infrastructure/"]
COPY ["ZooManager.Domain/ZooManager.Domain.csproj", "ZooManager.Domain/"]
RUN dotnet restore "ZooManager.API/ZooManager.API.csproj"
COPY . .
WORKDIR "/src/ZooManager.API"
RUN dotnet build "ZooManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZooManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZooManager.API.dll"]
