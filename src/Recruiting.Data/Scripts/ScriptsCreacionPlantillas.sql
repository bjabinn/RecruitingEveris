
USE [EVERISRECRUITING]
GO


DECLARE @remitente varchar(100)
SET @remitente = N'alejandro.garcia.pastor@everis.com'

--correo plantilla AvisoEntrevistaCandidato alicante
INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '<html>
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
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el {0} tenemos pendiente una entrevista
				en nuestras oficinas.
				
        </div>~FechaEntrevista|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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

 '
  	   ,4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaCandidato',2) 

	   

	   --correo plantilla AvisoEntrevistaCandidato murcia
INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '<html>
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
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el {0} tenemos pendiente una entrevista
				en nuestras oficinas.
				
        </div>~FechaEntrevista|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
'
  	   ,4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaCandidato',96) 

	   
	   
	   --correo plantilla AvisoEntrevistaCandidato sevilla
INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '<html>
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
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el {0} tenemos pendiente una entrevista
				en nuestras oficinas.
				
        </div>~FechaEntrevista|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    '
  	   ,4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaCandidato',98) 

	   
--correo plantilla AvisoEntrevistaCandidato tucuman
INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '<html>
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
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el {0} tenemos pendiente una entrevista
				en nuestras oficinas.
				
        </div>~FechaEntrevista|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
'
  	   ,4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaCandidato',99) 

	   

	   
--correo plantilla AvisoEntrevistaCandidato temuco
INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '<html>
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
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el {0} tenemos pendiente una entrevista
				en nuestras oficinas.
				
        </div>~FechaEntrevista|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
</html>'
  	   ,4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaCandidato',101) 

	   --correo plantilla AvisoEntrevistaCandidato uberlandia
INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '<html>
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
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el {0} tenemos pendiente una entrevista
				en nuestras oficinas.
				
        </div>~FechaEntrevista|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
        </div><br/></div></div></body></html>
		'
  	   ,4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaCandidato',103) 

	   
	   ----correo plantilla AvisoEntrevistaEntrevistador Alicante
		INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		   <html>
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
         Estimado {0}
        </div>~NombreEntrevistador|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el <b>{0}</b> tienes pendiente una <b>{1}</b>
				en nuestras oficinas con el candidato <b>{2}</b>.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
		
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Del mismo modo te recordamos que los datos de la candidatura <b>Ref: {0}</b> los tienes disponibles en la 
				herramienta de Recruiting {1}{2}
        </div>~CandidaturaId~UrlRecruiting~CandidaturaId| 
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    </div>
</div>

</body>
</html>

		   ',4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaEntrevistador',2) 
   
     -- plantilla correo AvisoEntrevistaEntrevistador Sevilla
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		   <html>
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
         Estimado {0}
        </div>~NombreEntrevistador|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el <b>{0}</b> tienes pendiente una <b>{1}</b>
				en nuestras oficinas con el candidato <b>{2}</b>.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
		
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Del mismo modo te recordamos que los datos de la candidatura <b>Ref: {0}</b> los tienes disponibles en la 
				herramienta de Recruiting {1}{2}
        </div>~CandidaturaId~UrlRecruiting~CandidaturaId| 
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    </div>
</div>

</body>
</html>

		   ',4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaEntrevistador',98) 
   
     -- plantilla correo AvisoEntrevistaEntrevistador Murcia
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		   <html>
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
         Estimado {0}
        </div>~NombreEntrevistador|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el <b>{0}</b> tienes pendiente una <b>{1}</b>
				en nuestras oficinas con el candidato <b>{2}</b>.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
		
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Del mismo modo te recordamos que los datos de la candidatura <b>Ref: {0}</b> los tienes disponibles en la 
				herramienta de Recruiting {1}{2}
        </div>~CandidaturaId~UrlRecruiting~CandidaturaId| 
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    </div>
</div>

</body>
</html>

		   ',4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaEntrevistador',96) 
   
      -- plantilla correo AvisoEntrevistaEntrevistador Tucumán
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		   <html>
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
         Estimado {0}
        </div>~NombreEntrevistador|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el <b>{0}</b> tienes pendiente una <b>{1}</b>
				en nuestras oficinas con el candidato <b>{2}</b>.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
		
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Del mismo modo te recordamos que los datos de la candidatura <b>Ref: {0}</b> los tienes disponibles en la 
				herramienta de Recruiting {1}{2}
        </div>~CandidaturaId~UrlRecruiting~CandidaturaId| 
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    </div>
</div>

