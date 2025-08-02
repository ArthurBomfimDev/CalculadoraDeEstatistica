@echo off
cd /d "%~dp0"
start cmd /k "dotnet run --project src\CalculadoraEstatisca.Api\CalculadoraEstatisca.Api.csproj --no-build"
