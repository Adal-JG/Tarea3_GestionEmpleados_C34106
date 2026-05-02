IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GestionEmpleadosDB')
BEGIN
    CREATE DATABASE GestionEmpleadosDB;
END
GO

USE GestionEmpleadosDB;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleados' AND xtype='U')
BEGIN
    CREATE TABLE Empleados (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(80) NOT NULL,
        Apellidos NVARCHAR(100) NOT NULL,
        Departamento NVARCHAR(100) NOT NULL,
        Salario DECIMAL(18,2) NOT NULL,
        FechaIngreso DATETIME2 NOT NULL DEFAULT GETDATE(),
        Activo BIT NOT NULL DEFAULT 1
    );
END
GO