SET IDENTITY_INSERT TipoMaestro ON 

INSERT INTO TipoMaestro (TipoMaestroId, TipoMaestro,Activo) 
VALUES (32, 'Tipo Becario', 1)

SET IDENTITY_INSERT TipoMaestro OFF


SET IDENTITY_INSERT Maestro ON 

INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1417, 32, 'CFGS', 1, null)

INSERT INTO Maestro (MaestroId, TipoMaestroId, Maestro, Activo, Orden) 
VALUES (1418, 32, 'Universidad', 1, null)

SET IDENTITY_INSERT Maestro OFF