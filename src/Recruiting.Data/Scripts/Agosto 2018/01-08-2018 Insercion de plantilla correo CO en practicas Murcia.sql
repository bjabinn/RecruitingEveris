SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(50, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato en pr�cticas, con un per�odo de prueba de  1 mes, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se har� efectiva en el momento en que nos contactes, teniendo un plazo m�ximo de vigencia de 15 d�as naturales, a partir de la fecha de recepci�n de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COEnPracticasFP' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (50, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (50, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (50, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (50, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (50, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (50, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')



SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(51, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato en pr�cticas, con un per�odo de prueba de  1 mes, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se har� efectiva en el momento en que nos contactes, teniendo un plazo m�ximo de vigencia de 15 d�as naturales, a partir de la fecha de recepci�n de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COEnPracticasGM' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (51, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (51, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (51, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (51, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (51, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (51, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')


SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(52, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato en pr�cticas, con un per�odo de prueba de  2 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se har� efectiva en el momento en que nos contactes, teniendo un plazo m�ximo de vigencia de 15 d�as naturales, a partir de la fecha de recepci�n de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COEnPracticasGS' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (52, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (52, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (52, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (52, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (52, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (52, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')


SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(53, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato en pr�cticas, con un per�odo de prueba de  1 mes, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.


        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La validez de esta carta oferta est� condicionada a la obtenci�n del t�tulo oficial o en su defecto fotocopia del resguardo de pago de las tasas correspondientes, teniendo un plazo m�ximo de vigencia de 9 meses a partir de la fecha de emisi�n de la misma.
		   <br/><br/>
		   La carta oferta se har� efectiva en el momento que entregues dicho documento.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COEnPracticasFP9Meses' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (53, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (53, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (53, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (53, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (53, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (53, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')


SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(54, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato en pr�cticas, con un per�odo de prueba de  1 mes, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.


        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La validez de esta carta oferta est� condicionada a la obtenci�n del t�tulo oficial o en su defecto fotocopia del resguardo de pago de las tasas correspondientes, teniendo un plazo m�ximo de vigencia de 9 meses a partir de la fecha de emisi�n de la misma.
		   <br/><br/>
		   La carta oferta se har� efectiva en el momento que entregues dicho documento.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COEnPracticasGM9Meses' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (54, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (54, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (54, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (54, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (54, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (54, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')



SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(55, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato en pr�cticas, con un per�odo de prueba de  2 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.


        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La validez de esta carta oferta est� condicionada a la obtenci�n del t�tulo oficial o en su defecto fotocopia del resguardo de pago de las tasas correspondientes, teniendo un plazo m�ximo de vigencia de 9 meses a partir de la fecha de emisi�n de la misma.
		   <br/><br/>
		   La carta oferta se har� efectiva en el momento que entregues dicho documento.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COEnPracticasGS9Meses' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (55, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (55, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (55, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (55, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (55, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (55, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')


SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(56, '
		 
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
           �Enhorabuena! Es un placer escribirte para confirmarte nuestro inter�s en tu incorporaci�n en la empresa.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Somos una Compa��a de consultor�a de �mbito internacional, con unas s�lidas perspectivas
                de expansi�n, crecimiento y consolidaci�n en este mercado y queremos agradecerte la confianza que has demostrado adem�s del inter�s por
                habernos presentado tu candidatura.|
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				 En<b> everis centers</b>  encontrar�s el lugar ideal para desarrollar tus intereses y motivaciones profesionales y recibir�s la formaci�n y la estabilidad necesaria
                para tu desarrollo en la empresa.
        </div>
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Nuestra actitud nos hace diferentes alcanzando objetivos, ofreciendo soluciones e innovando en todo lo que hacemos.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Una vez m�s agradecerte el tiempo que nos has dedicado durante el proceso de selecci�n y sobre todo darte la bienvenida al Grupo de profesionales 
		  que integramos <b>everis centers</b>, confiando en que adem�s de encontrar un excelente entorno de trabajo, 
		  contribuyamos a tu mejor desarrollo profesional.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Es necesario que nos devuelvas una copia firmada de la carta as� como el anexo que se adjunta,indicando tu aceptaci�n a la atenci�n del <b>Departamento de Selecci�n</b>.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Esperamos que pronto nos comuniques la confirmaci�n de tu decisi�n definitiva.
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
                han sido incorporados a un fichero cuyo responsable es Everis Spain, SLU con domicilio en Avenida Manoteras, n�m. 52. 28050 Madrid, y ser�n tratados
                con la finalidad de gestionar el proceso de selecci�n, de incluir su candidatura en procesos de seleccion, gestionar en su caso la contratacion del
                candidato seleccionado, reenviar su candidatura a aquellas compa�ias del Grupo everis que hubieran convocado la oferta de empleo o que pudieran estar
                interesadas en su perfil, realizar estadisticas, asi como enviarle informacion relacionada con las actividades y servicios del Grupo everis que
                pudieran ser de interes para el candidato, tales como, sin caracter limitativo, el envio de ofertas, noticias, eventos, newsletters, encuestas
                e informaciones relacionadas con el sector de la consultoria.
                Asimismo, le informamos de que para una mejor gesti�n de los procesos de selecci�n, sus datos podr�n ser transferidos a otras entidades del Grupo
                Everis, de acuerdo a la informaci�n facilitada en nuestra p�gina web <a href="http://www.everis.com" style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt">http://www.everis.com</a>
                ,* algunas de ellas establecidas en pa�ses no miembros de la Uni�n Europea. Ay�denos a mantener dichos datos actualizados comunic�ndonos cualquier
                modificaci�n que se produzca en los mismos.
        </div>
		<br/>

      <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt;">
                Si no desea que el
                tratamiento de sus datos se realice con la finalidad indicada, o desea ejercitar los derechos de acceso, rectificaci�n, cancelaci�n u
                oposici�n, deber� dirigirse por escrito al Departamento de Selecci�n de Everis Spain, SL( adjuntando fotocopia de su DNI o documento de
                dentificacion equivalente) en la direcci�n arriba indicada.
                *La Compa��a podr� ceder sus datos personales a otras sociedades del Grupo multinacional Everis sin perjuicio de las actualizaciones de la p�gina web:
                <a style="FONT-FAMILY: ''Arial'',''sans-serif''; COLOR: #505050; FONT-SIZE: 6pt" href="http://www.everis.com">www.everis.com</a> tales como Everis Spain
                S.L.U, Everis BPO S.L.U, Everis Centers Group S.L.U, Everis Initiatives S.L.U, Everis Argentina S.A, Everis Brasil Ltda, Everis BPO Brasil Ltda, Everis Chile S.A,
                Everis Colombia Ltda., Everis BPO Colombia Ltda., Everis M�xico S. de R.L, Everis BPO M�xico S. de R.L, Everis Panam� INC, Everis Per� SAC, Everis BPO Per� SAC,
                Everis Polonia Sp. Z o. o, 	Everis Italia S.p.A, Everis Portugal S.A, Everis USA INC, Everisconsultancy Limited, Everis Consulting INC (South �frica), Service Co
                Everis LLC, I-Deals Innovation&amp;technology Venturing Services S.L.U, Everis Arag�n S.L.U, Everis Servicios Energ�ticos S.L.U, Optizeveris S.L, Everis Aeroespacial
                y Defensa S.L.U, Embention Sistemas Inteligentes S.L, Everis Mobile S.L	y Fundaci�n Everis.
            
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
          <b><u>POSICI�N OFERTADA </u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>RELACI�N CONTRACTUAL </u>: </b>  Contrato Indefinido, con un per�odo de prueba de  6 meses, sujeto al Convenio Colectivo Nacional de Empresas Consultoras.


        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>CONDICIONES: </u></b> 
        </div>
		      
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;padding-left:1cm;">
           <b>Retribuci�n:  </b> La <b>retribuci�n bruta anual </b>ser� de {0} � y se desglosa seg�n el siguiente
		criterio:~SalarioBruto|
			
				<ul>
			<li><b>Retribuci�n fija:</b> {0} � que se liquidar�n en 14 pagas. ~SalarioNeto|</li>
			
			<li><b>Retribuci�n Ayuda Comedor:</b> En el caso de que la jornada laboral sea superior a siete horas diarias percibir�s una ayuda comedor por un importe de <b> {0} �.</b>
			Este importe est� sujeto de acuerdo a la pol�tica de la compa��a en cada momento~AyudaComedor|</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la pol�tica de la compa��a en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>
		
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDEZ: </u></b>  La carta oferta se har� efectiva en el momento en que nos contactes, teniendo un plazo m�ximo de vigencia de 15 d�as naturales, a partir de la fecha de recepci�n de la misma.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>DOCUMENTACI�N NECESARIA: </u></b>  Con el fin de agilizar al m�ximo los tr�mites necesarios para tu contrataci�n, te detallamos la documentaci�n que debes remitirnos:<br/><br/>
			<b><u>Documentaci�n PREVIA a la contrataci�n: </u></b>	<br/><br/>
						<ul>
						<li> Carta Oferta firmada (todas las p�ginas). </li>
						<li> Copia DNI.  </li>
						<li>N�mero de afiliaci�n a la Seguridad Social (NAF).  </li>
						<li> Copia Vida Laboral detallada, puedes pedirla en el 901502050 (Servicio de Atenci�n telef�nica de la Seguridad Social), y ellos la enviar�n a tu domicilio.  </li>
						<li> Copia de la titulaci�n. En su defecto, fotocopia del resguardo correspondiente al abono de las tasas para la expedici�n de la misma. </li>
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
           
		   <b><u>Documentaci�n en supuestos especiales: </u></b>	<br/><br/>
						<ul>
						<li><u>Opci�n <b>Movilidad Geogr�fica:</b></u> Podr�s acogerte a una reducci�n fiscal si en el momento de la contrataci�n est�s <b>desempleado e inscrito</b> en la oficina de empleo, 
						y aceptas un puesto de trabajo situado en un municipio distinto al de tu residencia habitual, siempre que el nuevo puesto de trabajo exija un <b>cambio de dicha residencia.</b> 
						Si te aplica este supuesto, nos debes aportar: Copia <b>Tarjeta demandante de empleo + Certificado de dicho organismo,</b> acreditativo de la vigencia de la tarjeta en tu condici�n 
						de desempleado y  estar expedidos en tu <b>lugar de origen.</b></li>
						</ul>
		   <br/><br/>
		   <b><u>Documentaci�n a aportar el d�a de la incorporaci�n: </u></b><br/><br/>  
		   � Disponer de la informaci�n relativa a  tus datos bancarios (IBAN), puesto que deber�s rellenar un formulario indic�ndola. Es conveniente que traigas anotado el n�mero de cuenta. <br />
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		<b><u>Env�o de documentaci�n: </u></b><br/><br/>  
            �  La documentaci�n debe ser enviada al siguiente correo electr�nico:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}.</span></b></a>
			Si tienes cualquier duda relativa a dicha documentaci�n puedes enviarnos un e-mail a la direcci�n indicada o 
			puedes llamarnos al <b> {1}</b> (Departamento de contrataci�n)~MailTo~Telefono|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            �  Si te surgen dudas en relaci�n a las condiciones de esta oferta o sobre la concreci�n del d�a de tu incorporaci�n, puedes contactar tel�fono:<b> {0} </b>~Telefono~Atencion|
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
	', 4, 2017-08-28, 1, 'COPerfilesConExperiencia' , 96, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (56, 'AyudaComedor', 4, 2017-08-29, 1, '944,00')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (56, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Socio')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (56, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (56, 'MailTo', 4, 2017-08-29, 1, 'rrhh.murcia@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (56, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Juan Antonio Garay Aranburu')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (56, 'Telefono', 4, 2017-08-29, 1, '968 49 81 00')