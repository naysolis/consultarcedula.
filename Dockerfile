# Imagen base del SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY . ./
RUN dotnet publish -c Release -o out

# Imagen runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Puerto que usará la app
EXPOSE 80

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "ConsultarCedulaApp.dll"]
