FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["manager.worker.distributor/manager.worker.distributor.csproj", "manager.worker.distributor/"]

RUN dotnet restore "manager.worker.distributor/manager.worker.distributor.csproj"
COPY . .
WORKDIR "/src/manager.worker.distributor"
RUN dotnet build "manager.worker.distributor.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "manager.worker.distributor.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "manager.worker.distributor.dll"]