FROM microsoft/dotnet:3.0-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:3.0-sdk-stretch AS build
WORKDIR /src
COPY ["ProductionMonitoring.WebHost/ProductionMonitoring.WebHost.csproj", "ProductionMonitoring.WebHost/"]
COPY ["ProductionMonitoring.Measure/ProductionMonitoring.Measure.csproj", "ProductionMonitoring.Measure/"]
COPY ["ProductionMonitoring/ProductionMonitoring.csproj", "ProductionMonitoring/"]
COPY ["ProductionMonitoring.Server/ProductionMonitoring.Server.csproj", "ProductionMonitoring.Server/"]
RUN dotnet restore "ProductionMonitoring.WebHost/ProductionMonitoring.WebHost.csproj"
COPY . .
WORKDIR "/src/ProductionMonitoring.WebHost"
RUN dotnet build "ProductionMonitoring.WebHost.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductionMonitoring.WebHost.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductionMonitoring.WebHost.dll"]
