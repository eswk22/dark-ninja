FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["application.utility.api/application.utility.api.csproj", "application.utility.api/"]

RUN dotnet restore "application.utility.api/application.utility.api.csproj"
COPY . .
WORKDIR "/src/application.utility.api"
RUN dotnet build "application.utility.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "application.utility.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "application.utility.api.dll"]