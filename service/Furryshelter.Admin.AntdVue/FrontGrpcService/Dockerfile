#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM registry.cn-hangzhou.aliyuncs.com/colder-public/aspnet:5.0.2
WORKDIR /app
EXPOSE 5000

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["FrontGrpcService/FrontGrpcService.csproj", "FrontGrpcService/"]
#RUN dotnet restore "FrontGrpcService/FrontGrpcService.csproj"
#COPY . .
#WORKDIR "/src/FrontGrpcService"
#RUN dotnet build "FrontGrpcService.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "FrontGrpcService.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
COPY . .
ENTRYPOINT ["dotnet", "FrontGrpcService.dll"]