DECLARE @EntrevistaID INT;
DECLARE @SuperaEntrevista BIT;
DECLARE @TipoEntrevistaID INT;
DECLARE @SinDecision BIT;
DECLARE @CandidaturaID INT;
DECLARE @EstadoCandidatura INT;

DECLARE entrevista_cursor CURSOR FOR
SELECT E.EntrevistaId, C.CandidaturaId,E.SuperaEntrevista, E.TipoEntrevistaId, SinDecision, C.EstadoCandidaturaId
  FROM Entrevista E 
  JOIN CANDIDATURA C ON E.CandidaturaId = C.CandidaturaId

OPEN entrevista_cursor;
FETCH NEXT FROM entrevista_cursor INTO @EntrevistaID,@CandidaturaID, @SuperaEntrevista,@TipoEntrevistaID,@SinDecision,@EstadoCandidatura;

WHILE @@FETCH_STATUS = 0
BEGIN
		IF @SuperaEntrevista = 1
			UPDATE Entrevista SET SinDecision = 0 WHERE EntrevistaId = @EntrevistaID;
		ELSE IF @SuperaEntrevista = 0 AND @EstadoCandidatura = 7 OR @EstadoCandidatura = 9 OR @EstadoCandidatura = 10
			UPDATE Entrevista SET SinDecision = 0 WHERE EntrevistaId = @EntrevistaID;
		ELSE
			UPDATE Entrevista SET SinDecision = 1 WHERE EntrevistaId = @EntrevistaID;

	FETCH NEXT FROM entrevista_cursor INTO @EntrevistaID,@CandidaturaID, @SuperaEntrevista,@TipoEntrevistaID,@SinDecision,@EstadoCandidatura;
END

CLOSE entrevista_cursor
DEALLOCATE entrevista_cursor
	


