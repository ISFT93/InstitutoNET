USE [instituto_db2];
GO

BEGIN TRANSACTION;

BEGIN TRY
    -- Actualizamos los textos existentes según su EspacioId.
    
    -- Espacio de Formación General
    UPDATE dbo.Espacios 
    SET Descripcion = 'Esp. de Form. General'
    WHERE Descripcion LIKE '%General%' OR EspacioId = 1;

    -- Espacio de Formación Fundamentos
    UPDATE dbo.Espacios 
    SET Descripcion = 'Esp. de Form. Fundamentos'
    WHERE Descripcion LIKE '%Fundamento%' OR EspacioId = 2;

    -- Espacio de Formación Específica
    UPDATE dbo.Espacios 
    SET Descripcion = 'Esp. de Form. Específica'
    WHERE Descripcion LIKE '%Específica%' OR EspacioId = 3;

    -- Espacio de Formación Prácticas Profesionalizantes
    UPDATE dbo.Espacios 
    SET Descripcion = 'Esp. de Form. Prácticas Profesionalizante'
    WHERE Descripcion LIKE '%Prácticas%' OR EspacioId = 4;

    COMMIT TRANSACTION;
    PRINT 'Actualización realizada correctamente. Todos los registros fueron modificados.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Ocurrió un error al actualizar los datos: ' + ERROR_MESSAGE();
END CATCH;
GO


-- Visualizar como quedo la tabla. 
SELECT EspacioId, Descripcion FROM dbo.Espacios;