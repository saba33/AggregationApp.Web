# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy and restore
COPY . .
RUN dotnet restore

# Build
RUN dotnet build -c Release -o /app/build

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

# Copy built files
COPY --from=build /app/build .

# Set entrypoint to run application
ENTRYPOINT ["dotnet", "AggregationApp.Web.dll"]

