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
				Nous vous rappelons que nous avons un entretien fix� pour le {0}.				
        </div>~FechaEntrevista|	   
        <br />
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Merci de nous indiquer par mail ou par t�l�phone s�il y a un changement de planning de votre part. 

        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 11pt;">
            En attendant notre prochaine rencontre, nous restons � votre disposition pour tout compl�ment d�information.

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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>
			<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
               Si no desea que el tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso,rectificaci�n cancelaci�n 
			   u oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de EVERIS SPAIN S.L.U ( adjuntando fotocopia de su DNI o documento de 
			   identificaci�n equivalente), en la direcci�n  arriba indicada o v�a correo electr�nico a la direcci�n electr�nica 
               <a style="FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt" mailto:"Spain.Mad.rrhh.gestion@everis.com">Spain.Mad.rrhh.gestion@everis.com</a> 
			   indicando en ambos casos la referencia � Solicitud de derechos Arco (LOPD)�.
		</div>
		<br/>	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Helv","sans-serif"; COLOR: #505050; FONT-SIZE: 6pt;">
           *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina 
		   web: www.everis.com tales como Everis Spain S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis 
		   Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A, Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de 
		   R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC, Everis Polonia Sp. Z o. , Everis Italia S.p.A, Everis Portugal S.A, Everis BPO Portugal 
		   LDA, FIT Inversi�n en Talento SCR, Everis Financial Advisory Services Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica)
		   ,, I-Deals Innovation&technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U,S.L, Everis Aeroespacial y Defensa 
		   S.L.U, Everpross S.LU, Cetel Ingenier�a de Sistemas S.L.U,, Everis Mobile S.L  y Fundaci�n Everis. 
        </div>
		<br/>
	</div>
</div>
</body>
</html>
', 4, 2017-06-06, 1, 'AvisoEntrevistaCandidato', 1170)

SET IDENTITY_INSERT CorreoPlantilla OFF


INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (27, 'Asunto', 4, 2017-06-06, 1, 'Recruiting Everis. entrevue pr�vue avis')

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