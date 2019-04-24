INSERT INTO TipoMaestro (TipoMaestro, Activo) 
VALUES ('Tipo SubEntrevista', 1)

SET IDENTITY_INSERT Maestro ON

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo) 
VALUES (1309, 24, 'Competencial', 1)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo) 
VALUES (1310, 24, 'Técnica', 1)

INSERT INTO Maestro (MaestroId,TipoMaestroId, Maestro, Activo) 
VALUES (1311, 24, 'Gerente', 1)

SET IDENTITY_INSERT Maestro OFF