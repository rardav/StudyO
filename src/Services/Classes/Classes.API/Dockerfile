#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Classes/Classes.API/Classes.API.csproj", "src/Services/Classes/Classes.API/"]
COPY ["src/Services/Classes/Classes.Infrastructure/Classes.Infrastructure.csproj", "src/Services/Classes/Classes.Infrastructure/"]
COPY ["src/Services/Classes/Classes.Domain/Classes.Domain.csproj", "src/Services/Classes/Classes.Domain/"]
RUN dotnet restore "src/Services/Classes/Classes.API/Classes.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Classes/Classes.API"
RUN dotnet build "Classes.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Classes.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Classes.API.dll"]
