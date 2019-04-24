SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(41,'', 4, 2018-02-06, 1, 'CartaOferta', 1306, null);


SET IDENTITY_INSERT CorreoPlantilla OFF 



INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'AtencionTelefonica', 4, 2018-02-06, 1, '923 12 62 87')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'AyudaComedor', 4, 2018-02-06, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'CargoEntregaCarta', 4, 2018-02-06, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'Fax', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'LineaDireccion', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'LineaEmail', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'LineaProvincia', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'LineaTelefono', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'LineaTituloPie', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'LineaWeb', 4, 2018-02-06, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'MailTo', 4, 2018-02-06, 1, 'spain.personal.candidate@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'NombreEntregaCarta', 4, 2018-02-06, 1, 'Juan Antonio Garay')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (41, 'Telefono', 4, 2018-02-06, 1, '917 49 07 91')

