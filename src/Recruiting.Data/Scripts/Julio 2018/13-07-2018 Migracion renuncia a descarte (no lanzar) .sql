update Maestro
set TipoMaestroId = 9
where MaestroId = 1315

update Maestro
set TipoMaestroId = 9
where MaestroId = 1198

update Maestro
set TipoMaestroId = 9
where MaestroId = 1194

update Candidatura
set EstadoCandidaturaId = 7
where MotivoRenunciaDescarteId in(1315, 1198, 1194)

