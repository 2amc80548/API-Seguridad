# ProjectMod1DevOps

API REST de sistema de inventario desarrollada con .NET 10, SQL Server y Docker.

## Requisitos previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

  dotnet tool install --global dotnet-ef

## Pasos para correr el proyecto

### 1. Clonar el repositorio

    git clone https://github.com/tu-usuario/tu-repo.git
    cd tu-repo/ProjectMod1DevOps

### 2. Crear el archivo .env

Dentro de la carpeta ProjectMod1DevOps crea un archivo .env con tus propias credenciales:

    SA_PASSWORD=<tu-password>
    DB_NAME=DbInventory
    APP_PORT=<puerto-disponible-en-tu-maquina>

Nota: DB_NAME debe ser igual en todo el equipo para que las migraciones funcionen correctamente.

### 3. Configurar User Secrets (solo si corres desde Rider)

Si vas a correr el proyecto desde Rider con F5 en lugar de Docker, configura los User Secrets:

    dotnet user-secrets init
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1437;Database=DbInventory;User Id=sa;Password=<tu-password>;TrustServerCertificate=True"

### 4. Levantar los contenedores con Docker

    docker-compose up -d

Espera unos segundos a que SQL Server y la aplicacion arranquen. Verifica con:

    docker ps

Deberias ver corriendo los contenedores sqlserver2022-projectmod1 y projectmod1devops.

### 5. Correr las migraciones

    dotnet ef database update

### 6. Verificar en Swagger

Abre el navegador y entra a:

    http://localhost:<APP_PORT>/swagger

Donde APP_PORT es el valor que definiste en tu archivo .env.

## Notas

- El archivo .env nunca debe subirse al repositorio
- Los User Secrets son locales de cada desarrollador, no van al repositorio
- En produccion las credenciales se manejan desde Azure App Service y Azure DevOps Variable Groups
- Para bajar los contenedores sin perder datos: docker-compose down
- Para bajar los contenedores eliminando datos: docker-compose down -v