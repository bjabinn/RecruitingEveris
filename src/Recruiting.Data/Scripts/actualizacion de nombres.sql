UPDATE dbo.TipoEstadoCandidatura
SET EstadoCandidatura = 'Pendiente Filtrado'
WHERE TipoEstadoCandidaturaId = 1;

UPDATE dbo.TipoEstadoCandidatura
SET EstadoCandidatura = 'Pendiente Filtrado'
WHERE TipoEstadoCandidaturaId = 11;

UPDATE dbo.TipoEstadoCandidatura
SET EstadoCandidatura = 'Rechaza Oferta'
WHERE TipoEstadoCandidaturaId = 9;

UPDATE dbo.TipoEstadoCandidatura
SET EstadoCandidatura = 'Stand-by'
WHERE TipoEstadoCandidaturaId = 6;

UPDATE dbo.TipoEstadoCandidatura
SET EstadoCandidatura = 'Backlog Entrevista'
WHERE TipoEstadoCandidaturaId = 12;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Filtrado Técnico'
WHERE TipoEtapaCandidaturaId = 1;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Filtrado Telefónico'
WHERE TipoEtapaCandidaturaId = 13;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Feedback Entrevista'
WHERE TipoEtapaCandidaturaId = 5;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Feedback 2ª Entrevista'
WHERE TipoEtapaCandidaturaId = 6;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Pendiente Decisión Carta Oferta'
WHERE TipoEtapaCandidaturaId = 15;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Pendiente Decisión 2ª Entrevista'
WHERE TipoEtapaCandidaturaId = 14;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Feedback Carta Oferta'
WHERE TipoEtapaCandidaturaId = 7;

UPDATE dbo.TipoEtapaCandidatura
SET EtapaCandidatura = 'Agendar Entrevistas'
WHERE TipoEtapaCandidaturaId = 2;

UPDATE dbo.RelacionEtapa
SET EstadoFinId = 4, EtapaFinId = 15
WHERE RelacionEtapaId = 30;

UPDATE dbo.TipoEtapaCandidatura
SET Activo = 0
WHERE TipoEtapaCandidaturaId = 3 or TipoEtapaCandidaturaId = 6 or TipoEtapaCandidaturaId = 14;

UPDATE dbo.TipoEstadoCandidatura
SET Activo = 0
WHERE TipoEstadoCandidaturaId = 2 or TipoEstadoCandidaturaId = 13;