</body>
</html>

		   ',4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaEntrevistador',99) 
   
   
    -- plantilla correo AvisoEntrevistaEntrevistador Temuco
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		   <html>
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
         Estimado {0}
        </div>~NombreEntrevistador|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el <b>{0}</b> tienes pendiente una <b>{1}</b>
				en nuestras oficinas con el candidato <b>{2}</b>.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
		
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Del mismo modo te recordamos que los datos de la candidatura <b>Ref: {0}</b> los tienes disponibles en la 
				herramienta de Recruiting {1}{2}
        </div>~CandidaturaId~UrlRecruiting~CandidaturaId| 
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    </div>
</div>

</body>
</html>

		   ',4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaEntrevistador',101) 
   
   
  -- plantilla correo AvisoEntrevistaEntrevistador Uberlandia
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		   <html>
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
         Estimado {0}
        </div>~NombreEntrevistador|
		<br/>

        
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para recordarte que el <b>{0}</b> tienes pendiente una <b>{1}</b>
				en nuestras oficinas con el candidato <b>{2}</b>.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
		
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Del mismo modo te recordamos que los datos de la candidatura <b>Ref: {0}</b> los tienes disponibles en la 
				herramienta de Recruiting {1}{2}
        </div>~CandidaturaId~UrlRecruiting~CandidaturaId| 
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
		
    </div>
</div>

</body>
</html>

		   ',4,'2016-04-04 00:00:00.000',1,N'AvisoEntrevistaEntrevistador',103) 
   
   
   
   ---correo backlog alicante
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   
		   '
		  <html><head> <title>Correo backlog</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>
	
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
          Buenos días 
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos complace comunicarte que has superado nuestro proceso de selección, no obstante, 
				las necesidades de perfiles con conocimientos y categoría similar a la tuya, son 
				actualmente puntuales en nuestra Compañía, por ese motivo, tu candidatura queda aplazada 
				hasta el momento en que surjan necesidades que se ajusten a tu área de competencia. 
				Será entonces cuando contactaremos nuevamente para valorar tu incorporación en la Compañía.
        </div>
		<br/>
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Una vez más, muchas gracias por tu tiempo.
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
        </div><br/></div></div></body></html>

		   ',4,'2016-04-04 00:00:00.000',1,N'CorreoBacklog',2) 
   
         
   ---correo backlog Sevilla
   	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   '
		   <html><head> <title>Carta Oferta</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>
	
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
          Buenos días {0}, ~NombreCandidato|
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos complace comunicarte que has superado nuestro proceso de selección, no obstante, las necesidades de perfiles con conocimientos y categoría similar a la tuya, son actualmente puntuales en nuestra Compañía, por ese motivo, tu candidatura queda aplazada hasta el momento en que surjan necesidades que se ajusten a tu área de competencia. 
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Será entonces cuando contactaremos nuevamente para valorar tu incorporación en la Compañía.
        </div>
		<br/>
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Una vez más, muchas gracias por tu tiempo.
        </div>
		<br/>
	   
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Saludos,
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
        </div><br/></div></div></body></html>
      ',4,'2016-04-04 00:00:00.000',1,N'CorreoBacklog',98) 
   
  

  --plantilla CorreoDescartado Sevilla
  	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   '
		 <html>
<head>
    <title></title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>
	
		
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Arial","sans-serif";FONT-SIZE: 11pt;">
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				En primer lugar queremos agradecerte el interés que has demostrado hacia nuestra 
				Compañía, así como el tiempo que nos has dedicado durante el proceso de selección 
				realizado con nosotros.
        </div>
		<br/>
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para comunicarte que, tras el proceso de selección 
				realizado en nuestras oficinas, valoramos que, tanto tu perfil como tu área de 
				competencia, no se ajustan de forma efectiva a nuestras necesidades actuales, por 
				este motivo no te hemos seleccionado para incorporarte en la Compañía.
        </div>
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
        </div><br/>
		
		
		
		
		
    </div>
</div>

</body>
</html>
    
    ',4,'2016-04-04 00:00:00.000',1,N'CorreoDescartado',98) 
	
	
	--plantilla CorreoDescartado Alicante
  	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		   '
  <html>
