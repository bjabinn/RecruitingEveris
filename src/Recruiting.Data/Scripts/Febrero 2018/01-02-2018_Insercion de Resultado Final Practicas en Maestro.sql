SET IDENTITY_INSERT TIPOMAESTRO ON

insert into TipoMaestro (TipoMaestroId, TipoMaestro, Activo)
values (36, 'Tipo Decision Practicas', 1)

SET IDENTITY_INSERT TIPOMAESTRO OFF

SET IDENTITY_INSERT MAESTRO ON

insert into Maestro(MaestroId, TipoMaestroId, Maestro, Activo, Orden)
values (1432, 36, 'Backlog', 1, 1)

insert into Maestro(MaestroId, TipoMaestroId, Maestro, Activo, Orden)
values (1433, 36, 'Contratable', 1, 2)

insert into Maestro(MaestroId, TipoMaestroId, Maestro, Activo, Orden)
values (1434, 36, 'No Contratable', 1, 3)

SET IDENTITY_INSERT MAESTRO OFF