FROM mcr.microsoft.com/dotnet/sdk:7.0 AS migrator

WORKDIR /src

COPY . .

RUN dotnet tool install --global dotnet-ef --version 7.0.14

ENV PATH="${PATH}:/root/.dotnet/tools"

ENTRYPOINT dotnet ef database update --project ZooManager.Infrastructure --startup-project ZooManager.API
