# Clean and restart the Blazor dev server
# Run with: .\dev.ps1

Write-Host "Stopping any running dotnet processes..." -ForegroundColor Yellow
Get-Process -Name "dotnet" -ErrorAction SilentlyContinue | Stop-Process -Force

Write-Host "Cleaning build artifacts..." -ForegroundColor Yellow
Remove-Item -Recurse -Force -ErrorAction SilentlyContinue "bin", "obj"

Write-Host "Starting dev server..." -ForegroundColor Green
Write-Host "Once the server starts, do a hard refresh: Ctrl+Shift+R" -ForegroundColor Cyan
dotnet run
