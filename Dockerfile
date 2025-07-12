FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SANJUAN.csproj", "./"]
RUN dotnet restore "./SANJUAN.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SANJUAN.csproj" -c Release -o /app/build
RUN dotnet publish "SANJUAN.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SANJUAN.dll"]
