use instituto_db
go

-- CARGA DE ESTADOS DE CARRERA --

IF NOT EXISTS (SELECT * FROM Estados WHERE Descripcion = 'Activo')
BEGIN
	INSERT INTO Estados (EstadoId,Descripcion)
	VALUES (1,'Activo')
END
GO

IF NOT EXISTS (SELECT * FROM Estados WHERE Descripcion = 'Inactivo')
BEGIN
	INSERT INTO Estados (EstadoId,Descripcion)
	VALUES (2,'Inactivo')
END
GO

IF NOT EXISTS (SELECT * FROM Estados WHERE Descripcion = 'Borrador')
BEGIN
	INSERT INTO Estados (EstadoId,Descripcion)
	VALUES (3,'Borrador')
END
GO
---------------------------------

-- CARGA DE ESPACIOS --
IF NOT EXISTS (SELECT * FROM Espacios WHERE Descripcion = 'Espacio de Formaci�n General')
BEGIN
	INSERT INTO Espacios (Descripcion)
	VALUES ('Espacio de Formaci�n General')
END
GO

IF NOT EXISTS (SELECT * FROM Espacios WHERE Descripcion = 'Espacio de Formaci�n de Fundamento')
BEGIN
	INSERT INTO Espacios (Descripcion)
	VALUES ('Espacio de Formaci�n de Fundamento')
END
GO

IF NOT EXISTS (SELECT * FROM Espacios WHERE Descripcion = 'Espacio de Formaci�n Espec�fica')
BEGIN
	INSERT INTO Espacios (Descripcion)
	VALUES ('Espacio de Formaci�n Espec�fica')
END
GO

IF NOT EXISTS (SELECT * FROM Espacios WHERE Descripcion = 'Espacio de Formaci�n de Pr�cticas Profesionalizant')
BEGIN
    INSERT INTO Espacios (Descripcion) 
	VALUES ('Espacio de Formaci�n de Pr�cticas Profesionalizant')
END
GO

--------------------------

-- DECLARACION DE VARIABLES PARA EL CODIGO DE BLOQUE --

DECLARE @CarreraCodBloq INT;
SELECT @CarreraCodBloq = ISNULL(MAX(CAST(CarrerasCodigoBloque AS INT)), 0) FROM Carreras;

DECLARE @CarreraCodigoBloque INT;
SELECT @CarreraCodigoBloque = RIGHT('00' + CAST(@CarreraCodBloq + 1 AS VARCHAR(2)), 2);

DECLARE @CarreraCodBloqSuma VARCHAR(2);
SELECT @CarreraCodBloqSuma = CONCAT(0, @CarreraCodigoBloque)

DECLARE @CarreraEstadoActivo INT;
SELECT @CarreraEstadoActivo = EstadoId FROM Estados WHERE Descripcion = 'Borrador';

-------------------------------------------------------

-- CREACION DE CARRERA --

IF NOT EXISTS (
    SELECT 1
FROM Carreras
WHERE Nombre = 'Tecnicatura Superior en Guia de Turismo'
)
BEGIN
    INSERT INTO Carreras
        (
        Titulo,
        Nombre,
        DescripcionCorta,
        JefeCatedra,
        AnioInicio,
        AnioFin,
        Activo,
        PlanEstudio,
        Resolucion,
        Correlatividades,
        ImagenDescriptiva,
        NumeroExpediente,
        CantidadHoras,
        Duracion,
        CarreraEstadoId,
        CarrerasCodigoBloque
       
        )
    VALUES
        (
            'Tecnico Superior en Guia de Turismo',
            'Tecnicatura Superior en Guia de Turismo',
            'Turismo',
            '',
            2026,
            0,
            1,
            '',
            '',
            NULL,
            '',
            '',
            1792,
            3,
            1,
            1
            
    );
END

-- ID de Carrera

DECLARE @CarreraID INT;
SELECT @CarreraID = CarreraID FROM Carreras WHERE Nombre = 'Tecnicatura Superior en Guia de Turismo' 

DECLARE @CarreraCodBloqId Varchar(2);
SELECT @CarreraCodBloqId = CarrerasCodigoBloque FROM Carreras WHERE CarreraId = @CarreraID

-- 1er A�o

DECLARE @AniosCarrerasCodBloq1 VARCHAR(3);
SELECT @AniosCarrerasCodBloq1 = CONCAT(@CarreraCodBloqId, '1')

IF NOT EXISTS (SELECT * FROM AniosCarreras WHERE CarreraId = @CarreraID AND AnioCarrera = 1) BEGIN 
	INSERT INTO AniosCarreras (AnioCarrera, CantidadMaterias, CargaHorariaCompleta, CarreraId, AniosCarrerasCodigoBloque)
	VALUES (1, 0, 0, @CarreraID, @AniosCarrerasCodBloq1) END

