SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(31, '<html>
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
				Estimado {0},
				
        </div>~NombreCandidato|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Tal y como hemos quedado en nuestra conversación telefónica, te confirmo la entrevista con nosotros para el próximo <b>{0}</b> a las <b>{1}</b>. La dirección de la 
			 entrevista, así como los datos de contacto, podrás revisarlos en la firma del correo.
        </div>~SoloFecha~SoloHora|
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Deberás preguntar por <b>{0}</b>
        </div>~NombreEntrevistador|
		<br/>
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Por favor, confírmame la recepción de este correo.
        </div>
		<br/>		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu atención, un saludo,
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
					 Av. Oscar Espla, 37, 2ª Planta
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 03007, Alicante
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Tel: +34 965 146 920
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 Ext: 113330
					</div>	
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(0,10,236)">
					    <a href="mailto:spain.alc.hhrr@everis.com">spain.alc.hhrr@everis.com</a>						
						<br/>
						<a href="http://everis.com">everis.com</a>
					</div>
				</td>
			</tr>
		</table>
       <br/>
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
         Sus datos personales incluidos en el curriculum remitido, así como los puestos de manifiesto durante su proceso de selección han sido incorporados a 
		 un fichero cuyo responsable es EVERIS SPAIN S.LU., con domicilio en Av. Manoteras, 52 28050  Madrid, y serán tratados con la finalidad de gestionar el 
		 proceso de selección, de incluir su candidatura en procesos de selección presentes y/o futuros, gestionar en su caso la contratación del candidato seleccionado,
		 reenviar su candidatura a aquellas compañías del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar interesadas en su perfil, 
		 realizar estadísticas, así como para enviarle información relacionada con las actividades y servicios del Grupo everis que pudieran ser de interés para 
		 el candidato, tales como, sin carácter limitativo, el envío de ofertas, noticias, eventos, newsletters, encuestas  e informaciones relacionadas con el 
		 sector de la consultoría. Asimismo,  le informamos que sus datos podrán ser transferidos a otras entidades del grupo  EVERIS * de acuerdo a la información 
		 facilitada en nuestra página web http://www.everis.com, algunas de ellas establecidas en países no miembros de la Unión Europea, todas ellas vinculadas al 
		 sector de la consultoría. Ayúdenos a mantener dichos datos actualizados comunicándonos cualquier modificación que se produzca en los mismos.
        </div>
		<br/>
			<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
               Si no desea que el tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso,rectificación cancelación 
			   u oposición, deberá dirigirse por escrito al Departamento de Selección de EVERIS SPAIN S.L.U ( adjuntando fotocopia de su DNI o documento de 
			   identificación equivalente), en la dirección  arriba indicada o vía correo electrónico a la dirección electrónica alicante@everis.com indicando 
			   en ambos casos la referencia “ Solicitud de derechos Arco (LOPD)”
		</div>
		<br/>	
	</div>
</div>
</body>
</html>', 4, 2017-08-28, 1, 'AvisoEntrevistaCandidato' , 2, 1);


SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (31, 'Asunto', 4, 2017-08-29, 1, 'RRHH Everis. Aviso de entrevista programada')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (31, 'imagenFirma', 4, 2017-08-29, 1, 'logo_everis.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (31, 'LogoCabecera', 4, 2017-86-29, 1, 'CabeceraPlantillaCorreo.png')


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (31, 'Remitente', 4, 2017-08-29, 1, 'Spain.alc.hhrr@everis.com')
