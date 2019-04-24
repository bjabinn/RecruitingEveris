update Entrevista
set Completada = 1
where CandidaturaId in (SELECT c.CandidaturaId from Candidatura c, Entrevista e
						where c.EtapaCandidaturaId not in(11,1,13,2, 5)
						and c.CandidaturaId = e.CandidaturaId)

update Entrevista
set Entrevista.Completada = 1
Where CandidaturaId in (select c.CandidaturaId from Candidatura c, Entrevista e
                        where c.CandidaturaId = e.CandidaturaId and (c.EstadoCandidaturaId = 7
						and c.EtapaCandidaturaId = 5) or (c.EstadoCandidaturaId = 10
						and (c.EtapaCandidaturaId = 5 or c.EtapaCandidaturaId = 2
						or c.EtapaCandidaturaId = 13 or c.EtapaCandidaturaId = 1
						or c.EtapaCandidaturaId = 11)))