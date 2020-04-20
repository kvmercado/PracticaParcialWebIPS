CREATE DATABASE [Copago];

USE [Copago]

CREATE TABLE [dbo].[Persona](
[Identificacion] [nvarchar](10) NOT NULL PRIMARY KEY,
[ValorHospitalizacion] [numeric](20, 0) NULL,
[Salario] [numeric](20, 0) NULL,
[ValorCopago] [numeric](20, 0) NULL,
)

GO

COMMIT