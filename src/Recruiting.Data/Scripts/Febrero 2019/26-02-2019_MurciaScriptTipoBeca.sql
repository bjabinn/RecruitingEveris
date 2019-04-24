DECLARE @TempTable TABLE(ID int);
DECLARE @TipoMaestroID int;

BEGIN
	INSERT INTO @TempTable SELECT TipoMaestroId FROM TipoMaestro WHERE TipoMaestro='Tipo Becario'; 
	SET @TipoMaestroID = (SELECT * FROM @TempTable);

	INSERT INTO Maestro VALUES(@TipoMaestroID, 'Certificado de Profesionalidad',1,NULL,96);

END