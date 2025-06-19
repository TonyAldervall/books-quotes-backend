# Build steg - bygger och publicerar din app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Kopiera csproj och gör restore
COPY *.csproj ./
RUN dotnet restore

# Kopiera resten och bygg appen i release-läge
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime steg - kör appen i lättvikts-ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Kopiera publicerade filer från build-steget
COPY --from=build /app/out ./

# Exponera port 80
EXPOSE 80

# Kör din app
ENTRYPOINT ["dotnet", "WebAPI.dll"]