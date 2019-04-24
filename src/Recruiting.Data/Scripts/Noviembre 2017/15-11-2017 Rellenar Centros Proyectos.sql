--Este script requiere que se lancen las migraciones hasta el punto Aniadir_Centro_a_Proyectos
--y luego continuar con el resto de migraciones

update Proyecto
set Centro = (select Centro from Cliente where ClienteId = Proyecto.ClienteId)


update Cliente
set Activo = 0, Centro = null
where ClienteId not in(select min(ClienteId) from Cliente
						where nombre in (select distinct Nombre from Cliente
											group by Nombre
											having count(*) > 1)
						group by Nombre)
and Nombre in (select distinct Nombre from Cliente
					group by Nombre
					having count(*) > 1)


DECLARE @ClienteId as INT;
DECLARE @Nombre as NVARCHAR(50);
DECLARE @ClienteCursor as CURSOR;
SET @ClienteCursor = CURSOR FOR
SELECT ClienteId, Nombre
 FROM Cliente
 WHERE Activo = 1;
 OPEN @ClienteCursor;
FETCH NEXT FROM @ClienteCursor INTO @ClienteId, @Nombre;
WHILE @@FETCH_STATUS = 0
BEGIN
 update Proyecto
 set ClienteId = @ClienteId
 where ClienteId in (select ClienteId from Cliente
					where Nombre in (@Nombre) and
					Activo = 0)
 FETCH NEXT FROM @ClienteCursor INTO @ClienteId, @Nombre;
END
CLOSE @ClienteCursor;
DEALLOCATE @ClienteCursor;