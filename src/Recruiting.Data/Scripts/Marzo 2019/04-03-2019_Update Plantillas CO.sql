--1) Activo False
UPDATE CorreoPlantilla SET Activo = 0
WHERE NombrePlantilla LIKE 'COEnPracticasGM'
OR NombrePlantilla LIKE 'COEnPracticasFP9Meses'
OR NombrePlantilla LIKE 'COEnPracticasGM9Meses'
OR NombrePlantilla LIKE 'COEnPracticasGS9Meses'


--2) Cambiar nombre plantilla 

UPDATE CorreoPlantilla SET NombrePlantilla = 'COJuniorEnPracticas'
WHERE NombrePlantilla LIKE 'COEnPracticasFP'
AND Activo = 1

UPDATE CorreoPlantilla SET NombrePlantilla = 'COJuniorIndefinido'
WHERE NombrePlantilla LIKE 'COEnPracticasGS'
AND Activo = 1

--3) Updateo Plantillas CO Junior Indefinido

--SEVILLA
UPDATE CorreoPlantilla SET TextoPlantilla = '
		 
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

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; FONT-SIZE: 11pt;">
           Estimado/a {0}~NombreCandidato|
        </div>
		<br/>

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
       
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt">
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
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>
       
        

        <p >
            <span><img width="5.0cm" height="2.0cm" src="file:///{0}" /></span>~imagenFirma||
        </p>


		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Open Sans'',''sans-serif''; COLOR: #505050; FONT-SIZE: 5pt;">
			Información de Protección de Datos<br/>
			Everis Centers S.L.U., en adelante la empresa, con domicilio en Sevilla, Avenida Américo Vespucio 5, le informa que es el Responsable 
			del tratamiento de los datos personales que voluntariamente facilite el interesado al remitir firmada esta oferta 
			y la documentación solicitada en la misma.<br/> 
			Los citados datos serán tratados con la exclusiva finalidad de realizar las gestiones pertinentes ante la Seguridad Social y el resto 
			de trámites necesarios para formalizar contrato de trabajo. Los datos y documentos solicitados son los necesarios para para tramitar 
			su contrato laboral, por lo que su negativa a facilitaros podría impedir dicha tramitación. No realizamos la toma de decisiones 
			automatizadas (incluida la elaboración de perfiles) a partir de los datos que nos facilite.<br/> 
			La base legal para los citados tratamientos es la aplicación de medidas precontractuales para la ejecución de un contrato en el que 
			el interesado es parte.<br/>
			Los datos personales recabados se conservarán, en su caso, durante la duración de la relación laboral que se formalice. No obstante, 
			si transcurrido el periodo de validez de esta carta oferta, no se procediese a la firma del contrato de trabajo, o bien usted rechaza 
			la oferta antes de transcurrir dicho periodo, los datos dejarán de tratarse y serán debidamente bloqueados durante los plazos de prescripción 
			establecidos por la legislación aplicable.<br/>
			Le informamos así mismo que los datos personales podrán ser comunicados a las empresas del GRUPO EVERIS que deban encargarse de gestionar 
			su contrato laboral o de realizar alguna actuación en relación con éste, así como a la Tesorería General de la Seguridad Social y demás 
			organismos públicos y privados, en la medida en que sea necesario para cumplir las obligaciones legales a las que estemos sujetos.<br/> 
			El interesado puede, en cualquier momento, solicitar el acceso a sus datos personales, su rectificación o supresión, así como a solicitar 
			la limitación de su tratamiento y la portabilidad de sus datos cuando se den los motivos o circunstancias previstas en la normativa aplicable. 
			A tales efectos podrá utilizar los siguientes canales, acompañando siempre acompañando fotocopia de su DNI o cualquier otro documento que permita 
			acreditar su identidad:<br/>
					-		Por carta a la dirección: Avenida Américo Vespucio 5, 41092, Sevilla.<br/>
					-		Por correo electrónico a data.protection.office@everis.com<br/>
			La empresa cuenta con un Delegado de Protección de Datos cuyos datos de contacto son: data.protection.office@everis.com<br/>
			Por último, se le informa igualmente de su derecho a presentar una reclamación ante la Agencia Española de Protección de Datos en caso de que tenga 
			conocimiento o considere que se hemos podido vulnerar sus derechos en materia de protección de datos. 
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
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>POSICIÓN OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACIÓN CONTRACTUAL </u>: </b>  Contrato indefinido, con un período de prueba de 3 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';COLOR: #505050; FONT-SIZE: 10pt;padding-left:0.2cm;">
           <ul>
				<li><b>Retribución:  </b> La <b>retribución bruta anual </b>será de {0} € y se desglosa según el siguiente criterio:~SalarioBruto|	</li>
				<ul style="list-style-type: circle;">
					<li><b>Retribución fija:</b> {0} € que se liquidarán en 14 pagas. ~SalarioNeto|</li>		
					<li><b>Retribución Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibirás una ayuda comedor por un importe de <b> {0} €.</b>
					Este importe está sujeto de acuerdo a la política de la compañía en cada momento~AyudaComedor|</li>
				</ul>						
				<li><b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y cumpliendo con los requisitos requeridos.</li>
		  </ul>
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se hará efectiva en el momento en que nos contactes, teniendo un plazo máximo de vigencia de 15 días naturales, a partir de la fecha de recepción de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <ul>
		        <li><b><u>DOCUMENTACIÓN NECESARIA: </u></b>  Con el fin de agilizar al máximo los trámites necesarios para tu contratación, te detallamos la documentación que debes remitirnos:<br/><br/></li>
		   </ul>
		</div>	
		   
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; padding-left:0.3cm;">
		   <p style="padding-left:0.5cm;"><b><u>Documentación PREVIA a la contratación: </u></b></p>
		   <ul style="list-style-type: circle;">
				<li> Carta Oferta firmada (todas las páginas). </li>
				<li> Copia DNI.  </li>
				<li> Número de afiliación a la Seguridad Social (NAF).  </li>
				<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atención telefónica de la Seguridad Social), y ellos la enviarán a tu domicilio.  </li>
				<li> Copia de la titulación. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedición de la misma. </li>
				<li> Copia de todas las certificaciones oficiales (ej. Sap, CCNA. CCNP, etc.) </li>
				<li> Si tienes reconocida una <b>Discapacidad</b>: Copia Certificado de discapacidad emitido por el organismo correspondiente.</li>						
		   </ul>
		</div>
		 
		 <br/><br/>
		 <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:70%;float:right;TEXT-ALIGN: center">
                Conforme:
            </div>
		</div>
		<div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>

        <p>
            <span><img width="5.0cm" height="2.03cm" src="file:///{0}" /></span>~imagenFirma||
        </p>

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
           
		   <p style="padding-left:0.5cm"><b><u>Documentación en supuestos especiales: </u></b></p>
						<ul style="list-style-type: circle;">
						<li><u>Opción <b>Movilidad Geográfica:</b></u> Podrás acogerte a una reducción fiscal si en el momento de la contratación estás <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condición 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentación a aportar el día de la incorporación: </u></b><br/><br/>  
		   <ul style="list-style-type: circle;">
		   <li>Disponer de la información relativa a  tus datos bancarios (IBAN), puesto que deberás rellenar un formulario indicándola. Es conveniente que traigas anotado el número de cuenta. </li>
		   </ul>
		</div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
			<p style="padding-left:0.5cm"><b><u>Envío de documentación: </u></b></p>

			<ul style="list-style-type: circle;">  
				<li>  La documentación debe ser enviada al siguiente correo electrónico:<b>
				<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b>
				Si tienes cualquier duda relativa a dicha documentación puedes enviarnos un e-mail a la dirección indicada o 
				puedes llamarnos al  {1} (Departamento de contratación)~MailTo~TelefonoContratacion|</li>
			</ul>
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<ul style="list-style-type: circle;">  
            <li>  Si te surgen dudas en relación a las condiciones de esta oferta o sobre la concreción del día de tu incorporación, puedes contactar <b>teléfono</b>: {0} ~Telefono~Atencion|</li>
        </ul>
		</div>
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
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; width:30%;float:left;">
                {0}~CargoEntregaCarta|
            </div>
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050;width:70%;float:right;TEXT-ALIGN: center">
                {0}~NombreCandidato|
            </div>

		</div>

        <p>
            <span><img width="5.0cm" height="2.03cm" src="file:///{0}" /></span>~imagenFirma||
        </p>
    </div>
