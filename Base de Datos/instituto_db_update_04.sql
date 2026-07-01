USE instituto_db
GO

ALTER TABLE dbo.CicloLectivo
ADD FechaInscripcionSuperioresInicio DATE NULL
GO

ALTER TABLE dbo.CicloLectivo
ADD FechaInscripcionSuperioresFinal DATE NULL
GO