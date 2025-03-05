# Use the base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Corrected paths inside the 'src' directory
COPY ["TajMaster.Application/TajMaster.Application.csproj", "TajMaster.Application/"]
COPY ["TajMaster.Domain/TajMaster.Domain.csproj", "TajMaster.Domain/"]
COPY ["TajMaster.Infrastructure/TajMaster.Infrastructure.csproj", "TajMaster.Infrastructure/"]
COPY ["TajMaster.WebApi/TajMaster.WebApi.csproj", "TajMaster.WebApi/"]

# Restore project dependencies
RUN dotnet restore "TajMaster.WebApi/TajMaster.WebApi.csproj"

# Copy the entire source code
COPY . .

# Build the application
WORKDIR "/src/TajMaster.WebApi"
RUN dotnet build "TajMaster.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TajMaster.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Create the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TajMaster.WebApi.dll"]
