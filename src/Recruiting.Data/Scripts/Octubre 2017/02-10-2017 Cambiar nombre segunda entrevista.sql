update TipoEtapaCandidatura
set EtapaCandidatura = 'Agendar Entrevista Complementaria'
where TipoEtapaCandidaturaId = 3;

update TipoEtapaCandidatura
set EtapaCandidatura = 'Feedback Entrevista Complementaria'
where TipoEtapaCandidaturaId = 6;

update TipoEtapaCandidatura
set EtapaCandidatura = 'Pendiente Decisión Entr. Comp.'
where TipoEtapaCandidaturaId = 14;

update TipoEstadoCandidatura
set EstadoCandidatura = 'Entrevista Complementaria'
where TipoEstadoCandidaturaId = 2;