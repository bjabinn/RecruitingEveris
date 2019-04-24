SET IDENTITY_INSERT CorreoPlantilla ON

INSERT INTO CorreoPlantilla(PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro) 
VALUES (27, '<html>
<head>
    <title>Notificacion</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>
	
		
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Arial","sans-serif";FONT-SIZE: 11pt;">
         Bonjour, 
        </div>
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nous vous rappelons que nous avons un entretien fixé pour le {0}.				
        </div>~FechaEntrevista|	   
        <br />
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Merci de nous indiquer par mail ou par téléphone s’il y a un changement de planning de votre part. 

        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 11pt;">
            En attendant notre prochaine rencontre, nous restons à votre disposition pour tout complément d’information.

        </div>
        <br />
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
            Bien cordialement.
        </div>
		<br/>
		
        
		<table style="border:none;">
			<tr>
				<td><span><img src="{0}"  /></span>~imagenFirma||</td>
				<td>
					<div style="TEXT-ALIGN:left;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 9pt;COLOR:rgb(54,95,145)">
						<b>{0}</b>~LineaTituloPie|
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 {0}~LineaDireccion|
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 {0}~LineaProvincia|
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
					 {0}~LineaTelefono|
					</div>
					<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(0,10,236)">
						<a href="mailto:{0}">{0}</a>~LineaEmail|
						<br/>
						<a href="http://{0}">{0}</a>~LineaWeb|
					</div>
				</td>
			</tr>
		</table>
       <br/>
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
          Sus datos personales incluidos en el curriculum remitido, asi como los puestos de manifiesto durante el proceso de seleccion
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, núm. 52. 28050 Madrid, y serán tratados
                con la finalidad de gestionar el proceso de selección, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compañias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gestión de los procesos de selección, sus datos podrán ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la información facilitada en nuestra página web <a href="http://www.everis.com" style="FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en países no miembros de la Unión Europea. Ayúdenos a mantener dichos datos actualizados comunicándonos cualquier
                modificación que se produzca en los mismos.
        </div>
		<br/>
			<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
               Si no desea que el tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso,rectificación cancelación 
			   u oposición, deberá dirigirse por escrito al Departamento de Selección de EVERIS SPAIN S.L.U ( adjuntando fotocopia de su DNI o documento de 
			   identificación equivalente), en la dirección  arriba indicada o vía correo electrónico a la dirección electrónica 
               <a style="FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt" mailto:"Spain.Mad.rrhh.gestion@everis.com">Spain.Mad.rrhh.gestion@everis.com</a> 
			   indicando en ambos casos la referencia “ Solicitud de derechos Arco (LOPD)”.
		</div>
		<br/>	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
           *La Compañía podrá ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la página 
		   web: www.everis.com tales como Everis Spain S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis 
		   Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A, Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis México S. de R.L, Everis BPO México S. de 
		   R.L, Everis Panamá INC, Everis Perú SAC, Everis BPO Perú SAC, Everis Polonia Sp. Z o. , Everis Italia S.p.A, Everis Portugal S.A, Everis BPO Portugal 
		   LDA, FIT Inversión en Talento SCR, Everis Financial Advisory Services Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South África)
		   ,, I-Deals Innovation&technology Venturing Services S.L.U, Everis Aragón S.L.U, Everis Servicios Energéticos S.L.U,S.L, Everis Aeroespacial y Defensa 
		   S.L.U, Everpross S.LU, Cetel Ingeniería de Sistemas S.L.U,, Everis Mobile S.L  y Fundación Everis. 
        </div>
		<br/>
	</div>
</div>
</body>
</html>
', 4, 2017-06-06, 1, 'AvisoEntrevistaCandidato', 1170)

SET IDENTITY_INSERT CorreoPlantilla OFF


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'Asunto', 4, 2017-06-06, 1, 'Recruiting Everis. entrevue prévue avis')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'FechaEntrevista', 4, 2017-06-06, 1, NULL)

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'imagenFirma', 4, 2017-06-06, 1, 'logo_everis.png')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LineaDireccion', 4, 2017-06-06, 1, 'TetouanShore Park-Shore 3
Route de Cabo Negro')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LineaEmail', 4, 2017-06-06, 1, 'Recruiting.Centers.Morocco@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LineaProvincia', 4, 2017-06-06, 1, '93000 Martil, Morocco')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LineaTelefono', 4, 2017-06-06, 1, 'Tlf: +212 531 06 2990')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LineaTituloPie', 4, 2017-06-06, 1, 'Everis centers Morocco ')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LineaWeb', 4, 2017-06-06, 1, 'www.everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'LogoCabecera', 4, 2017-06-06, 1, 'CabeceraPlantillaCorreo.png')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'NombreCandidato', 4, 2017-06-06, 1, NULL)

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'NombreEntrevistador', 4, 2017-06-06, 1, NULL)

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'Remitente', 4, 2017-06-06, 1, 'Recruiting.Centers.Morocco@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'TipoEntrevista', 4, 2017-06-06, 1, NULL)