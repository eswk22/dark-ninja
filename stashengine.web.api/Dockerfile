FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["stashengine.web.api/stashengine.web.api.csproj", "stashengine.web.api/"]

RUN dotnet restore "stashengine.web.api/stashengine.web.api.csproj"
COPY . .
WORKDIR "/src/stashengine.web.api"
RUN dotnet build "stashengine.web.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "stashengine.web.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "stashengine.web.api.dll"]