</div>
</body>
</html>' WHERE PlantillaId = 45;


--MURCIA
UPDATE CorreoPlantilla SET TextoPlantilla = '
		 
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
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>POSICIÓN OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACIÓN CONTRACTUAL </u>: </b>  Contrato indefinido, con un período de prueba de 3 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribución:  </b> La <b>retribución bruta anual </b>será de {0} € y se desglosa según el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribución fija:</b> {0} € que se liquidarán en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribución Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibirás una ayuda comedor por un importe de <b> {0} €.</b>
			Este importe está sujeto de acuerdo a la política de la compañía en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se hará efectiva en el momento en que nos contactes, teniendo un plazo máximo de vigencia de 15 días naturales, a partir de la fecha de recepción de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACIÓN NECESARIA: </u></b>  Con el fin de agilizar al máximo los trámites necesarios para tu contratación, te detallamos la documentación que debes remitirnos:<br/><br/>
			<b><u>Documentación PREVIA a la contratación: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las páginas). </li>
						<li> Copia DNI.  </li>
						<li>Número de afiliación a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atención telefónica de la Seguridad Social), y ellos la enviarán a tu domicilio.  </li>
						<li> Copia de la titulación. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedición de la misma. </li>
						<li> Copia de todas las certificaciones oficiales (ej. Sap, CCNA. CCNP, etc.) </li>
						<li>Si tienes reconocida una <b>Discapacidad:</b> Copia Certificado de discapacidad emitido por el organismo correspondiente.</li>
						</ul>
			
			</div>
		 
		 <br/><br/>
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
           
		   <b><u>Documentación en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opción <b>Movilidad Geográfica:</b></u> Podrás acogerte a una reducción fiscal si en el momento de la contratación estás <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condición 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentación a aportar el día de la incorporación: </u></b><br/><br/>  
		   • Disponer de la información relativa a  tus datos bancarios (IBAN), puesto que deberás rellenar un formulario indicándola. Es conveniente que traigas anotado el número de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Envío de documentación: </u></b><br/><br/>  
            •  La documentación debe ser enviada al siguiente correo electrónico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentación puedes enviarnos un e-mail a la dirección indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contratación)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Si te surgen dudas en relación a las condiciones de esta oferta o sobre la concreción del día de tu incorporación, puedes contactar teléfono:<b> {0} </b>~Telefono~Atencion|
        </div>
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
	' WHERE PlantillaId = 52;


