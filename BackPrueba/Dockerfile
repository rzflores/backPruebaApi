# Usa la imagen oficial de .NET 7.0 para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos y realiza la compilación
COPY . ./
RUN dotnet publish -c Release -o out

# Usa una imagen más ligera para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copia los archivos publicados de la fase de compilación
COPY --from=build /app/out .

# Exponer el puerto en el que la aplicación se ejecutará
EXPOSE 80

# Configurar la variable de entorno para la cadena de conexión a SQL Server
ENV cadenaSQL="Data Source=.;Initial Catalog=APIDB;User ID=usuariotest;Password=Abc1234$;Integrated Security=false;TrustServerCertificate=True;"


# Ejecutar la aplicación al iniciar el contenedor
ENTRYPOINT ["dotnet", "BackPrueba.dll"]



