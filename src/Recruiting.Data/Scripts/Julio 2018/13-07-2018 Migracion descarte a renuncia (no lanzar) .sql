update Maestro
set Activo = 0
where MaestroId in(102, 1168)

update Candidatura
set MotivoRenunciaDescarteId = 1196,
EstadoCandidaturaId = 10
where MotivoRenunciaDescarteId = 102

update Candidatura
set MotivoRenunciaDescarteId = 1197,
EstadoCandidaturaId = 10
where MotivoRenunciaDescarteId = 1168

DECLARE @CandidaturaId as INT;
DECLARE @CandidaturaCursor as CURSOR;
SET @CandidaturaCursor = CURSOR FOR
SELECT CandidaturaId
 FROM Entrevista
 WHERE MotivoId = 102;
 OPEN @CandidaturaCursor;
FETCH NEXT FROM @CandidaturaCursor INTO @CandidaturaId;
WHILE @@FETCH_STATUS = 0
BEGIN
	 UPDATE Candidatura
	 set MotivoRenunciaDescarteId = 1196,	 
	 EstadoCandidaturaId = 10
where CandidaturaId = @CandidaturaId
 FETCH NEXT FROM @CandidaturaCursor INTO @CandidaturaId;
END
CLOSE @CandidaturaCursor;
DEALLOCATE @CandidaturaCursor;

update Entrevista
set SuperaEntrevista = 1,
MotivoId = null
where MotivoId = 102

DECLARE @CandidaturaId as INT;
DECLARE @CandidaturaCursor as CURSOR;
SET @CandidaturaCursor = CURSOR FOR
SELECT CandidaturaId
 FROM Entrevista
 WHERE MotivoId = 1168;
 OPEN @CandidaturaCursor;
FETCH NEXT FROM @CandidaturaCursor INTO @CandidaturaId;
WHILE @@FETCH_STATUS = 0
BEGIN
	 UPDATE Candidatura
	 set MotivoRenunciaDescarteId = 1197,	 
	 EstadoCandidaturaId = 10
where CandidaturaId = @CandidaturaId
 FETCH NEXT FROM @CandidaturaCursor INTO @CandidaturaId;
END
CLOSE @CandidaturaCursor;
DEALLOCATE @CandidaturaCursor;

update Entrevista
set SuperaEntrevista = 1,
MotivoId = null
where MotivoId = 1168

