FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app   
    
COPY ./API/Letters.API/*.csproj ./API/Letters.API/
COPY ./API/Letters.Infrastructure/*.csproj ./API/Letters.Infrastructure/

RUN dotnet restore ./API/Letters.API/Letters.API.csproj

COPY . .
WORKDIR "/app/API/Letters.API"
RUN dotnet build "Letters.API.csproj" -c Release 

FROM build as publish
RUN dotnet publish "Letters.API.csproj" -c Release -o /app/publish
 

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Letters.API.dll"]