--ALICANTE
UPDATE CorreoPlantilla SET TextoPlantilla = '
		 
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
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>POSICIÓN OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACIÓN CONTRACTUAL </u>: </b>  Contrato indefinido, con un período de prueba de 3 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribución:  </b> La <b>retribución bruta anual </b>será de {0} € y se desglosa según el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribución fija:</b> {0} € que se liquidarán en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribución Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibirás una ayuda comedor por un importe de <b> {0} €.</b>
			Este importe está sujeto de acuerdo a la política de la compañía en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se hará efectiva en el momento en que nos contactes, teniendo un plazo máximo de vigencia de 15 días naturales, a partir de la fecha de recepción de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACIÓN NECESARIA: </u></b>  Con el fin de agilizar al máximo los trámites necesarios para tu contratación, te detallamos la documentación que debes remitirnos:<br/><br/>
			<b><u>Documentación PREVIA a la contratación: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las páginas). </li>
						<li> Copia DNI.  </li>
						<li>Número de afiliación a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atención telefónica de la Seguridad Social), y ellos la enviarán a tu domicilio.  </li>
						<li> Copia de la titulación. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedición de la misma. </li>
						<li> Copia de todas las certificaciones oficiales (ej. Sap, CCNA. CCNP, etc.) </li>
						<li>Si tienes reconocida una <b>Discapacidad:</b> Copia Certificado de discapacidad emitido por el organismo correspondiente.</li>
						</ul>
			
			</div>
		 
		 <br/><br/>
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
           
		   <b><u>Documentación en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opción <b>Movilidad Geográfica:</b></u> Podrás acogerte a una reducción fiscal si en el momento de la contratación estás <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condición 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentación a aportar el día de la incorporación: </u></b><br/><br/>  
		   • Disponer de la información relativa a  tus datos bancarios (IBAN), puesto que deberás rellenar un formulario indicándola. Es conveniente que traigas anotado el número de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Envío de documentación: </u></b><br/><br/>  
            •  La documentación debe ser enviada al siguiente correo electrónico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentación puedes enviarnos un e-mail a la dirección indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contratación)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Si te surgen dudas en relación a las condiciones de esta oferta o sobre la concreción del día de tu incorporación, puedes contactar teléfono:<b> {0} </b>~Telefono~Atencion|
        </div>
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
	' WHERE PlantillaId = 59;

