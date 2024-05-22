# Etapa 1: Construir la aplicación
# Utiliza la imagen base de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY ["Medical.MinimalAPI.WebAPI/Medical.MinimalAPI.WebAPI.csproj", "Medical.MinimalAPI.WebAPI/"]
RUN dotnet restore "Medical.MinimalAPI.WebAPI/Medical.MinimalAPI.WebAPI.csproj"

# Copia el resto de los archivos y construye la aplicación
COPY . .
WORKDIR "/src/Medical.MinimalAPI.WebAPI"
RUN dotnet build "Medical.MinimalAPI.WebAPI.csproj" -c Release -o /app/build

# Etapa 2: Publicar la aplicación
FROM build AS publish
RUN dotnet publish "Medical.MinimalAPI.WebAPI.csproj" -c Release -o /app/publish

# Etapa 3: Configurar la imagen final
# Utiliza la imagen base de ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia los archivos publicados desde la etapa de publicación
COPY --from=publish /app/publish .

# Configura el entorno de ASP.NET Core para Development
ENV ASPNETCORE_ENVIRONMENT=Development

# Especifica el comando de inicio para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Medical.MinimalAPI.WebAPI.dll"]