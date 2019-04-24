SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(95, '<html>
<head>
    <title>Notificacion</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Buenos días,
				
        </div>
		<br/>
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;>
			Su referenciado/a {0} ha sido incluido en nuestra base de datos, si existen necesidades acorde a su perfil profesional nos pondremos en contacto con él lo antes posible.
		</div>~Candidato|
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Muchas gracias.
        </div>		
		<br/>	
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Un saludo,
        </div>
		<br/>			
        
		<table style="border:none;">
				<tr>
				<td><span><img src="{0}"  /></span>~imagenFirma||</td>
				<td>
					<div style="TEXT-ALIGN:left;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 9pt;COLOR:rgb(54,95,145)">
						<b>Recruiting Sevilla</b>
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Avda. Americo Vespucio, 5.2º.C Edificio Cartuja
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 41092 Sevilla
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Telf:+34 95 498 97 10 Fax:+34 95 498 97 11
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(0,10,236)">
						<a href="mailto:Recruiting.Centers.Sevilla@everis.com">Recruiting.Centers.Sevilla@everis.com</a>
						<br/>
						<a href="http://www.everis.com">www.everis.com</a>
					</div>
				</td>
			</tr>
		</table>
       <br/>		
	</div>
</div>
</body>
</html>', 4, 2018-11-13, 1, 'RefFiltroTelefonico' , 98, null);


SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (95, 'Asunto', 4, 2018-11-13, 1, 'Notificacion Referenciado')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (95, 'imagenFirma', 4, 2018-11-13, 1, 'logo_everis.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (95, 'LogoCabecera', 4, 2018-11-13, 1, 'CabeceraPlantillaCorreo.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (95, 'Remitente', 4, 2018-11-13, 1, 'Recruiting.Centers.Sevilla@everis.com')
