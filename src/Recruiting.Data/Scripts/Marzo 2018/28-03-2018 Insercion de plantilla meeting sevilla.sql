SET IDENTITY_INSERT CorreoPlantilla ON 
  
insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(42, '
Buenos días

Se les ha asignado una reunión.
Por favor, confirmen su asistencia.

Un saludo
', 4, 2017-12-05, 1, 'Meeting' , 98, null);
 
SET IDENTITY_INSERT CorreoPlantilla OFF
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (42, 'Asunto', 4, 2017-08-29, 1, 'Meeting')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (42, 'imagenFirma', 4, 2017-08-29, 1, 'logo_everis.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (42, 'LogoCabecera', 4, 2017-08-29, 1, 'CabeceraPlantillaCorreo.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (42, 'Remitente', 4, 2017-08-29, 1, 'Recruiting.Centers.Sevilla@everis.com')

