
-- Creación de la base de datos "pruebaTecnica"
CREATE DATABASE AgendaPruebaTecnicaReact;
GO


-- Uso de la base de datos "pruebaTecnica"
USE AgendaPruebaTecnicaReact;
GO

-- Creación del esquema "Auditoria"
CREATE SCHEMA Auditoria;
GO

-- Creación de la tabla "Usuario" dentro del esquema "Auditoria"
CREATE TABLE Auditoria.Usuario (
    ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50),
    Contraseña VARCHAR(100), 
	ID_Persona INT NOT NULL,
	FOREIGN KEY (ID_Persona) REFERENCES Negocio.Persona(ID_Persona)
);
GO

-- Creación del esquema "Negocio"
CREATE SCHEMA Negocio;
GO

-- Creación de la tabla "Persona" dentro del esquema "Negocio"
CREATE TABLE Negocio.Persona (
    ID_Persona INT PRIMARY KEY IDENTITY(1,1),
	Cedula VARCHAR(50),
    Nombres VARCHAR(50),
    Apellidos VARCHAR(50),
    Edad INT,
    Email VARCHAR(50),
    Telefono VARCHAR(10)

);
GO

-- Creación de la tabla "Agenda" dentro del esquema "Negocio"
CREATE TABLE Negocio.Agenda (
    ID_Agenda INT PRIMARY KEY IDENTITY(1,1),
    ID_Usuario INT NOT NULL,
    ID_Persona INT NOT NULL,
    FOREIGN KEY (ID_Usuario) REFERENCES Auditoria.Usuario(ID_Usuario),
    FOREIGN KEY (ID_Persona) REFERENCES Negocio.Persona(ID_Persona)
);
GO

select * from Negocio.Agenda ;
select * from Negocio.Persona;
select * from Auditoria.Usuario;