--SALAMANCA
UPDATE CorreoPlantilla SET TextoPlantilla = '
		 
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
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>POSICIÓN OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACIÓN CONTRACTUAL </u>: </b>  Contrato indefinido, con un período de prueba de 3 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribución:  </b> La <b>retribución bruta anual </b>será de {0} € y se desglosa según el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribución fija:</b> {0} € que se liquidarán en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribución Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibirás una ayuda comedor por un importe de <b> {0} €.</b>
			Este importe está sujeto de acuerdo a la política de la compañía en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se hará efectiva en el momento en que nos contactes, teniendo un plazo máximo de vigencia de 15 días naturales, a partir de la fecha de recepción de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACIÓN NECESARIA: </u></b>  Con el fin de agilizar al máximo los trámites necesarios para tu contratación, te detallamos la documentación que debes remitirnos:<br/><br/>
			<b><u>Documentación PREVIA a la contratación: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las páginas). </li>
						<li> Copia DNI.  </li>
						<li>Número de afiliación a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atención telefónica de la Seguridad Social), y ellos la enviarán a tu domicilio.  </li>
						<li> Copia de la titulación. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedición de la misma. </li>
						<li> Copia de todas las certificaciones oficiales (ej. Sap, CCNA. CCNP, etc.) </li>
						<li>Si tienes reconocida una <b>Discapacidad:</b> Copia Certificado de discapacidad emitido por el organismo correspondiente.</li>
						</ul>
			
			</div>
		 
		 <br/><br/>
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
           
		   <b><u>Documentación en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opción <b>Movilidad Geográfica:</b></u> Podrás acogerte a una reducción fiscal si en el momento de la contratación estás <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condición 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentación a aportar el día de la incorporación: </u></b><br/><br/>  
		   • Disponer de la información relativa a  tus datos bancarios (IBAN), puesto que deberás rellenar un formulario indicándola. Es conveniente que traigas anotado el número de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Envío de documentación: </u></b><br/><br/>  
            •  La documentación debe ser enviada al siguiente correo electrónico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentación puedes enviarnos un e-mail a la dirección indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contratación)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Si te surgen dudas en relación a las condiciones de esta oferta o sobre la concreción del día de tu incorporación, puedes contactar teléfono:<b> {0} </b>~Telefono~Atencion|
        </div>
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
	' WHERE PlantillaId = 66;