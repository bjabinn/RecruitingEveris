SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(195, '<html>
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
			Desde el Departamento de Recursos Humanos de Everis Centers queremos agradecerte el interés mostrado hacia nuestra compañía, así como el tiempo dedicado durante el proceso de selección.
		</div>
		<br/>
		
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;>
			Siento comunicarte que contamos con otras candidaturas que se ajustan en mayor medida con lo que buscamos en la actualidad, no obstante, nos quedamos con tu CV para futuras necesidades que vayan surgiendo.
		</div>
		<br/>

	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
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
						<b>Recruiting Alicante</b>
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Avenida Oscar Esplá nº37 2ª planta
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 03007 Alicante
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Tel: +34 965 146 920 Fax 91 749 02 02
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(0,10,236)">
						<a href="mailto:spain.alc.hhrr@everis.com ">spain.alc.hhrr@everis.com</a>
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
</html>', 4, 2019-01-30, 1, 'DescarteBecaInterna' , 2, null);


SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (195, 'Asunto', 4, 2019-01-30, 1, 'Comunicación resultado proceso de selección')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (195, 'imagenFirma', 4, 2019-01-30, 1, 'logo_everis.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (195, 'LogoCabecera', 4, 2019-01-30, 1, 'CabeceraPlantillaCorreo.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (195, 'Remitente', 4, 2019-01-30, 1, 'spain.alc.hhrr@everis.com')
