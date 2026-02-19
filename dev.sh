#!/bin/bash
echo "Stopping any running dotnet processes..."
taskkill //F //IM dotnet.exe 2>/dev/null || true
sleep 2

echo "Cleaning build artifacts..."
rm -rf bin obj

echo "Starting dev server..."
echo "Once the server starts, do a hard refresh: Ctrl+Shift+R"
cd "$(dirname "$0")" && dotnet run
