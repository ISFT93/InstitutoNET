USE [instituto_db2];
GO

/* ============================================================================
   Creación de la tabla si no existe
   ============================================================================ */
IF NOT EXISTS (
    SELECT * 
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Espacios'
)
BEGIN
    CREATE TABLE dbo.Espacios (
        EspacioId INT IDENTITY(1,1) PRIMARY KEY,
        Descripcion VARCHAR(100) NOT NULL,
        Acumulador VARCHAR(100) NULL,
        SumaHoras BIT NOT NULL CONSTRAINT DF_Espacios_SumaHoras DEFAULT 1,
        CalculaPorcentaje BIT NOT NULL CONSTRAINT DF_Espacios_CalculaPorcentaje DEFAULT 1,
        Activo BIT NOT NULL CONSTRAINT DF_Espacios_Activo DEFAULT 1
    );
    PRINT 'Tabla dbo.Espacios creada exitosamente.';
END
GO

/* ============================================================================
   Agregar columnas faltantes en caso de que la tabla ya existía
   ============================================================================ */

-- Columna: Acumulador
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Espacios' AND COLUMN_NAME = 'Acumulador'
)
BEGIN
    ALTER TABLE dbo.Espacios ADD Acumulador VARCHAR(100) NULL;
    PRINT 'Columna Acumulador agregada.';
END
GO

-- Columna: SumaHoras
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Espacios' AND COLUMN_NAME = 'SumaHoras'
)
BEGIN
    ALTER TABLE dbo.Espacios ADD SumaHoras BIT NOT NULL CONSTRAINT DF_Espacios_SumaHoras DEFAULT 1;
    PRINT 'Columna SumaHoras agregada.';
END
GO

-- Columna: CalculaPorcentaje
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Espacios' AND COLUMN_NAME = 'CalculaPorcentaje'
)
BEGIN
    ALTER TABLE dbo.Espacios ADD CalculaPorcentaje BIT NOT NULL CONSTRAINT DF_Espacios_CalculaPorcentaje DEFAULT 1;
    PRINT 'Columna CalculaPorcentaje agregada.';
END
GO

-- Columna: Activo
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Espacios' AND COLUMN_NAME = 'Activo'
)
BEGIN
    ALTER TABLE dbo.Espacios ADD Activo BIT NOT NULL CONSTRAINT DF_Espacios_Activo DEFAULT 1;
    PRINT 'Columna Activo agregada.';
END
GO

/* ============================================================================
   Carga/Actualización de datos iniciales en la tabla
   ============================================================================ */
BEGIN TRANSACTION;
BEGIN TRY

    -- Caso A: Si la tabla está vacía, se insertan los registros por primera vez
    IF NOT EXISTS (SELECT 1 FROM dbo.Espacios)
    BEGIN
        INSERT INTO dbo.Espacios (Descripcion, Acumulador, SumaHoras, CalculaPorcentaje, Activo)
        VALUES 
            ('Esp. de Form. General', 'Formación General', 1, 1, 1),
            ('Esp. de Form. Fundamentos', 'Formación Fundamentos', 1, 1, 1),
            ('Esp. de Form. Específica', 'Formación Específica', 1, 1, 1),
            ('Esp. de Form. Prácticas Profesionalizante', 'Prácticas Profesionalizantes', 1, 1, 1);
            
        PRINT 'Datos iniciales insertados correctamente.';
    END
    -- Caso B: Si la tabla ya tenía registros, se actualizan las descripciones y acumuladores
    ELSE
    BEGIN
        UPDATE dbo.Espacios 
        SET Descripcion = 'Esp. de Form. General',
            Acumulador = 'Formación General'
        WHERE Descripcion LIKE '%General%' OR EspacioId = 1;

        UPDATE dbo.Espacios 
        SET Descripcion = 'Esp. de Form. Fundamentos',
            Acumulador = 'Formación Fundamentos'
        WHERE Descripcion LIKE '%Fundamento%' OR EspacioId = 2;

        UPDATE dbo.Espacios 
        SET Descripcion = 'Esp. de Form. Específica',
            Acumulador = 'Formación Específica'
        WHERE Descripcion LIKE '%Específica%' OR EspacioId = 3;

        UPDATE dbo.Espacios 
        SET Descripcion = 'Esp. de Form. Prácticas Profesionalizante',
            Acumulador = 'Prácticas Profesionalizantes'
        WHERE Descripcion LIKE '%Prácticas%' OR EspacioId = 4;

        PRINT 'Registros existentes actualizados correctamente.';
    END

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Error al procesar los datos: ' + ERROR_MESSAGE();
END CATCH;
GO

/* ============================================================================
   Verificación final
   ============================================================================ */
SELECT EspacioId, Descripcion, Acumulador, SumaHoras, CalculaPorcentaje, Activo 
FROM dbo.Espacios;
GO