SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(125, '<html>
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
				Buenos d�as,
				
        </div>
		<br/>
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;>
			Su referenciado/a {0} ha sido incluido en nuestra base de datos, si existen necesidades acorde a su perfil profesional nos pondremos en contacto con �l lo antes posible.
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
						<b>Recruiting Salamanca</b>
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 37185 Villamayor, Salamanca
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Tel: +34 92 312 62 87
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(0,10,236)">
						<a href="mailto:spain.sal.hhrr@everis.com">spain.sal.hhrr@everis.com</a>
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
</html>', 4, 2018-11-13, 1, 'RefFiltroTelefonico' , 1306, null);


SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (125, 'Asunto', 4, 2018-11-13, 1, 'Notificacion Referenciado')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (125, 'imagenFirma', 4, 2018-11-13, 1, 'logo_everis.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (125, 'LogoCabecera', 4, 2018-11-13, 1, 'CabeceraPlantillaCorreo.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (125, 'Remitente', 4, 2018-11-13, 1, 'spain.sal.hhrr@everis.com')
