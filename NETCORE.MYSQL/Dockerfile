##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["NETCORE.MYSQL/NETCORE.MYSQL.csproj", "NETCORE.MYSQL/"]
#RUN dotnet restore "NETCORE.MYSQL/NETCORE.MYSQL.csproj"
#COPY . .
#WORKDIR "/src/NETCORE.MYSQL"
#RUN dotnet build "NETCORE.MYSQL.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "NETCORE.MYSQL.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "NETCORE.MYSQL.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
MAINTAINER Amr Moataz <AmrMoatazFCIS@gmail.com>
WORKDIR /app
COPY NETCORE.MYSQL/ ./NETCORE.MYSQL
COPY NETCORE.MYSQL.Data/ ./NETCORE.MYSQL.Data

ENV ASPNETCORE_URLS:http=//+:80;https://+:443
ENV ASPNETCORE_ENVIRONMENT=Staging
ENV ASPNETCORE_HTTPS_PORT=5254

# Publish
RUN dotnet publish NETCORE.MYSQL/NETCORE.MYSQL.csproj -c Release -o ../out

WORKDIR /out
RUN rm -rf /app

ENTRYPOINT ["dotnet", "NETCORE.MYSQL.dll"]

EXPOSE 80