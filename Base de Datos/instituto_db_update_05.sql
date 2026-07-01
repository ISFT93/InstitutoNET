USE INSTITUTO_DB
GO

ALTER TABLE Cargos ADD CargaHoraria INT
GO

CREATE PROCEDURE InsertarCargo
    @Descripcion VARCHAR(50),
    @CargaHoraria INT,
    @TipoAsignacionId INT,
    @TipoAplicacionId INT
AS
BEGIN
    INSERT INTO Cargos
    (Descripcion, CargaHoraria, TipoAsignacionId, TipoAplicacionId, Activo)
    VALUES
    (@Descripcion, @CargaHoraria, @TipoAsignacionId, @TipoAplicacionId, 1)
END
GO

DELETE FROM TipoAplicacion
GO

INSERT INTO TipoAplicacion (Descripcion, Detalle) 
VALUES 
('= 1', 'El personal toma el cargo y no puede ser tomado x otro ni tomar otro cargo'),
('> 1', 'Puede asignarse, ser asignado por otros y a la vez asignarse a otros cargos'),
('>= 1', 'Una vez asignado, el personal no puede signarse otro cargo pero se puede asignar el cargo a otro personal.')
GO
