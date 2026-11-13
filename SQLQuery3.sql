SELECT TOP (20) [AlumnoCarreraId]
      ,[CarreraId]
      ,[AlumnoId]
      ,[FechaAlta]
      ,[FechaBaja]
      ,[Activo]
      ,[CicloLectivoId]
      ,[inicializado]
      ,[LibroActaId]
      ,[NroFolio]
  FROM [instituto_db8].[dbo].[AlumnosCarreras]

  SELECT * FROM LibroActas WHERE CarreraID = 1 AND Activo = 1;

  SELECT DISTINCT a.Nombre, a.Apellido, c.DescripcionCorta AS Carrera, ac.Activo AS AlumnoActivo
FROM Alumnos a
INNER JOIN AlumnosCarreras ac ON a.AlumnoId = ac.AlumnoId
INNER JOIN Carreras c ON ac.CarreraId = c.CarreraId
INNER JOIN LibroActas la ON ac.CarreraId = la.CarreraID
INNER JOIN TipoLibros tl ON la.TipoLibroId = tl.TipoLibroId
WHERE ac.Activo = 1 
  AND la.Activo = 1 
  AND tl.Descripcion = 'Libro de Matriz';

  SELECT CarreraID, DescripcionCorta FROM Carreras WHERE DescripcionCorta LIKE '%Marketing%' OR DescripcionCorta LIKE '%Marketing%';








  SELECT * FROM TipoLibros;