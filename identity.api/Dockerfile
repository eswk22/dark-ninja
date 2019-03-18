FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["identity.api/identity.api.csproj", "identity.api/"]

RUN dotnet restore "identity.api/identity.api.csproj"
COPY . .
WORKDIR "/src/identity.api"
RUN dotnet build "identity.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "identity.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "identity.api.dll"]