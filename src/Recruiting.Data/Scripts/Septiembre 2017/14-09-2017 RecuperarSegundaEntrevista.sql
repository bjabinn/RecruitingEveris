update TipoEtapaCandidatura
set Activo = 1
where TipoEtapaCandidaturaId in (3, 6, 14)

update RelacionEtapa
set EtapaFinId = 14, EstadoFinId = 2, Descripcion = 'Completar1->Pendiente2aEntrevista->2aEntrevista'
where RelacionEtapaId = 30