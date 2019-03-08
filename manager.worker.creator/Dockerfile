FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["manager.worker.creator/manager.worker.creator.csproj", "manager.worker.creator/"]

RUN dotnet restore "manager.worker.creator/manager.worker.creator.csproj"
COPY . .
WORKDIR "/src/manager.worker.creator"
RUN dotnet build "manager.worker.creator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "manager.worker.creator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "manager.worker.creator.dll"]