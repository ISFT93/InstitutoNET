USE instituto_db
GO

ALTER TABLE LibroActas ADD CarreraID INT
ALTER TABLE LibroActas ADD CONSTRAINT LimitarFolios CHECK (FolioNumero <= FolioMaximo)
ALTER TABLE LibroActas ADD CONSTRAINT FK_LibroActas_Carrera FOREIGN KEY (CarreraID) REFERENCES Carreras(CarreraID)
GO

CREATE PROCEDURE AgregarNumeroLibro
    @TipoLibroID INT,
    @LibroNumero INT,
	@CarreraID INT,
	@FolioMaximo INT,
	@FechaAlta DATE
AS
BEGIN
    INSERT INTO LibroActas 
	(TipoLibroId, LibroNumero, CarreraID, FolioNumero, FolioMaximo, FechaAlta, Activo) 
	VALUES 
	(@TipoLibroID, @LibroNumero, @CarreraID, 0, @FolioMaximo, @FechaAlta, 1)
END