<head>
    <title></title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>
	
		
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Arial","sans-serif";FONT-SIZE: 11pt;">
         Estimado {0}
        </div>~NombreCandidato|
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				En primer lugar queremos agradecerte el interés que has demostrado hacia nuestra 
				Compañía, así como el tiempo que nos has dedicado durante el proceso de selección 
				realizado con nosotros.
        </div>
		<br/>
     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos ponemos en contacto contigo para comunicarte que, tras el proceso de selección 
				realizado en nuestras oficinas, valoramos que, tanto tu perfil como tu área de 
				competencia, no se ajustan de forma efectiva a nuestras necesidades actuales, por 
				este motivo no te hemos seleccionado para incorporarte en la Compañía.
        </div>
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
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
        </div><br/>
		
		
		
		
		
    </div>
</div>

</body>
</html>
  
  
     ',4,'2016-04-04 00:00:00.000',1,N'CorreoDescartado',2) 
	 
	 
	 
	 
    
  --plantilla cartaoferta Sevilla
  	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		'
		 <html>
<head>
    <title>Carta Oferta</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">

<div>
    <p>
        <span><img width="794" height="160" src="file:///{0}" /></span>~LogoCabecera|
    </p>


    <div style="padding-left:3cm;padding-right:3cm">
        <div style="TEXT-ALIGN: justify; FONT-FAMILY: ''Arial'',''sans-serif''; FONT-SIZE: 11pt; COLOR: #505050">

            <div style="float:right;">En {0}, a {1}</div>~Centro~fecha|

        </div>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 11pt;">
            {0}~NombreCandidato|
        </div>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           ¡Enhorabuena! Es un placer escribirte para confirmarte nuestro interés en tu incorporación en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compañía de consultoría de ámbito internacional, con unas sólidas perspectivas
                de expansión, crecimiento y consolidación en este mercado y queremos agradecerte la confianza que has demostrado además del interés por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrarás el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibirás la formación y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez más agradecerte el tiempo que nos has dedicado durante el proceso de selección y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que además de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta así como el anexo que se adjunta,indicando tu aceptación a la atención del <b>Departamento de Selección</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmación de tu decisión definitiva.
        </div>
		<br/>
       
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;COLOR: #505050">
        Un cordial saludo,
        </div>
		<br/>
        
		
		 <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:70%;float:right;TEXT-ALIGN: center">
                Conforme:
            </div>
		</div>
		<div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>
       
        

        <p >
            <span><img width="2.3cm" height="2.0cm" src="file:///{0}" /></span>~imagenFirma||
        </p>


		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
          Sus datos personales incluidos en el curriculum remitido, asi como los puestos de manifiesto durante el proceso de seleccion
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, núm. 52. 28050 Madrid, y serán tratados
                con la finalidad de gestionar el proceso de selección, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compañias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gestión de los procesos de selección, sus datos podrán ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la información facilitada en nuestra página web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en países no miembros de la Unión Europea. Ayúdenos a mantener dichos datos actualizados comunicándonos cualquier
                modificación que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificación, cancelación u
                oposición, deberá dirigirse por escrito al Departamento de Selección de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la dirección arriba indicada.
                *La Compañía podrá ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la página web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis México S. de R.L, Everis BPO México S. de R.L, Everis Panamá INC, Everis Perú SAC, Everis BPO Perú SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South África), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Aragón S.L.U, Everis Servicios Energéticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundación Everis.
            
          </div>
		
    </div>

    


    <p>
        <span><img width="794" height="160" src="file:///{0}" /></span>~LogoCabecera|
    </p>


    <div style="padding-left:3cm;padding-right:3cm">
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b>CONDICIONES DE LA OFERTA a </b>{0}~NombreCandidato|
        </div>
		<br/>
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          <b><u>POSICIÓN OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          <b><u>RELACIÓN CONTRACTUAL </u>: </b>  Contrato Indefinido, con un período de prueba de {0} meses, sujeto al Convenio Colectivo Nacional de 
		  Empresas Consultoras.~PeriodoPrueba|
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		<br/>
        
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;padding-left:1cm;">
           <b>Retribución:  </b> La retribución bruta anual será de {0} <b>€</b> que se liquidarán  en 14 pagas.~SalarioBruto|
			<br />
			
			<b>Retribución Variable: </b> condicionada en función de la categoría ofertada y de acuerdo a la política de la compañía 
			en cada momento. Este variable no se consolidará en la retribución del trabajador.
			<br />
			
			<b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se hará efectiva en el momento en que nos contactes, teniendo un plazo máximo de vigencia 
		   de 15 días naturales, a partir de la fecha de recepción de la misma.
        </div>
		<br/>

        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACIÓN NECESARIA: </u></b>  Con el fin de agilizar al máximo los trámites necesarios para tu contratación, es importante que nos
                entregues, a la mayor brevedad posible, los datos y documentación que enumeramos a continuación:<br/><br/>
				
				• Una  fotocopia del DNI. <br />
				• Fotocopia documento acreditativo de afiliación a la Seguridad Social.  <br />
				• Podrás acogerte a una reducción fiscal por <b>“movilidad geográfica”</b> si estás desempleado e
                inscrito en la oficina de empleo, y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que 
				el nuevo puesto de trabajo exija el cambio de dicha residencia.  <br />
				 En este caso, debes aportar los siguientes documentos: <b>Tarjeta de demandante de empleo </b>y <b>Certificado de dicho organismo, </b>que acredite
				 la vigencia de la tarjeta por encontrarse en situación de desempleo y estar expedidos en tu<b> lugar de origen. </b>  <br />
				• Fotocopia de la Vida Laboral.  <br />
				• Copia compulsada del título  (en cualquier organismo oficial, así como un notario
                o la propia universidad) o en su defecto fotocopia del resguardo de pago de tasas para la expedición del título y de todas aquellas certificaciones
                oficiales (ej. CCNA. CCNP, etc.)  <br />
				• Carta Oferta firmada (las dos hojas donde se indica tu nombre y apellidos) <br />
				• En el caso de que tengas reconocida una discapacidad, <b> Certificado de discapacidad </b>emitido por el organismo oficial correspondiente.<br />
				<br />
				<b> *El día de la incorporación es necesario aportar: datos bancarios, copia compulsada
                  del título y en caso de que te acojas a la reducción por movilidad geográfica: Original de la Demanda de Empleo y Certificado del SEPE. </b>
        </div>
		<br/>
 

    </div>



    <p>
        <span><img width="794" height="160" src="file:///{0}" /></span>~LogoCabecera|
    </p>


    <div style="padding-left:3cm;padding-right:3cm">

        <p class="MsoNormal" style=''text-align:justify''>
            <span style=''font-family:"Arial","sans-serif"''>&nbsp;</span>
        </p>
        <p class="MsoNormal" style=''text-align:justify''>
            <span style=''font-family:"Arial","sans-serif"''>&nbsp;</span>
        </p>
        <p class="MsoNormal" style=''text-align:justify''>
            <span style=''font-family:"Arial","sans-serif"''>&nbsp;</span>
        </p>

		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           <b><u>TRÁMITES DE INCORPORACIÓN: </u></b>  
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  La documentación puede ser enviada por<b> correo</b>:<a href="mailto:Spain.Personal.Candidate@everis.com"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}</span></b></a>~MailTo|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Cualquier duda relativa sobre la documentación a aportar puedes localizarnos vía e-mail al correo anteriormente indicado o vía 
			telefónica:<b> {0}</b> (Departamento de contratación) ~Telefono|
        </div>
		<br/>
         
        

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Para cualquier duda que pudieras tener sobre las condiciones de esta oferta,concretar el día de la incorporación en las fechas establecidas 
			por la empresa y cualquier otra cuestión estamos disponibles vía telefónica:<b> {0} </b> ( {1} )~Telefono~Atencion|
        </div>
		<br/>


         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            Con el fin de agilizar al máximo los trámites necesarios para tu contratación, es importante que
                dispongamos, a la mayor brevedad posible, los datos y documentación requerida.
        </div>
		<br/>


        <br/>
        <br/>
        <br/>
        <br/>

		
         <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:70%;float:right;TEXT-ALIGN: center">
                Conforme:
            </div>
		</div>
		<div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>

        <p>
            <span><img width="2.3cm" height="2.03cm" src="file:///{0}" /></span>~imagenFirma||
        </p>
    </div>
