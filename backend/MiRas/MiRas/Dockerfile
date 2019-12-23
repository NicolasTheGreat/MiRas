FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiRas/MiRas.csproj", "MiRas/"]
RUN dotnet restore "MiRas/MiRas.csproj"
COPY . .
WORKDIR "/src/MiRas"
RUN dotnet build "MiRas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiRas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiRas.dll"]