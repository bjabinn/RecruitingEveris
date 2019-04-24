SET IDENTITY_INSERT RelacionEtapa ON

insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, Descripcion) values
(1082, 14, 14, 34, 3, 1, 2, 'Pausa:Pend. decision Entr. Compl.->Pend. decision Entr. Compl.->StandBy'); 

insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, Descripcion) values
(1083, 14, 14, 35, 2, 1, 3, 'Reanudar:Pend. decision Entr. Compl.->Pend. decision Entr. Compl.->Entrevista'); 

insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, Descripcion) values
(1084, 15, 15, 24, 3, 1, 4, 'Pausa:Pend. decision Entr. Compl.->Pend. decision Entr. Compl.->StandBy'); 

insert into RelacionEtapa (RelacionEtapaId, EtapaOrigenId, EtapaFinId, TipoDecisionId, EstadoFinId, Activo, EstadoOrigenId, Descripcion) values
(1085, 15, 15, 35, 4, 1, 3, 'Reanudar:Pend. decision Carta Oferta->Pend. decision Carta Oferta->Carta Oferta'); 

SET IDENTITY_INSERT RelacionEtapa OFF