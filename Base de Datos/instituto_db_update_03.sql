--****************
-- ACTUALIZACIÓN DE FERNANDEZ FRANCO DANIEL
--19/06/2026
--EQUIPO 5
--****************   v  
USE INSTITUTO_DB;

GO

ALTER TABLE Carreras
 ADD CantidadCorrelativas INT DEFAULT 0 NOT NULL;
