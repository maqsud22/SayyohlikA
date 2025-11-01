#!/usr/bin/env bash
set -o errexit

# Bazani yangilash (ixtiyoriy, agar migratsiya bo‘lsa)
dotnet ef database update || echo "Migration skipped"

# Build loyihani
dotnet publish -c Release -o out
