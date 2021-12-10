#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
#WORKDIR /app
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["./Coodesh.SpaceFlightNews.Web.csproj", "Coodesh.SpaceFlightNews.Web/"]
#COPY ["../Coodesh.SpaceFlightNews.DTO/Coodesh.SpaceFlightNews.DTO.csproj", "Coodesh.SpaceFlightNews.DTO/"]
#COPY ["Coodesh.SpaceFlightNews.Interfaces/Coodesh.SpaceFlightNews.Interfaces.csproj", "Coodesh.SpaceFlightNews.Interfaces/"]
#COPY ["Coodesh.SpaceFlightNews.Jobs/Coodesh.SpaceFlightNews.Jobs.csproj", "Coodesh.SpaceFlightNews.Jobs/"]
#COPY ["Coodesh.SpaceFlightNews.Model/Coodesh.SpaceFlightNews.Model.csproj", "Coodesh.SpaceFlightNews.Model/"]
#COPY ["Coodesh.SpaceFlightNews.Repositories/Coodesh.SpaceFlightNews.Repositories.csproj", "Coodesh.SpaceFlightNews.Repositories/"]
#COPY ["Coodesh.SpaceFlightNews.Services/Coodesh.SpaceFlightNews.Services.csproj", "Coodesh.SpaceFlightNews.Services/"]
#
#RUN dotnet restore "Coodesh.SpaceFlightNews/Coodesh.SpaceFlightNews.Web.csproj"
#COPY . .
#WORKDIR "/Coodesh.SpaceFlightNews"
#RUN dotnet build "Coodesh.SpaceFlightNews.Web.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Coodesh.SpaceFlightNews.Web.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Coodesh.SpaceFlightNews.Web.dll"]

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