DECLARE @AnioCarreraId1 INT;
SELECT @AnioCarreraId1 = AnioCarreraId FROM AniosCarreras WHERE CarreraId = @CarreraID AND AnioCarrera = 1

-- 2do A�o

DECLARE @AniosCarrerasCodBloq2 VARCHAR(3);
SELECT @AniosCarrerasCodBloq2 = CONCAT(@CarreraCodBloqId, '2')

IF NOT EXISTS (SELECT * FROM AniosCarreras WHERE CarreraId = @CarreraID AND AnioCarrera = 2) BEGIN 
	INSERT INTO AniosCarreras (AnioCarrera, CantidadMaterias, CargaHorariaCompleta, CarreraId, AniosCarrerasCodigoBloque)
	VALUES (2, 0, 0, @CarreraID, @AniosCarrerasCodBloq2) END

DECLARE @AnioCarreraId2 INT;
SELECT @AnioCarreraId2 = AnioCarreraId FROM AniosCarreras WHERE CarreraId = @CarreraID AND AnioCarrera = 2

-- 3er A�o

DECLARE @AniosCarrerasCodBloq3 VARCHAR(3);
SELECT @AniosCarrerasCodBloq3 = CONCAT(@CarreraCodBloqId, '3')

IF NOT EXISTS (SELECT * FROM AniosCarreras WHERE CarreraId = @CarreraID AND AnioCarrera = 3)
BEGIN 
	INSERT INTO AniosCarreras
	(AnioCarrera, CantidadMaterias, CargaHorariaCompleta, CarreraId, AniosCarrerasCodigoBloque)
	VALUES
	(3, 0, 0, @CarreraID, @AniosCarrerasCodBloq3)
END

DECLARE @AnioCarreraId3 INT;
SELECT @AnioCarreraId3 = AnioCarreraId FROM AniosCarreras WHERE CarreraId = @CarreraID AND AnioCarrera = 3
---------------------------------------------------
-- Codigo de Bloque Materias --

DECLARE @MateriasCodBloq VARCHAR(5);
SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;

DECLARE @MateriasCodigoBloque INT;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1

DECLARE @MateriasCodBloqSuma VARCHAR(5);
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

-----------------------------------
-- Materias 1er Año --

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Inglés 1' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Inglés 1', @AnioCarreraId1, 1, 1, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Introducción al turismo' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Introducción al turismo', @AnioCarreraId1, 1, 2, 96, 3, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Metodología de la investigación y técnicas de relevamiento' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Metodología de la investigación y técnicas de relevamiento', @AnioCarreraId1, 1, 2, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Psicología de los sujetos en contexto' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Psicología de los sujetos en contexto', @AnioCarreraId1, 1, 2, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación del espacio turístico ambiental de la Argentina' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación del espacio turístico ambiental de la Argentina', @AnioCarreraId1, 1, 3, 96, 3, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación del patrimonio turístico de la Argentina' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación del patrimonio turístico de la Argentina', @AnioCarreraId1, 1, 3, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación de las transformaciones sociales de la Argentina' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación de las transformaciones sociales de la Argentina', @AnioCarreraId1, 1, 3, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq1, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Prácticas Profesionales I' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Prácticas Profesionales I', @AnioCarreraId1, 1, 4, 96, 3, NULL, @CarreraID, @MateriasCodBloqSuma) END


-------------------------------------------------------------------------------------------------------
-- 2do Anio --

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Inglés 2' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Inglés 2', @AnioCarreraId2, 1, 1, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Idioma adicional de definición institucional I' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Idioma adicional de definición institucional I', @AnioCarreraId2, 1, 1, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Tecnologías de la información y comunicación aplicadas' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Tecnologías de la información y comunicación aplicadas', @AnioCarreraId2, 1, 2, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Recreación y animación socio-cultural' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Recreación y animación socio-cultural', @AnioCarreraId2, 1, 2, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación del espacio turístico local' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación del espacio turístico local', @AnioCarreraId2, 1, 3, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Gestión de circuitos turísticos' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Gestión de circuitos turísticos', @AnioCarreraId2, 1, 3, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación de las manifestaciones artísticas y culturales' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación de las manifestaciones artísticas y culturales', @AnioCarreraId2, 1, 3, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq2, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Prácticas Profesionales II' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Prácticas Profesionales II', @AnioCarreraId2, 1, 4, 224, 7, NULL, @CarreraID, @MateriasCodBloqSuma) END


-------------------------------------------------------------------------------------------------------------
-- 3er Anio ----

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq3, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Inglés 3' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Inglés 3', @AnioCarreraId3, 1, 1, 96, 3, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq3, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Idioma adicional de definición institucional II' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Idioma adicional de definición institucional II', @AnioCarreraId3, 1, 1, 64, 2, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq3, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Legislación turística' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Legislación turística', @AnioCarreraId3, 1, 2, 32, 1, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq3, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación del espacio turístico ambiental internacional' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación del espacio turístico ambiental internacional', @AnioCarreraId3, 1, 3, 96, 3, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq3, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Interpretación del patrimonio turístico internacional' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Interpretación del patrimonio turístico internacional', @AnioCarreraId3, 1, 3, 96, 3, NULL, @CarreraID, @MateriasCodBloqSuma) END

