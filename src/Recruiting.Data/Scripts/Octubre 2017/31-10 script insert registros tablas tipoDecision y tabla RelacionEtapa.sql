SET IDENTITY_INSERT TipoDecision ON

INSERT INTO TipoDecision (TipoDecisionId, Decision, TipoEtapaCandidaturaId, Activo)
VALUES(40, 'Pausar en filtrado telefonico', 13, 1)

INSERT INTO TipoDecision (TipoDecisionId, Decision, TipoEtapaCandidaturaId, Activo)
VALUES(41, 'Reanudar en filtrado telefonico', 13, 1)

SET IDENTITY_INSERT TipoDecision OFF




SET IDENTITY_INSERT RelacionEtapa ON

INSERT INTO RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId
		   ,EstadoFinId, Activo, EstadoOrigenId, Descripcion)
VALUES(1080, 13, 13, 40, 3, 1, 8,
	'Pausa:Filtrado telefónico->FiltradoTelefonico->StandBy')

INSERT INTO RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId
		   ,EstadoFinId, Activo, EstadoOrigenId, Descripcion)
VALUES(1081, 13 , 13, 41, 8, 1 ,3,
'Pausa:Filtrado telefónico->FiltradoTelefonico->StandBy')

SET IDENTITY_INSERT RelacionEtapa OFF
