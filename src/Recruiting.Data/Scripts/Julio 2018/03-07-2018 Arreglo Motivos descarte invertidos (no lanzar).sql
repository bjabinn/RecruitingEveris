update Maestro
set TipoMaestroId = 9
where MaestroId = 1191

update Maestro
set TipoMaestroId = 22
where MaestroId = 97

update Entrevista
set MotivoId = 1191
where MotivoId = 97

update Candidatura
set MotivoRenunciaDescarteId = 1
where MotivoRenunciaDescarteId = 97

update Candidatura
set MotivoRenunciaDescarteId = 97
where MotivoRenunciaDescarteId = 1191

update Candidatura
set MotivoRenunciaDescarteId = 1191
where MotivoRenunciaDescarteId = 1

update Candidatura
set MotivoRenunciaDescarteId = 1191,
EstadoCandidaturaId = 7
where MotivoRenunciaDescarteId = 97
and EstadoCandidaturaId = 10
and EtapaCandidaturaId = 13