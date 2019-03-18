FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["metric.parser/metric.parser.csproj", "metric.parser/"]

RUN dotnet restore "metric.parser/metric.parser.csproj"
COPY . .
WORKDIR "/src/metric.parser"
RUN dotnet build "metric.parser.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "metric.parser.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "metric.parser.dll"]