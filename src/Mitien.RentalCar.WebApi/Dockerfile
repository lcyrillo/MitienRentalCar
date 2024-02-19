FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Mitien.RentalCar.Api/Mitien.RentalCar.Api.csproj", "Mitien.RentalCar.Api/"]
COPY ["Mitien.RentalCar.Business/Mitien.RentalCar.Business.csproj", "Mitien.RentalCar.Business/"]
COPY ["Mitien.RentalCar.Repository/Mitien.RentalCar.Repository.csproj", "Mitien.RentalCar.Repository/"]
COPY ["Mitien.RentalCar.Tests/Mitien.RentalCar.Tests.csproj", "Mitien.RentalCar.Tests/"]
RUN dotnet restore "Mitien.RentalCar.Api/Mitien.RentalCar.Api.csproj"
COPY . .
WORKDIR "/src/Mitien.RentalCar.Api"
RUN dotnet build "Mitien.RentalCar.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Mitien.RentalCar.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT [ "dotnet", "Mitien.RentalCar.Api.dll" ]