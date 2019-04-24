DECLARE @TempTable TABLE(ID int);
DECLARE @TipoMaestroID int;

BEGIN
	INSERT INTO @TempTable SELECT TipoMaestroId FROM TipoMaestro WHERE TipoMaestro='Fuente Reclutamiento'; 
	SET @TipoMaestroID = (SELECT * FROM @TempTable);

	
	INSERT INTO Maestro VALUES(@TipoMaestroID, 'IES',1,6,96);
	INSERT INTO Maestro VALUES(@TipoMaestroID, 'Univesidad',1,7,96);
	INSERT INTO Maestro VALUES(@TipoMaestroID, 'Centro de estudios',1,8,96);

END