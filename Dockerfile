FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src
COPY . ./
WORKDIR /src/Coodesh.SpaceFlightNews
RUN dotnet clean
RUN dotnet restore
RUN dotnet publish -c Release -o /app/
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
COPY --from=build-env /app/ .
ENTRYPOINT ["dotnet", "Coodesh.SpaceFlightNews.Web.dll"]