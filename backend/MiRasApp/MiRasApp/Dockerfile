FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiRasApp/MiRasApp.csproj", "MiRasApp/"]
RUN dotnet restore "MiRasApp/MiRasApp.csproj"
COPY . .
WORKDIR "/src/MiRasApp"
RUN dotnet build "MiRasApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiRasApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiRasApp.dll"]