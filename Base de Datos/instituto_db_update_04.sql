--si la base es la nueva, ya existen esta columnas
USE INSTITUTO_DB
GO

ALTER TABLE dbo.CicloLectivo
ADD FechaInscripcionSuperioresInicio DATE NULL
GO

ALTER TABLE dbo.CicloLectivo
ADD FechaInscripcionSuperioresFinal DATE NULL
GO