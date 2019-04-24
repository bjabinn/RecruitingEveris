update CorreoPlantilla
set TextoPlantilla= '<html>
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
				Nos ponemos en contacto contigo para comunicarte que, tras el proceso de selección realizado en nuestras oficinas, valoramos que, 
				tanto su perfil como su área de competencia, no se ajustan de forma efectiva a nuestras necesidades actuales, por este motivo no ha sido 
				seleccionado para incorporarse en la Compañía.
        </div>
		<br/>
	   
	    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
			 Gracias por su tiempo.
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
</html>'
where PlantillaId = 24