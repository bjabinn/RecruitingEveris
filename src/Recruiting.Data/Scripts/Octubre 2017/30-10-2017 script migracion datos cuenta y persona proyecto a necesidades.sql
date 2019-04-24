USE [EVERISRECRUITING]
GO
DECLARE db_proyectos CURSOR FOR 
    SELECT py.ProyectoId 
        ,py.CuentaCargo
        ,py.Persona
    FROM Proyecto py
    DECLARE @proyecto int;
    DECLARE @persona nvarchar(max);
    DECLARE @cuenta nvarchar(max);

OPEN db_proyectos;
FETCH NEXT FROM db_proyectos INTO @proyecto, @persona, @cuenta;
WHILE @@FETCH_STATUS = 0  
BEGIN 
    UPDATE [dbo].[Necesidad]
       SET [PersonaProyecto] = @persona
          ,[CuentaProyecto] = @cuenta
     WHERE [ProyectoId] = @proyecto 

     FETCH NEXT FROM db_proyectos INTO @proyecto, @persona, @cuenta;
END;		
CLOSE db_proyectos;
DEALLOCATE db_proyectos;
