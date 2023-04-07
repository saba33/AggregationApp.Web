# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy and restore
COPY . .
RUN dotnet restore

# Build
RUN dotnet build -c Release -o /app/build

# Development stage
FROM build AS dev
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

# Copy built files
COPY --from=build /app/build .

# Set entrypoint to run application
ENTRYPOINT ["dotnet", "AggregationApp.Web.dll"]