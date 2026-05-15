
--****************
-- ACTUALIZACION DE FERNANDEZ FRANCO DANIEL
--29/04/2026
--EQUIPO 5
--****************

USE instituto_db;

GO

/*************************COLUMNAS ADICIONALES*************************************/

--Creacion de una nueva columna para almacenar el codigo de bloque de la tabla Carreras
ALTER TABLE Carreras
 ADD CarrerasCodigoBloque VARCHAR(20);

GO
--Creacion de una nueva columna para almacenar el codigo de bloque de la tabla AniosCarreras
ALTER TABLE AniosCarreras 
 ADD AniosCarrerasCodigoBloque VARCHAR(20);

GO
--Creacion de un campo CarreraId dentro de la tabla Materias.
ALTER TABLE Materias
ADD CarreraId INT;

GO
--Creacion de una nueva columna para almacenar el codigo de bloque de la tabla Materias
ALTER TABLE Materias
ADD MateriasCodigoBloque VARCHAR(20);

GO

/****************CREACION DE CODIGO PARA TABLA Carreras****************/

;WITH Codigos AS (
    SELECT 
        CarreraId,
        FORMAT(DENSE_RANK() OVER (ORDER BY CarreraId), '00') AS CarrerasCodigoBloque
    FROM Carreras
)
UPDATE CA
SET CA.CarrerasCodigoBloque = C.CarrerasCodigoBloque
FROM Carreras CA
INNER JOIN Codigos C ON CA.CarreraId = C.CarreraId;


GO

--Indice del nuevo campo CarrerasCodigoBloque
CREATE INDEX I_Carreras_C_CodigoBloque
ON Carreras(CarrerasCodigoBloque);

GO

/****************CREACION DE CODIGO PARA TABLA AniosCarreras****************/


;WITH Codigos AS (
    SELECT 
        AnioCarreraId,
        FORMAT(DENSE_RANK() OVER (ORDER BY CarreraId), '00') + '' +
        FORMAT(ROW_NUMBER() OVER (PARTITION BY CarreraId ORDER BY AnioCarreraId), '0') AS AniosCarrerasCodigoBloque
    FROM AniosCarreras
)
UPDATE AC
SET AC.AniosCarrerasCodigoBloque = C.AniosCarrerasCodigoBloque
FROM AniosCarreras AC
INNER JOIN Codigos C ON AC.AnioCarreraId = C.AnioCarreraId;

GO

--Indice para AniosCarrerasCodigoBloque
CREATE INDEX I_AniosCarreras_AC_CodigoBloque
ON AniosCarreras(AniosCarrerasCodigoBloque);


GO

/****************CREACIÓN DE CODIGO DE BLOQUE PARA LA TABLA Materias****************/

--Actualizacion del campo CarreraId perteneciente a la tabla Materias
--con los ID pertenecientes de cada carrera.

--Sistemas
UPDATE Materias SET CarreraId = 1003 WHERE AnioCarreraId IN(2002,2003,2004);
GO
--Enfermeria
UPDATE Materias SET CarreraId = 1004 WHERE AnioCarreraId IN(2005,2006,2007);
GO
--Marketing
UPDATE Materias SET CarreraId = 2010 WHERE AnioCarreraId IN(3005,3006,3007);
GO
--Turismo
UPDATE Materias SET CarreraId = 3004 WHERE AnioCarreraId IN(4005,4006,4007);
GO
--Publica
UPDATE Materias SET CarreraId = 3005 WHERE AnioCarreraId IN(4008,4009,4010);
GO
--Contable
UPDATE Materias SET CarreraId = 3006 WHERE AnioCarreraId IN(4011,4012,4013);
GO


;WITH Codigos AS (
	SELECT
    AC.AnioCarreraId,
    M.CarreraId,
    M.MateriaId,
    FORMAT(DENSE_RANK() OVER (ORDER BY AC.CarreraId), '00') + '' +
    FORMAT(DENSE_RANK() OVER (PARTITION BY AC.CarreraId ORDER BY AC.AnioCarreraId), '0') + '' +
    FORMAT(ROW_NUMBER() OVER (PARTITION BY AC.CarreraId, AC.AnioCarreraId ORDER BY M.MateriaId), '00') AS MateriasCodigoBloque
FROM AniosCarreras AC
LEFT JOIN Materias M ON AC.AnioCarreraId = M.AnioCarreraId
)
UPDATE M
SET M.MateriasCodigoBloque = C.MateriasCodigoBloque
FROM Materias M
INNER JOIN Codigos C ON M.MateriaId = C.MateriaId;

GO

--Indice para MateriasCodigoBloque
CREATE INDEX I_Materias_MateriasCodigo
ON Materias(MateriasCodigoBloque);


