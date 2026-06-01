--****************
-- ACTUALIZACIÓN DE FERNANDEZ FRANCO DANIEL
--01/06/2026
--EQUIPO 5
--****************
USE instituto_db;

GO

ALTER TABLE Materias
 ADD FinalPromocion CHAR(1) DEFAULT 'F' NOT NULL
  CONSTRAINT CK_Materias_FinalPromocion CHECK (FinalPromocion IN('F','P'));