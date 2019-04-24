update CorreoPlantilla
set TextoPlantilla = '<html><head> <title>Correo backlog</title>
</head>
<body lang="ES" style="" link="blue" vLink="purple">
<div>
    <div style="padding-left:1cm;padding-right:1cm">
		<p>
			<span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
		</p>
	
        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
          Buenos días {0},
        </div>~NombreCandidato|
		<br/>

        <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
				Nos complace comunicarte que has superado nuestro proceso de selección, no obstante, las necesidades de perfiles con conocimientos y categoría 
				similar a la tuya, son actualmente puntuales en nuestra Compañía, por ese motivo, tu candidatura queda aplazada hasta el momento en que surjan 
				necesidades que se ajusten a tu área de competencia. 
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
		
		</div></div></body></html>'
where PlantillaId = 21