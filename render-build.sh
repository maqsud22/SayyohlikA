#!/usr/bin/env bash
set -o errexit

# 🚀 Render build skripti — tozalaydi, tiklaydi va build qiladi

echo "🧹 Cleaning previous builds..."
dotnet clean

echo "🧺 Clearing NuGet cache..."
dotnet nuget locals all --clear

echo "📦 Restoring dependencies..."
dotnet restore

# 🗄️ Migratsiyani ishga tushirish (agar mavjud bo‘lsa)
echo "🔄 Applying EF Core migrations (if any)..."
dotnet ef database update || echo "⚠️ No migrations or skipped."

echo "🏗 Building the project..."
dotnet build --configuration Release

echo "🚀 Publishing the app..."
dotnet publish -c Release -o out

echo "✅ Build completed successfully!"
