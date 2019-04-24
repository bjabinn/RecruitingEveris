SET IDENTITY_INSERT TIPOMAESTRO ON

insert into TipoMaestro (TipoMaestroId, TipoMaestro, Activo)
values (35, 'Tipo Asistencia', 1)

SET IDENTITY_INSERT TIPOMAESTRO OFF

SET IDENTITY_INSERT MAESTRO ON

insert into Maestro (MaestroId, Maestro, TipoMaestroId, Activo, Orden)
values(1429, 'Mañana', 35, 1, 1)

insert into Maestro (MaestroId, Maestro, TipoMaestroId, Activo, Orden)
values(1430, 'Tarde', 35, 1, 2)

insert into Maestro (MaestroId, Maestro, TipoMaestroId, Activo, Orden)
values(1431, 'Ambos', 35, 1, 3)

SET IDENTITY_INSERT MAESTRO OFF

