FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src
COPY . ./
WORKDIR /src/Coodesh.SpaceFlightNews.Web
RUN dotnet restore
RUN dotnet publish -c Release -o /app/
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV ASPNETCORE_URLS=http://+:5000
ENV DefaultConnection="User ID=ntjxfdpsgvblqz;Password=e0912816bde6f999592d2dbb412abd394df16bbd73d382174ad87e01c9cdf2fa;Host=ec2-52-1-68-9.compute-1.amazonaws.com;Port=5432;Database=d73n25hq8srjc9;Connection Lifetime=0;SSL Mode=Require;Trust Server Certificate=true"
WORKDIR /app
COPY --from=build-env /app/ .
ENTRYPOINT ["dotnet", "Coodesh.SpaceFlightNews.Web.dll"]