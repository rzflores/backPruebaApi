********Consideraciones *******
1.-Crear base de datos APIDB

CREATE DATABASE APIDB;
go

2.- Crear usuario de bd en sql server

CREATE LOGIN usuariotest 
WITH PASSWORD = 'Abc1234$';

CREATE USER usuariotest 
FOR LOGIN usuariotest;

ALTER ROLE db_datareader ADD MEMBER usuariotest;
ALTER ROLE db_datawriter ADD MEMBER usuariotest;

2.-Creat tabla de Personas

CREATE TABLE Personas (
    id uniqueidentifier PRIMARY KEY,
    tipo_documento VARCHAR(20),
    numero_documento VARCHAR(20),
    nombres VARCHAR(50),
    apellido_paterno VARCHAR(50),
    apellido_materno VARCHAR(50),
    numero_telefono VARCHAR(20),
    correo_electronico VARCHAR(100),
    direccion VARCHAR(255),
    eliminado INT DEFAULT 0
);


3.-Generar Token

 * http://localhost:5039/api/v1/auth/generar
 body => {
    "correo" : "test@gmail.com",
    "clave" : "123"
}

4.- Usar Apí CRUD

******Opcional  1****
Ejecutar contenedor con el proyecto ApiPrueba conectandose a la bd local 
1.-Posicionar en la carpeta del proyecto y donde se encuentral DockerFile
2.-Construir imagen de docker
docker build -t net-apiprueba-tenica .
3.-Ejecutar contenedor
docker run -p 3056:80 --name cnt-api-prueba net-apiprueba-tenica
4.-Ingresar swagger o postman
http://localhost:3056/swagger/index.html



