
# 1. Aşama: Yapılandırma
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
WORKDIR /app
COPY . .

# 2. Aşama: Derleme
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# 3. Aşama: Çalıştırma
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Person.API.dll"]

# docker build -t person-service-image -f Dockerfile .