SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(71, '
		 
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
           Bonjour,
        </div>
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           ¡Félicitations! Nous avons le plaisir de vous remettre notre offre et serions ravis de vous voir rejoindre notre filiale au Maroc.
        </div>
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Nous sommes une société internationale de conseil et de services informatiques, avec de solides perspectives de croissance et
				de développement et nous vous remercions pour la confiance que vous nous témoignez et votre intérêt pour nous rejoindre.
        </div>
		<br/>

     
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
				Au sein de<b> everis centers</b>,  vous trouverez l’endroit idéal pour développer vos compétences professionnelles, 
				bénéficier du plan de formation et disposer de stabilité afin de développer votre carrière dans l&#8216;entreprise à long terme.
        </div><!-- AQUI ESTA LA COMILLA-->
		<br/>
	 
       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
           Notre attitude nous rend différent et nous aide à atteindre les objectifs, en proposant des solutions innovantes dans tous les domaines.
        </div>
	   <br/>

       <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
          Une fois de plus, nous tenons à vous remercier pour le temps que vous nous avez consacré pendant le processus de sélection et surtout
		  vous souhaiter la bienvenue parmi les professionnels qui font partie de everis, en espérant que vous trouviez un excellent cadre de travail 
		  et que nous pourrons contribuer à votre développement professionnel.
        </div>
		<br/>
         
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Merci de nous renvoyer une copie signée de la lettre ainsi que de l’annexe (page 2) en indiquant votre acceptation à notre service recrutement.
        </div>
		<br/>

         <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
         Nous espérons recevoir rapidement votre confirmation ainsi que votre décision définitive.
        </div>
		<br/>
       
		 <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt; COLOR: #505050>
        Bien cordialement,
        </div>
		<br/>
        
		
		 <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
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
       
        <br/><br/>

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
          <b>CONDITIONS DE L’OFFRE À </b>{0}~NombreCandidato|
        </div>
		<br/>
	
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>CATÉGORIE PROFESSIONELLE PROPOSÉE</u>: </b> {0}~Categoria|
        </div>
		<br/>
		
	   <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
          <b><u>TYPE DE CONTRAT </u>: </b>  CDI avec 3 mois renouvelable une fois.
        </div>
		<br/>
	
       
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>REMUNERATION: </u></b> 
        			
				<ul>
			<li><b>Salaire fixe:</b> {0} dirhams <b>nets par mois sur12 mois.</b> ~SalarioNeto|</li>
			
			<li><b>Variable:</b> Annuel basé sur la performance.</li>
			</ul>
									
			<b>Beneficios Sociales: </b>  de acuerdo a la política de la compañía en cada momento y cumpliendo con los requisitos requeridos.
		</div>
		<br/>

		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>AUTRES BENEFICES: </u></b> 

		   <ul>
			<li><b>Bénéfices Sociaux:</b> CNSS, AMO et CIMR</li>
			
			<li><b>Assurance Maladie Complémentaire(AMC) dès la fin de la période d’éssai</b></li>
			</ul>
        </div>
		<br/>
		
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
           <b><u>VALIDITÉ DE L’OFFRE: </u></b>  Cette offre est valable pour une durée maximale de 5 jours ouvrables à partir de la date de l’envoi de l’offre.
        </div>
		<br/>
		        
		<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt;">
<!--AQUI-->           <b><u>DOSSIER D’EMBAUCHE: </u></b>  Afin d&#8216;accélérer les procédures nécessaires à votre incorporation, il est important que vous nous fassiez parvenir, dès que possible, les informations et documents que nous énumérons ci-dessous :<br/><br/>
			
						<ul>
						<li> 4 photos d’identité </li>
						<li> Un extrait de votre état civil  </li>
						<li>Un certificat d’acte de naissance  </li>
						<li> Un certificat médical  </li>
						<li> Un extrait de votre casier judiciaire </li>
						<li> Une attestation de travail de votre ancien employeur attestant de votre liberté de tout engagement et du salaire mensuel </li>
						<li>Photocopie certifiée conforme de votre C.I.N</li>
						<li>Photocopie certifiée conforme de vos diplômes</li>
						<li>Attestation de RIB</li>
						<li>N° d’Immatriculation CNSS</li>
						</ul>
			
			</div>

			<br/>

			<div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
		
            •  Les documents peuvent être envoyés par mail à:<a href="{0}"><b>
			<span style=''font-family:"Arial","sans-serif"''>{0}</span></b></a>
			 en attendant de nous remettre les originaux.~MailTo|
        </div>
		<br/>
      

	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 11pt;">
            •  Pour toute question concernant les conditions de cette offre, confirmer la date de votre incorporation aux dates souhaitées par la société ou pour toute autre question, merci de nous contacter par téléphone au:<b> {0} </b>(Département People).~Telefono~Atencion|
        </div>

		 
		 <br/><br/>
		 <div style="TEXT-ALIGN: justify;">
            <div style="FONT-FAMILY: ''Arial'',''sans-serif'';FONT-SIZE: 10pt; COLOR: #505050; width:30%;float:left;">
                {0}~NombreEntregaCarta|
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
		        
    </div>
		        
</div>
</body>
</html>
	', 4, 2017-08-28, 1, 'CartaOfertaGenerica' , 1170, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (71, 'CargoEntregaCarta', 4, 2017-08-29, 1, 'Fondé de Pouvoirs')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (71, 'Fax', 4, 2017-08-29, 1, '')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (71, 'MailTo', 4, 2017-08-29, 1, 'Recruiting.Centers.Morocco@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (71, 'NombreEntregaCarta', 4, 2017-08-29, 1, 'Fred SABBAH')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (71, 'Telefono', 4, 2017-08-29, 1, '+212.531.06.29.90')



