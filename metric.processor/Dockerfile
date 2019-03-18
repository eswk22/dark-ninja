FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["metric.processor/metric.processor.csproj", "metric.processor/"]

RUN dotnet restore "metric.processor/metric.processor.csproj"
COPY . .
WORKDIR "/src/metric.processor"
RUN dotnet build "metric.processor.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "metric.processor.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "metric.processor.dll"]