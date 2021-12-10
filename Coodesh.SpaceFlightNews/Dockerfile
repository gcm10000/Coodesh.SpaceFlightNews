FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /src
COPY ["Coodesh.SpaceFlightNews\Coodesh.SpaceFlightNews.Web.csproj", "Coodesh.SpaceFlightNews.Web/"]
COPY ["Coodesh.SpaceFlightNews.DTO\Coodesh.SpaceFlightNews.DTO.csproj", "Coodesh.SpaceFlightNews.DTO/"]
COPY ["Coodesh.SpaceFlightNews.Interfaces\Coodesh.SpaceFlightNews.Interfaces.csproj", "Coodesh.SpaceFlightNews.Interfaces/"]
COPY ["Coodesh.SpaceFlightNews.Jobs\Coodesh.SpaceFlightNews.Jobs.csproj", "Coodesh.SpaceFlightNews.Jobs/"]
COPY ["Coodesh.SpaceFlightNews.Model\Coodesh.SpaceFlightNews.Model.csproj", "Coodesh.SpaceFlightNews.Model/"]
COPY ["Coodesh.SpaceFlightNews.Repositories\Coodesh.SpaceFlightNews.Repositories.csproj", "Coodesh.SpaceFlightNews.Repositories/"]
COPY ["Coodesh.SpaceFlightNews.Services\Coodesh.SpaceFlightNews.Services.csproj", "Coodesh.SpaceFlightNews.Services/"]

RUN dotnet restore "Sabesp.CHApis.Web/Sabesp.CHApis.Web.csproj"
COPY . .
WORKDIR "/src/Sabesp.CHApis.Web"
RUN dotnet build "Coodesh.SpaceFlightNews.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coodesh.SpaceFlightNews.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coodesh.SpaceFlightNews.Web.dll"]