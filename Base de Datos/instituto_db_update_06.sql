
IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'Estados'
      AND COLUMN_NAME = 'Color'
)
BEGIN
    ALTER TABLE Estados ADD Color VARCHAR(30);
END;
GO

DECLARE @ActivoId INT;
SELECT @ActivoId = EstadoId FROM Estados WHERE Descripcion = 'Activo';

DECLARE @InactivoId INT;
SELECT @InactivoId = EstadoId FROM Estados WHERE Descripcion = 'Inactivo';

DECLARE @BorradorId INT;
SELECT @BorradorId = EstadoId FROM Estados WHERE Descripcion = 'Borrador';

UPDATE Estados SET Color = 'Verde'    WHERE EstadoId = @ActivoId;
UPDATE Estados SET Color = 'Amarillo' WHERE EstadoId = @InactivoId;
UPDATE Estados SET Color = 'Rojo'     WHERE EstadoId = @BorradorId;