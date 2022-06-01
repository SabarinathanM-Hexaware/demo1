#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Code/Demo1.Api/Demo1.Api.csproj", "Code/Demo1.Api/"]
COPY ["Code/Demo1.Entities/Demo1.Entities.csproj", "Code/Demo1.Entities/"]
COPY ["Code/Demo1.Common/Demo1.Common.csproj", "Code/Demo1.Common/"]
COPY ["Code/Demo1.Business/Demo1.Business.csproj", "Code/Demo1.Business/"]
COPY ["Code/Demo1.Data/Demo1.Data.csproj", "Code/Demo1.Data/"]
RUN dotnet restore "Code/Demo1.Api/Demo1.Api.csproj"
COPY . .
WORKDIR "/src/Code/Demo1.Api"
RUN dotnet build "Demo1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo1.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo1.Api.dll"]