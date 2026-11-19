FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Le .csproj seul d'abord : tant qu'il ne change pas, Docker réutilise le cache du restore.
COPY MonApp.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
# Tag passé par le pipeline : docker build --build-arg APP_VERSION=<tag> ...
ARG APP_VERSION=locale
ENV APP_VERSION=$APP_VERSION
EXPOSE 8080
ENTRYPOINT ["dotnet", "MonApp.dll"]
