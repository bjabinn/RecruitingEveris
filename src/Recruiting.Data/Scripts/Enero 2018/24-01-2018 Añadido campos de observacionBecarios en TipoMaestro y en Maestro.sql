SET IDENTITY_INSERT TipoMaestro ON 

INSERT INTO TipoMaestro (TipoMaestroId, TipoMaestro, Activo) 
VALUES (33, 'Tipo Prueba', 1)

INSERT INTO TipoMaestro (TipoMaestroId, TipoMaestro, Activo) 
VALUES (34, 'Tipo Resultado', 1)

SET IDENTITY_INSERT TipoMaestro OFF


SET IDENTITY_INSERT Maestro ON 

INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1423, 33, 'Llamada telefónica', 1, 1)
INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1424, 33, 'Prueba Tecnica', 1, 2)
INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1425, 33, 'Entrevista', 1, 3)

INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1426, 34, 'Si', 1, 1)
INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1427, 34, 'No', 1, 2)
INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1428, 34, 'Duda', 1, 3)

SET IDENTITY_INSERT Maestro OFF