select * from tipoaplicacion

delete from TipoAplicacion

INSERT INTO TipoAplicacion (Descripcion, Detalle) 
VALUES 
('= 1', 'El personal toma el cargo y no puede ser tomado x otro ni tomar otro cargo'),
('> 1', 'Puede asignarse, ser asignado por otros y a la vez asignarse a otros cargos'),
('>= 1', 'Una vez asignado, el personal no puede signarse otro cargo pero se puede asignar el cargo a otro personal.')

select * from cargos

select c.cargoid, c.Descripcion, c.Activo, ta.Descripcion from Cargos c inner join TipoAplicacion ta on ta.TipoAplicacionId = c.TipoAplicacionId

update TipoAplicacion set Descripcion = '>= 1' Where TipoAplicacionId = 2 

update cargos set TipoAplicacionId = 3 where cargoid = 4025