</div>
</body>
</html>
	',4,'2016-04-04 00:00:00.000',1,N'CartaOferta',98)   

  	 
		
	 --plantilla cartaoferta Alicante
  	  	INSERT INTO [dbo].[CorreoPlantilla]
           ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
		   ,[Activo]
           ,[NombrePlantilla]
           ,[Centro])
     VALUES
	       (
		'
		 <html>
<head>
    <title>Carta Oferta</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">

<div>
    <p>
        <span><img width="794" height="160" src="file:///{0}" /></span>~LogoCabecera|
    </p>


    <div style="padding-left:3cm;padding-right:3cm">
        <div style="TEXT-ALIGN: justify; FONT-FAMILY: ''Arial'',''sans-serif''; FONT-SIZE: 11pt; COLOR: #505050">

            <div style="float:right;">En {0}, a {1}</div>~Centro~fecha|

        </div>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 11pt;">
            {0}~NombreCandidato|
        </div>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           ¡Enhorabuena! Es un placer escribirte para confirmarte nuestro interés en tu incorporación en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compañía de consultoría de ámbito internacional, con unas sólidas perspectivas
                de expansión, crecimiento y consolidación en este mercado y queremos agradecerte la confianza que has demostrado además del interés por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrarás el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibirás la formación y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez más agradecerte el tiempo que nos has dedicado durante el proceso de selección y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que además de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta así como el anexo que se adjunta,indicando tu aceptación a la atención del <b>Departamento de Selección</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmación de tu decisión definitiva.
        </div>
		<br/>
       
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;COLOR: #505050">
        Un cordial saludo,
        </div>
		<br/>
        
		
		 <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY:''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:70%;float:right;TEXT-ALIGN: center">
                Conforme:
            </div>
		</div>
		<div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>
       
        

        <p >
            <span><img width="2.3cm" height="2.0cm" src="file:///{0}" /></span>~imagenFirma||
        </p>


		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
          Sus datos personales incluidos en el curriculum remitido, asi como los puestos de manifiesto durante el proceso de seleccion
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, núm. 52. 28050 Madrid, y serán tratados
                con la finalidad de gestionar el proceso de selección, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compañias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gestión de los procesos de selección, sus datos podrán ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la información facilitada en nuestra página web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en países no miembros de la Unión Europea. Ayúdenos a mantener dichos datos actualizados comunicándonos cualquier
                modificación que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificación, cancelación u
                oposición, deberá dirigirse por escrito al Departamento de Selección de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la dirección arriba indicada.
				<br/>
                *La Compañía podrá ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la página web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis México S. de R.L, Everis BPO México S. de R.L, Everis Panamá INC, Everis Perú SAC, Everis BPO Perú SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South África), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Aragón S.L.U, Everis Servicios Energéticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundación Everis.
            
          </div>
		
    </div>

    


    <p>
        <span><img width="794" height="160" src="file:///{0}" /></span>~LogoCabecera|
    </p>


    <div style="padding-left:3cm;padding-right:3cm">
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b>CONDICIONES DE LA OFERTA a </b>{0}~NombreCandidato|
        </div>
		<br/>
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          <b><u>POSICIÓN OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          <b><u>RELACIÓN CONTRACTUAL </u>: </b>  Contrato Indefinido, con un período de prueba de {0} meses, sujeto al Convenio Colectivo Nacional de 
		  Empresas Consultoras.~PeriodoPrueba|
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		<br/>
        
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;padding-left:1cm;">
           <b>Retribución:  </b> La <b>retribución bruta anual </b>será de {0} € y se desglosa según el siguiente
		criterio:~SalarioBruto|
			<br /><br />
			
			<b>• Retribución fija:</b> {0} € que se liquidarán en 14 pagas. ~SalarioNeto|
			<br />
			
			<b>• Retribución Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibirás una ayuda comedor por un importe de <b> {0} €</b>~AyudaComedor|
			<br /><br />
			
			<b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y
cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY:''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se hará efectiva en el momento en que nos contactes, teniendo un plazo máximo de vigencia 
		   de 15 días naturales, a partir de la fecha de recepción de la misma.
        </div>
		<br/>

        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACIÓN NECESARIA: </u></b>  Con el fin de agilizar al máximo los trámites necesarios para tu contratación, es importante que nos
                entregues, a la mayor brevedad posible, los datos y documentación que enumeramos a continuación:<br/><br/>
				
				• Una  fotocopia del DNI. <br />
				• Fotocopia documento acreditativo de afiliación a la Seguridad Social.  <br />
				• Podrás acogerte a una reducción fiscal por <b>“movilidad geográfica”</b> si estás desempleado e
                inscrito en la oficina de empleo, y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que 
				el nuevo puesto de trabajo exija el cambio de dicha residencia.  <br />
				 En este caso, debes aportar los siguientes documentos: <b>Tarjeta de demandante de empleo </b>y <b>Certificado de dicho organismo, </b>que acredite
				 la vigencia de la tarjeta por encontrarse en situación de desempleo y estar expedidos en tu<b> lugar de origen. </b>  <br />
				• Fotocopia de la Vida Laboral.  <br />
				• Fotocopia del título o en su defecto fotocopia del resguardo de pago de tasas para la
				expedición del título y de todas aquellas certificaciones oficiales (ej. CCNA. CCNP, etc.)  <br />
				• Carta Oferta firmada (las dos hojas donde se indica tu nombre y apellidos) <br />
				• En el caso de que tengas reconocida una discapacidad, <b> Certificado de discapacidad </b>emitido por el organismo oficial correspondiente.<br />
				<br />
				<b> *El día de la incorporación es necesario aportar: datos bancarios, fotocopia del D.N.I. (para
				el trámite de la solicitud de la tarjeta AMEX) y en caso de que te acojas a la reducción por
				movilidad geográfica: Original de la Demanda de Empleo y Certificado del SEPE. </b>
        </div>
		<br/>
 

    </div>



    <p>
        <span><img width="794" height="160" src="file:///{0}" /></span>~LogoCabecera|
    </p>


    <div style="padding-left:3cm;padding-right:3cm">

        <p class="MsoNormal" style=''text-align:justify''>
            <span style=''font-family:"Arial","sans-serif"''>&nbsp;</span>
        </p>
        <p class="MsoNormal" style=''text-align:justify''>
            <span style=''font-family:"Arial","sans-serif"''>&nbsp;</span>
        </p>
        <p class="MsoNormal" style=''text-align:justify''>
            <span style=''font-family:"Arial","sans-serif"''>&nbsp;</span>
        </p>

		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           <b><u>TRÁMITES DE INCORPORACIÓN: </u></b>  
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  La documentación puede ser enviada por<b> correo</b>:<a href="mailto:{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0} </span></b></a>
			o a través de <b> fax</b> al <b> nº: {1} </b> (a la atención del área Gestión de Contratación).
			~MailTo~Fax|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Cualquier duda relativa sobre la documentación a aportar puedes localizarnos vía e-mail al correo anteriormente indicado o vía 
			telefónica:<b> {0}</b> (Departamento de contratación) ~Telefono|
        </div>
		<br/>
         
        

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Para cualquier duda que pudieras tener sobre las condiciones de esta oferta,concretar el día de la incorporación en las fechas establecidas 
			por la empresa y cualquier otra cuestión estamos disponibles vía telefónica: {0} ( Departamento de Selección )~Atencion|
        </div>
		<br/>


        <br/>
        <br/>
        <br/>
        <br/>

		
         <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:70%;float:right;TEXT-ALIGN: center">
                Conforme:
            </div>
		</div>
		<div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>




        <p>
            <span><img width="2.3cm" height="2.03cm" src="file:///{0}" /></span>~imagenFirma||
        </p>




    </div>



