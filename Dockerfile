FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

ARG BUILD_CONFIGURATION=Release

WORKDIR /App
EXPOSE 80
EXPOSE 443
EXPOSE 666

COPY AdsService/ /App

RUN dotnet restore

RUN dotnet publish -c ${BUILD_CONFIGURATION} -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /App
COPY --from=build-env /App/out .
CMD ["dotnet", "AdsService.dll"]