--CONSULTA

select Necesidad.NecesidadId, PersonaAsignada, necesidad.Observaciones, necesidad.UsuarioModificacionId, candidatura.CandidaturaId, Candidato.Nombre, Candidato.Apellidos from Necesidad, CartaOferta, Candidatura, Candidato
where candidatura.CandidatoId = candidato.CandidatoId
and necesidad.NecesidadId = CartaOferta.NecesidadId
and candidatura.CandidaturaId = CartaOferta.CandidaturaId
and CentroId = 1306
and EstadoNecesidadId = 11
and TipoContratacionId = 7
and necesidad.Activo = 1
and PersonaAsignada is not null



--PROCEDIMIENTO

DECLARE @NecesidadId as INT;
DECLARE @NecesidadCursor as CURSOR;
SET @NecesidadCursor = CURSOR FOR
SELECT NecesidadId
 FROM Necesidad
 WHERE Activo = 1
 AND CentroId = 1306
 AND EstadoNecesidadId = 11
 AND TipoContratacionId = 7
 AND PersonaAsignada is null;

OPEN @NecesidadCursor;
FETCH NEXT FROM @NecesidadCursor INTO @NecesidadId;
WHILE @@FETCH_STATUS = 0
BEGIN
 update Necesidad
 set PersonaAsignada = (select candidato.Nombre from Candidato, Candidatura, CartaOferta, Necesidad
					where candidatura.CandidatoId = candidato.CandidatoId
					and necesidad.NecesidadId = CartaOferta.NecesidadId
					and candidatura.CandidaturaId = CartaOferta.CandidaturaId
					and necesidad.NecesidadId = @NecesidadId
					and necesidad.Activo = 1) + ' ' + (select candidato.Apellidos from Candidato, Candidatura, CartaOferta, Necesidad
					where candidatura.CandidatoId = candidato.CandidatoId
					and necesidad.NecesidadId = CartaOferta.NecesidadId
					and candidatura.CandidaturaId = CartaOferta.CandidaturaId
					and necesidad.NecesidadId = @NecesidadId
					and necesidad.Activo = 1) 
 where NecesidadId = @NecesidadId;


 FETCH NEXT FROM @NecesidadCursor INTO @NecesidadId;
END
CLOSE @NecesidadCursor;
DEALLOCATE @NecesidadCursor;