# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install Python (required for wasm-tools)
RUN apt-get update && apt-get install -y python3 && \
    ln -s /usr/bin/python3 /usr/bin/python && \
    rm -rf /var/lib/apt/lists/*

# Install wasm-tools workload
RUN dotnet workload install wasm-tools

# Copy project file and restore
COPY ["Yahtzee.csproj", "./"]
RUN dotnet restore "Yahtzee.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "Yahtzee.csproj" -c Release -o /app/publish

# Runtime stage
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Copy published app
COPY --from=build /app/publish/wwwroot .

# Copy nginx config
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