SELECT @MateriasCodBloq = ISNULL(MAX(CAST(MateriasCodigoBloque AS INT)), CONCAT(@AniosCarrerasCodBloq3, '00')) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3;
SELECT @MateriasCodigoBloque = CAST(@MateriasCodBloq AS INT) + 1
SELECT @MateriasCodBloqSuma = CONCAT(0, @MateriasCodigoBloque)

IF NOT EXISTS (SELECT * FROM Materias WHERE Nombre = 'Prácticas Profesionales III' AND CarreraId = @CarreraID) BEGIN
INSERT INTO Materias (Nombre, AnioCarreraId, Activo, EspacioId, CargaHoraria, Modulos, Multiple, CarreraId, MateriasCodigoBloque)
VALUES ('Prácticas Profesionales III', @AnioCarreraId3, 1, 4, 288, 9, NULL, @CarreraID, @MateriasCodBloqSuma) END

--------------------------------------------------------------------------------------------------------------------------------
-- Correlatividades --

DECLARE @MateriaId INT;
DECLARE @MateriaCorrelativaId INT;

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Inglés 2' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Inglés 1' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Gestión de circuitos turísticos' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Metodología de la investigación y técnicas de relevamiento' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Prácticas Profesionales II' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Prácticas Profesionales I' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Inglés 3' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Inglés 2' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Idioma adicional de definición institucional II' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Idioma adicional de definición institucional I' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Recreación y animación socio-cultural' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Psicología de los sujetos en contexto' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Interpretación del espacio turístico ambiental internacional' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Interpretación del espacio turístico ambiental de la Argentina' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Interpretación del patrimonio turístico internacional' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Interpretación del espacio turístico local' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

SELECT @MateriaId = MateriaId FROM Materias WHERE Nombre = 'Prácticas Profesionales III' AND CarreraId = @CarreraID;
SELECT @MateriaCorrelativaId = MateriaId FROM Materias WHERE Nombre = 'Prácticas Profesionales II' AND CarreraId = @CarreraID;

IF @MateriaId IS NOT NULL AND @MateriaCorrelativaId IS NOT NULL AND NOT EXISTS (SELECT * FROM Correlativas WHERE MateriaId = @MateriaId AND MateriaCorrelativaId = @MateriaCorrelativaId) BEGIN
INSERT INTO Correlativas (MateriaId, MateriaCorrelativaId)
VALUES (@MateriaId, @MateriaCorrelativaId) END

DECLARE @CantMaterias1 INT;
SELECT @CantMaterias1 = COUNT(*) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1

DECLARE @CantMaterias2 INT;
SELECT @CantMaterias2 = COUNT(*) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2

DECLARE @CantMaterias3 INT;
SELECT @CantMaterias3 = COUNT(*) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3

DECLARE @CargaHoraria1 INT;
SELECT @CargaHoraria1 = SUM(CargaHoraria) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId1

DECLARE @CargaHoraria2 INT;
SELECT @CargaHoraria2 = SUM(CargaHoraria) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId2

DECLARE @CargaHoraria3 INT;
SELECT @CargaHoraria3 = SUM(CargaHoraria) FROM Materias WHERE CarreraId = @CarreraID AND AnioCarreraId = @AnioCarreraId3

DECLARE @CorrelatividadesCarrera INT;
SELECT @CorrelatividadesCarrera = COUNT(*) FROM Correlativas C INNER JOIN Materias M on C.MateriaId = M.MateriaId WHERE M.CarreraId = @CarreraID

UPDATE Carreras SET Correlatividades = @CorrelatividadesCarrera WHERE CarreraId = @CarreraID

UPDATE AniosCarreras SET CantidadMaterias = @CantMaterias1 WHERE AnioCarreraId = @AnioCarreraId1 
UPDATE AniosCarreras SET CantidadMaterias = @CantMaterias2 WHERE AnioCarreraId = @AnioCarreraId2
UPDATE AniosCarreras SET CantidadMaterias = @CantMaterias3 WHERE AnioCarreraId = @AnioCarreraId3

UPDATE AniosCarreras SET CargaHorariaCompleta = @CargaHoraria1 WHERE AnioCarreraId = @AnioCarreraId1
UPDATE AniosCarreras SET CargaHorariaCompleta = @CargaHoraria2 WHERE AnioCarreraId = @AnioCarreraId2
UPDATE AniosCarreras SET CargaHorariaCompleta = @CargaHoraria3 WHERE AnioCarreraId = @AnioCarreraId3
