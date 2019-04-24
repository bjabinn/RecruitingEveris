  SET IDENTITY_INSERT TipoDecision ON --Ejecutar solo si previamente se ha hecho la actualizacion de nombres

  Insert into TipoDecision (TipoDecisionId, Decision, TipoEtapaCandidaturaId, activo)
  values (32, 'Pausar en agendar primera entrevista', 11, 1)

    Insert into TipoDecision (TipoDecisionId, Decision, TipoEtapaCandidaturaId, activo)
  values (33, 'Reanudar en agendar primera entrevista', 2, 1)

  SET IDENTITY_INSERT TipoDecision OFF

  SET IDENTITY_INSERT RelacionEtapa ON

  Insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, descripcion)
  values (1067, 2, 2, 32, 3, 1, 8, 'Pausa:Agendar1->Agendar1->Backlog(RenombradoAStandBy)')

    Insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, descripcion)
  values (1068, 2, 2, 33, 8, 1, 3, 'Pausa:Agendar1->Agendar1->Backlog(RenombradoAStandBy)')

    SET IDENTITY_INSERT RelacionEtapa OFF

  update TipoEstadoCandidatura
  set EstadoCandidatura = 'AntiguoCVenBBDD'
  where TipoEstadoCandidaturaId = 6

  update TipoEstadoCandidatura
  set EstadoCandidatura = 'Stand-by'
  where TipoEstadoCandidaturaId = 3

  update RelacionEtapa
  set Descripcion = 'Completar1->PendienteCartaOferta->CartaOferta'
  where RelacionEtapaId = 30

  -- Este ultimo es para saltarnos la etapa de entregar carta oferta despues de agendar e ir directamente a completar

  update RelacionEtapa
  set EtapaFinId = 7, Descripcion = 'AgendarCO->CompletarCO(Ahora Feedback CO)'
  where RelacionEtapaId = 27

  update TipoEtapaCandidatura
  set Activo = 0
  where TipoEtapaCandidaturaId = 8

  update TipoEstadoCandidatura
  set Activo = 0
  where TipoEstadoCandidaturaId = 6 or TipoEstadoCandidaturaId = 12

  Update Candidatura
  Set EstadoCandidaturaId = 3
  Where EstadoCandidaturaId = 6
