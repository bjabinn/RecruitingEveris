USE [EVERISRECRUITING]
GO

DECLARE @remitente varchar(100)
SET @remitente = N'alejandro.garcia.pastor@everis.com'


 INSERT [dbo].[CorreoPlantilla]
		   ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[NombrePlantilla])
 
  VALUES ( 
   '<html><head> <title>Carta Oferta</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width=?"94" height="160" src="{0}" /></span>~LogoCabecera|
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
	   
        <p >
            <span><img width="2.3cm" height="2.0cm" src="{0}" /></span>~imagenFirma||
        </p>


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
        </div><br/></div></div></body></html>'
		,4,'2016-03-21 00:00:00.000',1,N'CorreoBacklog') 
 


 INSERT [dbo].[CorreoPlantilla]
		   ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[NombrePlantilla])
 
  VALUES ( 
   '
   <html>
<head>
    <title>Carta Oferta</title>
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
		
        <p >
            <span><img width="2.3cm" height="2.0cm" src="{0}" /></span>~imagenFirma||
        </p>
		

		
    </div>
</div>

</body>
</html>
   '
		,4,'2016-03-21 00:00:00.000',1,N'CorreoDescartado') 
 


 INSERT [dbo].[CorreoPlantilla]
		   ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[NombrePlantilla])
 
  VALUES ( 
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
		
         <p >
            <span><img width="2.3cm" height="2.0cm" src="{0}" /></span>~imagenFirma||
        </p>
		
    </div>
</div>

</body>
</html>
  '
,4,'2016-03-21 00:00:00.000',1,N'AvisoEntrevistaCandidato') 
   

INSERT [dbo].[CorreoPlantilla]
		   ([TextoPlantilla]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[NombrePlantilla])
 
  VALUES ( 
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
				Nos ponemos en contacto contigo para recordarte que el {0} tienes pendiente una {1}
				en nuestras oficinas con el candidato {2}.
				
        </div>~FechaEntrevista~TipoEntrevista~NombreCandidato|
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por tu tiempo.
        </div>
		<br/>
	 
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Atentamente,
        </div>
		<br/>
		
         <p >
            <span><img width="2.3cm" height="2.0cm" src="{0}" /></span>~imagenFirma||
        </p>
		
    </div>
</div>

</body>
</html>
    '
,4,'2016-03-21 00:00:00.000',1,N'AvisoEntrevistaEntrevistador') 



--variables para la plantilla CorreoBacklog
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1)),
			N'Remitente',4,N'2016-03-21 00:00:00.000',	1,  @remitente
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1)),
			N'Asunto',4,N'2016-03-21 00:00:00.000',	1, N'RRHH everis. Comunicación resultado proceso de selección'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1)),
			N'imagenFirma',4,N'2016-03-21 00:00:00.000',	1, N'FirmaPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1)),
			N'LogoCabecera',4,N'2016-03-21 00:00:00.000',	1, N'CabeceraPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoBacklog'  AND  Activo = 1)),
			N'NombreCandidato',4,N'2016-03-21 00:00:00.000',	1, NULL
		   )
 

--variables para la plantilla CorreoDescartado
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1)),
			N'Remitente',4,N'2016-03-21 00:00:00.000',	1,  @remitente
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1)),
			N'Asunto',4,N'2016-03-21 00:00:00.000',	1,   N'Resultado proceso selección'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1)),
			N'imagenFirma',4,N'2016-03-21 00:00:00.000',	1,   N'FirmaPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'CorreoDescartado'  AND  Activo = 1)),
			N'LogoCabecera',4,N'2016-03-21 00:00:00.000',	1,   N'CabeceraPlantillaCorreo.png'
		   )

--variables para la plantilla de correo de aviso de entrevista al candidato
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1)),
			N'Remitente',4,N'2016-03-21 00:00:00.000',	1,  @remitente
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1)),
			N'Asunto',4,N'2016-03-21 00:00:00.000',	1, N'RRHH everis. Recordatorio entrevista'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1)),
			N'imagenFirma',4,N'2016-03-21 00:00:00.000',	1, N'FirmaPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1)),
			N'LogoCabecera',4,N'2016-03-21 00:00:00.000',	1, N'CabeceraPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1)),
			N'NombreCandidato',4,N'2016-03-21 00:00:00.000',	1, NULL
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaCandidato'  AND  Activo = 1)),
			N'FechaEntrevista',4,N'2016-03-21 00:00:00.000',	1, NULL
		   )
 


 --variables para la plantilla de correo de aviso de entrevista al entrevistador
 INSERT INTO [dbo].[CorreoPlantillaVariable]
           ([PlantillaId]
           ,[NombreVariable]
           ,[UsuarioCreacionId]
           ,[FechaCreacion]
           ,[Activo]
           ,[ValorDefecto])
     VALUES
           (
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'Remitente',4,N'2016-03-21 00:00:00.000',	1,  @remitente
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'Asunto',4,N'2016-03-21 00:00:00.000',	1, N'Recruiting. Aviso de entrevista programada'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'imagenFirma',4,N'2016-03-21 00:00:00.000',	1, N'FirmaPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'LogoCabecera',4,N'2016-03-21 00:00:00.000',	1, N'CabeceraPlantillaCorreo.png'
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'NombreCandidato',4,N'2016-03-21 00:00:00.000',	1, NULL
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'FechaEntrevista',4,N'2016-03-21 00:00:00.000',	1, NULL
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'NombreEntrevistador',4,N'2016-03-21 00:00:00.000',	1, NULL
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
		    (SELECT [PlantillaId] FROM [EVERISRECRUITING].[dbo].[CorreoPlantilla] WHERE (NombrePlantilla = N'AvisoEntrevistaEntrevistador'  AND  Activo = 1)),
			N'TipoEntrevista',4,N'2016-03-21 00:00:00.000',	1, NULL
		   )

go
 


--creacion de nuevos permisos para bitacoras
INSERT [dbo].Permiso ([Nombre], [Descripcion], [Activo]) VALUES (N'Modificar Bitacora', N'Modificar Bitacora', 1)
GO
INSERT [dbo].Permiso ([Nombre], [Descripcion], [Activo]) VALUES (N'Ver Bitacora', N'Ver Bitacora', 1)

GO
INSERT [dbo].Permiso ([Nombre], [Descripcion], [Activo]) VALUES (N'Añadir/Eliminar Bitacora', N'Añadir/Eliminar Bitacora', 1)
GO


--inserccion de nuevos permisos para el rol Administrador
INSERT [dbo].[PermisoRol]
 ([PermisoId], [RolId], [Activo]) VALUES ( (SELECT [PermisoId]  FROM [EVERISRECRUITING].[dbo].[Permiso] where Nombre=N'Modificar Bitacora' and Activo=1),
										  (SELECT [RolId]  FROM [EVERISRECRUITING].[dbo].[Rol]	where [Nombre]=N'Administrador' And Activo=1), 1)
GO

INSERT [dbo].[PermisoRol]
 ([PermisoId], [RolId], [Activo]) VALUES ( (SELECT [PermisoId]  FROM [EVERISRECRUITING].[dbo].[Permiso] where Nombre=N'Ver Bitacora' and Activo=1),
										  (SELECT [RolId]  FROM [EVERISRECRUITING].[dbo].[Rol]	where [Nombre]=N'Administrador' And Activo=1), 1)
GO

INSERT [dbo].[PermisoRol]
 ([PermisoId], [RolId], [Activo]) VALUES ( (SELECT [PermisoId]  FROM [EVERISRECRUITING].[dbo].[Permiso] where Nombre=N'Añadir/Eliminar Bitacora' and Activo=1),
										  (SELECT [RolId]  FROM [EVERISRECRUITING].[dbo].[Rol]	where [Nombre]=N'Administrador' And Activo=1), 1)
GO




--------------------------------TIPOMAESTRO-------------------------------
USE [EverisRecruiting]
GO


USE [EVERISRECRUITING]
GO


INSERT INTO [dbo].[Permiso] ON
GO
INSERT [dbo].Permiso ([Nombre], [Descripcion], [Activo]) VALUES (N'Modificar Bitacora', N'Modificar Bitacora', 1)

GO
INSERT [dbo].Permiso ([Nombre], [Descripcion], [Activo]) VALUES (N'Ver Bitacora', N'Ver Bitacora', 1)


GO
INSERT [dbo].Permiso ([Nombre], [Descripcion], [Activo]) VALUES (N'Añadir/Eliminar Bitacora', N'Añadir/Eliminar Bitacora', 1)



 






SET IDENTITY_INSERT [dbo].[TipoMaestro] ON 

GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (1, N'Categoria', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (2, N'Centro', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (3, N'Estado Candidato', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (4, N'Estado Necesidad', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (5, N'Estado Oferta', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (6, N'Idioma', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (7, N'Incorporacion', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (8, N'Meses Asignacion', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (9, N'Motivo Rechazo', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (10, N'Nivel Idioma', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (11, N'Nivel Tecnologia', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (12, N'Oficina', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (13, N'Sector', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (14, N'Tipo Perfil', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (15, N'Tipo Identificacion', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (16, N'Tipo Medio Contrato', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (17, N'Tipo Tecnologia', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (18, N'Tipo Servicio', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (19, N'Tipo Contratacion', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (20, N'Tipo Prevision', 1)
GO
INSERT [dbo].[TipoMaestro] ([TipoMaestroId], [TipoMaestro], [Activo]) VALUES (21, N'Titulacion', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoMaestro] OFF
GO
SET IDENTITY_INSERT [dbo].[Maestro] ON 

GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (1, 12, N'Madrid', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (2, 2, N'Alicante', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (3, 13, N'Telecom', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (4, 18, N'AM', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (5, 14, N'CT', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (6, 17, N'Aplicación Notes', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (7, 19, N'Contratación', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (8, 20, N'Planificado', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (9, 8, N'Más de 12', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (10, 4, N'Abierta', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (11, 4, N'Cerrada', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (13, 17, N'Arquitectura NACAR', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (14, 5, N'Abierta', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (15, 6, N'Inglés', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (16, 10, N'A1', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (17, 10, N'A2', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (18, 15, N'DNI', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (19, 21, N'Ingeniería Informática', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (20, 3, N'Seleccion', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (22, 11, N'Nivel medio', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (23, 16, N'Telefono', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (25, 1, N'CT-J', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (26, 1, N'CT', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (27, 11, N'Nivel alto', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (29, 14, N'CT-J', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (30, 17, N'BI - Análisis y Reporting', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (31, 17, N'BI - ETL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (32, 17, N'CRM SIEBEL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (33, 17, N'Datapower', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (34, 17, N'Diversos módulos de SAP', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (35, 17, N'Gestor de contenidos (Fatwire/Vignette)', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (36, 17, N'Informática Power Center', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (37, 17, N'Java y J2EE', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (38, 17, N'Lenguaje C', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (39, 17, N'Lenguaje COBOL, RPG', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (40, 17, N'Natural Adabas', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (41, 17, N'PHP', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (42, 17, N'PL/I', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (43, 17, N'PowerBuilder', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (44, 17, N'Ruby', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (45, 17, N'Tecnología Clarify', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (46, 17, N'Tecnología HPS', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (47, 17, N'Tecnología IBM-ESQL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (48, 17, N'Tecnología Microsoft', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (49, 17, N'Tecnología Oracle', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (50, 17, N'Tibco', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (51, 17, N'Vantive', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (52, 6, N'Francés', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (53, 15, N'Pasaporte', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (54, 14, N'CT-S', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (55, 14, N'CA', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (56, 19, N'Cambio Interno', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (57, 16, N'Email', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (58, 6, N'Español', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (59, 10, N'Upper A2', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (60, 11, N'Nivel bajo', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (61, 21, N'Ingeniería Técnica Informática', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (62, 21, N'Ingeniería Telecomunicaciones', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (63, 21, N'Ingeniería Técnica Telecomunicaciones', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (64, 21, N'Licenciaturas(Matemáticas, Física)', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (65, 14, N'CAL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (66, 14, N'CE', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (67, 14, N'CCL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (68, 1, N'CT-S', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (69, 1, N'CA', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (70, 1, N'CA-S', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (71, 1, N'CAL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (72, 1, N'CAL-S', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (73, 1, N'CE', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (74, 1, N'CCL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (76, 1, N'CCL-S', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (77, 13, N'Banca', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (78, 13, N'AAPP', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (79, 13, N'Industria', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (80, 13, N'Utilities', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (81, 13, N'Seguros', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (82, 13, N'Varios', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (83, 12, N'Barcelona', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (84, 12, N'Sevilla', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (85, 12, N'Bruxelles', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (86, 12, N'Valencia', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (87, 12, N'Bilbao', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (88, 12, N'Santiago de Chile', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (90, 12, N'Sao Paulo', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (91, 12, N'Buenos Aires', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (92, 12, N'México', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (93, 12, N'Perú', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (94, 12, N'UK', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (95, 12, N'USA', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (96, 2, N'Murcia', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (97, 9, N'Oferta económica insuficiente', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (98, 2, N'Sevilla', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (99, 2, N'Tucumán', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (101, 2, N'Temuco', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (102, 9, N'Funciones ofrecidas inadecuadas', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (103, 2, N'Uberlandia', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (104, 14, N'CLL', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (105, 14, N'ESC', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (106, 14, N'GE', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (107, 14, N'Otros', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (109, 8, N'Menos de 3', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (110, 8, N'Entre 3 y 6', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (111, 8, N'Entre 6 y 12', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (112, 7, N'Inmediata', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (113, 7, N'15 días laborables', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (114, 7, N'15 días naturales', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (115, 7, N'Otros', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (116, 21, N'Otras Licenciaturas', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (117, 21, N'Otras Ingenierías', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (118, 21, N'Ciclo Formativo Grado Superior (CFGS)', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (120, 21, N'FP Informática', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (121, 21, N'Otras', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (123, 21, N'Grado Informática', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (125, 10, N'Low B1', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (126, 10, N'B1', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (127, 10, N'Upper B1', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (128, 10, N'Low B2', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (129, 10, N'B2', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (130, 10, N'Upper B2', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (131, 10, N'C1', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (133, 10, N'C2', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (134, 5, N'Cerrada', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (135, 20, N'Confirmado', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (136, 20, N'Cancelado', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (137, 18, N'SWF', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (138, 18, N'QA', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (139, 18, N'DEV', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (140, 12, N'Londres', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (141, 12, N'Washington', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (142, 12, N'A Coruña', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (143, 17, N'Otros', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (144, 17, N'Testing', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (145, 17, N'Maquetación(HTML+CSS)', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (146, 14, N'CAL-S', 1)
GO
INSERT [dbo].[Maestro] ([MaestroId], [TipoMaestroId], [Maestro], [Activo]) VALUES (147, 14, N'CA-S', 1)
GO
SET IDENTITY_INSERT [dbo].[Maestro] OFF
GO

--------------------------------------------------------------------------

---------------------------------------------------------USUARIOS----------------------------------------------------------
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (4, N'Alejandro Garcia Pastor', 1, N'ale@gmail.com', N'Recruiting', N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (6, N'Daniel Martinez Piñero', 1, NULL, NULL, N'das')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (9, N'Emilio Escobar Reyero', 1, NULL, NULL, N'emilio')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (11, N'Francisco Javier Fernandez Gonzalez', 1, NULL, NULL, N'Franq')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (12, N'Francisco José Cabello Castro', 1, NULL, NULL, N'dasdas')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (13, N'Ignacio Guajardo Fajardo Caballos', 1, NULL, NULL, N'dasdas')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (15, N'Jesús Manuel Martín Vázquez', 1, NULL, NULL, N'dasdas')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (16, N'Jorge Oviedo Garcia', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (17, N'Jorge Rodriguez Chacon', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (18, N'Jose Antonio Ramiro Bonet', 1, NULL, NULL, N'sadas')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (19, N'José María Díaz Moya', 1, NULL, NULL, N'sdadsa')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (20, N'José María Fernández Varela', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (21, N'Juan Antonio Galvez Jimenez', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (22, N'Juan Jose Sanchez Romero', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (23, N'Manuel Francisco Cardenas Blanco', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (24, N'Patricio Muñoz Palomino', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (25, N'Pedro Luis Díaz Montilla', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (26, N'Roberto Fuentes González', 1, NULL, NULL, N'')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (27, N'Sancho Sancho Canela', 1, NULL, NULL, N'dasdas')
GO
INSERT [dbo].[Usuario] ([UsuarioId], [Usuario], [Activo], [Email], [Aplicacion], [Username]) VALUES (28, N'Sergio manuel Jesus Martinez', 1, NULL, NULL, N'')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO

----------------------------------------------------------------------------------------------------------------------------


--------------------------------------------------CANDIDATO-->Metemos un candidato por defecto ---------------------------------------------------------
GO
SET IDENTITY_INSERT [dbo].[Candidato] ON 
GO
INSERT [dbo].[Candidato] ([CandidatoId], [Nombre], [Apellidos], [TipoIdentificacionId], [SalarioDeseado], [DisponibilidadViaje], [CambioResidencia], [TitulacionId], [DetalleTitulacion], [EstadoCandidatoId], [UsuarioCreacionId], [UsuarioModificacionId], [FechaCreacion], [FechaModificacion], [Activo], [FechaNacimiento], [NumeroIdentificacion]) VALUES (1108, N'Jose', N'Gonzalez Gomez', 18, CAST(15000.00 AS Decimal(18, 2)), 0, 0, 61, N'Universidad Pablo de Olavide.', 20, 1, 1, CAST(0x0000A4A600AC8359 AS DateTime), CAST(0x0000A4A600E5C9A0 AS DateTime), 0, NULL, N'44054133A')
GO
SET IDENTITY_INSERT [dbo].[Candidato] OFF
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------ROL y USUARIO ROL con permisos de Administrador para Alejandro---------------------------------------
SET IDENTITY_INSERT [dbo].[Permiso] ON 

GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (1, N'Añadir/Eliminar Candidatura', N'Añadir/Eliminar Candidatura', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (2, N'Modificar Candidatura', N'Modificar Candidatura', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (3, N'Ver Candidatura', N'Ver Candidatura', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (4, N'Añadir/Eliminar Necesidad', N'Añadir/Eliminar Necesidad', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (5, N'Modificar Necesidad', N'Modificar Necesidad', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (6, N'Ver Necesidad', N'Ver Necesidad', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (7, N'Añadir/Eliminar Oferta', N'Añadir/Eliminar Oferta', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (8, N'Modificar Oferta', N'Modificar Oferta', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (9, N'Ver Oferta', N'Ver Oferta', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (11, N'Añadir/Eliminar Candidato', N'Añadir/Eliminar Candidato', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (12, N'Modificar Candidato', N'Modificar Candidato', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (13, N'Ver Candidato', N'Ver Candidato', 1)
GO
INSERT [dbo].[Permiso] ([PermisoId], [Nombre], [Descripcion], [Activo]) VALUES (14, N'Administrar Usuarios/Roles', N'Administrar Usuarios/Roles', 1)
GO
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([RolId], [Nombre], [Descripcion], [Activo]) VALUES (1, N'Administrador', N'Administrador', 1)
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
INSERT [dbo].[UsuarioRol] ([UsuarioId], [RolId], [Activo]) VALUES (4, 1, 0)
GO


INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (1, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (2, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (3, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (4, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (5, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (6, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (7, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (8, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (9, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (10, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (11, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (12, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (13, 1, 0)
GO
INSERT [dbo].[PermisoRol] ([PermisoId], [RolId], [Activo]) VALUES (14, 1, 0)
GO

----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
GO
SET IDENTITY_INSERT [dbo].[TipoEtapaCandidatura] ON 

GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (1, N'Filtrado', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (2, N'Agendar Primera Entrevista', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (3, N'Agendar Segunda Entrevista', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (4, N'Agendar Carta Oferta', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (5, N'Completar Primera Entrevista', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (6, N'Completar Segunda Entrevista', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (7, N'Completar Carta Oferta', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (8, N'Entrega Carta Oferta', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (11, N'Inicio', 1)
GO
INSERT [dbo].[TipoEtapaCandidatura] ([TipoEtapaCandidaturaId], [EtapaCandidatura], [Activo]) VALUES (12, N'Fin', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoEtapaCandidatura] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoDecision] ON 

GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (1, N'Supera filtrado', 1, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (2, N'No supera filtrado', 1, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (3, N'Sin decisión', 2, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (4, N'Sin decisión', 3, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (5, N'Sin decisión', 4, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (6, N'Supera primera entrevista', 5, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (7, N'No supera primera entrevista', 5, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (8, N'Supera segunda entrevista', 6, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (10, N'No supera segunda entrevista', 6, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (11, N'Sin decisión', 7, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (12, N'Acepta carta oferta', 8, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (13, N'No acepta carta oferta', 8, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (14, N'Sin decisión', 11, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (15, N'Sin decision. Reagendar entrevista1', 5, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (16, N'Sin decision. Reagendar entrevista2', 6, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (17, N'Sin decision. Reagendar cartaoferta', 8, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (20, N'Pausar en filtrado. Manda a CVBBDD', 11, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (21, N'Pausar en primera entrevista. Manda a Backlog primera', 2, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (22, N'Pausar en completar primera entrevista. Manda a Backlog primera', 3, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (23, N'Pausar en segunda entrevista. Manda a Backlog', 11, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (24, N'Pausar en completar segunda entrevista. Manda a Backlog', 4, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (25, N'Reanudar desde CVBBDD', 2, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (27, N'Reanudar desde Backlog primera entrevista', 3, 1)
GO
INSERT [dbo].[TipoDecision] ([TipoDecisionId], [Decision], [TipoEtapaCandidaturaId], [Activo]) VALUES (28, N'Reanudar desde Backlog segunda entrevista', 4, 1)
GO
SET IDENTITY_INSERT [dbo].[TipoDecision] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoEstadoCandidatura] ON 

GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (1, N'Inicio', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (2, N'2ª Entrevista', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (3, N'Backlog', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (4, N'Carta Oferta', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (5, N'Contratado', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (6, N'CV en BBDD', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (7, N'Descartado', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (8, N'Entrevista', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (9, N'Rechaza', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (10, N'Renuncia', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (11, N'Pendiente filtrado', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (12, N'Backlog 1ª Entrevista', 1)
GO
INSERT [dbo].[TipoEstadoCandidatura] ([TipoEstadoCandidaturaId], [EstadoCandidatura], [Activo]) VALUES (13, N'KO Oferta', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoEstadoCandidatura] OFF
GO
SET IDENTITY_INSERT [dbo].[RelacionEtapa] ON 

GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (3, 11, 1, 14, 1, 1, 1, N'Datos básicos->FiltradoCV->PendienteFiltrado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (5, 11, 11, 14, 6, 1, 1, N'(Error)Datos básicos->FiltradoCV->BacklogCV')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (7, 11, 11, 14, 7, 1, 1, N'DatosBasicos->DatosBasicos->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (8, 11, 11, 14, 10, 1, 1, N'DatosBasicos->DatosBasico->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (9, 1, 2, 1, 8, 1, 1, N'FiltradoCV->Agendar1->Entrevista1')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (10, 1, 1, 2, 7, 1, 1, N'FiltradoCV->FiltradoCV->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (11, 1, 1, 1, 10, 1, 1, N'FiltradoCV->FiltradoCV->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (12, 1, 1, 1, 13, 1, 1, N'FIltradoCV->FiltradoCV->KO Oferta')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (13, 2, 5, 3, 8, 1, 8, N'Agendar1->Completar1')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (15, 11, 11, 14, 11, 1, 6, N'DatosBasicos->DatosBasicos->Reanudar')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (16, 1, 1, 1, 1, 1, 13, N'FiltradoCVBacklog->FiltradoCV->Reanudar')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (17, 2, 2, 3, 10, 1, 8, N'Agendar1->Agendar1->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (18, 2, 2, 3, 9, 1, 8, N'Agendar1->Agendar1->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (19, 2, 2, 3, 12, 1, 8, N'Agendar1->Agendar1->Backlog')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (20, 2, 2, 3, 8, 1, 12, N'Agendar1Backlog->Agendar1->Reanudar')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (21, 3, 6, 4, 2, 1, 2, N'Agendar2->Completar2')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (22, 3, 3, 4, 10, 1, 2, N'Agendar2->Agendar2->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (23, 3, 3, 4, 9, 1, 2, N'Agendar2->Agendar2->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (25, 3, 3, 4, 3, 1, 2, N'Agendar2->Agendar2->Backlog')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (26, 3, 3, 4, 2, 1, 3, N'Agendar2Backlog->Agendar2->Reanudar')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (27, 4, 8, 5, 4, 1, 4, N'AgendarCO->EntregarCO')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (28, 4, 4, 5, 10, 1, 4, N'AgendarCO->AgendarCO->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (29, 4, 4, 5, 9, 1, 4, N'AgendarCO->AgendarCO->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (30, 5, 3, 6, 2, 1, 8, N'Completar1->Agendar2->Entrevista2')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (31, 5, 5, 7, 7, 1, 8, N'Completar1->Completar1->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (32, 5, 5, 6, 10, 1, 8, N'Completar1->Completar1->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (33, 5, 5, 6, 12, 1, 8, N'Completar1->Completar1->Backlog')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (34, 5, 5, 6, 8, 1, 12, N'Completar1Backlog->Completar1->Reanudar')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (35, 6, 4, 8, 4, 1, 2, N'Completar2->AgendarCO->CO')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (38, 6, 6, 10, 7, 1, 2, N'Completar2->Completar2->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (39, 6, 6, 8, 10, 1, 2, N'Completar2->Completar2->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (40, 6, 6, 8, 3, 1, 2, N'Completar2->Completar2->Backlog')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (41, 6, 6, 8, 2, 1, 3, N'Completar2Backlog->Completar2->Reanudar')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (42, 8, 7, 11, 4, 1, 4, N'EntregarCO -> CompletarCO')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (43, 7, 7, 11, 10, 1, 4, N'CompletarCO->CompletarCO->Renuncia')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (44, 7, 7, 11, 7, 1, 4, N'CompletarCO->CompletarCO->Descartado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (45, 7, 12, 12, 5, 1, 4, N'EntregaCO->Fin->Contratado')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (46, 7, 12, 13, 9, 1, 4, N'EntregaCO->Fin->Rechaza')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (47, 2, 1, 3, 8, 1, 8, N'Agendar1->FiltradoCV')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (48, 3, 5, 4, 2, 1, 2, N'Agendar2->Completar1')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (49, 4, 6, 5, 4, 1, 4, N'AgendarCO->Completar2')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (50, 1, 2, 1, 8, 1, 7, N'FiltradoCV+Descartado->Agendar1->Entrevista1')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (51, 5, 2, 15, 8, 1, 7, N'Reagendar1:Completar1->Agendar1->Entrevista')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (52, 6, 3, 16, 2, 1, 2, N'Reagendar2:Completar2->Agendar2->Entrevista2')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (53, 8, 4, 17, 4, 1, 4, N'ReagendarCO:Entrega->AgendarCO->CO')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (54, 7, 4, 17, 4, 1, 4, N'ReagendarCO:Completar->AgendarCO->CO')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (1054, 2, 2, 20, 6, 1, 8, N'Pausa:Agendar1->Agendar1->CVBBDD')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (1057, 2, 2, 25, 8, 1, 6, N'Reanudar:Agendar1->Agendar1->Entrevista')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (1058, 3, 3, 22, 12, 1, 2, N'Pausa:Completar1->Completar->Backlog1')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (1060, 3, 3, 27, 2, 1, 12, N'Reanudar:Agendar1->Agendar1->BacklogPrimera')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (1061, 4, 4, 24, 3, 1, 4, N'Pausa:Agendar2->Agendar2->Backlog')
GO
INSERT [dbo].[RelacionEtapa] ([RelacionEtapaId], [EtapaOrigenId], [EtapaFinId], [TipoDecisionId], [EstadoFinId], [Activo], [EstadoOrigenId], [Descripcion]) VALUES (1062, 4, 4, 28, 4, 1, 3, N'Reanudar:Agendar2->Agendar2->CartaOferta')
GO
SET IDENTITY_INSERT [dbo].[RelacionEtapa] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoMotivoDecision] ON 

GO
INSERT [dbo].[TipoMotivoDecision] ([TipoMotivoDecisionId], [MotivoDecision], [TipoDecisionId], [Activo]) VALUES (1, N'Motivo decision completar primera entrevista', 1, 1)
GO
INSERT [dbo].[TipoMotivoDecision] ([TipoMotivoDecisionId], [MotivoDecision], [TipoDecisionId], [Activo]) VALUES (3, N'Motivo decision completar segunda entrevista', 3, 1)
GO
INSERT [dbo].[TipoMotivoDecision] ([TipoMotivoDecisionId], [MotivoDecision], [TipoDecisionId], [Activo]) VALUES (4, N'Motivo decision completar carta oferta', 5, 1)
GO
SET IDENTITY_INSERT [dbo].[TipoMotivoDecision] OFF
GO
SET IDENTITY_INSERT [dbo].[RelacionVistaEtapa] ON 

GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (1, 11, N'DatosBasicos', 1, 1)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (3, 2, N'AgendarPrimeraEntrevista', 1, 8)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (5, 3, N'AgendarSegundaEntrevista', 1, 2)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (8, 5, N'CompletarPrimeraEntrevista', 1, 8)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (10, 6, N'CompletarSegundaEntrevista', 1, 2)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (11, 7, N'CompletarCartaOferta', 1, 4)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (12, 8, N'EntregaCartaOferta', 1, 4)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (13, 4, N'AgendarCartaOferta', 1, 4)
GO
INSERT [dbo].[RelacionVistaEtapa] ([RelacionVistaEtapaId], [EtapaId], [VistaMostrar], [Activo], [EstadoId]) VALUES (14, 1, N'FiltradoCv', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[RelacionVistaEtapa] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoEntrevista] ON 

GO
INSERT [dbo].[TipoEntrevista] ([TipoEntrevistaId], [TipoEntrevista], [Activo]) VALUES (1, N'Primera Entrevista', 1)
GO
INSERT [dbo].[TipoEntrevista] ([TipoEntrevistaId], [TipoEntrevista], [Activo]) VALUES (2, N'Segunda Entrevista', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoEntrevista] OFF

------------------------------------------------------------------------------------------------------------------------------------------------------------


---------------------------------CLIENTE Y PROYECTO--------------------------------------------------------------------------

GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (1, N'Administración electrónica', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (2, N'AESA', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (3, N'Banco Popular', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (4, N'BCA', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (5, N'BID', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (6, N'Cepsa', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (7, N'DG REGIO', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (8, N'ehCOS', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (9, N'Enagás', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (10, N'Endesa', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (11, N'EPO', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (12, N'Everis', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (13, N'Fundación Tripartita para la Formación en el Empleo', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (15, N'GAS NATURAL FENOSA', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (16, N'Iberdrola', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (17, N'Inditex', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (18, N'ISBAN', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (19, N'LIFERAY', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (20, N'Ministerio de Trabajo de Colombia', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (21, N'Mutua Madrileña', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (22, N'Randstad', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (23, N'Repsol', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (24, N'Serviabertis', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (25, N'Servihabitat', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (26, N'Tesco', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (27, N'Universidad de Navarra', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (29, N'AXA', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (30, N'Correos', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (31, N'AlCampo', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (32, N'Sanitas', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (33, N'DIA', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (34, N'Bergé', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (36, N'A1 Telekom Austría', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (37, N'Gobierno de Andorra', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (38, N'IAM (Ayuntamiento de Madrid)', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (39, N'Axencia para a Modernización Tecnolóxica de Galicia', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (40, N'Varios', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (41, N'T-Mobile', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (42, N'Telekom Poland', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (43, N'Reale', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (44, N'TechData', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (45, N'CALRI', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (46, N'EJIE', 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [Activo]) VALUES (47, N'Petronor', 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Proyecto] ON 

GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (1, N'Intranet Santander', 1, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (3, N'Triton Repsol', 23, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (4, N'Aplicaciones Internas', 23, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (5, N'Gama', 23, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (6, N'BCA', 4, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (59, N'AESA Project', 2, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (60, N'Banco Popular Project', 3, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (62, N'BID Project', 5, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (63, N'Cepsa Project', 6, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (64, N'DG REGIO Project', 7, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (65, N'ehCOS Project', 8, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (66, N'Enagás Project', 9, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (67, N'Endesa Project', 10, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (68, N'EPO Project', 11, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (69, N'Everis Project', 12, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (70, N'Fundación Tripartita para la Formación en el Empleo Project', 13, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (71, N'GAS NATURAL FENOSA Project', 15, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (72, N'Iberdrola Project', 16, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (73, N'Inditex Project', 17, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (74, N'ISBAN Project', 18, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (75, N'LIFERAY Project', 19, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (76, N'Ministerio de Trabajo de Colombia Project', 20, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (77, N'Mutua Madrileña Project', 21, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (78, N'Randstad Project', 22, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (80, N'Serviabertis Project', 24, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (81, N'Servihabitat Project', 25, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (82, N'Tesco Project', 26, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (83, N'Universidad de Navarra Project', 27, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (89, N'ABAP-HR', 6, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (91, N'AXA', 29, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (92, N'Correos', 30, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (93, N'AlCampo', 31, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (94, N'Sanitas', 32, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (95, N'Repsol Project', 23, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (96, N'Implatación Nueva Intranet', 33, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (97, N'Bergé', 34, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (100, N'A1 Telekom Austría', 36, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (101, N'Gobierno Electrónico de Andalucía', 1, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (102, N'Implantación IRPF', 37, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (104, N'PLATEA2', 38, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (105, N'Servicios eAdmin AMTEGA', 39, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (106, N'Varios', 40, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (108, N'T-Mobile', 41, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (109, N'Telekom Poland', 42, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (110, N'Reale', 43, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (111, N'TechData', 44, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (112, N'APM CALRI', 45, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (113, N'EJIE', 46, 1)
GO
INSERT [dbo].[Proyecto] ([ProyectoId], [Nombre], [ClienteId], [Activo]) VALUES (114, N'AM Petronor', 47, 1)
GO
SET IDENTITY_INSERT [dbo].[Proyecto] OFF
GO

------------------------------------------------------------------------------------------------------------------------------

-------------------------------NECESIDADES-----------------------------------------------------------------------------------------

begin tran t1

INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad1',1,98,80,89,139,107,34,7,0,0,135,111,11,'SAP','11/08/2013','04/01/2014','05/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad2',1,98,82,78,4,55,39,7,0,0,135,9,10,'Capacidad de Análisis y programación','11/09/2013','04/02/2014','05/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad3',85,98,78,68,4,55,37,56,1,1,135,9,10,'Nivel alto de inglés','11/10/2013','04/03/2014','05/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad4',85,98,78,68,4,5,37,7,1,1,135,9,10,'Nivel alto de inglés','11/11/2013','04/04/2014','05/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad5',1,98,80,66,139,5,37,7,0,0,135,111,10,'Java','11/12/2013','04/05/2014','05/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad6',1,98,80,66,139,5,37,56,0,0,135,111,10,'Java','11/13/2013','04/06/2014','05/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad7',1,98,82,69,139,55,48,7,0,0,135,110,10,'.Net','11/14/2013','04/07/2014','05/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad8',1,98,82,69,139,5,48,56,0,0,135,110,10,'.Net','11/15/2013','04/08/2014','05/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad9',1,98,82,69,139,5,48,7,0,0,135,110,10,'.Net','11/16/2013','04/09/2014','05/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad10',1,98,82,69,139,5,48,7,0,0,135,110,10,'.Net','11/17/2013','04/10/2014','05/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad11',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','11/18/2013','04/11/2014','05/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad12',83,98,80,71,139,5,37,7,0,0,135,111,11,'Java','11/19/2013','04/12/2014','05/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad13',85,98,78,68,4,65,39,56,1,1,135,9,10,'Nivel alto de inglés','11/20/2013','04/13/2014','05/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad14',85,98,78,68,4,65,39,7,1,1,135,9,10,'Nivel alto de inglés','11/21/2013','04/14/2014','05/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad15',85,98,78,68,4,65,37,56,1,1,135,9,10,'Nivel alto de inglés','11/22/2013','04/15/2014','05/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad16',85,98,78,68,4,65,37,7,1,1,135,9,10,'Nivel alto de inglés','11/23/2013','04/16/2014','05/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad17',85,98,78,68,4,55,39,7,1,1,135,9,10,'Nivel alto de inglés','11/24/2013','04/17/2014','05/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad18',85,98,78,68,4,55,37,7,1,1,135,9,10,'Nivel alto de inglés','11/25/2013','04/18/2014','05/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad19',85,98,78,68,4,55,37,7,1,1,135,9,10,'Nivel alto de inglés','11/26/2013','04/19/2014','05/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad20',85,98,78,68,4,55,39,7,1,1,135,9,10,'Nivel alto de inglés','11/27/2013','04/20/2014','05/31/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad21',1,98,77,75,139,5,37,7,0,0,135,111,10,'Liferay','11/28/2013','04/21/2014','06/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad22',1,98,82,69,139,65,48,7,0,0,135,111,10,'.Net','11/29/2013','04/22/2014','06/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad23',1,98,78,70,4,65,48,56,0,0,135,9,10,'.Net','11/30/2013','04/23/2014','06/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad24',1,98,78,70,4,55,48,7,0,0,135,9,10,'.Net','12/01/2013','04/24/2014','06/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad25',1,98,78,70,4,55,49,56,0,0,135,9,10,'PL/SQL, Reports','12/02/2013','04/25/2014','06/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad26',1,98,78,70,4,5,48,7,0,0,135,9,10,'.Net','12/03/2013','04/26/2014','06/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad27',1,98,78,70,4,5,49,56,0,0,135,9,10,'PL/SQL, Reports','12/04/2013','04/27/2014','06/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad28',1,98,82,69,139,5,48,7,0,0,135,111,10,'.Net','12/05/2013','04/28/2014','06/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad29',1,98,82,69,139,5,48,7,0,0,135,111,10,'.Net','12/06/2013','04/29/2014','06/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad30',1,98,78,70,4,55,48,56,0,0,135,9,10,'Sharepoint','12/07/2013','04/30/2014','06/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad31',85,98,78,64,4,55,37,7,0,0,135,9,10,'Nivel alto de inglés','12/08/2013','05/01/2014','06/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad32',1,98,77,60,139,65,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/09/2013','05/02/2014','06/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad33',1,98,77,60,139,65,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/10/2013','05/03/2014','06/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad34',1,98,77,60,139,65,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/11/2013','05/04/2014','06/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad35',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/12/2013','05/05/2014','06/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad36',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/13/2013','05/06/2014','06/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad37',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/14/2013','05/07/2014','06/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad38',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/15/2013','05/08/2014','06/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad39',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/16/2013','05/09/2014','06/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad40',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/17/2013','05/10/2014','06/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad41',1,98,77,60,139,5,39,7,0,0,135,111,10,'Cobol, DB2, JCL','12/18/2013','05/11/2014','06/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad42',1,98,77,60,139,5,39,7,0,0,135,111,11,'Cobol, DB2, JCL','12/19/2013','05/12/2014','06/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad43',1,98,77,60,139,5,39,7,0,0,135,111,10,'Cobol, DB2, JCL','12/20/2013','05/13/2014','06/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad44',1,98,80,71,139,55,37,7,0,0,135,111,10,'Java (Swing)','12/21/2013','05/14/2014','06/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad45',85,98,78,64,4,55,37,7,0,0,135,111,10,'Preferible nivel alto de inglés','12/22/2013','05/15/2014','06/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad46',85,98,78,64,4,5,37,7,0,0,135,111,10,'Preferible nivel alto de inglés','12/23/2013','05/16/2014','06/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad47',85,98,78,64,4,5,37,7,0,0,135,111,10,'Preferible nivel alto de inglés','12/24/2013','05/17/2014','06/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad48',1,98,82,78,4,55,143,7,0,0,135,9,10,'Conocimiento WinDEV','12/25/2013','05/18/2014','06/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad49',1,98,77,75,139,5,37,7,0,0,135,111,11,'Conocimiento Liferay','12/26/2013','05/19/2014','06/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad50',1,98,77,75,139,5,37,7,0,0,135,111,11,'Conocimiento Liferay','12/27/2013','05/20/2014','06/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad51',1,98,77,75,139,5,37,7,0,0,135,111,11,'Conocimiento Liferay','12/28/2013','05/21/2014','07/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad52',1,98,82,73,4,55,37,7,0,0,135,9,10,'Conocimiento Liferay','12/29/2013','05/22/2014','07/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad53',1,98,82,73,4,55,37,56,0,0,135,9,10,'Conocimiento Liferay','12/30/2013','05/23/2014','07/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad54',1,98,80,4,4,5,48,7,0,0,135,9,10,'c#, DSTX','12/31/2013','05/24/2014','07/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad55',140,98,79,82,139,55,48,7,1,1,135,111,10,'.Net','01/01/2014','05/25/2014','07/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad56',140,98,79,82,139,55,48,7,1,1,135,111,10,'.Net','01/02/2014','05/26/2014','07/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad57',140,98,79,82,139,5,48,56,1,1,135,111,10,'.Net','01/03/2014','05/27/2014','07/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad58',87,98,78,83,4,55,37,7,0,0,135,9,10,'Java','01/04/2014','05/28/2014','07/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad59',1,98,82,78,4,55,48,56,0,0,135,9,10,'Conocimiento .NET para trabajar en WinDEV','01/05/2014','05/29/2014','07/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad60',1,98,80,67,4,55,37,7,0,0,135,111,11,'Gestores de contenido (preferentemente Web Center Sites). Deseable Spring.','01/06/2014','05/30/2014','07/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad61',1,98,80,67,4,55,37,7,0,0,135,111,11,'Obligatorio Spring. Deseable Hibernate y CXF.','01/07/2014','05/31/2014','07/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad62',140,98,79,6,139,55,48,56,1,1,135,111,10,'.Net','01/08/2014','06/01/2014','07/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad63',140,98,79,6,139,5,48,56,1,1,135,111,10,'.Net','01/09/2014','06/02/2014','07/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad64',140,98,79,6,139,5,48,7,1,1,135,111,11,'.Net','01/10/2014','06/03/2014','07/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad65',140,98,79,6,139,55,143,56,1,1,135,111,10,'PHP','01/11/2014','06/04/2014','07/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad66',140,98,79,6,139,5,143,56,1,1,135,111,10,'PHP','01/12/2014','06/05/2014','07/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad67',140,98,79,6,139,5,143,7,1,1,135,111,10,'PHP','01/13/2014','06/06/2014','07/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad68',140,98,79,6,139,55,144,7,1,1,135,111,10,'Testing','01/14/2014','06/07/2014','07/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad69',140,98,79,6,139,55,144,7,1,1,135,111,10,'Testing','01/15/2014','06/08/2014','07/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad70',140,98,79,6,139,5,144,7,1,1,135,111,10,'Testing','01/16/2014','06/09/2014','07/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad71',140,98,79,6,139,5,144,7,1,1,135,111,11,'Testing','01/17/2014','06/10/2014','07/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad72',140,98,79,6,139,5,143,7,1,1,135,111,10,'PHP','01/18/2014','06/11/2014','07/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad73',140,98,79,6,139,55,143,56,1,1,135,111,10,'PHP','01/19/2014','06/12/2014','07/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad74',140,98,79,6,139,5,143,7,1,1,135,111,11,'PHP','01/20/2014','06/13/2014','07/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad75',140,98,79,6,139,5,48,7,1,1,135,111,11,'Biztalk (no necesario)','01/21/2014','06/14/2014','07/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad76',140,98,79,6,139,5,48,7,1,1,135,111,11,'Biztalk','01/22/2014','06/15/2014','07/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad77',1,98,80,72,4,5,48,7,0,0,135,110,10,'Sharepoint','01/23/2014','06/16/2014','07/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad78',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','01/24/2014','06/17/2014','07/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad79',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','01/25/2014','06/18/2014','07/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad80',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','01/26/2014','06/19/2014','07/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad81',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','01/27/2014','06/20/2014','07/31/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad82',1,98,80,67,4,5,37,56,0,0,135,111,10,'Java','01/28/2014','06/21/2014','08/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad83',1,98,80,67,4,5,37,56,0,0,135,111,10,'Java','01/29/2014','06/22/2014','08/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad84',1,98,80,67,4,5,37,56,0,0,135,111,10,'Java','01/30/2014','06/23/2014','08/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad85',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','01/31/2014','06/24/2014','08/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad86',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','02/01/2014','06/25/2014','08/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad87',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','02/02/2014','06/26/2014','08/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad88',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java','02/03/2014','06/27/2014','08/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad89',1,98,80,67,4,5,37,56,0,0,135,111,10,'Java','02/04/2014','06/28/2014','08/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad90',1,98,80,67,4,5,37,56,0,0,135,111,10,'Java','02/05/2014','06/29/2014','08/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad91',1,98,77,74,139,5,37,7,0,0,135,111,10,'Conocimiento Java','02/06/2014','06/30/2014','08/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad92',1,98,80,63,139,5,48,56,0,0,135,9,10,'.NET','02/07/2014','07/01/2014','08/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad93',1,98,82,69,139,5,48,7,0,0,135,111,11,'.Net','02/08/2014','07/02/2014','08/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad94',1,98,82,69,139,55,48,56,0,0,135,110,10,'.NET','02/09/2014','07/03/2014','08/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad95',1,98,82,69,139,5,48,56,0,0,135,110,10,'.NET','02/10/2014','07/04/2014','08/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad96',1,98,82,69,139,5,48,56,0,0,135,110,10,'.NET','02/11/2014','07/05/2014','08/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad97',1,98,82,69,139,5,48,56,0,0,135,110,10,'.NET','02/12/2014','07/06/2014','08/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad98',83,98,82,81,139,5,34,7,0,0,135,111,10,'ABAP','02/13/2014','07/07/2014','08/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad99',83,98,82,81,139,5,34,56,0,0,135,111,10,'ABAP','02/14/2014','07/08/2014','08/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad100',83,98,82,81,139,55,34,7,0,0,135,111,10,'ABAP','02/15/2014','07/09/2014','08/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad101',83,98,82,81,139,55,34,56,0,0,135,111,10,'ABAP','02/16/2014','07/10/2014','08/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad102',83,98,82,81,139,5,34,7,0,0,135,111,10,'ABAP','02/17/2014','07/11/2014','08/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad103',83,98,82,81,139,5,34,7,0,0,135,111,10,'ABAP','02/18/2014','07/12/2014','08/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad104',83,98,82,81,139,5,34,7,0,0,135,111,10,'ABAP','02/19/2014','07/13/2014','08/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad105',84,98,78,76,139,65,37,56,0,0,135,111,10,'Java, e-Goveris','02/20/2014','07/14/2014','08/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad106',84,98,78,76,139,5,37,7,0,0,135,111,11,'Java, e-Goveris','02/21/2014','07/15/2014','08/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad107',84,98,78,76,139,5,37,7,0,0,135,111,11,'Java, e-Goveris','02/22/2014','07/16/2014','08/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad108',84,98,78,76,139,5,37,7,0,0,135,111,11,'Java, e-Goveris','02/23/2014','07/17/2014','08/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad109',1,98,81,91,139,55,37,7,0,0,8,111,11,'Conocimiento Liferay','02/24/2014','07/18/2014','08/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad110',1,98,81,91,139,55,37,7,0,0,8,111,11,'Conocimiento Liferay','02/25/2014','07/19/2014','08/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad111',1,98,81,91,139,5,37,7,0,0,8,111,11,'Conocimiento Liferay','02/26/2014','07/20/2014','08/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad112',1,98,82,69,139,5,143,7,0,0,135,111,10,'Conocimiento HTML5 + CSS3','02/27/2014','07/21/2014','08/31/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad113',1,98,79,92,4,5,37,7,0,0,8,111,11,'Conocimiento HTML, CSS y Javascript','02/28/2014','07/22/2014','09/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad114',1,98,82,93,4,55,37,7,0,0,8,111,11,'Conocimiento Liferay','03/01/2014','07/23/2014','09/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad115',1,98,82,93,4,5,37,7,0,0,8,111,11,'Conocimiento Liferay','03/02/2014','07/24/2014','09/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad116',1,98,82,69,139,5,143,7,0,0,8,111,11,'HTML5+CSS3','03/03/2014','07/25/2014','09/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad117',1,98,82,69,139,5,143,7,0,0,8,111,11,'HTML5+CSS3','03/04/2014','07/26/2014','09/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad118',140,98,79,6,139,65,48,7,1,1,135,111,10,'.Net','03/05/2014','07/27/2014','09/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad119',140,98,79,6,139,5,48,56,1,1,135,111,10,'.Net','03/06/2014','07/28/2014','09/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad120',140,98,79,6,139,5,48,56,1,1,135,111,10,'.Net','03/07/2014','07/29/2014','09/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad121',140,98,79,6,139,55,48,7,1,1,8,111,11,'.Net','03/08/2014','07/30/2014','09/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad122',140,98,79,6,139,5,48,7,1,1,8,111,11,'.Net','03/09/2014','07/31/2014','09/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad123',140,98,79,6,139,5,144,7,1,1,8,111,11,'Testing','03/10/2014','08/01/2014','09/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad124',140,98,79,6,139,55,48,7,1,1,135,111,11,'.Net','03/11/2014','08/02/2014','09/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad125',140,98,79,6,139,5,48,7,1,1,8,111,11,'.Net','03/12/2014','08/03/2014','09/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad126',140,98,79,6,139,5,48,7,1,1,135,111,11,'.Net','03/13/2014','08/04/2014','09/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad127',140,98,79,6,139,5,48,7,1,1,135,111,11,'.Net','03/14/2014','08/05/2014','09/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad128',140,98,79,6,139,5,144,7,1,1,8,111,11,'Testing','03/15/2014','08/06/2014','09/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad129',140,98,79,6,139,5,144,7,1,1,8,111,11,'Testing','03/16/2014','08/07/2014','09/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad130',83,98,80,71,139,5,37,56,0,0,135,111,10,'Java','03/17/2014','08/08/2014','09/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad131',83,98,80,71,139,5,37,56,0,0,135,111,10,'Java','03/18/2014','08/09/2014','09/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad132',1,98,81,94,4,5,37,7,0,0,8,111,11,'Oracle WebCenter Sites','03/19/2014','08/10/2014','09/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad133',1,98,80,95,139,5,48,56,0,0,135,111,10,'.Net','03/20/2014','08/11/2014','09/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad134',140,98,79,6,139,5,144,7,1,1,8,111,11,'Testing','03/21/2014','08/12/2014','09/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad135',1,98,80,95,139,5,48,7,0,0,135,111,10,'.Net','03/22/2014','08/13/2014','09/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad136',1,98,80,95,139,5,48,56,0,0,135,111,10,'.Net','03/23/2014','08/14/2014','09/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad137',83,98,80,71,139,5,37,7,0,0,135,111,11,'Java','03/24/2014','08/15/2014','09/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad138',83,98,80,71,139,5,37,7,0,0,135,111,11,'Java','03/25/2014','08/16/2014','09/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad139',1,98,80,95,139,5,48,7,0,0,8,111,11,'.Net','03/26/2014','08/17/2014','09/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad140',1,98,80,95,139,5,48,7,0,0,8,111,11,'.Net','03/27/2014','08/18/2014','09/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad141',1,98,77,60,139,55,37,56,0,0,135,111,10,'BTT','03/28/2014','08/19/2014','09/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad142',83,98,80,71,139,55,37,56,0,0,135,111,10,'Java','03/29/2014','08/20/2014','09/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad143',83,98,80,71,139,5,37,56,0,0,135,111,10,'Java','03/30/2014','08/21/2014','10/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad144',83,98,80,71,139,5,37,56,0,0,135,111,10,'Java','03/31/2014','08/22/2014','10/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad145',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','04/01/2014','08/23/2014','10/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad146',83,98,80,71,4,5,37,7,0,0,135,111,10,'Java','04/02/2014','08/24/2014','10/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad147',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','04/03/2014','08/25/2014','10/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad148',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/04/2014','08/26/2014','10/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad149',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/05/2014','08/27/2014','10/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad150',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/06/2014','08/28/2014','10/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad151',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/07/2014','08/29/2014','10/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad152',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/08/2014','08/30/2014','10/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad153',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/09/2014','08/31/2014','10/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad154',1,98,77,60,139,5,37,56,0,0,135,111,10,'BTT','04/10/2014','09/01/2014','10/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad155',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','04/11/2014','09/02/2014','10/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad156',1,98,82,96,139,5,37,56,0,0,8,111,11,'Liferay','04/12/2014','09/03/2014','10/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad157',83,98,80,71,4,5,37,7,0,0,135,111,10,'Java','04/13/2014','09/04/2014','10/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad158',83,98,80,71,4,5,37,7,0,0,135,111,10,'Java','04/14/2014','09/05/2014','10/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad159',83,98,80,71,4,5,37,7,0,0,135,111,10,'Java','04/15/2014','09/06/2014','10/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad160',83,98,80,71,4,5,37,56,0,0,135,111,10,'Java','04/16/2014','09/07/2014','10/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad161',83,98,80,71,4,29,37,7,0,0,135,111,10,'Java','04/17/2014','09/08/2014','10/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad162',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','04/18/2014','09/09/2014','10/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad163',83,98,80,71,139,29,37,7,0,0,135,111,10,'Java','04/19/2014','09/10/2014','10/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad164',83,98,80,71,139,55,37,7,0,0,135,111,10,'Java','04/20/2014','09/11/2014','10/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad165',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','04/21/2014','09/12/2014','10/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad166',83,98,80,71,139,5,37,56,0,0,135,111,10,'Java','04/22/2014','09/13/2014','10/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad167',85,98,78,68,4,65,144,56,0,0,135,9,10,'Nivel alto de inglés','04/23/2014','09/14/2014','10/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad168',87,98,78,83,4,55,37,7,0,0,8,9,11,'Liferay','04/24/2014','09/15/2014','10/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad169',85,98,78,68,4,55,37,7,1,1,135,9,10,'Nivel alto de inglés','04/25/2014','09/16/2014','10/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad170',85,98,78,68,4,55,39,7,1,1,135,9,10,'Nivel alto de inglés','04/26/2014','09/17/2014','10/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad171',85,98,78,68,4,55,39,7,1,1,135,9,10,'Nivel alto de inglés','04/27/2014','09/18/2014','10/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad172',85,98,78,68,4,5,37,7,1,1,135,9,10,'Nivel alto de inglés','04/28/2014','09/19/2014','10/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad173',85,98,78,68,4,55,39,7,1,1,8,9,11,'Nivel alto de inglés','04/29/2014','09/20/2014','10/31/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad174',85,98,78,68,4,5,144,7,1,1,135,9,10,'Nivel alto de inglés','04/30/2014','09/21/2014','11/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad175',85,98,78,68,4,55,39,7,1,1,8,9,11,'Nivel alto de inglés','05/01/2014','09/22/2014','11/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad176',85,98,78,68,4,5,37,7,1,1,135,9,10,'Nivel alto de inglés','05/02/2014','09/23/2014','11/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad177',85,98,78,68,4,5,37,7,1,1,8,9,11,'Nivel alto de inglés','05/03/2014',null,'11/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad178',1,98,77,60,139,5,37,56,0,0,135,111,10,'BTT','05/04/2014','06/02/2014','11/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad179',1,98,77,74,139,55,48,7,0,0,8,110,11,'VBA','05/05/2014','06/21/2014','11/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad180',1,98,80,63,139,5,48,7,0,0,135,111,10,'.Net','05/06/2014','06/21/2014','11/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad181',1,98,80,63,139,5,48,7,0,0,135,111,10,'.Net','05/07/2014','06/21/2014','11/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad182',1,98,78,92,138,5,37,7,0,0,135,109,11,'Funcional','05/08/2014','06/15/2014','11/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad183',1,98,78,92,138,5,37,7,0,0,135,109,11,'','05/09/2014','06/15/2014','11/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad184',1,98,78,59,139,65,48,7,0,0,8,110,11,'.NET','05/10/2014','07/01/2014','11/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad185',1,98,78,59,139,5,48,7,0,0,8,110,11,'.NET','05/11/2014','07/01/2014','11/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad186',1,98,78,59,139,5,48,7,0,0,8,110,11,'.NET','05/12/2014','07/01/2014','11/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad187',1,98,78,59,139,5,48,7,0,0,8,110,11,'.NET','05/13/2014','07/01/2014','11/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad188',1,98,77,74,139,55,48,7,0,0,8,110,11,'.NET','05/14/2014','06/21/2014','11/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad189',85,98,78,68,4,5,144,7,1,1,135,9,10,'Nivel alto de inglés','05/15/2014','06/16/2014','11/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad190',85,98,78,68,4,5,144,7,1,1,135,9,10,'Nivel alto de inglés','05/16/2014','06/16/2014','11/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad191',85,98,78,68,4,5,144,7,1,1,135,9,10,'Nivel alto de inglés','05/17/2014','06/16/2014','11/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad192',85,98,78,68,4,67,143,7,1,1,135,9,10,'Nivel alto de inglés','05/18/2014','06/30/2014','11/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad193',1,98,80,95,139,5,48,7,0,0,8,111,11,'.Net','05/19/2014','07/01/2014','11/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad194',1,98,80,95,139,5,48,7,0,0,8,111,11,'.Net','05/20/2014','07/01/2014','11/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad195',1,98,80,95,139,5,48,7,0,0,8,111,11,'.Net','05/21/2014','07/01/2014','11/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad196',1,98,82,73,4,5,37,7,0,0,8,111,11,'Conocimiento Java y Liferay','05/22/2014','06/23/2014','11/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad197',1,98,82,97,4,5,37,7,0,0,8,111,11,'Conocimiento Java y Liferay','05/23/2014','06/23/2014','11/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad198',1,98,82,97,4,5,37,7,0,0,8,111,11,'Conocimiento Java y Liferay','05/24/2014','06/23/2014','11/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad199',1,98,3,100,138,5,37,7,0,0,8,111,11,'Perfiles Tibco con nivel de Inglés y deseable Alemán','05/25/2014',null,'11/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad200',1,98,3,108,138,5,37,7,0,0,8,111,11,'Perfiles Tibco con nivel de Inglés y deseable Alemán','05/26/2014',null,'11/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad201',1,98,3,109,138,5,37,7,0,0,8,111,11,'Perfiles Tibco con nivel de Inglés y deseable Alemán','05/27/2014',null,'11/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad202',1,98,81,110,139,55,48,7,0,0,135,111,11,'o        WPF, MVVM (fundamental).
o        WCF (fundamental).
o        Oracle (fundamental).','05/28/2014','06/30/2014','11/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad203',1,98,82,65,138,5,37,56,0,0,135,110,10,'conocimientos de diseño y ejecución de pruebas manuales. Así mismo se valora experiencia en automatización (SAHI, QTP, Sikuli, etc…)','05/29/2014','07/01/2014','11/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad204',140,98,79,82,139,55,48,7,0,0,135,111,10,'.Net','05/30/2014','06/30/2014','12/01/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad205',1,98,80,63,139,5,48,56,0,0,8,111,11,'.Net','05/31/2014','07/02/2014','12/02/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad206',1,98,80,72,4,65,48,56,0,0,135,9,10,'Sharepoint','06/01/2014','06/30/2014','12/03/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad207',1,98,80,72,4,5,48,7,0,0,135,9,10,'Sharepoint','06/02/2014','06/30/2014','12/04/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad208',85,98,78,68,4,5,37,7,0,0,135,9,10,'Nivel alto de inglés','06/03/2014','07/01/2014','12/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad209',83,98,80,71,139,55,37,7,0,0,135,111,11,'Java','06/04/2014','09/01/2014','12/06/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad210',85,98,78,68,4,5,37,7,1,1,8,9,11,'Nivel alto de inglés','06/05/2014','06/30/2014','12/07/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad211',85,98,78,64,4,67,143,7,0,0,135,9,10,'Nivel alto de inglés','06/06/2014','07/15/2014','12/08/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad212',1,98,80,67,4,67,143,7,0,0,135,9,10,'Java','06/07/2014','07/15/2014','12/09/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad213',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','06/08/2014','09/01/2014','12/10/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad214',83,98,80,71,139,5,37,7,0,0,135,111,10,'Java','06/09/2014','09/01/2014','12/11/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad215',1,98,82,69,139,5,48,7,0,0,135,9,11,'.Net','06/10/2014','10/01/2014','12/12/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad216',85,98,78,64,4,55,37,7,0,0,135,9,11,'JAVA. Necesario inglés (mínimo low B2)','06/11/2014','07/01/2014','12/13/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad217',1,98,78,70,4,5,48,56,0,0,135,9,10,'Sharepoint','06/12/2014','09/01/2014','12/14/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad218',1,98,80,63,139,5,48,56,0,0,135,111,11,'.Net','06/13/2014','10/15/2014','12/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad219',83,98,80,71,139,65,37,7,0,0,135,9,10,'Java','06/14/2014','09/01/2014','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad220',83,98,80,71,139,5,37,7,0,0,135,9,11,'Java','06/15/2014','09/01/2014','12/17/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad221',83,98,80,71,139,5,37,7,0,0,135,9,10,'Java','06/16/2014','09/01/2014','12/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad222',83,98,80,71,139,5,37,7,0,0,135,9,10,'Java','06/17/2014','09/01/2014','12/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad223',1,98,77,77,138,5,37,7,0,0,135,9,10,'Java','06/18/2014','07/11/2014','12/20/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad224',1,98,82,65,138,5,37,7,0,0,135,9,10,'Java','06/19/2014','07/14/2014','12/21/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad225',1,98,82,65,138,5,37,56,0,0,135,9,10,'Java','06/20/2014','07/14/2014','12/22/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad226',1,98,77,74,139,55,48,7,0,0,135,9,11,'.NET','06/21/2014','07/28/2014','12/23/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad227',1,98,82,69,139,55,48,7,0,0,135,9,11,'.Net','06/22/2014','09/01/2014','12/24/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad228',85,98,78,68,4,5,37,7,1,1,135,9,11,'JavaScript - JQuery, Steal, JavaScript MVC. Java 1.6 en JBoss 6 – Spring (creo que el 2.4), DWR, AspectJ, ehCache, Testing – Junit, EasyMock y algo de Selenium, PDF generator - Batik, FOP y Stylesheets','06/23/2014','07/15/2014','12/25/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad229',140,98,79,82,139,5,48,7,1,1,135,111,10,'.Net','06/24/2014','07/15/2014','12/26/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad230',85,98,78,68,4,5,37,7,1,1,135,9,11,'JavaScript - JQuery, Steal, JavaScript MVC. Java 1.6 en JBoss 6 – Spring (creo que el 2.4), DWR, AspectJ, ehCache, Testing – Junit, EasyMock y algo de Selenium, PDF generator - Batik, FOP y Stylesheets','06/25/2014','07/15/2014','12/27/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad231',140,98,79,6,139,5,144,7,1,1,135,9,10,'Testing','06/26/2014','09/30/2014','12/28/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad232',83,98,82,106,139,55,34,7,0,0,135,9,11,'ABAP','06/27/2014','09/01/2014','12/29/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad233',85,98,78,68,4,5,39,7,1,1,8,9,11,'Nivel alto de inglés','06/28/2014',null,'12/30/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad234',140,98,79,82,139,5,48,7,1,1,135,111,10,'.Net','06/29/2014','07/28/2014','12/31/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad235',1,98,80,67,4,5,37,7,0,0,135,111,10,'Java. Gestores de contenido (preferentemente Web Center Sites). Deseable Spring','06/30/2014','07/31/2014','01/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad236',1,98,80,95,139,5,48,7,0,0,135,9,10,'.Net','07/01/2014','08/01/2014','01/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad237',1,98,77,60,139,5,37,7,0,0,135,111,10,'BTT','07/02/2014','08/18/2014','01/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad238',1,98,77,60,139,55,37,7,0,0,135,111,10,'BTT','07/03/2014','08/18/2014','01/04/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad239',1,98,77,60,139,55,37,7,0,0,135,111,11,'BTT','07/04/2014','08/18/2014','01/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad240',1,98,80,95,139,5,48,7,0,0,135,9,11,'.Net','07/05/2014','09/01/2014','01/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad241',1,98,80,95,139,5,48,7,0,0,135,9,11,'.Net','07/06/2014','09/01/2014','01/07/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad242',1,98,82,69,139,65,48,7,0,0,135,9,10,'.Net','07/07/2014','09/01/2014','01/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad243',1,98,80,106,4,67,37,7,0,0,135,9,10,'Otros','07/08/2014','09/01/2014','01/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad244',1,98,80,95,139,5,48,7,0,0,135,9,11,'.Net','07/09/2014','10/01/2014','01/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad245',1,98,80,95,139,5,48,7,0,0,135,9,11,'.Net','07/10/2014','10/01/2014','01/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad246',1,98,80,72,4,5,48,7,0,0,135,9,10,'.NET (SHAREPOINT)','07/11/2014','11/01/2014','01/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad247',85,98,78,64,4,5,37,7,0,0,135,9,10,'JAVA. Necesario inglés (mínimo low B2)','07/12/2014','08/04/2014','01/13/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad248',140,98,79,6,139,5,144,7,1,1,135,111,10,'Testing','07/13/2014','09/01/2014','01/14/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad249',140,98,79,82,139,55,48,7,1,1,135,111,11,'.NET (debe ser capaz de comprender propuestas arquitectónicas complejas y plantear soluciones para dichos entornos)','07/14/2014','09/01/2014','01/15/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad250',141,98,77,62,139,55,48,7,0,0,135,111,11,'.NET','07/15/2014','10/10/2014','01/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad251',140,98,79,6,139,5,144,7,1,1,135,111,11,'Testing','07/16/2014','09/01/2014','01/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad252',140,98,79,6,139,55,41,7,0,0,135,111,10,'PHP (mínimo 2 años de experiencia)','07/17/2014','08/29/2014','01/18/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad253',140,98,79,6,139,5,41,7,0,0,135,111,10,'PHP (mínimo 2 años de experiencia)','07/18/2014','09/15/2014','01/19/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad254',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/19/2014','09/15/2014','01/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad255',140,98,79,6,139,65,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/20/2014','10/15/2014','01/21/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad256',140,98,79,6,139,5,41,7,0,0,135,111,10,'PHP (mínimo 2 años de experiencia)','07/21/2014','10/15/2014','01/22/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad257',140,98,79,6,139,55,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/22/2014','10/15/2014','01/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad258',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/23/2014','11/15/2014','01/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad259',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/24/2014','11/15/2014','01/25/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad260',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/25/2014','11/15/2014','01/26/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad261',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/26/2014','12/15/2014','01/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad262',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/27/2014','12/15/2014','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad263',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/28/2014','12/15/2014','01/29/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad264',140,98,79,6,139,5,41,7,0,0,135,111,11,'PHP (mínimo 2 años de experiencia)','07/29/2014','12/15/2014','01/30/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad265',1,98,78,59,139,55,48,7,1,1,135,110,10,'.NET','07/30/2014','10/13/2014','01/31/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad266',1,98,78,59,139,5,48,7,0,0,8,110,11,'.NET','07/31/2014','10/17/2014','02/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad267',1,98,78,59,139,5,48,56,0,0,135,110,10,'.NET','08/01/2014','10/27/2014','02/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad268',1,98,77,60,139,5,37,7,0,0,135,111,11,'BTT','08/02/2014','08/18/2014','02/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad269',141,98,77,62,139,5,48,7,0,0,135,111,10,'.NET','08/03/2014','09/15/2014','02/04/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad270',141,98,77,62,139,5,48,7,0,0,135,111,11,'.NET','08/04/2014','10/10/2014','02/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad271',141,98,77,62,139,55,48,56,0,0,135,111,10,'.NET','08/05/2014','10/10/2014','02/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad272',1,98,80,71,138,5,37,7,0,0,135,9,10,'Automatización (QTP o UFT)','08/06/2014','09/01/2014','02/07/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad273',1,98,80,71,138,55,37,7,0,0,135,9,11,'Automatización (QTP o UFT)','08/07/2014','09/01/2014','02/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad274',85,98,78,68,4,55,37,56,1,1,135,9,10,'JavaScript - JQuery, Steal, JavaScript MVC. Java 1.6 en JBoss 6 – Spring (creo que el 2.4), DWR, AspectJ, ehCache, Testing – Junit, EasyMock y algo de Selenium, PDF generator - Batik, FOP y Stylesheets','08/08/2014','09/15/2014','02/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad275',85,98,78,68,4,5,39,7,1,1,135,9,10,'','08/09/2014','09/15/2014','02/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad276',1,98,80,67,4,5,37,7,0,0,135,111,11,'Java. Gestores de contenido (preferentemente Web Center Sites). Deseable Spring','08/10/2014','09/15/2014','02/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad277',140,98,79,6,139,67,143,56,0,0,135,9,10,'','08/11/2014','10/15/2014','02/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad278',1,98,82,78,4,55,37,7,0,0,135,9,10,'La tecnología utilizada es Windev, nos sirve perfiles java y  .net','08/12/2014','10/01/2014','02/13/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad279',1,98,77,74,4,29,37,56,0,0,135,9,10,'BKS','08/13/2014','10/01/2014','02/14/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad280',1,98,77,74,4,5,37,56,0,0,135,9,10,'BKS','08/14/2014','11/03/2014','02/15/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad281',1,98,82,69,4,5,37,7,0,0,135,9,11,'Java J2EE, con conocimiento en programación de portlets web.(Mínimo 2 años de experiencia)','08/15/2014','10/15/2014','02/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad282',1,98,82,69,4,55,37,7,1,1,135,9,11,'Java J2EE, con conocimiento en programación de portlets web. (Mínimo 3 años de experiencia)','08/16/2014','10/15/2014','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad283',1,98,80,66,139,29,37,56,0,0,135,111,10,'Java','08/17/2014','10/01/2014','02/18/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad284',1,98,82,69,139,5,145,7,0,0,135,9,10,'Conocimiento HTML5 + CSS3','08/18/2014','10/31/2014','02/19/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad285',1,98,82,78,4,55,37,7,0,0,135,9,10,'La tecnología utilizada es Windev, nos sirve perfiles java y  .net','08/19/2014','10/15/2014','02/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad286',1,98,82,78,4,5,37,7,0,0,135,9,10,'La tecnología utilizada es Windev, nos sirve perfiles java y  .net','08/20/2014','10/15/2014','02/21/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad287',1,98,82,78,4,5,37,7,0,0,135,9,11,'La tecnología utilizada es Windev, nos sirve perfiles java y  .net','08/21/2014','10/15/2014','02/22/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad288',1,98,82,78,4,5,37,7,0,0,135,9,11,'La tecnología utilizada es Windev, nos sirve perfiles java y  .net','08/22/2014','10/15/2014','02/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad289',1,98,82,78,4,5,39,56,0,0,135,9,10,'Cobol – AS400','08/23/2014','10/15/2014','02/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad290',1,98,82,75,139,5,37,7,0,0,135,111,10,'Liferay','08/24/2014','10/01/2014','02/25/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad291',1,98,80,63,139,55,48,7,0,0,135,111,10,'.Net','08/25/2014','10/27/2014','02/26/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad292',140,98,79,6,139,55,144,56,0,0,135,111,10,'','08/26/2014','10/15/2014','02/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad293',83,98,82,81,4,5,34,7,0,0,135,111,10,'ABAP','08/27/2014','10/31/2014','02/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad294',83,98,82,81,4,5,34,7,0,0,135,111,11,'ABAP','08/28/2014','10/31/2014','03/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad295',1,98,80,63,139,5,48,7,0,0,135,109,11,'.Net','08/29/2014','10/31/2014','03/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad296',1,98,80,62,139,65,48,56,0,0,135,111,10,'.NEt. Necesario conocimiento en la arquitectura everNet','08/30/2014','11/15/2014','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad297',1,98,80,62,139,5,48,7,0,0,135,111,10,'.NEt. Necesario conocimiento en la arquitectura everNet','08/31/2014','12/01/2014','03/04/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad298',1,98,80,62,139,5,48,56,0,0,135,111,10,'.NEt. Necesario conocimiento en la arquitectura everNet','09/01/2014','12/01/2014','03/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad299',85,98,78,68,4,5,37,7,1,1,135,9,11,'JavaScript - JQuery, Steal, JavaScript MVC. Java 1.6 en JBoss 6 – Spring (creo que el 2.4), DWR, AspectJ, ehCache, Testing – Junit, EasyMock y algo de Selenium, PDF generator - Batik, FOP y Stylesheets','09/02/2014','10/30/2014','03/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad300',1,98,78,59,139,29,48,7,0,0,135,110,10,'.NET','09/03/2014','01/01/2015','03/07/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad301',84,98,82,101,4,65,37,7,0,0,135,111,11,'Java / J2EE','09/04/2014','12/01/2014','03/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad302',84,98,82,101,4,5,37,7,0,0,135,111,11,'Java / J2EE','09/05/2014','12/01/2014','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad303',84,98,82,101,4,5,37,7,0,0,135,111,11,'Java / J2EE','09/06/2014','12/01/2014','03/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad304',1,98,80,63,139,5,48,7,0,0,135,110,11,'.Net','09/07/2014','10/31/2014','03/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad305',83,98,80,71,4,5,37,7,0,0,135,9,11,'Java con experiencia al menos de 3 años.','09/08/2014','10/31/2014','03/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad306',83,98,82,81,4,5,34,7,0,0,135,111,11,'ABAP','09/09/2014','10/31/2014','03/13/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad307',1,98,82,69,139,5,145,7,0,0,135,9,10,'Conocimiento HTML5 + CSS3','09/10/2014','10/31/2014','03/14/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad308',140,98,79,6,139,5,48,56,0,0,135,111,10,'.Net','09/11/2014','11/03/2014','03/15/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad309',1,98,77,74,4,5,37,56,0,0,135,9,10,'BKS','09/12/2014','11/15/2014','03/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad310',1,98,77,74,4,29,37,7,0,0,135,9,11,'BKS','09/13/2014','11/15/2014','03/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad311',141,98,77,62,139,55,48,7,0,0,135,111,11,'.NET','09/14/2014','11/15/2014','03/18/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad312',141,98,77,62,139,5,48,7,0,0,135,111,10,'.NET','09/15/2014','11/15/2014','03/19/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad313',141,98,77,62,139,5,48,7,0,0,135,111,10,'.NET','09/16/2014','11/15/2014','03/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad314',83,98,82,80,4,5,34,7,0,0,135,111,10,'ABAP','09/17/2014','11/30/2014','03/21/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad315',83,98,82,80,4,5,34,7,0,0,135,111,11,'ABAP','09/18/2014','11/30/2014','03/22/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad316',1,98,80,66,139,29,37,7,0,0,135,111,10,'Java','09/19/2014','10/28/2014','03/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad317',1,98,82,69,139,5,48,7,0,0,135,110,10,'.NET','09/20/2014','11/10/2014','03/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad318',1,98,82,69,139,5,48,7,0,0,135,110,10,'.NET','09/21/2014','11/10/2014','03/25/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad319',1,98,77,60,4,5,37,56,0,0,135,9,10,'BTT','09/22/2014','12/01/2014','03/26/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad320',1,98,80,95,139,29,48,7,0,0,135,9,10,'.NET','09/23/2014','12/05/2014','03/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad321',1,98,80,67,4,29,37,7,0,0,135,111,10,'Java','09/24/2014','11/15/2014','03/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad322',1,98,80,67,4,5,37,7,0,0,135,111,11,'Java','09/25/2014','11/15/2014','03/29/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad323',140,98,79,6,139,5,41,7,0,0,135,9,10,'PHP','09/26/2014','11/30/2014','03/30/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad324',140,98,79,6,139,5,41,7,0,0,135,9,10,'PHP','09/27/2014','11/30/2014','03/31/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad325',140,98,79,6,139,29,144,7,0,0,135,9,10,'Testing','09/28/2014','11/30/2014','04/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad326',140,98,79,6,139,5,144,56,0,0,135,9,10,'Testing','09/29/2014','11/30/2014','04/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad327',140,98,79,6,139,55,41,7,0,0,135,9,11,'PHP','09/30/2014','01/05/2015','04/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad328',140,98,79,6,139,55,41,7,0,0,135,9,11,'PHP','10/01/2014','01/05/2015','04/04/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad329',140,98,79,6,139,29,41,7,0,0,135,9,11,'PHP','10/02/2014','01/05/2015','04/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad330',140,98,79,6,139,5,41,7,0,0,135,9,11,'PHP','10/03/2014','01/05/2015','04/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad331',140,98,79,6,139,29,144,56,0,0,135,9,10,'Testing','10/04/2014','01/05/2015','04/07/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad332',140,98,79,6,139,5,144,7,0,0,135,9,11,'Testing','10/05/2014','01/05/2015','04/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad333',1,98,77,60,139,65,37,56,0,0,135,111,10,'BTT','10/06/2014','11/30/2014','04/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad334',85,98,78,68,4,55,39,7,1,1,135,9,10,'Nivel alto de inglés','10/07/2014','11/30/2014','04/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad335',1,98,82,69,139,29,48,7,0,0,135,110,10,'.NET','10/08/2014','12/01/2014','04/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad336',1,98,82,69,139,5,48,56,0,0,135,110,10,'.NET','10/09/2014','12/01/2014','04/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad337',1,98,82,69,139,5,48,7,0,0,135,110,10,'.NET','10/10/2014','12/01/2014','04/13/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad338',1,98,80,66,139,29,37,7,0,0,135,9,10,'Java','10/11/2014','11/24/2014','04/14/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad339',84,98,82,101,4,55,37,7,0,0,135,111,10,'Java / J2EE','10/12/2014','12/01/2014','04/15/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad340',140,98,79,82,139,55,48,7,1,1,135,9,10,'.Net','10/13/2014','01/01/2015','04/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad341',140,98,79,82,139,5,48,7,0,0,135,9,10,'.Net','10/14/2014','01/01/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad342',140,98,79,82,139,29,48,7,0,0,135,9,10,'.Net','10/15/2014','01/01/2015','04/18/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad343',140,98,79,82,139,29,48,7,0,0,135,9,10,'.Net','10/16/2014','01/01/2015','04/19/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad344',140,98,79,82,139,55,48,7,1,1,135,9,10,'.Net','10/17/2014','01/01/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad345',1,98,77,60,139,55,37,56,0,0,135,111,10,'BTT','10/18/2014','11/30/2014','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad346',84,98,82,101,4,5,37,56,0,0,135,111,10,'Java / J2EE','10/19/2014','12/01/2014','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad347',84,98,82,101,4,5,37,7,0,0,135,9,11,'Java / J2EE.','10/20/2014','12/15/2014','01/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad348',1,98,78,59,139,29,48,7,0,0,135,110,10,'.NET','10/21/2014','01/12/2015','12/05/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad349',1,98,78,59,139,5,48,56,0,0,135,110,10,'.NET','10/22/2014','01/12/2015','01/13/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad350',1,98,80,72,4,5,48,7,0,0,135,9,10,'.NET (SHAREPOINT)','10/23/2014','12/15/2014','12/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad351',1,98,82,78,4,29,37,7,0,0,135,9,10,'La tecnología utilizada es Windev, nos sirve perfiles java y  .net','10/24/2014','12/15/2014','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad352',1,98,80,72,4,29,48,7,0,0,135,9,10,'.NET (SHAREPOINT)','10/25/2014','12/15/2014','12/15/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad353',1,98,82,69,4,29,48,56,0,0,135,9,10,'.NET','10/26/2014','01/02/2015','12/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad354',1,98,82,75,139,5,37,7,0,0,135,111,10,'Java (Si es posible con conocimientos en Liferay)','10/27/2014','12/31/2014','01/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad355',140,98,79,6,139,55,41,7,0,0,135,9,10,'PHP','10/28/2014','01/02/2015','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad356',85,98,78,68,4,29,37,7,0,0,135,9,10,'Java','10/29/2014','01/15/2015','12/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad357',85,98,78,68,4,29,37,7,0,0,135,9,10,'Java','10/30/2014','01/15/2015','12/18/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad358',85,98,78,68,4,55,37,7,0,0,135,9,10,'Java','10/31/2014','01/15/2015','02/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad359',140,98,79,6,139,5,41,56,0,0,135,9,10,'PHP','11/01/2014','01/02/2015','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad360',84,98,82,101,4,65,37,56,0,0,135,9,11,'Java / J2EE.','11/02/2014','01/01/2015','01/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad361',83,98,82,81,139,65,34,7,0,0,135,9,10,'Funcional HR','11/03/2014','01/07/2015','01/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad362',1,98,82,75,139,29,37,7,0,0,135,9,10,'Java (Si es posible con conocimientos en Liferay)','11/04/2014','02/01/2015','03/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad363',1,98,82,75,139,65,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/05/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad364',1,98,82,75,139,55,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/06/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad365',1,98,82,75,139,55,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/07/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad366',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/08/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad367',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/09/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad368',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/10/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad369',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/11/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad370',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','11/12/2014','02/01/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad371',83,98,82,81,4,29,34,7,0,0,135,111,10,'ABAP','11/13/2014','12/16/2014','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad372',83,98,82,81,4,29,34,7,0,0,135,111,10,'ABAP','11/14/2014','12/16/2014','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad373',87,98,78,83,4,29,37,7,0,0,135,9,10,'Java','11/15/2014','01/15/2015','12/16/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad374',83,98,82,111,4,5,34,7,0,0,135,110,11,'ABAP','11/16/2014','01/15/2015','01/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad375',83,98,82,111,4,5,34,7,0,0,135,110,11,'ABAP','11/17/2014','01/15/2015','01/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad376',1,98,77,74,139,29,48,7,0,0,135,9,10,'','11/18/2014','01/01/2015','12/19/2014',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad377',1,98,77,60,4,5,37,56,0,0,135,9,10,'BTT','11/19/2014','01/17/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad378',1,98,77,60,4,5,37,56,0,0,135,9,10,'BTT','11/20/2014','01/17/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad379',87,98,78,83,4,55,37,7,0,0,135,110,11,'Java','11/21/2014','02/16/2015','01/22/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad380',87,98,78,83,4,55,37,7,0,0,135,109,11,'Java, Alfresco','11/22/2014','03/01/2015','01/22/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad381',140,98,79,6,139,5,144,56,0,0,135,9,11,'Testing','11/23/2014','01/07/2015','01/07/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad382',84,98,82,112,4,5,37,7,0,0,135,9,10,'Java','11/24/2014','01/31/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad383',84,98,82,112,4,29,37,7,0,0,135,9,10,'Java','11/25/2014','01/31/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad384',87,98,80,113,139,5,34,7,0,0,135,111,11,'Programador ABAP/4','11/26/2014','02/01/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad385',1,98,82,104,4,65,37,7,0,0,135,9,11,'Java','11/27/2014','02/01/2015','01/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad386',84,98,82,112,4,65,37,7,0,0,135,9,10,'Java','11/28/2014','03/01/2015','02/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad387',1,98,82,104,4,5,37,7,0,0,8,9,11,'Java','11/29/2014','05/01/2015','04/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad388',1,98,82,104,4,5,37,7,0,0,8,9,11,'Java','11/30/2014','05/01/2015','04/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad389',83,98,82,80,4,107,34,7,0,0,135,111,10,'ABAP','12/01/2014','03/15/2015','03/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad390',83,98,82,80,4,54,34,7,0,0,135,111,10,'ABAP','12/02/2014','05/15/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad391',1,98,82,75,139,5,37,56,0,0,135,9,10,'Java (Si es posible con conocimientos en Liferay), se podría estudiar algún perfil de maquetación.','12/03/2014','02/01/2015','01/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad392',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay), se podría estudiar algún perfil de maquetación.','12/04/2014','03/01/2015','02/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad393',1,98,82,75,139,55,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay, al menos el CA debe tener conocimientos en LIFERAY)','12/05/2014','02/15/2015','01/28/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad394',1,98,82,75,139,5,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','12/06/2014','03/10/2015','01/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad395',1,98,82,69,139,5,145,7,0,0,135,9,10,'Conocimiento HTML5 + CSS3','12/07/2014','02/01/2015','02/19/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad396',83,98,80,71,4,5,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','12/08/2014','02/02/2015','01/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad397',1,98,78,70,4,29,48,7,0,0,135,9,10,'NET/SHAREPOINT','12/09/2014','02/09/2015','02/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad398',83,98,80,71,4,5,37,7,0,0,8,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','12/10/2014','02/23/2015','03/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad399',83,98,80,71,4,5,37,7,0,0,8,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','12/11/2014','02/23/2015','03/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad400',83,98,80,71,4,5,37,7,0,0,8,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','12/12/2014','02/23/2015','03/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad401',83,98,80,71,4,29,37,7,0,0,8,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','12/13/2014','02/23/2015','03/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad402',83,98,80,71,4,29,37,7,0,0,8,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','12/14/2014','02/23/2015','03/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad403',142,98,78,105,4,5,37,7,0,0,8,111,11,'Imprescindible conocimiento de J2EE/Java (al menos 1 año de experiencia).                                       Deseable conocimientos de Administración Electrónica.','12/15/2014','03/15/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad404',142,98,78,105,4,5,37,7,0,0,8,111,11,'Imprescindible conocimiento de J2EE/Java (al menos 1 año de experiencia).                                       Deseable conocimientos de Administración Electrónica.','12/16/2014','03/15/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad405',142,98,78,105,4,55,37,7,0,0,8,111,11,'Imprescindible conocimientos funcionales y técnicos en Administración Electrónica.','12/17/2014','03/15/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad406',1,98,77,74,4,55,48,7,0,0,135,109,10,'','12/18/2014','02/01/2015','01/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad407',1,98,82,75,139,29,37,7,0,0,135,111,10,'Java (Si es posible con conocimientos en Liferay)','12/19/2014','03/10/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad408',1,98,82,75,139,55,37,56,0,0,135,111,10,'Java (Si es posible con conocimientos en Liferay)','12/20/2014','03/10/2015','05/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad409',1,98,82,75,139,5,37,7,0,0,135,9,10,'Java (Si es posible con conocimientos en Liferay, al menos el CA debe tener conocimientos en LIFERAY)','12/21/2014','02/15/2015','02/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad410',1,98,82,75,139,29,37,7,0,0,135,9,10,'Java (Si es posible con conocimientos en Liferay, al menos el CA debe tener conocimientos en LIFERAY)','12/22/2014','02/15/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad411',1,98,82,75,139,29,37,7,0,0,135,9,10,'Java (Si es posible con conocimientos en Liferay, al menos el CA debe tener conocimientos en LIFERAY)','12/23/2014','02/15/2015','03/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad412',1,98,82,75,139,29,37,7,0,0,135,9,10,'Java (Si es posible con conocimientos en Liferay, al menos el CA debe tener conocimientos en LIFERAY)','12/24/2014','02/15/2015','03/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad413',1,98,82,75,139,5,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','12/25/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad414',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','12/26/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad415',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','12/27/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad416',1,98,82,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','12/28/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad417',1,98,82,75,139,55,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','12/29/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad418',1,98,77,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','12/30/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad419',1,98,77,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','12/31/2014','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad420',1,98,77,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','01/01/2015','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad421',1,98,77,75,139,5,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','01/02/2015','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad422',1,98,77,75,139,55,37,7,0,0,8,9,11,'Java (Si es posible con conocimientos en Liferay)','01/03/2015','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad423',1,98,82,75,139,5,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','01/04/2015','06/15/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad424',1,98,82,75,139,5,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','01/05/2015','06/15/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad425',1,98,80,63,139,55,37,7,1,1,135,9,11,'java','01/06/2015','02/05/2015','02/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad426',1,98,80,63,139,5,37,7,0,0,135,9,11,'java','01/07/2015','02/26/2015','02/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad427',1,98,80,63,139,5,37,7,0,0,135,9,11,'java','01/08/2015','02/26/2015','02/10/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad428',141,98,77,62,139,29,48,7,0,0,135,111,10,'.NET','01/09/2015','03/15/2015','02/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad429',141,98,77,62,139,5,48,56,0,0,135,111,10,'.NET','01/10/2015','03/15/2015','02/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad430',141,98,77,62,139,5,48,7,0,0,135,111,10,'.NET','01/11/2015','03/15/2015','02/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad431',141,98,77,62,139,5,48,7,0,0,135,111,10,'.NET','01/12/2015','03/15/2015','02/18/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad432',141,98,77,62,139,5,48,7,0,0,135,111,11,'.NET','01/13/2015','03/15/2015','03/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad433',1,98,77,74,4,29,37,7,0,0,135,9,10,'BKS','01/14/2015','03/15/2015','02/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad434',1,98,77,74,4,29,37,7,0,0,135,9,10,'BKS','01/15/2015','03/15/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad435',1,98,77,74,4,29,37,7,0,0,135,9,10,'BKS','01/16/2015','03/15/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad436',1,98,77,74,4,5,37,7,0,0,135,9,11,'BKS','01/17/2015','03/15/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad437',1,98,77,74,4,55,37,7,0,0,135,9,11,'BKS','01/18/2015','03/15/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad438',1,98,77,74,4,65,37,7,0,0,135,9,11,'BKS','01/19/2015','03/15/2015','03/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad439',83,98,80,71,139,29,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/20/2015','02/16/2015','02/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad440',83,98,80,71,139,5,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/21/2015','02/16/2015','02/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad441',83,98,80,71,139,5,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/22/2015','02/16/2015','02/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad442',83,98,80,71,139,29,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/23/2015','03/02/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad443',83,98,80,71,139,5,37,7,0,0,135,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/24/2015','03/02/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad444',83,98,80,71,139,29,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/25/2015','03/02/2015','02/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad445',83,98,80,71,139,29,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/26/2015','03/02/2015','02/19/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad446',83,98,80,71,139,29,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/27/2015','03/02/2015','02/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad447',83,98,80,71,4,5,37,7,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/28/2015','03/02/2015','02/13/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad448',83,98,80,71,4,5,37,7,0,0,135,9,11,'Conocimiento de Spring, Hibernate, Maven. Valorable el conocimiento de frameworks MVC, como JSF','01/29/2015','03/02/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad449',1,98,77,60,4,29,37,7,0,0,135,9,10,'BTT','01/30/2015','03/15/2015','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad450',1,98,77,60,4,29,37,7,0,0,135,9,10,'BTT','01/31/2015','03/15/2015','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad451',1,98,77,60,4,29,37,7,0,0,135,9,10,'BTT','02/01/2015','03/15/2015','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad452',1,98,77,60,4,29,37,7,0,0,135,9,10,'BTT','02/02/2015','03/15/2015','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad453',1,98,77,60,4,29,37,7,0,0,135,9,10,'BTT','02/03/2015','03/15/2015','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad454',1,98,80,63,139,55,48,7,1,1,135,9,11,'.net','02/04/2015','04/01/2015','04/21/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad455',1,98,80,63,139,5,48,7,0,0,135,9,11,'.net','02/05/2015','04/01/2015','03/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad456',1,98,80,63,139,5,48,7,0,0,135,9,11,'.net','02/06/2015','04/01/2015','03/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad457',1,98,82,69,139,29,48,7,0,0,135,110,10,'.NET','02/07/2015','02/17/2015','02/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad458',85,98,78,68,4,5,144,7,0,0,135,9,10,'Nivel alto de inglés','02/08/2015','04/01/2015','03/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad459',1,98,80,67,4,29,37,7,0,0,135,111,10,'Java','02/09/2015','02/16/2015','02/16/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad460',87,98,78,83,4,5,37,56,0,0,135,9,10,'Java','02/10/2015','03/02/2015','03/03/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad461',83,98,82,114,4,55,34,7,0,0,135,9,10,'Programador con experiencia en el módulo HCM','02/11/2015','03/02/2015','02/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad462',83,98,82,81,4,5,34,7,0,0,135,9,10,'Programador ABAP con experiencia (ideal unos 2 años)','02/12/2015','03/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad463',142,98,78,105,4,55,37,7,0,0,135,111,10,'Imprescindible conocimientos funcionales y técnicos en Administración Electrónica.','02/13/2015','04/01/2015','03/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad464',142,98,78,105,4,29,37,56,0,0,135,111,10,'Imprescindible conocimiento de J2EE/Java.
                                      Deseable conocimientos de Administración Electrónica.','02/14/2015','04/01/2015','03/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad465',1,98,80,63,4,29,34,7,0,0,135,9,10,'Programador o Analista Programador con experiencia en el módulo HCM.','02/15/2015','04/01/2015','06/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad466',83,98,82,81,4,55,34,7,0,0,135,9,11,'Programador ABAP.','02/16/2015','04/01/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad467',83,98,82,81,4,29,34,7,0,0,135,9,10,'Programador ABAP.','02/17/2015','05/30/2015','06/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad468',83,98,82,81,4,29,34,7,0,0,135,9,10,'Programador ABAP.','02/18/2015','05/30/2015','06/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad469',142,98,78,105,4,5,37,7,0,0,135,111,10,'Imprescindible conocimiento de J2EE/Java (al menos 1 año de experiencia).Deseable conocimientos de Administración Electrónica.','02/19/2015','05/04/2015','02/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad470',1,98,77,75,139,55,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','02/20/2015','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad471',1,98,77,75,139,5,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','02/21/2015','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad472',1,98,77,75,139,5,37,7,0,0,8,111,11,'Java (Si es posible con conocimientos en Liferay)','02/22/2015','04/01/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad473',1,98,82,78,4,29,37,7,0,0,135,9,11,'Windev (Si es posible con conocimientos en Java o .NET)','02/23/2015','04/01/2015','03/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad474',1,98,77,74,4,29,37,7,0,0,135,9,11,'BKS','02/24/2015','03/31/2015','03/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad475',1,98,77,74,4,29,37,7,0,0,135,9,11,'BKS','02/25/2015','03/31/2015','03/06/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad476',87,98,78,83,4,5,37,7,0,0,135,9,10,'Java','02/26/2015','04/11/2015','03/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad477',1,98,80,63,139,55,48,7,0,0,135,9,10,'.net','02/27/2015','04/15/2015','04/21/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad478',85,98,78,68,4,5,39,56,0,0,135,9,10,'Debe trabajar en inglés','02/28/2015','04/15/2015','06/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad479',85,98,78,68,4,5,144,7,0,0,8,9,11,'Tester Con inglés','03/01/2015',null,'06/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad480',85,98,78,68,4,5,144,7,0,0,8,9,11,'Tester Con inglés','03/02/2015',null,'06/05/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad481',1,98,77,74,4,29,37,7,0,0,135,9,10,'BKS','03/03/2015','04/07/2015','03/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad482',1,98,77,74,4,5,37,7,0,0,135,9,10,'BKS','03/04/2015','04/07/2015','03/24/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad483',83,98,80,71,4,5,37,7,0,0,135,9,11,'Java','03/05/2015','04/27/2015','04/14/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad484',83,98,80,71,4,5,37,7,0,0,135,9,11,'Java','03/06/2015','04/27/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad485',83,98,80,71,4,29,37,7,0,0,135,9,10,'Java','03/07/2015','04/27/2015','04/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad486',83,98,80,71,4,29,37,7,0,0,135,9,11,'Java','03/08/2015','04/27/2015','04/14/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad487',83,98,80,71,4,29,37,7,0,0,135,9,11,'Java','03/09/2015','04/27/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad488',1,98,82,106,4,67,144,7,0,0,135,9,10,'Otros','03/10/2015','05/01/2015','05/15/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad489',83,98,80,71,4,29,37,7,0,0,135,9,11,'Java','03/11/2015','04/26/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad490',83,98,80,71,4,5,37,7,0,0,135,9,10,'Java','03/12/2015','04/26/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad491',83,98,80,71,4,5,37,7,0,0,135,9,11,'Java','03/13/2015','04/26/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad492',85,98,78,68,4,55,37,56,0,0,135,9,10,'Java','03/14/2015','04/30/2015','05/12/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad493',1,98,82,104,4,5,37,7,0,0,135,9,10,'Java','03/15/2015','04/14/2015','04/08/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad494',142,98,78,105,4,5,37,7,0,0,135,111,10,'Imprescindible conocimiento de J2EE/Java (al menos 1 año de experiencia).Deseable conocimientos de Administración Electrónica.','03/16/2015','05/04/2015','05/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad495',1,98,82,104,4,5,37,7,0,0,135,9,11,'Java','03/17/2015','05/04/2015','04/17/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad496',142,98,78,105,4,65,37,56,0,0,135,111,10,'Imprescindible conocimiento de J2EE/Java (al menos 1 año de experiencia).Deseable conocimientos de Administración Electrónica.','03/18/2015','04/20/2015','04/20/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad497',140,98,79,82,139,55,48,56,0,0,135,111,10,'.NET','03/19/2015','05/01/2015','05/11/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad498',83,98,80,71,139,65,37,7,0,0,8,9,10,'Java','03/20/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad499',83,98,80,71,139,65,37,7,0,0,8,9,10,'Java','03/21/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad500',83,98,80,71,139,65,37,7,0,0,8,9,10,'Java','03/22/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad501',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/23/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad502',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/24/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad503',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/25/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad504',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/26/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad505',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/27/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad506',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/28/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad507',83,98,80,71,139,55,37,7,0,0,8,9,10,'Java','03/29/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad508',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','03/30/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad509',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','03/31/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad510',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','04/01/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad511',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','04/02/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad512',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','04/03/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad513',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','04/04/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad514',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','04/05/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad515',83,98,80,71,139,5,37,7,0,0,8,9,10,'Java','04/06/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad516',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/07/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad517',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/08/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad518',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/09/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad519',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/10/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad520',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/11/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad521',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/12/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad522',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/13/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad523',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/14/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad524',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/15/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad525',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/16/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad526',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/17/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad527',83,98,80,71,139,29,37,7,0,0,8,9,10,'Java','04/18/2015','10/15/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad528',85,98,78,68,4,55,37,7,0,0,135,9,11,'Debe trabajar en inglés y, preferiblemente, debe tener conocimientos de Javascript','04/19/2015','05/30/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad529',142,98,78,105,4,55,37,7,0,0,8,111,10,'Imprescindible conocimiento de J2EE/Java (al menos 2 años de experiencia). Deseable conocimientos de Administración Electrónica.','04/20/2015','06/01/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad530',142,98,78,104,4,5,37,7,0,0,135,111,10,'Imprescindible conocimiento de J2EE/Java (al menos 2 años de experiencia). Deseable conocimientos de Administración Electrónica.','04/21/2015','06/01/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad531',1,98,77,60,139,5,37,7,0,0,8,111,10,'','04/22/2015','06/30/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad532',83,98,78,102,139,29,34,7,0,0,135,9,10,'ABAP','04/23/2015','05/30/2015','06/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad533',83,98,82,80,4,29,34,7,0,0,135,111,10,'ABAP','04/24/2015','06/01/2015','06/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad534',83,98,82,80,4,65,34,7,1,1,135,111,10,'SAP-FI','04/25/2015','05/30/2015','06/01/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad535',83,98,80,71,139,55,37,56,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven y SQL. Valorable el conocimiento de frameworks MVC, como JSF','04/26/2015','06/15/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad536',1,98,78,70,4,29,48,56,0,0,135,9,11,'.Net','04/27/2015','06/15/2015','05/26/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad537',1,98,77,74,4,65,37,56,0,0,135,9,10,'BKS','04/28/2015','06/13/2015','05/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad538',1,98,77,74,4,5,37,56,0,0,135,9,10,'BKS','04/29/2015','06/13/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad539',1,98,77,74,4,29,37,56,0,0,135,9,10,'JAVA','04/30/2015','06/13/2015','05/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad540',1,98,77,74,4,29,37,56,0,0,135,9,10,'JAVA','05/01/2015','06/13/2015','05/27/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad541',83,98,80,71,139,54,37,56,0,0,135,9,10,'Conocimiento de Spring, Hibernate, Maven y SQL. Valorable el conocimiento de frameworks MVC, como JSF','05/02/2015','06/25/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad542',85,98,78,68,4,5,37,7,0,0,135,9,10,'Debe trabajar en inglés','05/03/2015','06/22/2015','06/02/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad543',83,98,82,80,4,5,34,7,0,0,135,111,10,'ABAP','05/04/2015','07/02/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad544',87,98,78,83,4,65,37,56,0,0,135,9,10,'Java','05/05/2015','07/01/2015','06/23/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad545',85,98,78,68,4,5,144,7,0,0,135,9,10,'Tester Con inglés','05/06/2015','07/01/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad546',85,98,78,68,4,5,144,7,0,0,135,9,10,'Tester Con inglés','05/07/2015','07/01/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad547',87,98,78,83,4,29,37,7,0,0,135,9,10,'Java','05/08/2015','06/09/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad548',84,98,82,101,4,29,37,7,0,0,135,111,10,'Java / J2EE','05/09/2015','06/09/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad549',84,98,82,101,4,29,37,7,0,0,135,111,10,'Java / J2EE','05/10/2015','06/09/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad550',1,98,77,60,4,29,37,7,0,0,135,9,10,'BTT','05/11/2015','06/09/2015','06/09/2015',4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad551',83,98,82,80,4,5,34,7,0,0,135,111,10,'ABAP','05/12/2015','07/02/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad552',1,98,80,66,139,29,37,7,0,0,135,9,10,'Java','05/13/2015','07/23/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad553',1,98,80,66,139,29,37,7,0,0,135,9,10,'Java','05/14/2015','07/23/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad554',1,98,80,66,139,29,37,7,0,0,135,9,10,'Java','05/15/2015','07/23/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad555',1,98,80,66,139,5,37,7,0,0,135,9,10,'Java','05/16/2015','07/23/2015',null,4,4,getdate(),getdate(),1)
INSERT INTO [dbo].[Necesidad]
           ([Nombre] ,[OficinaId] ,[CentroId] ,[SectorId] ,[ProyectoId] ,[TipoServicioId] ,[TipoPerfilId] ,[TipoTecnologiaId] ,[TipoContratacionId] ,[DisponibilidadViaje] ,[CambioResidencia] ,[TipoPrevisionId]
 ,[MesesAsignacionId] ,[EstadoNecesidadId] ,[Observaciones] ,[FechaSolicitud] ,[FechaCompromiso] ,[FechaCierre] ,[UsuarioCreacionId] ,[UsuarioModificacionId]  ,[FechaCreacion],[FechaModificacion] ,[Activo])
     VALUES
           ('Necesidad556',1,98,80,66,139,5,37,7,0,0,135,9,10,'Java','05/17/2015','07/23/2015',null,4,4,getdate(),getdate(),1)


commit tran t1
------------------------------------------------------------------------------------------------------------------------------------