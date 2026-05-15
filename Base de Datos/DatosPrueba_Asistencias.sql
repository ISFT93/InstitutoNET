-- Script de datos de prueba para Control de Asistencias
-- Ejecutar en la base instituto_db

USE [instituto_db]
GO

-- =============================================================================
-- 1. Asignar alumnos existentes a cursadas existentes
-- =============================================================================
-- Alumnos de la carrera 1003 (Sistemas) que vamos a vincular con las cursadas:
--   AlumnoCarreraId 2003 (Alumno 4005 - Lara Laura)
--   AlumnoCarreraId 2004 (Alumno 4006 - Rodriguez Jorge)
--   AlumnoCarreraId 2009 (Alumno 4007 - Lopez Maria)
--   AlumnoCarreraId 2010 (Alumno 4008 - Perez Juan)
--   AlumnoCarreraId 2011 (Alumno 4009 - Santillan Diego)
--
-- Cursadas existentes para 2024:
--   438322 -> CursoMateriaId 1  -> Curso 1004 -> Materia 1 (Álgebra)
--   438323 -> CursoMateriaId 2  -> Curso 1004 -> Materia 2 (Análisis Matemático)
--   438324 -> CursoMateriaId 3  -> Curso 1004 -> Materia 3 (Inglés Técnico)
--   438325 -> CursoMateriaId 4  -> Curso 1004 -> Materia 4 (Administración)
--   438326 -> CursoMateriaId 5  -> Curso 1004 -> Materia 5 (Metodología)
--   438327 -> CursoMateriaId 6  -> Curso 1004 -> Materia 6 (Programación I)
--   438328 -> CursoMateriaId 7  -> Curso 1004 -> Materia 7 (Sistemas de Computación)
--   438329 -> CursoMateriaId 8  -> Curso 1004 -> Materia 8 (EDI)
--   438330 -> CursoMateriaId 9  -> Curso 2004 -> Materia 9 (Probabilidad y Estadística)
--   438331 -> CursoMateriaId 10 -> Curso 2004 -> Materia 10 (Análisis Matemático II)

INSERT INTO [dbo].[CursadaAlumnoCarreras] 
    ([AlumnoCarreraId], [CursadaId], [AnioCicloLectivo], [Estado], [HorasCursadas], [UltimoPresentismo], [PorcentajeAsistencia], [Cursada], [Activo])
VALUES
    -- Cursada 438322 (Álgebra - Curso 1004 A - 1er año Sistemas)
    (2003, 438322, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2004, 438322, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2009, 438322, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2010, 438322, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2011, 438322, 2024, 'AC', 0, NULL, 0, 'Regular', 1),

    -- Cursada 438323 (Análisis Matemático - Curso 1004 A)
    (2003, 438323, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2004, 438323, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2009, 438323, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2010, 438323, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2011, 438323, 2024, 'AC', 0, NULL, 0, 'Regular', 1),

    -- Cursada 438327 (Programación I - Curso 1004 A)
    (2003, 438327, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2004, 438327, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2009, 438327, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2010, 438327, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2011, 438327, 2024, 'AC', 0, NULL, 0, 'Regular', 1),

    -- Cursada 438330 (Probabilidad y Estadística - Curso 2004 A - 2do año Sistemas)
    (2003, 438330, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2004, 438330, 2024, 'AC', 0, NULL, 0, 'Regular', 1),
    (2009, 438330, 2024, 'AC', 0, NULL, 0, 'Regular', 1);
GO

-- =============================================================================
-- 2. Insertar asistencias previas (opcional - para que aparezcan datos 
--    al cargar una fecha específica en la grilla)
-- =============================================================================
-- Primero obtenemos los CursadaAlumnoCarreraId generados en el paso anterior.
-- Como son IDENTITY, consultamos primero para saber qué IDs se generaron.
-- En su lugar, usamos los IDs que sabemos que serán consecutivos si la tabla
-- estaba vacía.  Si preferís, podés ejecutar esta parte después de ver los IDs.

-- Descomentar y ajustar los CursadaAlumnoCarreraId según los IDs generados:
/*
INSERT INTO [dbo].[Asistencias] ([Fecha], [Asistencia], [CursadaAlumnoCarreraId])
VALUES
    ('2025-05-05', 'P', <ID_generado_1>),
    ('2025-05-05', 'P', <ID_generado_2>),
    ('2025-05-05', 'A', <ID_generado_3>),
    ('2025-05-05', 'P', <ID_generado_4>),
    ('2025-05-05', 'P', <ID_generado_5>);
*/
GO

-- =============================================================================
-- 3. Verificación rápida
-- =============================================================================
SELECT 
    c.CursadaId,
    m.Nombre AS Materia,
    cu.NombreCurso AS Curso,
    ac.AlumnoCarreraId,
    a.Apellido + ', ' + a.Nombre AS Alumno,
    cac.CursadaAlumnoCarreraId
FROM CursadaAlumnoCarreras cac
INNER JOIN Cursadas c ON c.CursadaId = cac.CursadaId
INNER JOIN CursoMaterias cm ON c.CursoMateriaId = cm.CursoMateriaId
INNER JOIN Materias m ON cm.MateriaId = m.MateriaId
INNER JOIN Cursos cu ON cm.CursoId = cu.CursoId
INNER JOIN AlumnosCarreras ac ON cac.AlumnoCarreraId = ac.AlumnoCarreraId
INNER JOIN Alumnos a ON ac.AlumnoId = a.AlumnoId
ORDER BY c.CursadaId, a.Apellido;
GO
