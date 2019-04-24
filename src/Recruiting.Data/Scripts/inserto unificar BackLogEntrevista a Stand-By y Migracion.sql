  SET IDENTITY_INSERT TipoDecision ON --Ejecutar solo si previamente se ha hecho la actualizacion de nombres

  Insert into TipoDecision (TipoDecisionId, Decision, TipoEtapaCandidaturaId, activo)
  values (34, 'Pausar en agendar segunda entrevista', 11, 1)

    Insert into TipoDecision (TipoDecisionId, Decision, TipoEtapaCandidaturaId, activo)
  values (35, 'Reanudar en agendar segunda entrevista', 3, 1)

  SET IDENTITY_INSERT TipoDecision OFF

    SET IDENTITY_INSERT RelacionEtapa ON

  Insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, descripcion)
  values (1069, 3, 3, 34, 3, 1, 2, 'Pausa:Agendar2->Agendar2->BacklogEntrevista(RenombradoAStandBy)')

    Insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, descripcion)
  values (1070, 3, 3, 35, 2, 1, 3, 'Pausa:Agendar2->Agendar2->BacklogEntrevista(RenombradoAStandBy)')

    SET IDENTITY_INSERT RelacionEtapa OFF

  Update Candidatura
  Set EstadoCandidaturaId = 3
  Where EstadoCandidaturaId = 12