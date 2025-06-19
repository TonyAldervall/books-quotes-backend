#!/bin/bash
set -e

echo "Running database migrations..."
dotnet ef database update

echo "Starting the application..."
exec dotnet WebAPI.dll