FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["./manager.web.api.csproj", "manager.web.api/"]

RUN dotnet restore "manager.web.api/manager.web.api.csproj"
WORKDIR "/src/manager.web.api"
COPY . .
RUN dotnet build "manager.web.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "manager.web.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "manager.web.api.dll"]