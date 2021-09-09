#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Apps/WebApp.Client/WebApp.Client.csproj", "Apps/WebApp.Client/"]
RUN dotnet restore "Apps/WebApp.Client/WebApp.Client.csproj"
COPY . .
WORKDIR "/src/Apps/WebApp.Client"
RUN dotnet build "WebApp.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.Client.dll"]