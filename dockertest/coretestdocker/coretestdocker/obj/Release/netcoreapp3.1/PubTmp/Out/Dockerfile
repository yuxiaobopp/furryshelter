#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["coretestdocker/coretestdocker.csproj", "coretestdocker/"]
#RUN dotnet restore "coretestdocker/coretestdocker.csproj"
#COPY . .
#WORKDIR "/src/coretestdocker"
#RUN dotnet build "coretestdocker.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "coretestdocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
#COPY --from=publish /app/publish .
COPY . .
ENTRYPOINT ["dotnet", "coretestdocker.dll"]