--****************
-- ACTUALIZACIÓN DE FERNANDEZ FRANCO DANIEL
--19/06/2026
--EQUIPO 5
--****************
USE instituto_db;

GO

ALTER TABLE Carreras
 ADD CantidadCorrelativas INT DEFAULT 0 NOT NULL;