</div>






</body>
</html>
	',4,'2016-04-04 00:00:00.000',1,N'CartaOferta',2)   
			 
			 

 
 

--AvisoEntrevistaEntrevistador Sevilla
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avda. Americo Vespucio, 5.2º.C
Edificio Cartuja'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'41092 Sevilla'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Telf:+34 95 498 97 10
Fax:+34 95 498 97 11'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting Sevilla'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=98 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 --AvisoEntrevistaCandidato Sevilla
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'RRHH Everis. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avda. Americo Vespucio, 5.2º.C
Edificio Cartuja'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'41092 Sevilla'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Telf:+34 95 498 97 10
Fax:+34 95 498 97 11'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting Sevilla'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=98 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 --plantilla CorreoDescartado Sevilla
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Comunicación resultado proceso de selección'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avda. Americo Vespucio, 5.2º.C
Edificio Cartuja'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'41092 Sevilla'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Telf:+34 95 498 97 10
Fax:+34 95 498 97 11'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting Sevilla'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
  
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=98 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 --variables correo CorreoBacklog sevilla
	
	 

	INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Comunicación resultado proceso de selección'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avda. Americo Vespucio, 5.2º.C
Edificio Cartuja'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'41092 Sevilla'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Telf:+34 95 498 97 10
Fax:+34 95 498 97 11'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting Sevilla'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=98 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 --carta oferta sevilla

INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'AtencionTelefonica',4,N'2016-04-04 00:00:00.000',	1,  N'María José Cristino / Carmen Ramiro'
		   )

 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'AyudaComedor',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'CargoEntregaCarta',4,N'2016-04-04 00:00:00.000',	1,  N'Socio'
		   )
		   

INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'Fax',4,N'2016-04-04 00:00:00.000',	1,  N''
		   )
 
 
  
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avda. Americo Vespucio, 5.2º.C
Edificio Cartuja'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'41092 Sevilla'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Telf:+34 95 498 97 10
Fax:+34 95 498 97 11'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting Sevilla'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'MailTo',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'NombreEntregaCarta',4,N'2016-04-04 00:00:00.000',	1,  N'Juan Antonio Garay'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=98 )),
			N'Telefono',4,N'2016-04-04 00:00:00.000',	1,  N'95 498 97 10'
		   )
 

 --AvisoEntrevistaEntrevistador Alicante
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=2 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 --AvisoEntrevistaCandidato Alicante
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'RRHH Everis. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=2 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 --CorreoDescartado Alicante
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Comunicación resultado proceso de selección'
		   )
 
 
  
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1 AND Centro=2 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
  
  
 		--CorreoBacklog Alicante
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Candidatura Standby'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1 AND Centro=2 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
   --CartaOferta Alicante
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'AtencionTelefonica',4,N'2016-04-04 00:00:00.000',	1,  N'965 146 920'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'AyudaComedor',4,N'2016-04-04 00:00:00.000',	1,  N'944,00'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'CargoEntregaCarta',4,N'2016-04-04 00:00:00.000',	1,  N'Socio'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'Fax',4,N'2016-04-04 00:00:00.000',	1,  N'91 749 02 02'
		   )
		   
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
   INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'MailTo',4,N'2016-04-04 00:00:00.000',	1,  N'Spain.Personal.Candidate@everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'NombreEntregaCarta',4,N'2016-04-04 00:00:00.000',	1,  N'Juan Antonio Garay'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CartaOferta'  AND  Activo = 1 AND Centro=2 )),
			N'Telefono',4,N'2016-04-04 00:00:00.000',	1,  N'91 749 06 57 /54'
		   )
 
 
 
 --AvisoEntrevistaEntrevistador Murcia
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=96 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 --AvisoEntrevistaCandidato Murcia
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'RRHH Everis. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=96 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 --AvisoEntrevistaEntrevistador Tucuman
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=99 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 --AvisoEntrevistaCandidato Tucuman
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'RRHH Everis. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=99 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 
 --AvisoEntrevistaEntrevistador Temuco
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=101 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 --AvisoEntrevistaCandidato Temuco
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'RRHH Everis. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=101 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 --AvisoEntrevistaEntrevistador Uberlandia
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'Recruiting. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1 AND Centro=103 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 --AvisoEntrevistaCandidato Uberlandia
INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'Asunto',4,N'2016-04-04 00:00:00.000',	1,  N'RRHH Everis. Aviso de entrevista programada'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'FechaEntrevista',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'imagenFirma',4,N'2016-04-04 00:00:00.000',	1,  N'logo_everis.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LineaDireccion',4,N'2016-04-04 00:00:00.000',	1,  N'Avenida Oscar Esplá nº37 2ª planta'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LineaEmail',4,N'2016-04-04 00:00:00.000',	1,  N'alicante@everis.com'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LineaProvincia',4,N'2016-04-04 00:00:00.000',	1,  N'03007 Alicante'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LineaTelefono',4,N'2016-04-04 00:00:00.000',	1,  N'Tel: +34 965 146 920
Ext: 113267'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LineaTituloPie',4,N'2016-04-04 00:00:00.000',	1,  N'People Alicante'
		   )
 
  INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LineaWeb',4,N'2016-04-04 00:00:00.000',	1,  N'www.everis.com'
		   )
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
          ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'LogoCabecera',4,N'2016-04-04 00:00:00.000',	1,  N'CabeceraPlantillaCorreo.png'
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'NombreCandidato',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'NombreEntrevistador',4,N'2016-04-04 00:00:00.000',	1,  null
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'Remitente',4,N'2016-04-04 00:00:00.000',	1,  @remitente
		   )
 
 
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1 AND Centro=103 )),
			N'TipoEntrevista',4,N'2016-04-04 00:00:00.000',	1,  NULL
		   )
 
 
 