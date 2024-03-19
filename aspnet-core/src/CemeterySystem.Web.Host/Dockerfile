FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/CemeterySystem.Web.Host/CemeterySystem.Web.Host.csproj", "src/CemeterySystem.Web.Host/"]
COPY ["src/CemeterySystem.Web.Core/CemeterySystem.Web.Core.csproj", "src/CemeterySystem.Web.Core/"]
COPY ["src/CemeterySystem.Application/CemeterySystem.Application.csproj", "src/CemeterySystem.Application/"]
COPY ["src/CemeterySystem.Core/CemeterySystem.Core.csproj", "src/CemeterySystem.Core/"]
COPY ["src/CemeterySystem.EntityFrameworkCore/CemeterySystem.EntityFrameworkCore.csproj", "src/CemeterySystem.EntityFrameworkCore/"]
WORKDIR "/src/src/CemeterySystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/CemeterySystem.Web.Host", "src/CemeterySystem.Web.Host"]
COPY ["src/CemeterySystem.Web.Core", "src/CemeterySystem.Web.Core"]
COPY ["src/CemeterySystem.Application", "src/CemeterySystem.Application"]
COPY ["src/CemeterySystem.Core", "src/CemeterySystem.Core"]
COPY ["src/CemeterySystem.EntityFrameworkCore", "src/CemeterySystem.EntityFrameworkCore"]
WORKDIR "/src/src/CemeterySystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "CemeterySystem.Web.Host.dll"]
