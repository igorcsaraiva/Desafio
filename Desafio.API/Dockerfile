#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
FROM base AS final

WORKDIR /app
COPY ["/bin/Release/net5.0/publish", "/app"] 
ENTRYPOINT ["dotnet", "Desafio.API.dll"]