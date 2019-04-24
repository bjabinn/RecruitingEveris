
SET IDENTITY_INSERT TipoMaestro ON

INSERT INTO TipoMaestro (TipoMaestroId, TipoMaestro, Activo) 
VALUES (30 ,'Origen CV', 1)

INSERT INTO TipoMaestro (TipoMaestroId, TipoMaestro, Activo) 
VALUES (31, 'Fuente Reclutamiento', 2)

SET IDENTITY_INSERT TipoMaestro OFF

SET IDENTITY_INSERT Maestro ON

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1400, 30, 'Búsqueda Activa',1, 1)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1401, 30, 'Inscripción', 1,2)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1402, 30, 'Referenciados',1, 3)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1403, 31, 'Linkedin',1, 1)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1404, 31, 'Infojobs',1, 2)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1405, 31, 'Tecnoempleo',1, 3)


SET IDENTITY_INSERT Maestro OFF