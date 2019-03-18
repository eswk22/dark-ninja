FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["bigben/bigben.csproj", "bigben/"]

RUN dotnet restore "bigben/bigben.csproj"
COPY . .
WORKDIR "/src/bigben"
RUN dotnet build "bigben.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "bigben.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "bigben.dll"]